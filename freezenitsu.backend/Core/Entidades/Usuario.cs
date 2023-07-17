using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Usuario : IdentityUser
    {

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }


    }
}
