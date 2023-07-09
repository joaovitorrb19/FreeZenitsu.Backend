using App.InputModel;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("")]
    public class ProdutoController : Controller
    {
        public ProdutoController()
        {
                
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("getbyid")]
        public IActionResult GetById([FromBody]int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("getbyname")]
        public IActionResult GetByName([FromBody]string name)
        {
            return Ok();
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post([FromBody]ProdutoInputModel produto)
        {
            return Ok();
        }

        [HttpPut]
        [Route("put")]
        public IActionResult Put([FromBody] ProdutoInputModel produto)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromBody] ProdutoInputModel produto)
        {
            return Ok();
        }
    }
}
