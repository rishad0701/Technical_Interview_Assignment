namespace WebApi.Controllers
{
    using Azure.Messaging.ServiceBus;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public readonly string? _connectionString;
        private readonly string? _queueName;

        public MessageController(IConfiguration configuration)
        {
            _connectionString = configuration["AzureServiceBus : ConnectionString"];
            _queueName = configuration["AzureServiceBus : QueueName"];
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] string messageContent)
        {

            var client = new ServiceBusClient(_connectionString);
            var sender = client.CreateSender(_queueName);

            var message = new ServiceBusMessage(messageContent);
            await sender.SendMessageAsync(message);

            return Ok("Message sent to Service Bus queue");
        }
    }
}
