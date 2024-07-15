// src/components/HomePage.js
import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getJobs } from '../redux/thunks/jobThunk';

const HomePage = () => {
  const dispatch = useDispatch();
  const { jobs, status, error } = useSelector((state) => state.jobs);

  useEffect(() => {
    //console.log('HomePage useEffect triggered');
    dispatch(getJobs());
  }, [dispatch]);

  if (status === 'loading') {
    return <div>Loading...</div>;
  }

  if (status === 'failed') {
    return <div>Error: {error}</div>;
  }

  return (
    <div>
    <div className="row justify-content-center">
        {jobs.map((job,index) => (
          <div key={index} className="col-lg-4 col-md-6 mb-4 d-flex justify-content-center">
            <div className="card">
              <div className="card-body">
             
                <h5 className="card-title">{job.fieldOfWorkCodeNavigation?.fieldOfWorkName}</h5>
                {/* <p><strong> : פרטי המפרסם</strong></p> */}
                <p className="card-text">{job.companyName} : החברה המגייסת</p>
                <p className="card-text">{job.companyAddress} : כתובת</p>
               
                <h4><strong> : דרישות</strong></h4>
                  <p>{job.criteriaCodeNavigation?.severalYearsOfExperience} : מספר שנות נסיון</p>
                  <p>{job.criteriaCodeNavigation?.Descreption} : תיאור המשרה</p>
                  <p>{job.criteriaCodeNavigation?.salary} : הצעת שכר</p>
                <a href="#" className="btn btn-primary">לשליחת קורות חיים</a>
              </div>
            </div>
          </div>
        ))}
      </div>
      
    </div>
  );
};

export default HomePage;
