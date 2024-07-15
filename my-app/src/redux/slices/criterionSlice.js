import { createSlice } from '@reduxjs/toolkit';
import { addCriterion,getCriterion } from '../thunks/criterionThunk';

const criterionSlice = createSlice({
  name: 'criteria',
  initialState: {
    criteria: [],
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(addCriterion.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(addCriterion.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.criteria.push(action.payload);
        state.error = null;
      })
      .addCase(addCriterion.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.payload;
      })
      .addCase(getCriterion.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(getCriterion.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.criterion = action.payload;
      })
      .addCase(getCriterion.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.payload;
      });
  },
});

export default criterionSlice.reducer;
