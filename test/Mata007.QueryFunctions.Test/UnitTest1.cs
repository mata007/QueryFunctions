using NUnit.Framework;

namespace Mata007.QueryFunctions
{
    public class StringFuncs
    {
        // http://clagnut.com/blog/2380/
        private const string pangramLV = "Glāžšķūņa rūķīši dzērumā čiepj Baha koncertflīģeļu vākus.";
        private const string pangramLT = "Įlinkdama fechtuotojo špaga sublykčiojusi pragręžė apvalų arbūzą.";
        private const string pangramRO = "Bând whisky, jazologul șprițuit vomă fix în tequila.";
        private const string pangramRS = "Fin džip, gluh jež i čvrst konjić dođoše bez moljca.";
        private const string pangramCZ = "Příliš žluťoučký kůň úpěl ďábelské ódy.";
        private const string pangramDE = "“Fix, Schwyz!” quäkt Jürgen blöd vom Paß.";
        private const string pangramPL = "Jeżu klątw, spłódź Finom część gry hańb!";
        private const string pangramSK = "Kŕdeľ šťastných ďatľov učí pri ústí Váhu mĺkveho koňa obhrýzať kôru a žrať čerstvé mäso.";               
        private const string pangramUA = "Чуєш їх, доцю, га? Кумедна ж ти, прощайся без ґольфів! Жебракують філософи при ґанку церкви в Гадячі, ще й шатро їхнє п’яне знаємо.";
        private const string pangramRU = "Любя, съешь щипцы, — вздохнёт мэр, — Кайф жгуч!";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Contains()
        {
            Assert.IsTrue(pangramLV.ContainsAI("RUKISI"));
            Assert.IsTrue(pangramLT.ContainsAI("PRAGREZE"));
            Assert.IsTrue(pangramRO.ContainsAI("IN"));
            Assert.IsTrue(pangramRO.ContainsAI("SPRITUIT"));
            Assert.IsTrue(pangramRS.ContainsAI("DODOSE"));
            Assert.IsTrue(pangramCZ.ContainsAI("KUN"));
            Assert.IsTrue(pangramDE.ContainsAI("BLOD"));
            Assert.IsTrue(pangramPL.ContainsAI("SPLODZ"));
            Assert.IsTrue(pangramSK.ContainsAI("KORU"));
            Assert.IsTrue(pangramUA.ContainsAI("ІХНЄ"));
            Assert.IsTrue(pangramRU.ContainsAI("ВЗДОХНЕТ"));
        }

        [Test]
        public void StartsWith()
        {
            Assert.IsTrue(pangramLV.StartsWithAI("GLAZSKUNA"));
            Assert.IsTrue(pangramLT.StartsWithAI("ILINKDAMA"));
            Assert.IsTrue(pangramRO.StartsWithAI("BAND"));
            Assert.IsTrue(pangramCZ.StartsWithAI("PRILIS"));
            Assert.IsTrue(pangramPL.StartsWithAI("JEZU"));
            Assert.IsTrue(pangramSK.StartsWithAI("KRDEL"));            
        }

        [Test]
        public void EndsWith()
        {
            Assert.IsTrue(pangramLV.EndsWithAI("VAKUS."));
            Assert.IsTrue(pangramLT.EndsWithAI("ARBUZA."));
            Assert.IsTrue(pangramCZ.EndsWithAI("ODY."));
            Assert.IsTrue(pangramDE.EndsWithAI("PASS."));
            Assert.IsTrue(pangramPL.EndsWithAI("HANB!"));
            Assert.IsTrue(pangramSK.EndsWithAI("MASO."));
        }
    }
}