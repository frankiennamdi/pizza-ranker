using System;

namespace pizza_counter
{
    public class Pizza
    {
        private string[] toppings;

        public string[] Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                Array.Sort(value);
                toppings = value;
            }
        }
    }
}
