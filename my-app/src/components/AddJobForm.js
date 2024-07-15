// src/components/AddJobForm.js
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchFieldOfWorks } from '../redux/thunks/fieldOfWorkThunk';
import { addJob } from '../redux/thunks/jobThunk';
import { addCriterion } from '../redux/thunks/criterionThunk';

const AddJobForm = () => {
  const dispatch = useDispatch();
  const { fieldOfWorks } = useSelector(state => state.fieldOfWorks);
  const [formData, setFormData] = useState({
    fieldOfWorkCode: '',
    criteria: {
      severalYearsOfExperience: '',
      car: false,
      numberOfCvsSent: '',
      salary: '',
      descriptions: '',
    },
    // other job fields if needed
  });

  useEffect(() => {
    dispatch(fetchFieldOfWorks());
  }, [dispatch]);

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    if (name in formData.criteria) {
      setFormData({
        ...formData,
        criteria: {
          ...formData.criteria,
          [name]: type === 'checkbox' ? checked : value,
        },
      });
    } else {
      setFormData({ ...formData, [name]: value });
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const employerCode = localStorage.getItem('token'); // Fetch from local storage
    console.log(employerCode);
    try {
      // First, add the criterion
      const resultAction = await dispatch(addCriterion(formData.criteria));
      console.log(resultAction);
      if (addCriterion.fulfilled.match(resultAction)) {
        const criteriaCode = resultAction.payload.code; // Accessing the criteria code from the payload
        console.log(criteriaCode);
  
        // Then, create the job with the returned criteria code
        const jobData = {
          EmployersCode: Number(employerCode),
          fieldOfWorkCode: Number(formData.fieldOfWorkCode),
          criteriaCode: 2,
          // other job fields if needed
        };
        console.log(jobData);
        dispatch(addJob(jobData));
      }
    } catch (error) {
      console.error('Failed to add job:', error);
    }
  };
  

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Field of Work:</label>
        <select name="fieldOfWorkCode" value={formData.fieldOfWorkCode} onChange={handleChange} required>
          <option value="">Select Field of Work</option>
          {fieldOfWorks.map((field) => (
            <option key={field.code} value={field.code}>
              {field.fieldOfWorkName}
            </option>
          ))}
        </select>
      </div>

      {/* Criterion fields */}
      <div>
        <label>Several Years of Experience:</label>
        <input type="number" name="severalYearsOfExperience" value={formData.criteria.severalYearsOfExperience} onChange={handleChange} />
      </div>
      <div>
        <label>Car:</label>
        <input type="checkbox" name="car" checked={formData.criteria.car} onChange={handleChange} />
      </div>
      <div>
        <label>Number of CVs Sent:</label>
        <input type="number" name="numberOfCvsSent" value={formData.criteria.numberOfCvsSent} onChange={handleChange} />
      </div>
      <div>
        <label>Salary:</label>
        <input type="number" name="salary" value={formData.criteria.salary} onChange={handleChange} />
      </div>
      <div>
        <label>Descriptions:</label>
        <textarea name="descriptions" value={formData.criteria.descriptions} onChange={handleChange} />
      </div>

      <button type="submit">Add Job</button>
    </form>
  );
};

export default AddJobForm;
