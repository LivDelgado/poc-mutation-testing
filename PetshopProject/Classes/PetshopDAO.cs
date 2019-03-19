using System.Collections.Generic;

namespace PetshopProject.Classes
{
    public class PetshopDAO
    {
        private static PetshopDAO PetshopDAOInstancia;
        private static List<Petshop> ListaPetshops;

        private PetshopDAO()
        {
            ListaPetshops = new List<Petshop>();
            ListaPetshops.Add(new Petshop("Meu Canino Feliz", 20, 40, 20 * 1.2, 40 * 1.2, 2.0));
            ListaPetshops.Add(new Petshop("Vai Rex", 15, 50, 20, 55, 1.7));
            ListaPetshops.Add(new Petshop("ChowMara", 30, 45, 30, 45, 0.8));
        }

        public static PetshopDAO Instancia()
        {
            if (PetshopDAOInstancia == null)
                PetshopDAOInstancia = new PetshopDAO();
            return PetshopDAOInstancia;
        }

        public void InserirPetshop(Petshop ps)
        {
            ListaPetshops.Add(ps);
        }

        public bool EditarPetshop(Petshop psAntiga, Petshop psNova)
        {
            if (ListaPetshops.Contains(psAntiga))
            {
                ListaPetshops.Remove(psAntiga);
                ListaPetshops.Add(psNova);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExcluirPetshop(Petshop ps)
        {
            if (ListaPetshops.Contains(ps))
                ListaPetshops.Remove(ps);
        }

        public Petshop BuscarPetshop(string nomePetshop)
        {
            return ListaPetshops.Find(x => x.Nome.Equals(nomePetshop));
        }

        public IEnumerable<Petshop> ListarPetshops()
        {
            return ListaPetshops;
        }
    }
}