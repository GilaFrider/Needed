import { combineReducers } from "redux";
import jobReducer from "./jobReducer";

const allReducers = combineReducers({
  jobReducer: jobReducer,
});
export default allReducers;