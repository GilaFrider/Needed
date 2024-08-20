using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Repositories.ApiRepo;
using Services.ApiService;
using Repositories.Models;
using Services.DTO;

namespace Services.ImplementationService
{
    public class FieldsOfWorkService : IFieldsOfWorkService
    {
        private readonly IFieldsOfWorkRepo _fieldsOfWorkRepo;
        private readonly IMapper _mapper;

        public FieldsOfWorkService(IFieldsOfWorkRepo fieldsOfWorkRepo, IMapper mapper)
        {
            _fieldsOfWorkRepo = fieldsOfWorkRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FieldsOfWorkDTO>> GetAllAsync()
        {
            var fieldsOfWork = await _fieldsOfWorkRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<FieldsOfWorkDTO>>(fieldsOfWork);
        }

        public async Task<FieldsOfWorkDTO> GetByIdAsync(int id)
        {
            var fieldsOfWork = await _fieldsOfWorkRepo.GetByIdAsync(id);
            return _mapper.Map<FieldsOfWorkDTO>(fieldsOfWork);
        }

        public async Task CreateAsync(FieldsOfWorkDTO fieldsOfWorkDto)
        {
            var fieldsOfWork = _mapper.Map<FieldsOfWork>(fieldsOfWorkDto);
            await _fieldsOfWorkRepo.CreateAsync(fieldsOfWork);
        }

        public async Task UpdateAsync(FieldsOfWorkDTO fieldsOfWorkDto)
        {
            var fieldsOfWork = _mapper.Map<FieldsOfWork>(fieldsOfWorkDto);
            await _fieldsOfWorkRepo.UpdateAsync(fieldsOfWork);
        }

        public async Task DeleteAsync(int id)
        {
            await _fieldsOfWorkRepo.DeleteAsync(id);
        }
    }
}
