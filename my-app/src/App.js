import React from "react";
import { useState, useEffect } from 'react';

import axios from "axios";
 
function App() {

        // const createJob =  () => {
        //     const jobData = {
        //         EmployersCode: 'ABC123',
        //         FieldOfWorkCode: 'IT',
        //         CriteriaCode: 'A'
        //     };
    
        //     try {
        //         const response = axios.post('http://localhost:5152/api/jobs', jobData);
        //         console.log('Job created successfully on the server: ', response.data);
        //     } catch (error) {
        //         console.error('Error creating job: ', error);
        //     }
        // };
        const GetJobs = () => {
          const [jobs, setJobs] = useState([]);
      
          useEffect(() => {
              const fetchData =  () => {
                  try {
                      const response =  axios.get('http://localhost:5152/api/jobs');
                      console.log('Jobs fetched successfully from the server: ', response.data);
                      setJobs(response.data);
                  } catch (error) {
                      console.error('Error fetching jobs: ', error);
                  }
              };
      
              fetchData();
          }, []);
        }
        return (
          <div>
          <h2>Jobs:</h2>
          <GetJobs />
          </div>
        );

    }
export default App;
