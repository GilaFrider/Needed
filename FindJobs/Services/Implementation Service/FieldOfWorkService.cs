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

        var fieldOfWork = new FieldOfWork
        {
            Code = item.Code,
            FieldOfWorkName = item.FieldOfWorkName
        };
        _fieldOfWorkRepo.Create(fieldOfWork);
        return item;

    }

    public List<FieldOfWorkDTO> GetAll()
    {
        List<FieldOfWork> fieldOfWorks = _fieldOfWorkRepo.GetAll();

        List<FieldOfWorkDTO> fieldOfWorkDTOs = fieldOfWorks.Select(fieldOfWork => new FieldOfWorkDTO
        {
            Code = fieldOfWork.Code,
            FieldOfWorkName = fieldOfWork.FieldOfWorkName,
        }).ToList();

        return fieldOfWorkDTOs;

    }

    public FieldOfWorkDTO GetByName(string name)
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
}


