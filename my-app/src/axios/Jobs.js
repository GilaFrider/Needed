import React, { useState, useEffect } from 'react';
import axios from 'axios';

const GetJobs = () => {
    const [jobs, setJobs] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get('https://yourserver/api/jobs');
                setJobs(response.data);
            } catch (error) {
                console.error('Error fetching jobs: ', error);
            }
        };

        fetchData();
    }, []);

    return (
        <div>
            <h2>Jobs:</h2>
            <ul>
                {jobs.map((job) => (
                    <li key={job.id}>{job.title}</li>
                ))}
            </ul>
        </div>
    );
};

export default GetJobs;
