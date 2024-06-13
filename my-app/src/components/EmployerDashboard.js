import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchJobs, addJob } from '../redux/thunks/jobThunk';
//import JobList from './JobList';
import AddJobForm from './AddJobForm';

const EmployerDashboard = () => {
  const dispatch = useDispatch();
  const { jobs, loading, error } = useSelector(state => state.jobs);

  useEffect(() => {
    dispatch(fetchJobs());
  }, [dispatch]);

  const handleAddJob = (jobData) => {
    dispatch(addJob(jobData));
  };

  return (
    <div>
      <h1>Employer Dashboard</h1>
      {loading && <p>Loading jobs...</p>}
      {error && <p>{error}</p>}
      {/* <JobList jobs={jobs} /> */}
      <h2>Add New Job</h2>
      <AddJobForm onAddJob={handleAddJob} />
    </div>
  );
};

export default EmployerDashboard;

