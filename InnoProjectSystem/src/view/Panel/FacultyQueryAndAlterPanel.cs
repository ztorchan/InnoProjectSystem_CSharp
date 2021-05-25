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

        /*查询按钮处理*/
        private void QueryBtn_Click(object sender, EventArgs e)
        {
            this.DisplayData2View();

            return;
        }

        /*根据条件将教师信息显示在表格中*/
        private void DisplayData2View()
        {
            //构建查询语句
            string queryCmd = "Select FNo, FName, ColName, FGender, FTitle, FEmail " +
                "From Faculty, College " +
                "Where Faculty.ColNo = College.ColNo";
            if (CollegeCBox.SelectedValue != String.Empty)
            {
                queryCmd += (" and Faculty.ColNo='" + CollegeCBox.SelectedValue.ToString() + "'");
            }
            if (GenderCBox.SelectedItem != null && GenderCBox.SelectedItem.ToString() != String.Empty)
            {
                queryCmd += (" and FGender='" + GenderCBox.SelectedItem.ToString() + "'");
            }
            if (TitleTxt.Text != String.Empty)
            {
                queryCmd += (" and FTitle like '%" + TitleTxt.Text.ToString() + "%'");
            }
            if (NameTxt.Text != String.Empty)
            {
                queryCmd += (" and FName like '%" + NameTxt.Text.ToString() + "%'");
            }
            if (IdTxt.Text != String.Empty)
            {
                queryCmd += (" and FNo like '%" + IdTxt.Text.ToString() + "%'");
            }

            SqlDataAdapter FacultyAdapter = new SqlDataAdapter(queryCmd, this.sqlConnection);
            this.FacultyTable.Clear();
            FacultyAdapter.Fill(this.FacultyTable);
            this.FacultyView.DataSource = this.FacultyTable;

            string[] vs =
            {
                "员工号",
                "姓名",
                "院系单位",
                "性别",
                "职称",
                "电子邮箱"
            };
            for (int i = 0; i < 6; i++)
            {
                this.FacultyView.Columns[i].HeaderText = vs[i];
            }

            return;
        }

        /*删除按钮事件*/
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            //判断是否选中
            if(this.FacultyView.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中");
                return;
            }

            if(MessageBox.Show("确认删除？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            //选中，提取教师id，开始删除
            for(int i=0; i< this.FacultyView.SelectedRows.Count; i++)
            {
                string fno = "";
                fno = FacultyView.SelectedRows[i].Cells[0].Value.ToString();
                Faculty.DeleteByFno(fno);
            }

            //重新加载FacultyView
            DisplayData2View();
            return;
        }
    }
}
