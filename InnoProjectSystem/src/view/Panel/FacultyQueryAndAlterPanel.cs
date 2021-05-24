﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using InnoProjectSystem.src.Util;
using InnoProjectSystem.src.models;

namespace InnoProjectSystem.src.view.Panel
{
    public partial class FacultyQueryAndAlterPanel : UserControl
    {
        private DataTable FacultyTable;
        private DataTable CollegeTable;
        private SqlConnection sqlConnection;

        public FacultyQueryAndAlterPanel()
        {
            InitializeComponent();
            this.FacultyTable = new DataTable();
            this.CollegeTable = new DataTable();
            this.sqlConnection = DbUtil.getConnection();
        }

        private void FacultyQueryAndAlterPanel_Load(object sender, EventArgs e)
        {
            //填充院系下拉框
            SqlDataAdapter collegeAdapter = new SqlDataAdapter("select * from College", this.sqlConnection);
            collegeAdapter.Fill(this.CollegeTable);

            DataRow newrow = this.CollegeTable.NewRow();    //多创建一空选项
            newrow["ColNo"] = "";
            newrow["ColName"] = "";
            this.CollegeTable.Rows.InsertAt(newrow, 0);

            this.CollegeCBox.DataSource = this.CollegeTable;
            this.CollegeCBox.DisplayMember = "ColName";
            this.CollegeCBox.ValueMember = "ColNo";
        }
    }
}