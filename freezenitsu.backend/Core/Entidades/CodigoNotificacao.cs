using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class CodigoNotificacao
    {
        public int id {  get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public string TipoNotificador { get; set; }

        public string TipoNotificacao {get;set; }

        public string Numero { get; set; }

        public bool IsUsado { get; set; }

        public DateTime ValidoAte { get; set; }
    }
}
