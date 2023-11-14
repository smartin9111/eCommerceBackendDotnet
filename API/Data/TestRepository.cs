using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class TestRepository : ITestRepository
    {
        private readonly StoreContext _context;

        public TestRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<Test>> AddTestAsync(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();
            return await _context.Tests.ToListAsync();
        }

        public async Task<List<Test>> DeleteTestAsync(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null)
                return null;

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();

            return await _context.Tests.ToListAsync();
        }

        public async Task<List<Test>> GetAllTests()
        {
            var tests = await _context.Tests.ToListAsync();
            return tests;
        }

        public async Task<Test?> GetSingleTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            return test;
        }

        public async Task<List<Test>?> UpdateTestAsync(int id, Test request)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null)
                return null;

            test.Id = request.Id;
            test.Name = request.Name;
            await _context.SaveChangesAsync();

            return await _context.Tests.ToListAsync();
        }
    }
}