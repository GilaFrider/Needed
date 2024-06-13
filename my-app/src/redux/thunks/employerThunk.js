import { createAsyncThunk } from '@reduxjs/toolkit';
//import { loginRequest, loginSuccess, loginFailure } from '../slices/authSlice';
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
  'employers/login',
  async (credentials, { rejectWithValue }) => {
    try {
      const response = await axios.post('/employers/login', credentials);
      const { Token } = response.data;
      localStorage.setItem('jwtToken', Token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${Token}`;
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data.message || 'Login failed');
    }
  }
);

// export const employerLogin = (credentials) => async (dispatch) => {
//   dispatch(loginRequest());
//   try {
//     const response = await axios.post('/auth/employer-login', credentials);
//     if (response.data.role === 'employer') {
//       dispatch(loginSuccess(response.data));
//     } else {
//       dispatch(loginFailure('Unauthorized'));
//     }
//   } catch (error) {
//     dispatch(loginFailure(error.response.data.message || 'Login failed'));
//   }
// };
