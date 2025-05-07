

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserRegister.Data;
using UserRegister.Entities;
using UserRegister.Services;

internal class Program
{
    private ServiceProvider serviceProvider { get; set; }
    public static void Main(string[] args) => new Program().ConsoleApp(args);
    private void ConsoleApp(string[] args)
    {
        serviceProvider = new ServiceCollection().AddDbContext<AppDbContext>(options =>
                                                        options.UseInMemoryDatabase("UsuariosDb"))
                                                     .AddScoped<UserService>()
                                                     .BuildServiceProvider();

        ExecuteProgram();
    }

    private bool ExecuteProgram()
    {
        var userService = serviceProvider.GetRequiredService<UserService>();
        bool isRunning = true;
        while (isRunning)
        {
            var option = HandleOptions();
            switch (option)
            {
                case 1:
                    userService.RegisterUser();
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

    private int HandleOptions()
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
            Task.Delay(2000).Wait();
            return HandleOptions();
        }
    }


}