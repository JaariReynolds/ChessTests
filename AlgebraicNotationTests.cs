using Chess.Classes;
using Chess.Classes.ConcretePieces;
using Chess.Types;

namespace ChessTests
{
    public class AlgebraicNotationTests
    {
        #region Standard Moves
        [Fact]
        public void WhitePawnMove()
        {
            var pawn = new Pawn(TeamColour.White, "a2");
            var action = new Action(pawn, "a3", ActionType.Move);

            Assert.Equal("a3", action.AlgebraicNotation);
        }

        [Fact]
        public void WhitePawnDoubleMove()
        {
            var pawn = new Pawn(TeamColour.White, "d2");
            var action = new Action(pawn, "d4", ActionType.PawnDoubleMove);

            Assert.Equal("d4", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackPawnMove()
        {
            var pawn = new Pawn(TeamColour.Black, "c4");
            var action = new Action(pawn, "c3", ActionType.Move);

            Assert.Equal("c3", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackPawnDoubleMove()
        {
            var pawn = new Pawn(TeamColour.Black, "f5");
            var action = new Action(pawn, "f3", ActionType.PawnDoubleMove);

            Assert.Equal("f3", action.AlgebraicNotation);
        }

        // Knight moves

        [Fact]
        public void WhiteKnightMove()
        {
            var knight = new Knight(TeamColour.White, "b1");
            var action = new Action(knight, "c3", ActionType.Move);

            Assert.Equal("Nc3", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackKnightMove()
        {
            var knight = new Knight(TeamColour.Black, "c5");
            var action = new Action(knight, "e6", ActionType.Move);

            Assert.Equal("Ne6", action.AlgebraicNotation);
        }

        // Rook moves
        [Fact]
        public void WhiteRookMove()
        {
            var rook = new Rook(TeamColour.White, "a1");
            var action = new Action(rook, "a7", ActionType.Move);

            Assert.Equal("Ra7", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackRookMove()
        {
            var rook = new Rook(TeamColour.Black, "a8");
            var action = new Action(rook, "a7", ActionType.Move);

            Assert.Equal("Ra7", action.AlgebraicNotation);
        }

        // Bishop moves
        [Fact]
        public void WhiteBishopMove()
        {
            var bishop = new Bishop(TeamColour.White, "a5");
            var action = new Action(bishop, "c7", ActionType.Move);

            Assert.Equal("Bc7", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackBishopMove()
        {
            var bishop = new Bishop(TeamColour.Black, "e3");
            var action = new Action(bishop, "g1", ActionType.Move);

            Assert.Equal("Bg1", action.AlgebraicNotation);
        }

        // King moves
        [Fact]
        public void WhiteKingMove()
        {
            var king = new King(TeamColour.White, "b1");
            var action = new Action(king, "c1", ActionType.Move);

            Assert.Equal("Kc1", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackKingMove()
        {
            var king = new King(TeamColour.Black, "e5");
            var action = new Action(king, "c1", ActionType.Move);

            Assert.Equal("Kc1", action.AlgebraicNotation);
        }

        // Queen moves
        [Fact]
        public void WhiteQueenMove()
        {
            var queen = new Queen(TeamColour.White, "b8");
            var action = new Action(queen, "h2", ActionType.Move);

            Assert.Equal("Qh2", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackQueenMove()
        {
            var queen = new Queen(TeamColour.Black, "d5");
            var action = new Action(queen, "d4", ActionType.Move);

            Assert.Equal("Qd4", action.AlgebraicNotation);
        }
        #endregion

        #region Standard Captures
        // Pawn captures - includes the file the pawn is coming from 
        [Fact]
        public void WhitePawnCapture()
        {
            var pawn = new Pawn(TeamColour.White, "a2");
            var action = new Action(pawn, "b3", ActionType.Capture);

            Assert.Equal("axb3", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackPawnCapture()
        {
            var pawn = new Pawn(TeamColour.Black, "f7");
            var action = new Action(pawn, "e6", ActionType.Capture);

            Assert.Equal("fxe6", action.AlgebraicNotation);
        }

        // Knight captures
        [Fact]
        public void WhiteKnightCapture()
        {
            var knight = new Knight(TeamColour.White, "g1");
            var action = new Action(knight, "f3", ActionType.Capture);

            Assert.Equal("Nxf3", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackKnightCapture()
        {
            var knight = new Knight(TeamColour.Black, "b8");
            var action = new Action(knight, "c6", ActionType.Capture);

            Assert.Equal("Nxc6", action.AlgebraicNotation);
        }

        // Rook captures
        [Fact]
        public void WhiteRookCapture()
        {
            var rook = new Rook(TeamColour.White, "a1");
            var action = new Action(rook, "a5", ActionType.Capture);

            Assert.Equal("Rxa5", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackRookCapture()
        {
            var rook = new Rook(TeamColour.Black, "h8");
            var action = new Action(rook, "h4", ActionType.Capture);

            Assert.Equal("Rxh4", action.AlgebraicNotation);
        }

        // Bishop captures
        [Fact]
        public void WhiteBishopCapture()
        {
            var bishop = new Bishop(TeamColour.White, "c1");
            var action = new Action(bishop, "g5", ActionType.Capture);

            Assert.Equal("Bxg5", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackBishopCapture()
        {
            var bishop = new Bishop(TeamColour.Black, "f8");
            var action = new Action(bishop, "b4", ActionType.Capture);

            Assert.Equal("Bxb4", action.AlgebraicNotation);
        }

        // King captures
        [Fact]
        public void WhiteKingCapture()
        {
            var king = new King(TeamColour.White, "e1");
            var action = new Action(king, "d2", ActionType.Capture);

            Assert.Equal("Kxd2", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackKingCapture()
        {
            var king = new King(TeamColour.Black, "e8");
            var action = new Action(king, "f7", ActionType.Capture);

            Assert.Equal("Kxf7", action.AlgebraicNotation);
        }

        // Queen captures
        [Fact]
        public void WhiteQueenCapture()
        {
            var queen = new Queen(TeamColour.White, "d1");
            var action = new Action(queen, "h5", ActionType.Capture);

            Assert.Equal("Qxh5", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackQueenCapture()
        {
            var queen = new Queen(TeamColour.Black, "d8");
            var action = new Action(queen, "a5", ActionType.Capture);

            Assert.Equal("Qxa5", action.AlgebraicNotation);
        }
        #endregion

        #region Special Actions
        [Fact]
        public void KingCastle()
        {
            var king = new King(TeamColour.White, "e1");
            var action = new Action(king, "g1", ActionType.KingsideCastle);

            Assert.Equal("O-O", action.AlgebraicNotation);
        }

        [Fact]
        public void QueenCastle()
        {
            var king = new King(TeamColour.White, "e1");
            var action = new Action(king, "c1", ActionType.QueensideCastle);

            Assert.Equal("O-O-O", action.AlgebraicNotation);
        }

        [Fact]
        public void WhiteEnPassant()
        {
            var pawn = new Pawn(TeamColour.White, "a5");
            var action = new Action(pawn, "b6", ActionType.PawnEnPassant);

            Assert.Equal("axb6", action.AlgebraicNotation);
        }

        [Fact]
        public void BlackEnPassant()
        {
            var pawn = new Pawn(TeamColour.Black, "c4");
            var action = new Action(pawn, "d3", ActionType.PawnEnPassant);

            Assert.Equal("cxd3", action.AlgebraicNotation);
        }
        #endregion

        #region Pawn Promotions
        [Fact]
        public void PawnPromoteKnight_Move()
        {
            var pawn = new Pawn(TeamColour.White, "a7");
            var action = new Action(pawn, "a8", ActionType.PawnPromoteKnight);

            Assert.Equal("a8=N", action.AlgebraicNotation);
        }

        [Fact]
        public void PawnPromoteBishop_Move()
        {
            var pawn = new Pawn(TeamColour.White, "b7");
            var action = new Action(pawn, "b8", ActionType.PawnPromoteBishop);

            Assert.Equal("b8=B", action.AlgebraicNotation);
        }

        [Fact]
        public void PawnPromoteRook_Move()
        {
            var pawn = new Pawn(TeamColour.White, "c7");
            var action = new Action(pawn, "c8", ActionType.PawnPromoteRook);

            Assert.Equal("c8=R", action.AlgebraicNotation);
        }

        [Fact]
        public void PawnPromoteQueen_Move()
        {
            var pawn = new Pawn(TeamColour.White, "d7");
            var action = new Action(pawn, "d8", ActionType.PawnPromoteQueen);

            Assert.Equal("d8=Q", action.AlgebraicNotation);
        }

        [Fact]
        public void PawnPromoteKnight_Capture()
        {
            var pawn = new Pawn(TeamColour.White, "d7");
            var enemyBishop = new Bishop(TeamColour.Black, "e8");
            var action = new Action(pawn, "e8", ActionType.PawnPromoteKnight, enemyBishop.PieceValue);

            Assert.Equal("dxe8=N", action.AlgebraicNotation);
        }

        [Fact]
        public void PawnPromoteBishop_Capture()
        {
            var pawn = new Pawn(TeamColour.White, "e7");
            var enemyBishop = new Bishop(TeamColour.Black, "f8");
            var action = new Action(pawn, "f8", ActionType.PawnPromoteBishop, enemyBishop.PieceValue);

            Assert.Equal("exf8=B", action.AlgebraicNotation);
        }

        [Fact]
        public void PawnPromoteRook_Capture()
        {
            var pawn = new Pawn(TeamColour.White, "f7");
            var enemyBishop = new Bishop(TeamColour.Black, "g8");
            var action = new Action(pawn, "g8", ActionType.PawnPromoteRook, enemyBishop.PieceValue);

            Assert.Equal("fxg8=R", action.AlgebraicNotation);
        }

        [Fact]
        public void PawnPromoteQueen_Capture()
        {
            var pawn = new Pawn(TeamColour.White, "g7");
            var enemyBishop = new Bishop(TeamColour.Black, "h8");
            var action = new Action(pawn, "h8", ActionType.PawnPromoteQueen, enemyBishop.PieceValue);

            Assert.Equal("gxh8=Q", action.AlgebraicNotation);
        }
        #endregion

        #region Check and Checkmate suffixes
        // A non-critical action should not add a check or mate suffix symbol
        [Fact]
        public void NoSuffixedAdded()
        {
            var rook = new Rook(TeamColour.White, "a4");
            var action = new Action(rook, "a7", ActionType.Move);
            TeamColour? checkedTeam = null;
            TeamColour? matedTeam = null;

            var updatedAlgebraicNotation = ChessUtils.AddAlgebraicNotationSuffix(action.AlgebraicNotation, checkedTeam, matedTeam);

            Assert.Equal("Ra7", action.AlgebraicNotation);
            Assert.Equal("Ra7", updatedAlgebraicNotation);
        }

        [Fact]
        public void CheckSuffixedAdded()
        {
            var rook = new Rook(TeamColour.White, "a4");
            var action = new Action(rook, "a7", ActionType.Move);
            TeamColour? checkedTeam = TeamColour.Black;
            TeamColour? matedTeam = null;

            var updatedAlgebraicNotation = ChessUtils.AddAlgebraicNotationSuffix(action.AlgebraicNotation, checkedTeam, matedTeam);

            Assert.Equal("Ra7", action.AlgebraicNotation);
            Assert.Equal("Ra7+", updatedAlgebraicNotation);
        }

        [Fact]
        public void MateSuffixedAdded()
        {
            var rook = new Rook(TeamColour.White, "a4");
            var action = new Action(rook, "a7", ActionType.Move);
            TeamColour? checkedTeam = TeamColour.Black;
            TeamColour? matedTeam = null;

            var updatedAlgebraicNotation = ChessUtils.AddAlgebraicNotationSuffix(action.AlgebraicNotation, checkedTeam, matedTeam);

            Assert.Equal("Ra7", action.AlgebraicNotation);
            Assert.Equal("Ra7+", updatedAlgebraicNotation);
        }
        #endregion

        // Ensuring that identical algebraic notations are considered equal
        [Fact]
        public void EqualAlgebraicNotation()
        {
            var whiteKnight = new Knight(TeamColour.White, "c5");
            var whiteAction = new Action(whiteKnight, "e6", ActionType.Move);

            var blackKnight = new Knight(TeamColour.Black, "c5");
            var blackAction = new Action(blackKnight, "e6", ActionType.Move);

            // Ne6, Ne6
            Assert.Equal(whiteAction.AlgebraicNotation, blackAction.AlgebraicNotation);
        }
    }
}
