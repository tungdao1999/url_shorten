import React, { useState } from "react";
import Input from "../components/input";
import Button from "../components/button";
import api from "../api/api";
const customInputStyle = {
    width: '200px',
  };
  interface RegisterRequest {
    username: string;
    password: string;
    email: string;
  }
  interface Response {
    status: string;
    message: string;
  }

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
        const regiterRequest: RegisterRequest = {
            username: userName,
            password:  password,
            email: email,
        };
        api.postApiData('register', regiterRequest)
           .then((response: Response) => {
            // handle success
            // redirect to login page or home page
        })
        .catch((error: any) => {
            console.log(error.message)
        })
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