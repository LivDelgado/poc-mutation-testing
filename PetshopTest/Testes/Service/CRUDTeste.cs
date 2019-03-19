using PetshopProject.Classes;
using System.Linq;
using Xunit;

namespace PetshopProject.Testes.Service
{
    public class CRUDTeste
    {
        [Fact]
        public void InserirPetshopTeste()
        {
            var psService = new PetshopService();
            var psAdicionar = new Petshop("PSTeste", 10, 15, 20, 30, 2.0);

            psService.InserirPetshop(psAdicionar);

            var psAdicionada = psService.BuscarPetshop(psAdicionar.Nome);

            Assert.Equal(psAdicionar.Nome, psAdicionada.Nome);
            Assert.Equal(psAdicionar.PrecoDiaUtilPequeno, psAdicionada.PrecoDiaUtilPequeno);
            Assert.Equal(psAdicionar.PrecoDiaUtilGrande, psAdicionada.PrecoDiaUtilGrande);
            Assert.Equal(psAdicionar.PrecoFimDeSemanaPequeno, psAdicionada.PrecoFimDeSemanaPequeno);
            Assert.Equal(psAdicionar.PrecoFimDeSemanaGrande, psAdicionada.PrecoFimDeSemanaGrande);
            Assert.Equal(psAdicionar.Distancia, psAdicionada.Distancia);
        }

        [Fact]
        public void EditarPetshopTeste()
        {
            var psService = new PetshopService();

            var psEditar = psService.ListarPetshops().ElementAt(0);
            var psEditada = new Petshop("PetshopEditada", 10, 10, 20, 20, 0.7);

            var editou = psService.EditarPetshop(psEditar, psEditada);
            Assert.True(editou);
            Assert.Contains(psEditada, psService.ListarPetshops());
        }

        [Fact]
        public void ExcluirPetshopTeste()
        {
            var psService = new PetshopService();

            var psExcluir = psService.ListarPetshops().ElementAt(0);

            psService.ExcluirPetshop(psExcluir);

            Assert.NotNull(psExcluir);
            Assert.DoesNotContain(psExcluir, psService.ListarPetshops());
        }

        [Fact]
        public void BuscarPetshopTeste()
        {
            var psService = new PetshopService();

            var psBuscar = psService.ListarPetshops().ElementAtOrDefault(0).Nome;

            var psEncontrada = psService.BuscarPetshop(psBuscar);

            Assert.NotNull(psBuscar);
            Assert.Equal(psBuscar, psEncontrada.Nome);
        }

        [Fact]
        public void ListarPetshopsTeste()
        {
            var psService = new PetshopService();
            var lista = psService.ListarPetshops();

            Assert.NotNull(lista);

        }
    }
}
