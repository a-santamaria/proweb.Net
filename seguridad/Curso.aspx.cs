using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Curso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Request.QueryString["id"];
        int id = Int32.Parse(Request.QueryString["id"]);
        DataClassesDataContext dc = new DataClassesDataContext();
        string username = HttpContext.Current.User.Identity.Name;
        var result = from a in dc.EstudianteXcursos
                         where a.username == username && a.id_Curso == id
                         select a;

        if (!result.Any())
        {
            Response.Redirect("Account/Login.aspx");
        }

    }
}