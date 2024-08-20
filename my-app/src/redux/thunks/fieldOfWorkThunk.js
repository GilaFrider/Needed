import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from '../../utils/axios';

export const fetchFieldsOfWork = createAsyncThunk(
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