using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Reflection;

namespace BookLibrayWeb
{
    public partial class Search : System.Web.UI.Page
    {
        Logic logic = new Logic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable("Books");

                dt = logic.GetBooks(DDLFilter.SelectedValue.ToString(), txtSearch.Text.Trim().ToUpper());

                if (dt != null && dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }//if
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                }

            }//try
            catch (Exception)
            {

            }
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable("Books");

                dt = logic.GetBooks("","");

                if (dt != null && dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }//if
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                }

            }//try
            catch (Exception)
            {

            }
        }
    }
}