// src/components/ProtectedRoute.js
import React from 'react';
import { Navigate } from 'react-router-dom';
import { useSelector } from 'react-redux';

const ProtectedRoute = () => {

  const { isAuthenticated } = useSelector(state => state.auth);

  return isAuthenticated ? <Navigate to="/add-job" /> : <Navigate to="/login" />;
  
};

export default ProtectedRoute;
