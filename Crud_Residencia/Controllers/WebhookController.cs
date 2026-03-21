using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("webhook")]
public class WebhookController : ControllerBase
{
    [HttpPost]
    public IActionResult ReceberWebhook([FromBody] object dados)
    {
        Console.WriteLine("Webhook recebido!");
        Console.WriteLine(dados);

        return Ok(new { mensagem = "Webhook recebido", dados });
    }
}