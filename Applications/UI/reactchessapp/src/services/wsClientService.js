console.log(process.env.REACT_APP_WS_GAMESERVER);
export const WsGameClient = new WebSocket(process.env.REACT_APP_WS_GAMESERVER);