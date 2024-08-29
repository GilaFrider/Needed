// src/redux/slices/fieldOfWorkSlice.js
import { createSlice } from '@reduxjs/toolkit';
import { fetchFieldsOfWork } from '../thunks/fieldsOfWorkThunk';

const fieldsOfWorkSlice = createSlice({
  name: 'fieldOfWorks',
  initialState: {
    fieldsOfWork: [],
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchFieldsOfWork.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(fetchFieldsOfWork.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.fieldsOfWork = action.payload;
      })
      .addCase(fetchFieldsOfWork.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.payload;
      });
  },
});

export default fieldsOfWorkSlice.reducer;