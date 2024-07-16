using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class KingTests
    {
        [Fact]
        public void KingWhiteMove()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, 3, 3);

            gameboard.SetTestBoard(3, 3, king);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, 2, 2, ActionType.Move),
                new Action(king, 2, 3, ActionType.Move),
                new Action(king, 2, 4, ActionType.Move),
                new Action(king, 3, 2, ActionType.Move),
                new Action(king, 3, 4, ActionType.Move),
                new Action(king, 4, 2, ActionType.Move),
                new Action(king, 4, 3, ActionType.Move),
                new Action(king, 4, 4, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingBlackMove()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, 3, 3);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(3, 3, king);
            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action>
            {
                new Action(king, 2, 2, ActionType.Move),
                new Action(king, 2, 3, ActionType.Move),
                new Action(king, 2, 4, ActionType.Move),
                new Action(king, 3, 2, ActionType.Move),
                new Action(king, 3, 4, ActionType.Move),
                new Action(king, 4, 2, ActionType.Move),
                new Action(king, 4, 3, ActionType.Move),
                new Action(king, 4, 4, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteObstructionNorth()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, 3, 3);
            var friendlyPawn1 = new Pawn(TeamColour.White, 2, 2);
            var friendlyPawn2 = new Pawn(TeamColour.White, 2, 3);
            var friendlyPawn3 = new Pawn(TeamColour.White, 2, 4);

            gameboard.SetTestBoard(3, 3, king);
            gameboard.SetTestBoard(2, 2, friendlyPawn1);
            gameboard.SetTestBoard(2, 3, friendlyPawn2);
            gameboard.SetTestBoard(2, 4, friendlyPawn3);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, 3, 2, ActionType.Move),
                new Action(king, 3, 4, ActionType.Move),
                new Action(king, 4, 2, ActionType.Move),
                new Action(king, 4, 3, ActionType.Move),
                new Action(king, 4, 4, ActionType.Move),
                new Action(friendlyPawn1, 1, 2, ActionType.Move),
                new Action(friendlyPawn2, 1, 3, ActionType.Move),
                new Action(friendlyPawn3, 1, 4, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteObstructionSouth()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, 3, 3);
            var friendlyPawn1 = new Pawn(TeamColour.White, 4, 2);
            var friendlyPawn2 = new Pawn(TeamColour.White, 4, 3);
            var friendlyPawn3 = new Pawn(TeamColour.White, 4, 4);

            gameboard.SetTestBoard(3, 3, king);
            gameboard.SetTestBoard(4, 2, friendlyPawn1);
            gameboard.SetTestBoard(4, 3, friendlyPawn2);
            gameboard.SetTestBoard(4, 4, friendlyPawn3);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, 2, 2, ActionType.Move),
                new Action(king, 2, 3, ActionType.Move),
                new Action(king, 2, 4, ActionType.Move),
                new Action(king, 3, 2, ActionType.Move),
                new Action(king, 3, 4, ActionType.Move),
                new Action(friendlyPawn1, 3, 2, ActionType.Move),
                new Action(friendlyPawn3, 3, 4, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteObstructionEast()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, 3, 3);
            var friendlyPawn1 = new Pawn(TeamColour.White, 2, 4);
            var friendlyPawn2 = new Pawn(TeamColour.White, 3, 4);
            var friendlyPawn3 = new Pawn(TeamColour.White, 4, 4);

            gameboard.SetTestBoard(3, 3, king);
            gameboard.SetTestBoard(2, 4, friendlyPawn1);
            gameboard.SetTestBoard(3, 4, friendlyPawn2);
            gameboard.SetTestBoard(4, 4, friendlyPawn3);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, 2, 2, ActionType.Move),
                new Action(king, 2, 3, ActionType.Move),
                new Action(king, 3, 2, ActionType.Move),
                new Action(king, 4, 2, ActionType.Move),
                new Action(king, 4, 3, ActionType.Move),
                new Action(friendlyPawn1, 1, 4, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteObstructionWest()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, 3, 3);
            var friendlyPawn1 = new Pawn(TeamColour.White, 2, 2);
            var friendlyPawn2 = new Pawn(TeamColour.White, 3, 2);
            var friendlyPawn3 = new Pawn(TeamColour.White, 4, 2);

            gameboard.SetTestBoard(3, 3, king);
            gameboard.SetTestBoard(2, 2, friendlyPawn1);
            gameboard.SetTestBoard(3, 2, friendlyPawn2);
            gameboard.SetTestBoard(4, 2, friendlyPawn3);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, 2, 3, ActionType.Move),
                new Action(king, 2, 4, ActionType.Move),
                new Action(king, 3, 4, ActionType.Move),
                new Action(king, 4, 3, ActionType.Move),
                new Action(king, 4, 4, ActionType.Move),
                new Action(friendlyPawn1, 1, 2, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteCaptureNorth()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, 3, 3);
            var enemyPawn1 = new Pawn(TeamColour.Black, 2, 2);
            var enemyPawn2 = new Pawn(TeamColour.Black, 2, 3);
            var enemyPawn3 = new Pawn(TeamColour.Black, 2, 4);

            gameboard.SetTestBoard(3, 3, king);
            gameboard.SetTestBoard(2, 2, enemyPawn1);
            gameboard.SetTestBoard(2, 3, enemyPawn2);
            gameboard.SetTestBoard(2, 4, enemyPawn3);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, 3, 2, ActionType.Move),
                new Action(king, 3, 4, ActionType.Move),
                new Action(king, 4, 2, ActionType.Move),
                new Action(king, 4, 3, ActionType.Move),
                new Action(king, 4, 4, ActionType.Move),
                new Action(king, 2, 2, ActionType.Capture),
                new Action(king, 2, 3, ActionType.Capture),
                new Action(king, 2, 4, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteCaptureSouth()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, 3, 3);
            var enemyPawn1 = new Pawn(TeamColour.Black, 4, 2);
            var enemyPawn2 = new Pawn(TeamColour.Black, 4, 3);
            var enemyPawn3 = new Pawn(TeamColour.Black, 4, 4);

            gameboard.SetTestBoard(3, 3, king);
            gameboard.SetTestBoard(4, 2, enemyPawn1);
            gameboard.SetTestBoard(4, 3, enemyPawn2);
            gameboard.SetTestBoard(4, 4, enemyPawn3);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, 2, 2, ActionType.Move),
                new Action(king, 2, 3, ActionType.Move),
                new Action(king, 2, 4, ActionType.Move),
                new Action(king, 3, 2, ActionType.Move),
                new Action(king, 3, 4, ActionType.Move),
                new Action(king, 4, 2, ActionType.Capture),
                new Action(king, 4, 3, ActionType.Capture),
                new Action(king, 4, 4, ActionType.Capture)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteCaptureEast()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, 3, 3);
            var enemyPawn1 = new Pawn(TeamColour.Black, 2, 4);
            var enemyPawn2 = new Pawn(TeamColour.Black, 3, 4);
            var enemyPawn3 = new Pawn(TeamColour.Black, 4, 4);

            gameboard.SetTestBoard(3, 3, king);
            gameboard.SetTestBoard(2, 4, enemyPawn1);
            gameboard.SetTestBoard(3, 4, enemyPawn2);
            gameboard.SetTestBoard(4, 4, enemyPawn3);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, 2, 2, ActionType.Move),
                new Action(king, 2, 3, ActionType.Move),
                new Action(king, 3, 2, ActionType.Move),
                new Action(king, 4, 2, ActionType.Move),
                new Action(king, 4, 3, ActionType.Move),
                new Action(king, 2, 4, ActionType.Capture),
                new Action(king, 3, 4, ActionType.Capture),
                new Action(king, 4, 4, ActionType.Capture),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingWhiteCaptureWest()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, 3, 3);
            var enemyPawn1 = new Pawn(TeamColour.Black, 2, 2);
            var enemyPawn2 = new Pawn(TeamColour.Black, 3, 2);
            var enemyPawn3 = new Pawn(TeamColour.Black, 4, 2);

            gameboard.SetTestBoard(3, 3, king);
            gameboard.SetTestBoard(2, 2, enemyPawn1);
            gameboard.SetTestBoard(3, 2, enemyPawn2);
            gameboard.SetTestBoard(4, 2, enemyPawn3);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(king, 2, 3, ActionType.Move),
                new Action(king, 2, 4, ActionType.Move),
                new Action(king, 3, 4, ActionType.Move),
                new Action(king, 4, 3, ActionType.Move),
                new Action(king, 4, 4, ActionType.Move),
                new Action(king, 2, 2, ActionType.Capture),
                new Action(king, 3, 2, ActionType.Capture),
                new Action(king, 4, 2, ActionType.Capture),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }
    }
}