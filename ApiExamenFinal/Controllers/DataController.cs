using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using ApiExamenFinal.Models;
using Newtonsoft.Json;

namespace ApiExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]

        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
             string connectionString = "Endpoint=sb://queueexamenfinal.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=d2dwttlnWFXaphpKvlEhR/jTFjfuXZ28JmXjuzcND9I=;EntityPath=colaexamenfinal";
             string queueName = "colaexamenfinal";
             string mensaje = JsonConvert.SerializeObject(data);

            // create a Service Bus client 
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }

            return true;
        }
    }
}

        