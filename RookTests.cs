﻿using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

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
            var rook = new Rook(TeamColour.White, "d5");

            gameboard.Board.SetSquare(rook);

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d8", ActionType.Move),
                new Action(rook, "d7", ActionType.Move),
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "d3", ActionType.Move),
                new Action(rook, "d2", ActionType.Move),
                new Action(rook, "d1", ActionType.Move),
                new Action(rook, "a5", ActionType.Move),
                new Action(rook, "b5", ActionType.Move),
                new Action(rook, "c5", ActionType.Move),
                new Action(rook, "e5", ActionType.Move),
                new Action(rook, "f5", ActionType.Move),
                new Action(rook, "g5", ActionType.Move),
                new Action(rook, "h5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A rook can move infinitely vertically and horizontally with no obstructions
        /// </summary>
        [Fact]
        public void RookBlackMove()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, "d5");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(rook);

            var actual = gameboard.CalculateTeamActions(TeamColour.Black)
                .OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d8", ActionType.Move),
                new Action(rook, "d7", ActionType.Move),
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "d3", ActionType.Move),
                new Action(rook, "d2", ActionType.Move),
                new Action(rook, "d1", ActionType.Move),
                new Action(rook, "a5", ActionType.Move),
                new Action(rook, "b5", ActionType.Move),
                new Action(rook, "c5", ActionType.Move),
                new Action(rook, "e5", ActionType.Move),
                new Action(rook, "f5", ActionType.Move),
                new Action(rook, "g5", ActionType.Move),
                new Action(rook, "h5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A rook should be blocked from moving past a friendly obstruction to the North
        /// </summary>
        [Fact]
        public void RookWhiteObstructionNorth()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d5");

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "d7"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == rook).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "d3", ActionType.Move),
                new Action(rook, "d2", ActionType.Move),
                new Action(rook, "d1", ActionType.Move),
                new Action(rook, "a5", ActionType.Move),
                new Action(rook, "b5", ActionType.Move),
                new Action(rook, "c5", ActionType.Move),
                new Action(rook, "e5", ActionType.Move),
                new Action(rook, "f5", ActionType.Move),
                new Action(rook, "g5", ActionType.Move),
                new Action(rook, "h5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A rook should be blocked from moving past a friendly obstruction to the South
        /// </summary>
        [Fact]
        public void RookWhiteObstructionSouth()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d5");

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Pawn(TeamColour.White, "d3"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == rook).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d8", ActionType.Move),
                new Action(rook, "d7", ActionType.Move),
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "a5", ActionType.Move),
                new Action(rook, "b5", ActionType.Move),
                new Action(rook, "c5", ActionType.Move),
                new Action(rook, "e5", ActionType.Move),
                new Action(rook, "f5", ActionType.Move),
                new Action(rook, "g5", ActionType.Move),
                new Action(rook, "h5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A rook should be blocked from moving past a friendly obstruction to the East
        /// </summary>
        [Fact]
        public void RookBlackObstructionEast()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, "d5");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Pawn(TeamColour.Black, "g5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.Black)
                .Where(a => a.Piece == rook).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d8", ActionType.Move),
                new Action(rook, "d7", ActionType.Move),
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "d3", ActionType.Move),
                new Action(rook, "d2", ActionType.Move),
                new Action(rook, "d1", ActionType.Move),
                new Action(rook, "a5", ActionType.Move),
                new Action(rook, "b5", ActionType.Move),
                new Action(rook, "c5", ActionType.Move),
                new Action(rook, "e5", ActionType.Move),
                new Action(rook, "f5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A rook should be blocked from moving past a friendly obstruction to the West
        /// </summary>
        [Fact]
        public void RookBlackObstructionWest()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, "d5");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "c5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.Black)
                .Where(a => a.Piece == rook).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d8", ActionType.Move),
                new Action(rook, "d7", ActionType.Move),
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "d3", ActionType.Move),
                new Action(rook, "d2", ActionType.Move),
                new Action(rook, "d1", ActionType.Move),
                new Action(rook, "e5", ActionType.Move),
                new Action(rook, "f5", ActionType.Move),
                new Action(rook, "g5", ActionType.Move),
                new Action(rook, "h5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A rook should be able to capture an enemy piece to the North and not move past it
        /// </summary>
        [Fact]
        public void RookBlackCaptureNorth()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, "d5");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Rook(TeamColour.White, "d7"));

            var actual = gameboard.CalculateTeamActions(TeamColour.Black)
                .Where(a => a.Piece == rook).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d7", ActionType.Capture),
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "d3", ActionType.Move),
                new Action(rook, "d2", ActionType.Move),
                new Action(rook, "d1", ActionType.Move),
                new Action(rook, "a5", ActionType.Move),
                new Action(rook, "b5", ActionType.Move),
                new Action(rook, "c5", ActionType.Move),
                new Action(rook, "e5", ActionType.Move),
                new Action(rook, "f5", ActionType.Move),
                new Action(rook, "g5", ActionType.Move),
                new Action(rook, "h5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A rook should be able to capture an enemy piece to the South and not move past it
        /// </summary>
        [Fact]
        public void RookBlackCaptureSouth()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.Black, "d5");

            gameboard.SwapTurns();
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Rook(TeamColour.White, "d2"));

            var actual = gameboard.CalculateTeamActions(TeamColour.Black)
                .Where(a => a.Piece == rook).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d8", ActionType.Move),
                new Action(rook, "d7", ActionType.Move),
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "d3", ActionType.Move),
                new Action(rook, "d2", ActionType.Capture),
                new Action(rook, "a5", ActionType.Move),
                new Action(rook, "b5", ActionType.Move),
                new Action(rook, "c5", ActionType.Move),
                new Action(rook, "e5", ActionType.Move),
                new Action(rook, "f5", ActionType.Move),
                new Action(rook, "g5", ActionType.Move),
                new Action(rook, "h5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A rook should be able to capture an enemy piece to the East and not move past it
        /// </summary>
        [Fact]
        public void RookWhiteCaptureEast()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d5");

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "e5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == rook).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d8", ActionType.Move),
                new Action(rook, "d7", ActionType.Move),
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "d3", ActionType.Move),
                new Action(rook, "d2", ActionType.Move),
                new Action(rook, "d1", ActionType.Move),
                new Action(rook, "a5", ActionType.Move),
                new Action(rook, "b5", ActionType.Move),
                new Action(rook, "c5", ActionType.Move),
                new Action(rook, "e5", ActionType.Capture),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// A rook should be able to capture an enemy piece to the West and not move past it
        /// </summary>
        [Fact]
        public void RookWhiteCaptureWest()
        {
            var gameboard = new Gameboard();
            var rook = new Rook(TeamColour.White, "d5");

            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(new Rook(TeamColour.Black, "b5"));

            var actual = gameboard.CalculateTeamActions(TeamColour.White)
                .Where(a => a.Piece == rook).OrderBy(a => a.ToString());

            var expected = new List<Action>
            {
                new Action(rook, "d8", ActionType.Move),
                new Action(rook, "d7", ActionType.Move),
                new Action(rook, "d6", ActionType.Move),
                new Action(rook, "d4", ActionType.Move),
                new Action(rook, "d3", ActionType.Move),
                new Action(rook, "d2", ActionType.Move),
                new Action(rook, "d1", ActionType.Move),
                new Action(rook, "b5", ActionType.Capture),
                new Action(rook, "c5", ActionType.Move),
                new Action(rook, "e5", ActionType.Move),
                new Action(rook, "f5", ActionType.Move),
                new Action(rook, "g5", ActionType.Move),
                new Action(rook, "h5", ActionType.Move),
            }.OrderBy(a => a.ToString()).ToList();

            Assert.Equal(expected, actual);
        }
    }
}
