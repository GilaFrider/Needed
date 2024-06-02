import axios from '../utils/axios'
// נבצע את קריאות השרת service ב

//get
export const getJobsService = async () => {
    return await axios.get("/jobs")
    .then(response => {
        const jobs = response.data
        console.log(jobs);
      });
}

//post
export const addJobService = async(newJob) => {
    console.log("addJobService ");
    const response=await axios.post("/jobs",newJob);
    const job=await response.data;
    return job;

}

//update
// export const updateJobService = async (id, job) =>{
//     console.log("updatejobService");
//     const response = await axios.put(`/jobs/${id}`,job);
//     const job = response.data;
//     console.log(job);
//     return job;
// }
