
import axios from 'axios';
import { getJobsThunk } from '../redux/thunks/jobThunk';
import { getEmployersThunk } from '../redux/thunks/employerThunk';
import { getJobsService } from '../services/jobService';
import { useSelector, useDispatch } from 'react-redux';

export default function HomePage() {
  //  axios.get('https://localhost:7038/api/jobs')
  //  .then(res => {
  //   const jobs = res.data;
  //   console.log(jobs);
  // })
  // const jobs2 = getJobsService()
  //   console.log(jobs2);
  const dispatch = useDispatch();
  // const jobs3 = useSelector((state) => state.jobSlice.jobs)
  return (
     
    
    <div>
      <h1>Hello World</h1>
      <button onClick={() => dispatch(getEmployersThunk())}>rrrrr</button>
      <button onClick={() => dispatch(getJobsThunk())}>fffff</button>
     
    </div>
  );
}