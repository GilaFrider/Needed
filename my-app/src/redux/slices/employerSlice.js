import { createSlice } from '@reduxjs/toolkit';
import { addEmployer, sendCV } from '../thunks/employerThunk';

const employerSlice = createSlice({
  name: 'employers',
  initialState: {
    employers: [],
    status: 'idle',
    error: null,
    cvStatus: 'idle',  // New state for sending CV
    cvError: null,     // New state for handling CV errors
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      // Handling addEmployer actions
      .addCase(addEmployer.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(addEmployer.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.employers.push(action.payload);
      })
      .addCase(addEmployer.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.payload;
      })
      // Handling sendCV actions
      .addCase(sendCV.pending, (state) => {
        state.cvStatus = 'loading';
      })
      .addCase(sendCV.fulfilled, (state) => {
        state.cvStatus = 'succeeded';
        state.cvError = null;
      })
      .addCase(sendCV.rejected, (state, action) => {
        state.cvStatus = 'failed';
        state.cvError = action.payload;
      });
  },
});

export default employerSlice.reducer;
