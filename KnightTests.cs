using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class KnightTests
    {
        /// <summary>
        /// A knight should be able to move to all 8 unobstructed squares
        /// </summary>
        [Fact]
        public void KnightWhiteMoves()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, 3, 3);

            gameboard.SetTestBoard(3, 3, knight);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(knight, 1, 2, ActionType.Move),
                new Action(knight, 1, 4, ActionType.Move),
                new Action(knight, 5, 2, ActionType.Move),
                new Action(knight, 5, 4, ActionType.Move),
                new Action(knight, 2, 1, ActionType.Move),
                new Action(knight, 2, 5, ActionType.Move),
                new Action(knight, 4, 1, ActionType.Move),
                new Action(knight, 4, 5, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A knight in the corner of the board should only be able to move to 2 squares
        /// </summary>
        [Fact]
        public void KnightWhiteCornerMoves()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, 0, 0);

            gameboard.SetTestBoard(0, 0, knight);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(knight, 1, 2, ActionType.Move),
                new Action(knight, 2, 1, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A knight should not be able to move on friendly pieces 
        /// </summary>
        [Fact]
        public void KnightWhiteFriendlyObstruction()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, 2, 3);
            var friendlyPawn1 = new Pawn(TeamColour.White, 0, 2);
            var friendlyPawn2 = new Pawn(TeamColour.White, 0, 4);

            gameboard.SetTestBoard(2, 3, knight);
            gameboard.SetTestBoard(0, 2, friendlyPawn1);
            gameboard.SetTestBoard(0, 4, friendlyPawn2);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(knight, 1, 1, ActionType.Move),
                new Action(knight, 1, 5, ActionType.Move),
                new Action(knight, 3, 1, ActionType.Move),
                new Action(knight, 3, 5, ActionType.Move),
                new Action(knight, 4, 2, ActionType.Move),
                new Action(knight, 4, 4, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A knight should be able to capture the 2 enemy pieces
        /// </summary>
        [Fact]
        public void KnightWhiteCapture()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, 2, 3);
            var enemyPawn1 = new Pawn(TeamColour.Black, 0, 2);
            var enemyPawn2 = new Pawn(TeamColour.Black, 0, 4);

            gameboard.SetTestBoard(2, 3, knight);
            gameboard.SetTestBoard(0, 2, enemyPawn1);
            gameboard.SetTestBoard(0, 4, enemyPawn2);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(knight, 0, 2, ActionType.Capture),
                new Action(knight, 0, 4, ActionType.Capture),
                new Action(knight, 1, 1, ActionType.Move),
                new Action(knight, 1, 5, ActionType.Move),
                new Action(knight, 3, 1, ActionType.Move),
                new Action(knight, 3, 5, ActionType.Move),
                new Action(knight, 4, 2, ActionType.Move),
                new Action(knight, 4, 4, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A knight should be able to capture 2 enemy pieces, and be obstructed 2 moves by 2 friendly pieces
        /// </summary>
        [Fact]
        public void KnightWhiteCaptureAndObstruction()
        {
            var gameboard = new Gameboard();
            var knight = new Knight(TeamColour.White, 2, 3);
            var friendlyPawn1 = new Pawn(TeamColour.White, 3, 1);
            var friendlyPawn2 = new Pawn(TeamColour.White, 3, 5);
            var enemyPawn1 = new Pawn(TeamColour.Black, 0, 2);
            var enemyPawn2 = new Pawn(TeamColour.Black, 0, 4);

            gameboard.SetTestBoard(2, 3, knight);
            gameboard.SetTestBoard(3, 1, friendlyPawn1);
            gameboard.SetTestBoard(3, 5, friendlyPawn2);
            gameboard.SetTestBoard(0, 2, enemyPawn1);
            gameboard.SetTestBoard(0, 4, enemyPawn2);
            var actual = gameboard.CalculateTeamActions(TeamColour.White);

            var expected = new List<Action>
            {
                new Action(knight, 0, 2, ActionType.Capture),
                new Action(knight, 0, 4, ActionType.Capture),
                new Action(knight, 1, 1, ActionType.Move),
                new Action(knight, 1, 5, ActionType.Move),
                new Action(friendlyPawn1, 2, 1, ActionType.Move),
                new Action(friendlyPawn2, 2, 5, ActionType.Move),
                new Action(knight, 4, 2, ActionType.Move),
                new Action(knight, 4, 4, ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }
    }
}
