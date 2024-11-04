using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class KingCastleTests
    {
        /// <summary>
        /// A white King can kingside castle when unobstructed and not threatened by a check
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "h1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.True(canKingsideCastle);
        }

        /// <summary>
        /// A white King can still kingside castle when only the rook is under threat 
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_RookThreatened_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "h1");
            var enemyBishop = new Bishop(TeamColour.Black, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyBishop);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.True(canKingsideCastle);
        }

        /// <summary>
        /// A white King can no longer kingside castle if they are not on their starting squares, despite all other conditions being met (include HasMoved == false)
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_CorrectDistanceButIncorrectRank_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e2");
            var rook = new Rook(TeamColour.White, "h2");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A white king can no longer kingside castle if they are not on their starting squares (are instead on the starting squares for a black kingside castle)
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_CorrectDistanceButOnBlackKingsideCastleSquares_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e8");
            var rook = new Rook(TeamColour.White, "h8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A white king can no longer kingside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_FriendlyKnightObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "h1");
            var initialKnight = new Knight(TeamColour.White, "g1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialKnight);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A white king can no longer kingside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_FriendlyBishopObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "h1");
            var initialBishop = new Bishop(TeamColour.White, "f1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialBishop);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A white King can no longer kingside castle when he himself is in check (must get out of check another way)
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_Checked_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "h1");
            var enemyBishop = new Bishop(TeamColour.Black, "b4");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyBishop);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A white King can no longer kingside castle if the f1 square he moves through is threatened
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_f1Threatened_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "h1");
            var enemyRook = new Rook(TeamColour.Black, "f5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A white King can no longer kingside castle if the g1 square he moves to is threatened
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_g1Threatened_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "h1");
            var enemyRook = new Rook(TeamColour.Black, "g5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A white king, despite being in the correct castling position, can no longer castle if they had previously moved
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_PreviouslyMovedKing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "h1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            // move out of starting square, then move back to starting square
            gameboard.PerformAction(new Action(king, "d1", ActionType.Move));
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(king, "e1", ActionType.Move));

            var canKingSideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingSideCastle);
        }

        /// <summary>
        /// A white king, despite being in the correct castling position, can no longer castle if the rook had previously moved
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_PreviouslyMovedRook_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "h1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            // move out of starting square, then move back to starting square
            gameboard.PerformAction(new Action(rook, "h6", ActionType.Move));
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(rook, "h1", ActionType.Move));

            var canKingSideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingSideCastle);
        }

        /// <summary>
        /// A black King can kingside castle when unobstructed and not threatened by a check
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "h8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.True(canKingsideCastle);
        }

        /// <summary>
        /// A black King can still kingside castle when only the rook is under threat 
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_RookThreatened_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "h8");
            var enemyBishop = new Bishop(TeamColour.White, "e5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyBishop);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.True(canKingsideCastle);
        }

        /// <summary>
        /// A white King can no longer kingside castle if they are not on their starting squares, despite all other conditions being met (include HasMoved == false)
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_CorrectDistanceButIncorrectRank_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e2");
            var rook = new Rook(TeamColour.Black, "h2");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A black king can no longer kingside castle if they are not on their starting squares (are instead on the starting squares for a white kingside castle)
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_CorrectDistanceButOnWhiteKingsideCastleSquares_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e1");
            var rook = new Rook(TeamColour.Black, "h1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A black king can no longer kingside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_FriendlyKnightObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "h8");
            var initialKnight = new Knight(TeamColour.Black, "g8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialKnight);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A black king can no longer kingside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_FriendlyBishopObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "h8");
            var initialBishop = new Bishop(TeamColour.Black, "f8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialBishop);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A black King can no longer kingside castle when he himself is in check (must get out of check another way)
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_Checked_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "h8");
            var enemyBishop = new Bishop(TeamColour.White, "b5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyBishop);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A black King can no longer kingside castle if the f8 square he moves through is threatened
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_f8Threatened_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "h8");
            var enemyRook = new Rook(TeamColour.White, "f5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A black King can no longer kingside castle if the g8 square he moves to is threatened
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_g8Threatened_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "h8");
            var enemyRook = new Rook(TeamColour.White, "g5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A black king, despite being in the correct castling position, can no longer castle if they had previously moved
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_PreviouslyMovedKing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "h8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            // move out of starting square, then move back to starting square
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(king, "e7", ActionType.Move));
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(king, "e8", ActionType.Move));

            var canKingSideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingSideCastle);
        }

        /// <summary>
        /// A black king, despite being in the correct castling position, can no longer castle if the rook had previously moved
        /// </summary>
        [Fact]
        public void BlackKingsideCastle_PreviouslyMovedRook_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "h8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            // move out of starting square, then move back to starting square
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(rook, "h6", ActionType.Move));
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(rook, "h8", ActionType.Move));

            var canKingSideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingSideCastle);
        }

        /// <summary>
        /// A white King can queenside castle when unobstructed and not threatened by a check
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.True(canQueensideCastle);
        }

        /// <summary>
        /// A white King can still queenside castle when only the rook is under threat 
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_RookThreatened_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");
            var enemyBishop = new Bishop(TeamColour.Black, "d4");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyBishop);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.True(canQueensideCastle);
        }

        /// <summary>
        /// A white King can still queenside castle when only the rook's moves are under threat (b1)
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_RookMoveThreatened_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");
            var enemyRook = new Rook(TeamColour.Black, "b5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.True(canQueensideCastle);
        }

        /// <summary>
        /// A white King can no longer queenside castle if they are not on their starting squares, despite all other conditions being met (include HasMoved == false)
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_CorrectDistanceButIncorrectRank_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e2");
            var rook = new Rook(TeamColour.Black, "a2");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A white king can no longer queenside castle if they are not on their starting squares (are instead on the starting squares for a black queenside castle)
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_CorrectDistanceButOnBlackQueensideCastleSquares_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e8");
            var rook = new Rook(TeamColour.White, "a8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board);

            Assert.False(canKingsideCastle);
        }

        /// <summary>
        /// A white king can no longer queenside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_FriendlyKnightObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");
            var initialKnight = new Knight(TeamColour.White, "b1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialKnight);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A white king can no longer queenside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_FriendlyBishopObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");
            var initialBishop = new Bishop(TeamColour.White, "c1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialBishop);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A white king can no longer queenside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_FriendlyQueenObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");
            var initialQueen = new Queen(TeamColour.White, "d1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialQueen);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A white King can no longer queenside castle when he himself is in check (must get out of check another way)
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_Checked_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");
            var enemyBishop = new Bishop(TeamColour.Black, "c3");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyBishop);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A white King can no longer queenside castle if the d1 square he moves through is threatened
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_d1Threatened_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");
            var enemyRook = new Rook(TeamColour.Black, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A white King can no longer queenside castle if the c1 square he moves through is threatened
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_c1Threatened_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");
            var enemyRook = new Rook(TeamColour.Black, "c5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A white king, despite being in the correct castling position, can no longer castle if they had previously moved
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_PreviouslyMovedKing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            // move out of starting square, then move back to starting square
            gameboard.PerformAction(new Action(king, "d1", ActionType.Move));
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(king, "e1", ActionType.Move));

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A white king, despite being in the correct castling position, can no longer castle if the rook had previously moved
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_PreviouslyMovedRook_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e1");
            var rook = new Rook(TeamColour.White, "a1");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            // move out of starting square, then move back to starting square
            gameboard.PerformAction(new Action(rook, "a6", ActionType.Move));
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(rook, "a1", ActionType.Move));

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black King can queenside castle when unobstructed and not threatened by a check
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.True(canQueensideCastle);
        }

        /// <summary>
        /// A black King can still queenside castle when only the rook is under threat 
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_RookThreatened_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");
            var enemyBishop = new Bishop(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyBishop);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.True(canQueensideCastle);
        }

        /// <summary>
        /// A black King can still queenside castle when only the rook's moves are under threat (b1)
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_RookMoveThreatened_Available()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");
            var enemyRook = new Rook(TeamColour.White, "b5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.True(canQueensideCastle);
        }

        /// <summary>
        /// A black King can no longer queenside castle if they are not on their starting squares, despite all other conditions being met (include HasMoved == false)
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_CorrectDistanceButIncorrectRank_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e2");
            var rook = new Rook(TeamColour.Black, "a2");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black king can no longer queenside castle if they are not on their starting squares (are instead on the starting squares for a white queenside castle)
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_CorrectDistanceButOnWhiteQueensideCastleSquares_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e2");
            var rook = new Rook(TeamColour.Black, "a2");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black king can no longer queenside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_FriendlyKnightObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");
            var initialKnight = new Knight(TeamColour.Black, "b8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialKnight);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black king can no longer queenside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_FriendlyBishopObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");
            var initialBishop = new Bishop(TeamColour.Black, "c8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialBishop);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black king can no longer queenside castle when one or more of the separating squares are occupied
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_FriendlyQueenObstructing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");
            var initialQueen = new Queen(TeamColour.Black, "d8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(initialQueen);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black King can no longer queenside castle when he himself is in check (must get out of check another way)
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_Checked_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");
            var enemyBishop = new Bishop(TeamColour.White, "h5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyBishop);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black King can no longer queenside castle if the d8 square he moves through is threatened
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_d8Threatened_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");
            var enemyRook = new Rook(TeamColour.White, "d5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black King can no longer queenside castle if the c8 square he moves through is threatened
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_c8Threatened_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");
            var enemyRook = new Rook(TeamColour.White, "c5");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);
            gameboard.Board.SetSquare(enemyRook);

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black king, despite being in the correct castling position, can no longer castle if they had previously moved
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_PreviouslyMovedKing_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.Black, "e8");
            var rook = new Rook(TeamColour.Black, "a8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            // move out of starting square, then move back to starting square
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(king, "d8", ActionType.Move));
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(king, "e8", ActionType.Move));

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A black king, despite being in the correct castling position, can no longer castle if the rook had previously moved
        /// </summary>
        [Fact]
        public void BlackQueensideCastle_PreviouslyMovedRook_Unavailable()
        {
            var gameboard = new Gameboard();
            var king = new King(TeamColour.White, "e8");
            var rook = new Rook(TeamColour.White, "a8");

            gameboard.Board.SetSquare(king);
            gameboard.Board.SetSquare(rook);

            // move out of starting square, then move back to starting square
            gameboard.PerformAction(new Action(rook, "a6", ActionType.Move));
            gameboard.SwapTurns();
            gameboard.PerformAction(new Action(rook, "a1", ActionType.Move));

            var canQueensideCastle = king.CanQueensideCastle(gameboard.Board);

            Assert.False(canQueensideCastle);
        }

        /// <summary>
        /// A white king should be able to kingside castle when black also has a kingside castle available (infinite loop test)
        /// </summary>
        [Fact]
        public void WhiteKingsideCastle_CastleAvailableBothTeams_Available()
        {
            var gameboard = new Gameboard();
            var whiteKing = new King(TeamColour.White, "e1");
            var whiteRook = new Rook(TeamColour.White, "h1");
            var blackKing = new King(TeamColour.Black, "e8");
            var blackRook = new Rook(TeamColour.Black, "h8");

            gameboard.Board.SetSquare(whiteKing);
            gameboard.Board.SetSquare(whiteRook);
            gameboard.Board.SetSquare(blackKing);
            gameboard.Board.SetSquare(blackRook);

            var canWhiteKingsideCastle = whiteKing.CanKingsideCastle(gameboard.Board);

            Assert.True(canWhiteKingsideCastle);
        }

        /// <summary>
        /// A white king should be able to queenside castle when black also has a queenside castle available (infinite loop test)
        /// </summary>
        [Fact]
        public void WhiteQueensideCastle_CastleAvailableBothTeams_Available()
        {
            var gameboard = new Gameboard();
            var whiteKing = new King(TeamColour.White, "e1");
            var whiteRook = new Rook(TeamColour.White, "a1");
            var blackKing = new King(TeamColour.Black, "e8");
            var blackRook = new Rook(TeamColour.Black, "a8");

            gameboard.Board.SetSquare(whiteKing);
            gameboard.Board.SetSquare(whiteRook);
            gameboard.Board.SetSquare(blackKing);
            gameboard.Board.SetSquare(blackRook);

            var canWhiteQueensideCastle = whiteKing.CanQueensideCastle(gameboard.Board);

            Assert.True(canWhiteQueensideCastle);
        }
    }
}
