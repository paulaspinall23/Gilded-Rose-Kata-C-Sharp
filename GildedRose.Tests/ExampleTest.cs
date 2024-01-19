using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose_CSharp;

namespace GildedRose.Tests 
{
    [TestClass]
    public class TestAssemblyTests
    {
        [TestMethod]
        public void TestGildedRoseFoo()
        {
            var items = new List<Item>
            {
                new Item("foo", 0, 0)
            };
            var gildedRose = new GildedRoseShop(items);
            items = gildedRose.UpdateItems(items).ToList();
            //gildedRose.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);
        }
    }
}
