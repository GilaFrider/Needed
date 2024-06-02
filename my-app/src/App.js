import { Provider } from 'react-redux';
import store from './redux/store';
import { useState, useEffect } from 'react';

import axios from "axios";    
import HomePage from "./components/HomePage";
import Employee from './components/Employee';
 
function App() {

        
        return (
          <Provider store={store}>
            <HomePage/> 
            <Employee/> 
        </Provider>
        );

    }
export default App;
