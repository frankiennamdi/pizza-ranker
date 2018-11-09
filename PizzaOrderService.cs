using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace pizza_counter
{
    public class PizzaOrderService
    {
        public IEnumerable<Pizza> PizzaOrders()
        {
            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead("http://files.olo.com/pizzas.json"))
            using (StreamReader streamReader = new StreamReader(stream))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.SupportMultipleContent = true;
                var serializer = new JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        yield return serializer.Deserialize<Pizza>(reader);
                    }
                }
            }
        }
    }
}
