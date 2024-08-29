import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate  } from 'react-router-dom';
import { fetchFieldsOfWork } from '../redux/thunks/fieldsOfWorkThunk';
import { addJob } from '../redux/thunks/jobThunk';
import './Form.css';

const JobForm = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { isAuthenticated } = useSelector(state => state.auth);
  if(!isAuthenticated){
    navigate('/login')
  }

  useEffect(() => {
    dispatch(fetchFieldsOfWork());
  }, [dispatch]);
  const { fieldsOfWork } = useSelector(state => state.fieldsOfWork);

  const [formData, setFormData] = useState({
    fieldOfWorkCode: '', // Added this field
    severalYearsOfExperience: '',
    salary: '',
    description: '',
  });

  

 

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const employerCode = localStorage.getItem('token'); // Fetch from local storage
    try {
      const jobData = {
        severalYearsOfExperience: Number(formData.severalYearsOfExperience),
        salary: Number(formData.salary),
        description: formData.description,
        EmployerCode: Number(employerCode),
        fieldOfWorkCode: Number(formData.fieldOfWorkCode),
      };
      await dispatch(addJob(jobData));
      navigate('/');
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
            <div className="mb-3">
              <label>Several Years of Experience:</label>
              <input
                type="text"
                className="form-control"
                name="severalYearsOfExperience"
                value={formData.severalYearsOfExperience}
                onChange={handleChange}
                placeholder="Enter several years of experience"
              />
            </div>
            <div className="mb-3">
              <label>Salary:</label>
              <input
                type="text"
                className="form-control"
                name="salary"
                value={formData.salary}
                onChange={handleChange}
                placeholder="Enter salary"
              />
            </div>
            <div className="mb-3">
              <label>Description:</label>
              <input
                type="text"
                className="form-control"
                name="description"
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

