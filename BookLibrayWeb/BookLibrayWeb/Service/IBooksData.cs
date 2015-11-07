using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookLibrayWeb.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBooksData" in both code and config file together.
    [ServiceContract]
    public interface IBooksData
    {
        [OperationContract]
        string GetBooks(string sFilter, string sSearch);

        [OperationContract]
        string UpdateBook(string sID, string sBook, string sAuthorID, string sCategoryID);

        [OperationContract]
        string DeleteBook(string sID);
        
        [OperationContract]
        string GetAllAuthors();

        [OperationContract]
        string UpdateAuthor(string sID, string sAuthor);

        [OperationContract]
        string DeleteAuthor(string sID);

        [OperationContract]
        string GetAllCategories();

        [OperationContract]
        string UpdateCategory(string sID, string sCategory);

        [OperationContract]
        string DeleteCategory(string sID);
    }
}
