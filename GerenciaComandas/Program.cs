using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaComandas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();

            // Quantidade de clientes na mesa
            int nClientes = Convert.ToInt32(Console.ReadLine());

            // Quantidade de itens
            int nItens = Convert.ToInt32(Console.ReadLine());

            // Ler item e valor digitados
            for(int i = 0; i < nItens; i++)
            {
                string valorDigitado = Console.ReadLine();
                string[] valores = valorDigitado.Split(' ');
                Item item = new Item { descricao = valores[0], valor = Convert.ToInt32(valores[1]) };
                itens.Add(item);
            }

            // Ler itens que serão removidos da divisão por clientes
            string itensRemovidos = Console.ReadLine();

            // Total da conta
            int total = itens.Sum(x => x.valor);
            Console.WriteLine(total);

            // Divisão por cliente
            int divisaoPorCliente = itens.Where(x => !itensRemovidos.Contains(x.descricao)).Sum(x => x.valor) / nClientes;
            Console.WriteLine(divisaoPorCliente);

            // Restante da conta
            // Total - TotalDivididoPorCliente
            int restanteDaConta = itens.Where(x => itensRemovidos.Contains(x.descricao)).Sum(x => x.valor);
            Console.WriteLine(restanteDaConta);

            Console.ReadKey();
        }
    }

    class Item
    {
        public string descricao { get; set; }
        public int valor { get; set; }
    }
}
