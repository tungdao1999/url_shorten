import React from "react";
import  './index.css'

interface ButtonProps {
    name: string;
    onClick?: React.MouseEventHandler
}

const Button: React.FC<ButtonProps> = ({ name, onClick,...props}) => {
    return <input className="submit" type="submit" value={name} onClick={onClick} {...props}></input>
}

export default Button;