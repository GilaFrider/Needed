
import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { fetchFieldsOfWork } from '../redux/thunks/fieldOfWorkThunk';

const NavBar = ({ onSearch }) => {
  const [experience, setExperience] = useState('');
  const [selectedFieldOfWork, setSelectedFieldOfWork] = useState('');
  const dispatch = useDispatch();
  const fieldsOfWork = useSelector((state) => state.fieldsOfWork?.list || []);  // Assuming you have this in your Redux state

  useEffect(() => {
    dispatch(fetchFieldsOfWork());
    console.log('Fetched fieldsOfWork:', fieldsOfWork); // Debugging output
  }, [dispatch, fieldsOfWork]);
  

  const handleSearch = (e) => {
    e.preventDefault();
    onSearch({ experience, selectedFieldOfWork });
  };

  return (
    <nav className="navbar navbar-light bg-light justify-content-between">
      <div>
        <a className="navbar-brand">Needed</a>
        <div className="justify-content-between">
          <Link to="/">Home</Link>
          <Link to="/dashboard">Add Job</Link>
          <Link to="/login">Login</Link>
        </div>
      </div>
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
          {fieldsOfWork?.map((field) => (
            <option key={field.code} value={field.code}>
              {field.fieldOfWorkName}
            </option>
          ))}
        </select>
        <button className="btn btn-outline-success my-2 my-sm-0" type="submit">
          Search
        </button>
      </form>
    </nav>
  );
};

export default NavBar;

