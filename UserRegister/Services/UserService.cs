using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegister.Data;
using UserRegister.Entities;
using UserRegister.Extension;

namespace UserRegister.Services
{
    internal class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void RegisterUser()
        {
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            if(String.IsNullOrEmpty(email) || !email.isEmail())
            {
                Console.WriteLine("Email inválido.");
                Task.Delay(2000).Wait();
                return;
            }

            Console.Write("Idade: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Idade inválida.");
                Task.Delay(2000).Wait();
                return;
            }
            var userToAdd = new User { Name = name!, Email = email!, Age = age };
            _context.Users.Add(userToAdd);
            _context.SaveChanges();

            Console.WriteLine($"Usuário cadastrado com sucesso: \n {userToAdd}");
            Task.Delay(2000).Wait();
        }

        public void ListUsers()
        {
            var users = _context.Users.ToList();

            if (!users.Any())
            {
                Console.WriteLine("Nenhum usuário encontrado.");
                Task.Delay(2000).Wait();
                return;
            }

            Console.WriteLine("=== Lista de Usuários ===");
            foreach (var u in users)
                Console.WriteLine($"ID: {u.Id}, Nome: {u.Name}, Email: {u.Email}, Idade: {u.Age}");

            Console.WriteLine("\n Essa lista sera excluida em 5 segundos...");
            Task.Delay(5000).Wait();
        }

        public void FindUsers()
        {
            Console.Write("Digite o nome para buscar: ");
            var name = Console.ReadLine();

            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("O nome digitado está vazio, digite um texto valido.");
                Task.Delay(2000).Wait();
                return;
            }

            var resultados = _context.Users
                .Where(u => u.Name.Contains(name!, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!resultados.Any())
            {
                Console.WriteLine("Usuário não encontrado.");
                Task.Delay(2000).Wait();
                return;
            }

            Console.WriteLine("=== Resultado da busca ===");
            foreach (var u in resultados)
                Console.WriteLine($"ID: {u.Id}, Nome: {u.Name}, Email: {u.Email}, Idade: {u.Age}");

            Console.WriteLine("\n Essa lista sera excluida em 5 segundos...");
            Task.Delay(5000).Wait();
        }
    }

}

