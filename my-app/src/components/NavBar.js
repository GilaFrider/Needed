import React, { useState, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { fetchFieldsOfWork } from '../redux/thunks/fieldsOfWorkThunk';

const NavBar = ({ onSearch }) => {
  const dispatch = useDispatch();
  const location = useLocation();

  useEffect(() => {
    dispatch(fetchFieldsOfWork());
  }, [dispatch]);
  
  const { fieldsOfWork } = useSelector(state => state.fieldsOfWork);
  const [experience, setExperience] = useState('');
  const [selectedFieldOfWork, setSelectedFieldOfWork] = useState('');

  const handleSearch = (e) => {
    e.preventDefault();
    console.log('onSearch:', onSearch);
    if (typeof onSearch === 'function') {
      onSearch({ experience, selectedFieldOfWork });
    }
  };

  return (
    <nav className="navbar navbar-light bg-light justify-content-between">
      <div >
        <a className="navbar-brand">Needed</a>
        <div className='d-flex'>
        <Link className="nav-link" to="/" style={{ color: 'black' }}>Home</Link>
        <Link className="nav-link" to="/delete-job" style={{ color: 'black' }}>MyJobs</Link>
        <Link className="nav-link" to="/add-job" style={{ color: 'black' }}>Add Job</Link>
          <Link className="nav-link" to="/login" style={{ color: 'black' }}>Login</Link>
        </div>
      </div>
      {location.pathname === '/' && (
        <form className="form-inline" onSubmit={handleSearch}>
          <input
            type="number"
            className="form-control mr-sm-2"
            placeholder="Years of Experience"
            value={experience}
            onChange={(e) => setExperience(e.target.value)}
          />
          <select
            className="form-control mr-sm-2"
            value={selectedFieldOfWork}
            onChange={(e) => setSelectedFieldOfWork(e.target.value)}
          >
            <option value="">Select Field</option>
            {fieldsOfWork.map((field) => (
              <option key={field.code} value={field.code}>
                {field.fieldOfWorkName}
              </option>
            ))}
          </select>
          <button className="btn btn-outline-success my-2 my-sm-0" type="submit">
            Search
          </button>
        </form>
      )}
    </nav>
  );
};

export default NavBar;
