using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class KnightTests
    {
        /// <summary>
        /// A knight should be able to move to all 8 unobstructed squares
        /// </summary>
        [Fact]
        public void KnightWhiteMoves()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, "d5");

            gameboard.Board.SetSquare(knight);

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(knight, "b6", ActionType.Move),
                new Action(knight, "b4", ActionType.Move),
                new Action(knight, "c7", ActionType.Move),
                new Action(knight, "e7", ActionType.Move),
                new Action(knight, "f6", ActionType.Move),
                new Action(knight, "f4", ActionType.Move),
                new Action(knight, "c3", ActionType.Move),
                new Action(knight, "e3", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A knight in the corner of the board should only be able to move to 2 squares
        /// </summary>
        [Fact]
        public void KnightWhiteCornerMoves()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, "a8");

            gameboard.Board.SetSquare(knight);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(knight, "c7", ActionType.Move),
                new Action(knight, "b6", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A knight should not be able to move on friendly pieces 
        /// </summary>
        [Fact]
        public void KnightWhiteFriendlyObstruction()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, "d6");

            gameboard.Board.SetSquare(knight);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c8"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e8"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == knight).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(knight, "b7", ActionType.Move),
                new Action(knight, "b5", ActionType.Move),
                new Action(knight, "c4", ActionType.Move),
                new Action(knight, "e4", ActionType.Move),
                new Action(knight, "f7", ActionType.Move),
                new Action(knight, "f5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A knight should be able to capture the 2 enemy pieces
        /// </summary>
        [Fact]
        public void KnightWhiteCapture()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, "d6");

            gameboard.Board.SetSquare(knight);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c8"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e8"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(knight, "c8", ActionType.Capture),
                new Action(knight, "e8", ActionType.Capture),
                new Action(knight, "b7", ActionType.Move),
                new Action(knight, "b5", ActionType.Move),
                new Action(knight, "c4", ActionType.Move),
                new Action(knight, "e4", ActionType.Move),
                new Action(knight, "f7", ActionType.Move),
                new Action(knight, "f5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A knight should be able to capture 2 enemy pieces, and be obstructed 2 moves by 2 friendly pieces
        /// </summary>
        [Fact]
        public void KnightWhiteCaptureAndObstruction()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, "d6");

            gameboard.Board.SetSquare(knight);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c8"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e8"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "b7"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "b5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == knight).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(knight, "b7", ActionType.Capture),
                new Action(knight, "b5", ActionType.Capture),
                new Action(knight, "c4", ActionType.Move),
                new Action(knight, "e4", ActionType.Move),
                new Action(knight, "f5", ActionType.Move),
                new Action(knight, "f7", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }
    }
}
