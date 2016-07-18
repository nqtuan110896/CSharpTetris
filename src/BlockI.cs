using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Tetris
{
    /// <summary>
    /// Derived from the base <see cref="Block"/> class, each instance of <see cref="BlockI"/> takes shape of the letter I.
    /// </summary>
    public class BlockI : Block
    {
        /// <summary>
        /// Initialises a <see cref="BlockI"/> instance.
        /// </summary>
        /// <param name="startPoint">Raw starting position of the block.</param>
        /// <param name="cellWidth">Width of a block cell.</param>
        public BlockI(Point2D startPoint, int cellWidth) : base(startPoint, cellWidth, SwinGame.RGBColor(0, 255, 255), AppConfig.Background)
        {

        }

        /// <summary>
        /// Constructs the block based on its raw starting position.
        /// </summary>
        public override void Construct()
        {
            base.Construct();
            for (int row = 0; row < _cells.Length; ++row) _cells[row][1].Occupied = true;
        }

        /// <summary>
        /// Rotates the block to a new angle.
        /// </summary>
        /// <param name="rotateAngle">Angle to rotate.</param>
        public override void Rotate(float rotateAngle)
        {
            base.Rotate(rotateAngle);
            if (_angle % 180 == 90f)
            {
                for (int row = 0; row < _cells.Length; ++row)
                {
                    for (int col = 0; col < _cells.Length; ++col)
                    {
                        _cells[row][col].Occupied = false;
                        _cells[row][1].Occupied = true;
                    }
                }
            }
            else
            {
                for (int row = 0; row < _cells.Length; ++row)
                {
                    for (int col = 0; col < _cells.Length; ++col)
                    {
                        _cells[row][col].Occupied = false;
                        _cells[1][col].Occupied = true;
                    }
                }
            }
        }
    }
}
