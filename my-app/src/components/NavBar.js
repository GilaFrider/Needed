import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useSelector } from 'react-redux';

const NavBar = () => {
 // const { isAuthenticated, role } = useSelector(state => state.auth);
  const navigate = useNavigate();

  const handleLogout = () => {
   
  };

  return (
    <nav style={styles.navBar}>
      <ul style={styles.navList}>
        <li style={styles.navItem}>
          <Link to="/" style={styles.navLink}>Home</Link>
        </li>
          <li style={styles.navItem}>
            <Link to="/dashboard" style={styles.navLink}>Add Job</Link>
          </li>
        
            <li style={styles.navItem}>
              <Link to="/login" style={styles.navLink}>Login</Link>
            </li>
      
          <li style={styles.navItem} onClick={handleLogout}>
            <Link style={styles.navLink}>Logout</Link>
              
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
    cursor: 'pointer', // Change cursor to pointer for button-like behavior
  },
};

export default NavBar;
