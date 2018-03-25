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
    public partial class Prueba : System.Web.UI.Page
    {
        List<string> evaluaciones = new List<string>();
        List<int> estudiantes = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            evaluaciones.Add("Examen 1");
            evaluaciones.Add("Quiz 1");
            evaluaciones.Add("Examen 2");
            evaluaciones.Add("Proyecto");

            
            estudiantes.Add(0);
            estudiantes.Add(1);
            estudiantes.Add(2);
            estudiantes.Add(3);
            estudiantes.Add(4);

            registrarNotas(evaluaciones, estudiantes);

        }

       
        void test(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = evaluaciones.IndexOf(btn.ID);
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
        
        public void registrarNotas(List<string> evaluaciones, List<int> estudiantes)
        {
            for (int rowCtr = 0; rowCtr < estudiantes.Count; rowCtr++)
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
                        tCell.Text = "Estudiante: "+estudiantes[i].ToString();
                        tRow.Cells.Add(tCell);
                    }
                    TableCell Cell = new TableCell();
                    Cell.Text = "Agregar";
                    tRow.Cells.Add(Cell);
                }
                else
                {
                    TableCell tCell = new TableCell();
                    tCell.Text = evaluaciones[rowCtr - 1];
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
                    Btn.Text = "Agregar " + evaluaciones[rowCtr - 1];
                    Btn.ID= evaluaciones[rowCtr - 1];
                    Btn.Click += new EventHandler(test);
                    Cell.Controls.Add(Btn);
                    tRow.Cells.Add(Cell);
                }
            }
        }
    }
}