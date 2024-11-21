using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;
using ChessLogic.Classes;

namespace ChessTests
{
    public class PawnTests
    {

        // Setup before some Pawn tests required as GameStateManager is a single instance that should not carry over into other tests 
        public PawnTests()
        {
            GameStateManager.Instance.Reset();
        }

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

            var pawn = new Pawn(TeamColour.White, "a2");

            gameboard.Board.SetSquare(pawn);
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
            var pawn = new Pawn(TeamColour.White, "b3");

            gameboard.Board.SetSquare(pawn);
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

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "b5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .OrderBy(a => a.ToString());

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

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "a5"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "c5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == pawn);

            var expected = new List<Action> {
                new Action(pawn, "b5", ActionType.Move),
            };

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

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "a8"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "c8"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .OrderBy(a => a.ToString());
            ;

            var expected = new List<Action> {
                new Action(pawn, "a8", ActionType.PawnPromoteKnight, pawn.PieceValue),
                new Action(pawn, "a8", ActionType.PawnPromoteBishop, pawn.PieceValue),
                new Action(pawn, "a8", ActionType.PawnPromoteRook, pawn.PieceValue),
                new Action(pawn, "a8", ActionType.PawnPromoteQueen, pawn.PieceValue),
                new Action(pawn, "b8", ActionType.PawnPromoteKnight),
                new Action(pawn, "b8", ActionType.PawnPromoteBishop),
                new Action(pawn, "b8", ActionType.PawnPromoteRook),
                new Action(pawn, "b8", ActionType.PawnPromoteQueen),
                new Action(pawn, "c8", ActionType.PawnPromoteKnight, pawn.PieceValue),
                new Action(pawn, "c8", ActionType.PawnPromoteBishop, pawn.PieceValue),
                new Action(pawn, "c8", ActionType.PawnPromoteRook, pawn.PieceValue),
                new Action(pawn, "c8", ActionType.PawnPromoteQueen, pawn.PieceValue),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A white pawn can en passant capture an enemy pawn if they had just double moved out of square they would have otherwise been capturable from
        /// </summary>
        [Fact]
        public void PawnWhiteEnPassant()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "f5");
            var enemyPawn = new Pawn(TeamColour.Black, "e5");
            var previousAction = new Action(enemyPawn, "e5", ActionType.PawnDoubleMove);

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(enemyPawn);
            gameboard.AddActionToHistory(previousAction);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(pawn, "f6", ActionType.Move),
                new Action(pawn, "e6", ActionType.PawnEnPassant)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A white pawn should not be able to en passant capture an enemy pawn if the previous action was not a double move from that pawn
        /// </summary>
        [Fact]
        public void PawnWhiteEnPassantNotAvailable1()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "f5");

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "e5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action> { new Action(pawn, "f6", ActionType.Move) };

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A white pawn should not be able to en passant capture an enemy pawn (in the correct en passant position) if a DIFFERENT enemy pawn performed the double move
        /// </summary>
        [Fact]
        public void PawnWhiteEnPassantNotAvailable2()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "b5");
            var enemyPawn1 = new Pawn(TeamColour.Black, "a5");
            var enemyPawn2 = new Pawn(TeamColour.Black, "g5");
            var previousAction = new Action(enemyPawn2, "g5", ActionType.PawnDoubleMove);

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(enemyPawn1);
            gameboard.Board.SetSquare(enemyPawn2);
            gameboard.AddActionToHistory(previousAction);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action> { new Action(pawn, "b6", ActionType.Move) };

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A white pawn should not be able to en passant capture an enemy pawn outside of the double move zone (even if the previous action was somehow a double move - (not legal))
        /// </summary>
        [Fact]
        public void PawnWhiteEnPassantNotAvailable3()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, "e4");
            var enemyPawn = new Pawn(TeamColour.Black, "d4");
            var previousAction = new Action(enemyPawn, "d4", ActionType.PawnDoubleMove);

            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(enemyPawn);
            gameboard.AddActionToHistory(previousAction);

            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action> { new Action(pawn, "e5", ActionType.Move) };

            Assert.Equal(expected, actual);
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

            var actual = gameboard.CalculateTeamActions(TeamColour.Black)
                .OrderBy(a => a.ToString());

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
            var pawn = new Pawn(TeamColour.Black, "a7");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
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
            var pawn = new Pawn(TeamColour.Black, "c5");

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

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "e3"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "g3"));

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

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "d4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.Black)
                .Where(a => a.Piece == pawn);

            var expected = new List<Action> { new Action(pawn, "c4", ActionType.Move) };

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

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "f1"));
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "h1"));

            var actual = gameboard.CalculateTeamActions(TeamColour.Black)
                .OrderBy(a => a.ToString());

            var expected = new List<Action> {
                new Action(pawn, "f1", ActionType.PawnPromoteKnight, pawn.PieceValue),
                new Action(pawn, "f1", ActionType.PawnPromoteBishop, pawn.PieceValue),
                new Action(pawn, "f1", ActionType.PawnPromoteRook, pawn.PieceValue),
                new Action(pawn, "f1", ActionType.PawnPromoteQueen, pawn.PieceValue),
                new Action(pawn, "g1", ActionType.PawnPromoteKnight),
                new Action(pawn, "g1", ActionType.PawnPromoteBishop),
                new Action(pawn, "g1", ActionType.PawnPromoteRook),
                new Action(pawn, "g1", ActionType.PawnPromoteQueen),
                new Action(pawn, "h1", ActionType.PawnPromoteKnight, pawn.PieceValue),
                new Action(pawn, "h1", ActionType.PawnPromoteBishop, pawn.PieceValue),
                new Action(pawn, "h1", ActionType.PawnPromoteRook, pawn.PieceValue),
                new Action(pawn, "h1", ActionType.PawnPromoteQueen, pawn.PieceValue),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PawnBlackEnPassant()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, "d4");
            var enemyPawn = new Pawn(TeamColour.White, "e4");
            var previousAction = new Action(enemyPawn, "e4", ActionType.PawnDoubleMove);

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(enemyPawn);
            gameboard.AddActionToHistory(previousAction);

            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action>
            {
                new Action(pawn, "d3", ActionType.Move),
                new Action(pawn, "e3", ActionType.PawnEnPassant)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A black pawn should not be able to en passant capture an enemy pawn if the previous action was not a double move from that pawn
        /// </summary>
        [Fact]
        public void PawnBlackEnPassantNotAvailable1()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, "e4");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "f4"));

            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action> { new Action(pawn, "e3", ActionType.Move) };

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A black pawn should not be able to en passant capture an enemy pawn (in the correct en passant position) if a DIFFERENT enemy pawn performed the double move
        /// </summary>
        [Fact]
        public void PawnBlackEnPassantNotAvailable2()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, "b4");
            var enemyPawn1 = new Pawn(TeamColour.White, "c4");
            var enemyPawn2 = new Pawn(TeamColour.White, "g4");
            var previousAction = new Action(enemyPawn2, "g4", ActionType.PawnDoubleMove);

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(enemyPawn1);
            gameboard.Board.SetSquare(enemyPawn2);
            gameboard.AddActionToHistory(previousAction);

            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action> { new Action(pawn, "b3", ActionType.Move) };

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A black pawn should not be able to en passant capture an enemy pawn outside of the double move zone (even if the previous action was somehow a double move - (not legal))
        /// </summary>
        [Fact]
        public void PawnBlackEnPassantNotAvailable3()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, "d6");
            var enemyPawn = new Pawn(TeamColour.White, "e6");

            var previousAction = new Action(enemyPawn, "e6", ActionType.PawnDoubleMove);

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(pawn);
            gameboard.Board.SetSquare(enemyPawn);
            gameboard.AddActionToHistory(previousAction);

            var actual = gameboard.CalculateTeamActions(TeamColour.Black);

            var expected = new List<Action> { new Action(pawn, "d5", ActionType.Move) };

            Assert.Equal(expected, actual);
        }
    }
}