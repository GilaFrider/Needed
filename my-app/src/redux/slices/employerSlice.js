import { createSlice } from "@reduxjs/toolkit";

export const employerSlice = createSlice({
    name: 'employers',
    initialState: {
        employers: undefined,
    },
    reducers: {
        addEmployer: (state, action) => {
            if(state.employers!== undefined){
                state.employers.push(action.payload)
            }
        },
        setEmployer: (state, action) => {
            state.employers = action.payload
        }
    }
});
export const { addEmployer, setEmployer } = employerSlice.actions;
export default employerSlice.reducer;