import React  from "react";
import Input from "../components/input";
import Button from "../components/button";

const customInputStyle = {
    width: '200px',
  };
const Login : React.FC = () => {
    return (
        <div className="login-container">
            <div className="login-content">
                <h1>Login</h1>
                <Input name="User Name" customstyle={customInputStyle}/>
                <Input name="Password" customstyle={customInputStyle}/>
                <Button name="Login"></Button>
            </div>
        </div>
    )
}

export default Login;