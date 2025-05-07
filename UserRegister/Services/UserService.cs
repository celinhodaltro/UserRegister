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

            _context.Users.Add(new User { Name = nome, Email = email, Age = idade });
            _context.SaveChanges();

            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

    }
}
