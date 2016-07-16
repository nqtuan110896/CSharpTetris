using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Tetris
{
    /// <summary>
    /// Base class for block, which needs to be inherited before use.
    /// </summary>
    public abstract class Block
    {
        protected float _angle;
        protected Color _background;
        protected Cell[][] _cells;
        protected Color _foreground;
        protected float _speed;
        protected Vector _tempVelocity;

        /// <summary>
        /// Gets or sets the block angle.
        /// </summary>
        public float Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        /// <summary>
        /// Gets or sets the block background colour.
        /// </summary>
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        /// <summary>
        /// Gets the bottom-most position of the block.
        /// </summary>
        public float Bottom
        {
            get
            {
                float bottom = float.MinValue;
                foreach (Cell[] row in _cells)
                {
                    foreach (Cell c in row)
                    {
                        if (c.Occupied && c.Position.Y + c.Width > bottom) bottom = c.Position.Y + c.Width;
                    }
                }
                return bottom;
            }
        }

        /// <summary>
        /// Gets or sets the block foreground colour.
        /// </summary>
        public Color Foreground
        {
            get { return _foreground; }
            set { _background = value; }
        }

        /// <summary>
        /// Gets the left-most position of the block.
        /// </summary>
        public float Left
        {
            get
            {
                float left = float.MaxValue;
                foreach (Cell[] row in _cells)
                {
                    foreach (Cell c in row)
                    {
                        if (c.Occupied && c.Position.X < left) left = c.Position.X;
                    }
                }
                return left;
            }
        }

        /// <summary>
        /// Gets the block origin.
        /// </summary>
        public Point2D Origin
        {
            get { return _cells[0][0].Position; }
        }

        /// <summary>
        /// Gets the right-most position of the block.
        /// </summary>
        public float Right
        {
            get
            {
                float right = float.MinValue;
                foreach (Cell[] row in _cells)
                {
                    foreach (Cell c in row)
                    {
                        if (c.Occupied && c.Position.X + c.Width > right) right = c.Position.X + c.Width;
                    }
                }
                return right;
            }
        }

        /// <summary>
        /// Gets or sets the block speed.
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// Gets the top-most position of the block.
        /// </summary>
        public float Top
        {
            get
            {
                float top = float.MaxValue;
                foreach (Cell[] row in _cells)
                {
                    foreach (Cell c in row)
                    {
                        if (c.Occupied && c.Position.Y < top) top = c.Position.Y;
                    }
                }
                return top;
            }
        }

        
        public int TotalWidth
        {
            get { return _cells[0][0].Width * _cells.Length; }
        }

        /// <summary>
        /// Initialises a <see cref="Block"/> instance.
        /// </summary>
        /// <param name="startPoint">Raw starting position of the block.</param>
        /// <param name="cellWidth">Width of a block cell.</param>
        /// <param name="background">Block background colour.</param>
        /// <param name="foreground">Block foreground colour.</param>
        public Block(Point2D startPoint, int cellWidth, Color background, Color foreground)
        {
            _angle = 90;
            _background = background;
            _foreground = foreground;
            _speed = cellWidth;
            _tempVelocity = SwinGame.VectorTo(0, 0);

            _cells = new Cell[4][];
            for (int row = 0; row < _cells.Length; ++row) _cells[row] = new Cell[4];

            _cells[0][0] = new Cell(startPoint, cellWidth);
        }

        /// <summary>
        /// Constructs the block based on its raw starting position.
        /// </summary>
        public virtual void Construct()
        {
            float cellWidthFloat = Convert.ToSingle(_cells[0][0].Width);

            for (int row = 0; row < _cells.Length; ++row)
            {
                for (int col = 0; col < _cells[row].Length; ++col)
                {
                    Point2D startPoint = _cells[0][0].Position.Add(SwinGame.PointAt(col * cellWidthFloat, row * cellWidthFloat));
                    _cells[row][col] = new Cell(startPoint, _cells[0][0].Width);
                }
            }
        }

        /// <summary>
        /// Drops the block at larger speed.
        /// </summary>
        public void Drop()
        {
            Fall(32f);
        }

        /// <summary>
        /// Makes the block fall.
        /// </summary>
        /// <param name="speedModifier">Modifier of the block natural speed. Default value is 1.</param>
        public void Fall(float speedModifier = 1f)
        {
            float speedPerFrame = _speed * speedModifier * AppSystem.DeltaTime / 1000;
            _tempVelocity = _tempVelocity.AddVector(SwinGame.VectorFromAngle(90, speedPerFrame));

            if (_tempVelocity.Magnitude > _speed)
            {
                Vector offset = SwinGame.VectorFromAngle(90, _speed);
                for (int row = 0; row < _cells.Length; ++row)
                {
                    for (int col = 0; col < _cells[row].Length; ++col) _cells[row][col].Position = SwinGame.PointAt(_cells[row][col].Position, offset);
                }
                _tempVelocity = SwinGame.VectorTo(0, 0);
            }
        }

        /// <summary>
        /// Renders the block.
        /// </summary>
        public void Render()
        {
            foreach (Cell[] row in _cells)
            {
                foreach (Cell c in row) c.Render(_background, _foreground);
            }
        }

        /// <summary>
        /// Rotates the block to a new angle.
        /// </summary>
        /// <param name="rotateAngle">Angle to rotate.</param>
        public virtual void Rotate(float rotateAngle)
        {
            _angle += rotateAngle;
            while (_angle >= 360f) _angle -= 360f;
            while (_angle < 0f) _angle += 360f;
        }
    }
}
