using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XphoneStateForm
{
    class Database
    {
        private const string USER_STATE_FILE = "user_state.xml";
        private const string DEFAULT_IMPLEMENT = "default_implement.xml";

        public static List<UserState> AllUserState = new List<UserState>();
        public static List<UserEvent> DefaultImplemt = new List<UserEvent>();

        public static void ReadTest()
        {
            string data = File.ReadAllText(USER_STATE_FILE);
            AllUserState = XMLSerialUtil<List<UserState>>.Deserialize(data);
        }

        public static void WriteTest()
        {
            string data = XMLSerialUtil<List<UserState>>.Serialize(AllUserState);
            File.WriteAllText(USER_STATE_FILE, data);
        }

        public static bool ReadDatabase(string fileName = "")
        {
            bool readStatus = true;
#if true
            string data; ;
            if (!string.IsNullOrEmpty(fileName))
            {
                data = File.ReadAllText(USER_STATE_FILE);
            }
            else
            {
                data = File.ReadAllText(USER_STATE_FILE);
            }
           
            AllUserState = XMLSerialUtil<List<UserState>>.Deserialize(data);
#else
            if (!File.Exists(USER_STATE_FILE))
            {
                StreamWriter writer = new StreamWriter(USER_STATE_FILE);
                writer.Close();
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<UserState>));
                FileStream fs = null;
                try
                {
                    fs = new FileStream(USER_STATE_FILE, FileMode.Open);
                    AllUserState = (List<UserState>)serializer.Deserialize(fs);
                }
                catch (System.Exception ex)
                {
                    readStatus = false;
                    throw ex;
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }

            if (!File.Exists(DEFAULT_IMPLEMENT))
            {
                StreamWriter writer = new StreamWriter(DEFAULT_IMPLEMENT);
                writer.Close();
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<UserEvent>));
                FileStream fs = null;
                try
                {
                    fs = new FileStream(DEFAULT_IMPLEMENT, FileMode.Open);
                    DefaultImplemt = (List<UserEvent>)serializer.Deserialize(fs);
                }
                catch (System.Exception ex)
                {
                    readStatus = false;
                    throw ex;
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
#endif
            return readStatus;
        }

        public static bool WriteDatabase()
        {
            return SaveAsDatabase(USER_STATE_FILE, DEFAULT_IMPLEMENT);
        }

        public static bool SaveAsDatabase(string stateFileName, string defaultImplementFile)
        {
            bool writeStatus = true;

#if true
            string data = XMLSerialUtil<List<UserState>>.Serialize(AllUserState);
            File.WriteAllText(stateFileName, data);           
#else
            XmlSerializer mySerializer;
            if(!string.IsNullOrEmpty(stateFileName))
            {
                try
                {
                    mySerializer = new XmlSerializer(typeof(List<UserState>));
                    // Writing the file requires a TextWriter.
                    if (!File.Exists(stateFileName))
                    {
                        //File.Create(stateFileName);
                        StreamWriter Fwriter = new StreamWriter(stateFileName);
                        Fwriter.Close();
                    }
                    TextWriter writer = new StreamWriter(stateFileName);
                    mySerializer.Serialize(writer, AllUserState);
                    writer.Close();
                }
                catch (System.Exception ex)
                {
                    writeStatus = false;
                    throw ex;
                }
            }

            if (!string.IsNullOrEmpty(defaultImplementFile))
            {
                try
                {
                    mySerializer = new XmlSerializer(typeof(List<UserEvent>));
                    // Writing the file requires a TextWriter.
                    if (!File.Exists(defaultImplementFile))
                    {
                        //File.Create(defaultImplementFile);
                        StreamWriter Fwriter = new StreamWriter(defaultImplementFile);
                        Fwriter.Close();
                    }
                    TextWriter writer = new StreamWriter(defaultImplementFile);
                    mySerializer.Serialize(writer, DefaultImplemt);
                    writer.Close();
                }
                catch (System.Exception ex)
                {
                    writeStatus = false;
                    throw ex;
                }
            }
#endif
            return writeStatus;
        }
    }
}
