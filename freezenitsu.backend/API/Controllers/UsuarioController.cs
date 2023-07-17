using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        public UsuarioController()
        {
                
        }

        public IActionResult Cadastrar()
        {
            return Ok();
        }

        public IActionResult ConfirmarCadastro()
        {
            return Ok();
        }

        public IActionResult AtualizarCadastro()
        {
            return Ok();
        }


    }
}
