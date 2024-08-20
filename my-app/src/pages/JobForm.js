// // src/components/AddJobForm.js
// import React, { useEffect, useState } from 'react';
// import { useDispatch, useSelector } from 'react-redux';
// import { fetchFieldOfWorks } from '../redux/thunks/fieldOfWorkThunk';
// import { addJob } from '../redux/thunks/jobThunk';

// const JobForm = () => {
//   const dispatch = useDispatch();
//   const { fieldOfWorks } = useSelector(state => state.fieldOfWorks);
//   const [formData, setFormData] = useState({
//     fieldOfWorkCode: '',
   
//     // other job fields if needed
//   });

//   useEffect(() => {
//     dispatch(fetchFieldOfWorks());
//   }, [dispatch]);



  

//   return (
//     <form onSubmit={handleSubmit}>
//       <div>
//         <label>Field of Work:</label>
//         <select name="fieldOfWorkCode" value={formData.fieldOfWorkCode} onChange={handleChange} required>
//           <option value="">Select Field of Work</option>
//           {fieldOfWorks.map((field) => (
//             <option key={field.code} value={field.code}>
//               {field.fieldOfWorkName}
//             </option>
//           ))}
//         </select>
//       </div>

//       {/* Criterion fields */}
      
//       {/* <div> */}
//         {/* <label>Car:</label>
//         <input type="checkbox" name="car" checked={formData.criteria.car} onChange={handleChange} />
//       </div>
//       <div>
//         <label>Number of CVs Sent:</label>
//         <input type="number" name="numberOfCvsSent" value={formData.criteria.numberOfCvsSent} onChange={handleChange} />
//       </div>
//       <div>
//         <label>Salary:</label>
//         <input type="number" name="salary" value={formData.criteria.salary} onChange={handleChange} />
//       </div>
//       <div>
//         <label>Descriptions:</label>
//         <textarea name="descriptions" value={formData.criteria.descriptions} onChange={handleChange} />
//       </div> */}

//       <button type="submit">Add Job</button>
//     </form>
//   );
// };

// export default JobForm;
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchFieldsOfWork } from '../redux/thunks/fieldOfWorkThunk';
import { addJob } from '../redux/thunks/jobThunk';
import { Link, useNavigate } from 'react-router-dom';
import './Form.css';

const JobForm = () => {
  const dispatch = useDispatch();
  const { fieldsOfWork } = useSelector(state => state.fieldsOfWork);

  const [formData, setFormData] = useState({
    severalYearsOfExperience: '',
    salary: '',
    description: '',
  });

    useEffect(() => {
    dispatch(fetchFieldsOfWork());
  }, [dispatch]);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

    const handleSubmit = async (e) => {
    e.preventDefault();
    const employerCode = localStorage.getItem('token'); // Fetch from local storage
    console.log(employerCode);
    try {
      // First, add the criterion
      

  
        // Then, create the job with the returned criteria code
        const jobData = {
          severalYearsOfExperience: Number(formData.severalYearsOfExperience),
          salary: Number(formData.salary),
          description: formData.description,
          // Add the employerCode to the jobData object, but ensure it's a number before adding it to the jobData object.
          EmployerCode: Number(employerCode),
          fieldOfWorkCode: Number(formData.fieldOfWorkCode),

          // other job fields if needed
        };
        console.log(jobData);
        dispatch(addJob(jobData));
      
    } catch (error) {
      console.error('Failed to add job:', error);
    }
  };

  return (
    <div className="App">
      <div className="auth-wrapper">
        <div className="auth-inner">
          <form onSubmit={handleSubmit}>
            <h3>Add Job</h3>
            <div className="mb-3">
            <div>
       <label>Field of Work:</label>
       <select name="fieldOfWorkCode" value={formData.fieldOfWorkCode} onChange={handleChange} required>
         <option value="">Select Field of Work</option>
         {fieldsOfWork.map((field) => (
            <option key={field.code} value={field.code}>
              {field.fieldOfWorkName}
            </option>
          ))}
        </select>
      </div>
              <label>several years of experience</label>
              <input
                type="text"
                className="form-control"
                name="severalYearsOfExperience"  // Add the correct name attribute
                value={formData.severalYearsOfExperience}
                onChange={handleChange}
                placeholder="Enter several years of experience"
              />
            </div>
            <div className="mb-3">
              <label>salary</label>
              <input
                type="text"
                className="form-control"
                name="salary"  // Add the correct name attribute
                value={formData.salary}
                onChange={handleChange}
                placeholder="Enter salary"
              />
            </div>
            <div className="mb-3">
              <label>description</label>
              <input
                type="text"
                className="form-control"
                name="description"  // Add the correct name attribute
                value={formData.description}
                onChange={handleChange}
                placeholder="Enter description"
              />
            </div>
            
              <div className="d-grid">
              <button type="submit" className="btn btn-primary">
                Add
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}

export default JobForm;
