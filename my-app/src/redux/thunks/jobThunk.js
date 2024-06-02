
import { addJob  , setJob } from '../slices/jobSlice';
// import { setUser ,updateUser} from '../slices/auth.slice';
import { getJobsService, addJobService ,updateJobService} from '../../services/jobService';


// get
export const getJobsThunk = () => {
    console.log("getJobsThunk ");
    return async (dispatch) => {
        const jobs = await getJobsService();
        dispatch(setJob(jobs))
        console.log(jobs);
        // מבצע את הפעולה שברדוסר
    }
}

//add
export const addJobThunk = (newjob) => {
    console.log("addJobThunk ")
    return async (dispatch) => {
        const job = await addJobService(newjob)
        dispatch(addJob(job))
        return job;
    }
}


//update
// export const updateJobThunk = (id, job)=>{
//     console.log("updatejobThunk");
//     return async (dispatch)=>{
//         const job_= await updateJobService(id, job);
//         console.log(job);
//         return await dispatch(setJob(job));
//     }
// }
