import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from '../../utils/axios';

export const fetchJobs = createAsyncThunk(
  'jobs/fetchJobs',
  async (_, { rejectWithValue }) => {
    try {
      const response = await axios.get('/jobs');
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
      const response = await axios.post('/jobs', jobData);
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data.message);
    }
  }
);
export const fetchFieldOfWorks = createAsyncThunk(
  'fieldOfWorks/fetchFieldOfWorks',
  async (_, { rejectWithValue }) => {
    try {
      const response = await axios.get('/fieldsOfWork');
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);