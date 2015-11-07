using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using BookLibrayWeb.Service;

namespace BookLibrayWeb
{
    public class Logic
    {
        IBooksData serviceBooks = new BooksData();

        #region Search
        public DataTable GetBooks(string sFilter, string sSearch)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = serviceBooks.GetBooks(sFilter, sSearch).AsDataTable();
            }
            catch (Exception)
            {

            }

            return dt;
        }

        public string UpdateBook(string sID, string sBook, string sAuthorID, string sCategoryID)
        {
            return serviceBooks.UpdateBook(sID, sBook, sAuthorID, sCategoryID);
        }

        public string DeleteBook(string sID)
        {
            return serviceBooks.DeleteBook(sID);

        }
        #endregion

        #region Authors
        public DataTable GetAllAuthors()
        {
            DataTable dt = new DataTable();
            try
            {
                dt= serviceBooks.GetAllAuthors().AsDataTable();
            }
            catch(Exception)
            {
                
            }

            return dt;
        }

        public string UpdateAuthor(string sID, string sAuthor)
        {
            return serviceBooks.UpdateAuthor(sID, sAuthor);
        }

        public string DeleteAuthor(string sID)
        {
            return serviceBooks.DeleteAuthor(sID);

        }
        #endregion

        #region Categories
        public DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = serviceBooks.GetAllCategories().AsDataTable();
            }
            catch (Exception)
            {

            }

            return dt;
        }

        public string UpdateCategory(string sID, string sCategory)
        {
            return serviceBooks.UpdateCategory(sID, sCategory);
        }

        public string DeleteCategory(string sID)
        {
            return serviceBooks.DeleteCategory(sID);

        }
        #endregion

    }
}