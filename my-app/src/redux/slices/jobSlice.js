import { createSlice } from '@reduxjs/toolkit'

export const jobSlice = createSlice({
    name: 'jobs',
    initialState: {
        jobs: undefined,
    },
    reducers: {
        addJob: (state, action) => {
            if(state.clients !== undefined){
                state.jobs.push(action.payload)
            }
        },
        setJob: (state, action) => {
            state.jobs = action.payload
        }
    }
})
export const { setJob, addJob } = jobSlice.actions
export default jobSlice.reducer;
