using Microsoft.AspNetCore.Mvc;
using Algrorithm;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net;
using System.Net.Http.Json;

namespace app.Controllers;

[ApiController]
[Route("[controller]")]
public class StringProcessingController : ControllerBase
{

    [HttpGet("{input}/{typeOfSort}")]
    public async Task<IActionResult> Get(string input, string typeOfSort) {
        try {
            if (input == null || input.Length == 0) return Content("");
            Algrorithm.Algrorithm.check(input);

            var processed = Algrorithm.Algrorithm.process(input);
            var count = Algrorithm.Algrorithm.count(processed);
            var maxSubstring = Algrorithm.Algrorithm.getMaxSubstring(processed);
            var withoutSybmol = (new Algrorithm.Async()).deleteRandomSymbol(processed);

            // "Введите 0 или любой другой символ (qSort или TreeSort) для выбора способа сортировки");
            var typeS = "qSort";
            var res = "null";
            if (typeOfSort != "0") {
                typeS = "tSort";
                res = Algrorithm.Algrorithm.treeSort(processed);
            } else
                res = Algrorithm.Algrorithm.quickSort(processed);

            return Ok((new JsonObject{
                ["processed"] = processed
                ,["by alphabetical occurrence"] = JsonArray.Parse(JsonSerializer.Serialize(count))
                ,["maxSubString"] = maxSubstring
                ,["type + string"] = (typeS + " " + res)
                ,["withoutSymbol"] = await withoutSybmol
            }).ToJsonString());
            
        } catch (Exception ex) {
            return BadRequest(ex.Message);    
        }
    }
}
