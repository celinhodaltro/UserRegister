using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegister.Entities
{
    public class User
    {
        [Key]
        public int {get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Nome: {Name}, Email: {Email}, Idade: {Age}";
        }
    }
}
