import React, { useState } from 'react';

const UpdateJobForm = ({ job, onSave, onCancel }) => {
  const [formData, setFormData] = useState({
    fieldOfWorkCode: job.fieldOfWorkCode,
    severalYearsOfExperience: job.criteriaCodeNavigation?.severalYearsOfExperience,
    descriptions: job.criteriaCodeNavigation?.descriptions,
    salary: job.criteriaCodeNavigation?.salary,
    companyName: job.employersCodeNavigation?.companyName,
    companyAddress: job.employersCodeNavigation?.companyAddress
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSave(job.code, formData);
  };

  return (
    <div className="update-job-form">
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="fieldOfWorkCode"
          placeholder="Field of Work Code"
          value={formData.fieldOfWorkCode}
          onChange={handleChange}
          required
        />
        <input
          type="number"
          name="severalYearsOfExperience"
          placeholder="Years of Experience"
          value={formData.severalYearsOfExperience}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="descriptions"
          placeholder="Job Description"
          value={formData.descriptions}
          onChange={handleChange}
          required
        />
        <input
          type="number"
          name="salary"
          placeholder="Salary"
          value={formData.salary}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="companyName"
          placeholder="Company Name"
          value={formData.companyName}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="companyAddress"
          placeholder="Company Address"
          value={formData.companyAddress}
          onChange={handleChange}
          required
        />
        <button type="submit" className="btn btn-primary">Save</button>
        <button type="button" className="btn btn-secondary" onClick={onCancel}>Cancel</button>
      </form>
    </div>
  );
};

export default UpdateJobForm;
