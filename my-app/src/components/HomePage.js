// src/components/HomePage.js
import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getJobs, deleteJob } from '../redux/thunks/jobThunk';

const HomePage = () => {
  const dispatch = useDispatch();
  const { jobs, status, error } = useSelector((state) => state.jobs);

  useEffect(() => {
    dispatch(getJobs());
  }, [dispatch]);

  const handleDelete = (jobId) => {
    dispatch(deleteJob(jobId));
  };

  if (status === 'loading') {
    return <div>Loading...</div>;
  }

  if (status === 'failed') {
    return <div>Error: {error}</div>;
  }

  return (
    <div className="home-page">
      <div className="row justify-content-center">
        {jobs.map((job, index) => (
          <div key={index} className="col-lg-4 col-md-6 mb-4 d-flex justify-content-center">
            <div className="card job-card">
              <div className="card-body">
                <h5 className="card-title">{job.fieldOfWorkCodeNavigation?.fieldOfWorkName}</h5>
                <p className="card-text">{job.employersCodeNavigation?.companyName} : החברה המגייסת</p>
                <p className="card-text">{job.employersCodeNavigation?.companyAddress} : כתובת</p>
                <h4><strong> : דרישות</strong></h4>
                <p>{job.criteriaCodeNavigation?.severalYearsOfExperience} : מספר שנות נסיון</p>
                <p>{job.criteriaCodeNavigation?.descriptions} : תיאור המשרה</p>
                <p>{job.criteriaCodeNavigation?.salary} : הצעת שכר</p>
                <a href="#" className="btn btn-primary">לשליחת קורות חיים</a>
                <button onClick={() => handleDelete(job.code)} className="btn btn-danger">Delete Job</button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default HomePage;
