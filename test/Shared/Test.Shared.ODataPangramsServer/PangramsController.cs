using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.QueryFunctions.OData
{
    public class PangramsController: ODataController
    {
        List<PangramsDto> pangramsData = new();

        public PangramsController()
        {
            pangramsData.Add(new PangramsDto(nameof(Pangrams.LV), Pangrams.LV));
            pangramsData.Add(new PangramsDto(nameof(Pangrams.LT), Pangrams.LT));
            pangramsData.Add(new PangramsDto(nameof(Pangrams.RO), Pangrams.RO));
            pangramsData.Add(new PangramsDto(nameof(Pangrams.RS), Pangrams.RS));
            pangramsData.Add(new PangramsDto(nameof(Pangrams.CZ), Pangrams.CZ));
            pangramsData.Add(new PangramsDto(nameof(Pangrams.DE), Pangrams.DE));
            pangramsData.Add(new PangramsDto(nameof(Pangrams.PL), Pangrams.PL));
            pangramsData.Add(new PangramsDto(nameof(Pangrams.SK), Pangrams.SK));
            pangramsData.Add(new PangramsDto(nameof(Pangrams.UA), Pangrams.UA));
            pangramsData.Add(new PangramsDto(nameof(Pangrams.RU), Pangrams.RU));
        }

        public IActionResult Get(ODataQueryOptions<PangramsDto> options)
        {
            var result = options.ApplyTo(pangramsData.AsQueryable());
            return Ok(result);
        }
    }
}
