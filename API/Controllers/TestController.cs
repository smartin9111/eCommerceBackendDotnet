using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly ITestRepository _testRepo;

        public TestController(ITestRepository testrepo)
        {
            _testRepo = testrepo;
        }


        [HttpGet]
        public async Task<ActionResult<List<Test>>> getAllTestAsync()
        {
            return await _testRepo.GetAllTests();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Test>>> getSingleTestAsync(int id)
        {
            var result = await _testRepo.GetSingleTest(id);
            if (result is null)
                return NotFound("The test not exist.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Test>>> AddTestAsync([FromBody] Test test)
        {
            var result = await _testRepo.AddTestAsync(test);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Test>>> UpdateTestAsync(int id, Test request)
        {
            var result = await _testRepo.UpdateTestAsync(id, request);
            if (result is null)
                return NotFound("The test not exist.");

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Test>>> DeleteTestAsync(int id)
        {
            var result = await _testRepo.DeleteTestAsync(id);
            if (result is null)
                return NotFound("The test not exist.");

            return Ok(result);
        }
    }
}