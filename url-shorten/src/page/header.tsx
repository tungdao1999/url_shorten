import { Link, useLocation } from 'react-router-dom';

function Header() {
  const location = useLocation();

  // Conditionally render the header based on the current route
  if (location.pathname === '/short' || location.pathname === '/contact') {
    return (
      <div className="topnav">
        <Link to="/short">Short</Link>
        <Link to="/contact">Contact</Link>
      </div>
    );
  }

  return null; // Return null to hide the header in other routes
}

export default Header;