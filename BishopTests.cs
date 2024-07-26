using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class BishopTests
    {
        /// <summary>
        /// A bishop should be able to move freely in any diagonal direction
        /// </summary>
        [Fact]
        public void BishopWhiteMove()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.White, 3, 3);

            gameboard.SetTestBoard(3, 3, bishop);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(bishop, 0, 0, ActionType.Move),
                new Action(bishop, 1, 1, ActionType.Move),
                new Action(bishop, 2, 2, ActionType.Move),
                new Action(bishop, 4, 4, ActionType.Move),
                new Action(bishop, 5, 5, ActionType.Move),
                new Action(bishop, 6, 6, ActionType.Move),
                new Action(bishop, 7, 7, ActionType.Move),
                new Action(bishop, 6, 0, ActionType.Move),
                new Action(bishop, 5, 1, ActionType.Move),
                new Action(bishop, 4, 2, ActionType.Move),
                new Action(bishop, 2, 4, ActionType.Move),
                new Action(bishop, 1, 5, ActionType.Move),
                new Action(bishop, 0, 6, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A bishop should be able to move freely in any diagonal direction
        /// </summary>
        [Fact]
        public void BishopBlackMove()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.Black, 4, 3);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(4, 3, bishop);
            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action>
            {
                new Action(bishop, 1, 0, ActionType.Move),
                new Action(bishop, 2, 1, ActionType.Move),
                new Action(bishop, 3, 2, ActionType.Move),
                new Action(bishop, 5, 4, ActionType.Move),
                new Action(bishop, 6, 5, ActionType.Move),
                new Action(bishop, 7, 6, ActionType.Move),
                new Action(bishop, 7, 0, ActionType.Move),
                new Action(bishop, 6, 1, ActionType.Move),
                new Action(bishop, 5, 2, ActionType.Move),
                new Action(bishop, 3, 4, ActionType.Move),
                new Action(bishop, 2, 5, ActionType.Move),
                new Action(bishop, 1, 6, ActionType.Move),
                new Action(bishop, 0, 7, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A bishop should not be able to move past a friendly piece (north west)
        /// </summary>
        [Fact]
        public void BishopObstructionNorthWest()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.White, 3, 3);
            var friendlyPawn1 = new Pawn(TeamColour.White, 2, 2);

            gameboard.SetTestBoard(3, 3, bishop);
            gameboard.SetTestBoard(2, 2, friendlyPawn1);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(bishop, 4, 4, ActionType.Move),
                new Action(bishop, 5, 5, ActionType.Move),
                new Action(bishop, 6, 6, ActionType.Move),
                new Action(bishop, 7, 7, ActionType.Move),
                new Action(bishop, 2, 4, ActionType.Move),
                new Action(bishop, 1, 5, ActionType.Move),
                new Action(bishop, 0, 6, ActionType.Move),
                new Action(bishop, 4, 2, ActionType.Move),
                new Action(bishop, 5, 1, ActionType.Move),
                new Action(bishop, 6, 0, ActionType.Move),
                new Action(friendlyPawn1, 1, 2, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A bishop should not be able to move past a friendly piece (north east)
        /// </summary>
        [Fact]
        public void BishopObstructionNorthEast()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.White, "d5");
            var friendlyPawn1 = new Pawn(TeamColour.White, "e6");

            gameboard.Board.SetSquare(bishop);
            gameboard.Board.SetSquare(friendlyPawn1);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(bishop, "a8", ActionType.Move),
                new Action(bishop, "b7", ActionType.Move),
                new Action(bishop, "c6", ActionType.Move),
                new Action(bishop, "e4", ActionType.Move),
                new Action(bishop, "f3", ActionType.Move),
                new Action(bishop, "g2", ActionType.Move),
                new Action(bishop, "h1", ActionType.Move),
                new Action(bishop, "a2", ActionType.Move),
                new Action(bishop, "b3", ActionType.Move),
                new Action(bishop, "c4", ActionType.Move),
                new Action(friendlyPawn1, "e7", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A bishop should not be able to move past a friendly piece (south west)
        /// </summary>
        [Fact]
        public void BishopObstructionSouthWest()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.White, 3, 3);
            var friendlyPawn1 = new Pawn(TeamColour.White, 5, 1);
            var friendlyPawn2 = new Pawn(TeamColour.White, 4, 2);

            gameboard.SetTestBoard(3, 3, bishop);
            gameboard.SetTestBoard(5, 1, friendlyPawn1);
            gameboard.SetTestBoard(4, 2, friendlyPawn2);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(bishop, 2, 2, ActionType.Move),
                new Action(bishop, 1, 1, ActionType.Move),
                new Action(bishop, 0, 0, ActionType.Move),
                new Action(bishop, 4, 4, ActionType.Move),
                new Action(bishop, 5, 5, ActionType.Move),
                new Action(bishop, 6, 6, ActionType.Move),
                new Action(bishop, 7, 7, ActionType.Move),
                new Action(bishop, 2, 4, ActionType.Move),
                new Action(bishop, 1, 5, ActionType.Move),
                new Action(bishop, 0, 6, ActionType.Move),
                new Action(friendlyPawn2, 3, 2, ActionType.Move),
                new Action(friendlyPawn1, 4, 1, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A bishop should not be able to move past a friendly piece (south east)
        /// </summary>
        [Fact]
        public void BishopObstructionSouthEast()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.White, 3, 3);
            var friendlyPawn1 = new Pawn(TeamColour.White, 6, 6);

            gameboard.SetTestBoard(3, 3, bishop);
            gameboard.SetTestBoard(6, 6, friendlyPawn1);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(bishop, 2, 2, ActionType.Move),
                new Action(bishop, 1, 1, ActionType.Move),
                new Action(bishop, 0, 0, ActionType.Move),
                new Action(bishop, 4, 4, ActionType.Move),
                new Action(bishop, 5, 5, ActionType.Move),
                new Action(bishop, 2, 4, ActionType.Move),
                new Action(bishop, 1, 5, ActionType.Move),
                new Action(bishop, 0, 6, ActionType.Move),
                new Action(bishop, 4, 2, ActionType.Move),
                new Action(bishop, 5, 1, ActionType.Move),
                new Action(bishop, 6, 0, ActionType.Move),
                new Action(friendlyPawn1, 5, 6, ActionType.Move),
                new Action(friendlyPawn1, 4, 6, ActionType.PawnDoubleMove),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A bishop should be able to capture an enemy piece and not move past it (north west)
        /// </summary>
        [Fact]
        public void BishopCaptureNorthWest()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.White, 3, 3);
            var enemyPawn = new Pawn(TeamColour.Black, 1, 1);

            gameboard.SetTestBoard(3, 3, bishop);
            gameboard.SetTestBoard(1, 1, enemyPawn);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(bishop, 2, 2, ActionType.Move),
                new Action(bishop, 1, 1, ActionType.Capture),
                new Action(bishop, 4, 4, ActionType.Move),
                new Action(bishop, 5, 5, ActionType.Move),
                new Action(bishop, 6, 6, ActionType.Move),
                new Action(bishop, 7, 7, ActionType.Move),
                new Action(bishop, 6, 0, ActionType.Move),
                new Action(bishop, 5, 1, ActionType.Move),
                new Action(bishop, 4, 2, ActionType.Move),
                new Action(bishop, 2, 4, ActionType.Move),
                new Action(bishop, 1, 5, ActionType.Move),
                new Action(bishop, 0, 6, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A bishop should be able to capture an enemy piece and not move past it (north east)
        /// </summary>
        [Fact]
        public void BishopCaptureNorthEast()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.White, 3, 3);
            var enemyKnight = new Knight(TeamColour.Black, 2, 4);

            gameboard.SetTestBoard(3, 3, bishop);
            gameboard.SetTestBoard(2, 4, enemyKnight);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(bishop, 2, 2, ActionType.Move),
                new Action(bishop, 1, 1, ActionType.Move),
                new Action(bishop, 0, 0, ActionType.Move),
                new Action(bishop, 4, 4, ActionType.Move),
                new Action(bishop, 5, 5, ActionType.Move),
                new Action(bishop, 6, 6, ActionType.Move),
                new Action(bishop, 7, 7, ActionType.Move),
                new Action(bishop, 6, 0, ActionType.Move),
                new Action(bishop, 5, 1, ActionType.Move),
                new Action(bishop, 4, 2, ActionType.Move),
                new Action(bishop, 2, 4, ActionType.Capture),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A bishop should be able to capture an enemy piece and not move past it (south west)
        /// </summary>
        [Fact]
        public void BishopCaptureSouthWest()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.White, 3, 3);
            var enemyRook = new Rook(TeamColour.Black, 6, 0);

            gameboard.SetTestBoard(3, 3, bishop);
            gameboard.SetTestBoard(6, 0, enemyRook);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(bishop, 2, 2, ActionType.Move),
                new Action(bishop, 1, 1, ActionType.Move),
                new Action(bishop, 0, 0, ActionType.Move),
                new Action(bishop, 4, 4, ActionType.Move),
                new Action(bishop, 5, 5, ActionType.Move),
                new Action(bishop, 6, 6, ActionType.Move),
                new Action(bishop, 7, 7, ActionType.Move),
                new Action(bishop, 6, 0, ActionType.Capture),
                new Action(bishop, 5, 1, ActionType.Move),
                new Action(bishop, 4, 2, ActionType.Move),
                new Action(bishop, 2, 4, ActionType.Move),
                new Action(bishop, 1, 5, ActionType.Move),
                new Action(bishop, 0, 6, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A bishop should be able to capture an enemy piece and not move past it (south east)
        /// </summary>
        [Fact]
        public void BishopCaptureSouthEast()
        {
            var gameboard = new Gameboard();
            var bishop = new Bishop(TeamColour.White, 3, 3);
            var enemyBishop = new Bishop(TeamColour.Black, 5, 5);

            gameboard.SetTestBoard(3, 3, bishop);
            gameboard.SetTestBoard(5, 5, enemyBishop);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(bishop, 2, 2, ActionType.Move),
                new Action(bishop, 1, 1, ActionType.Move),
                new Action(bishop, 0, 0, ActionType.Move),
                new Action(bishop, 4, 4, ActionType.Move),
                new Action(bishop, 5, 5, ActionType.Capture),
                new Action(bishop, 6, 0, ActionType.Move),
                new Action(bishop, 5, 1, ActionType.Move),
                new Action(bishop, 4, 2, ActionType.Move),
                new Action(bishop, 2, 4, ActionType.Move),
                new Action(bishop, 1, 5, ActionType.Move),
                new Action(bishop, 0, 6, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }
    }
}
