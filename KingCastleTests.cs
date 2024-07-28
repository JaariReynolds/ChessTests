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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

            Assert.True(canKingsideCastle);
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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

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
            gameboard.PerformAction(new Action(king, "e1", ActionType.Move));

            var canKingSideCastle = king.CanKingsideCastle(gameboard.Board, null);

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
            gameboard.PerformAction(new Action(rook, "h1", ActionType.Move));

            var canKingSideCastle = king.CanKingsideCastle(gameboard.Board, null);

            Assert.False(canKingSideCastle);
        }

        //-----------

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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

            Assert.True(canKingsideCastle);
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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

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

            var canKingsideCastle = king.CanKingsideCastle(gameboard.Board, null);

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
            gameboard.PerformAction(new Action(king, "e7", ActionType.Move));
            gameboard.PerformAction(new Action(king, "e8", ActionType.Move));

            var canKingSideCastle = king.CanKingsideCastle(gameboard.Board, null);

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
            gameboard.PerformAction(new Action(rook, "h6", ActionType.Move));
            gameboard.PerformAction(new Action(rook, "h8", ActionType.Move));

            var canKingSideCastle = king.CanKingsideCastle(gameboard.Board, null);

            Assert.False(canKingSideCastle);
        }
    }
}
