import React from 'react';
import { Link } from 'react-router-dom';

const NavBar = () => {
  return (
    <nav style={styles.navBar}>
      <ul style={styles.navList}>
        <li style={styles.navItem}>
          <Link to="/" style={styles.navLink}>Home</Link>
        </li>
        <li style={styles.navItem}>
          <Link to="/add-employer" style={styles.navLink}>Add Employer</Link>
        </li>
        <li style={styles.navItem}>
          <Link to="/dashboard" style={styles.navLink}>Add Job</Link>
        </li>
        <li style={styles.navItem}>
          <Link to="/login" style={styles.navLink}>Login</Link>
        </li>
      </ul>
    </nav>
  );
};

const styles = {
  navBar: {
    backgroundColor: '#333',
    padding: '1rem',
  },
  navList: {
    listStyleType: 'none',
    display: 'flex',
    justifyContent: 'space-around',
  },
  navItem: {
    margin: '0 1rem',
  },
  navLink: {
    color: '#fff',
    textDecoration: 'none',
    fontWeight: 'bold',
  },
};

export default NavBar;
