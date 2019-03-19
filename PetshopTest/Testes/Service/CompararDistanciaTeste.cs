using PetshopProject.Classes;
using System.Collections.Generic;
using Xunit;

namespace PetshopProject.Testes.Service
{
    public class CompararDistanciaTeste
    {
        [Fact]
        public void CompararDistanciaTeste_Sucesso()
        {
            var psService = new PetshopService();

            var ps1 = new Petshop("PS1", 10, 20, 15, 30, 1.2);
            var ps2 = new Petshop("PS2", 10, 20, 15, 30, 1.1);
            var listaPetshops = new List<Petshop>
            {
                ps1,
                ps2
            };

            var resultado = psService.CompararDistancia(listaPetshops);

            Assert.Equal(ps2.Distancia, resultado.Distancia);
        }

    }
}
