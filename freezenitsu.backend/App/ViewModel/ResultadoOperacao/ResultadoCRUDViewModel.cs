using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel.ResultadoOperacao
{
    public class ResultadoCRUDViewModel
    {
        public bool IsSucessfull { get; set; }
        public string[] Error { get; set; } = new string[0];
    }
}
