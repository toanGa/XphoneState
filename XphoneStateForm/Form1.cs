using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        UserState mStateViewing = null;

        private const int StartLocX = 20;
        private const int StartLocY = 10;

        public Form1()
        {
            InitializeComponent();

            Setting.ReadSetting();
        }

        public void AddEvent(Panel panel, UserState state)
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

                ctrl.Click += DynamicStateEventClick;

                // TODO: add event handler
                panel.Controls.Add(ctrl);

                mCountImg++;
            }
        }

        void SetSourceTextBoxState()
        {
            AutoCompleteStringCollection autoTextBoxState = new AutoCompleteStringCollection();

            textBoxSearchState.AutoCompleteCustomSource.Clear();
            textBoxSearchState.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxSearchState.AutoCompleteSource = AutoCompleteSource.CustomSource;

            addItems(autoTextBoxState);
            textBoxSearchState.AutoCompleteCustomSource = autoTextBoxState;
        }

        void SetSourceTextBoxEvent(UserState state)
        {
            AutoCompleteStringCollection autoTextBoxState = new AutoCompleteStringCollection();
            string[] arrEvents = state.ToListOverrideEvent().ToArray();

            textBoxEvent.AutoCompleteCustomSource.Clear();
            textBoxEvent.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxEvent.AutoCompleteSource = AutoCompleteSource.CustomSource;

            autoTextBoxState.AddRange(arrEvents);
            if(arrEvents.Length > 0)
            {
                textBoxEvent.Text = arrEvents[0];
            }
            textBoxEvent.AutoCompleteCustomSource = autoTextBoxState;

            mStateViewing = state;
        }

        private void addItems(AutoCompleteStringCollection col)
        {
            int i;
            int numStates = Database.AllUserState.Count;
            List<string> names = new List<string>();
            for (i = 0; i < numStates; i++)
            {
                names.Add(Database.AllUserState[i].Name);
            }

            col.Clear();
            col.AddRange(names.ToArray());
        }

        private void DynamicStateEventClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            UserEvent userEvent = (UserEvent)button.Tag;

            textBoxDebug.Text = userEvent.EventDesciption;

            List<UserState> nextState = UserStateParser.GetNextStates(userEvent, Database.AllUserState);
            AddNextState(panelNextState, nextState);
        }

        public void AddNextState(Panel panel, List<UserState> state)
        {
            int locnewX;
            int locnewY;
            int mCurrLocY = StartLocY;
            int mCountImg = 0;
            panel.Controls.Clear();

            for (int i = 0; i < state.Count; i++)
            {
                Button ctrl = new Button();
                if (state[i].TransitionFunc == UserStateParser.JUMP_BACK_FUNC)
                {
                    ctrl.ForeColor = Color.Orange;
                }
                else
                {
                    ctrl.ForeColor = Color.Green;
                }


                ctrl.Tag = state[i];

                ctrl.Width = 250;
                ctrl.Text = state[i].Name;

                mCurrLocY += ctrl.Height + 10;

                locnewX = StartLocX;
                locnewY = mCurrLocY;

                ctrl.Name = "DymanicState" + mCountImg;
                ctrl.BackColor = Color.Transparent;
                ctrl.Location = new Point(locnewX, locnewY);

                ctrl.Click += DynamicStateClick;

                // TODO: add event handler
                panel.Controls.Add(ctrl);

                mCountImg++;
            }
        }

        private void DynamicStateClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Clipboard.SetText(b.Text);

            labelStatus.Text = "Copied to clipboard";
        }

        void AssignAllState()
        {
            int i;
            int numStates = Database.AllUserState.Count;
            List<string> names = new List<string>();
            for(i = 0; i < numStates; i++)
            {
                names.Add(Database.AllUserState[i].Name);
            }

            if(numStates > 0)
            {
                comboBox1.DataSource = names;
                comboBox1.Text = names[0];
                comboBox1.Tag = (Database.AllUserState[0]);
                textBoxFileLocation.Text = ((UserState)(comboBox1.Tag)).FileSource;
            }

            SetSourceTextBoxState();
            if(numStates > 0)
            {
                SetSourceTextBoxEvent(Database.AllUserState[0]);
            }
            MessageBox.Show(numStates + " states");
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
            else
            {
                if(!string.IsNullOrEmpty(Setting.FoderUser))
                {
                    FoderLastSelected = Setting.FoderUser;
                    if (Directory.Exists(FoderLastSelected))
                    {
                        folderDlg.SelectedPath = FoderLastSelected;
                    }
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
                    Database.DefaultImplemt = DefaultEventParser.ParseDefaultImplementationEvent(fileDefaultaHandler);
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

                Database.AllUserState.Clear();

                for (int i = 0; i < numFiles; i++)
                {
                    if(AllFiles[i].Contains(".c") || AllFiles[i].Contains(".cpp"))
                    {
                        UserState state = UserStateParser.ParseState(AllFiles[i]);

                        if (state != null)
                        {
                            UserState mergeState = state.MergeWithDefaultHandle(Database.DefaultImplemt);
                            Database.AllUserState.Add(mergeState);
                        }
                    }

                }
                // Assign data to UI of every user_state
                AssignAllState();

                // Save current foder for user
                if (FoderLastSelected != Setting.FoderUser)
                {
                    Setting.WriteSetting(FoderLastSelected);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxSelected = comboBox1.SelectedIndex;
            comboBox1.Tag = (Database.AllUserState[idxSelected]);
            textBoxFileLocation.Text = ((UserState)(comboBox1.Tag)).FileSource;

            AddEvent(this.panelEvent, Database.AllUserState[idxSelected]);
            SetSourceTextBoxEvent(Database.AllUserState[idxSelected]);

            this.labelStatus.Text = string.Format("{0} events", ((UserState)(comboBox1.Tag)).OverrideEvents.Count);
        }

        private void panelEvent_MouseEnter(object sender, EventArgs e)
        {
            panelEvent.Focus();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Database.AllUserState.Count > 0)
            {
                Database.WriteDatabase();
                labelStatus.Text = "Saved file";
            }
            else
            {
                labelStatus.Text = "No data to save";
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.AllUserState.Count == 0)
            {
                labelStatus.Text = "No data to save";
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Title = "Save state Files";
                saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "xml";
                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    bool saveStat = Database.SaveAsDatabase(saveFileDialog1.FileName, null);
                    if (saveStat)
                    {
                        labelStatus.Text = "Saves file: " + saveFileDialog1.FileName;
                    }
                    else
                    {
                        labelStatus.Text = "Cannot save state file";
                    }
                }
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath),
                Title = "Open State file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bool readStatus = Database.ReadDatabase(openFileDialog1.FileName);
                if (readStatus)
                {
                    // Assign data to UI of every user_state
                    AssignAllState();
                    labelStatus.Text = "Read success";
                }
                else
                    labelStatus.Text = "Cannot read data";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void ButtonOpenFileLocation_Click(object sender, EventArgs e)
        {
            string fileOpen = textBoxFileLocation.Text;

            if(!string.IsNullOrEmpty(fileOpen))
            {
                if(File.Exists(fileOpen))
                {
                    Process.Start(fileOpen);
                }
            }
        }

        private void TextBoxSearchState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string txt = (sender as TextBox).Text;
                int i;
                int numStates = Database.AllUserState.Count;
                
                for (i = 0; i < numStates; i++)
                {
                    if(Database.AllUserState[i].Name == txt)
                    {
                        comboBox1.Text = txt;
                        comboBox1.Tag = (Database.AllUserState[i]);
                        textBoxFileLocation.Text = ((UserState)(comboBox1.Tag)).FileSource;

                        AddEvent(this.panelEvent, Database.AllUserState[i]);

                        this.labelStatus.Text = string.Format("{0} events", ((UserState)(comboBox1.Tag)).OverrideEvents.Count);

                        break;
                    }
                }
            }
        }

        private void TextBoxEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string txt = (sender as TextBox).Text;
                int i;

                for (i = 0; i < panelEvent.Controls.Count; i++)
                {
                    if (panelEvent.Controls[i].Text == txt)
                    {
                        DynamicStateEventClick(panelEvent.Controls[i], null);
                        break;
                    }
                }

            }
        }
    }
}
