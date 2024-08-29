import React, { useState } from 'react';
import NavBar from './NavBar';
import { getJobs } from '../redux/thunks/jobThunk';

const Search = () => {
  // const [jobs, setJobs] = useState([]); // This is where all jobs are stored
  // const [filteredJobs, setFilteredJobs] = useState([]); // This is where filtered jobs are stored

  // // useEffect(() => {
  //   dispatch(getJobs());
  // }, [dispatch]);

  // useEffect(() => {
  //   setFilteredJobs(jobs);
  // }, [jobs]);
 
  // const handleSearch = ({ experience, selectedFieldOfWork }) => {
  //   console.log('Selected Experience:', experience);
  //   console.log('Selected Field of Work:', selectedFieldOfWork);
  
  //   const filtered = jobs.filter((job) => {
  //     console.log('Job Field Code:', job.fieldOfWorkCode);
  
  //     const matchesExperience = experience ? job.severalYearsOfExperience >= experience : true;
  //     const matchesFieldOfWork = selectedFieldOfWork ? job.fieldOfWorkCode.toString() === selectedFieldOfWork.toString() : true;
  
  //     console.log('Matches Experience:', matchesExperience);
  //     console.log('Matches Field of Work:', matchesFieldOfWork);
  
  //     return matchesExperience && matchesFieldOfWork;
  //   });
  
  //   console.log('Filtered Jobs:', filtered);
  
  //   setFilteredJobs(filtered); // Update the state with the filtered jobs
  // };
  

  return (
    <div>
      <NavBar/> {/* Pass the handleSearch function to NavBar */}
      {/* Render the filtered jobs here */}
      <div>
        {filteredJobs.map((job, index) => (
          <div key={index}>
            {/* Render job details here */}
            <h5>{job.fieldOfWorkCodeNavigation?.fieldOfWorkName} : תחום</h5>
            <p>{job.employerCodeNavigation?.companyName} : החברה המגייסת</p>
            <p>{job.description} : תיאור המשרה</p>
            {/* More job details */}
          </div>
        ))}
      </div>
    </div>
  );
};

export default Search;
