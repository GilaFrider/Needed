import { addEmployer,setEmployer } from "../slices/employerSlice";
import {getEmployersService, addEmployersService} from "../../services/employerService";



export const getEmployersThunk = () => {
    console.log("getEmployersThunk");
    return async (dispatch) => {
        const employers = await getEmployersService();
        dispatch(setEmployer(employers));
    }
}
export const addEmployersThunk =  (employee) => {
    return async (dispatch) =>
    await dispatch(addEmployer(employee));
}