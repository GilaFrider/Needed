import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useParams } from 'react-router-dom'; // Import useParams
import { sendCV } from '../redux/thunks/employerThunk'; // Adjust the path as necessary

const SendCVForm = () => {
  const { employerId } = useParams(); // Retrieve employerId from the URL
  console.log("Employer ID: ", employerId);
  const [cvFile, setCvFile] = useState(null);
  const [message, setMessage] = useState('');
  const dispatch = useDispatch();
  const { cvStatus, cvError } = useSelector((state) => state.employers); // Assuming employers is the slice name

  const handleFileChange = (e) => {
    setCvFile(e.target.files[0]);
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!cvFile || !message) {
      alert('Please provide both a CV and a message.');
      return;
    }

    const formData = new FormData();
    formData.append('cv', cvFile);
    formData.append('message', message);

    dispatch(sendCV({ employerId, formData }));
  };

  const renderError = () => {
    if (!cvError) return null;

    if (typeof cvError === 'object') {
      return (
        <div className="alert alert-danger">
          {cvError.message || cvError.title || 'An error occurred'}
        </div>
      );
    }

    return <div className="alert alert-danger">{cvError}</div>;
  };

  return (
    <div className="container">
      <h2>Send CV to Employer</h2>
      {cvStatus === 'succeeded' && (
        <div className="alert alert-success">CV sent successfully!</div>
      )}
      {renderError()}
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="cv">Upload CV (PDF/Word):</label>
          <input
            type="file"
            id="cv"
            name="cv"
            accept=".pdf,.doc,.docx"
            onChange={handleFileChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="message">Message to Employer:</label>
          <textarea
            id="message"
            name="message"
            rows="4"
            className="form-control"
            value={message}
            onChange={(e) => setMessage(e.target.value)}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary" disabled={cvStatus === 'loading'}>
          {cvStatus === 'loading' ? 'Sending...' : 'Send CV'}
        </button>
      </form>
    </div>
  );
};

export default SendCVForm;
