import { addEmployer,setEmployer } from "../slices/employerSlice";
import {getEmployersService} from "../../services/employerService";



export const getEmployersThunk = () => {
    console.log("getEmployersThunk");
    return async (dispatch) => {
        const employers = await getEmployersService();
        dispatch(setEmployer(employers));
    }
}