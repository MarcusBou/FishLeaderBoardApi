using FishLeaderBoardApi.Controllers;
using FishLeaderBoardApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.Json;

namespace FishLeaderBoardApia.TEST
{
    [TestClass]
    public class LeaderBoardControllerTest
    {
        List<Record> mockdata = new List<Record>
        {
            new Record { Name = "test1", HighestWeight = 5000, MostFish = 80, Points = 600000},
            new Record { Name = "test2", HighestWeight = 4000, MostFish = 70, Points = 400000},
            new Record { Name = "test3", HighestWeight = 6000, MostFish = 60, Points = 500000},
        };

        [TestMethod]
        public void PostNewRecord_ShouldReturn201()
        {
            //Create mock element for IJsonHandler
            JsonHandlerMocker jsonHandlerMocker = new JsonHandlerMocker(MakeMockDataJson());

            //Inject JsonHandler
            LeaderboardController lbc = new LeaderboardController(jsonHandlerMocker);

            //Post new element
            IActionResult response = lbc.PostNewRecord(new Record { Name = "PostTest", HighestWeight = 10000, MostFish = 1000, Points = 1000000 });

            //Update mockdata
            MakeJsonMockData(jsonHandlerMocker.Json);

            //Assert if 201
            CreatedAtActionResult iscreated = response as CreatedAtActionResult;
            Assert.IsNotNull(iscreated);

            //Assert if over 3
            Assert.IsTrue(mockdata.Count > 3);
        }

        [TestMethod]
        public void GetTopPoint_ShouldReturn200WithListOfRecordsSorted()
        {
            //Create mock element for IJsonHandler
            JsonHandlerMocker jsonHandlerMocker = new JsonHandlerMocker(MakeMockDataJson());

            //Inject JsonHandler
            LeaderboardController lbc = new LeaderboardController(jsonHandlerMocker);

            IActionResult response = lbc.GetTopPoint(5);

            //Asserts if it 200
            OkObjectResult result = response as OkObjectResult;
            Assert.IsNotNull(result);

            //Asserts if it is an array of records
            Record[] records = result.Value as Record[];
            Assert.IsNotNull(records);

            //Asserts if is sorted
            Assert.IsTrue(records[0].Points > records[1].Points && records[1].Points > records[2].Points);
        }

        [TestMethod]
        public void GetTopFish_ShouldReturn200WithListOfRecordsSorted()
        {
            //Create mock element for IJsonHandler
            JsonHandlerMocker jsonHandlerMocker = new JsonHandlerMocker(MakeMockDataJson());

            //Inject JsonHandler
            LeaderboardController lbc = new LeaderboardController(jsonHandlerMocker);

            IActionResult response = lbc.GetTopFish(5);

            //Asserts if it 200
            OkObjectResult result = response as OkObjectResult;
            Assert.IsNotNull(result);

            //Asserts if it is an array of records
            Record[] records = result.Value as Record[];
            Assert.IsNotNull(records);

            //Asserts if is sorted
            Assert.IsTrue(records[0].MostFish > records[1].MostFish && records[1].MostFish > records[2].MostFish);
        }

        [TestMethod]
        public void GetTopWeight_ShouldReturn200WithListOfRecordsSorted()
        {
            //Create mock element for IJsonHandler
            JsonHandlerMocker jsonHandlerMocker = new JsonHandlerMocker(MakeMockDataJson());

            //Inject JsonHandler
            LeaderboardController lbc = new LeaderboardController(jsonHandlerMocker);

            IActionResult response = lbc.GetTopWeight(5);

            //Asserts if it 200 as expected
            OkObjectResult result = response as OkObjectResult;
            Assert.IsNotNull(result);

            //Asserts if it is an array of records
            Record[] records = result.Value as Record[];
            Assert.IsNotNull(records);

            //Asserts if is sorted
            Assert.IsTrue(records[0].Points > records[1].HighestWeight && records[1].HighestWeight > records[2].HighestWeight);
        }

        private string MakeMockDataJson()
        {
            return JsonSerializer.Serialize(mockdata).ToString();
        }

        private void MakeJsonMockData(string json)
        {
            mockdata = JsonSerializer.Deserialize<List<Record>>(json);
        }
    }
}