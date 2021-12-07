import React, { useEffect, useState } from 'react';
import { Navigate, useNavigate } from 'react-router-dom';
import '../../assets/css/home.css'
import AuthService from '../../services/authService';
const LoginPage = ({ }) => {
    const navigate = useNavigate();
    useEffect(() => {
        if (AuthService.isLoggedIn) {
            navigate('/lobby')
        }
    },[AuthService.isLoggedIn])
    
    const onLogin = () => {
        navigate('/lobby')
    }
    return (
        <div>
            <div className="bg-image blur-effect"></div>
            <div className="center">
                <div className="container card p-4">
                    <div className="card-body">
                        <h5 className="text-center">Login</h5>
                        <div className="form-group">
                            <label htmlFor="username">Username</label>
                            <input type="text"
                                className="form-control" name="" id="" aria-describedby="helpId" placeholder="" />
                            <small hidden id="helpId" className="form-text text-muted">Help text</small>
                        </div>
                        <div className="form-group">
                            <label htmlFor="password">Password</label>
                            <input type="text"
                                className="form-control" name="" id="" aria-describedby="helpId" placeholder="" />
                            <small id="helpId" className="form-text text-muted">Help text</small>
                        </div>
                        <div className="form-group">
                            <button onClick={() => onLogin()} className="btn btn-primary rounded form-control">Login</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default LoginPage;