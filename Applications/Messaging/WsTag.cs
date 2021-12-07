namespace ChessApp.Applications.Messaging
{
    public enum WsTag
    {
        Register,
        Login,
        GetLobbies,
        JoinLobby,
        StartMatch,
        InitBoard,
        MoveChess,
        UpgradePawn,
        Attack,
        Draw,
        DrawAccept,
        EndMatch
    }
}