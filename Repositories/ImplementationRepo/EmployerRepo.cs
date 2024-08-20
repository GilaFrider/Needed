using Repositories.ApiRepo;
using Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repositories.ImplementationRepo
{
    public class EmployerRepo : IEmployerRepo
    {
        private readonly Context _context;

        public EmployerRepo(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employer>> GetAllAsync()
        {
            return await _context.Employers.ToListAsync();
        }

        public async Task<Employer> GetByIdAsync(int id)
        {
            return await _context.Employers.FindAsync(id);
        }

        public async Task CreateAsync(Employer entity)
        {
            await _context.Employers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employer entity)
        {
            _context.Employers.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Employers.FindAsync(id);
            if (entity != null)
            {
                _context.Employers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Employer> GetByEmailAsync(string email)
        {
            return await _context.Employers
                .FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
