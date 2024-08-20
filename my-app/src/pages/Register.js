import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { register } from '../redux/thunks/authThunk';
import { Link, useNavigate } from 'react-router-dom';
import './Form.css';

const Register = () => {
  const dispatch = useDispatch();
  const { status, error } = useSelector((state) => state.employers);

  const [formData, setFormData] = useState({
    email: '',
    password: '',
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
    dispatch(register(formData));
  };

  return (
    <div className="App">
      <div className="auth-wrapper">
        <div className="auth-inner">
          <form onSubmit={handleSubmit}>
            <h3>Sign Up</h3>
            <div className="mb-3">
              <label>First name</label>
              <input
                type="text"
                className="form-control"
                name="firstname"  // Add the correct name attribute
                value={formData.firstname}
                onChange={handleChange}
                placeholder="First name"
              />
            </div>
            <div className="mb-3">
              <label>Last name</label>
              <input
                type="text"
                className="form-control"
                name="lastname"  // Add the correct name attribute
                value={formData.lastname}
                onChange={handleChange}
                placeholder="Last name"
              />
            </div>
            <div className="mb-3">
              <label>Email address</label>
              <input
                type="email"
                className="form-control"
                name="email"  // Add the correct name attribute
                value={formData.email}
                onChange={handleChange}
                placeholder="Enter email"
              />
            </div>
            <div className="mb-3">
              <label>Password</label>
              <input
                type="password"
                className="form-control"
                name="password"  // Add the correct name attribute
                value={formData.password}
                onChange={handleChange}
                placeholder="Enter password"
              />
            </div>
            <div className="mb-3">
              <label>Phone</label>
              <input
                type="text"
                className="form-control"
                name="phone"  // Add the correct name attribute
                value={formData.phone}
                onChange={handleChange}
                placeholder="Enter phone"
              />
            </div>
            <div className="mb-3">
              <label>Company Name</label>
              <input
                type="text"
                className="form-control"
                name="companyName"  // Add the correct name attribute
                value={formData.companyName}
                onChange={handleChange}
                placeholder="Enter your company name"
              />
            </div>
            <div className="mb-3">
              <label>Company Address</label>
              <input
                type="text"
                className="form-control"
                name="companyAddress"  // Add the correct name attribute
                value={formData.companyAddress}
                onChange={handleChange}
                placeholder="Enter your company address"
              />
            </div>

            <div className="d-grid">
              <button type="submit" className="btn btn-primary">
                Sign Up
              </button>
            </div>
            <p className="forgot-password text-right">
              Already registered <a href="/login">register?</a>
            </p>
          </form>
        </div>
      </div>
    </div>
  );
}

export default Register;
