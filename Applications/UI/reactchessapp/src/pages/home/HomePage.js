import { useState } from "react";
import { Link } from "react-router-dom";
import '../../assets/css/home.css';
const HomePage = () => {

    return (
        <div>
            <div className="bg-image blur-effect-sm"></div>
            <div className="center">
                <div className="text-center">
                    <h1>Online chess</h1>
                    <p>Current online: 1000</p>
                </div>
                <div className="d-flex justify-content-center">
                    <Link to="/login"  className="btn btn-primary rounded">Play now!</Link>
                </div>

            </div>
        </div>
    )
}
export default HomePage;