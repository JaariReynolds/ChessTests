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
            var bishop = new Bishop(TeamColour.White, "d5");

            gameboard.Board.SetSquare(bishop);

            var dict = gameboard.CalculateTeamActions(TeamColour.White);

            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

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
                new Action(bishop, "e6", ActionType.Move),
                new Action(bishop, "f7", ActionType.Move),
                new Action(bishop, "g8", ActionType.Move),
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
            var bishop = new Bishop(TeamColour.Black, "d4");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(bishop);

            var dict = gameboard.CalculateTeamActions(TeamColour.Black);
            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

            var expected = new List<Action>
            {
                new Action(bishop, "a1", ActionType.Move),
                new Action(bishop, "b2", ActionType.Move),
                new Action(bishop, "c3", ActionType.Move),
                new Action(bishop, "e5", ActionType.Move),
                new Action(bishop, "f6", ActionType.Move),
                new Action(bishop, "g7", ActionType.Move),
                new Action(bishop, "h8", ActionType.Move),
                new Action(bishop, "a7", ActionType.Move),
                new Action(bishop, "b6", ActionType.Move),
                new Action(bishop, "c5", ActionType.Move),
                new Action(bishop, "e3", ActionType.Move),
                new Action(bishop, "f2", ActionType.Move),
                new Action(bishop, "g1", ActionType.Move),
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
            var bishop = new Bishop(TeamColour.White, "d5");
            var friendlyPawn1 = new Pawn(TeamColour.White, "c6");

            gameboard.Board.SetSquare(bishop);
            gameboard.Board.SetSquare(friendlyPawn1);

            var dict = gameboard.CalculateTeamActions(TeamColour.White);
            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

            var expected = new List<Action>
            {
                new Action(bishop, "e4", ActionType.Move),
                new Action(bishop, "f3", ActionType.Move),
                new Action(bishop, "g2", ActionType.Move),
                new Action(bishop, "h1", ActionType.Move),
                new Action(bishop, "a2", ActionType.Move),
                new Action(bishop, "b3", ActionType.Move),
                new Action(bishop, "c4", ActionType.Move),
                new Action(bishop, "e6", ActionType.Move),
                new Action(bishop, "f7", ActionType.Move),
                new Action(bishop, "g8", ActionType.Move),
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

            var dict = gameboard.CalculateTeamActions(TeamColour.White);
            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

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
            var bishop = new Bishop(TeamColour.White, "d5");
            var friendlyPawn1 = new Pawn(TeamColour.White, "b3");

            gameboard.Board.SetSquare(bishop);
            gameboard.Board.SetSquare(friendlyPawn1);

            var dict = gameboard.CalculateTeamActions(TeamColour.White);
            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

            var expected = new List<Action>
            {
                new Action(bishop, "a8", ActionType.Move),
                new Action(bishop, "b7", ActionType.Move),
                new Action(bishop, "c6", ActionType.Move),
                new Action(bishop, "e4", ActionType.Move),
                new Action(bishop, "f3", ActionType.Move),
                new Action(bishop, "g2", ActionType.Move),
                new Action(bishop, "h1", ActionType.Move),
                new Action(bishop, "c4", ActionType.Move),
                new Action(bishop, "e6", ActionType.Move),
                new Action(bishop, "f7", ActionType.Move),
                new Action(bishop, "g8", ActionType.Move),
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
            var bishop = new Bishop(TeamColour.White, "d5");
            var friendlyPawn1 = new Pawn(TeamColour.White, "f3");

            gameboard.Board.SetSquare(bishop);
            gameboard.Board.SetSquare(friendlyPawn1);

            var dict = gameboard.CalculateTeamActions(TeamColour.White);
            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

            var expected = new List<Action>
            {
                new Action(bishop, "a8", ActionType.Move),
                new Action(bishop, "b7", ActionType.Move),
                new Action(bishop, "c6", ActionType.Move),
                new Action(bishop, "e4", ActionType.Move),
                new Action(bishop, "a2", ActionType.Move),
                new Action(bishop, "b3", ActionType.Move),
                new Action(bishop, "c4", ActionType.Move),
                new Action(bishop, "e6", ActionType.Move),
                new Action(bishop, "f7", ActionType.Move),
                new Action(bishop, "g8", ActionType.Move),
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
            var bishop = new Bishop(TeamColour.White, "d5");
            var enemyPawn = new Pawn(TeamColour.Black, "b7");

            gameboard.Board.SetSquare(bishop);
            gameboard.Board.SetSquare(enemyPawn);

            var dict = gameboard.CalculateTeamActions(TeamColour.White);
            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

            var expected = new List<Action>
            {
                new Action(bishop, "b7", ActionType.Capture),
                new Action(bishop, "c6", ActionType.Move),
                new Action(bishop, "e4", ActionType.Move),
                new Action(bishop, "f3", ActionType.Move),
                new Action(bishop, "g2", ActionType.Move),
                new Action(bishop, "h1", ActionType.Move),
                new Action(bishop, "a2", ActionType.Move),
                new Action(bishop, "b3", ActionType.Move),
                new Action(bishop, "c4", ActionType.Move),
                new Action(bishop, "e6", ActionType.Move),
                new Action(bishop, "f7", ActionType.Move),
                new Action(bishop, "g8", ActionType.Move),
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
            var bishop = new Bishop(TeamColour.White, "d5");
            var enemyKnight = new Knight(TeamColour.Black, "e6");

            gameboard.Board.SetSquare(bishop);
            gameboard.Board.SetSquare(enemyKnight);

            var dict = gameboard.CalculateTeamActions(TeamColour.White);
            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

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
                new Action(bishop, "e6", ActionType.Capture)
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
            var bishop = new Bishop(TeamColour.White, "d5");
            var enemyRook = new Rook(TeamColour.Black, "b3");

            gameboard.Board.SetSquare(bishop);
            gameboard.Board.SetSquare(enemyRook);

            var dict = gameboard.CalculateTeamActions(TeamColour.White);
            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

            var expected = new List<Action>
            {
                new Action(bishop, "a8", ActionType.Move),
                new Action(bishop, "b7", ActionType.Move),
                new Action(bishop, "c6", ActionType.Move),
                new Action(bishop, "e4", ActionType.Move),
                new Action(bishop, "f3", ActionType.Move),
                new Action(bishop, "g2", ActionType.Move),
                new Action(bishop, "h1", ActionType.Move),
                new Action(bishop, "b3", ActionType.Capture),
                new Action(bishop, "c4", ActionType.Move),
                new Action(bishop, "e6", ActionType.Move),
                new Action(bishop, "f7", ActionType.Move),
                new Action(bishop, "g8", ActionType.Move),
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
            var bishop = new Bishop(TeamColour.White, "d5");
            var enemyBishop = new Bishop(TeamColour.Black, "f3");

            gameboard.Board.SetSquare(bishop);
            gameboard.Board.SetSquare(enemyBishop);

            var dict = gameboard.CalculateTeamActions(TeamColour.White);
            var actual = new List<Action>();

            if (dict.TryGetValue(bishop, out var bishopActions))
                actual = bishopActions.OrderBy(a => a.ToString()).ToList();

            var expected = new List<Action>
            {
                new Action(bishop, "a8", ActionType.Move),
                new Action(bishop, "b7", ActionType.Move),
                new Action(bishop, "c6", ActionType.Move),
                new Action(bishop, "e4", ActionType.Move),
                new Action(bishop, "f3", ActionType.Capture),
                new Action(bishop, "a2", ActionType.Move),
                new Action(bishop, "b3", ActionType.Move),
                new Action(bishop, "c4", ActionType.Move),
                new Action(bishop, "e6", ActionType.Move),
                new Action(bishop, "f7", ActionType.Move),
                new Action(bishop, "g8", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }
    }
}
