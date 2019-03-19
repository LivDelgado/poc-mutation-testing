using System;

namespace PetshopProject.Classes
{
    public class Program
    {
        public static void Main(string [] args)
        {
            Console.WriteLine("Informe a data:");
            string data = Console.ReadLine();

            Console.WriteLine("Informe a quantidade de cães pequenos:");
            string caesPequenos = Console.ReadLine();

            Console.WriteLine("Informe a quantidade de cães grandes:");
            string caesGrandes = Console.ReadLine();

            PetshopController controller = new PetshopController();
            Console.WriteLine(controller.ObterInformacoesPetshop(Convert.ToDateTime(data), Convert.ToInt32(caesPequenos), Convert.ToInt32(caesGrandes)));
            Console.ReadKey();
        }
    }
}
