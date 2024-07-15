// src/redux/thunks/authThunk.js
import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from '../../utils/axios';  

export const employerLogin = createAsyncThunk(
  'auth/login', 
  async ({ email, password }, { rejectWithValue }) => {
  try {
    console.log("cfvgbhnjmk")
    const response = await axios.post('/employers/login', { email, password } );
    const  Token  = response.data.code;
    localStorage.setItem('token', Token);
    alert("Login succeeded");
    return response.data;
  } catch (error) {
    alert("Login Failed");
    return rejectWithValue(error.response.data.message || 'Login failed');
  }
}
);


// export const employerLogin = createAsyncThunk('auth/login', async (credentials, { rejectWithValue }) => {
//   try {
//     const response = await axios.post('/api/auth/login', credentials);
//     const { employerDetails, token } = response.data; // נניח שהנתונים מתקבלים כך
//     // שמירת ה-token ב-localStorage לדוגמה
//     localStorage.setItem('token', token);
//     return employerDetails; // מחזירים את פרטי המעסיק
//   } catch (error) {
//     return rejectWithValue(error.response.data);
//   }
// });

