import { createSlice } from '@reduxjs/toolkit';
import { addEmployer } from '../thunks/employerThunk';

const employerSlice = createSlice({
  name: 'employers',
  initialState: {
    employers: [],
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
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
      });
  },
});

export default employerSlice.reducer;
