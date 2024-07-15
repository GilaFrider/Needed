// src/redux/slices/fieldOfWorkSlice.js
import { createSlice } from '@reduxjs/toolkit';
import { fetchFieldOfWorks } from '../thunks/fieldOfWorkThunk';

const fieldOfWorkSlice = createSlice({
  name: 'fieldOfWorks',
  initialState: {
    fieldOfWorks: [],
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchFieldOfWorks.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(fetchFieldOfWorks.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.fieldOfWorks = action.payload;
      })
      .addCase(fetchFieldOfWorks.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.payload;
      });
  },
});

export default fieldOfWorkSlice.reducer;