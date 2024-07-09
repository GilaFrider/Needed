import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchFieldOfWorks, addJob } from '../redux/thunks/jobThunk'; // Adjust import paths accordingly
//import { fetchFieldOfWorks, addJob } from '../redux/thunks/jobThunk'; // Adjust import paths accordingly

const AddJobForm = ({ onAddJob }) => {
  const dispatch = useDispatch();
  const { fieldOfWorks } = useSelector(state => state.fieldOfWorks);
  const [formData, setFormData] = useState({
    fieldOfWorkCode: '',
    criteriaCode: '',
    // other job fields
  });

  useEffect(() => {
    dispatch(fetchFieldOfWorks());
  }, [dispatch]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onAddJob(formData);
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Field of Work:</label>
        <select name="fieldOfWorkCode" value={formData.fieldOfWorkCode} onChange={handleChange} required>
          <option value="">Select Field of Work</option>
          {fieldOfWorks.map((field) => (
            <option key={field.code} value={field.code}>
              {/* {field.FieldOfWorkName} */}
            </option>
          ))}
        </select>
      </div>
      {/* Add other job fields here */}
      <button type="submit">Add Job</button>
    </form>
  );
};

export default AddJobForm;
