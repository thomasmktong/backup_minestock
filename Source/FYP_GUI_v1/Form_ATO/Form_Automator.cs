using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FYP_GUI_v1
{
    public partial class Form_Automator : Form
    {
        private MainForm pointer_MainForm = null;

        public Form_Automator(MainForm pointer)
        {
            pointer_MainForm = pointer;

            InitializeComponent();
            InitializeComboBox();

            Model_Automator.reset();
            dataGridView1.DataSource = Model_Automator.list;
        }

        public void InitializeComboBox()
        {
            foreach (string eachAct in pointer_MainForm.automatableList)
            {
                toolStripComboBox_listOfActions.Items.Add(eachAct);
            }
            toolStripComboBox_listOfActions.SelectedIndex = 0;
        }

        private void toolStripButton_add_Click(object sender, EventArgs e)
        {
            Form f = pointer_MainForm.getRespectiveForm(toolStripComboBox_listOfActions.SelectedItem);
            Model_Automator model = new Model_Automator(toolStripComboBox_listOfActions.SelectedItem.ToString());
            this.dataGridView1.DataSource = null;
            Model_Automator.list.Add(model);
            this.dataGridView1.DataSource = Model_Automator.list;
            ((Form_Automatable)f).Show_withAutomationSettings(model);
            if (this.Text.LastIndexOf('*') == -1) this.Text += '*';
        }

        private void toolStripButton_remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Model_Automator.list.RemoveAt(dataGridView1.SelectedRows[0].Index);
                if (this.Text.LastIndexOf('*') == -1) this.Text += '*';
            }
        }

        private void toolStripButton_setting_Click(object sender, EventArgs e)
        {
            Model_Automator model = Model_Automator.list[dataGridView1.SelectedRows[0].Index];
            if (model != null && model.Action != null && model.Action.Trim().Length != 0)
            {
                Form f = pointer_MainForm.getRespectiveForm(model.Action);
                ((Form_Automatable)f).Show_withAutomationSettings(model);
                if (this.Text.LastIndexOf('*') == -1) this.Text += '*';
            }
        }

        private void toolStripButton_up_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index >= 1)
            {
                Model_Automator temp = Model_Automator.list[dataGridView1.SelectedRows[0].Index];
                Model_Automator.list[dataGridView1.SelectedRows[0].Index] = Model_Automator.list[dataGridView1.SelectedRows[0].Index - 1];
                Model_Automator.list[dataGridView1.SelectedRows[0].Index - 1] = temp;
                if (this.Text.LastIndexOf('*') == -1) this.Text += '*';
            }
        }

        private void toolStripButton_down_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index < Model_Automator.list.Count - 1)
            {
                Model_Automator temp = Model_Automator.list[dataGridView1.SelectedRows[0].Index];
                Model_Automator.list[dataGridView1.SelectedRows[0].Index] = Model_Automator.list[dataGridView1.SelectedRows[0].Index + 1];
                Model_Automator.list[dataGridView1.SelectedRows[0].Index + 1] = temp;
                if (this.Text.LastIndexOf('*') == -1) this.Text += '*';
            }
        }

        private void toolStripButton_start_Click(object sender, EventArgs e)
        {
            Form_Autorun form_ar = new Form_Autorun(pointer_MainForm);
            form_ar.MdiParent = pointer_MainForm;
            form_ar.Show();
        }

        private void toolStripButton_subset_Click(object sender, EventArgs e)
        {
            Form f = pointer_MainForm.getRespectiveForm("SUBSET-START");
            Model_Automator model = new Model_Automator("SUBSET-START");
            this.dataGridView1.DataSource = null;
            Model_Automator.list.Add(model);
            this.dataGridView1.DataSource = Model_Automator.list;
            ((Form_Automatable)f).Show_withAutomationSettings(model);
            if (this.Text.LastIndexOf('*') == -1) this.Text += '*';
        }

        private void toolStripButton_univset_Click(object sender, EventArgs e)
        {
            Form f = pointer_MainForm.getRespectiveForm("SUBSET-END");
            Model_Automator model = new Model_Automator("SUBSET-END");
            this.dataGridView1.DataSource = null;
            Model_Automator.list.Add(model);
            this.dataGridView1.DataSource = Model_Automator.list;
            ((Form_Automatable)f).Show_withAutomationSettings(model);
            if (this.Text.LastIndexOf('*') == -1) this.Text += '*';
        }

        private void toolStripButton_save_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void toolStripButton_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogOpen = new OpenFileDialog();
            DialogOpen.DefaultExt = "xml";
            DialogOpen.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";
            DialogOpen.AddExtension = true;
            DialogOpen.RestoreDirectory = true;
            DialogOpen.Title = "Load Automation Script";
            DialogOpen.InitialDirectory = Config.AUTO_PATH_DEFAULT;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                string path = DialogOpen.FileName;
                Model_Automator.load(path);
                this.dataGridView1.DataSource = Model_Automator.list;
                this.Text = Text.Substring(0, Text.LastIndexOf('-')) + "- " + Path.GetFileName(path);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text.LastIndexOf('*') == -1) this.Text += '*';
        }

        private void Form_Automator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text.LastIndexOf('*') != -1)
            {
                var result = MessageBox.Show("Save changes of automator script?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    saveFile();
                }
            }
        }

        private void saveFile()
        {
            // Create new SaveFileDialog object
            SaveFileDialog DialogSave = new SaveFileDialog();

            // Default file extension
            DialogSave.DefaultExt = "xml";

            // Available file extensions
            DialogSave.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";

            // Adds a extension if the user does not
            DialogSave.AddExtension = true;

            // Restores the selected directory, next time
            DialogSave.RestoreDirectory = true;

            // Dialog title
            DialogSave.Title = "Save Automation Script";

            // Startup directory
            DialogSave.InitialDirectory = Config.AUTO_PATH_DEFAULT;

            // Show the dialog and process the result
            if (DialogSave.ShowDialog() == DialogResult.OK)
            {
                string file = Path.GetFileNameWithoutExtension(DialogSave.FileName);
                string path = DialogSave.FileName.Substring(0, DialogSave.FileName.LastIndexOf(file));
                Model_Automator.save(path, file);
                this.Text = Text.Substring(0, Text.LastIndexOf('-')) + "- " + file + ".xml";
            }

            DialogSave.Dispose();
            DialogSave = null;
        }
    }
}
