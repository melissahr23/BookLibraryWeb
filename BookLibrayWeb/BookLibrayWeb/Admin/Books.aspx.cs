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



namespace BookLibrayWeb.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        Logic logic = new Logic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                BindBook();

            }

        }


        private void BindBook()
        {
            try
            {
                DataTable dt = new DataTable("Book");

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




        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            btnAdd.Enabled = true;
            GridView1.EditIndex = -1;
            BindBook();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            btnAdd.Enabled = false;
            GridView1.EditIndex = e.NewEditIndex;
            BindBook();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                btnAdd.Enabled = false;
                string sResult = string.Empty;
                string sID = ((Label)GridView1.Rows[e.RowIndex].Cells[1].FindControl("lblID")).Text;
                string sBook = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txtBook")).Text.Trim().ToUpper();
                string sAuthorID = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("DDLAuthor")).SelectedValue.ToString();
                string sCategoryID = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[3].FindControl("DDLCategory")).SelectedValue.ToString();


                sResult = logic.UpdateBook(sID, sBook, sAuthorID, sCategoryID);

                if (sResult != "Ok")
                {
                    btnAdd.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;

                    GridView1.EditIndex = -1;
                    BindBook();

                }


            }
            catch (Exception)
            {

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    string sAuthor = ((Label)e.Row.Cells[2].FindControl("lblAuthor")).Text;
                    string sCategory = ((Label)e.Row.Cells[3].FindControl("lblCategory")).Text;

                    DropDownList DDLAuthor = (DropDownList)e.Row.Cells[2].FindControl("DDLAuthor");
                    DropDownList DDLCategory = (DropDownList)e.Row.Cells[3].FindControl("DDLCategory");


                    PopulateAuthor(DDLAuthor, sAuthor);
                    PopulateCategory(DDLCategory, sCategory);
                }

            }
        }

        private void PopulateAuthor(DropDownList ddl, string sItem)
        {

            try
            {
                DataTable dt = logic.GetAllAuthors();

                ddl.Items.Clear();

                if (dt.Rows.Count > 0)
                {
                    ddl.Items.Add(new ListItem("", ""));

                    for (int x = 0; x < dt.Rows.Count;x++ )
                    {
                        ddl.Items.Add(new ListItem(dt.Rows[x]["Author_Name"].ToString(),dt.Rows[x]["Author_ID"].ToString()));
                    }

                    if (!string.IsNullOrEmpty(sItem))
                        ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(sItem));
                }
               
            }
            catch (Exception )
            {
            }
        }

        private void PopulateCategory(DropDownList ddl, string sItem)
        {

            try
            {
                DataTable dt = logic.GetAllCategories();

                ddl.Items.Clear();

                if (dt.Rows.Count > 0)
                {
                    ddl.Items.Add(new ListItem("", ""));

                    for (int x = 0; x < dt.Rows.Count;x++ )
                    {
                        ddl.Items.Add(new ListItem(dt.Rows[x]["Category_Name"].ToString(),dt.Rows[x]["Category_ID"].ToString()));
                    }

                    if (!string.IsNullOrEmpty(sItem))
                        ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(sItem));
                }
               
            }
            catch (Exception )
            {
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                btnAdd.Enabled = false;

                DataTable dt;
                int iRow = 0;

                dt = logic.GetBooks("","");

                if (dt == null || dt.Rows.Count == 0)
                {
                    dt = new DataTable();
                    dt.Columns.Add("Book_ID");
                    dt.Columns.Add("Book_Name");
                    dt.Columns.Add("Author_ID");
                    dt.Columns.Add("Category_ID");
                    dt.Columns.Add("Author_Name");
                    dt.Columns.Add("Category_Name");

                }

                dt.Rows.Add("", "","","","","");

                iRow = GridView1.Rows.Count;

                GridView1.EditIndex = iRow;
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception)
            {
                btnAdd.Enabled = true;
            }

        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            GridView1.Attributes.Add("onkeydown", "if(event.keyCode==13)return false;");

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
            }
            if (e.CommandName == "Update")
            {
            }
            if (e.CommandName == "Delete")
            {
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sResult = "Ok";

            try
            {
                string sID = ((Label)GridView1.Rows[e.RowIndex].Cells[1].FindControl("lblID2")).Text;

                sResult = logic.DeleteBook(sID);

                if (sResult == "Ok")
                    BindBook();
            }
            catch (Exception)
            {

            }
        }



    }
}