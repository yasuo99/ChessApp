import { CHESS_PIECE, CHESS_SIDE } from "./chessPiece";

const BLACK = 'black';
const WHITE = 'white';
export const BLACK_CHESS_PIECE = {
    KING: `${BLACK}-king.png`,
    QUEEN: `${BLACK}-queen.png`,
    BISHOP: `${BLACK}-bishop.png`,
    KNIGHT: `${BLACK}-knight.png`,
    ROOK: `${BLACK}-rook.png`,
    PAWN: `${BLACK}-pawn.png`

}
export const WHITE_CHESS_PIECE = {
    KING: `${WHITE}-king.png`,
    QUEEN: `${WHITE}-queen.png`,
    BISHOP: `${WHITE}-bishop.png`,
    KNIGHT: `${WHITE}-knight.png`,
    ROOK: `${WHITE}-rook.png`,
    PAWN: `${WHITE}-pawn.png`
}
const initBlack = [
    {
        label: 'A8',
        x: 0,
        y: 7,
        image: BLACK_CHESS_PIECE.ROOK,
        type: CHESS_PIECE.ROOK,
        side: CHESS_SIDE.BLACK
    },
    {
        label: 'B8',
        x: 1,
        y: 7,
        image: BLACK_CHESS_PIECE.KNIGHT,
        type: CHESS_PIECE.KNIGHT,
        side: CHESS_SIDE.BLACK
    },
    {
        label: 'C8',
        x: 2,
        y: 7,
        image: BLACK_CHESS_PIECE.BISHOP,
        type: CHESS_PIECE.BISHOP,
        side: CHESS_SIDE.BLACK
    },
    {
        label: 'D8',
        x: 3,
        y: 7,
        image: BLACK_CHESS_PIECE.QUEEN,
        type: CHESS_PIECE.QUEEN,
        side: CHESS_SIDE.BLACK
    },
    {
        label: 'E8',
        x: 4,
        y: 7,
        image: BLACK_CHESS_PIECE.KING,
        type: CHESS_PIECE.KING,
        side: CHESS_SIDE.BLACK
    },
    {
        label: 'F8',
        x: 5,
        y: 7,
        image: BLACK_CHESS_PIECE.BISHOP,
        type: CHESS_PIECE.BISHOP,
        side: CHESS_SIDE.BLACK
    },
    {
        label: 'G8',
        x: 6,
        y: 7,
        image: BLACK_CHESS_PIECE.KNIGHT,
        type: CHESS_PIECE.KNIGHT,
        side: CHESS_SIDE.BLACK
    },
    {
        label: 'H8',
        x: 7,
        y: 7,
        image: BLACK_CHESS_PIECE.ROOK,
        type: CHESS_PIECE.ROOK,
        side: CHESS_SIDE.BLACK
    },
]
const initWhite = [
    {
        label: 'A1',
        x: 0,
        y: 0,
        image: WHITE_CHESS_PIECE.ROOK,
        type: CHESS_PIECE.ROOK,
        side: CHESS_SIDE.WHITE
    },
    {
        label: 'B1',
        x: 1,
        y: 0,
        image: WHITE_CHESS_PIECE.KNIGHT,
        type: CHESS_PIECE.KNIGHT,
        side: CHESS_SIDE.WHITE
    },
    {
        label: 'C1',
        x: 2,
        y: 0,
        image: WHITE_CHESS_PIECE.BISHOP,
        type: CHESS_PIECE.BISHOP,
        side: CHESS_SIDE.WHITE
    },
    {
        label: 'D1',
        x: 3,
        y: 0,
        image: WHITE_CHESS_PIECE.QUEEN,
        type: CHESS_PIECE.QUEEN,
        side: CHESS_SIDE.WHITE
    },
    {
        label: 'E1',
        x: 4,
        y: 0,
        image: WHITE_CHESS_PIECE.KING,
        type: CHESS_PIECE.KING,
        side: CHESS_SIDE.WHITE
    },
    {
        label: 'F1',
        x: 5,
        y: 0,
        image: WHITE_CHESS_PIECE.BISHOP,
        type: CHESS_PIECE.BISHOP,
        side: CHESS_SIDE.WHITE
    },
    {
        label: 'G1',
        x: 6,
        y: 0,
        image: WHITE_CHESS_PIECE.KNIGHT,
        type: CHESS_PIECE.KNIGHT,
        side: CHESS_SIDE.WHITE
    },
    {
        label: 'H1',
        x: 7,
        y: 0,
        image: WHITE_CHESS_PIECE.ROOK,
        type: CHESS_PIECE.ROOK,
        side: CHESS_SIDE.WHITE
    },
]
const initBoard = {
    rows: []
}
const ALPHABET = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H']
const NUMERIC = [1, 2, 3, 4, 5, 6, 7, 8]
for (let y = 0; y < 8; y++) {
    var chess = []
    if (y === 0) {
        for (let x = 0; x < 8; x++) {
            chess.push(initWhite[x]);
        }
    }
    else if (y === 7) {
        for (let x = 0; x < 8; x++) {
            chess.push(initBlack[x])
        }
    }
    else if (y === 6) { // Initital pawn for black chess
        for (let x = 0; x < 8; x++) {
            const pawn = {
                label: `${ALPHABET[x]}${y}`,
                x: x,
                y: y,
                image: BLACK_CHESS_PIECE.PAWN,
                type: CHESS_PIECE.PAWN,
                side: CHESS_SIDE.BLACK
            }
            chess.push(pawn);
        }
    }
    else if (y === 1) {  // Initital pawn for white chess
        for (let x = 0; x < 8; x++) {
            const pawn = {
                label: `${ALPHABET[x]}${y}`,
                x: x,
                y: y,
                image: WHITE_CHESS_PIECE.PAWN,
                type: CHESS_PIECE.PAWN,
                side: CHESS_SIDE.WHITE
            }
            chess.push(pawn);
        }
    }
    else {
        for (let x = 0; x < 8; x++) {
            const empty = {
                label: `${ALPHABET[x]}${y}`,
                x: x,
                y: y,
                image: null,
                type: CHESS_PIECE.EMPTY
            }
            chess.push(empty)
        }

    }
    initBoard.rows.push(chess)
}
initBoard.rows.map((row, index) => {
    row.map((col,colIdx) => {
        col.predictMove = []
    })
})
export default initBoard;