namespace PetshopProject.Classes
{
    public class Petshop
    {
        public string Nome { get; set; }
        public double PrecoDiaUtilPequeno { get; set; }
        public double PrecoDiaUtilGrande { get; set; }
        public double PrecoFimDeSemanaPequeno { get; set; }
        public double PrecoFimDeSemanaGrande { get; set; }
        public double Distancia { get; set; }

        public Petshop(string Nome, double PrecoDiaUtilPequeno, double PrecoDiaUtilGrande, double PrecoFimDeSemanaPequeno, 
            double PrecoFimDeSemanaGrande, double Distancia)
        {
            this.Nome = Nome;
            this.PrecoDiaUtilPequeno = PrecoDiaUtilPequeno;
            this.PrecoDiaUtilGrande = PrecoDiaUtilGrande;
            this.PrecoFimDeSemanaPequeno = PrecoFimDeSemanaPequeno;
            this.PrecoFimDeSemanaGrande = PrecoFimDeSemanaGrande;
            this.Distancia = Distancia;
        }
    }
}