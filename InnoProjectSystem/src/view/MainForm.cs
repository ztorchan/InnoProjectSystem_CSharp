﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InnoProjectSystem.src.models;
using InnoProjectSystem.src.view.Panel;

namespace InnoProjectSystem.src.view
{
    public partial class MainForm : Form
    {
        public User user;
        public MainForm(User u)
        {
            InitializeComponent();
            this.user = u;
        }

        private void PersonInfoItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new PersonInfoPanel(this.user));
        }

        private void PeopleQandCItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new FacultyQueryAndAlterPanel());
        }

        private void PeopleAddItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new FacultyAddPanel());
        }

        private void ProjectAddItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new ProjectAddPanel());
        }

        private void ProjectQandCItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new ProjectQueryAndAlter());
        }

        private void ProjectTypeItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new ProjectTypePanel());
        }
    }
}
