using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Tetris
{
    public class Cell
    {
        private bool _occupied;
        private Point2D _position;
        private int _width;

        /// <summary>
        /// Gets or sets whether the cell is occupied (i.e. filled with colour).
        /// </summary>
        public bool Occupied
        {
            get { return _occupied; }
            set { _occupied = value; }
        }

        /// <summary>
        /// Gets or sets the cell position.
        /// </summary>
        public Point2D Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// Gets or sets the cell width.
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Initialises a <see cref="Cell"/> instance.
        /// </summary>
        /// <param name="position">Cell position.</param>
        /// <param name="width">Cell width.</param>
        /// <param name="occupied">Indicates whether the cell should be occupied.</param>
        public Cell(Point2D position, int width, bool occupied = false)
        {
            _occupied = occupied;
            _position = position;
            _width = width;
        }

        /// <summary>
        /// Render the occupied cell with provided colours.
        /// </summary>
        /// <param name="background">Cell background colour.</param>
        /// <param name="foreground">Cell foreground colour.</param>
        public void Render(Color background, Color foreground)
        {
            if (_occupied)
            {
                SwinGame.FillRectangle(background, SwinGame.RectangleFrom(_position, _width, _width));
                SwinGame.DrawRectangle(foreground, SwinGame.RectangleFrom(_position, _width, _width));
            }
        }
    }
}
