using App.InputModel.Categoria;
using App.Services.Interfaces;
using App.Validators;
using App.ViewModel.ResultadoOperacao;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("categoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _service;
        private readonly CategoriaInputModelValidator _validator;

        public CategoriaController(ICategoriaService service, CategoriaInputModelValidator validator)
        {
            _service = service;
            _validator = validator;
        }

        [Route("post")]
        [HttpPost]
        public IActionResult Create([FromBody]CategoriaInputModel categoria)
        {
            var resultadoValidacao = _validator.Validate(categoria);
            if (!resultadoValidacao.IsValid)
            {
                var resultado = new ResultadoCRUDViewModel{ IsSucessfull=false};
                resultado.Error = resultadoValidacao.Errors.Select(x => x.ErrorMessage).ToArray();
                return BadRequest(resultado);
            }

            try
            {
                _service.Create(categoria);
                return Ok(new ResultadoCRUDViewModel { IsSucessfull=true});
            }
            catch (EntidadeJaCadastradaException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull=false,Error=new string[1]{ $"{e.Message}" } });
            }
            
        }
        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            
            try
            {
                var listaCategorias = _service.Get();
                return Ok(listaCategorias);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" }});
            }
            
        }

        [Route("getbyid")]
        [HttpGet]
        public IActionResult GetById([FromBody]int id)
        {
            try
            {
                _service.Get(id);

                return Ok(new ResultadoCRUDViewModel { IsSucessfull = true });
            }
            catch (EntidadeNaoExisteException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } });
            }
            
        }

        [Route("getbyname")]
        [HttpGet]
        public IActionResult GetByName([FromBody] string name)
        {
            try
            {
                var categoria = _service.Get(name);

                return Ok(categoria);
            }
            catch (EntidadeNaoExisteException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = true, Error = new string[1] {$"{e.Message}"} });
            }
            
        }

        [Route("put")]
        [HttpPut]
        public IActionResult Put([FromBody] CategoriaInputModel categoria)
        {

            var validacao = _validator.Validate(categoria);

            if (!validacao.IsValid){
                var resposta = new ResultadoCRUDViewModel { IsSucessfull = false };
                resposta.Error = validacao.Errors.Select(x => x.ErrorMessage).ToArray();
                return BadRequest(resposta);
            }

            try
            {
                _service.Put(categoria);

                return Ok(new ResultadoCRUDViewModel { IsSucessfull = true });
            }
            catch (EntidadeNaoExisteException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = true, Error = new string[1] { $"{e.Message}" } });
            }
            
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody]CategoriaInputModel categoria)
        {

            var validacao = _validator.Validate(categoria);

            if (!validacao.IsValid)
            {
                var resposta = new ResultadoCRUDViewModel {IsSucessfull=false};
                resposta.Error = validacao.Errors.Select( x => x.ErrorMessage).ToArray();
                return BadRequest(resposta);
            }

            try
            {
                _service.Delete(categoria);
                return Ok(new ResultadoCRUDViewModel { IsSucessfull=true});
            }
            catch (EntidadeNaoExisteException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }

            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = true, Error = new string[1] { $"{e.Message}" } });
            }
            
        }

    }

}
