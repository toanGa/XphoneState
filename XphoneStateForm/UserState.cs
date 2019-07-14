using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XphoneStateForm
{
    public struct UserEvent
    {
        public string EventName;// keyboard0
        public string EventFunc;// keyboard0OfState
        public string EventDesciption;// implement of EventFunc
    }

    public class UserState
    {
        public string Name = "UNDEFINED";
        public string TransitionFunc;
        public List<UserEvent> OverrideEvents = new List<UserEvent>();

        public List<string> ToListOverrideEvent()
        {
            List<string> overrideList = new List<string>();
            int i;
            int numEvents = OverrideEvents.Count;
            for(i = 0; i < numEvents; i++)
            {
                overrideList.Add(OverrideEvents[i].EventName);
            }

            return overrideList;
        }

        public UserState MergeWithDefaultHandle(List<UserEvent> listEvent)
        {
            UserState userState = new UserState();
            int i;
            int numEvents = listEvent.Count;
            int idxExited = 0;
            userState.Name = this.Name;
            userState.TransitionFunc = this.TransitionFunc;
            userState.OverrideEvents = new List<UserEvent>(listEvent);

            for (i = 0; i < numEvents; i++)
            {
                if(ExistedEvent(userState.OverrideEvents[i].EventName, ref idxExited))
                {
                    //userState.OverrideEvents[i].EventName = this.OverrideEvents[idxExited].EventName;
                    //userState.OverrideEvents[i].EventFunc = this.OverrideEvents[idxExited].EventFunc;
                    //userState.OverrideEvents[i].EventDesciption = this.OverrideEvents[idxExited].EventDesciption;
                    userState.OverrideEvents[i] = this.OverrideEvents[idxExited];
                }
            }

            return userState;
        }

        bool ExistedEvent(string EventName, ref int idxIfExisted)
        {
            bool existed = false;
            int i;
            int numEvents = OverrideEvents.Count;
            for(i = 0; i < numEvents; i++)
            {
                if(OverrideEvents[i].EventName == EventName)
                {
                    existed = true;
                    idxIfExisted = i;
                    break;
                }
            }
            return existed;
        }
    }
    
}
