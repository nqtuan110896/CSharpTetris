using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Tetris
{
    /// <summary>
    /// 
    /// </summary>
    public class Board
    {
        private Color _background;
        private Cell[][] _cells;
        private Color _foreground;

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public Color Foreground
        {
            get { return _foreground; }
            set { _foreground = value; }
        }

        /// <summary>
        /// Gets a specific row of cells.
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <returns>A row of cell (as an array of <see cref="Cell"/>).</returns>
        public Cell[] this[int row]
        {
            get { return _cells[row]; }
        }

        /// <summary>
        /// Gets or sets a specific cell.
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <param name="col">Column index.</param>
        /// <returns>Cell at the specific row and column indices.</returns>
        public Cell this[int row, int col]
        {
            get { return _cells[row][col]; }
            set { _cells[row][col] = value; }
        }

        /// <summary>
        /// Initialises a <see cref="Board"/> instance.
        /// </summary>
        /// <param name="startPoint">Raw starting position of the block.</param>
        /// <param name="cellWidth">Width of a block cell.</param>
        /// <param name="background">Block background colour.</param>
        /// <param name="foreground">Block foreground colour.</param>
        public Board(Point2D startPoint, int cellWidth, Color background, Color foreground)
        {
            _cells = new Cell[20][];
            for (int row = 0; row < _cells.Length; ++row) _cells[row] = new Cell[10];

            _cells[0][0] = new Cell(startPoint, cellWidth);
        }
    }
}
