import { createAsyncThunk } from '@reduxjs/toolkit';
import api from '../../utils/axios';

export const getJobs = createAsyncThunk(
  'jobs/fetchJobs',
  async (_, { rejectWithValue }) => {
    try {
      const response = await api.get('/jobs');
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data.message);
    }
  }
);

export const addJob = createAsyncThunk(
  'jobs/addJob',
  async (jobData, { rejectWithValue }) => {
    try {
      console.log("adding");
      const response = await api.post('/jobs', jobData);
      console.log(response);
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data.message);
    }
  }
);
