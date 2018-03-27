﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDD1
{
    public partial class ConsultaEstudiante : System.Web.UI.Page
    {
        List<Grupo> grupos = new List<Grupo>();
        List<GrupoxEstudiante> gruposxEstudiante = new List<GrupoxEstudiante>();
        List<EvaluacionxEstudiante> evaluacionesxEstudiante = new List<EvaluacionxEstudiante>();
        public static Estudiante estudiante;

        protected void Page_Load(object sender, EventArgs e)
        {
            escogerGrupos();
            RadioButtonList1.Items.Clear();
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonList1.Items.Add(new ListItem(grupos[i].nombreCurso));
                }
            }
            escogerEvaluaciones();
        }

        private void escogerEvaluaciones()
        {
            for (int i = 0; i < gruposxEstudiante.Count; i++)
            {
                for (int j = 0; j < gruposxEstudiante[i].evaluacionxEstudiantes.Count; j++)
                    evaluacionesxEstudiante.Add(gruposxEstudiante[i].evaluacionxEstudiantes[j]);
            }
        }

        private List<EvaluacionxEstudiante> escogerEvaluaciones(Grupo grupo)
        {
            List<EvaluacionxEstudiante> evaluaciones = new List<EvaluacionxEstudiante>();
            for (int i = 0; i < grupo.grupoxEstudiantes.Count; i++)
            {
                for (int j = 0; j < grupo.grupoxEstudiantes[i].evaluacionxEstudiantes.Count; j++)
                    evaluaciones.Add(gruposxEstudiante[i].evaluacionxEstudiantes[j]);
            }
            return evaluaciones;
        }

        private void escogerGrupos()
        {
            for (int i = 0; i < Profesor.periodos.Count; i++)
            {
                for (int j = 0; j < Profesor.periodos[i].grupos.Count; j++)
                    grupos.Add(Profesor.periodos[i].grupos[j]);
            }
            List<Grupo> gruposNew = new List<Grupo>();
            for (int x = 0; x < grupos.Count; x++)
            {
                for (int y = 0; y < grupos[x].grupoxEstudiantes.Count; y++)
                {
                    if (grupos[x].grupoxEstudiantes[y].estudiante.correo.Equals(estudiante.correo))
                        gruposNew.Add(grupos[x]);
                }
            }
            grupos = gruposNew;
        }

        public void verNotas( List<EvaluacionxEstudiante> notas)
        {
            for (int rowCtr = 0; rowCtr<2; rowCtr++)
            {
                // Create new row and add it to the table.
                TableRow tRow = new TableRow();
                Table1.Rows.Add(tRow);
                if (rowCtr == 0)
                {
                    TableCell tCell = new TableCell();
                    tCell.Text = "Evaluación";
                    tRow.Cells.Add(tCell);
                    for (int i = 0; i < notas.Count; i++)
                    {
                        tCell = new TableCell();
                        tCell.Text =  notas[i].evaluacion.nombre;
                        tRow.Cells.Add(tCell);
                    }
                }
                else
                {
                    TableCell tCell = new TableCell();
                    tCell.Text = "Nota";
                    tRow.Cells.Add(tCell);
                    for (int i = 0; i < notas.Count; i++)
                    {
                        tCell = new TableCell();
                        tCell.Text = notas[i].nota.ToString();
                        tRow.Cells.Add(tCell);
                    }
                }
            }
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            Grupo grupo = grupos[RadioButtonList1.SelectedIndex];
            List<EvaluacionxEstudiante> evaluaciones = escogerEvaluaciones(grupo);
            verNotas(evaluaciones);

        }
    }
}