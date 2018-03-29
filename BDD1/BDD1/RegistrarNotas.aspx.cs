﻿using System;
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
        List<Evaluacion> evaluaciones;
        List<GrupoxEstudiante> grupoxestudiantes;

        protected void Page_Load(object sender, EventArgs e)
        {
            grupo = ProfesorWindow.notas;
            evaluaciones = new List<Evaluacion>();
            grupoxestudiantes = Procedures.ver_grupoxestudiante_grupo(grupo.ID);

            

            List<GrupoxRubro> grupoxRubros = Procedures.ver_grupoxrubro_grupo(grupo.ID);

            for (int i = 0;i <grupoxRubros.Count;i++)
            {
                GrupoxRubro gr = grupoxRubros[i];
                List<Evaluacion> ev = Procedures.ver_evaluacion_grupoxrubro(gr.ID);
                for (int j=0;j<ev.Count;j++)
                {
                    evaluaciones.Add(ev[j]);
                }
            }
            

           registrarNotas(evaluaciones, grupoxestudiantes);
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
            for (int i=1; i<row.Cells.Count-1;i++ )
            {
                TableCell cell = row.Cells[i];
                TextBox txt = (TextBox)cell.Controls[0];
                string[] partes = txt.ID.Split('-');
                int indexEvaluacion = int.Parse(partes[0]);
                int indexGrupoXEstudiante = int.Parse(partes[1]);
                Procedures.evaluacionxestudiante_crear(indexGrupoXEstudiante,indexEvaluacion,decimal.Parse(txt.Text));
                txt.Text = "";
            }
        }
        
        public void registrarNotas(List<Evaluacion> evaluaciones, List<GrupoxEstudiante> grupoxestudiantes)
        {
            for (int rowCtr = 0; rowCtr < evaluaciones.Count+1; rowCtr++)
            {
                TableRow tRow = new TableRow();
                Table1.Rows.Add(tRow);
                if (rowCtr == 0)
                {
                    TableCell tCell = new TableCell();
                    tCell.Text = "Evaluaciones/Estudiante";
                    tRow.Cells.Add(tCell);
                    for (int i = 0; i < grupoxestudiantes.Count; i++)
                    {
                        tCell = new TableCell();
                        tCell.Text = "Estudiante: "+ grupoxestudiantes[i].IdEstudiante;
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
                    for (int cellCtr = 0; cellCtr < grupoxestudiantes.Count; cellCtr++)
                    {
                        tCell = new TableCell();
                        TextBox txt = new TextBox();
                        txt.ID = evaluaciones[rowCtr - 1].ID + "-" + grupoxestudiantes[cellCtr].ID;
                        txt.Text = txt.ID;
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