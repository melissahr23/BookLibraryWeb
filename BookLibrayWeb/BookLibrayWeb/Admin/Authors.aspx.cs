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
    public partial class Authors : System.Web.UI.Page
    {
        Logic logic = new Logic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                BindAuthor();

            }

        }


        private void BindAuthor()
        {
            try
            {
                DataTable dt = new DataTable("Author");

                dt = logic.GetAllAuthors();
                
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
            catch (Exception )
            {
               
            }

        }


       

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            btnAdd.Enabled = true;
            GridView1.EditIndex = -1;
            BindAuthor();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            btnAdd.Enabled = false;
            GridView1.EditIndex = e.NewEditIndex;
            BindAuthor();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                btnAdd.Enabled = false;
                string sResult = string.Empty;
                string sID = ((Label)GridView1.Rows[e.RowIndex].Cells[1].FindControl("lblID")).Text;
                string sAuthor = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("txtAuthor")).Text.Trim().ToUpper();

                sResult = logic.UpdateAuthor(sID, sAuthor); 

                    if (sResult != "Ok")
                    {
                        btnAdd.Enabled = false;
                    }
                    else
                    {
                        btnAdd.Enabled = true;

                        GridView1.EditIndex = -1;
                        BindAuthor();

                    }
              

            }
            catch (Exception )
            {
                
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
                try
                {
                    btnAdd.Enabled = false;

                    DataTable dt;
                    int iRow = 0;

                    dt = logic.GetAllAuthors();
                
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("Author_ID");
                        dt.Columns.Add("Author_Name");
                  
                    }

                    dt.Rows.Add("", "");

                    iRow = GridView1.Rows.Count;

                    GridView1.EditIndex = iRow;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
                catch (Exception )
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

                sResult = logic.DeleteAuthor(sID);

                if (sResult == "Ok")
                    BindAuthor();
            }
            catch (Exception )
            {
               
            }
        }




    }
}