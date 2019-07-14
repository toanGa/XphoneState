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
        string FoderLastSelected = "";
        List<UserState> AllUserState = new List<UserState>();
        List<UserEvent> DefaultImplemt = new List<UserEvent>();

        private const int StartLocX = 20;
        private const int StartLocY = 10;


        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AssignAllState();
        }

        public void AddLabel(Panel panel, UserState state)
        {
           
            int locnewX;
            int locnewY;
            int mCurrLocY = StartLocY;
            int mCountImg = 0;
            panel.Controls.Clear();

            for(int i = 0; i < state.OverrideEvents.Count; i++)
            {
                Button ctrl = new Button();
                if(state.OverrideEvents[i].EventFunc == "defaultUserHandler")
                {
                    ctrl.ForeColor = Color.Orange;
                }
                else
                {
                    ctrl.ForeColor = Color.Green;
                }
               

                ctrl.Tag = state.OverrideEvents[i];

                ctrl.Width = 250;
                ctrl.Text = state.OverrideEvents[i].EventName;

                mCurrLocY += ctrl.Height + 10;

                locnewX = StartLocX;
                locnewY = mCurrLocY;

                ctrl.Name = "DymanicLabel" + mCountImg;
                ctrl.BackColor = Color.Transparent;
                ctrl.Location = new Point(locnewX, locnewY);

                ctrl.Click += DynamicLabelClick;

                // TODO: add event handler
                panel.Controls.Add(ctrl);

                mCountImg++;
            }
        }

        private void DynamicLabelClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            UserEvent userEvent = (UserEvent)button.Tag;

            textBoxDebug.Text = userEvent.EventDesciption;
        }

        void AssignAllState()
        {
            int i;
            int numStates = AllUserState.Count;
            List<string> names = new List<string>();
            for(i = 0; i < numStates; i++)
            {
                names.Add(AllUserState[i].Name);
            }

            comboBox1.DataSource = names;
            comboBox1.Text = names[0];
            comboBox1.Tag = (AllUserState[0]);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            folderDlg.Description = "Choose (user_handler) foder";

            if (!string.IsNullOrEmpty( FoderLastSelected))
            {
                if(Directory.Exists(FoderLastSelected))
                {
                    folderDlg.SelectedPath = FoderLastSelected;
                }
            }
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Parse default implementation
                string fileDefaultaHandler = folderDlg.SelectedPath + "/user_handler_events.c";
                if (!File.Exists(fileDefaultaHandler))
                {
                    fileDefaultaHandler = folderDlg.SelectedPath + "/user_handler_events.cpp";
                }
                if (File.Exists(fileDefaultaHandler))
                {
                    DefaultImplemt = DefaultEventParser.ParseDefaultImplementationEvent(fileDefaultaHandler);
                }
                else
                {
                    MessageBox.Show("Cannot open file user_handler_events");
                }

                // Parse for every state
                textBoxUserHandleFoder.Text = folderDlg.SelectedPath;
                FoderLastSelected = folderDlg.SelectedPath;

                string[] AllFiles = Directory.GetFiles(folderDlg.SelectedPath, "*", SearchOption.AllDirectories);
                int numFiles = AllFiles.Length;

                for (int i = 0; i < numFiles; i++)
                {
                    if(AllFiles[i].Contains(".c") || AllFiles[i].Contains(".cpp"))
                    {
                        UserState state = UserStateParser.ParseState(AllFiles[i]);

                        if (state != null)
                        {
                            UserState mergeState = state.MergeWithDefaultHandle(DefaultImplemt);
                            AllUserState.Add(mergeState);
                        }
                    }

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxSelected = comboBox1.SelectedIndex;
            comboBox1.Tag = (AllUserState[idxSelected]);

            AddLabel(this.panel1, AllUserState[idxSelected]);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Focus();
        }
    }
}
