using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CrearCurso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Crear_Click(object sender, EventArgs e)
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        Curso2 curso = new Curso2();

        curso.Nombre = TextBoxNombre.Text;
        curso.Descripcion = TextBoxD.Text;
        curso.Max = Int32.Parse(TextBoxCupo.Text);
        curso.Habilitado = 1;


        dc.Curso2s.InsertOnSubmit(curso);
        dc.SubmitChanges();
    }
}