// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import NavBar from './components/NavBar';
import Login from './components/Login';
import EmployerDashboard from './components/EmployerDashboard';
import ProtectedRoute from './components/ProtectedRoute';
import AddEmployer from './components/Register';
import AddJobForm from './components/AddJobForm';
import AppRoutes from './routes/AppRoutes';

const App = () => {
  return (
   <AppRoutes/>
  );
};



export default App;

