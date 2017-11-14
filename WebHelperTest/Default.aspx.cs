using System;
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
            string id = WebHelper.Request.Request.get("id");

            Response.Write("id:" + id);

            WebHelper.DataBase.MSSQL db = new WebHelper.DataBase.MSSQL();

            DataTable dt = db.DataTable("select * from Blog");

            if (db.Message != "")
            {
                Response.Write("<br>Message:" + db.Message);
            }

            string str = "<table border='1'>";
            foreach(DataRow dr in dt.Rows)
            {
                str += "<tr><td>"+dr["cName"]+ "</td><td>" + dr["dcdate"] + "</td></tr>";
            }
            str += "</table>";

            Response.Write("<br>" + str);



            string ConnStr1 = ConfigurationManager.AppSettings["ConnStr1"];

            Response.Write("ConnStr1:" + ConnStr1);


        }
    }
}