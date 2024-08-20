// // import React, { useEffect, useState } from 'react';
// // import { useDispatch, useSelector } from 'react-redux';
// // import { getJobs, deleteJob, updateJob } from '../redux/thunks/jobThunk';
// // import UpdateJobForm from '../components/updateJob';

// // const HomePage = () => {
// //   const dispatch = useDispatch();
// //   const { jobs, status, error } = useSelector((state) => state.jobs);
// //   const [editingJob, setEditingJob] = useState(null);

// //   useEffect(() => {
// //     dispatch(getJobs());
// //   }, [dispatch]);

// //   const handleCancelEdit = () => {
// //     setEditingJob(null);
// //   };

// //   const handleSaveEdit = (jobId, updatedJob) => {
// //     dispatch(updateJob({ jobId, updatedJob }));
// //     setEditingJob(null);
// //   };

// //   if (status === 'loading') {
// //     return <div>Loading...</div>;
// //   }

// //   if (status === 'failed') {
// //     return <div>Error: {error}</div>;
// //   }

// //   return (
// //     <div className="home-page">
// //       <div className="row justify-content-center">
// //         {jobs.map((job, index) => (
// //           <div key={index} className="col-12 mb-3">
// //             <div className="card mx-auto" style={{ maxWidth: '50%' }}> {/* Center and add side margins */}
// //               <div className="card-body text-center"> {/* Center the text */}
// //                 <h5 className="card-title">{job.fieldOfWorkCodeNavigation?.fieldOfWorkName} : תחום</h5>
// //                 <p className="card-text">{job.employerCodeNavigation?.companyName} : החברה המגייסת</p>
// //                 <p className="card-text">{job.employerCodeNavigation?.companyAddress} : כתובת</p>
// //                 <h4><strong> : דרישות</strong></h4>
// //                 <p>{job.severalYearsOfExperience} : מספר שנות נסיון</p>
// //                 <p>{job.description} : תיאור המשרה</p>
// //                 <p>{job.salary} : הצעת שכר</p>
// //                 <a href="#" className="btn btn-primary">לשליחת קורות חיים</a>
// //               </div>
// //             </div>
// //           </div>
// //         ))}
// //       </div>

// //       {editingJob && (
// //         <UpdateJobForm
// //           job={editingJob}
// //           onSave={handleSaveEdit}
// //           onCancel={handleCancelEdit}
// //         />
// //       )}
// //     </div>
// //   );
// // };

// // export default HomePage;
// import React, { useEffect, useState } from 'react';
// import { useDispatch, useSelector } from 'react-redux';
// import { getJobs } from '../redux/thunks/jobThunk';
// import NavBar from '../components/NavBar'; // Import NavBar component

// const HomePage = () => {
//   const dispatch = useDispatch();
//   const { jobs, status, error } = useSelector((state) => state.jobs);
//   const [filteredJobs, setFilteredJobs] = useState([]);

//   useEffect(() => {
//     dispatch(getJobs());
//   }, [dispatch]);

//   useEffect(() => {
//     setFilteredJobs(jobs);
//   }, [jobs]);

//   const handleSearch = ({ experience, fieldOfWork }) => {
//     let filtered = jobs;

//     if (experience) {
//       filtered = filtered.filter(
//         (job) => job.severalYearsOfExperience <= experience
//       );
//     }

//     if (fieldOfWork) {
//       filtered = filtered.filter(
//         (job) => job.fieldOfWorkCodeNavigation?.fieldOfWorkName.includes(fieldOfWork)
//       );
//     }

//     setFilteredJobs(filtered);
//   };

//   if (status === 'loading') {
//     return <div>Loading...</div>;
//   }

//   if (status === 'failed') {
//     return <div>Error: {error}</div>;
//   }

//   return (
//     <div className="home-page">
//       <NavBar onSearch={handleSearch} /> {/* Pass the handleSearch function to NavBar */}
//       <div className="row justify-content-center">
//         {filteredJobs.map((job, index) => (
//           <div key={index} className="col-12 mb-3">
//             <div className="card mx-auto" style={{ maxWidth: '50%' }}>
//               <div className="card-body text-center">
//                 <h5 className="card-title">{job.fieldOfWorkCodeNavigation?.fieldOfWorkName} : תחום</h5>
//                 <p className="card-text">{job.employerCodeNavigation?.companyName} : החברה המגייסת</p>
//                 <p className="card-text">{job.employerCodeNavigation?.companyAddress} : כתובת</p>
//                 <h4><strong> : דרישות</strong></h4>
//                 <p>{job.severalYearsOfExperience} : מספר שנות נסיון</p>
//                 <p>{job.description} : תיאור המשרה</p>
//                 <p>{job.salary} : הצעת שכר</p>
//                 <a href="#" className="btn btn-primary">לשליחת קורות חיים</a>
//               </div>
//             </div>
//           </div>
//         ))}
//       </div>
//     </div>
//   );
// };

// export default HomePage;
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

  const handleSearch = ({ experience, fieldOfWork }) => {
    let filtered = jobs;

    if (experience) {
      filtered = filtered.filter(
        (job) => job.severalYearsOfExperience <= experience
      );
    }

    if (fieldOfWork) {
      filtered = filtered.filter(
        (job) => job.fieldOfWorkCodeNavigation?.fieldOfWorkName.includes(fieldOfWork)
      );
    }

    setFilteredJobs(filtered);
  };

  if (status === 'loading') {
    return <div>Loading...</div>;
  }

  if (status === 'failed') {
    return <div>Error: {error}</div>;
  }

  return (
    <div className="home-page">
      <NavBar onSearch={handleSearch} />
      <div className="row justify-content-center">
        {filteredJobs.map((job, index) => (
          <div key={index} className="col-12 mb-3">
            <div className="card mx-auto" style={{ maxWidth: '50%' }}>
              <div className="card-body text-center">
                <h5 className="card-title">{job.fieldOfWorkCodeNavigation?.fieldOfWorkName} : תחום</h5>
                <p className="card-text">{job.employerCodeNavigation?.companyName} : החברה המגייסת</p>
                <p className="card-text">{job.employerCodeNavigation?.companyAddress} : כתובת</p>
                <h4><strong> : דרישות</strong></h4>
                <p>{job.severalYearsOfExperience} : מספר שנות נסיון</p>
                <p>{job.description} : תיאור המשרה</p>
                <p>{job.salary} : הצעת שכר</p>
                <Link to={`/send-cv/${job.employerCode}`} className="btn btn-primary">לשליחת קורות חיים</Link>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default HomePage;
