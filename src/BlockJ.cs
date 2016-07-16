using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Tetris
{
    /// <summary>
    /// Derived from the base <see cref="Block"/> class, each instance of <see cref="BlockJ"/> takes shape of the letter J.
    /// </summary>
    public class BlockJ : Block
    {
        /// <summary>
        /// Initialises a <see cref="BlockJ"/> instance.
        /// </summary>
        /// <param name="startPoint">Raw starting position of the block.</param>
        /// <param name="cellWidth">Width of a block cell.</param>
        public BlockJ(Point2D startPoint, int cellWidth) : base(startPoint, cellWidth, SwinGame.ColorTurquoise(), AppConfig.Background)
        {

        }

        /// <summary>
        /// Constructs the block based on its raw starting position.
        /// </summary>
        public override void Construct()
        {
            base.Construct();
            _cells[0][1].Occupied = true;
            _cells[1][1].Occupied = true;
            _cells[2][0].Occupied = true;
            _cells[2][1].Occupied = true;
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
            if (_angle == 0f)
            {
                _cells[1][0].Occupied = true;
                _cells[1][1].Occupied = true;
                _cells[1][2].Occupied = true;
                _cells[2][2].Occupied = true;
            }
            else if (_angle == 90f)
            {
                _cells[0][1].Occupied = true;
                _cells[1][1].Occupied = true;
                _cells[2][0].Occupied = true;
                _cells[2][1].Occupied = true;
            }
            else if (_angle == 180f)
            {
                _cells[0][0].Occupied = true;
                _cells[1][0].Occupied = true;
                _cells[1][1].Occupied = true;
                _cells[1][2].Occupied = true;
            }
            else if (_angle == 270f)
            {
                _cells[0][1].Occupied = true;
                _cells[0][2].Occupied = true;
                _cells[1][1].Occupied = true;
                _cells[2][1].Occupied = true;
            }
        }
    }
}
