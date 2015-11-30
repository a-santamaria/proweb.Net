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
        if (this.User != null && this.User.Identity.IsAuthenticated)
        {
            this.username = HttpContext.Current.User.Identity.Name;
            loged = true;
            Button1.Enabled = HttpContext.Current.User.IsInRole("admin");
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
                         where a.username == userName && a.id_Curso == this.idCurso
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
            System.Windows.Forms.MessageBox.Show("used no ha iniciado sesión");
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
            //System.Windows.Forms.MessageBox.Show("Voy a inscribir " + this.username + " " + this.idCurso);
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
                    if (c.Max - c.Inscritas - 1 < 0)
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
        GridView1.DataBind();
    }


    protected void habilitar(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((LinkButton)sender).Parent.Parent);
        int row = gvr.RowIndex;
        //System.Windows.Forms.MessageBox.Show("sender row index " + row);
        this.idCurso = Convert.ToInt32(GridView1.Rows[row].Cells[1].Text);
        if (loged)
        {
            
            DataClassesDataContext dc = new DataClassesDataContext();


            var query =
                 from curso in dc.Curso2s
                 where curso.Id == this.idCurso
                 select curso;

            foreach (Curso2 c in query)
            {
                
                if (c.Habilitado == 1)
                {
                    //System.Windows.Forms.MessageBox.Show("voy a des " + this.idCurso);
                    c.Habilitado = 0;
                }
                else
                {
                    //System.Windows.Forms.MessageBox.Show("voy a habil " + this.idCurso);
                    c.Habilitado = 1;
                }
            }
            dc.SubmitChanges();
            GridView1.DataBind();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CrearCurso.aspx");
    }
}