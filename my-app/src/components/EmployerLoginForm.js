import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { employerLogin } from '../redux/thunks/employerThunk';

const EmployerLoginForm = () => {
  const [formData, setFormData] = useState({
    email: '',
    password: ''
  });

  const dispatch = useDispatch();
  const { loading, error, isAuthenticated } = useSelector(state => state.auth);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(employerLogin(formData));
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Phone</label>
        <input
          type="email"
          name="email"
          placeholder="email"
          value={formData.email}
          onChange={handleChange}
          required
        />
      </div>
      <div>
        <label>Password</label>
        <input
          type="password"
          name="password"
          placeholder="Password"
          value={formData.password}
          onChange={handleChange}
          required
        />
      </div>
      <button type="submit" disabled={loading}>
        {loading ? 'Logging in...' : 'Login'}
      </button>
      {error && <div>{error}</div>}
    </form>
  );
};

export default EmployerLoginForm;
