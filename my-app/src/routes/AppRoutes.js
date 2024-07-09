import React from 'react';
import { Routes, Route } from 'react-router-dom';
import HomePage from '../components/HomePage';
import AddEmployerForm from '../components/AddEmployer';
import EmployerLoginForm from '../components/Login';
import EmployerDashboard from '../components/EmployerDashboard';
//import ProtectedRoute from '../components/ProtectedRoute';

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/add-employer" element={<AddEmployerForm />} />
      <Route path="/login" element={<EmployerLoginForm />} />
      <Route path="/dashboard" element={
          // <ProtectedRoute>
            <EmployerDashboard />
          // </ProtectedRoute>
        }
      />
      {/* Add more routes here as needed */}
    </Routes>
  );
};

export default AppRoutes;
