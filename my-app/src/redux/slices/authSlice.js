// src/redux/slices/authSlice.js
import { createSlice } from '@reduxjs/toolkit';
import { employerLogin } from '../thunks/authThunk';

const authSlice = createSlice({
  name: 'auth',
  initialState: {
    isAuthenticated: false,
    user: null,
    status: 'idle',
    error: null,
  },
  reducers: {
    logout: (state) => {
      state.isAuthenticated = false;
      state.user = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(employerLogin.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(employerLogin.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.isAuthenticated = true;
        state.user = action.payload; // שומרים את פרטי המעסיק
        state.error = null;
      })
      .addCase(employerLogin.rejected, (state, action) => {
        state.status = 'failed';
        state.isAuthenticated = false;
        state.error = action.payload;
      });
  },
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;
