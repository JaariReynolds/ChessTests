using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class KingBasicTests
    {
        [Fact]
        public void KingWhiteMove()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, "c5", ActionType.Move),
                new Action(king, "c6", ActionType.Move),
                new Action(king, "d6", ActionType.Move),
                new Action(king, "e6", ActionType.Move),
                new Action(king, "e5", ActionType.Move),
                new Action(king, "e4", ActionType.Move),
                new Action(king, "d4", ActionType.Move),
                new Action(king, "c4", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingBlackMove()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "d5");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(king);

            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action>
            {
                new Action(king, "c5", ActionType.Move),
                new Action(king, "c6", ActionType.Move),
                new Action(king, "d6", ActionType.Move),
                new Action(king, "e6", ActionType.Move),
                new Action(king, "e5", ActionType.Move),
                new Action(king, "e4", ActionType.Move),
                new Action(king, "d4", ActionType.Move),
                new Action(king, "c4", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteObstructionNorth()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White).Where(action => action.Piece == king);

            var expected = new List<Action>
            {
                new Action(king, "d6", ActionType.Move),
                new Action(king, "e6", ActionType.Move),
                new Action(king, "e5", ActionType.Move),
                new Action(king, "e4", ActionType.Move),
                new Action(king, "d4", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteObstructionSouth()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "d4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White).Where(action => action.Piece == king);

            var expected = new List<Action>
            {
                new Action(king, "c5", ActionType.Move),
                new Action(king, "c6", ActionType.Move),
                new Action(king, "d6", ActionType.Move),
                new Action(king, "e6", ActionType.Move),
                new Action(king, "e5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteObstructionEast()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White).Where(action => action.Piece == king);

            var expected = new List<Action>
            {
                new Action(king, "d6", ActionType.Move),
                new Action(king, "c6", ActionType.Move),
                new Action(king, "c5", ActionType.Move),
                new Action(king, "c4", ActionType.Move),
                new Action(king, "d4", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteObstructionWest()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White).Where(action => action.Piece == king);

            var expected = new List<Action>
            {
                new Action(king, "d6", ActionType.Move),
                new Action(king, "e6", ActionType.Move),
                new Action(king, "e5", ActionType.Move),
                new Action(king, "e4", ActionType.Move),
                new Action(king, "d4", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteCaptureNorth()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e6"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, "c4", ActionType.Move),
                new Action(king, "d4", ActionType.Move),
                new Action(king, "e4", ActionType.Move),
                new Action(king, "c6", ActionType.Capture),
                new Action(king, "d6", ActionType.Capture),
                new Action(king, "e6", ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteCaptureSouth()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e4"));
            ;
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, "c5", ActionType.Move),
                new Action(king, "c6", ActionType.Move),
                new Action(king, "d6", ActionType.Move),
                new Action(king, "e6", ActionType.Move),
                new Action(king, "e5", ActionType.Move),
                new Action(king, "e4", ActionType.Capture),
                new Action(king, "d4", ActionType.Capture),
                new Action(king, "c4", ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteCaptureEast()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, "d6", ActionType.Move),
                new Action(king, "c6", ActionType.Move),
                new Action(king, "c5", ActionType.Move),
                new Action(king, "c4", ActionType.Move),
                new Action(king, "e4", ActionType.Capture),
                new Action(king, "e5", ActionType.Capture),
                new Action(king, "e6", ActionType.Capture),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteCaptureWest()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, "c6", ActionType.Capture),
                new Action(king, "c5", ActionType.Capture),
                new Action(king, "c4", ActionType.Capture),
                new Action(king, "e4", ActionType.Move),
                new Action(king, "e5", ActionType.Move),
                new Action(king, "e6", ActionType.Move),
                new Action(king, "d6", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }
    }
}