<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BookLibrayWeb.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <br />
<br />
<asp:Label ID="Label1" runat="server" Text="SEARCH BOOK" Font-Bold="True" Font-Size="Medium" ForeColor="#336699" style="text-align: center"></asp:Label>
 

       <br />
       <table style="width:700px;">
           <tr>
               <td>
                   <asp:Label ID="Label3" runat="server" Text="Filter By"></asp:Label>
               </td>
               <td>
                   <asp:DropDownList ID="DDLFilter" runat="server">
                       <asp:ListItem>Author</asp:ListItem>
                       <asp:ListItem>Category</asp:ListItem>
                   </asp:DropDownList>
               </td>
               <td>
                   <asp:TextBox ID="txtSearch" runat="server" Width="250px"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
               </td>
               <td>
                   <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
               <td>
                   <asp:Button ID="btnAll" runat="server" Text="Show All" CausesValidation="False" OnClick="btnAll_Click" />
               </td>
           </tr>
       </table>
       <br />
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridviewWebPage" EmptyDataText="No Available Data" Width="634px">
           <Columns>
               <asp:BoundField DataField="Book_ID" HeaderText="ID" />
               <asp:BoundField DataField="Book_Name" HeaderText="Title" />
               <asp:BoundField DataField="Author_Name" HeaderText="Author" />
               <asp:BoundField DataField="Category_Name" HeaderText="Category" />
           </Columns>
           <EditRowStyle HorizontalAlign="Left" />
           <EmptyDataRowStyle HorizontalAlign="Left" />
           <HeaderStyle HorizontalAlign="Left" />
           <RowStyle HorizontalAlign="Left" />
       </asp:GridView>
       <br />
       <br />
       <br />
 

</asp:Content>
