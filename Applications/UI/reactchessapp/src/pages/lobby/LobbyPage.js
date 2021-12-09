import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import '../../assets/css/home.css'
import '../../assets/css/lobby.css'
import {WsGameClient} from '../../services/wsClientService'
const LobbyPage = ({ }) => {
    const navigate = useNavigate();
    const searchLobby = (event) => {
        if (event.code === 'Enter') {
            console.log('User press enter');
        }
    }
    useEffect(() => {
        WsGameClient.onmessage = (event) => {
            console.log(event.data);
        }
    },[])
    return (
        <div>


            <div className="bg-image blur-effect">

            </div>
            <div className="center">
                <div className="container">
                    <div className="text-center">
                        <div className="input-group mb-3">
                            <input onKeyDown={(event) => searchLobby(event)} type="text" placeholder="Enter room Id" className="form-control"></input>
                            <div className="input-group-append">
                                <button className="btn btn-primary"><i className="fas fa-search"></i></button>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="lobby">
                    <div className="grid-items">
                        <div className='item'>
                            <div className="card">
                                <div className="card-body">
                                    <div className="card-background"></div>
                                    <h3>Room cua thanh</h3>
                                    <small>Winning Rate: 1.03</small>
                                    <br/>
                                    <button className="btn btn-success">Join</button>
                                </div>
                            </div>
                        </div>
                        <div className='item'>
                            <div className="card">
                                <div className="card-body">
                                    <div className="card-background"></div>
                                    <h3>Room cua thanh</h3>
                                    <button className="btn btn-success">Join</button>
                                </div>
                            </div>
                        </div>
                        <div className='item'>
                            <div className="card">
                                <div className="card-body">
                                    <div className="card-background"></div>
                                    <h3>Room cua thanh</h3>
                                    <button className="btn btn-success">Join</button>
                                </div>
                            </div>
                        </div>
                        <div className='item'>
                            <div className="card">
                                <div className="card-body">
                                    <div className="card-background"></div>
                                    <h3>Room cua thanh</h3>
                                    <button className="btn btn-success">Join</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default LobbyPage;