using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cursos : System.Web.UI.Page
{
    int idCurso;
    String username;
    bool loged = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.username = "";
        this.idCurso = -1;
        Label1.Text = Request.QueryString["id"];
        if (this.User != null && this.User.Identity.IsAuthenticated)
        {
            this.username = HttpContext.Current.User.Identity.Name;
            loged = true;
        }
        else
        {
            loged = false;
        }
    }

    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        
        string id = GridView1.SelectedRow.Cells[1].Text;
        this.idCurso = Int32.Parse(id);
        if (this.User != null && this.User.Identity.IsAuthenticated)
        {
            string userName = HttpContext.Current.User.Identity.Name;
            username = userName;
            //if(HttpContext.Current.User.IsInRole("admin"))
            //System.Windows.Forms.MessageBox.Show(userName);
            //ContextDataSourceContextData d = new ContextDataSourceContextData();
            DataClassesDataContext dc = new DataClassesDataContext();

            

            var result = from a in dc.EstudianteXcursos
                         where a.username == userName && a.id_Curso == idCurso
                       select a;

            if (result.Any())
            {
                Response.Redirect("Curso.aspx?id=" + id);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Usted no está inscrito en ese curso");
            }
           
        }
        else
        {
            //System.Windows.Forms.MessageBox.Show("no logeado");
        }


        
    }

    protected void inscribir(object sender, EventArgs e)
    {
        LinkButton b = sender as LinkButton;
        GridViewRow gvr = (GridViewRow)(((LinkButton)sender).Parent.Parent);
        int row = gvr.RowIndex;
        //System.Windows.Forms.MessageBox.Show("sender row index " + row);
        this.idCurso = Convert.ToInt32(GridView1.Rows[row].Cells[1].Text);
        if (loged)
        {
            System.Windows.Forms.MessageBox.Show("Voy a inscribir " + this.username + " " + this.idCurso);
            DataClassesDataContext dc = new DataClassesDataContext();


            var result = from a in dc.EstudianteXcursos
                         where a.username == this.username && a.id_Curso == this.idCurso
                         select a;

            if (result.Any())
            {
                System.Windows.Forms.MessageBox.Show("Ya está inscrito en el curso");
            }
            else
            {

                //revisar si hay cupo
                var query =
                from curso in dc.Curso2s
                where curso.Id == this.idCurso
                select curso;
                
                foreach (Curso2 c in query)
                {
                    if (c.Max - c.Inscritas - 1 <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("No hay cupos en esta clase");
                    }
                    else
                    {
                        //update numero de inscritos
                        c.Inscritas++;
                        EstudianteXcurso nuevoEstCurso = new EstudianteXcurso();
                        nuevoEstCurso.id_Curso = this.idCurso;
                        nuevoEstCurso.username = this.username;
                        dc.EstudianteXcursos.InsertOnSubmit(nuevoEstCurso);
                        dc.SubmitChanges();


                        System.Windows.Forms.MessageBox.Show("Inscripcion exitosa");
                    }
                }
            }
        }
        else
        {
            System.Windows.Forms.MessageBox.Show("No ha iniciado sesion");
        }
    }
}