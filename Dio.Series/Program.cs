using Dio.Series.Classes;
using Dio.Series.Enum;
using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoDoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirNovaSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoDoUsuario();
            }
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Lista de Séries");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada");
                return;
            }
            foreach(Serie serie in lista)
            {
                if (!serie.IsExcluido())
                {
                    Console.WriteLine("#ID {0}: - {1} ", serie.RetornaId(), serie.RetornaTitulo());
                }
            }
        }
        private static void InserirNovaSerie()
        {
            Console.WriteLine("Inserindo Nova Série");
            foreach (int i in Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Genero.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero escolhendo dentre as opções acima");
            int genero =int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o ano de lançamento da série");
            int ano = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                genero: (Genero)genero,
                titulo: titulo,
                descricao: descricao,
                ano: ano);
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizando Série");

            Console.WriteLine("Digite o ID da Série que deseja alterar");
            int id = int.Parse(Console.ReadLine());

            foreach (int i in Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Genero.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero escolhendo dentre as opções acima");
            int genero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o ano de lançamento da série");
            int ano = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série");
            string descricao = Console.ReadLine();

            Serie serieAtualizada = new Serie(id: id,
               genero: (Genero)genero,
               titulo: titulo,
               descricao: descricao,
               ano: ano);
            repositorio.Atualiza(id, serieAtualizada);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série que deseja Excluir");
            int id = int.Parse(Console.ReadLine());
            repositorio.Exclui(id);
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série que deseja Excluir");
            int id = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(id);
            Console.WriteLine(serie);
        }
        private static string ObterOpcaoDoUsuario() 
        {
            Console.WriteLine("Bem vindo ao Dio-Séries");
            Console.WriteLine("============================");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("============================");
            string opcaoUsuario = Console.ReadLine().ToUpper();

            return opcaoUsuario;
        }
    }
}
