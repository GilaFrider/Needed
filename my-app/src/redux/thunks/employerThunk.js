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
export const employerLogin = createAsyncThunk(
  'auth/employerLogin',
  async ({ email, password }, { rejectWithValue }) => {
  try {
    const response = await axios.get(`/employers/login?email=${email}&password=${password}`);
    const Token = response.data.code;
    localStorage.setItem('token', Token);
    alert("Login succeeded");
    return response.data;
  } catch (error) {
    alert("Login Failed");
    return rejectWithValue(error.response.data);
  }
});


export const sendCV = createAsyncThunk(
  'employers/sendCV',
  async ({ employerId, formData }, { rejectWithValue }) => {
    try {
      const response = await axios.post(`/employers/send-cv/${employerId}`, formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);

