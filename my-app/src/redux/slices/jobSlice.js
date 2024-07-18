import { createSlice } from '@reduxjs/toolkit';
import { getJobs, addJob, deleteJob, updateJob } from '../thunks/jobThunk';

const jobSlice = createSlice({
  name: 'jobs',
  initialState: {
    jobs: [],
    loading: false,
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getJobs.pending, (state) => {
        state.loading = true;
      })
      .addCase(getJobs.fulfilled, (state, action) => {
        state.loading = false;
        state.jobs = action.payload;
      })
      .addCase(getJobs.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      })
      .addCase(addJob.pending, (state) => {
        state.loading = true;
      })
      .addCase(addJob.fulfilled, (state, action) => {
        state.loading = false;
        state.jobs.push(action.payload);
      })
      .addCase(addJob.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      })
      .addCase(deleteJob.fulfilled, (state, action) => {
        state.jobs = state.jobs.filter(job => job.code !== action.payload);
      })
      .addCase(updateJob.fulfilled, (state, action) => {
        const updatedJob = action.payload;
        const existingJob = state.jobs.find((job) => job.code === updatedJob.code);
        if (existingJob) {
          Object.assign(existingJob, updatedJob);
        }
      });
  },
});

export default jobSlice.reducer;
