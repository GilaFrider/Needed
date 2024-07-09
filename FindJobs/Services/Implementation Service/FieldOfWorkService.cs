
using Services.Api_Service;
using Services.DTO;
using Repositiries;
using Repositiries.Api_Repo;
using Repositiries.Models;

namespace Services.Implementation_Service
{
    public class FieldOfWorkService : IFieldOfWorkService
    {
        private readonly IFieldOfWorkRepo _fieldOfWorkRepo;
        public FieldOfWorkService(ManagerRepo dalManager)
        {
            _fieldOfWorkRepo = dalManager.fieldOfWork;
        }

        public FieldOfWorkDTO Create(FieldOfWorkDTO item)
        {
            throw new NotImplementedException();
        }

        public List<FieldOfWorkDTO> GetAll()
        {
            try
            {
                List<FieldOfWork> fieldOfWorks = _fieldOfWorkRepo.GetAll();

                List<FieldOfWorkDTO> fieldOfWorkDTOs = fieldOfWorks.Select(fieldOfWork => new FieldOfWorkDTO
                {
                    Code = fieldOfWork.Code,
                    FieldOfWorkName = fieldOfWork.FieldOfWorkName,
                }).ToList();

                return fieldOfWorkDTOs;
            }
            catch (Exception ex)
            {
                // Handle any exceptions or add logging here
                throw; // You can rethrow the exception or handle it as needed
            }

        }

        public FieldOfWorkDTO GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
