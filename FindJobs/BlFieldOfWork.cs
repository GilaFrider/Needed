
using Bl.Bl_Api;
using DataBase;
using DataBase.Dal_Api;
using DataBase.Dal_Implementation;
using DataBase.Models;
using Bl.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Bl_Implementation
{
    public class BlFieldOfWork:IBlFieldOfWork
    {
        private readonly IFieldOfWorkRepo _fieldOfWorkRepo;
        //private readonly IMapper _mapper;
        public BlFieldOfWork(DalManager dalManager)
        {
            _fieldOfWorkRepo = dalManager.fieldOfWork;
            //_mapper = mapper;
        }

        public List<FieldOfWorkDTO> GetAll()
        {
            try
            {
                // Retrieve FieldOfWork entities from the repository
                List<FieldOfWork> fieldOfWorks = _fieldOfWorkRepo.GetAll();

                // Map FieldOfWork entities to FieldOfWorkDTO objects
                List<FieldOfWorkDTO> fieldOfWorkDTOs = fieldOfWorks.Select(fieldOfWork => new FieldOfWorkDTO
                {
                    Code = fieldOfWork.Code,
                    FieldOfWorkName = fieldOfWork.FieldOfWorkName,
                    //Jobs = fieldOfWork.Jobs.Select(job => new JobDTO
                    //{
                    //    // Map Job properties here
                    //}).ToList()
                }).ToList();

                return fieldOfWorkDTOs;
            }
            catch (Exception ex)
            {
                // Handle any exceptions or add logging here
                throw; // You can rethrow the exception or handle it as needed
            }

        }
    }
}
