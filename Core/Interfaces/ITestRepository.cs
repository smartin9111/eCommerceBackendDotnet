using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITestRepository
    {
        Task<List<Test>> GetAllTests();
        Task<Test?> GetSingleTest(int id);
        Task<List<Test>> AddTestAsync(Test test);
        Task<List<Test>> UpdateTestAsync(int id, Test request);
        Task<List<Test>> DeleteTestAsync(int id);
    }
}