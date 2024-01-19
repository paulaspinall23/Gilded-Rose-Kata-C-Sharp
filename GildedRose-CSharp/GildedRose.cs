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

            if (item.Name != "Fabergé egg") {
                    item.SellIn = item.SellIn - 1;
                }
            return item.SellIn;
        }

       private int GetUpdatedQuality(Item item) {
            
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a Coldplay concert") {

                if (item.Quality > 0) {

                    if (item.Name != "Fabergé egg") {

                        item.Quality = item.Quality - 1;
                    }
                }
            } else {

                if (item.Quality < 50) {

                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a Coldplay concert") {

                        if (item.SellIn < 10) {

                            if (item.Quality < 50) {

                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 5)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }
            
            if (item.SellIn < 0) {

                if (item.Name != "Aged Brie") {

                    if (item.Name != "Backstage passes to a Coldplay concert") {

                        if (item.Quality > 0) {

                            if (item.Name != "Fabergé egg") {

                                item.Quality = item.Quality - 1;
                            }
                        }
                    } else {

                        item.Quality = item.Quality - item.Quality;
                    }
                } else {

                    if (item.Quality < 50) {

                        item.Quality = item.Quality + 1;
                    }
                }
            }
            return item.Quality;
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