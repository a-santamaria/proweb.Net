<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cursos.aspx.cs" Inherits="Cursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged1" >
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="id_Curso" HeaderText="id_Curso" 
            SortExpression="id_Curso" />
        <asp:TemplateField HeaderText="View">
            <ItemTemplate>
            <asp:LinkButton runat="server" ID="lnkView" OnClick="inscribir">Inscribir</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:prowebNetConnectionString %>" 
    
        SelectCommand="SELECT [id_Curso] FROM [InstitucionXcurso] WHERE ([id_Institucion] = @id_Institucion)">
    <SelectParameters>
        <asp:ControlParameter ControlID="Label1" Name="id_Institucion" PropertyName="Text" 
            Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>

