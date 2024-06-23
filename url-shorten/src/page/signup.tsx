import React, { useState } from "react";
import Input from "../components/input";
import Button from "../components/button";
const customInputStyle = {
    width: '200px',
  };

const SignUp : React.FC = () => {
    const [userName, setUserName] = React.useState('');
    const [password, setPassword] = React.useState('');
    const [email, setEmail] = React.useState('');
    const handleOnUserNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUserName(event.target.value);
      };
      const handleOnPasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
      };
      const handleOnEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setEmail(event.target.value);
      };
      const submitSignup = () => {
        console.log(userName);
        console.log(password);
        console.log(email);
      };
    return (
        <div className="signup-container">
        <div className="signup-content">
            <h1>Login</h1>
            <Input name="User Name"  onChange={handleOnUserNameChange} customstyle={customInputStyle}/>
            <Input name="Password" onChange={handleOnPasswordChange} customstyle={customInputStyle}/>
            <Input name="Email" onChange={handleOnEmailChange} customstyle={customInputStyle}/>
            <Button name="Sign up"  onClick={submitSignup}></Button>
        </div>
    </div>
    )
}

export default SignUp;