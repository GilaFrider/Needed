import { configureStore } from '@reduxjs/toolkit';
import authReducer from './slices/authSlice.js';
import jobReducer from './slices/jobSlice';
import employerReducer from './slices/employerSlice';
import fieldOfWorkReducer from './slices/fieldOfWorkSlice.js';

const store = configureStore({
  reducer: {
    auth: authReducer,
    jobs: jobReducer,
    employers: employerReducer,
    fieldOfWorks: fieldOfWorkReducer,
  },
});

export default store;
