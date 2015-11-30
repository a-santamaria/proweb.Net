<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CrearCurso.aspx.cs" Inherits="CrearCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    Nombre del curso:  <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
    <br />
    <br />
    Descripcion:   <asp:TextBox id="TextBoxD" TextMode="multiline" runat="server" ></asp:TextBox>
    <br />
    <br />
    Cupo:   <asp:TextBox ID="TextBoxCupo" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                    ControlToValidate="TextBoxCupo" 
                                    runat="server" 
                                    ErrorMessage="Only Numbers allowed" 
                                    ValidationExpression="\d+">
                                    </asp:RegularExpressionValidator>
                                    &nbsp;
    <br />
    <br />
    <asp:Button ID="Crear" runat="server" Text="Crear Curso" 
        onclick="Crear_Click" />
&nbsp;
</asp:Content>

