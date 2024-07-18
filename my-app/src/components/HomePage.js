import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getJobs, deleteJob, updateJob } from '../redux/thunks/jobThunk';
import UpdateJobForm from '../components/updateJob';

const HomePage = () => {
  const dispatch = useDispatch();
  const { jobs, status, error } = useSelector((state) => state.jobs);
  const [editingJob, setEditingJob] = useState(null);

  useEffect(() => {
    dispatch(getJobs());
  }, [dispatch]);

  const handleDelete = (jobId) => {
    dispatch(deleteJob(jobId));
  };

  const handleEdit = (job) => {
    setEditingJob(job);
  };

  const handleCancelEdit = () => {
    setEditingJob(null);
  };

  const handleSaveEdit = (jobId, updatedJob) => {
    dispatch(updateJob({ jobId, updatedJob }));
    setEditingJob(null);
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
                <button onClick={() => handleEdit(job)} className="btn btn-warning">Update Job</button>
              </div>
            </div>
          </div>
        ))}
      </div>

      {editingJob && (
        <UpdateJobForm
          job={editingJob}
          onSave={handleSaveEdit}
          onCancel={handleCancelEdit}
        />
      )}
    </div>
  );
};

export default HomePage;
