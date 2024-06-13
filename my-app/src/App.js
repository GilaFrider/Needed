import React from 'react';
import { Provider } from 'react-redux';
import { BrowserRouter as Router } from 'react-router-dom';
import store from './redux/store';
import NavBar from './components/NavBar';
import AppRoutes from './routes/AppRoutes';

const App = () => {
  return (
    <Provider store={store}>
      <Router>
        <div>
          <NavBar />
          <AppRoutes />
        </div>
      </Router>
    </Provider>
  );
};

export default App;
