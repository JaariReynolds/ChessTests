using Chess;
using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTests
{
    public class RookTests
    {
        
        /// <summary>
        /// A rook can move infinitely vertically and horizontally with no obstructions
        /// </summary>
        [Fact]
        public void RookWhiteMove()
        {
            var gameboard = new Gameboard(); 
            var rook = new Rook(TeamColour.White, 3, 3);

            gameboard.SetTestBoard(3, 3, rook);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 3, 0, ActionType.Move),
                new Action(rook, 3, 1, ActionType.Move),
                new Action(rook, 3, 2, ActionType.Move),
                new Action(rook, 3, 4, ActionType.Move),
                new Action(rook, 3, 5, ActionType.Move),
                new Action(rook, 3, 6, ActionType.Move),
                new Action(rook, 3, 7, ActionType.Move),
                new Action(rook, 0, 3, ActionType.Move),
                new Action(rook, 1, 3, ActionType.Move),
                new Action(rook, 2, 3, ActionType.Move),
                new Action(rook, 4, 3, ActionType.Move),
                new Action(rook, 5, 3, ActionType.Move),
                new Action(rook, 6, 3, ActionType.Move),
                new Action(rook, 7, 3, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A rook can move infinitely vertically and horizontally with no obstructions
        /// </summary>
        [Fact]
        public void RookBlackMove()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, 3, 3);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(3, 3, rook);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 3, 0, ActionType.Move),
                new Action(rook, 3, 1, ActionType.Move),
                new Action(rook, 3, 2, ActionType.Move),
                new Action(rook, 3, 4, ActionType.Move),
                new Action(rook, 3, 5, ActionType.Move),
                new Action(rook, 3, 6, ActionType.Move),
                new Action(rook, 3, 7, ActionType.Move),
                new Action(rook, 0, 3, ActionType.Move),
                new Action(rook, 1, 3, ActionType.Move),
                new Action(rook, 2, 3, ActionType.Move),
                new Action(rook, 4, 3, ActionType.Move),
                new Action(rook, 5, 3, ActionType.Move),
                new Action(rook, 6, 3, ActionType.Move),
                new Action(rook, 7, 3, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A rook should be blocked from moving past a friendly obstruction to the North
        /// </summary>
        [Fact]
        public void RookObstructionNorth()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 1, 3);

            gameboard.SetTestBoard(3, 3, rook);
            gameboard.SetTestBoard(1, 3, friendlyPawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 2, 3, ActionType.Move),
                new Action(rook, 4, 3, ActionType.Move),
                new Action(rook, 5, 3, ActionType.Move),
                new Action(rook, 6, 3, ActionType.Move),
                new Action(rook, 7, 3, ActionType.Move),
                new Action(rook, 3, 0, ActionType.Move),
                new Action(rook, 3, 1, ActionType.Move),
                new Action(rook, 3, 2, ActionType.Move),
                new Action(rook, 3, 4, ActionType.Move),
                new Action(rook, 3, 5, ActionType.Move),
                new Action(rook, 3, 6, ActionType.Move),
                new Action(rook, 3, 7, ActionType.Move),
                new Action(friendlyPawn, 0, 3, ActionType.PawnPromote)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A rook should be blocked from moving past a friendly obstruction to the South
        /// </summary>
        [Fact]
        public void RookObstructionSouth()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.White, 4, 3);

            gameboard.SetTestBoard(3, 3, rook);
            gameboard.SetTestBoard(4, 3, friendlyPawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 0, 3, ActionType.Move),
                new Action(rook, 1, 3, ActionType.Move),
                new Action(rook, 2, 3, ActionType.Move),
                new Action(rook, 3, 0, ActionType.Move),
                new Action(rook, 3, 1, ActionType.Move),
                new Action(rook, 3, 2, ActionType.Move),
                new Action(rook, 3, 4, ActionType.Move),
                new Action(rook, 3, 5, ActionType.Move),
                new Action(rook, 3, 6, ActionType.Move),
                new Action(rook, 3, 7, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A rook should be blocked from moving past a friendly obstruction to the East
        /// </summary>
        [Fact]
        public void RookObstructionEast()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.Black, 3, 4);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(3, 3, rook);
            gameboard.SetTestBoard(3, 4, friendlyPawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 0, 3, ActionType.Move),
                new Action(rook, 1, 3, ActionType.Move),
                new Action(rook, 2, 3, ActionType.Move),
                new Action(rook, 4, 3, ActionType.Move),
                new Action(rook, 5, 3, ActionType.Move),
                new Action(rook, 6, 3, ActionType.Move),
                new Action(rook, 7, 3, ActionType.Move),
                new Action(rook, 3, 0, ActionType.Move),
                new Action(rook, 3, 1, ActionType.Move),
                new Action(rook, 3, 2, ActionType.Move),
                new Action(friendlyPawn, 4, 4, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A rook should be blocked from moving past a friendly obstruction to the West
        /// </summary>
        [Fact]
        public void RookObstructionWest()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, 3, 3);
            var friendlyPawn = new Pawn(TeamColour.Black, 3, 1);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(3, 3, rook);
            gameboard.SetTestBoard(3, 1, friendlyPawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 0, 3, ActionType.Move),
                new Action(rook, 1, 3, ActionType.Move),
                new Action(rook, 2, 3, ActionType.Move),
                new Action(rook, 4, 3, ActionType.Move),
                new Action(rook, 5, 3, ActionType.Move),
                new Action(rook, 6, 3, ActionType.Move),
                new Action(rook, 7, 3, ActionType.Move),
                new Action(rook, 3, 2, ActionType.Move),
                new Action(rook, 3, 4, ActionType.Move),
                new Action(rook, 3, 5, ActionType.Move),
                new Action(rook, 3, 6, ActionType.Move),
                new Action(rook, 3, 7, ActionType.Move),
                new Action(friendlyPawn, 4, 1, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A rook should be able to capture an enemy piece to the North and not move past it
        /// </summary>
        [Fact]
        public void RookCaptureNorth()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, 3, 3);
            var enemyPawn = new Pawn(TeamColour.White, 2, 3);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(3, 3, rook);
            gameboard.SetTestBoard(2, 3, enemyPawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 4, 3, ActionType.Move),
                new Action(rook, 5, 3, ActionType.Move),
                new Action(rook, 6, 3, ActionType.Move),
                new Action(rook, 7, 3, ActionType.Move),
                new Action(rook, 2, 3, ActionType.Capture),
                new Action(rook, 3, 0, ActionType.Move),
                new Action(rook, 3, 1, ActionType.Move),
                new Action(rook, 3, 2, ActionType.Move),
                new Action(rook, 3, 4, ActionType.Move),
                new Action(rook, 3, 5, ActionType.Move),
                new Action(rook, 3, 6, ActionType.Move),
                new Action(rook, 3, 7, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A rook should be able to capture an enemy piece to the South and not move past it
        /// </summary>
        [Fact]
        public void RookCaptureSouth()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, 3, 3);
            var enemyPawn = new Pawn(TeamColour.White, 4, 3);

            gameboard.SwapTurns();
            gameboard.SetTestBoard(3, 3, rook);
            gameboard.SetTestBoard(4, 3, enemyPawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 4, 3, ActionType.Capture),
                new Action(rook, 2, 3, ActionType.Move),
                new Action(rook, 1, 3, ActionType.Move),
                new Action(rook, 0, 3, ActionType.Move),
                new Action(rook, 3, 0, ActionType.Move),
                new Action(rook, 3, 1, ActionType.Move),
                new Action(rook, 3, 2, ActionType.Move),
                new Action(rook, 3, 4, ActionType.Move),
                new Action(rook, 3, 5, ActionType.Move),
                new Action(rook, 3, 6, ActionType.Move),
                new Action(rook, 3, 7, ActionType.Move)
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A rook should be able to capture an enemy piece to the East and not move past it
        /// </summary>
        [Fact]
        public void RookCaptureEast()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, 3, 3);
            var enemyPawn = new Pawn(TeamColour.Black, 3, 4);

            gameboard.SetTestBoard(3, 3, rook);
            gameboard.SetTestBoard(3, 4, enemyPawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 4, 3, ActionType.Move),
                new Action(rook, 5, 3, ActionType.Move),
                new Action(rook, 6, 3, ActionType.Move),
                new Action(rook, 7, 3, ActionType.Move),
                new Action(rook, 2, 3, ActionType.Move),
                new Action(rook, 1, 3, ActionType.Move),
                new Action(rook, 0, 3, ActionType.Move),
                new Action(rook, 3, 4, ActionType.Capture),
                new Action(rook, 3, 0, ActionType.Move),
                new Action(rook, 3, 1, ActionType.Move),
                new Action(rook, 3, 2, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

        /// <summary>
        /// A rook should be able to capture an enemy piece to the West and not move past it
        /// </summary>
        [Fact]
        public void RookCaptureWest()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, 3, 3);
            var enemyPawn = new Pawn(TeamColour.Black, 3, 1);

            gameboard.SetTestBoard(3, 3, rook);
            gameboard.SetTestBoard(3, 1, enemyPawn);
            gameboard.CalculateCurrentTeamActions();

            var expected = new List<Action>
            {
                new Action(rook, 4, 3, ActionType.Move),
                new Action(rook, 5, 3, ActionType.Move),
                new Action(rook, 6, 3, ActionType.Move),
                new Action(rook, 7, 3, ActionType.Move),
                new Action(rook, 2, 3, ActionType.Move),
                new Action(rook, 1, 3, ActionType.Move),
                new Action(rook, 0, 3, ActionType.Move),
                new Action(rook, 3, 1, ActionType.Capture),
                new Action(rook, 3, 2, ActionType.Move),
                new Action(rook, 3, 4, ActionType.Move),
                new Action(rook, 3, 5, ActionType.Move),
                new Action(rook, 3, 6, ActionType.Move),
                new Action(rook, 3, 7, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, gameboard.CurrentTeamActions);
        }

    }
}
