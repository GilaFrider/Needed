using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.ApiRepo;
using Repositories.Models;

namespace Repositories.ImplementationRepo
{
    public class JobRepo : IJobRepo
    {
        private readonly Context _context;

        public JobRepo(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            // Include related entities in the query
            return await _context.Jobs
                .Include(j => j.EmployerCodeNavigation)
                .Include(j => j.FieldOfWorkCodeNavigation)
                .ToListAsync();
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            // Include related entities in the query
            return await _context.Jobs
                .Include(j => j.EmployerCodeNavigation)
                .Include(j => j.FieldOfWorkCodeNavigation)
                .FirstOrDefaultAsync(j => j.Code == id);
        }

        public async Task CreateAsync(Job entity)
        {
            await _context.Jobs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Job entity)
        {
            _context.Jobs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Jobs
                .Include(j => j.EmployerCodeNavigation)
                .Include(j => j.FieldOfWorkCodeNavigation)
                .FirstOrDefaultAsync(j => j.Code == id);
            if (entity != null)
            {
                _context.Jobs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
