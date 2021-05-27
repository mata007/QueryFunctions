using NUnit.Framework;
using Mata007.QueryFunctions;

namespace Test.QueryFunctions
{
    public class StringFuncs
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Contains()
        {
            Assert.IsTrue(Pangrams.LV.ContainsAI("RUKISI"));
            Assert.IsTrue(Pangrams.LT.ContainsAI("PRAGREZE"));
            Assert.IsTrue(Pangrams.RO.ContainsAI("IN"));
            Assert.IsTrue(Pangrams.RO.ContainsAI("SPRITUIT"));
            Assert.IsTrue(Pangrams.RS.ContainsAI("DODOSE"));
            Assert.IsTrue(Pangrams.CZ.ContainsAI("KUN"));
            Assert.IsTrue(Pangrams.DE.ContainsAI("BLOD"));
            Assert.IsTrue(Pangrams.PL.ContainsAI("SPLODZ"));
            Assert.IsTrue(Pangrams.SK.ContainsAI("KORU"));
            Assert.IsTrue(Pangrams.UA.ContainsAI("ІХНЄ"));
            Assert.IsTrue(Pangrams.RU.ContainsAI("ВЗДОХНЕТ"));
        }

        [Test]
        public void StartsWith()
        {
            Assert.IsTrue(Pangrams.LV.StartsWithAI("GLAZSKUNA"));
            Assert.IsTrue(Pangrams.LT.StartsWithAI("ILINKDAMA"));
            Assert.IsTrue(Pangrams.RO.StartsWithAI("BAND"));
            Assert.IsTrue(Pangrams.CZ.StartsWithAI("PRILIS"));
            Assert.IsTrue(Pangrams.PL.StartsWithAI("JEZU"));
            Assert.IsTrue(Pangrams.SK.StartsWithAI("KRDEL"));            
        }

        [Test]
        public void EndsWith()
        {
            Assert.IsTrue(Pangrams.LV.EndsWithAI("VAKUS."));
            Assert.IsTrue(Pangrams.LT.EndsWithAI("ARBUZA."));
            Assert.IsTrue(Pangrams.CZ.EndsWithAI("ODY."));
            Assert.IsTrue(Pangrams.DE.EndsWithAI("PASS."));
            Assert.IsTrue(Pangrams.PL.EndsWithAI("HANB!"));
            Assert.IsTrue(Pangrams.SK.EndsWithAI("MASO."));
        }
    }
}