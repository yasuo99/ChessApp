import { useEffect, useState } from 'react'
import '../../assets/css/playground.css'
import UpgradePawn from '../../components/upgrade/upgrade';
import { CHESS_PIECE, CHESS_SIDE } from './chessPiece';
import initBoard from './initBoard';


const PlayGround = ({ }) => {
    const defaultPiece = {
        label: '',
        x: -1,
        y: -1,
        type: CHESS_PIECE.EMPTY,
        image: null,
        side: CHESS_SIDE.BLACK,
        predictMove: []
    }
    const move = {
        x: 0,
        y: 0,
        type: CHESS_PIECE.EMPTY
    }
    const prepareMoveStep = {
        isChessSelected: false,
        isPositionSelected: false,
        positionSelected: { x: 0, y: 0 },
        isValidPosition: false
    }
    let boardInit = false;



    //Side of player - Black or white
    const [side, setSide] = useState(CHESS_SIDE.BLACK);

    const preInitBoard = side === CHESS_SIDE.BLACK ? initBoard.rows.reverse() : initBoard.rows;
    //Board init
    const [board, setBoard] = useState(initBoard.rows.reverse());

    //Chess piece selected
    const [selectedPiece, setSelectedPiece] = useState(defaultPiece)

    //Predict move
    const [predictMove, setPredictMove] = useState([]);

    //Check first move
    const [isFirstMove, setIsFirstMove] = useState(true);
    const [prepareMove, setPrepareMove] = useState(prepareMoveStep)
    const [isYourTurn, setIsYourTurn] = useState(true);

    const [history, setHistory] = useState([]);
    const [point, setPoint] = useState([])

    useEffect(() => {
        if (boardInit && selectedPiece !== null) {
            if (side === selectedPiece.side) {
                if (side === CHESS_SIDE.BLACK) {
                    calculateBlackMove();
                }
                else {
                    calculateWhiteMove();
                }
            }
        }
    }, [selectedPiece])
    useEffect(() => {
        if (prepareMove.isValidPosition && prepareMove.isChessSelected) {
            board[prepareMove.positionSelected.y][prepareMove.positionSelected.x].type = selectedPiece.type;
            board[prepareMove.positionSelected.y][prepareMove.positionSelected.x].image = selectedPiece.image;
            board[prepareMove.positionSelected.y][prepareMove.positionSelected.x].side = selectedPiece.side
            board[selectedPiece.y][selectedPiece.x].type = CHESS_PIECE.EMPTY;
            board[selectedPiece.y][selectedPiece.x].image = null;
            board[selectedPiece.y][selectedPiece.x].side = null;

            setBoard(board)
            setPrepareMove({
                isValidPosition: false,
                isChessSelected: false,
                isPositionSelected: false
            })
            setPredictMove([])
            setSelectedPiece(null)
            if (isFirstMove) {
                setIsFirstMove(false);
            }
        }
    }, [prepareMove])
    function movePiece() {
        setIsFirstMove(false);

    }
    function calculateWhiteMove() {
        const tempMove = []
        switch (selectedPiece.type) {
            case CHESS_PIECE.PAWN:
                if (selectedPiece.predictMove.length === 0) {
                    console.log('calculate');
                    if (selectedPiece.x < 7) {
                        const diagonalMoveRight = { x: selectedPiece.x + 1, y: selectedPiece.y + 1 };
                        if (board[selectedPiece.y + 1][selectedPiece.x + 1].type !== CHESS_PIECE.EMPTY) { // Attack right move white pawn
                            tempMove.push(diagonalMoveRight);
                        }
                    }
                    if (selectedPiece.x > 1) {
                        const diagonalMoveLeft = { x: selectedPiece.x - 1, y: selectedPiece.y + 1 }
                        if (board[selectedPiece.y + 1][selectedPiece.x - 1].type !== CHESS_PIECE.EMPTY) {
                            tempMove.push(diagonalMoveLeft);
                        }
                    }

                    tempMove.push()
                    if (isFirstMove) {
                        var twoStepsForward = { x: selectedPiece.x, y: selectedPiece.y + 2 }
                        var oneStepForward = { x: selectedPiece.x, y: selectedPiece.y + 1 }
                        tempMove.push(oneStepForward);
                        tempMove.push(twoStepsForward);

                    } else {
                        var oneStepForward = { x: selectedPiece.x, y: selectedPiece.y + 1 }
                        tempMove.push(oneStepForward);
                    }

                    setPredictMove([...tempMove])
                    board[selectedPiece.y][selectedPiece.x].predictMove = tempMove;
                    setBoard([...board])
                }
                else {
                    setPredictMove([...selectedPiece.predictMove])
                }


                break;
            case CHESS_PIECE.ROOK:
                break;
            case CHESS_PIECE.KNIGHT:
                break;
            case CHESS_PIECE.BISHOP:
                var isBlockChess = board.some(row => row.some(col => col.x === selectedPiece.x - 1 && col.y === selectedPiece.y - 1))
                console.log(isBlockChess);
                break;
            case CHESS_PIECE.QUEEN:
                break;
            case CHESS_PIECE.KING:
                break;
            default:
                break;
        }
    }
    function calculateBlackMove() {
        const tempMove = []
        switch (selectedPiece.type) {
            case CHESS_PIECE.PAWN:
                if (selectedPiece.predictMove.length === 0) {
                    console.log('clg');
                    console.log('calculate');
                    if (selectedPiece.x < 7) {
                        const diagonalMoveRight = { x: selectedPiece.x + 1, y: selectedPiece.y - 1 };
                        if (board[selectedPiece.y - 1][selectedPiece.x + 1].type !== CHESS_PIECE.EMPTY) { // Attack right move black pawn
                            tempMove.push(diagonalMoveRight);
                        }
                    }
                    if (selectedPiece.x > 1) {
                        const diagonalMoveLeft = { x: selectedPiece.x - 1, y: selectedPiece.y - 1 }
                        console.warn(board[selectedPiece.y - 1][selectedPiece.x - 1])
                        if (board[selectedPiece.y - 1][selectedPiece.x - 1].type !== CHESS_PIECE.EMPTY) { // Attack right move black pawn
                            tempMove.push(diagonalMoveLeft);
                        }
                    }
                    if (isFirstMove) {
                        var twoStepsForward = { x: selectedPiece.x, y: selectedPiece.side === CHESS_SIDE.BLACK ? selectedPiece.y - 2 : selectedPiece.y + 2 }
                        var oneStepForward = { x: selectedPiece.x, y: selectedPiece.side === CHESS_SIDE.BLACK ? selectedPiece.y - 1 : selectedPiece.y + 1 }
                        tempMove.push(oneStepForward);
                        tempMove.push(twoStepsForward);

                    } else {
                        var oneStepForward = { x: selectedPiece.x, y: selectedPiece.side === CHESS_SIDE.BLACK ? selectedPiece.y - 1 : selectedPiece.y + 1 }
                        tempMove.push(oneStepForward);
                    }

                    setPredictMove([...tempMove])
                    board[selectedPiece.y][selectedPiece.x].predictMove = tempMove;
                    setBoard([...board])
                }
                else {
                    setPredictMove([...selectedPiece.predictMove])
                }


                break;
            case CHESS_PIECE.ROOK:
                break;
            case CHESS_PIECE.KNIGHT:
                break;
            case CHESS_PIECE.BISHOP:
                if (selectedPiece.side === CHESS_SIDE.BLACK) {
                    var isBlockChess = board.some(row => row.some(col => col.x === selectedPiece.x - 1 && col.y === selectedPiece.y - 1))
                    console.log(isBlockChess);
                } else {

                }
                break;
            case CHESS_PIECE.QUEEN:
                break;
            case CHESS_PIECE.KING:
                break;
            default:
                break;
        }
    }
    function selectPiece(piece) {
        console.log(piece);
        if (isYourTurn) { // Check if it's your turn to play or not.
            if (piece.type !== CHESS_PIECE.EMPTY) {
                if (piece.side === side) {
                    setSelectedPiece(piece);
                    setPrepareMove({
                        ...prepareMove,
                        isChessSelected: true
                    });
                }
            } else {
                if (prepareMove.isChessSelected) {
                    switch (selectedPiece.type) {
                        case CHESS_PIECE.PAWN:
                            // if(side === CHESS_SIDE.BLACK){
                            //     if(piece.x > selectedPiece.x && piece.y > selectedPiece.y){
                            //         setPrepareMove({
                            //             ...prepareMove,
                            //             isValidPosition: false
                            //         });
                            //     }
                            // }
                            break;
                        case CHESS_PIECE.ROOK:
                            break;
                        default:
                            break;
                    }
                    if (predictMove.some(move => move.x === piece.x && move.y === piece.y)) {
                        setPrepareMove({
                            ...prepareMove,
                            isPositionSelected: true,
                            positionSelected: {
                                x: piece.x,
                                y: piece.y
                            },
                            isValidPosition: true
                        })
                    }

                }
            }
        }
    }
    const renderBoard = () => {
        boardInit = true;
        console.log(board);
        return (
            <div className="container border p-4">
                {board.map((row, idx) => {
                    return (
                        <div className="d-flex" key={idx}>
                            {row.map((col, colIdx) =>
                                <div onClick={() => selectPiece(col)} key={`${col.label}-${idx}`} className={`chess-position ${selectedPiece !== null && col.x === selectedPiece.x && col.y === selectedPiece.y ? 'active' : ''} text-center align-items-center border ${idx % 2 === 0 ? (colIdx % 2 === 0 ? 'white' : 'black') : (colIdx % 2 === 0 ? 'black' : 'white')} ${predictMove.some(move => move.x === col.x && move.y === col.y) ? 'predict' : ''}`}>
                                    <span className="text-white">{col.y} {col.x}</span>   
                                    {col.type !== CHESS_PIECE.EMPTY && <img key={col.label} className={`img-fluid chess-piece text-center ${selectedPiece !== null && col.x === selectedPiece.x && col.y === selectedPiece.y ? 'bounce' : ''}`} src={`/chess/${col.image}`}></img>}
                                </div>
                            )}
                        </div>
                    )
                })
                }
            </div>
        )
    }
    const upgradePawn = (newChess) => {
        console.log('clq', newChess);
    }
    return (
        <div>

            <div className="play-ground">
                <div className="center">
                    {renderBoard()}
                </div>

            </div>
            {/* <div className="mt-4">
                <UpgradePawn select={upgradePawn}></UpgradePawn>
            </div> */}
        </div>

    )
}
export default PlayGround