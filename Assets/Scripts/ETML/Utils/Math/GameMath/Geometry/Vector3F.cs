﻿namespace GameMath
{
    using System;

    /// <summary>
    ///   Vector in three-dimensional space with floating point components. Note that vectors are immutable.
    /// </summary>
    /// <seealso cref="Vector2F"/>
    /// <seealso cref="Vector2I"/>
    /// <seealso cref="Vector3I"/>
    [CLSCompliant(true)]
    public struct Vector3F : IEquatable<Vector3F>
    {
        #region Constants

        /// <summary>
        ///   Unit vector in direction of the x axis.
        /// </summary>
        public static readonly Vector3F UnitX = new Vector3F(1.0f, 0.0f, 0.0f);

        /// <summary>
        ///   Unit vector in direction of the y axis.
        /// </summary>
        public static readonly Vector3F UnitY = new Vector3F(0.0f, 1.0f, 0.0f);

        /// <summary>
        ///   Unit vector in direction of the z axis.
        /// </summary>
        public static readonly Vector3F UnitZ = new Vector3F(0.0f, 0.0f, 1.0f);

        /// <summary>
        ///   Null vector.
        /// </summary>
        public static readonly Vector3F Zero = new Vector3F();

        #endregion

        #region Fields

        /// <summary>
        ///   X-component of this vector.
        /// </summary>
        private readonly float x;

        /// <summary>
        ///   Y-component of this vector.
        /// </summary>
        private readonly float y;

        /// <summary>
        ///   Z-component of this vector.
        /// </summary>
        private readonly float z;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructs a new vector with the specified components.
        /// </summary>
        /// <param name="x">
        ///   X-component of the new vector.
        /// </param>
        /// <param name="y">
        ///   Y-component of the new vector.
        /// </param>
        /// <param name="z">
        ///   Z-component of the new vector.
        /// </param>
        public Vector3F(float x, float y, float z)
            : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the magnitude of this vector.
        /// </summary>
        public float Length
        {
            get
            {
                return MathF.Sqrt(this.LengthSquared);
            }
        }

        /// <summary>
        ///   Gets the squared magnitude of this vector. Faster than <see cref="Length" />.
        /// </summary>
        public float LengthSquared
        {
            get
            {
                return Dot(this, this);
            }
        }

        /// <summary>
        ///   Gets the x-component of this vector.
        /// </summary>
        public float X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        ///   Two-dimensional vector with the x and y component of this vector.
        /// </summary>
        public Vector2F XY
        {
            get
            {
                return new Vector2F(this.X, this.Y);
            }
        }

        /// <summary>
        ///   Two-dimensional vector with the x and z component of this vector.
        /// </summary>
        public Vector2F XZ
        {
            get
            {
                return new Vector2F(this.X, this.Z);
            }
        }

        /// <summary>
        ///   Gets the y-component of this vector.
        /// </summary>
        public float Y
        {
            get
            {
                return this.y;
            }
        }

        /// <summary>
        ///   Two-dimensional vector with the y and z component of this vector.
        /// </summary>
        public Vector2F YZ
        {
            get
            {
                return new Vector2F(this.Y, this.Z);
            }
        }

        /// <summary>
        ///   Gets the z-component of this vector.
        /// </summary>
        public float Z
        {
            get
            {
                return this.z;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Adds the passed vectors.
        /// </summary>
        /// <param name="v">
        ///   First summand.
        /// </param>
        /// <param name="w">
        ///   Second summand.
        /// </param>
        /// <returns>
        ///   Sum of the passed vectors.
        /// </returns>
        public static Vector3F Add(Vector3F v, Vector3F w)
        {
            return v + w;
        }

        /// <summary>
        ///   Adds the passed vector to this one, returning the sum of both vectors.
        /// </summary>
        /// <param name="v">
        ///   Vector to add.
        /// </param>
        /// <returns>
        ///   Sum of both vectors.
        /// </returns>
        public Vector3F Add(Vector3F v)
        {
            return Add(this, v);
        }

        /// <summary>
        ///   Computes the cross product of the passed vectors.
        /// </summary>
        /// <remarks>
        ///   See http://en.wikipedia.org/wiki/Cross_product for details.
        /// </remarks>
        /// <param name="v">
        ///   First vector to compute the cross product of.
        /// </param>
        /// <param name="w">
        ///   Second vector to compute the cross product of.
        /// </param>
        /// <returns>
        ///   Cross product of the passed vectors.
        /// </returns>
        public static Vector3F Cross(Vector3F v, Vector3F w)
        {
            return new Vector3F(
                (v.y * w.z) - (v.z * w.y),
                (v.z * w.x) - (v.x * w.z),
                (v.x * w.y) - (v.y * w.x));
        }

        /// <summary>
        ///   Computes the cross product of the passed vector and this one.
        /// </summary>
        /// <remarks>
        ///   See http://en.wikipedia.org/wiki/Cross_product for details.
        /// </remarks>
        /// <param name="v">
        ///   Vector to compute the cross product of.
        /// </param>
        /// <returns>
        ///   Cross product of the both vectors.
        /// </returns>
        public Vector3F Cross(Vector3F v)
        {
            return Cross(this, v);
        }

        /// <summary>
        ///   Computes the Euclidean distance between the points at <paramref name="p" /> and <paramref name="q" />.
        /// </summary>
        /// <param name="p">
        ///   First point to compute the distance of.
        /// </param>
        /// <param name="q">
        ///   Second point to compute the distance of.
        /// </param>
        /// <returns>
        ///   Euclidean distance between the two passed points.
        /// </returns>
        public static float Distance(Vector3F p, Vector3F q)
        {
            return MathF.Sqrt(DistanceSquared(p, q));
        }

        /// <summary>
        ///   Computes the Euclidean distance between the points denoted by this vector and <paramref name="p" />.
        /// </summary>
        /// <param name="p">
        ///   Point to compute the distance to.
        /// </param>
        /// <returns>
        ///   Euclidean distance between the two points.
        /// </returns>
        public float Distance(Vector3F p)
        {
            return Distance(this, p);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points at <paramref name="p" /> and <paramref name="q" />.
        ///   Faster than <see cref="Distance(Vector3F, Vector3F)" />.
        /// </summary>
        /// <param name="p">
        ///   First point to compute the squared distance of.
        /// </param>
        /// <param name="q">
        ///   Second point to compute the squared distance of.
        /// </param>
        /// <returns>
        ///   Squared Euclidean distance between the two passed points.
        /// </returns>
        public static float DistanceSquared(Vector3F p, Vector3F q)
        {
            var distX = p.x - q.x;
            var distY = p.y - q.y;
            var distZ = p.z - q.z;
            return (distX * distX) + (distY * distY) + (distZ * distZ);
        }

        /// <summary>
        ///   Computes the squared Euclidean distance between the points denoted by this vector and <paramref name="p" />.
        ///   Faster than <see cref="Distance(Vector3F)" />.
        /// </summary>
        /// <param name="p">
        ///   Point to compute the squared distance to.
        /// </param>
        /// <returns>
        ///   Squared Euclidean distance between the two points.
        /// </returns>
        public float DistanceSquared(Vector3F p)
        {
            return DistanceSquared(this, p);
        }

        /// <summary>
        ///   Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Dividend.
        /// </param>
        /// <param name="divisor">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public static Vector3F Divide(Vector3F v, float divisor)
        {
            return v / divisor;
        }

        /// <summary>
        ///   Divides this vector by the specified scalar.
        /// </summary>
        /// <param name="divisor">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public Vector3F Divide(float divisor)
        {
            return Divide(this, divisor);
        }

        /// <summary>
        ///   Computes the dot product of the two passed vectors.
        /// </summary>
        /// <param name="v">
        ///   First vector to compute the dot product of.
        /// </param>
        /// <param name="w">
        ///   Second vector to compute the dot product of.
        /// </param>
        /// <returns>
        ///   Dot product of the two passed vectors.
        /// </returns>
        public static float Dot(Vector3F v, Vector3F w)
        {
            return (v.x * w.x) + (v.y * w.y) + (v.z * w.z);
        }

        /// <summary>
        ///   Computes the dot product of the passed vector and this one.
        /// </summary>
        /// <param name="v">
        ///   Vector to compute the dot product of.
        /// </param>
        /// <returns>
        ///   Dot product of the two vectors.
        /// </returns>
        public float Dot(Vector3F v)
        {
            return Dot(this, v);
        }

        /// <summary>
        ///   Compares the passed vector to this one for equality.
        /// </summary>
        /// <param name="obj">
        ///   Vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Vector3F && this.Equals((Vector3F)obj);
        }

        /// <summary>
        ///   Compares the passed vector to this one for equality.
        /// </summary>
        /// <param name="other">
        ///   Vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public bool Equals(Vector3F other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y) && this.z.Equals(other.z);
        }

        /// <summary>
        ///   Gets the hash code of this vector.
        /// </summary>
        /// <returns>
        ///   Hash code of this vector.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.x.GetHashCode();
                hashCode = (hashCode * 397) ^ this.y.GetHashCode();
                hashCode = (hashCode * 397) ^ this.z.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        ///   Linearly interpolates between the two passed vectors.
        /// </summary>
        /// <param name="v">
        ///   First vector to interpolate.
        /// </param>
        /// <param name="w">
        ///   Second vector to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns <paramref name="v" />, 1 returns <paramref name="w" />.
        /// </param>
        /// <returns>
        ///   Linear interpolation between the two passed vectors.
        /// </returns>
        public static Vector3F Lerp(Vector3F v, Vector3F w, float l)
        {
            var lerpX = Interpolation.Lerp(v.x, w.x, l);
            var lerpY = Interpolation.Lerp(v.y, w.y, l);
            var lerpZ = Interpolation.Lerp(v.z, w.z, l);
            return new Vector3F(lerpX, lerpY, lerpZ);
        }

        /// <summary>
        ///   Linearly interpolates between the passed vector and this one.
        /// </summary>
        /// <param name="v">
        ///   Vector to interpolate.
        /// </param>
        /// <param name="l">
        ///   Interpolation parameter. 0 returns this vector, 1 returns <paramref name="v" />.
        /// </param>
        /// <returns>
        ///   Linear interpolation between the two vectors.
        /// </returns>
        public Vector3F Lerp(Vector3F v, float l)
        {
            return Lerp(this, v, l);
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <param name="factor">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector3F Multiply(Vector3F v, float factor)
        {
            return factor * v;
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="factor">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector3F Multiply(float factor, Vector3F v)
        {
            return factor * v;
        }

        /// <summary>
        ///   Multiplies this vector with the specified scalar.
        /// </summary>
        /// <param name="factor">
        ///   Scalar to multiply this vector with.
        /// </param>
        /// <returns>
        ///   Product of this vector and the scalar.
        /// </returns>
        public Vector3F Multiply(float factor)
        {
            return Multiply(factor, this);
        }

        /// <summary>
        ///   Normalizes the passed vector, returning a unit vector with the same orientation.
        ///   If the passed vector is the zero vector, the zero vector is returned instead.
        /// </summary>
        /// <param name="v">
        ///   Vector to normalize.
        /// </param>
        /// <returns>
        ///   Normalized passed vector.
        /// </returns>
        public static Vector3F Normalize(Vector3F v)
        {
            return v / v.Length;
        }

        /// <summary>
        ///   Normalizes this vector, returning a unit vector with the same orientation.
        ///   If this passed vector is the zero vector, the zero vector is returned instead.
        /// </summary>
        /// <returns>
        ///   Normalized vector.
        /// </returns>
        public Vector3F Normalize()
        {
            return Normalize(this);
        }

        /// <summary>
        ///   Adds the passed vectors.
        /// </summary>
        /// <param name="v">
        ///   First summand.
        /// </param>
        /// <param name="w">
        ///   Second summand.
        /// </param>
        /// <returns>
        ///   Sum of the passed vectors.
        /// </returns>
        public static Vector3F operator +(Vector3F v, Vector3F w)
        {
            return new Vector3F(v.x + w.x, v.y + w.y, v.z + w.z);
        }

        /// <summary>
        ///   Divides the passed vector by the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Dividend.
        /// </param>
        /// <param name="divisor">
        ///   Divisor.
        /// </param>
        /// <returns>
        ///   Vector divided by the specified scalar.
        /// </returns>
        public static Vector3F operator /(Vector3F v, float divisor)
        {
            return new Vector3F(v.x / divisor, v.y / divisor, v.z / divisor);
        }

        /// <summary>
        ///   Compares the passed vectors for equality.
        /// </summary>
        /// <param name="v">
        ///   First vector to compare.
        /// </param>
        /// <param name="w">
        ///   Second vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if both vectors are equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(Vector3F v, Vector3F w)
        {
            return v.Equals(w);
        }

        /// <summary>
        ///   Implicitly converts the passed vector with integer components to
        ///   a vector with floating point components.
        /// </summary>
        /// <param name="v">Vector to convert.</param>
        /// <returns>Passed vector with floating point components.</returns>
        public static implicit operator Vector3F(Vector3I v)
        {
            return new Vector3F(v.X, v.Y, v.Z);
        }

        /// <summary>
        ///   Implicitly converts the passed two-dimensional vector to
        ///   a three-dimensional vector by using zero as z component.
        /// </summary>
        /// <param name="v">Vector to convert.</param>
        /// <returns>Passed vector as three-dimensional vector.</returns>
        public static implicit operator Vector3F(Vector2F v)
        {
            return new Vector3F(v.X, v.Y, 0.0f);
        }

        /// <summary>
        ///   Implicitly converts the passed two-dimensional vector with integer components to
        ///   a three-dimensional vector with floating point components by using zero as z component.
        /// </summary>
        /// <param name="v">Vector to convert.</param>
        /// <returns>Passed vector as three-dimensional vector with floating point components..</returns>
        public static implicit operator Vector3F(Vector2I v)
        {
            return new Vector3F(v.X, v.Y, 0.0f);
        }

        /// <summary>
        ///   Compares the passed vectors for inequality.
        /// </summary>
        /// <param name="v">
        ///   First vector to compare.
        /// </param>
        /// <param name="w">
        ///   Second vector to compare.
        /// </param>
        /// <returns>
        ///   <c>true</c>, if the vectors are not equal, and <c>false</c> otherwise.
        /// </returns>
        public static bool operator !=(Vector3F v, Vector3F w)
        {
            return !(v == w);
        }

        /// <summary>
        ///   Computes the dot product of the two passed vectors.
        /// </summary>
        /// <param name="v">
        ///   First vector to compute the dot product of.
        /// </param>
        /// <param name="w">
        ///   Second vector to compute the dot product of.
        /// </param>
        /// <returns>
        ///   Dot product of the two passed vectors.
        /// </returns>
        public static float operator *(Vector3F v, Vector3F w)
        {
            return Dot(v, w);
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <param name="factor">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector3F operator *(Vector3F v, float factor)
        {
            return factor * v;
        }

        /// <summary>
        ///   Multiplies the passed vector with the specified scalar.
        /// </summary>
        /// <param name="factor">
        ///   Scalar to multiply the vector with.
        /// </param>
        /// <param name="v">
        ///   Vector to multiply.
        /// </param>
        /// <returns>
        ///   Product of the vector and the scalar.
        /// </returns>
        public static Vector3F operator *(float factor, Vector3F v)
        {
            return new Vector3F(v.x * factor, v.y * factor, v.z * factor);
        }

        /// <summary>
        ///   Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="v">
        ///   Vector to subtract from.
        /// </param>
        /// <param name="w">
        ///   Vector to subtract.
        /// </param>
        /// <returns>
        ///   Difference of both vectors.
        /// </returns>
        public static Vector3F operator -(Vector3F v, Vector3F w)
        {
            return new Vector3F(v.x - w.x, v.y - w.y, v.z - w.z);
        }

        /// <summary>
        ///   Reflects the passed vector off the plane defined by the specified normal.
        /// </summary>
        /// <remarks>
        ///   See http://www.blitzbasic.com/Community/posts.php?topic=52511 for details.
        /// </remarks>
        /// <param name="v">Vector to reflect.</param>
        /// <param name="n">Normal of the plane to reflect off.</param>
        /// <returns>Reflected vector.</returns>
        public static Vector3F Reflect(Vector3F v, Vector3F n)
        {
            return v - (2 * n * (n * v));
        }

        /// <summary>
        ///   Reflects this off the plane defined by the specified normal.
        /// </summary>
        /// <param name="n">Normal of the plane to reflect off.</param>
        /// <returns>Reflected vector.</returns>
        public Vector3F Reflect(Vector3F n)
        {
            return Reflect(this, n);
        }

        /// <summary>
        ///   Subtracts the second vector from the first one.
        /// </summary>
        /// <param name="v">
        ///   Vector to subtract from.
        /// </param>
        /// <param name="w">
        ///   Vector to subtract.
        /// </param>
        /// <returns>
        ///   Difference of both vectors.
        /// </returns>
        public static Vector3F Subtract(Vector3F v, Vector3F w)
        {
            return v - w;
        }

        /// <summary>
        ///   Subtracts the passed vector from this one.
        /// </summary>
        /// <param name="v">
        ///   Vector to subtract.
        /// </param>
        /// <returns>
        ///   Difference of both vectors.
        /// </returns>
        public Vector3F Subtract(Vector3F v)
        {
            return Subtract(this, v);
        }

        /// <summary>
        ///   Returns a <see cref="string" /> representation of this vector.
        /// </summary>
        /// <returns>
        ///   This vector as <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", this.x, this.y, this.z);
        }

        /// <summary>
        ///   Returns this vector with its x component changed to the specified value.
        /// </summary>
        /// <param name="newX">X component of the new vector.</param>
        /// <returns>This vector with its x component changed to the specified value. </returns>
        public Vector3F WithX(float newX)
        {
            return new Vector3F(newX, this.Y, this.Z);
        }

        /// <summary>
        ///   Returns this vector with its y component changed to the specified value.
        /// </summary>
        /// <param name="newY">Y component of the new vector.</param>
        /// <returns>This vector with its y component changed to the specified value. </returns>
        public Vector3F WithY(float newY)
        {
            return new Vector3F(this.X, newY, this.Z);
        }

        /// <summary>
        ///   Returns this vector with its z component changed to the specified value.
        /// </summary>
        /// <param name="newZ">Z component of the new vector.</param>
        /// <returns>This vector with its z component changed to the specified value. </returns>
        public Vector3F WithZ(float newZ)
        {
            return new Vector3F(this.X, this.Y, newZ);
        }

        #endregion
    }
}