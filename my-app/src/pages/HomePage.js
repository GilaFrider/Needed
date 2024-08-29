
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getJobs } from '../redux/thunks/jobThunk';
import { Link } from 'react-router-dom';
import NavBar from '../components/NavBar';

const HomePage = () => {
  const dispatch = useDispatch();
  const { jobs, status, error } = useSelector((state) => state.jobs);
  const [filteredJobs, setFilteredJobs] = useState([]);

  useEffect(() => {
    dispatch(getJobs());
  }, [dispatch]);

  useEffect(() => {
    setFilteredJobs(jobs);
  }, [jobs]);

  const handleSearch = ({ experience, selectedFieldOfWork }) => {
    console.log('Selected Experience:', experience);
    console.log('Selected Field of Work:', selectedFieldOfWork);
  
    const filtered = jobs.filter((job) => {
      console.log('Job Field Code:', job.fieldOfWorkCode);
  
      const matchesExperience = experience ? job.severalYearsOfExperience <= experience : true;
      const matchesFieldOfWork = selectedFieldOfWork ? job.fieldOfWorkCode.toString() === selectedFieldOfWork.toString() : true;
  
      console.log('Matches Experience:', matchesExperience);
      console.log('Matches Field of Work:', matchesFieldOfWork);
  
      return matchesExperience && matchesFieldOfWork;
    });
  
    console.log('Filtered Jobs:', filtered);
  
    setFilteredJobs(filtered); // Update the state with the filtered jobs
  };

  return (
    <div className="home-page">
      <NavBar onSearch={handleSearch} />
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
                <Link to={`/send-cv/${job.employerCode}`} className="btn btn-primary">Send CV</Link>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default HomePage;
