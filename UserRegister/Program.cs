

using UserRegister.Entities;

internal class Program
{
    static List<User> users = new List<User>();
    private static void Main(string[] args)
    {
        ExecuteProgram();
    }

    private static bool ExecuteProgram()
    {
        bool isRunning = true;
        while (isRunning)
        {
            var option = HandleOptions();
            switch (option)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:

                    break;
                case 0:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        return true;
    }

    private static int HandleOptions()
    {
        Console.Clear();
        Console.WriteLine("\n=== MENU ===");
        Console.WriteLine("1 - Cadastrar Usuário");
        Console.WriteLine("2 - Listar Usuários");
        Console.WriteLine("3 - Buscar Usuário por Nome");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");

        var input = Console.ReadLine();
        
        if(int.TryParse(input, out int option))
        {
            return option;
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            return HandleOptions();
        }
    }
}