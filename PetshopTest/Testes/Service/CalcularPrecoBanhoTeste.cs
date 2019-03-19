using PetshopProject.Classes;
using System;
using Xunit;

namespace PetshopProject.Testes.Service
{
    public class CalcularPrecoBanhoTeste
    {
        [Fact]
        public void CalcularPrecoBanhoTeste_DiaSemanaSucesso()
        {
            var psService = new PetshopService();
            var ps = new Petshop("Petshop de teste", 10, 20, 15, 30, 1.5);
            DateTime data = DateTime.Parse("2019-03-06");
            int caesPequenos = 3;
            int caesGrandes = 5;

            var resultado = psService.CalcularPrecoBanho(ps, data, caesPequenos, caesGrandes);

            Assert.Equal(resultado, 10 * 3 + 20 * 5);
        }

        [Fact]
        public void CalcularPrecoBanhoTeste_FimDeSemanaSucesso()
        {
            var psService = new PetshopService();
            var ps = new Petshop("Petshop de teste", 10, 20, 15, 30, 1.5);
            DateTime data = DateTime.Parse("2019-03-09");
            int caesPequenos = 3;
            int caesGrandes = 5;

            var resultado = psService.CalcularPrecoBanho(ps, data, caesPequenos, caesGrandes);

            Assert.Equal(resultado, 15 * 3 + 30 * 5);
        }
    }
}
