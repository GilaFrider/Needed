
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate,Link } from 'react-router-dom';
import { login } from '../redux/thunks/authThunk';
import './Form.css';
const Login  = () => {
  const dispatch = useDispatch();
  const { isAuthenticated, error } = useSelector((state) => state.auth);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();
  useEffect(() => {
    if (isAuthenticated) {
      navigate(-2);
    }
  }, [isAuthenticated, navigate]);

  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(login({ email, password }));
  };

 
 
    return (
      <div className="App">
      <div className="auth-wrapper">
        <div className="auth-inner">
      <form onSubmit={handleSubmit}>
        <h3>Loginn</h3>
        <div className="mb-3">
          <label>Email address</label>
          <input
            type="email"
            onChange={(e) => setEmail(e.target.value)}
            className="form-control"
            placeholder="Enter email"
          />
        </div>
        <div className="mb-3">
          <label>Password</label>
          <input
            type="password"
            onChange={(e) => setPassword(e.target.value)}
            className="form-control"
            placeholder="Enter password"
          />
        </div>
        <div className="mb-3">
          <div className="custom-control custom-checkbox">
            <input
              type="checkbox"
              className="custom-control-input"
              id="customCheck1"
            />
            {/* <label className="custom-control-label" htmlFor="customCheck1">
              Remember me
            </label> */}
          </div>
        </div>
        <div className="d-grid">
          <button type="submit" className="btn btn-primary">
            Login
          </button>
        </div>
        {/* <p className="forgot-password text-right">
          Forgot <a href="#">password?</a>
        </p> */}
         <p className="forgot-password text-right">
          Don't registered <a href="/register">Register?</a>
        </p>
      </form>
      </div>
        </div>
      </div>
    )
  
}
export default Login;