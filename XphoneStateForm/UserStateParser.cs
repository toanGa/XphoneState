using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XphoneStateForm
{
    class UserStateParser
    {
        const string TRANS_RET_TYPE = "userStatePtr";
        const string NODE_DEFINE = "static struct userHandlerState";
        /// <summary>
        /// Parse all infomation of a state
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static UserState ParseState(string fileName)
        {
            UserState state = new UserState();
            string contentFile = File.ReadAllText(fileName);
            string FuncDefine = ParseTransitionFunction(contentFile);
            if(string.IsNullOrEmpty(FuncDefine))
            {
                return null;
            }

            string[] lines = FuncDefine.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int i;
            int numLines = lines.Length;
            string Node = "";
            string transitonFunction = "";

            // Find transition function name
            transitonFunction = lines[0].Substring(lines[0].IndexOf(TRANS_RET_TYPE) + TRANS_RET_TYPE.Length).Trim();
            transitonFunction = transitonFunction.Substring(0, transitonFunction.IndexOf('(')).Trim();
            state.TransitionFunc = transitonFunction;

            for (i = 1; i < numLines; i++)
            {
                if(lines[i].Contains(NODE_DEFINE))
                {
                    string defineNode = lines[i];
                    string s = defineNode.Substring(defineNode.IndexOf(NODE_DEFINE) + NODE_DEFINE.Length);
                    s = s.Replace(" ", "").Replace(" ", "").Replace(";", "");
                    Node = s;
                    break;
                }
            }

            if(!string.IsNullOrEmpty(Node))
            {
                for (i = 1; i < numLines; i++)
                {
                    string s = lines[i].Trim();
                    // not a comment line
                    if (s.Length >= 2 && s[0] != '/' && s[1] != '/')
                    {
                        if (s.Contains(Node + "."))
                        {
                            // Found Name of state
                            if(s.Contains(Node + ".name"))
                            {
                                s = s.Substring((Node + ".name").Length);
                                int assignIdx = s.IndexOf("\"");
                                s = s.Substring(assignIdx + 1);

                                int breakIdx = s.IndexOf("\"");
                                if(assignIdx >= 0 && breakIdx >= 0)
                                {
                                    s = s.Substring(0, breakIdx);

                                    state.Name = s;
                                }
                                else
                                {
                                    string nextLine = lines[i + 1].Trim();

                                    assignIdx = nextLine.IndexOf("\"");
                                    s = nextLine.Substring(assignIdx + 1);
                                    breakIdx = s.IndexOf("\"");

                                    s = s.Substring(0, breakIdx);
                                    state.Name = s;
                                }
                            }
                            else
                            {
                                // override handle event
                                UserEvent userEvent = new UserEvent();
                                string eventName = "";
                                string eventFunc = "";
                                string eventDescript = "";

                                int idxEqual = s.IndexOf("=");
                                int idxBreak = s.IndexOf(";");
                                
                                // TODO: check list default event include this event name
                                eventName = s.Substring(s.IndexOf(Node + ".") + (Node + ".").Length).Trim();
                                eventName = eventName.Substring(0, eventName.IndexOf("=")).Trim();
                                // the line may be break into 2 lines
                                if (idxBreak >= 0)
                                {
                                    eventFunc = s.Substring(idxEqual + 1).Trim();
                                    eventFunc = eventFunc.Substring(0, eventFunc.IndexOf(";")).Trim();
                                }
                                else
                                {
                                    // assign fucntion is new line
                                    string nextLine = lines[i + 1].Trim();
                                    idxBreak = nextLine.IndexOf(";");
                                    eventFunc = nextLine.Substring(0, idxBreak);
                                }

                                if(!string.IsNullOrEmpty(eventFunc))
                                {
                                    eventDescript = DefaultEventParser.ParseFunc(eventFunc, contentFile);
                                }

                                userEvent.EventName = eventName;
                                userEvent.EventFunc = eventFunc;
                                userEvent.EventDesciption = eventDescript;

                                state.OverrideEvents.Add(userEvent);
                            }
                        }
                        
                    }
                }
            }


            return state;
        }

        /// <summary>
        /// Parse content of transition function
        /// </summary>
        /// <param name="contentFile"></param>
        /// <returns></returns>
        public static string ParseTransitionFunction(string contentFile)
        {
            string[] lines = contentFile.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int i;
            int j = 0;
            int numLines = lines.Length;
            int countOpen = 0;
            int countClose = 0;
            string contentFunc = "";

            for (i = 0; i < numLines; i++)
            {
                string line = lines[i].Trim();
                if (line.IndexOf(TRANS_RET_TYPE) == 0)
                {
                    if (lines[i + 1].Contains('{'))
                    {
                        int idxFunc = contentFile.IndexOf(line);
                        string funcDefine = contentFile.Substring(idxFunc);
                        j = 0;
                        while ((countClose != countOpen) || countClose == 0)
                        {
                            if (funcDefine[j] == '{')
                            {
                                countOpen++;
                            }
                            else if (funcDefine[j] == '}')
                            {
                                countClose++;
                            }
                            j++;
                        }
                        contentFunc = funcDefine.Substring(0, j);

                        break;
                    }
                }
            }

            return contentFunc;
        }
    }
}
