using System;
using System.Collections.Generic;
using System.Linq;

namespace PetshopProject.Classes
{
    public class PetshopController
    {
        private static PetshopService psService;

        private DateTime data;
        private int caesPequenos;
        private int caesGrandes;

        private double precoFinal;

        public PetshopController()
        {
            psService = new PetshopService();
        }

        public string ObterInformacoesPetshop(DateTime data, int caesPequenos, int caesGrandes)
        {
            this.data = data;
            this.caesPequenos = caesPequenos;
            this.caesGrandes = caesGrandes;

            try
            {
                ValidarParametros();
            }
            catch (NegocioException ex)
            {
                return ex.Message;
            }

            List<Petshop> melhoresPetshops = ObterMelhoresPetshops();
            Petshop psEscolhida = SelecionarMelhorPetshop(melhoresPetshops);
            return FormatarInformacoesPetshop(psEscolhida);
        }

        private List<Petshop> ObterMelhoresPetshops()
        {
            List<Petshop> melhoresPetshops = new List<Petshop>();

            double preco = 0;
            double precoFinal = 0;

            foreach(Petshop ps in psService.ListarPetshops())
            {
                preco = psService.CalcularPrecoBanho(ps, data, caesPequenos, caesGrandes);

                if(precoFinal == 0 || preco < precoFinal)
                {
                    melhoresPetshops = new List<Petshop>();
                    melhoresPetshops.Add(ps);
                    precoFinal = preco;
                }
                else if (preco == precoFinal)
                {
                    melhoresPetshops.Add(ps);
                }
            }

            this.precoFinal = precoFinal;
            return melhoresPetshops;
        }

        private void ValidarParametros()
        {
            if(caesPequenos < 0 || caesGrandes < 0)
            {
                throw new NegocioException("Quantidade de cães inválida");
            }
        }

        private Petshop SelecionarMelhorPetshop(List<Petshop> melhoresPetshops)
        {
            if(melhoresPetshops.Count > 1)
            {
                return psService.CompararDistancia(melhoresPetshops);
            }
            else
            {
                return melhoresPetshops.FirstOrDefault();
            }
        }

        private string FormatarInformacoesPetshop(Petshop psEscolhida)
        {
            return string.Format("Petshop mais adequada: {0}\nPreço: {1}", psEscolhida.Nome, precoFinal);
        }

    }
}