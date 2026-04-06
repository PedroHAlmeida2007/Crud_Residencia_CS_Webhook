using Microsoft.AspNetCore.Mvc;

namespace Crud_CSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiService _apiService;

        public ProdutosController(ApiService apiService)
        {
            _apiService = apiService;
        }


        /// GET - Recupera todos os produtos do mock server
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _apiService.GetProdutos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao obter produtos", error = ex.Message });
            }
        }

        /// POST - Cria um novo produto no mock server
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object produto)
        {
            try
            {
                var result = await _apiService.PostProduto(produto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar produto", error = ex.Message });
            }
        }

        /// PUT - Atualiza um produto existente no mock server
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] object produto)
        {
            try
            {
                var result = await _apiService.PutProduto(id, produto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao atualizar produto", error = ex.Message });
            }
        }

        /// DELETE - Deleta um produto do mock server
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _apiService.DeleteProduto(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao deletar produto", error = ex.Message });
            }
        }

    }
}
