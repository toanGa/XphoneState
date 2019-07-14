using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XphoneStateForm
{
    class DefaultEventParser
    {
        /// <summary>
        /// Parse default implementation on file "user_handler_event.c"
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<UserEvent> ParseDefaultImplementationEvent(string fileName)
        {
            string fileContent = File.ReadAllText(fileName);
            string defineFunc = "void userHandler_defaultImplementation (userStatePtr state)\r\n{";
            int idx = fileContent.IndexOf(defineFunc);
            int countOpen = 0;
            int countClose = 0;
            int i = 0;
            string contentFunc = "";
            List<UserEvent> userEvents = new List<UserEvent>();
            if (idx > 0)
            {
                string testString = fileContent.Substring(idx, fileContent.Length - idx);
                while ((countClose != countOpen) || countClose == 0)
                {
                    if (testString[i] == '{')
                    {
                        countOpen++;
                    }
                    else if (testString[i] == '}')
                    {
                        countClose++;
                    }
                    i++;
                }
                contentFunc = testString.Substring(0, i);
            }
            else
            {
                // cannot found function
            }

            if (!string.IsNullOrEmpty(contentFunc))
            {
                string[] lines = contentFunc.Split( new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None );
                for(int j = 0; j < lines.Length; j++)
                {
                    string s = lines[j].Trim();

                    if (s.Length >= 2 && s[0] != '/' && s[1] != '/')
                    {
                        string assignFunc = s.Replace(" ", "").Replace(" ", "");
                        int idxAssign = assignFunc.IndexOf("state->", 0);
                        if (idxAssign >= 0)
                        {
                            int idxStart = assignFunc.IndexOf("->");
                            int idxEqual = assignFunc.IndexOf('=');
                            int idxStop = assignFunc.IndexOf(';');
                            if (idxEqual > 0 && idxStop > 0)
                            {
                                string s1 = assignFunc.Substring(idxStart + 2, idxEqual - idxStart - 2);
                                string s2 = assignFunc.Substring(idxEqual + 1, idxStop - idxEqual - 1);
                                UserEvent userEvent = new UserEvent();
                                userEvent.EventName = s1;
                                userEvent.EventFunc = s2;
                                userEvent.EventDesciption = ParseFunc(userEvent.EventFunc, fileContent);
                                userEvents.Add(userEvent);
                            }
                        }
                    }
                }
            }

            return userEvents;
        }

        /// <summary>
        /// Get function implementation 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        public static string ParseFunc(string func, string fileContent)
        {
            string funcDefine = "void " + func + " (userStatePtr* state)\r\n{";
            int idx = fileContent.IndexOf(funcDefine);
            int countOpen = 0;
            int countClose = 0;
            int i = 0;
            string contentFunc = "";

            if(idx < 0)
            {
                // cannot found with fomat string
                // try with another fomat
                funcDefine = "void " + func + "(userStatePtr* state)\r\n{";
                idx = fileContent.IndexOf(funcDefine);
            }

            if (idx > 0)
            {
                string testString = fileContent.Substring(idx, fileContent.Length - idx);
                while ((countClose != countOpen) || countClose == 0)
                {
                    if(testString[i] == '{')
                    {
                        countOpen++;
                    }
                    else if(testString[i] == '}')
                    {
                        countClose++;
                    }
                    i++;
                }
                contentFunc = testString.Substring(0, i);
            }
            else
            {
                // cannot found function
            }
            return contentFunc;
        }
    }
}
