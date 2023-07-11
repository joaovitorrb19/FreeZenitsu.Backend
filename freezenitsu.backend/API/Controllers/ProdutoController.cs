using App.InputModel.Produto;
using App.Services.Interfaces;
using App.ViewModel.ResultadoOperacao;
using Core.Entidades;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            try
            {
                var produtos = _produtoService.Get();
                return Ok(produtos);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } });
            }
            
        }

        [HttpGet]
        [Route("getbyid")]
        public IActionResult GetById([FromBody]int id)
        {
            try
            {
                var produto = _produtoService.Get(id);
                return Ok();
            }
            catch (EntidadeJaCadastradaException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } });
            }
            
        }

        [HttpGet]
        [Route("getbyname")]
        public IActionResult GetByName([FromBody]string name)
        {
            try
            {
                var produto = _produtoService.Get(name);
                return Ok(produto);
            }
            catch (EntidadeJaCadastradaException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } });
            }
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post([FromForm]string Nome, [FromForm]string Preco, [FromForm]string CategoriaId, [FromForm]IFormFile Imagem)
        {

            if (String.IsNullOrEmpty(Nome) && String.IsNullOrEmpty(Preco) && String.IsNullOrEmpty(CategoriaId))
            {
                var resultadoDTO = new ResultadoCRUDViewModel {IsSucessfull = false,Error = new string[1] {"Algum campo faltando..."} };
                return BadRequest(resultadoDTO);
            }
                
            try
            {
                _produtoService.Create(Nome,Preco,CategoriaId,Imagem);

                return Ok(new ResultadoCRUDViewModel { IsSucessfull = true});
            }
            catch (EntidadeJaCadastradaException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] {$"{e.Message}"} };
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("put")]
        public IActionResult Put([FromBody] ProdutoInputModel produto)
        {
            try
            {
                _produtoService.Put(produto);
                return Ok(new ResultadoCRUDViewModel { IsSucessfull = true });
            }
            catch (EntidadeJaCadastradaException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } });
            }
            
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromBody] ProdutoInputModel produto)
        {
            try
            {
                _produtoService.Delete(produto);
                return Ok(new ResultadoCRUDViewModel { IsSucessfull = true});
            }
            catch (EntidadeJaCadastradaException e)
            {
                var resultadoDTO = new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } };
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(new ResultadoCRUDViewModel { IsSucessfull = false, Error = new string[1] { $"{e.Message}" } });
            }
        }
    }
}
