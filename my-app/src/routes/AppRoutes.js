import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from '../components/HomePage';
import Register from '../components/Register';
import Login from '../components/Login';
import EmployerDashboard from '../components/EmployerDashboard';
import AddJobForm from '../components/AddJobForm';
import NavBar from '../components/NavBar';

//import ProtectedRoute from '../components/ProtectedRoute';

const AppRoutes = () => {
  return (
    <BrowserRouter>
    <NavBar/>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register/>} />
        <Route path="/login" element={<Login />}/>
        <Route path='/add-job' element={<AddJobForm />} />
        <Route path="/dashboard" element={
          // <ProtectedRoute>
          <EmployerDashboard />
          // </ProtectedRoute>
        }
        />
        {/* Add more routes here as needed */}
      </Routes>
    </BrowserRouter>
  );
};

export default AppRoutes;
