using App.ControllerServices;
using App.ControllerServices.Interfaces;
using App.InputModel.Usuario;
using App.Validators;
using App.ViewModel.ResultadoOperacao;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioInputModelValidator _validator;
        private readonly IUsuarioService _service;
        public UsuarioController(UsuarioInputModelValidator validator, IUsuarioService service)
        {
            _validator = validator;
            _service = service;
        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<IActionResult> Cadastrar([FromBody]UsuarioCadastroInputModel usuario)
        {
            var validacao = _validator.Validate(usuario);
            if (!validacao.IsValid)
                return BadRequest(new ResultadoCRUDViewModel {IsSucessfull = false , Error = validacao.Errors.Select(x => x.ErrorMessage).ToArray()});

            try
            {
               await _service.Cadastrar(usuario);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { ex.Message } });
            }
            
        }


    }
}
