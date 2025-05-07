using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegister.Data;
using UserRegister.Entities;

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
            var nome = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Idade: ");
            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Idade inválida.");
                return;
            }
            var userToAdd = new User { Name = nome, Email = email, Age = idade };
            _context.Users.Add(userToAdd);
            _context.SaveChanges();

            Console.WriteLine($"Usuário cadastrado com sucesso: \n {userToAdd}");
            Task.Delay(2000).Wait();
        }

        public void ListUsers()
        {
            var usuarios = _context.Users.ToList();

            if (!usuarios.Any())
            {
                Console.WriteLine("Nenhum usuário encontrado.");
                return;
            }

            Console.WriteLine("=== Lista de Usuários ===");
            foreach (var u in usuarios)
                Console.WriteLine($"ID: {u.Id}, Nome: {u.Name}, Email: {u.Email}, Idade: {u.Age}");
        }

    }
}
