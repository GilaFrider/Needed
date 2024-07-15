import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { addEmployer } from '../redux/thunks/employerThunk';
import { Link, useNavigate } from 'react-router-dom';

const Register = () => {
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
    <div className="login-container">
      <div className="login-box">
      <h1 className="login-title" >Register</h1>
      {status === 'loading' && <p>Loading...</p>}
      {status === 'failed' && <p>Error: {error}</p>}
      <form onSubmit={handleSubmit} className="register-form">
        <input
          type="email"
          name="email"
          placeholder="Email"
          value={formData.email}
          onChange={handleChange}
          className="register-input"
          required
        />
        <input
          type="password"
          name="password"
          placeholder="password"
          value={formData.password}
          onChange={handleChange}
          className="register-input"
          required
        />
        <input
          type="text"
          name="phone"
          placeholder="Phone"
          value={formData.phone}
          onChange={handleChange}
          className="register-input"
          required
        />
        <input
          type="text"
          name="firstname"
          placeholder="First Name"
          value={formData.firstname}
          onChange={handleChange}
          className="register-input"
          required
        />
        <input
          type="text"
          name="lastname"
          placeholder="Last Name"
          value={formData.lastname}
          onChange={handleChange}
          className="register-input"
          required
        />
        <input
          type="text"
          name="companyName"
          placeholder="Company Name"
          value={formData.companyName}
          onChange={handleChange}
          className="register-input"
          required
        />
        <input
          type="text"
          name="companyAddress"
          placeholder="Company Address"
          value={formData.companyAddress}
          onChange={handleChange}
          className="register-input"
          required
        />
       <div className="full-width">
            <button type="submit" className="login-button">Register</button>
          </div>
      </form>
      <div className="login-register">
        Already have an account? <Link to="/login">Login</Link>
      </div>
    </div>
    </div>
  );
};

export default Register;
