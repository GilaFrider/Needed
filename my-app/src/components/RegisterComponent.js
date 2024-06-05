// import React from 'react';
// import { useDispatch } from 'react-redux';
// import { getEmployersThunk,addEmployersThunk } from '../redux/thunks/employerThunk';

// export default function RegisterComponent() {
//     const dispatch = useDispatch();
//     this.state = {
//             firstname: '',
//             lastname: '',
//             email: '',
//             phone: '',
//             CompanyName: '',
//             CompanyAddress: ''


//         };
//         this.handleSubmit = this.handleSubmit.bind(this);

   

//         const data = { firstname: this.state.firstname,lastname: this.state.lastname, email: this.state.email,
//              phone: this.state.phone, CompanyName: this.state.CompanyName, CompanyAddress: this.state.CompanyAddress }
           
//         // fetch('/api/createAccount', {
//         //     method: 'POST',

//         //     body: JSON.stringify(data), // data can be `string` or {object}!

//         //     headers: { 'Content-Type': 'application/json' }
//         // })

//         //     .then(res => res.json())

//         //     .catch(error => console.error('Error:', error))

//         //     .then(response => console.log('Success:', response));
        



  
//         return (
//             <form onSubmit={this.handleSubmit}>
//                 <label>
//                     firstname:
//                     <input type="text" name="name" />
//                 </label>

//                 <label>
//                     lastname:
//                     <input type="text" name="name" />
//                 </label>

//                 <label>
//                     email:
//                     <input name="email" type="email" />
//                 </label>
//                 <label>
//                     phone:
//                     <input type="text" name="name" />
//                 </label>
//                 <label>
//                     CompanyName:
//                     <input type="text" name="name" />
//                 </label>
//                 <label>
//                     CompanyAddress:
//                     <input type="text" name="name" />
//                 </label>



//                 <button>Send data!</button>
//             </form>
//         );
//     }

