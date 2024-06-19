import React from "react";
import './index.css';

interface SidebarProps {
    children: React.ReactNode;
  }
const Sidebar : React.FC<SidebarProps> = ({children}) => {
    return (
        <div className="sidebar">
            {children}
        </div>
    )
}

export default Sidebar;












