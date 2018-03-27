using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BDD1
{
    public partial class RegistrarNotas : System.Web.UI.Page
    {
        Grupo grupo;
        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        List<Estudiante> estudiantes = new List<Estudiante>();

        protected void Page_Load(object sender, EventArgs e)
        {
            grupo = Profesor.grupoActivo;
            for (int i = 0;i <grupo.grupoxRubros.Count;i++)
            {
                GrupoxRubro gr = grupo.grupoxRubros[i];
                for (int j=0;j<gr.evaluaciones.Count;j++)
                {
                    evaluaciones.Add(gr.evaluaciones[j]);
                }
            }
            for (int i = 0; i < grupo.grupoxEstudiantes.Count; i++)
            {
                GrupoxEstudiante gr = grupo.grupoxEstudiantes[i];
                estudiantes.Add(gr.estudiante);
            }

           registrarNotas(evaluaciones, estudiantes);
        }

        public int buscarIndiceEvaluacion(string nombre)
        {
            for (int i = 0; i < evaluaciones.Count; i++)
            {
                if (evaluaciones[i].nombre.Equals(nombre))
                    return i;
            }
            return -1;
        }
       
        void test(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = buscarIndiceEvaluacion( btn.ID);
            TableRow row = Table1.Rows[index+1];
            List<int> notas = new List<int>();
            for (int i=1; i<row.Cells.Count-1;i++ )
            {
                TableCell cell = row.Cells[i];
                TextBox txt = (TextBox)cell.Controls[0];
                string[] partes = txt.ID.Split('-');
                string indexEvaluacion = partes[0];
                string indexEstudiante = partes[1];
                notas.Add(int.Parse(txt.Text));
                txt.Text = "";
            }
            
            
            
        }
        
        public void registrarNotas(List<Evaluacion> evaluaciones, List<Estudiante> estudiantes)
        {
            for (int rowCtr = 0; rowCtr < evaluaciones.Count+1; rowCtr++)
            {
                // Create new row and add it to the table.
                TableRow tRow = new TableRow();
                Table1.Rows.Add(tRow);
                if (rowCtr == 0)
                {
                    TableCell tCell = new TableCell();
                    tCell.Text = "Evaluaciones/Estudiante";
                    tRow.Cells.Add(tCell);
                    for (int i = 0; i < estudiantes.Count; i++)
                    {
                        tCell = new TableCell();
                        tCell.Text = "Estudiante: "+estudiantes[i].ID;
                        tRow.Cells.Add(tCell);
                    }
                    TableCell Cell = new TableCell();
                    Cell.Text = "Agregar";
                    tRow.Cells.Add(Cell);
                }
                else
                {
                    TableCell tCell = new TableCell();
                    tCell.Text = evaluaciones[rowCtr - 1].nombre;
                    tRow.Cells.Add(tCell);
                    for (int cellCtr = 0; cellCtr < estudiantes.Count; cellCtr++)
                    {
                        tCell = new TableCell();
                        TextBox txt = new TextBox();
                        txt.ID = (rowCtr - 1) + "-" + (cellCtr);
                        tCell.Controls.Add(txt);
                        tRow.Cells.Add(tCell);
                    }
                    TableCell Cell = new TableCell();
                    Button Btn = new Button();
                    Btn.Text = "Agregar " + evaluaciones[rowCtr - 1].nombre;
                    Btn.ID= evaluaciones[rowCtr - 1].nombre;
                    Btn.Click += new EventHandler(test);
                    Cell.Controls.Add(Btn);
                    tRow.Cells.Add(Cell);
                }
            }
        }

        
    }
}