// src/redux/thunks/authThunk.js
import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from '../../utils/axios';  

export const employerLogin = createAsyncThunk(
  'auth/login', 
  async ({ email, password }, { rejectWithValue }) => {
  try {
    console.log("cfvgbhnjmk")
    const response = await axios.post('/employers/login', { email, password } );
    const { Token } = response.data;
    localStorage.setItem('jwtToken', Token);
    alert("Login succeeded");
    return response.data;
  } catch (error) {
    alert("Login Failed");
    return rejectWithValue(error.response.data.message || 'Login failed');
  }
}
);
