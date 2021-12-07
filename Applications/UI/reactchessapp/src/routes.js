import React from "react";
import HomePage from "./pages/home/HomePage";
import LobbyPage from "./pages/lobby/LobbyPage";
import LoginPage from "./pages/login/LoginPage";
import PlayGround from "./pages/playground/PlayGround";
const routes = [
    {
        path: '/',
        exact: true,
        main: () => <HomePage></HomePage>,
        guard: false,
    },
    {
        path: '/login',
        exact: true,
        main: () => <LoginPage></LoginPage>,
        guard: false,
    },
    {
        path: '/lobby',
        exact: true,
        main: () => <LobbyPage></LobbyPage>,
        guard: false,
    },
    {
        path: '/play',
        exact: true,
        main: () => <PlayGround></PlayGround>,
        guard: false,
    }
]
export default routes;