import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate  } from 'react-router-dom';
import { getJobs, deleteJob,updateJob } from '../redux/thunks/jobThunk';

const MyJobs = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { isAuthenticated } = useSelector(state => state.auth);
  if(!isAuthenticated){
    navigate('/login')
  }
  const { jobs, status, error } = useSelector((state) => state.jobs);
  const [filteredJobs, setFilteredJobs] = useState([]);
  const [editingJob, setEditingJob] = useState(null);
  const [updatedJob, setUpdatedJob] = useState({});

  // Get the employer code from local storage
  const employerCode = localStorage.getItem('token');
  console.log(employerCode)

  useEffect(() => {
    dispatch(getJobs());
  }, [dispatch]);

  useEffect(() => {
    if (employerCode) {
      // Filter jobs based on the employer code
      const filtered = jobs.filter(job => job.employerCodeNavigation.code == employerCode);
      
      jobs.map(job=>console.log(job.employerCodeNavigation))
      setFilteredJobs(filtered);
    }
  }, [jobs, employerCode]);

  const handleDelete = (jobCode) => {
    // Dispatch the deleteJob action with the job code
    dispatch(deleteJob(jobCode));
  };
  const handleUpdate = (job) => {
    setEditingJob(job);
    setUpdatedJob({
      ...job,
      // add fields you want to be editable
    });
  };

  const handleUpdateChange = (e) => {
    const { name, value } = e.target;
    setUpdatedJob((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleUpdateSubmit = (e) => {
    e.preventDefault();
    if (editingJob) {
      // Make sure updatedJob includes a `code` field if required by your API
      dispatch(updateJob({ jobId: editingJob.code, updatedData: updatedJob }));
      setEditingJob(null);
    }
  };

  // const handleUpdateSubmit = (e) => {
  //   e.preventDefault();
  //   if (editingJob) {
  //     // Destructure to remove navigation properties
  //     const { employerCodeNavigation, fieldOfWorkCodeNavigation, ...jobData } = updatedJob;
  
  //     // Dispatch the updateJob action with the cleaned data
  //     dispatch(updateJob({ jobId: editingJob.code, updatedData: jobData }));
  //     setEditingJob(null);
  //   }
  // };
  // const handleUpdateSubmit = (e) => {
  //   e.preventDefault();
  //   if (editingJob) {
  //     // Manually nullify navigation properties
  //     const updatedJobData = {
  //       ...updatedJob,
  //       // employerCodeNavigation: null,
  //       // fieldOfWorkCodeNavigation: null,
  //     };
  
  //     dispatch(updateJob({ jobId: editingJob.code, updatedData: updatedJobData }));
  //     setEditingJob(null);
  //   }
  // };
  

  return (
    <div>
      <div className="row justify-content-center">
        {filteredJobs.map((job, index) => (
           <div key={index} className="col-12 mb-3">
           <div className="card mx-auto" style={{ maxWidth: '50%' }}>
             <div className="card-body text-center">
               <h5 className="card-title">Field: {job.fieldOfWorkCodeNavigation?.fieldOfWorkName}</h5>
               <p className="card-text">Company name{job.employerCodeNavigation?.companyName}</p>
               <p className="card-text">Area: {job.employerCodeNavigation?.companyAddress}</p>
               <h4><strong>job requirements</strong></h4>
               <p>Several years of expirience: {job.severalYearsOfExperience}</p>
               <p>Description : {job.description}</p>
               <p>Salary: {job.salary}</p>
                <button
                  onClick={() => handleDelete(job.code)}
                  className="btn btn-danger"
                >
                  Delete Job
                </button>
                {/* <button
                    onClick={() => handleUpdate(job)}
                    className="btn btn-primary ml-2"
                  >
                    Update Job
                  </button> */}
              </div>
            </div>
          </div>
        ))}
      </div>
      {editingJob && (
        <div className="modal show d-block" style={{ backgroundColor: 'rgba(0,0,0,0.5)' }}>
          <div className="modal-dialog">
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Update Job</h5>
                <button
                  type="button"
                  className="close"
                  onClick={() => setEditingJob(null)}
                >
                  &times;
                </button>
              </div>
              <form onSubmit={handleUpdateSubmit}>
                <div className="modal-body">
                  {/* Include form fields for job details */}
                  <div className="form-group">
                    <label htmlFor="description">Description</label>
                    <input
                      type="text"
                      id="description"
                      name="description"
                      className="form-control"
                      value={updatedJob.description || ''}
                      onChange={handleUpdateChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="salary">Salary</label>
                    <input
                      type="number"
                      id="salary"
                      name="salary"
                      className="form-control"
                      value={updatedJob.salary || ''}
                      onChange={handleUpdateChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="experience">Several Years Of Experience</label>
                    <input
                      type="number"
                      id="experience"
                      name="experience"
                      className="form-control"
                      value={updatedJob.severalYearsOfExperience || ''}
                      onChange={handleUpdateChange}
                    />
                  </div>
                  {/* Add other fields as needed */}
                </div>
                <div className="modal-footer">
                  <button type="button" className="btn btn-secondary" onClick={() => setEditingJob(null)}>
                    Close
                  </button>
                  <button type="submit" className="btn btn-primary">
                    Save Changes
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      )}
    </div>
    
  );
};

export default MyJobs;
