﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebHelper;
using System.Data;
using System.Configuration;
 


namespace WebHelperTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string id = WebHelper.Request.get("id");

            //Response.Write("id:" + id);

            WebHelper.DataBase db = new WebHelper.DataBase();

            DataTable dt = db.DataTable("select * from Blog");
 

            
            if (db.Message != "")
            {
                //Response.Write("<br>Message:" + db.Message);
            }

            string str = "<table  class='table table-bordered table-hove'>";
            foreach(DataRow dr in dt.Rows)
            {
                str += "<tr><td width='30px'>"+dr["cName"]+ "</td><td>" + dr["dcdate"] + "</td></tr>";
            }
            str += "</table>";

            //Response.Write("<br>" + str);



            string ConnStr1 = ConfigurationManager.AppSettings["ConnStr1"];

            //Response.Write("ConnStr1:" + ConnStr1);


        }
    }
}