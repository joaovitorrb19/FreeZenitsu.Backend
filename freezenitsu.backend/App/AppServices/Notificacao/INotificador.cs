using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AppServices.Notificacao
{
    public interface INotificador
    {
        public void Notificar(string mensagem,string destinatario);
    }
}
