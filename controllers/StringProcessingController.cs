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
    static int counter = 0;
    settings set = JsonSerializer.Deserialize<settings>(new StreamReader("appsettings.json").ReadToEnd());

    [HttpGet("{input}/{typeOfSort}")]
    public async Task<IActionResult> Get(string input, string typeOfSort) {
        counter++;
        if (counter >  int.Parse(set.Settings["ParallelLimit"][0])) return StatusCode(503);
        try {
            if (input == null || input.Length == 0) return Content("");

            Algrorithm.Algrorithm.check(input, set.Settings["BlackList"]);

            var processed = Algrorithm.Algrorithm.process(input);
            var count = Algrorithm.Algrorithm.count(processed);
            var maxSubstring = Algrorithm.Algrorithm.getMaxSubstring(processed);
            var withoutSybmol = new Algrorithm.Async().deleteRandomSymbol(processed, set.RandomApi);

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
        } finally {
            counter--;
        }
    }
}
