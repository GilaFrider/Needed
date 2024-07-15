// src/redux/thunks/criterionThunk.js
import { createAsyncThunk } from '@reduxjs/toolkit';
import api from '../../utils/axios'; // Adjust the import path accordingly

export const addCriterion = createAsyncThunk(
  'criterion/addCriterion',
  async (criteria, { rejectWithValue }) => {
    try {
      const response = await api.post('/criterion', criteria);
      console.log("nnnn" + response.data.id);
      return response.data
      //return getCriterion(response.data.code); // Ensure the payload contains the data you expect
    } catch (error) {
      if (!error.response) {
        throw error;
      }
      return rejectWithValue(error.response.data);
    }
  }
);
export const getCriterion = createAsyncThunk(
  'criteria/getCriterion',
  async (code, { rejectWithValue }) => {
    try {
      const response = await api.get(`/criterion/${code}`);
      return response.data; // Ensure the payload contains the data you expect
    } catch (error) {
      if (!error.response) {
        throw error;
      }
      return rejectWithValue(error.response.data);
    }
  }
);

