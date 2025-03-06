﻿using System;
using ETML.Utils.Math.GameMath.Core;
using GameMath;

namespace ETML.Utils.Math.GameMath.Geometry
{
    /// <summary>
    ///   Axis-aligned box with integer position and extents.
    ///   Note that boxes are immutable.
    /// </summary>
    public struct BoxI : IEquatable<BoxI>
    {
        #region Fields

        /// <summary>
        ///   Position of this box.
        /// </summary>
        private readonly Vector3I position;

        /// <summary>
        ///   Size of this box, its width, height and depth.
        /// </summary>
        private readonly Vector3I size;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new box with the specified position and size.
        /// </summary>
        /// <param name="x">
        ///   X-component of the box position.
        /// </param>
        /// <param name="y">
        ///   Y-component of the box position.
        /// </param>
        /// <param name="z">
        ///   Z-component of the box position.
        /// </param>
        /// <param name="width">
        ///   Box width.
        /// </param>
        /// <param name="height">
        ///   Box height.
        /// </param>
        /// <param name="depth">
        ///   Box depth.
        /// </param>
        public BoxI(int x, int y, int z, int width, int height, int depth)
            : this(new Vector3I(x, y, z), new Vector3I(width, height, depth))
        {
        }

        /// <summary>
        ///   Constructs a new box with the specified position and size.
        /// </summary>
        /// <param name="x">
        ///   X-component of the box position.
        /// </param>
        /// <param name="y">
        ///   Y-component of the box position.
        /// </param>
        /// <param name="z">
        ///   Z-component of the box position.
        /// </param>
        /// <param name="size">
        ///   Box extents.
        /// </param>
        public BoxI(int x, int y, int z, Vector3I size)
            : this(new Vector3I(x, y, z), size)
        {
        }

        /// <summary>
        ///   Constructs a new box with the specified position and size.
        /// </summary>
        /// <param name="position">
        ///   Box position.
        /// </param>
        /// <param name="width">
        ///   Box width.
        /// </param>
        /// <param name="height">
        ///   Box height.
        /// </param>
        /// <param name="depth">
        ///   Box depth.
        /// </param>
        public BoxI(Vector3I position, int width, int height, int depth)
            : this(position, new Vector3I(width, height, depth))
        {
        }

        /// <summary>
        ///   Constructs a new box with the specified position and size.
        /// </summary>
        /// <param name="position">
        ///   Box position.
        /// </param>
        /// <param name="size">
        ///   Box size.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   Any component of <paramref name="size"/> is zero or negative.
        /// </exception>
        public BoxI(Vector3I position, Vector3I size)
        {
            if (size.X < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Width must be non-negative.");
            }

            if (size.Y < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Height must be non-negative.");
            }

            if (size.Z < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Depth must be non-negative.");
            }

            this.position = position;
            this.size = size;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the position of the center of this box.
        /// </summary>
        public Vector3I Center
        {
            get
            {
                return this.Position + (this.Size / 2);
            }
        }

        /// <summary>
        ///   Gets or sets the depth of this box.
        /// </summary>
        public int Depth
        {
            get
            {
                return this.Size.Z;
            }
        }

        /// <summary>
        ///   Gets or sets the height of this box.
        /// </summary>
        public int Height
        {
            get
            {
                return this.Size.Y;
            }
        }

        /// <summary>
        ///   Gets the maximum x-component of this box.
        /// </summary>
        public int MaxX
        {
            get
            {
                return this.Position.X + this.Size.X;
            }
        }

        /// <summary>
        ///   Gets the maximum y-component of this box.
        /// </summary>
        public int MaxY
        {
            get
            {
                return this.Position.Y + this.Size.Y;
            }
        }

        /// <summary>
        ///   Gets the maximum z-component of this box.
        /// </summary>
        public int MaxZ
        {
            get
            {
                return this.Position.Z + this.Size.Z;
            }
        }

        /// <summary>
        ///   Position of this box.
        /// </summary>
        public Vector3I Position
        {
            get
            {
                return this.position;
            }
        }

        /// <summary>
        ///   Gets or sets the size of this box, its width, height and depth.
        /// </summary>
        public Vector3I Size
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>
        ///   Gets the volume of this box, the product of its width, height and depth.
        /// </summary>
        public int Volume
        {
            get
            {
                return this.Size.X * this.Size.Y * this.Size.Z;
            }
        }

        /// <summary>
        ///   Gets or sets the width of this box.
        /// </summary>
        public int Width
        {
            get
            {
                return this.Size.X;
            }
        }

        /// <summary>
        ///   Gets or sets the x-component of the position of this box.
        /// </summary>
        public int X
        {
            get
            {
                return this.Position.X;
            }
        }

        /// <summary>
        ///   Gets or sets the y-component of the position of this box.
        /// </summary>
        public int Y
        {
            get
            {
                return this.Position.Y;
            }
        }

        /// <summary>
        ///   Gets or sets the z-component of the position of this box.
        /// </summary>
        public int Z
        {
            get
            {
                return this.Position.Z;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether this box entirely encompasses the passed other one.
        /// </summary>
        /// <param name="other">
        ///   Box to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this box contains <paramref name="other" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(BoxI other)
        {
            return (this.X <= other.X && this.MaxX >= other.MaxX) && (this.Y <= other.Y && this.MaxY >= other.MaxY)
                   && (this.Z <= other.Z && this.MaxZ >= other.MaxZ);
        }

        /// <summary>
        ///   Checks whether this box contains the point denoted by the specified vector.
        /// </summary>
        /// <param name="point">
        ///   Point to check.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if this box contains <paramref name="point" />, and <c>false</c> otherwise.
        /// </returns>
        public bool Contains(Vector3I point)
        {
            return point.X.IsWithinBounds(this.X, this.MaxX) && point.Y.IsWithinBounds(this.Y, this.MaxY)
                   && point.Z.IsWithinBounds(this.Z, this.MaxZ);
        }

        /// <summary>
        ///   Compares the passed box to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Box to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both boxes are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(BoxI other)
        {
            return this.Position.Equals(other.Position) && this.Size.Equals(other.Size);
        }

        /// <summary>
        ///   Compares the passed box to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Box to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both boxes are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj != null && obj.GetType() == this.GetType() && this.Equals((BoxI)obj);
        }

        /// <summary>
        ///   Gets the hash code of this box.
        /// </summary>
        /// <returns>
        ///   Hash code of this box.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Position.GetHashCode() * 397) ^ this.Size.GetHashCode();
            }
        }

        /// <summary>
        ///   Compares the passed boxes for equality.
        /// </summary>
        /// <param name="first">
        ///   First box to compare.
        /// </param>
        /// <param name="second">
        ///   Second box to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both boxes are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(BoxI first, BoxI second)
        {
            return first.Equals(second);
        }

        /// <summary>
        ///   Compares the passed boxes for inequality.
        /// </summary>
        /// <param name="first">
        ///   First box to compare.
        /// </param>
        /// <param name="second">
        ///   Second box to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both boxes are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(BoxI first, BoxI second)
        {
            return !(first == second);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this box.
        /// </summary>
        /// <returns>
        ///   This box as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Position: {0}, Size: {1}", this.Position, this.Size);
        }

        #endregion
    }
}