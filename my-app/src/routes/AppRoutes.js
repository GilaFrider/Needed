import React from 'react';
import { BrowserRouter as Router, Routes, Route, useLocation } from 'react-router-dom';
import HomePage from '../pages/HomePage';
// import EmployerDashboard from '../components/EmployerDashboard';
import JobForm from '../pages/JobForm';
import NavBar from '../components/NavBar';
import Login from '../pages/Login';
import Register from '../pages/Register';
import SendCVForm from '../pages/SendCVForm';
import MyJobs from '../pages/MyJobs';
import '../App.css';

const AppRoutes = () => {
  return (
    <Router>
      <NavBarWrapper />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path='/add-job' element={<JobForm />} />
        <Route path='/delete-job' element={<MyJobs />} />
        <Route path="/send-cv/:employerId" element={<SendCVForm />} />
        {/* <Route path="/dashboard" element={<EmployerDashboard />} /> */}
      </Routes>
    </Router>
  );
};

const NavBarWrapper = () => {
  const location = useLocation();
  return location.pathname !== '/' ? <NavBar /> : null;
};

export default AppRoutes;
