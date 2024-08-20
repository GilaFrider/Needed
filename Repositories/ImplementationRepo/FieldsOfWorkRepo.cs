using Repositories.ApiRepo;
using Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repositories.ImplementationRepo
{
    public class FieldsOfWorkRepo : IFieldsOfWorkRepo
    {
        private readonly Context _context;

        public FieldsOfWorkRepo(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FieldsOfWork>> GetAllAsync()
        {
            return await _context.FieldsOfWorks.ToListAsync();
        }

        public async Task<FieldsOfWork> GetByIdAsync(int id)
        {
            return await _context.FieldsOfWorks.FindAsync(id);
        }

        public async Task CreateAsync(FieldsOfWork entity)
        {
            await _context.FieldsOfWorks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FieldsOfWork entity)
        {
            _context.FieldsOfWorks.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.FieldsOfWorks.FindAsync(id);
            if (entity != null)
            {
                _context.FieldsOfWorks.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
