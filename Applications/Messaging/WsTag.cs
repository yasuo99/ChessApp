namespace ChessApp.Applications.Messaging
{
    public enum WsTag
    {
        Register,
        Login,
        GetLobbies,
        JoinLobby,
        CreateMatch,
        CancelMatch,
        StartMatch,
        InitBoard,
        MoveChess,
        UpgradePawn,
        Attack,
        Draw,
        DrawAccept,
        EndMatch,
        PauseMatch
    }
}