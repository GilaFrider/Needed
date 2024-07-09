// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import NavBar from './components/NavBar';
import Login from './components/Login';
import EmployerDashboard from './components/EmployerDashboard';
import ProtectedRoute from './components/ProtectedRoute';
import AddEmployer from './components/AddEmployer';
import AddJobForm from './components/AddJobForm';

const App = () => {
  return (
    <Router>
      <NavBar />
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/add-employer" element={<AddEmployer />} />
        <Route path="/add-job" element={ <AddJobForm/>} />
        <Route path="/dashboard" element={<EmployerDashboard />} />
        {/* <Route path='/protected' element={<ProtectedRoute/>} /> */}
        <Route path="/" element={<Home />} />
      </Routes>
    </Router>
  );
};

const Home = () => <h1>Home</h1>;

export default App;

