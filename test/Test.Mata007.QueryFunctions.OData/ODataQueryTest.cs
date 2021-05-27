using NUnit.Framework;
using Microsoft.AspNetCore.TestHost;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Linq;

namespace Test.QueryFunctions.OData
{
    public class ODataQueryTest
    {
        private TestServer testServer;

        [OneTimeTearDown]
        public virtual void Cleanup()
        {
            testServer.Dispose();
        }

        [OneTimeSetUp]
        public virtual void Initialize()
        {
            testServer = ODataPangramsServer.CreateServer(null);
        }

        private async Task<ODataQueryResonse<PangramsDto>> getData(string method, string filter)
        {
            HttpResponseMessage responseMessage = await testServer
                .CreateClient()
                .GetAsync($"odata/Pangrams?$filter={method}(Text, '{filter}')");

            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.OK);

            var responseString = await responseMessage.Content.ReadAsStringAsync();
            ODataQueryResonse<PangramsDto> result = JsonConvert.DeserializeObject<ODataQueryResonse<PangramsDto>>(responseString);
            return result;
        }


        [Test]
        [TestCase("RUKISI", "LV")]
        [TestCase("PRAGREZE", "LT")]
        [TestCase("SPRITUIT", "RO")]
        [TestCase("DODOSE", "RS")]
        [TestCase("KUN", "CZ")]
        [TestCase("BLOD", "DE")]
        [TestCase("SPLODZ", "PL")]
        [TestCase("KORU", "SK")]
        [TestCase("ІХНЄ", "UA")]
        [TestCase("ВЗДОХНЕТ", "RU")]

        public async Task Contains(string filter, string resultId)
        {
            ODataQueryResonse<PangramsDto> result = await getData("containsai", filter);
            Assert.IsTrue(result.Value.Any((p) => p.Id == resultId));
        }

        [Test]
        [TestCase("GLAZSKUNA", "LV")]
        [TestCase("ILINKDAMA", "LT")]
        [TestCase("BAND", "RO")]
        [TestCase("PRILIS", "CZ")]
        [TestCase("JEZU", "PL")]
        [TestCase("KRDEL", "SK")]

        public async Task StartsWith(string filter, string resultId)
        {
            ODataQueryResonse<PangramsDto> result = await getData("startswithai", filter);
            Assert.IsTrue(result.Value.Any((p) => p.Id == resultId));
        }

        [Test]
        [TestCase("VAKUS.", "LV")]
        [TestCase("ARBUZA.", "LT")]
        [TestCase("ODY.", "CZ")]
        [TestCase("PASS.", "DE")]
        [TestCase("HANB!", "PL")]
        [TestCase("MASO.", "SK")]

        public async Task EndsWithAI(string filter, string resultId)
        {
            ODataQueryResonse<PangramsDto> result = await getData("endswithaI", filter);
            Assert.IsTrue(result.Value.Any((p) => p.Id == resultId));
        }
    }
}