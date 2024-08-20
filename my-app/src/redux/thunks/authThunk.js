// src/redux/thunks/authThunk.js
import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from '../../utils/axios';

// export const employerLogin = createAsyncThunk(
//   'auth/login', 
//   async ({ email, password }, { rejectWithValue }) => {
//   try {
//     console.log("cfvgbhnjmk")
//     const response = await axios.post('/employers/login', { email, password } );
//     const  Token  = response.data.code;
//     localStorage.setItem('token', Token);
//     alert("Login succeeded");
//     return response.data;
//   } catch (error) {
//     alert("Login Failed");
//     return rejectWithValue(error.response.data.message || 'Login failed');
//   }
// }
// );
export const login = createAsyncThunk('auth/employerLogin', async ({ email, password }, { rejectWithValue }) => {
  try {
    const response = await axios.get(`/employers/login?email=${email}&password=${password}`);
    const Token = response.data.code;
    localStorage.setItem('token', Token);
    alert("Login succeeded");
    return response.data;
  } catch (error) {
    alert("Login Failed");
    // if (!error.response) {
    //   throw error;
    // }
    return rejectWithValue(error.response.data);
  }
});
export const register = createAsyncThunk(
  'employers/register',
  async (employerData, { rejectWithValue }) => {
    try {
      const response = await axios.post('/employers', employerData);
      alert("register succeeded", response);
      return response.data;
    } catch (error) {
      alert("register Failed", error);
      return rejectWithValue(error.response.data);
    }
  }
);

