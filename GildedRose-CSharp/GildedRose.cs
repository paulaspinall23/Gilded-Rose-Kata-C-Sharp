namespace GildedRose_CSharp 
{
    public class GildedRoseShop
    {
        IList<Item> Items;

        public GildedRoseShop(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a Coldplay concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Fabergé egg")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a Coldplay concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Fabergé egg")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a Coldplay concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Fabergé egg")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            var output = "";
            for (var i = 0; i < Items.Count; i++)
            {
                if (output.Length > 0)
                {
                    output += ", ";
                }
                output += Items[i].ToString();
            }
            return output;
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