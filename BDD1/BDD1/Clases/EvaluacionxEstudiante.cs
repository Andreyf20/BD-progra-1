namespace BDD1
{
    public class EvaluacionxEstudiante
    {
        public int ID;
        public int nota;
        public Evaluacion evaluacion;

        public EvaluacionxEstudiante(int nota, Evaluacion evaluacion)
        {
            this.nota = nota;
            this.evaluacion = evaluacion;
        }
    }
}