using Chess.Classes.ConcretePieces;
using Chess.Types;
using ChessLogic.Classes;

namespace ChessTests
{
    public class AmbiguityResolutionTests
    {
        // Rooks on the same file have their notation resolved with their rank
        [Fact]
        public void IdenticalRookActions_SameFile_RankResolution()
        {
            var highRook = new Rook(TeamColour.White, "a7");
            var lowRook = new Rook(TeamColour.White, "a1");

            var highRookAction = new Action(highRook, "a4", ActionType.Move);
            var lowRookAction = new Action(lowRook, "a4", ActionType.Move);

            var ambiguousActions = new List<Action> { lowRookAction, highRookAction };

            Assert.Equal("Ra4", lowRookAction.AlgebraicNotation);
            Assert.Equal("Ra4", highRookAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(ambiguousActions);

            Assert.Equal("R1a4", lowRookAction.AlgebraicNotation);
            Assert.Equal("R7a4", highRookAction.AlgebraicNotation);
        }

        // Rooks on the same rank have their notation resolved with their file
        [Fact]
        public void IdentialRookActions_SameRank_FileResolution()
        {
            var leftRook = new Rook(TeamColour.White, "a1");
            var rightRook = new Rook(TeamColour.White, "h1");

            var leftRookAction = new Action(leftRook, "e1", ActionType.Move);
            var rightRookAction = new Action(rightRook, "e1", ActionType.Move);

            var ambiguousActions = new List<Action>() { leftRookAction, rightRookAction };

            Assert.Equal("Re1", leftRookAction.AlgebraicNotation);
            Assert.Equal("Re1", rightRookAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(ambiguousActions);

            Assert.Equal("Rae1", leftRookAction.AlgebraicNotation);
            Assert.Equal("Rhe1", rightRookAction.AlgebraicNotation);
        }

        // Bishops on the same rank have their notation resolved with their file
        [Fact]
        public void IdenticalBishopActions_SameRank_FileResolution()
        {
            var leftBishop = new Bishop(TeamColour.White, "a3");
            var rightBishop = new Bishop(TeamColour.White, "e3");

            var leftBishopAction = new Action(leftBishop, "c5", ActionType.Move);
            var rightBishopAction = new Action(rightBishop, "c5", ActionType.Move);

            var ambiguousActions = new List<Action>() { leftBishopAction, rightBishopAction };

            Assert.Equal("Bc5", leftBishopAction.AlgebraicNotation);
            Assert.Equal("Bc5", rightBishopAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(ambiguousActions);

            Assert.Equal("Bac5", leftBishopAction.AlgebraicNotation);
            Assert.Equal("Bec5", rightBishopAction.AlgebraicNotation);
        }

        // Bishops on different ranks and different files have their notation resolved with their file
        [Fact]
        public void IdenticalBishopActions_DifferentFileAndRank_FileResolution()
        {
            var leftBishop = new Bishop(TeamColour.White, "a3");
            var rightBishop = new Bishop(TeamColour.White, "c5");

            var leftBishopAction = new Action(leftBishop, "b4", ActionType.Capture);
            var rightBishopAction = new Action(rightBishop, "b4", ActionType.Capture);

            var ambiguousActions = new List<Action>() { leftBishopAction, rightBishopAction };

            Assert.Equal("Bxb4", leftBishopAction.AlgebraicNotation);
            Assert.Equal("Bxb4", rightBishopAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(ambiguousActions);

            Assert.Equal("Baxb4", leftBishopAction.AlgebraicNotation);
            Assert.Equal("Bcxb4", rightBishopAction.AlgebraicNotation);
        }

        [Fact]
        public void IdenticalKnightActions_SameFile_RankResolution()
        {
            var topKnight = new Knight(TeamColour.White, "c4");
            var bottomKnight = new Knight(TeamColour.White, "c2");

            var topKnightAction = new Action(topKnight, "a3", ActionType.Capture);
            var bottomKnightAction = new Action(bottomKnight, "a3", ActionType.Capture);

            var ambiguousActions = new List<Action>() { topKnightAction, bottomKnightAction };

            Assert.Equal("Nxa3", topKnightAction.AlgebraicNotation);
            Assert.Equal("Nxa3", bottomKnightAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(ambiguousActions);

            Assert.Equal("N4xa3", topKnightAction.AlgebraicNotation);
            Assert.Equal("N2xa3", bottomKnightAction.AlgebraicNotation);
        }

        // One of the few situations in which both file and rank are required to disambiguate
        // When there are three (or more) of the same pieces that form an L or right angle between them, and all three (or more) can move to the same square
        [Fact]
        public void IdentialQueenActions_ThreeQueens_FileRankResolution()
        {
            var leftQueen = new Queen(TeamColour.White, "e4");
            var topRightQueen = new Queen(TeamColour.White, "h4");
            var bottomRightQueen = new Queen(TeamColour.White, "h1");

            var leftQueenAction = new Action(leftQueen, "e1", ActionType.Move);
            var topRightQueenAction = new Action(topRightQueen, "e1", ActionType.Move);
            var bottomRightQueenAction = new Action(bottomRightQueen, "e1", ActionType.Move);

            var ambiguousActions = new List<Action> { leftQueenAction, topRightQueenAction, bottomRightQueenAction };

            Assert.Equal("Qe1", leftQueenAction.AlgebraicNotation);
            Assert.Equal("Qe1", topRightQueenAction.AlgebraicNotation);
            Assert.Equal("Qe1", bottomRightQueenAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(ambiguousActions);

            Assert.Equal("Qe4e1", leftQueenAction.AlgebraicNotation);
            Assert.Equal("Qh4e1", topRightQueenAction.AlgebraicNotation);
            Assert.Equal("Qh1e1", bottomRightQueenAction.AlgebraicNotation);
        }

        [Fact]
        public void IdentialKnightActions_ThreeKnights_FileRankResolution()
        {
            var topLeftKnight = new Knight(TeamColour.White, "a8");
            var bottomLeftKnight = new Knight(TeamColour.White, "a4");
            var rightKnight = new Knight(TeamColour.White, "c8");

            var topLeftAction = new Action(topLeftKnight, "b6", ActionType.Capture);
            var bottomLeftAction = new Action(bottomLeftKnight, "b6", ActionType.Capture);
            var rightAction = new Action(rightKnight, "b6", ActionType.Capture);

            var ambiguousActions = new List<Action> { topLeftAction, bottomLeftAction, rightAction };

            Assert.Equal("Nxb6", topLeftAction.AlgebraicNotation);
            Assert.Equal("Nxb6", bottomLeftAction.AlgebraicNotation);
            Assert.Equal("Nxb6", rightAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(ambiguousActions);

            Assert.Equal("Na8xb6", topLeftAction.AlgebraicNotation);
            Assert.Equal("Na4xb6", bottomLeftAction.AlgebraicNotation);
            Assert.Equal("Nc8xb6", rightAction.AlgebraicNotation);
        }

        // A list of unambiguous actions should be not changed
        [Fact]
        public void UnrequiredAmbiguityResolution_NoAmbiguity()
        {
            var leftRook = new Rook(TeamColour.White, "a7");
            var rightRook = new Rook(TeamColour.White, "f3");

            var leftRookAction = new Action(leftRook, "d7", ActionType.Move);
            var rightRookAction = new Action(rightRook, "f6", ActionType.Move);

            var nonAmbiguousActions = new List<Action> { leftRookAction, rightRookAction };

            Assert.Equal("Rd7", leftRookAction.AlgebraicNotation);
            Assert.Equal("Rf6", rightRookAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(nonAmbiguousActions);

            Assert.Equal("Rd7", leftRookAction.AlgebraicNotation);
            Assert.Equal("Rf6", rightRookAction.AlgebraicNotation);
        }

        // Only the ambiguous actions in a list of partly-ambiguous actions should be changed
        [Fact]
        public void UnrequiredAmbiguityResolution_PartlyAmbiguous()
        {
            var leftRook = new Rook(TeamColour.White, "a7");
            var topRightRook = new Rook(TeamColour.White, "f3");
            var bottomRightRook = new Rook(TeamColour.White, "f1");

            var leftAction = new Action(leftRook, "f7", ActionType.Move);
            var topRightAction = new Action(topRightRook, "f2", ActionType.Move);
            var bottomRightAction = new Action(bottomRightRook, "f2", ActionType.Move);

            var partlyAmbiguousActions = new List<Action> { leftAction, topRightAction, bottomRightAction };

            Assert.Equal("Rf7", leftAction.AlgebraicNotation);
            Assert.Equal("Rf2", topRightAction.AlgebraicNotation);
            Assert.Equal("Rf2", bottomRightAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(partlyAmbiguousActions);

            Assert.Equal("Rf7", leftAction.AlgebraicNotation);
            Assert.Equal("R3f2", topRightAction.AlgebraicNotation);
            Assert.Equal("R1f2", bottomRightAction.AlgebraicNotation);
        }

        // Multiple sets of ambiguous actions should be disambiguated within the same list of actions
        [Fact]
        public void MultipleSetsAmbiguityResolution()
        {
            var leftRookAction = new Action(new Rook(TeamColour.White, "a8"), "c8", ActionType.Move);
            var rightRookAction = new Action(new Rook(TeamColour.White, "f8"), "c8", ActionType.Move);
            var topKnightAction = new Action(new Knight(TeamColour.White, "b4"), "d3", ActionType.Capture);
            var bottomKnightAction = new Action(new Knight(TeamColour.White, "b2"), "d3", ActionType.Capture);

            var ambiguousActions = new List<Action> { leftRookAction, rightRookAction, topKnightAction, bottomKnightAction };

            Assert.Equal("Rc8", leftRookAction.AlgebraicNotation);
            Assert.Equal("Rc8", rightRookAction.AlgebraicNotation);
            Assert.Equal("Nxd3", topKnightAction.AlgebraicNotation);
            Assert.Equal("Nxd3", bottomKnightAction.AlgebraicNotation);

            AlgebraicNotationUtils.AlgebraicNotationAmbiguityResolution(ambiguousActions);

            // Rooks disambiguated using file, Knights disambiguated using rank
            Assert.Equal("Rac8", leftRookAction.AlgebraicNotation);
            Assert.Equal("Rfc8", rightRookAction.AlgebraicNotation);
            Assert.Equal("N4xd3", topKnightAction.AlgebraicNotation);
            Assert.Equal("N2xd3", bottomKnightAction.AlgebraicNotation);
        }
    }
}
