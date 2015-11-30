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
        CrearCursoWS.WebService proxy = new CrearCursoWS.WebService();

        string s = proxy.crearCurso(TextBoxNombre.Text, TextBoxD.Text, Int32.Parse(TextBoxCupo.Text));
        if (s == null)
        {
            System.Windows.Forms.MessageBox.Show("Error al crear el nuevo curso");
        }
        else
        {
            System.Windows.Forms.MessageBox.Show("Curos creado exitosamente GUID = "+s);
        }
        Response.Redirect("Default.aspx");


        /*
        DataClassesDataContext dc = new DataClassesDataContext();

        Curso2 curso = new Curso2();

        curso.Nombre = TextBoxNombre.Text;
        curso.Descripcion = TextBoxD.Text;
        curso.Max = Int32.Parse(TextBoxCupo.Text);
        curso.Habilitado = 1;


        dc.Curso2s.InsertOnSubmit(curso);
        dc.SubmitChanges();
         */
    }
}