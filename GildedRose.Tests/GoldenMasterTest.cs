using GildedRose_CSharp;

namespace GildedRose.Tests 
{
    [TestClass]
    public class GoldenMasterTest
    {
        [TestMethod]
        public void TestGildedRoseMultipleUpdates()
        {
            var items = new List<Item>
            {
                new Item("4 Pints of Milk", 10, 20),
                new Item("Aged Brie", 2, 0),
                new Item("Elixir of the Mongoose", 5, 7),
                new Item("Fabergé egg", 0, 80),
                new Item("Fabergé egg", -1, 80),
                new Item("Backstage passes to a Coldplay concert", 15, 20),
                new Item("Backstage passes to a Coldplay concert", 10, 49),
                new Item("Backstage passes to a Coldplay concert", 5, 49),
                new Item("Lemon Drizzle Cake", 3, 6)
            };

            var gildedRose = new GildedRoseShop(items);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(
                gildedRose.ToString(),
                "4 Pints of Milk, 9, 19, Aged Brie, 1, 1, Elixir of the Mongoose, 4, 6, Fabergé egg, 0, " +
                    "80, Fabergé egg, -1, 80, Backstage passes to a Coldplay concert, 14, 21, " +
                    "Backstage passes to a Coldplay concert, 9, 50, Backstage passes to a Coldplay concert, 4, 50, " +
                    "Lemon Drizzle Cake, 2, 5"
            );

            for (var i = 0; i < 10; i++) {
                gildedRose.UpdateQuality();
            }

            Assert.AreEqual(
                gildedRose.ToString(),
                "4 Pints of Milk, -1, 8, Aged Brie, -9, 20, Elixir of the Mongoose, -6, 0, Fabergé egg, " +
                    "0, 80, Fabergé egg, -1, 80, Backstage passes to a " +
                    "Coldplay concert, 4, 38, Backstage passes to a Coldplay concert, -1, 0, " +
                    "Backstage passes to a Coldplay concert, -6, 0, Lemon Drizzle Cake, -8, 0"
            );
        }
    }
}
