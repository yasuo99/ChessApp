export const CHESS_PIECE = {
    EMPTY: 0,
    PAWN: 1,
    BISHOP: 2,
    KNIGHT: 3,
    ROOK: 4,
    QUEEN: 5,
    KING: 6
}
export const CHESS_SIDE = {
    BLACK: 'BLACK',
    WHITE: 'WHITE'
}

export const ROOK_MOVE = [
    {
        x: 8,
        y: 0
    },
    {
        x: -8,
        y: 0
    },
    {
        x: 0,
        y: -8
    },
    {
        x: 0,
        y: 8
    }
]

export const KNIGHT_MOVE = [
    {
        x: 1, //First top right
        y: -2 
    },
    {
        x: -1, //First top left
        y: -2
    },
    {
        x: 2, //Second top right
        y: -1
    },
    {
        x: -2, //Second top left
        y: -1
    },
    {
        x: 2,
        y: 1
    },
    {
        x: -2,
        y: 1
    },
    {
        x:1,
        y: 2
    },
    {
        x: -1,
        y: 2
    }
]