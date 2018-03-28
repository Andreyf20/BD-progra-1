namespace BDD1
{
    public class EvaluacionxEstudiante
    {
        public int ID;
        public decimal nota;
        public Evaluacion evaluacion;

        public int idEvaluacion;
        public int IdGrupoxEstudiante;

        public EvaluacionxEstudiante(int ID, decimal nota, Evaluacion evaluacion, int idEvaluacion, int IdGrupoxEstudiante)
        {
            this.ID = ID;
            this.idEvaluacion = idEvaluacion;
            this.nota = nota;
            this.evaluacion = evaluacion;
            this.IdGrupoxEstudiante = IdGrupoxEstudiante;
        }
    }
}