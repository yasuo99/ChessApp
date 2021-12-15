namespace ChessApp.Applications.Messaging
{
    public enum WsTag
    {
        Register,
        Login,
        GetLobbies,
        JoinLobby,
        CreateMatch,
        ChangeSide,
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