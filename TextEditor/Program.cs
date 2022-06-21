using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir o arquivo");
            Console.WriteLine("2 - Criar Novo Arquivo");
            Console.WriteLine("0 - Sair da Aplicação");
            System.Console.WriteLine("");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            System.Console.WriteLine("");
            string path = Console.ReadLine();
            System.Console.WriteLine("");

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            //System.Console.WriteLine("");
            Console.WriteLine(" [ Pressione ENTER para continuar ] ");
            Console.ReadLine();
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo: ");
            Console.WriteLine("[ Pressione ESC para SALVAR o arquivo e SAIR ]");
            Console.WriteLine("-----");
            System.Console.WriteLine("");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            // Console.Write(text);
            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho você deseja salvar este arquivo?");

            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            System.Console.WriteLine("");
            Console.WriteLine($"Arquivo {path} foi salvo com sucesso!");
            Console.WriteLine(" [ Pressione ENTER para continuar ] ");
            System.Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }
    }
}
