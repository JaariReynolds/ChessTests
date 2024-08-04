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
        public void PerformAction_PawnMove()
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
        /// A DoubleMove should update the Pawn's square property to the action's provided square
        /// </summary>
        [Fact]
        public void PerformAction_PawnDoubleMove()
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
        /// A captured pawn should award 1 point to the capturing team
        /// </summary>
        [Fact]
        public void PerformAction_CapturePawn_PointsAwarded()
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
    }
}
