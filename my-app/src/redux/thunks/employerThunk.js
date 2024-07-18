import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from '../../utils/axios';


// Async thunk for adding an employer
export const addEmployer = createAsyncThunk(
  'employers/addEmployer',
  async (employerData, { rejectWithValue }) => {
    try {
      const response = await axios.post('/employers', employerData);
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);

