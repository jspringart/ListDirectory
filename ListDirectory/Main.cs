using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace ListDirectory
{
    public partial class Main : Form
    {
        private List<string> m_DisplayList;
        private List<string> m_FullList;

        public Main()
        {
            InitializeComponent();
            m_DisplayList = new List<string>();
            m_FullList = new List<string>();
        }

        private void selectDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    Program.DirectoryPath = folderBrowserDialog.SelectedPath;
                    loadNames();
                }
            }
        }

        private void loadNames()
        {
            List<string> dir = new List<string>();
            List<string> file = new List<string>();
            Program.ListFoldersAndFiles(Program.DirectoryPath, out dir, out file);

            List<string> items = new List<string>();
            items.AddRange(dir);
            items.AddRange(file);

            m_FullList = items;
            updateNames(m_FullList);
        }

        private void updateNames(List<string> items)
        {
            m_DisplayList.Clear();
            m_DisplayList = Program.GetFolderAndFileNames(items, extensions.Checked);

            names.DataSource = null;
            names.DataSource = m_DisplayList;
        }

        private void extensions_CheckedChanged(object sender, EventArgs e)
        {
            updateNames(m_FullList);
        }

        private void remove_Click(object sender, EventArgs e)
        {
            foreach (var item in names.SelectedItems)
            {
                var test = m_FullList.FirstOrDefault(s => s.Contains(item.ToString()));
                string ss = test;
                m_FullList.Remove(test.ToString());
            }
            updateNames(m_FullList);
        }

        private void toTxt_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    Program.SaveOutputFile(sfd.FileName, m_DisplayList);
                }
            }
        }
    }
}
