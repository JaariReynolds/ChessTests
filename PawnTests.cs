using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class PawnTests
    {

        /// <summary>
        /// A white pawn can advance 1 or 2 squares as their first action
        /// </summary>
        [Fact]
        public void PawnWhiteFirstMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "a2");

            gameboard.Board.SetSquare(pawn);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(pawn, "a4", ActionType.PawnDoubleMove),
                new Action(pawn, "a3", ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A white pawn should not be able to advance 2 squares (or even 1) if the first is obstructed
        /// </summary>
        [Fact]
        public void PawnWhiteObstructedFirstMove()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "a2"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "a3"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            Assert.Empty(actual);
        }

        /// <summary>
        /// A white pawn can advance 1 square on its non-starting square
        /// </summary>
        [Fact]
        public void PawnWhiteRegularMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "b3");

            gameboard.Board.SetSquare(pawn);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);
            var expected = new List<Action> { new Action(pawn, "b4", ActionType.Move) };

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A white pawn should have no moves if their move squares are obstructed
        /// </summary>
        [Fact]
        public void PawnWhiteNoMove()
        {
            var gameboard = new Gameboard();

            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "b3"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "b4"));
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            Assert.Empty(actual);
        }

        /// <summary>
        /// A white pawn should be able to capture 1 diagonally forward on both sides
        /// </summary>
        [Fact]
        public void PawnWhiteCapture()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "c4");
            var blackPawn1 = new Pawn(TeamColour.Black, "b5");
            var blackPawn2 = new Pawn(TeamColour.Black, "d5");

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(blackPawn1);
            gameboard.Board.SetSquare(blackPawn2);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(pawn, "b5", ActionType.Capture),
                new Action(pawn, "d5", ActionType.Capture),
                new Action(pawn, "c5", ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A white pawn should not be able to capture friendly pieces
        /// </summary>
        [Fact]
        public void PawnWhiteFriendlyCapture()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "b4");
            var friendlyPawn1 = new Pawn(TeamColour.White, "a5");
            var friendlyPawn2 = new Pawn(TeamColour.White, "c5");

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(friendlyPawn1);
            gameboard.Board.SetSquare(friendlyPawn2);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action> {
                new Action(pawn, "b5", ActionType.Move ),
                new Action(friendlyPawn1, "a6", ActionType.Move),
                new Action(friendlyPawn2, "c6", ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A white pawn, when faced with 2 potential captures on the promote row, should be overwritten by PawnPromote actions
        /// </summary>
        [Fact]
        public void PawnWhitePromote()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "b7");
            var blackPawn1 = new Pawn(TeamColour.Black, "a8");
            var blackPawn2 = new Pawn(TeamColour.Black, "c8");

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(blackPawn1);
            gameboard.Board.SetSquare(blackPawn2);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action> {
                new Action(pawn, "a8", ActionType.PawnPromoteKnight),
                new Action(pawn, "a8", ActionType.PawnPromoteBishop),
                new Action(pawn, "a8", ActionType.PawnPromoteRook),
                new Action(pawn, "a8", ActionType.PawnPromoteQueen),
                new Action(pawn, "b8", ActionType.PawnPromoteKnight),
                new Action(pawn, "b8", ActionType.PawnPromoteBishop),
                new Action(pawn, "b8", ActionType.PawnPromoteRook),
                new Action(pawn, "b8", ActionType.PawnPromoteQueen),
                new Action(pawn, "c8", ActionType.PawnPromoteKnight),
                new Action(pawn, "c8", ActionType.PawnPromoteBishop),
                new Action(pawn, "c8", ActionType.PawnPromoteRook),
                new Action(pawn, "c8", ActionType.PawnPromoteQueen),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PawnWhiteEnPassant()
        {
            // not yet implemented as performing an action on a gameboard not yet implemented
            Assert.True(false);
        }
        /// <summary>
        /// A black pawn can advance 1 or 2 squares as their first action
        /// </summary>
        [Fact]
        public void PawnBlackFirstMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, "a7");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action> {
                new Action(pawn, "a6", ActionType.Move),
                new Action(pawn, "a5", ActionType.PawnDoubleMove)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A black pawn should not be able to advance 2 squares (or even 1) if the first is obstructed
        /// </summary>
        [Fact]
        public void PawnBlackObstructedFirstMove()
        {
            var gameboard = new Gameboard();

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "a7"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "a6"));

            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            Assert.Empty(actual);
        }

        /// <summary>
        /// A black pawn can advance 1 square on its non-starting square
        /// </summary>
        [Fact]
        public void PawnBlackRegularMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, "b3");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action> { new Action(pawn, "b2", ActionType.Move) };

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A black pawn should have no moves if their move squares are obstructed
        /// </summary>
        [Fact]
        public void PawnBlackNoMove()
        {
            var gameboard = new Gameboard();

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            Assert.Empty(actual);
        }

        /// <summary>
        /// A black pawn should be able to capture 1 diagonally on both sides
        /// </summary>
        [Fact]
        public void PawnBlackCapture()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, "f4");
            var whitePawn1 = new Pawn(TeamColour.White, "e3");
            var whitePawn2 = new Pawn(TeamColour.White, "g3");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(whitePawn1);
            gameboard.Board.SetSquare(whitePawn2);

            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action> {
                new Action(pawn, "e3", ActionType.Capture),
                new Action(pawn, "g3", ActionType.Capture),
                new Action(pawn, "f3", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A black pawn should not be able to capture friendly pieces
        /// </summary>
        [Fact]
        public void PawnBlackFriendlyCapture()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, "c5");
            var friendlyPawn1 = new Pawn(TeamColour.Black, "d4");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(friendlyPawn1);
            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action>
            {
                new Action(pawn, "c4", ActionType.Move),
                new Action(friendlyPawn1, "d3", ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A black pawn, when faced with 2 potential captures on the promote row, should be overwritten by PawnPromote actions
        /// </summary>
        [Fact]
        public void PawnBlackPromote()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, "g2");
            var blackPawn1 = new Pawn(TeamColour.White, "f1");
            var blackPawn2 = new Pawn(TeamColour.White, "h1");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(blackPawn1);
            gameboard.Board.SetSquare(blackPawn2);

            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action> {
                new Action(pawn, "f1", ActionType.PawnPromoteKnight),
                new Action(pawn, "f1", ActionType.PawnPromoteBishop),
                new Action(pawn, "f1", ActionType.PawnPromoteRook),
                new Action(pawn, "f1", ActionType.PawnPromoteQueen),
                new Action(pawn, "g1", ActionType.PawnPromoteKnight),
                new Action(pawn, "g1", ActionType.PawnPromoteBishop),
                new Action(pawn, "g1", ActionType.PawnPromoteRook),
                new Action(pawn, "g1", ActionType.PawnPromoteQueen),
                new Action(pawn, "h1", ActionType.PawnPromoteKnight),
                new Action(pawn, "h1", ActionType.PawnPromoteBishop),
                new Action(pawn, "h1", ActionType.PawnPromoteRook),
                new Action(pawn, "h1", ActionType.PawnPromoteQueen),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PawnBlackEnPassant()
        {
            // not yet implemented as performing an action on a gameboard not yet implemented
            Assert.True(false);
        }
    }
}