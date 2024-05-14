const ininitalstate = {};
const jobReducer = (state = ininitalstate, job) =>{
    switch(job.type){
        case "ADDJOB":
            return {...state,job: job.payload};
    }
    return state;
}