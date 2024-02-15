namespace GildedRose_CSharp 
{
    public class GildedRoseShop
    {
        IList<Item> Items;

        public GildedRoseShop(IList<Item> items)
        {
            Items = items;
        }

        public IEnumerable<Item> UpdateItems(IEnumerable<Item> items) {
            
            return items.Select(item => new Item(item.Name, GetUpdatedSellIn(item), GetUpdatedQuality(item)));
        }

        private int GetUpdatedSellIn(Item item) {
            int newSellIn = item.SellIn;
            if (item.Name != "Fabergé egg") return newSellIn - 1;

            return newSellIn;
        }

       private int GetUpdatedQuality(Item item) {
            int newQuality = item.Quality;
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a Coldplay concert") {

                if (newQuality > 0 && item.Name != "Fabergé egg") newQuality = newQuality - 1;
                
            } else if (newQuality < 50) {

                newQuality++;
                if (item.Name == "Backstage passes to a Coldplay concert" && item.SellIn < 11 && newQuality < 50) newQuality = newQuality + 1;
                if (item.Name == "Backstage passes to a Coldplay concert" && item.SellIn < 6 && newQuality < 50) newQuality = newQuality + 1;
            }

            if (item.SellIn < 1 && item.Name != "Aged Brie" && item.Name != "Backstage passes to a Coldplay concert" && newQuality > 0 && item.Name != "Fabergé egg") newQuality = newQuality - 1;
            if (item.SellIn < 1 && item.Name == "Backstage passes to a Coldplay concert") newQuality = newQuality - newQuality;
            if (item.SellIn < 1 && item.Name == "Aged Brie" && newQuality < 50) newQuality = newQuality + 1;
            
            return newQuality;
        }

        // public void UpdateQuality()
        // {

            // for (var i = 0; i < Items.Count; i++)
        //     {
        //         if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a Coldplay concert")
        //         {
        //             if (Items[i].Quality > 0)
        //             {
        //                 if (Items[i].Name != "Fabergé egg")
        //                 {
        //                     Items[i].Quality = Items[i].Quality - 1;
        //                 }
        //             }
        //         }
        //         else
        //         {
        //             if (Items[i].Quality < 50)
        //             {
        //                 Items[i].Quality = Items[i].Quality + 1;

        //                 if (Items[i].Name == "Backstage passes to a Coldplay concert")
        //                 {
        //                     if (Items[i].SellIn < 11)
        //                     {
        //                         if (Items[i].Quality < 50)
        //                         {
        //                             Items[i].Quality = Items[i].Quality + 1;
        //                         }
        //                     }

        //                     if (Items[i].SellIn < 6)
        //                     {
        //                         if (Items[i].Quality < 50)
        //                         {
        //                             Items[i].Quality = Items[i].Quality + 1;
        //                         }
        //                     }
        //                 }
        //             }
        //         }
                
        //         if (Items[i].Name != "Fabergé egg")
        //         {
        //             Items[i].SellIn = Items[i].SellIn - 1;
        //         }

        //         if (Items[i].SellIn < 0)
        //         {
        //             if (Items[i].Name != "Aged Brie")
        //             {
        //                 if (Items[i].Name != "Backstage passes to a Coldplay concert")
        //                 {
        //                     if (Items[i].Quality > 0)
        //                     {
        //                         if (Items[i].Name != "Fabergé egg")
        //                         {
        //                             Items[i].Quality = Items[i].Quality - 1;
        //                         }
        //                     }
        //                 }
        //                 else
        //                 {
        //                     Items[i].Quality = Items[i].Quality - Items[i].Quality;
        //                 }
        //             }
        //             else
        //             {
        //                 if (Items[i].Quality < 50)
        //                 {
        //                     Items[i].Quality = Items[i].Quality + 1;
        //                 }
        //             }
        //         }
        //     }
        //}

        public string StringifyItems(IEnumerable<Item> items) {
            // var output = "";
            // for (var i = 0; i < Items.Count; i++)
            // {
            //     if (output.Length > 0)
            //     {
            //         output += ", ";
            //     }
            //     output += Items[i].ToString();
            // }
            // return output;

            // join the string values of individual items into single string
            return string.Join(", ", items);
        }
    }
    
    public class Item
    {
        public Item(string name, int sellIn, int quality) {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Name, SellIn, Quality);
        }
    }
}