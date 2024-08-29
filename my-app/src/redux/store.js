import { configureStore } from '@reduxjs/toolkit';
import authReducer from './slices/authSlice.js';
import jobReducer from './slices/jobSlice';
import employerReducer from './slices/employerSlice';
import fieldsOfWorkReducer from './slices/fieldsOfWorkSlice.js';

const store = configureStore({
  reducer: {
    auth: authReducer,
    jobs: jobReducer,
    employers: employerReducer,
    fieldsOfWork: fieldsOfWorkReducer,
  },
});

export default store;
