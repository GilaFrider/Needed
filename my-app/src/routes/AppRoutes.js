import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from '../pages/HomePage';
import EmployerDashboard from '../components/EmployerDashboard';
import JobForm from '../pages/JobForm';
import NavBar from '../components/NavBar';
import Login from '../pages/Login';
import Register from '../pages/Register';
import SendCVForm from '../pages/SendCVForm';
// import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
// import '.../node_modules/'
import '../App.css'

//import ProtectedRoute from '../components/ProtectedRoute';

const AppRoutes = () => {
  return (
    // <BrowserRouter>
    // <NavBar/>
    //   <Routes>
    //     <Route path="/" element={<HomePage />} />
    //     <Route path="/login" element={<Login />}/>
    //     <Route path='/add-job' element={<AddJobForm />} />
    //     <Route path="/dashboard" element={
    //       // <ProtectedRoute>
    //       <EmployerDashboard />
    //       // </ProtectedRoute>
    //     }
    //     />
    //     {/* Add more routes here as needed */}
    //   </Routes>
    // </BrowserRouter>
    <Router>
      {/* <NavBar/> */}
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} />
              <Route path='/add-job' element={<JobForm />} />
              <Route path="/send-cv/:employerId" element={<SendCVForm />} />
               <Route path="/dashboard" element={
          // <ProtectedRoute>
          <EmployerDashboard />
          // </ProtectedRoute>a
        }
        />
            </Routes>
     
    </Router>
  );
};

export default AppRoutes;
