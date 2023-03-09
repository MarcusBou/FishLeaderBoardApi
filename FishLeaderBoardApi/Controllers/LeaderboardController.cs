using FishLeaderBoardApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishLeaderBoardApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly string jsonpath = "./leaderboardstats";
        private IJsonHandler jsonHandler = new JsonHandler();

        [HttpGet("/")]
        public IActionResult suckadic()
        {
            return Ok("Suck a dick");
        }

        [HttpPost("/record")]
        public IActionResult PostNewRecord([FromBody] Record record)
        {
            jsonHandler.WriteOneItemToJsonFile<Record>(jsonpath, record);
            return CreatedAtAction(nameof(PostNewRecord), record);
        }

        [HttpGet("/toppoints/{amount}")]
        public IActionResult GetTopPoint([FromRoute] int amount)
        {
            Record[] records = jsonHandler.GetListOfObjectsFromJsonFile<Record[]>(jsonpath);
            if(amount > records.Length)
            {
                amount = records.Length;
            }
            // Selection sort for only up until you have the amount.
            for (int i = 0; i < records.Length; i++)
            {
                int lowestval = i;
                for (int j = i+1; j < records.Length    ; j++)
                {
                    if (records[j].Points > records[i].Points)
                    {
                        lowestval = j;
                    }
                }
                Record temp = records[lowestval];
                records[lowestval] = records[i];
                records[i] = temp;
                
            }
            //Will return from index 0 up until amount
            return Ok(records[0..amount]);
        }

        [HttpGet("/topweight/{amount}")]
        public IActionResult GetTopWeight([FromRoute] int amount)
        {
            Record[] records = jsonHandler.GetListOfObjectsFromJsonFile<Record[]>(jsonpath);
            if (amount > records.Length)
            {
                amount = records.Length;
            }
            // Selection sort for only up until you have the amount.
            for (int i = 0; i < amount; i++)
            {
                int lowestval = i;
                for (int j = i; j < records.Length; j++)
                {
                    if (records[j].HighestWeight > records[i].HighestWeight)
                    {
                        lowestval = j;
                    }
                }
                Record temp = records[lowestval];
                records[lowestval] = records[i];
                records[i] = temp;
            }
            //Will return from index 0 up until amount
            return Ok(records[0..amount]);
        }

        [HttpGet("/topfish/{amount}")]
        public IActionResult GetTopFish([FromRoute] int amount)
        {
            Record[] records = jsonHandler.GetListOfObjectsFromJsonFile<Record[]>(jsonpath);
            if (amount > records.Length)
            {
                amount = records.Length;
            }
            // Selection sort for only up until you have the amount.
            for (int i = 0; i < amount; i++)
            {
                int lowestval = i;
                for (int j = i; j < records.Length; j++)
                {
                    if (records[j].MostFish > records[i].MostFish)
                    {
                        lowestval = j;
                    }
                }
                Record temp = records[lowestval];
                records[lowestval] = records[i];
                records[i] = temp;
            }
            //Will return from index 0 up until amount
            return Ok(records[0..amount]);
        }
    }
}
