import { BrowserRouter as Router, Route, Routes, Link, useLocation, Navigate } from 'react-router-dom';
import Short from './page/short';
import Contact from './page/contact';

import './App.css'
import HandleRedirect from './redirect';

function RequireAuth({ children }: { children: JSX.Element }) {
  let location = useLocation();

  if (1 !== 1) {
    return <Navigate to="/login" state={{ from: location }} />;
  }

  return children;
}
function App() {
  return (
    <Router>
      <div>
        <div className="topnav">
          <Link to="/short">Short</Link>
          <Link to="/contact">Contact</Link>
        </div>
        <div className='main-container'>
          <Routes>
            <Route path="/short"
              element={
                <RequireAuth>
                  <Short />
                </RequireAuth>
              }
            >
            </Route>
            <Route path="/:hash"
              element={
                <RequireAuth>
                  <HandleRedirect/>
                </RequireAuth>
              }
            >
            </Route>
            <Route path="/contact"
              element={
                <RequireAuth>
                  <Contact />
                </RequireAuth>
              }
            >
            </Route>
          </Routes>
        </div>
      </div>
    </Router>
  );
}

export default App;