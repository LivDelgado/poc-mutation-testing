using System;
using System.Collections.Generic;

namespace PetshopProject.Classes
{
    public class PetshopService
    {
        private static PetshopDAO psDAO;

        public DateTime Data { get; private set; }
        public int QuantidadePequenos { get; private set; }
        public int QuantidadeGrandes { get; private set; }

        public PetshopService()
        {
            psDAO = PetshopDAO.Instancia();
        }

        public void InserirPetshop(Petshop ps)
        {
            psDAO.InserirPetshop(ps);
        }

        public void ExcluirPetshop(Petshop ps)
        {
            psDAO.ExcluirPetshop(ps);
        }

        public bool EditarPetshop(Petshop psAntiga, Petshop psNova)
        {
            return psDAO.EditarPetshop(psAntiga, psNova);
        }

        public Petshop BuscarPetshop(string nomePetshop)
        {
            return psDAO.BuscarPetshop(nomePetshop);
        }

        public IEnumerable<Petshop> ListarPetshops()
        {
            return psDAO.ListarPetshops();
        }

        public double CalcularPrecoBanho(Petshop ps, DateTime data, int caesPequenos, int caesGrandes)
        {
            double preco;

            Data = data;
            QuantidadePequenos = caesPequenos;
            QuantidadeGrandes = caesGrandes;

            DayOfWeek diaSemana = Data.DayOfWeek;

            if (diaSemana == DayOfWeek.Saturday || diaSemana == DayOfWeek.Sunday)
            {
                preco = QuantidadePequenos * ps.PrecoFimDeSemanaPequeno + QuantidadeGrandes * ps.PrecoFimDeSemanaGrande;
            }
            else
            {
                preco = QuantidadePequenos * ps.PrecoDiaUtilPequeno + QuantidadeGrandes * ps.PrecoDiaUtilGrande;
            }

            return preco;
        }

        public Petshop CompararDistancia(List<Petshop> melhoresPetshops)
        {
            double menor = 0;
            Petshop psMaisProx = null;

            foreach (Petshop ps in melhoresPetshops)
            {
                if (menor == 0 || ps.Distancia < menor)
                {
                    menor = ps.Distancia;
                    psMaisProx = ps;
                }
            }

            return psMaisProx;
        }
    }
}