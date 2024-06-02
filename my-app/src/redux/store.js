import {configureStore} from '@reduxjs/toolkit'
import jobSlice from './slices/jobSlice';
import employerSlice from './slices/employerSlice';
const store = configureStore({
    reducer: {
        employerSlice,
        jobSlice,
        
    }
})

export default store;