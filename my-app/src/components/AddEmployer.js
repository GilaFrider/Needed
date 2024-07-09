import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { addEmployer } from '../redux/thunks/employerThunk';

const AddEmployer = () => {
  const dispatch = useDispatch();
  const { status, error } = useSelector((state) => state.employers);

  const [formData, setFormData] = useState({
    email: '',
    password:'',
    phone: '',
    firstname: '',
    lastname: '',
    companyName: '',
    companyAddress: '',
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(addEmployer(formData));
  };

  return (
    <div>
      <h1>Add Employer</h1>
      {status === 'loading' && <p>Loading...</p>}
      {status === 'failed' && <p>Error: {error}</p>}
      <form onSubmit={handleSubmit}>
        <input
          type="email"
          name="email"
          placeholder="Email"
          value={formData.email}
          onChange={handleChange}
          required
        />
        <input
          type="password"
          name="password"
          placeholder="password"
          value={formData.password}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="phone"
          placeholder="Phone"
          value={formData.phone}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="firstname"
          placeholder="First Name"
          value={formData.firstname}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="lastname"
          placeholder="Last Name"
          value={formData.lastname}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="companyName"
          placeholder="Company Name"
          value={formData.companyName}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="companyAddress"
          placeholder="Company Address"
          value={formData.companyAddress}
          onChange={handleChange}
          required
        />
        <button type="submit">Add Employer</button>
      </form>
    </div>
  );
};

export default AddEmployer;
