using System;
using System.Collections.Generic;
using System.Linq;

namespace Citation_Interview_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thanks Citation team for this interview.");
            Console.WriteLine("Ishan, be serious! This is live interview");
            Console.WriteLine("---------------------------------------------");

            double cartPrice = 0;
            List<Items> allItems = Items.GetItemsData();
            List<Cart> cart = new List<Cart>();
            cart.Add(new Cart(3, allItems[0]));
            cart.Add(new Cart(2, allItems[1]));
            cart.Add(new Cart(5, allItems[2]));
            cart.Add(new Cart(2, allItems[3]));

            cartPrice = cart.Sum(x => x.FinalPrice);
            Console.WriteLine(cartPrice.ToString());
        }
    }

    public class Cart
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public Items Item { get; set; }
        public double FinalPrice
        {
            get { return CalculateFinalPrice(); }
        }
        public ItemDiscounts ItemDiscounts
        {
            get { return GetItemDiscount(); }
        }
        ItemDiscounts GetItemDiscount()
        {
            return ItemDiscounts.GetDiscountsData().Where(x => x.ItemId == Item.Id).SingleOrDefault();
        }
        public Cart(int qty, Items item)
        {
            this.Qty = qty;
            this.Item = item;
        }
        double CalculateFinalPrice()
        {
            double final = 0;
            if (ItemDiscounts == null)
                final = (this.Qty * this.Item.Price);
            else
            {
                if (this.Qty == ItemDiscounts.DiscountQty)
                    final = ItemDiscounts.FlatDiscountPrice;
                else if (this.Qty < ItemDiscounts.DiscountQty)
                    final = (this.Qty * this.Item.Price);
                else
                {
                    final = (this.Qty / ItemDiscounts.DiscountQty) * ItemDiscounts.FlatDiscountPrice;
                    if (this.Qty % ItemDiscounts.DiscountQty > 0)
                        final = (this.Qty / ItemDiscounts.DiscountQty) * ItemDiscounts.FlatDiscountPrice +
                            (this.Qty % ItemDiscounts.DiscountQty * this.Item.Price);
                }
            }
            return final;
        }
    }

    public class ItemDiscounts
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int DiscountQty { get; set; }
        public double FlatDiscountPrice { get; set; }
        public ItemDiscounts(int id, int iId, int qty, double price)
        {
            Id = id;
            ItemId = iId;
            DiscountQty = qty;
            FlatDiscountPrice = price;
        }
        public static List<ItemDiscounts> GetDiscountsData()
        {
            List<ItemDiscounts> discounts = new List<ItemDiscounts>();
            discounts.Add(new ItemDiscounts(1, 1, 3, 1.3));
            discounts.Add(new ItemDiscounts(2, 2, 2, 0.45));
            discounts.Add(new ItemDiscounts(3, 3, 3, 2));
            return discounts;
        }
    }

    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Items(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public static List<Items> GetItemsData()
        {
            List<Items> items = new List<Items>();
            items.Add(new Items(1, "A", 0.5));
            items.Add(new Items(2, "B", 0.3));
            items.Add(new Items(3, "C", 1));
            items.Add(new Items(4, "D", 1));
            return items;
        }
    }
}
