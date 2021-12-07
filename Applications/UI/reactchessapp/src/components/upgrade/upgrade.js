import '../../assets/css/board.css'
import { CHESS_PIECE, CHESS_SIDE } from '../../pages/playground/chessPiece';
import { BLACK_CHESS_PIECE, WHITE_CHESS_PIECE } from '../../pages/playground/initBoard';
const UpgradePawn = ({ side, select }) => {
    const selectUpgrage = (newPiece) => {
        select(newPiece)
    }
    return (
        <div className="container" style={{zIndex: 100}}>
            <div className='d-flex justify-content-center'>
                <div className="row upgrade-row">
                    <div onClick={() => selectUpgrage(CHESS_PIECE.ROOK)} className="col mini-card shadow-sm">
                        <img src={`/chess/${side === CHESS_SIDE.BLACK ? BLACK_CHESS_PIECE.ROOK : WHITE_CHESS_PIECE.ROOK}`}></img>
                    </div>
                    <div onClick={() => selectUpgrage(CHESS_PIECE.KNIGHT)} className="col mini-card shadow-sm">
                        <img src={`/chess/${side === CHESS_SIDE.BLACK ? BLACK_CHESS_PIECE.KNIGHT : WHITE_CHESS_PIECE.KNIGHT}`}></img>
                    </div>
                    <div onClick={() => selectUpgrage(CHESS_PIECE.BISHOP)} className="col mini-card shadow-sm">
                        <img src={`/chess/${side === CHESS_SIDE.BLACK ? BLACK_CHESS_PIECE.BISHOP : WHITE_CHESS_PIECE.BISHOP}`}></img>
                    </div>
                    <div onClick={() => selectUpgrage(CHESS_PIECE.QUEEN)} className="col mini-card shadow-sm">
                        <img src={`/chess/${side === CHESS_SIDE.BLACK ? BLACK_CHESS_PIECE.QUEEN : WHITE_CHESS_PIECE.QUEEN}`}></img>
                    </div>
                </div>
            </div>

        </div>
    )
}
export default UpgradePawn;