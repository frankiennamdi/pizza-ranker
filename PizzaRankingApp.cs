using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace pizza_counter
{

    public class PizzaRankingApp
    {
        static void Main(string[] args)
        {
            var rank = 1;
            var lowestRankLimit = 20;
            var pizzaOrderService = new PizzaOrderService();
            var pizzaWithCount = pizzaOrderService.PizzaOrders()
            .GroupBy(pizza => string.Join(", ", pizza.Toppings))
            .Select(item => new
            {
                Toppings = item.Key,
                Count = item.Count()
            })
            .OrderByDescending(key => key.Count)
            .Take(lowestRankLimit);

            foreach (var pizza in pizzaWithCount)
            {
                Console.WriteLine("Rank = {0}, Toppings = [{1}], Times = {2}", rank++, pizza.Toppings, pizza.Count);
            }
        }
    }
}