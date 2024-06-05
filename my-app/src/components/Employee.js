
import React from 'react';
import { useDispatch } from 'react-redux';
import { getEmployersThunk,addEmployersThunk } from '../redux/thunks/employerThunk';


export default function Employee() {
  const dispatch = useDispatch();
  const handleSubmit = (event) => {
    console.log(event.target);
    const data = {
      firstname:event.target[0].value,
      lastname:event.target[1].value,
      email:event.target[2].value,
      phone:event.target[3].value,
      CompanyName:event.target[4].value,
      CompanyAddress:event.target[5].value
  };
  console.log(data);
    //const data = event.target.;
    // JSON.stringify(data)
    dispatch(addEmployersThunk(data));
    dispatch(getEmployersThunk());
    
    event.preventDefault();
}

    return(
<form onSubmit={(event)=>handleSubmit(event)}>
                <label>
                    firstname:
                    <input type="text" name="name" />
                </label>

                <label>
                    lastname:
                    <input type="text" name="name" />
                </label>

                <label>
                    email:
                    <input name="email" type="email" />
                </label>
                <label>
                    phone:
                    <input type="text" name="name" />
                </label>
                <label>
                    CompanyName:
                    <input type="text" name="name" />
                </label>
                <label>
                    CompanyAddress:
                    <input type="text" name="name" />
                </label>

                <button type="submit">Submit</button>

               
            </form>
    )
    }