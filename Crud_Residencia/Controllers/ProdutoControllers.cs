using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ApiService _apiService;

    public ProdutoController(AppDbContext context, ApiService apiService)
    {
        _context = context;
        _apiService = apiService;
    }

    // ✅ Endpoints do banco de dados (já existiam)
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Produtos.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return Ok(produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Produto produto)
    {
        var produtoBanco = await _context.Produtos.FindAsync(id);
        if (produtoBanco == null)
            return NotFound();

        produtoBanco.Nome = produto.Nome;
        produtoBanco.Preco = produto.Preco;
        await _context.SaveChangesAsync();
        return Ok(produtoBanco);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
            return NotFound();

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return Ok("Produto removido");
    }

    // ✅ Endpoints que chamam o ApiService (novos!)
    [HttpGet("mock")]
    public async Task<IActionResult> GetMock()
    {
        var resultado = await _apiService.GetProdutos();
        return Ok(resultado);
    }

    [HttpPost("mock")]
    public async Task<IActionResult> PostMock([FromBody] object produto)
    {
        var resultado = await _apiService.PostProduto(produto);
        return Ok(resultado);
    }

    [HttpPut("mock/{id}")]
    public async Task<IActionResult> PutMock(int id, [FromBody] object produto)
    {
        var resultado = await _apiService.PutProduto(id, produto);
        return Ok(resultado);
    }

    [HttpDelete("mock/{id}")]
    public async Task<IActionResult> DeleteMock(int id)
    {
        var resultado = await _apiService.DeleteProduto(id);
        return Ok(resultado);
    }
}