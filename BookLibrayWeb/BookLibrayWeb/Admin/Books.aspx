<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="BookLibrayWeb.Admin.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
<br />
<asp:Label ID="Label1" runat="server" Text="BOOKS LIST" Font-Bold="True" Font-Size="Medium" ForeColor="#336699" style="text-align: center"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridviewWebPage" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" EmptyDataText="No Available Data" OnPreRender="GridView1_PreRender" Width="634px" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
        <Columns>

             <asp:CommandField HeaderText="Modify" ButtonType="Image" CancelImageUrl="~/App_Themes/Cancel.gif"
                                        CancelText="Cancel" InsertImageUrl="~/App_Themes/AddNewitem.gif"
                                        InsertText="Insert" UpdateImageUrl="~/App_Themes/Update.gif"
                                        UpdateText="Update" EditImageUrl="~/App_Themes/Edit.gif"
                                        EditText="Edit" ShowEditButton="True" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>

             <asp:TemplateField HeaderText="ID">
                 <EditItemTemplate>
                     <asp:Label ID="lblID" runat="server" Text='<%# Eval("Book_ID") %>'></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="lblID2" runat="server" Text='<%# Bind("Book_ID") %>'></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:TemplateField>
            <asp:TemplateField HeaderText="Title">
                <EditItemTemplate>
                    <asp:TextBox ID="txtBook" runat="server" MaxLength="250" Text='<%# Bind("Book_Name") %>' Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBook" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Book_Name") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Author">
                 <EditItemTemplate>
                     <asp:DropDownList ID="DDLAuthor" runat="server">
                     </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDLAuthor" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:Label ID="lblAuthor" runat="server" Text='<%# Bind("Author_ID") %>' Visible="False"></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("Author_Name") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Category">
                 <EditItemTemplate>
                     <asp:DropDownList ID="DDLCategory" runat="server">
                     </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DDLCategory" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category_ID") %>' Visible="False"></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label3" runat="server" Text='<%# Bind("Category_Name") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField ShowHeader="False" HeaderText="Delete">
                 <ItemTemplate>
                     <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/App_Themes/Delete.gif" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to permanently delete this item?')"/>
                 </ItemTemplate>
             </asp:TemplateField>
        </Columns>
        <EditRowStyle HorizontalAlign="Left" />
        <EmptyDataRowStyle HorizontalAlign="Left" />
        <HeaderStyle HorizontalAlign="Left" />
        <RowStyle HorizontalAlign="Left" />
    </asp:GridView>
    <br />
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add Book" OnClick="btnAdd_Click" />
</asp:Content>
