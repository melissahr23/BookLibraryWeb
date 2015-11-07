using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using BookLibrayWeb.Service.DAL;


namespace BookLibrayWeb.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BooksData" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BooksData.svc or BooksData.svc.cs at the Solution Explorer and start debugging.
    public class BooksData : IBooksData
    {
        #region Books
        public string GetBooks(string sFilter, string sSearch)
        {
            string sWhere = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", null, null);
            xmlDoc.AppendChild(dec);

            XmlElement root = xmlDoc.CreateElement("Authors");
            xmlDoc.AppendChild(root);

            try
            {
                if (string.IsNullOrEmpty(sFilter) == false)
                {
                    sWhere = " Where " + sFilter + "_Name = @search";
                }

                string sql = @"Select Book_ID, Book_Name, b.Category_ID, b.Author_ID, c.Category_Name, a.Author_Name
                                from Book b
                                left join Category c
                                  on b.Category_ID = c.Category_ID
                                left join Author a
                                  on b.Author_ID = a.Author_ID "
                                + sWhere + @"
                                Order by Book_ID";


                using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                {
                    myConnection.Open();
                    using (SqlCommand co = new SqlCommand(sql, myConnection))
                    {
                        if (string.IsNullOrEmpty(sFilter) == false)                
                            co.Parameters.AddWithValue("search", sSearch);
                
                        try
                        {
                            using (SqlDataReader myReader = co.ExecuteReader())
                            {
                                if (myReader.HasRows)
                                {
                                    XmlElement LinesElement;

                                    while (myReader.Read())
                                    {
                                        LinesElement = xmlDoc.CreateElement("Item");
                                        LinesElement.SetAttribute("Book_ID", myReader["Book_ID"].ToString());
                                        LinesElement.SetAttribute("Book_Name", myReader["Book_Name"].ToString());
                                        LinesElement.SetAttribute("Category_ID", myReader["Category_ID"].ToString());
                                        LinesElement.SetAttribute("Author_ID", myReader["Author_ID"].ToString());
                                        LinesElement.SetAttribute("Category_Name", myReader["Category_Name"].ToString());
                                        LinesElement.SetAttribute("Author_Name", myReader["Author_Name"].ToString());
                                        
                                        root.AppendChild(LinesElement);
                                    }//while
                                }//if
                            }
                        }//try
                        catch (Exception)
                        {
                        }
                    }//using
                }

            }//try
            catch (Exception)
            {
            }

            return xmlDoc.AsString();

        }

        public string UpdateBook(string sID, string sBook, string sAuthorID, string sCategoryID)
        {
            string sResult = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(sID) == true)
                {
                    string sql = "Insert into Book(Category_ID, Author_ID, Book_Name) values (@category, @author, @book_name)";

                    using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                    {
                        myConnection.Open();
                        using (SqlCommand co = new SqlCommand(sql, myConnection))
                        {
                            co.CommandType = CommandType.Text;
                            co.Parameters.AddWithValue("category", sCategoryID);
                            co.Parameters.AddWithValue("author", sAuthorID);
                            co.Parameters.AddWithValue("book_name", sBook);
                            co.ExecuteNonQuery();

                        }
                    }//using


                    sResult = "Ok";
                }
                else
                {
                    string sql = "Update Book set Book_Name = @book_name, Category_ID = @category, Author_ID = @Author where Book_ID = @id";

                    using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                    {
                        myConnection.Open();
                        using (SqlCommand co = new SqlCommand(sql, myConnection))
                        {
                            co.CommandType = CommandType.Text;
                            co.Parameters.AddWithValue("category", sCategoryID);
                            co.Parameters.AddWithValue("author", sAuthorID);
                            co.Parameters.AddWithValue("book_name", sBook);
                            co.Parameters.AddWithValue("id", sID);

                            co.ExecuteNonQuery();

                        }
                    }//using


                    sResult = "Ok";

                }

            }
            catch (Exception ex)
            {
                sResult = ex.Message;

            }
            return sResult;
        }

        public string DeleteBook(string sID)
        {
            string sResult = string.Empty;

            try
            {
                string sql = "Delete from Book where Book_ID =@id";

                using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                {
                    myConnection.Open();
                    using (SqlCommand co = new SqlCommand(sql, myConnection))
                    {
                        co.CommandType = CommandType.Text;
                        co.Parameters.AddWithValue("id", sID);

                        co.ExecuteNonQuery();

                    }
                }//using


                sResult = "Ok";

            }
            catch (Exception ex)
            {
                sResult = ex.Message;

            }
            return sResult;
        }
        #endregion

        #region Authors
        public string GetAllAuthors()
        {
            
            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", null, null);
            xmlDoc.AppendChild(dec);

            XmlElement root = xmlDoc.CreateElement("Authors");
            xmlDoc.AppendChild(root);

            try
            {
                string sql = @"Select Author_ID, Author_Name from Author Order by Author_ID";


                using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                {
                    myConnection.Open();
                    using (SqlCommand co = new SqlCommand(sql, myConnection))
                    {
                        try
                        {
                            using (SqlDataReader myReader = co.ExecuteReader())
                            {
                                if (myReader.HasRows)
                                {
                                    XmlElement LinesElement;

                                    while (myReader.Read())
                                    {
                                        LinesElement = xmlDoc.CreateElement("Item");
                                        LinesElement.SetAttribute("Author_ID", myReader["Author_ID"].ToString());
                                        LinesElement.SetAttribute("Author_Name", myReader["Author_Name"].ToString());

                                        root.AppendChild(LinesElement);
                                    }//while
                                }//if
                            }
                        }//try
                        catch (Exception )
                        {
                        }
                    }//using
                }

            }//try
            catch (Exception )
            {
            }

            return xmlDoc.AsString();

        }

        public string UpdateAuthor(string sID, string sAuthor)
        {
            string sResult = string.Empty;
            
            try
            {
                if (string.IsNullOrEmpty(sID) == true)
                {
                    string sql = "Insert into Author(Author_Name) values (@author)";

                    using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                    {
                        myConnection.Open();
                        using (SqlCommand co = new SqlCommand(sql, myConnection))
                        {
                            co.CommandType = CommandType.Text;
                            co.Parameters.AddWithValue("author", sAuthor);

                            co.ExecuteNonQuery();

                        }
                    }//using


                    sResult = "Ok";
                }
                else
                {
                    string sql = "Update Author set Author_Name =  @author where Author_ID = @id";

                    using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                    {
                        myConnection.Open();
                        using (SqlCommand co = new SqlCommand(sql, myConnection))
                        {
                            co.CommandType = CommandType.Text;
                            co.Parameters.AddWithValue("author", sAuthor);
                            co.Parameters.AddWithValue("id", sID);

                            co.ExecuteNonQuery();

                        }
                    }//using


                    sResult = "Ok";

                }

            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                
            }
            return sResult;
        }

        public string DeleteAuthor(string sID)
        {
            string sResult = string.Empty;

            try
            {
                    string sql = "Delete from Author where Author_ID =@id";

                    using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                    {
                        myConnection.Open();
                        using (SqlCommand co = new SqlCommand(sql, myConnection))
                        {
                            co.CommandType = CommandType.Text;
                            co.Parameters.AddWithValue("id", sID);

                            co.ExecuteNonQuery();

                        }
                    }//using


                    sResult = "Ok";
                
            }
            catch (Exception ex)
            {
                sResult = ex.Message;

            }
            return sResult;
        }
        #endregion

        #region Categories
        public string GetAllCategories()
        {

            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", null, null);
            xmlDoc.AppendChild(dec);

            XmlElement root = xmlDoc.CreateElement("Categories");
            xmlDoc.AppendChild(root);

            try
            {
                string sql = @"Select Category_ID, Category_Name from Category Order by Category_ID";


                using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                {
                    myConnection.Open();
                    using (SqlCommand co = new SqlCommand(sql, myConnection))
                    {
                        try
                        {
                            using (SqlDataReader myReader = co.ExecuteReader())
                            {
                                if (myReader.HasRows)
                                {
                                    XmlElement LinesElement;

                                    while (myReader.Read())
                                    {
                                        LinesElement = xmlDoc.CreateElement("Item");
                                        LinesElement.SetAttribute("Category_ID", myReader["Category_ID"].ToString());
                                        LinesElement.SetAttribute("Category_Name", myReader["Category_Name"].ToString());

                                        root.AppendChild(LinesElement);
                                    }//while
                                }//if
                            }
                        }//try
                        catch (Exception)
                        {
                        }
                    }//using
                }

            }//try
            catch (Exception)
            {
            }

            return xmlDoc.AsString();

        }

        public string UpdateCategory(string sID, string sCategory)
        {
            string sResult = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(sID) == true)
                {
                    string sql = "Insert into Category(Category_Name) values (@category)";

                    using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                    {
                        myConnection.Open();
                        using (SqlCommand co = new SqlCommand(sql, myConnection))
                        {
                            co.CommandType = CommandType.Text;
                            co.Parameters.AddWithValue("category", sCategory);

                            co.ExecuteNonQuery();

                        }
                    }//using


                    sResult = "Ok";
                }
                else
                {
                    string sql = "Update Category set Category_Name =  @category where Category_ID = @id";

                    using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                    {
                        myConnection.Open();
                        using (SqlCommand co = new SqlCommand(sql, myConnection))
                        {
                            co.CommandType = CommandType.Text;
                            co.Parameters.AddWithValue("category", sCategory);
                            co.Parameters.AddWithValue("id", sID);

                            co.ExecuteNonQuery();

                        }
                    }//using


                    sResult = "Ok";

                }

            }
            catch (Exception ex)
            {
                sResult = ex.Message;

            }
            return sResult;
        }

        public string DeleteCategory(string sID)
        {
            string sResult = string.Empty;

            try
            {
                string sql = "Delete from Category where Category_ID =@id";

                using (SqlConnection myConnection = new SqlConnection(Common.GetConnectionString()))
                {
                    myConnection.Open();
                    using (SqlCommand co = new SqlCommand(sql, myConnection))
                    {
                        co.CommandType = CommandType.Text;
                        co.Parameters.AddWithValue("id", sID);

                        co.ExecuteNonQuery();

                    }
                }//using


                sResult = "Ok";

            }
            catch (Exception ex)
            {
                sResult = ex.Message;

            }
            return sResult;
        }
        #endregion
    }
}
