<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Cursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged1" 
        DataKeyNames="Id" >
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="Id" HeaderText="Id" 
            SortExpression="Id" ReadOnly="True" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
            SortExpression="Nombre" />
        <asp:BoundField DataField="Inscritas" HeaderText="Inscritas" 
            SortExpression="Inscritas" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
            SortExpression="Descripcion" />
        <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" 
            SortExpression="Habilitado" />
        <asp:BoundField DataField="Max" HeaderText="Cupo" SortExpression="Max" />

         <asp:TemplateField HeaderText="View">
            <ItemTemplate>
            <asp:LinkButton runat="server" ID="lnkView" OnClick="inscribir">Inscribir</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="View">
            <ItemTemplate>
            <asp:LinkButton runat="server" ID="lnkView2" OnClick="habilitar">Habilitar/Deshabilitar</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:prowebNetConnectionString %>" 
    
        SelectCommand="SELECT * FROM [Curso]">
</asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Crear Curso" />
</asp:Content>

