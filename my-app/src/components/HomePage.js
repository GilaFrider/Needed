import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchJobs } from '../redux/thunks/jobThunk';

const HomePage = () => {
  const dispatch = useDispatch();
  const { jobs, status, error } = useSelector((state) => state.jobs);

  useEffect(() => {
    dispatch(fetchJobs());
  }, [dispatch]);

  if (status === 'loading') {
    return <div>Loading...</div>;
  }

  if (status === 'failed') {
    return <div>Error: {error}</div>;
  }

  return (
    <div>
      <h1>Job Listings</h1>
      <ul>
        {jobs.map((job) => (
          <li key={job.code}>
            <h2>{job.fieldOfWorkCodeNavigation?.fieldOfWorkName}</h2>
            <p>מספר שנות נסיון: {job.criteriaCodeNavigation?.severalYearsOfExperience}</p>
            <p><strong>Employer:</strong> {job.employersCodeNavigation?.companyName}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default HomePage;
