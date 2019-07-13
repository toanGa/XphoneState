using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XphoneStateForm
{
    public partial class Form1 : Form
    {
        List<UserEvent> userEvents; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string fileName = @"E:\git-server\GIT_LAB\os\source\threads\user_handler\user_handler_events.c";
            string content = File.ReadAllText(fileName);
            DefaultEventParser Parser = new DefaultEventParser();
            string contentParsed = Parser.ParseFunc("defaultUserHandler", content);
            textBoxDebug.Text = contentParsed;

            userEvents = Parser.ParseDefaultImplementationEvent(fileName);
        }
    }
}
