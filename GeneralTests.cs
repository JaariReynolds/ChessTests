using Chess.Classes;
using Chess.Types;

namespace ChessTests
{
    public class GeneralTests
    {
        [Fact]
        public void WithinBounds_ValidBounds_True()
        {
            var isWithinBounds = ChessUtils.IsWithinBounds(4, 5);
            Assert.True(isWithinBounds);
        }

        [Fact]
        public void WithinBounds_SquareArgument_True()
        {
            var isWithinBounds = ChessUtils.IsWithinBounds(new Square(3, 1));
            Assert.True(isWithinBounds);
        }

        [Fact]
        public void WithinBounds_InvalidBounds_False()
        {
            var isWithinBounds = ChessUtils.IsWithinBounds(4, 8);
            Assert.False(isWithinBounds);
        }

        [Fact]
        public void WithinBounds_NegativeBounds_False()
        {
            var isWithinBounds = ChessUtils.IsWithinBounds(-3, 2);
            Assert.False(isWithinBounds);
        }

        /// <summary>
        /// A Square should throw an argument exception when one or more of the arguments is above the valid square thresholds
        /// </summary>
        [Fact]
        public void InvalidSquare_AboveLimit_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Square(5, 9));
        }

        /// <summary>
        /// When two squares have the same X and Y properties, they should be equal
        /// </summary>
        [Fact]
        public void SquareComparison_EqualSquares()
        {
            var squareOne = new Square(5, 3);
            var squareTwo = new Square(5, 3);

            Assert.Equal(squareOne, squareTwo);
        }

        /// <summary>
        /// When two squares do not have the same X and Y properties, they should not be equal
        /// </summary>
        [Fact]
        public void SquareComparison_NotEqualSquares()
        {
            var squareOne = new Square(5, 3);
            var squareTwo = new Square(1, 3);

            Assert.NotEqual(squareOne, squareTwo);
        }


    }
}
