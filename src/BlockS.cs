using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Tetris
{
    /// <summary>
    /// Derived from the base <see cref="Block"/> class, each instance of <see cref="BlockS"/> takes shape of the letter S.
    /// </summary>
    public class BlockS : Block
    {
        /// <summary>
        /// Initialises a <see cref="BlockZ"/> instance.
        /// </summary>
        /// <param name="startPoint">Raw starting position of the block.</param>
        /// <param name="cellWidth">Width of a block cell.</param>
        public BlockS(Point2D startPoint, int cellWidth) : base(startPoint, cellWidth, SwinGame.RGBColor(128, 255, 0), AppConfig.Background)
        {

        }

        /// <summary>
        /// Constructs the block based on its raw starting position.
        /// </summary>
        public override void Construct()
        {
            base.Construct();
            _cells[0][1].Occupied = true;
            _cells[0][2].Occupied = true;
            _cells[1][0].Occupied = true;
            _cells[1][1].Occupied = true;
        }

        /// <summary>
        /// Rotates the block to a new angle.
        /// </summary>
        /// <param name="rotateAngle">Angle to rotate.</param>
        public override void Rotate(float rotateAngle)
        {
            base.Rotate(rotateAngle);
            for (int row = 0; row < _cells.Length; ++row)
            {
                for (int col = 0; col < _cells[row].Length; ++col) _cells[col][row].Occupied = false;
            }
            if (_angle % 180 == 0f)
            {
                _cells[0][0].Occupied = true;
                _cells[1][0].Occupied = true;
                _cells[1][1].Occupied = true;
                _cells[2][1].Occupied = true;
            }
            else if (_angle % 180 == 90f)
            {
                _cells[0][1].Occupied = true;
                _cells[0][2].Occupied = true;
                _cells[1][0].Occupied = true;
                _cells[1][1].Occupied = true;
            }
        }
    }
}
