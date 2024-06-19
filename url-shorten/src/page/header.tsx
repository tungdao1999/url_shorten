import { Link, useLocation } from 'react-router-dom';
import Sidebar from '../components/sidebar';
import React, { useState } from 'react';
import Login from './login';
import SignUp from './signup';
import Button from '../components/button';

const Header : React.FC = () => {
  const location = useLocation();
  const [showLogin, setShowLogin] = React.useState(false);
  const [showSignUp, setShowSignUp] = React.useState(false);

  // Conditionally render the header based on the current route
  if (location.pathname === '/short' || location.pathname === '/contact') {
    return (
      <>
      <div className="topnav">
        <Link to="/short">Short</Link>
        <Link to="/contact">Contact</Link>
        <Button name="Sign In" onClick={() => setShowSignUp(!showSignUp)}></Button>
        <Button name="Log In" onClick={() => setShowLogin(!showLogin)}></Button>
      </div>
      {showLogin && <Sidebar><Login /></Sidebar>}
      {showSignUp && <Sidebar><SignUp /></Sidebar>}
      </>
    );
  }

  return null; // Return null to hide the header in other routes
}

export default Header;