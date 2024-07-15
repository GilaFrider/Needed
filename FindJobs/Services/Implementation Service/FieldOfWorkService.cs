using Repositiries.Api_Repo;
using Repositiries.Models;
using Repositiries;
using Services.Api_Service;
using Services.DTO;

public class FieldOfWorkService : IFieldOfWorkService
{
    private readonly IFieldOfWorkRepo _fieldOfWorkRepo;

    public FieldOfWorkService(ManagerRepo dalManager)
    {
        _fieldOfWorkRepo = dalManager.fieldOfWork;
    }

    public FieldOfWorkDTO Create(FieldOfWorkDTO item)
    {
        try
        {
            var fieldOfWork = new FieldOfWork
            {
                Code = item.Code,
                FieldOfWorkName = item.FieldOfWorkName
            };
            _fieldOfWorkRepo.Create(fieldOfWork);
             // Assuming the code is generated after insertion

            return item;
        }
        catch (Exception ex)
        {
            // Handle any exceptions or add logging here
            throw; // You can rethrow the exception or handle it as needed
        }
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
        try
        {
            var fieldOfWork = _fieldOfWorkRepo.GetByName(name);

            if (fieldOfWork == null)
                return null;

            var fieldOfWorkDTO = new FieldOfWorkDTO
            {
                Code = fieldOfWork.Code,
                FieldOfWorkName = fieldOfWork.FieldOfWorkName,
            };

            return fieldOfWorkDTO;
        }
        catch (Exception ex)
        {
            // Handle any exceptions or add logging here
            throw; // You can rethrow the exception or handle it as needed
        }
    }
}
