using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class PerformActionTests
    {


        /// <summary>
        /// A Move should update the Pawn's square property to the action's provided square
        /// </summary>
        [Fact]
        public void PerformAction_Move_Pawn()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "c4");
            var moveAction = new Action(pawn, "c5", ActionType.Move);

            gameboard.Board.SetSquare(pawn);

            // squares should not be equal before the action is performed, and equal after the action is performed

            Assert.NotEqual(pawn.Square, moveAction.Square);

            gameboard.PerformAction(moveAction);

            Assert.Equal(pawn.Square, moveAction.Square);
        }

        /// <summary>
        /// A piece should not be able to move to a non-empty square
        /// </summary>
        [Fact]
        public void PerformAction_Move_NonEmptySquare_Exception()
        {
            var gameboard = new Gameboard();

            var pawn = new Pawn(TeamColour.White, "c4");

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c5"));

            var moveAction = new Action(pawn, "c5", ActionType.Move);

            Assert.Throws<ArgumentException>(() => gameboard.PerformAction(moveAction));
        }

        /// <summary>
        /// Trying to perform a black team action when it is white's turn should not be legal
        /// </summary>
        [Fact]
        public void PerformAction_Move_WhiteTurn_BlackActionAttempt_Exception()
        {
            var gameboard = new Gameboard();

            var pawn = new Pawn(TeamColour.Black, "c4");

            gameboard.Board.SetSquare(pawn);

            var moveAction = new Action(pawn, "c3", ActionType.Move);

            Assert.Throws<ArgumentException>(() => gameboard.PerformAction(moveAction));
        }

        /// <summary>
        /// Trying to perform a white team action when it is black's turn should not be legal
        /// </summary>
        [Fact]
        public void PerformAction_Move_BlackTurn_WhiteActionAttempt_Exception()
        {
            var gameboard = new Gameboard();

            var pawn = new Pawn(TeamColour.White, "c4");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);

            var moveAction = new Action(pawn, "c3", ActionType.Move);

            Assert.Throws<ArgumentException>(() => gameboard.PerformAction(moveAction));
        }

        /// <summary>
        /// A DoubleMove should update the Pawn's square property to the action's provided square
        /// </summary>
        [Fact]
        public void PerformAction_PawnDoubleMove_Pawn()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "c3");
            var moveAction = new Action(pawn, "c5", ActionType.PawnDoubleMove);

            gameboard.Board.SetSquare(pawn);

            // squares should not be equal before the action is performed, and equal after the action is performed

            Assert.NotEqual(pawn.Square, moveAction.Square);

            gameboard.PerformAction(moveAction);

            Assert.Equal(pawn.Square, moveAction.Square);
        }

        /// <summary>
        /// A piece should not be able to capture a friendly piece
        /// </summary>
        [Fact]
        public void PerformAction_Capture_FriendlyRook_Exception()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d2");
            var captureRookAction = new Action(rook, "d6", ActionType.Capture);

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "d6"));

            Assert.Throws<ArgumentException>(() => gameboard.PerformAction(captureRookAction));
        }

        /// <summary>
        /// A captured pawn should award 1 point to the capturing team
        /// </summary>
        [Fact]
        public void PerformAction_Capture_Pawn_PointsAwarded()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d2");
            var capturePawnAction = new Action(rook, "d6", ActionType.Capture);

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d6"));

            gameboard.PerformAction(capturePawnAction);

            Assert.Equal(rook.Square, capturePawnAction.Square);
            Assert.Equal(1, gameboard.WhitePoints);
        }

        /// <summary>
        /// A captured bishop should award 3 points to the capturing team
        /// </summary>
        [Fact]
        public void PerformAction_Capture_Bishop_PointsAwarded()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d2");
            var captureBishopAction = new Action(rook, "d6", ActionType.Capture);

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Bishop(TeamColour.Black, "d6"));

            gameboard.PerformAction(captureBishopAction);

            Assert.Equal(rook.Square, captureBishopAction.Square);
            Assert.Equal(3, gameboard.WhitePoints);
        }

        /// <summary>
        /// A captured knight should award 3 points to the capturing team
        /// </summary>
        [Fact]
        public void PerformAction_Capture_Knight_PointsAwarded()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d2");
            var capturedKnightAction = new Action(rook, "d6", ActionType.Capture);

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Knight(TeamColour.Black, "d6"));

            gameboard.PerformAction(capturedKnightAction);

            Assert.Equal(rook.Square, capturedKnightAction.Square);
            Assert.Equal(3, gameboard.WhitePoints);
        }


        /// <summary>
        /// A captured rook should award 5 points to the capturing team
        /// </summary>
        [Fact]
        public void PerformAction_Capture_Rook_PointsAwarded()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d2");
            var captureRookAction = new Action(rook, "d6", ActionType.Capture);

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "d6"));

            gameboard.PerformAction(captureRookAction);

            Assert.Equal(rook.Square, captureRookAction.Square);
            Assert.Equal(5, gameboard.WhitePoints);
        }

        /// <summary>
        /// A captured queeen should award 9 points to the capturing team
        /// </summary>
        [Fact]
        public void PerformAction_Capture_Queen_PointsAwarded()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d2");
            var capturedQueenAction = new Action(rook, "d6", ActionType.Capture);

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Queen(TeamColour.Black, "d6"));

            gameboard.PerformAction(capturedQueenAction);

            Assert.Equal(rook.Square, capturedQueenAction.Square);
            Assert.Equal(9, gameboard.WhitePoints);
        }


    }
}
