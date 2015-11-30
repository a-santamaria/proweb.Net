<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Curso.aspx.cs" Inherits="Curso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="Id" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
            SortExpression="Id" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
            SortExpression="Nombre" />
        <asp:BoundField DataField="Inscritas" HeaderText="Inscritas" 
            SortExpression="Inscritas" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
            SortExpression="Descripcion" />
        <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" 
            SortExpression="Habilitado" />
        <asp:BoundField DataField="Max" HeaderText="Max" SortExpression="Max" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:prowebNetConnectionString %>" 
    SelectCommand="SELECT * FROM [Curso] WHERE ([Id] = @Id)">
    <SelectParameters>
        <asp:ControlParameter ControlID="Label1" Name="Id" PropertyName="Text" 
            Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>

