<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="BookLibrayWeb.Admin.Authors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<asp:Label ID="Label1" runat="server" Text="AUTHORS LIST" Font-Bold="True" Font-Size="Medium" ForeColor="#336699" style="text-align: center"></asp:Label>
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
                     <asp:Label ID="lblID" runat="server" Text='<%# Eval("Author_ID") %>'></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="lblID2" runat="server" Text='<%# Bind("Author_ID") %>'></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:TemplateField>
            <asp:TemplateField HeaderText="Author">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAuthor" runat="server" MaxLength="250" Text='<%# Bind("Author_Name") %>' Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAuthor" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Author_Name") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
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
    <asp:Button ID="btnAdd" runat="server" Text="Add Author" OnClick="btnAdd_Click" />
</asp:Content>
