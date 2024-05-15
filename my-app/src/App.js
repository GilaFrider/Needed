import React from "react";
import axios from "axios";
 
class App extends React.Component {
    state = {
        newfiles: null,
    };
 
    // handleFile(e) {
    //     // Getting the files from the input
    //     let newfiles = e.target.newfiles;
    //     this.setState({ newfiles });
    // }
 
    handleUpload(e) {
    //     let newfiles = this.state.newfiles;
 
    //     let formData = new FormData();
 
    //     // Adding files to the formdata
    //     formData.append("image", newfiles);
    //     formData.append("name", "Name");
 
        axios({
            // Endpoint to send files
            url: "http://localhost:5152/api/FieldOfWork",
            method: "GET",
            headers: {
                // Add any auth token here
                authorization: "your token comes here",
            },
 
            // Attaching the form data
            // data: formData,
        })
            // Handle the response from backend here
            .then((res) => {})
 
            // Catch errors if any
            .catch((err) => {});
    }
 
    render() {
        return (
            <div>
                <h1>Select your files</h1>
                
                <button
                    onClick={(e) => this.handleUpload(e)}
                >
                    Send Files
                </button>
            </div>
        );
    }
}
 
export default App;
