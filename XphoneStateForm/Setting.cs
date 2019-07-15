using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XphoneStateForm
{
    class Setting
    {
        private static string SETTING_FILE = "user_setting";
        public static string FoderUser;

        public static void ReadSetting()
        {
            if(!File.Exists(SETTING_FILE))
            {
                File.Create(SETTING_FILE);
            }
            else
            {
                FoderUser = File.ReadAllText(SETTING_FILE);
            }
        }

        public static void WriteSetting(string newFoder)
        {
            File.WriteAllText(SETTING_FILE, newFoder);
            FoderUser = newFoder;
        }
    }
}
