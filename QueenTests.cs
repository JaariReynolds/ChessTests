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
            var queen = new Queen(TeamColour.White, 3, 3);

            gameboard.SetTestBoard(3, 3, queen);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenBlackMove()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.Black, 3, 3);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(3, 3, queen);
            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionNorth()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 2, 3);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(2, 3, friendlyPawn);

            var actual = gameboard.CalculateTeamActions(TeamColour.White).Where(action => action.Piece == queen);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionSouth()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 4, 3);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(4, 3, friendlyPawn);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 3, 4);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(3, 4, friendlyPawn);

            var actual = gameboard.CalculateTeamActions(TeamColour.White).Where(action => action.Piece == queen);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 3, 2);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(3, 2, friendlyPawn);

            var actual = gameboard.CalculateTeamActions(TeamColour.White).Where(action => action.Piece == queen);

            var expected = new List<Action>
            {
                 new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionNorthWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 2, 2);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(2, 2, friendlyPawn);

            var actual = gameboard.CalculateTeamActions(TeamColour.White).Where(action => action.Piece == queen);

            var expected = new List<Action>
            {
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionNorthEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 2, 4);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(2, 4, friendlyPawn);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(friendlyPawn, 1, 4, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionSouthWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 4, 2);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(4, 2, friendlyPawn);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(friendlyPawn, 3, 2, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionSouthEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 4, 4);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(4, 4, friendlyPawn);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(friendlyPawn, 3, 4, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureNorth()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var enemy = new Pawn(TeamColour.Black, 2, 3);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(2, 3, enemy);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureSouth()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var enemy = new Pawn(TeamColour.Black, 4, 3);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(4, 3, enemy);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var enemy = new Pawn(TeamColour.Black, 3, 4);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(3, 4, enemy);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var enemy = new Pawn(TeamColour.Black, 3, 2);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(3, 2, enemy);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                 new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureNorthWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var enemy = new Pawn(TeamColour.Black, 2, 2);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(2, 2, enemy);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureNorthEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var enemy = new Pawn(TeamColour.Black, 2, 4);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(2, 4, enemy);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureSouthWest()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var enemy = new Pawn(TeamColour.Black, 4, 2);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(4, 2, enemy);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Move),
                new Action(queen, 5, 5, ActionType.Move),
                new Action(queen, 6, 6, ActionType.Move),
                new Action(queen, 7, 7, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureSouthEast()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);
            var enemy = new Pawn(TeamColour.Black, 4, 4);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(4, 4, enemy);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 0, 0, ActionType.Move),
                new Action(queen, 1, 1, ActionType.Move),
                new Action(queen, 2, 2, ActionType.Move),
                new Action(queen, 6, 0, ActionType.Move),
                new Action(queen, 5, 1, ActionType.Move),
                new Action(queen, 4, 2, ActionType.Move),
                new Action(queen, 2, 4, ActionType.Move),
                new Action(queen, 1, 5, ActionType.Move),
                new Action(queen, 0, 6, ActionType.Move),
                new Action(queen, 3, 0, ActionType.Move),
                new Action(queen, 3, 1, ActionType.Move),
                new Action(queen, 3, 2, ActionType.Move),
                new Action(queen, 3, 4, ActionType.Move),
                new Action(queen, 3, 5, ActionType.Move),
                new Action(queen, 3, 6, ActionType.Move),
                new Action(queen, 3, 7, ActionType.Move),
                new Action(queen, 0, 3, ActionType.Move),
                new Action(queen, 1, 3, ActionType.Move),
                new Action(queen, 2, 3, ActionType.Move),
                new Action(queen, 4, 3, ActionType.Move),
                new Action(queen, 5, 3, ActionType.Move),
                new Action(queen, 6, 3, ActionType.Move),
                new Action(queen, 7, 3, ActionType.Move),
                new Action(queen, 4, 4, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteObstructionAll()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);

            var friendlyNW = new Pawn(TeamColour.White, 2, 2);
            var friendlyN = new Pawn(TeamColour.White, 2, 3);
            var friendlyNE = new Pawn(TeamColour.White, 2, 4);
            var friendlyW = new Pawn(TeamColour.White, 3, 2);
            var friendlyE = new Pawn(TeamColour.White, 3, 4);
            var friendlySW = new Pawn(TeamColour.White, 4, 2);
            var friendlyS = new Pawn(TeamColour.White, 4, 3);
            var friendlySE = new Pawn(TeamColour.White, 4, 4);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(2, 2, friendlyNW);
            gameboard.SetTestBoard(2, 3, friendlyN);
            gameboard.SetTestBoard(2, 4, friendlyNE);
            gameboard.SetTestBoard(3, 2, friendlyW);
            gameboard.SetTestBoard(3, 4, friendlyE);
            gameboard.SetTestBoard(4, 2, friendlySW);
            gameboard.SetTestBoard(4, 3, friendlyS);
            gameboard.SetTestBoard(4, 4, friendlySE);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(friendlyNW, 1, 2, ActionType.Move),
                new Action(friendlyN, 1, 3, ActionType.Move),
                new Action(friendlyNE, 1, 4, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenWhiteCaptureAll()
        {
            var gameboard = new Gameboard();
            var queen = new Queen(TeamColour.White, 3, 3);

            var enemyNW = new Pawn(TeamColour.Black, 2, 2);
            var enemyN = new Pawn(TeamColour.Black, 2, 3);
            var enemyNE = new Pawn(TeamColour.Black, 2, 4);
            var enemyW = new Pawn(TeamColour.Black, 3, 2);
            var enemyE = new Pawn(TeamColour.Black, 3, 4);
            var enemySW = new Pawn(TeamColour.Black, 4, 2);
            var enemyS = new Pawn(TeamColour.Black, 4, 3);
            var enemySE = new Pawn(TeamColour.Black, 4, 4);

            gameboard.SetTestBoard(3, 3, queen);
            gameboard.SetTestBoard(2, 2, enemyNW);
            gameboard.SetTestBoard(2, 3, enemyN);
            gameboard.SetTestBoard(2, 4, enemyNE);
            gameboard.SetTestBoard(3, 2, enemyW);
            gameboard.SetTestBoard(3, 4, enemyE);
            gameboard.SetTestBoard(4, 2, enemySW);
            gameboard.SetTestBoard(4, 3, enemyS);
            gameboard.SetTestBoard(4, 4, enemySE);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(queen, 2, 2, ActionType.Capture),
                new Action(queen, 2, 3, ActionType.Capture),
                new Action(queen, 2, 4, ActionType.Capture),
                new Action(queen, 3, 2, ActionType.Capture),
                new Action(queen, 3, 4, ActionType.Capture),
                new Action(queen, 4, 2, ActionType.Capture),
                new Action(queen, 4, 3, ActionType.Capture),
                new Action(queen, 4, 4, ActionType.Capture),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }
    }
}
