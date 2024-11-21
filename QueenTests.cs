using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class QueenTests
    {
        [Fact]
        public void QueenWhiteMove()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenBlackMove()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.Black, "d5");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(queen);

            var actual = gameboard.CalculateTeamActions(TeamColour.Black)
                .OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionNorth()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "d7"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionSouth()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "d4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "f5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionNorthWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c6"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionNorthEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "f7"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionSouthWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "b3"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionSouthEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureNorth()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d7"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d7", ActionType.Capture),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureSouth()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d2"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Capture),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "f5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Capture),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "c5", ActionType.Capture),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureNorthWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c6"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "c6", ActionType.Capture),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureNorthEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e6"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Capture),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureSouthWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Move),
                new Action(queen, "h1", ActionType.Move),
                new Action(queen, "c4", ActionType.Capture),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureSouthEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "g2"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "d8", ActionType.Move),
                new Action(queen, "d7", ActionType.Move),
                new Action(queen, "d6", ActionType.Move),
                new Action(queen, "d4", ActionType.Move),
                new Action(queen, "d3", ActionType.Move),
                new Action(queen, "d2", ActionType.Move),
                new Action(queen, "d1", ActionType.Move),
                new Action(queen, "a5", ActionType.Move),
                new Action(queen, "b5", ActionType.Move),
                new Action(queen, "c5", ActionType.Move),
                new Action(queen, "e5", ActionType.Move),
                new Action(queen, "f5", ActionType.Move),
                new Action(queen, "g5", ActionType.Move),
                new Action(queen, "h5", ActionType.Move),
                new Action(queen, "a8", ActionType.Move),
                new Action(queen, "b7", ActionType.Move),
                new Action(queen, "c6", ActionType.Move),
                new Action(queen, "e4", ActionType.Move),
                new Action(queen, "f3", ActionType.Move),
                new Action(queen, "g2", ActionType.Capture),
                new Action(queen, "a2", ActionType.Move),
                new Action(queen, "b3", ActionType.Move),
                new Action(queen, "c4", ActionType.Move),
                new Action(queen, "e6", ActionType.Move),
                new Action(queen, "f7", ActionType.Move),
                new Action(queen, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionAll()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "d6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "d4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen);

            Assert.Empty(actual);
        }

        [Fact]
        public void QueenWhiteCaptureAll()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, "d5");

            gameboard.Board.SetSquare(queen);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e6"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d4"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == queen).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(queen, "c5", ActionType.Capture),
                new Action(queen, "c6", ActionType.Capture),
                new Action(queen, "d6", ActionType.Capture),
                new Action(queen, "e6", ActionType.Capture),
                new Action(queen, "e5", ActionType.Capture),
                new Action(queen, "e4", ActionType.Capture),
                new Action(queen, "d4", ActionType.Capture),
                new Action(queen, "c4", ActionType.Capture),

            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }
    }
}
