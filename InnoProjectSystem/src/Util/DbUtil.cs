﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace InnoProjectSystem.src.Util
{
    class DbUtil
    {

        /*用于创建数据库连接，返回SqlConnection*/
        public static SqlConnection getConnection()
        {
            string strCnn = ConfigurationManager.ConnectionStrings["InnoProjectCnnString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(strCnn);
            return cnn;
        }

    }
}
