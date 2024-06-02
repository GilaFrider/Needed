import axios from '../utils/axios'
// נבצע את קריאות השרת service ב

//get
export const getEmployersService = async () => {
    return await axios.get("/employers")
    .then(response => {
        const employers = response.data
        console.log(employers);
      }).catch(error => {
        console.log(error)
    });
}
//add
export const addEmployersService = async (employee) => {
    return await axios.post("/employers", employee)
    .then(response => {
        console.log(response.data);
      })
      .catch(error => {
        console.log(error)
    });
}