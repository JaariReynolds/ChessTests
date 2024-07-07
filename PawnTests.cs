using Chess;
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
            var pawn = new Pawn(TeamColour.White, 6, 0);

            gameboard.SetTestBoard(6, 0, pawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(pawn, 4, 0, ActionType.PawnDoubleMove),
                new Action(pawn, 5, 0, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A white pawn should not be able to advance 2 squares (or even 1) if the first is obstructed
        /// </summary>
        [Fact]
        public void PawnWhiteObstructedFirstMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, 6, 0);
            var obstructingPawn = new Pawn(TeamColour.Black, 5, 0);

            gameboard.SetTestBoard(6, 0, pawn);
            gameboard.SetTestBoard(5, 0, obstructingPawn);
            gameboard.CalculateCurrentTeamActions();

            Assert.Empty(gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A white pawn can advance 1 square on its non-starting square
        /// </summary>
        [Fact]
        public void PawnWhiteRegularMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, 5, 1);

            gameboard.SetTestBoard(5, 1, pawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new  List<Action> { new Action(pawn, 4, 1, ActionType.Move) };

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A white pawn should have no moves if their move squares are obstructed
        /// </summary>
        [Fact]
        public void PawnWhiteNoMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, 5, 1);
            var obstructingPawn = new Pawn(TeamColour.Black, 4, 1);

            gameboard.SetTestBoard(5, 1, pawn);
            gameboard.SetTestBoard(4, 1, obstructingPawn);
            gameboard.CalculateCurrentTeamActions();

            Assert.Empty(gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A white pawn should be able to capture 1 diagonally forward on both sides
        /// </summary>
        [Fact]
        public void PawnWhiteCapture()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, 4, 2);
            var blackPawn1 = new Pawn(TeamColour.Black, 3, 1);
            var blackPawn2 = new Pawn(TeamColour.Black, 3, 3);

            gameboard.SetTestBoard(4, 2, pawn);
            gameboard.SetTestBoard(3, 1, blackPawn1);
            gameboard.SetTestBoard(3, 3, blackPawn2);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(pawn, 3, 1, ActionType.Capture),
                new Action(pawn, 3, 3, ActionType.Capture),
                new Action(pawn, 3, 2, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();
                

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A white pawn should not be able to capture friendly pieces
        /// </summary>
        [Fact]
        public void PawnWhiteFriendlyCapture()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, 1, 1);
            var friendlyPawn1 = new Pawn(TeamColour.White, 0, 0);
            var friendlyPawn2 = new Pawn(TeamColour.White, 0, 2);

            gameboard.SetTestBoard(1, 1, pawn);
            gameboard.SetTestBoard(0, 0, friendlyPawn1);
            gameboard.SetTestBoard(0, 2, friendlyPawn2);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action> { new Action(pawn, 0, 1, ActionType.PawnPromote) };
      

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A white pawn, when faced with 2 potential captures on the promote row, should be overwritten by PawnPromote actions
        /// </summary>
        [Fact]
        public void PawnWhitePromote()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.White, 1, 1);
            var blackPawn1 = new Pawn(TeamColour.Black, 0, 0);
            var blackPawn2 = new Pawn(TeamColour.Black, 0, 2);

            gameboard.SetTestBoard(1, 1, pawn);
            gameboard.SetTestBoard(0, 0, blackPawn1);
            gameboard.SetTestBoard(0, 2, blackPawn2);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action> {
                new Action(pawn, 0, 0, ActionType.PawnPromote),
                new Action(pawn, 0, 2, ActionType.PawnPromote),
                new Action(pawn, 0, 1, ActionType.PawnPromote)
            }.OrderBy(a => a.ToString()).ToList();
               
            Assert.Equal(expected, gameboard.CurrentTeamActions);
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
            var pawn = new Pawn(TeamColour.Black, 1, 0);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(1, 0, pawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action> {
                new Action(pawn, 2, 0, ActionType.Move),
                new Action(pawn, 3, 0, ActionType.PawnDoubleMove)
            }.OrderBy(a => a.ToString()).ToList();
                
            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A black pawn should not be able to advance 2 squares (or even 1) if the first is obstructed
        /// </summary>
        [Fact]
        public void PawnBlackObstructedFirstMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, 1, 0);
            var obstructingPawn = new Pawn(TeamColour.White, 2, 0);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(1, 0, pawn);
            gameboard.SetTestBoard(2, 0, obstructingPawn);
            gameboard.CalculateCurrentTeamActions();

            Assert.Empty(gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A black pawn can advance 1 square on its non-starting square
        /// </summary>
        [Fact]
        public void PawnBlackRegularMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, 5, 1);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(5, 1, pawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action> { new Action(pawn, 6, 1, ActionType.Move) };

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A black pawn should have no moves if their move squares are obstructed
        /// </summary>
        [Fact]
        public void PawnBlackNoMove()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, 5, 1);
            var obstructingPawn = new Pawn(TeamColour.White, 6, 1);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(5, 1, pawn);
            gameboard.SetTestBoard(6, 1, obstructingPawn);
            gameboard.CalculateCurrentTeamActions();

            Assert.Empty(gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A black pawn should be able to capture 1 diagonally on both sides
        /// </summary>
        [Fact]
        public void PawnBlackCapture()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, 4, 2);
            var whitePawn1 = new Pawn(TeamColour.White, 5, 1);
            var whitePawn2 = new Pawn(TeamColour.White, 5, 3);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(4, 2, pawn);
            gameboard.SetTestBoard(5, 1, whitePawn1);
            gameboard.SetTestBoard(5, 3, whitePawn2);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action> {
                new Action(pawn, 5, 1, ActionType.Capture),
                new Action(pawn, 5, 3, ActionType.Capture),
                new Action(pawn, 5, 2, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();           

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A black pawn should not be able to capture friendly pieces
        /// </summary>
        [Fact]
        public void PawnBlackFriendlyCapture()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, 3, 3);
            var friendlyPawn1 = new Pawn(TeamColour.Black, 4, 2);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(3, 3, pawn);
            gameboard.SetTestBoard(4, 2, friendlyPawn1);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action> 
            { 
                new Action(pawn, 4, 3, ActionType.Move), 
                new Action(friendlyPawn1, 5, 2, ActionType.Move) 
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A black pawn, when faced with 2 potential captures on the promote row, should be overwritten by PawnPromote actions
        /// </summary>
        [Fact]
        public void PawnBlackPromote()
        {
            var gameboard = new Gameboard();
            var pawn = new Pawn(TeamColour.Black, 6, 1);
            var blackPawn1 = new Pawn(TeamColour.White, 7, 0);
            var blackPawn2 = new Pawn(TeamColour.White, 7, 2);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(6, 1, pawn);
            gameboard.SetTestBoard(7, 0, blackPawn1);
            gameboard.SetTestBoard(7, 2, blackPawn2);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action> {
                new Action(pawn, 7, 0, ActionType.PawnPromote),
                new Action(pawn, 7, 2, ActionType.PawnPromote),
                new Action(pawn, 7, 1, ActionType.PawnPromote)
            }.OrderBy(a => a.ToString()).ToList();
               
            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        [Fact]
        public void PawnBlackEnPassant()
        {
            // not yet implemented as performing an action on a gameboard not yet implemented
            Assert.True(false);
        }
    }
}