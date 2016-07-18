using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Tetris
{
    /// <summary>
    /// Derived from the base <see cref="Block"/> class, each instance of <see cref="BlockO"/> takes shape of the letter O.
    /// </summary>
    public class BlockO : Block
    {
        /// <summary>
        /// Initialises a <see cref="BlockO"/> instance.
        /// </summary>
        /// <param name="startPoint">Raw starting position of the block.</param>
        /// <param name="cellWidth">Width of a block cell.</param>
        public BlockO(Point2D startPoint, int cellWidth) : base(startPoint, cellWidth, SwinGame.RGBColor(255, 255, 0), AppConfig.Background)
        {

        }

        /// <summary>
        /// Constructs the block based on its raw starting position.
        /// </summary>
        public override void Construct()
        {
            base.Construct();
            for (int row = 1; row < _cells.Length - 1; ++row)
            {
                for (int col = 1; col < _cells.Length - 1; ++col) _cells[row][col].Occupied = true;
            }
        }
    }
}
