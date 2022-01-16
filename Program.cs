using System;

namespace DIO.Produtos
{
    class Program
    {
        static ProdutoRepositorio repositorio = new ProdutoRepositorio ();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarProduto();
						break;
					case "2":
						InserirProduto();
						break;
					case "3":
						AtualizarProduto();
						break;
					case "4":
						ExcluirProduto();
						break;
					case "5":
						VisualizarProduto();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Bem vinda a loja de calçados DIO.");
			Console.ReadLine();
        }

        private static void ExcluirProduto()
		{
			Console.Write("Digite o id do Calçado: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceProduto);
		}

        private static void VisualizarProduto()
		{
			Console.Write("Digite o id do Calçado: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			var produto = repositorio.RetornaPorId(indiceProduto);

			Console.WriteLine(produto);
		}

        private static void AtualizarProduto()
		{
			Console.Write("Digite o id do Calçado: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Classificacao)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Classificacao), i));
			}
			Console.Write("Digite a Classificação entre as opções acima: ");
			int entradaClassificacao = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição do produto: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite o Tamanho do calçado: ");
			int entradaTamanho = int.Parse(Console.ReadLine());

			Console.Write("Digite a cor do produto: ");
			string entradaCor = Console.ReadLine();

			Produtos AtualizaProduto = new Produtos(id: indiceProduto,
										classificacao: (Classificacao)entradaClassificacao,
										descricao: entradaDescricao,
										tamanho: entradaTamanho,
										cor: entradaCor);

			repositorio.AtualizarProduto(indiceProduto, AtualizarProduto);
		}
        private static void ListarProduto()
		{
			Console.WriteLine("Listar Produtos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum produto cadastrado.");
				return;
			}

			foreach (var produtos in lista)
			{
                var excluido = produtos.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaDescricao(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirProduto()
		{
			Console.WriteLine("Inserir novo produto");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Classificacao)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Classificacao), i));
			}
			Console.Write("Digite a classificação entre as opções acima: ");
			int entradaClassificacao = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição do produto: ");
;
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite o Tamanho do calçado: ");
			int entradaTamanho = int.Parse(Console.ReadLine());

			Console.Write("Digite a cor do produto: ");
			string entradaCor = Console.ReadLine();

			Produtos novoProduto = new Produtos(id: repositorio.ProximoId(),
										classificacao: (Classificacao)entradaClassificacao,
										descricao: entradaDescricao,
										tamanho: entradaTamanho,
										cor: entradaCor);

			repositorio.Insere(novoProduto );
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Bem vinda a loja de calçados DIO.");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Produtos");
			Console.WriteLine("2- Inserir novo produto");
			Console.WriteLine("3- Atualizar produto");
			Console.WriteLine("4- Excluir produto");
			Console.WriteLine("5- Visualizar produto");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
