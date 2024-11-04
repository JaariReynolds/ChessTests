using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class KingCheckTests
    {
        /// <summary>
        /// A king should not be in check on an empty board
        /// </summary>
        [Fact]
        public void WhiteKing_EmptyBoard_Unchecked()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.False(isKingInCheck);
        }

        /// <summary>
        /// A king should not be in check by a friendly piece
        /// </summary>
        [Fact]
        public void WhiteKing_FriendlyAttack_Unchecked()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new Rook(TeamColour.White, "e7"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.False(isKingInCheck);
        }

        /// <summary>
        /// A king should not be in check when a friendly piece is blocking a potential capture
        /// </summary>
        [Fact]
        public void WhiteKing_KingBlockedFromAttack_Unchecked()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e5"));
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "e7"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.False(isKingInCheck);
        }

        /// <summary>
        /// A king should be in check when threatened by an enemy rook
        /// </summary>
        [Fact]
        public void WhiteKing_RookThreat_Checked()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "e7"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.True(isKingInCheck);
        }

        /// <summary>
        /// A king should be in check when threatened by an enemy pawn
        /// </summary>
        [Fact]
        public void WhiteKing_PawnCheck_Checked()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d5"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.True(isKingInCheck);
        }

        /// <summary>
        /// A king should not be in check when in the move square of an enemy pawn
        /// </summary>
        [Fact]
        public void WhiteKing_PawnMoveSquare_Unchecked()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e5"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.False(isKingInCheck);
        }

        /// <summary>
        /// A king should be in check when threatened by an enemy bishop across the board
        /// </summary>
        [Fact]
        public void WhiteKing_BishopCrossBoard_Checked()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new King(TeamColour.White, "a8"));
            gameboard.Board.SetSquare(new Bishop(TeamColour.Black, "h1"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.True(isKingInCheck);
        }

        /// <summary>
        /// A king should be in check when multiple pieces are causing the check
        /// </summary>
        [Fact]
        public void WhiteKing_DoubleCheck_Checked()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "e7"));
            gameboard.Board.SetSquare(new Bishop(TeamColour.Black, "c6"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.True(isKingInCheck);
        }

        /// <summary>
        /// A king should be in check after a pawn promotion to a piece that opens a check opportunity
        /// </summary>
        [Fact]
        public void WhiteKing_PawnPromotionCheck_Checked()
        {
            var gameboard = new Gameboard();

            var enemy = new Pawn(TeamColour.Black, "e2");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(enemy);

            var isKingInCheckByPawn = gameboard.Board.IsKingInCheck(TeamColour.White);

            // pawn promotes to rook on e1, is now a threat to the king on e4
            var promoteToRook = new Action(enemy, "e1", ActionType.PawnPromoteRook);
            gameboard.PerformAction(promoteToRook);

            var isKingInCheckByRook = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.False(isKingInCheckByPawn);
            Assert.True(isKingInCheckByRook);
        }

        /// <summary>
        /// A king should be in check by an enemy piece once the piece in front moves
        /// </summary>
        [Fact]
        public void WhiteKing_DiscoveredCheck_Checked()
        {
            var gameboard = new Gameboard();

            var enemyKnight = new Knight(TeamColour.Black, "e7");

            // knight is blocking the queen from a check on white king
            gameboard.SwapTurns();
            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new Queen(TeamColour.Black, "e8"));
            gameboard.Board.SetSquare(enemyKnight);

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            // knight moves out of the way for queen to check king
            var knightMove = new Action(enemyKnight, "c6", ActionType.Move);
            gameboard.PerformAction(knightMove);

            var isKingNowInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.False(isKingInCheck);
            Assert.True(isKingNowInCheck);
        }


        /// <summary>
        /// Both kings should be checking eachother when placed diagonally from eachother
        /// </summary>
        [Fact]
        public void WhiteKing_BlackKing_DoubleChecked()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new King(TeamColour.Black, "d5"));

            var isWhiteInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);
            var isBlackInCheck = gameboard.Board.IsKingInCheck(TeamColour.Black);
            var bothInCheck = isWhiteInCheck && isBlackInCheck;

            Assert.True(bothInCheck);
        }

        /// <summary>
        /// A king should be in check after the opposing team captures the defending piece
        /// </summary>
        [Fact]
        public void WhiteKing_OpenedCheckAfterCapture_Checked()
        {
            var gameboard = new Gameboard();

            var enemyRook = new Rook(TeamColour.Black, "e7");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(new King(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e5"));
            gameboard.Board.SetSquare(enemyRook);

            var capturePawn = new Action(enemyRook, "e5", ActionType.Capture);
            gameboard.PerformAction(capturePawn);

            // rook now at e5, directly infront of king 

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            Assert.True(isKingInCheck);
        }

        /// <summary>
        /// A king should avoid the check by moving out of the capture squares of the rook
        /// </summary>
        [Fact]
        public void WhiteKing_AvoidingCheckByMove_Unchecked()
        {
            var gameboard = new Gameboard();

            var king = new King(TeamColour.White, "e4");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "e5"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            var movedOutOfCheck = new Action(king, "d4", ActionType.Move);
            gameboard.PerformAction(movedOutOfCheck);

            var isKingStillInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            // The king should be in check before the action, and out of check after the action
            Assert.True(isKingInCheck);
            Assert.False(isKingStillInCheck);
        }

        /// <summary>
        /// A king should avoid the check by capturing the piece threatening it
        /// </summary>
        [Fact]
        public void WhiteKing_AvoidingCheckByCapture_Unchecked()
        {
            var gameboard = new Gameboard();

            var king = new King(TeamColour.White, "e4");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "e5"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            var captureOutOfCheck = new Action(king, "e5", ActionType.Capture);
            gameboard.PerformAction(captureOutOfCheck);

            var isKingStillInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            // The king should be in check before the action, and out of check after the action
            Assert.True(isKingInCheck);
            Assert.False(isKingStillInCheck);
        }

        /// <summary>
        /// A king should still be in check when moving out of the check of one piece and into the check of another
        /// </summary>
        [Fact]
        public void WhiteKing_MovingIntoAnotherCheck_Checked()
        {
            var gameboard = new Gameboard();

            var king = new King(TeamColour.White, "e4");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "e7"));
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "d7"));

            var isKingInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);

            var moveIntoAnotherCheck = new Action(king, "d5", ActionType.Move);
            gameboard.PerformAction(moveIntoAnotherCheck);

            var isKingStillInCheck = gameboard.Board.IsKingInCheck(TeamColour.White);
            var stillInCheck = isKingInCheck && isKingStillInCheck;

            // The king should be in check before the action, and still in check after the action
            Assert.True(stillInCheck);
        }
    }
}
