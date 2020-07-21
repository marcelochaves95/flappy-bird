﻿using System;
using System.Runtime.InteropServices;

namespace Kinematics.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2 : IEquatable<Vector2>
    {
        #region Properties

        public float X;
        public float Y;

        public static readonly Vector2 Up = new Vector2(1f, 0f);
        public static readonly Vector2 Down = new Vector2(0f, -1f);
        public static readonly Vector2 Left = new Vector2(-1f, 0f);
        public static readonly Vector2 Right = new Vector2(1f, 0f);
        public static readonly Vector2 One = new Vector2(1f, 1f);
        public static readonly Vector2 Zero = new Vector2(0f, 0f);

        #endregion

        #region Constructors

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2(Vector2 value)
        {
            X = value.X;
            Y = value.Y;
        }

        public Vector2(Vector3 value)
        {
            X = value.X;
            Y = value.Y;
        }

        public Vector2(Vector4 value)
        {
            X = value.X;
            Y = value.Y;
        }

        public Vector2(Quaternion value)
        {
            (float x, float y, _, _) = value;
            X = x;
            Y = y;
        }

        #endregion

        #region Operators

        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.X + value2.X, value1.Y + value2.Y);
        }

        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.X - value2.X, value1.Y - value2.Y);
        }

        public static Vector2 operator -(Vector2 value)
        {
            return new Vector2(-value.X, -value.Y);
        }

        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.X * value2.X, value1.Y * value2.Y);
        }

        public static Vector2 operator *(Vector2 value1, float scalar)
        {
            return new Vector2(value1.X * scalar, value1.Y * scalar);
        }

        public static Vector2 operator *(float scalar, Vector2 vector)
        {
            return new Vector2(vector.X * scalar, vector.Y * scalar);
        }

        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.X / value2.X, value1.Y / value2.Y);
        }

        public static Vector2 operator /(Vector2 vector, float scalar)
        {
            return new Vector2(vector.X / scalar, vector.Y / scalar);
        }

        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            return value1.Equals(value2);
        }

        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            return !value1.Equals(value2);
        }

        public static explicit operator Vector3(Vector2 value)
        {
            return new Vector3(value);
        }

        public static explicit operator Vector4(Vector2 value)
        {
            return new Vector4(value);
        }

        public static explicit operator Quaternion(Vector2 value)
        {
            return new Quaternion(value);
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            return obj is Vector2 vector && Equals(vector);
        }

        public bool Equals(Vector2 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString()
        {
            return $"[Vector2] X({X}) Y({Y})";
        }

        #endregion

        #region Public Methods

        public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
        {
            return new Vector2(Mathf.Barycentric(value1.X, value2.X, value3.X, amount1, amount2), Mathf.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2));
        }

        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
        {
            return new Vector2(Mathf.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount), Mathf.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount));
        }

        public void Ceiling()
        {
            X = Mathf.Ceiling(X);
            Y = Mathf.Ceiling(Y);
        }

        public static Vector2 Ceiling(Vector2 value)
        {
            value.X = Mathf.Ceiling(value.X);
            value.Y = Mathf.Ceiling(value.Y);
            return value;
        }

        public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
        {
            return new Vector2(Mathf.Clamp(value.X, min.X, max.X), Mathf.Clamp(value.Y, min.Y, max.Y));
        }

        public static float Distance(Vector2 value1, Vector2 value2)
        {
            float v1X = value1.X - value2.X;
            float v2Y = value1.Y - value2.Y;
            return Mathf.Sqrt(v1X * v1X + v2Y * v2Y);
        }

        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            float v1X = value1.X - value2.X;
            float v2Y = value1.Y - value2.Y;
            return v1X * v1X + v2Y * v2Y;
        }

        public static float Dot(Vector2 value1, Vector2 value2)
        {
            return value1.X * value2.X + value1.Y * value2.Y;
        }

        public void Floor()
        {
            X = Mathf.Floor(X);
            Y = Mathf.Floor(Y);
        }

        public static Vector2 Floor(Vector2 value)
        {
            value.X = Mathf.Floor(value.X);
            value.Y = Mathf.Floor(value.Y);
            return value;
        }

        public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float amount)
        {
            return new Vector2(Mathf.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount), Mathf.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount));
        }

        public float Length()
        {
            return Mathf.Sqrt(Mathf.Pow(X, 2) + Mathf.Pow(Y, 2));
        }

        public static float Length(Vector2 v)
        {
            return Mathf.Sqrt(Mathf.Pow(v.X, 2) + Mathf.Pow(v.Y, 2));
        }

        public float LengthSquared()
        {
            return Mathf.Pow(X, 2) + Mathf.Pow(Y, 2);
        }

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            return new Vector2(Mathf.Lerp(value1.X, value2.X, amount), Mathf.Lerp(value1.Y, value2.Y, amount));
        }

        public static Vector2 LerpPrecise(Vector2 value1, Vector2 value2, float amount)
        {
            return new Vector2(Mathf.LerpPrecise(value1.X, value2.X, amount), Mathf.LerpPrecise(value1.Y, value2.Y, amount));
        }

        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            return new Vector2(Mathf.Max(value1.X, value2.X), Mathf.Max(value1.Y, value2.Y));
        }

        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            return new Vector2(Mathf.Min(value1.X, value2.X), Mathf.Min(value1.Y, value2.Y));
        }

        public void Normalize()
        {
            float length = 1.0f / Length();
            X *= length;
            Y *= length;
        }

        public static Vector2 Normalize(Vector2 value)
        {
            float length = 1.0f / Length(value);
            value.X *= length;
            value.Y *= length;
            return value;
        }

        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            Vector2 result;
            float val = 2.0f * Dot(vector, normal);
            result.X = vector.X - normal.X * val;
            result.Y = vector.Y - normal.Y * val;
            return result;
        }

        public void Round()
        {
            X = Mathf.Round(X);
            Y = Mathf.Round(Y);
        }

        public static Vector2 Round(Vector2 value)
        {
            value.X = Mathf.Round(value.X);
            value.Y = Mathf.Round(value.Y);
            return value;
        }

        public static Vector2 SmoothStep(Vector2 value1, Vector2 value2, float amount)
        {
            return new Vector2(Mathf.SmoothStep(value1.X, value2.X, amount), Mathf.SmoothStep(value1.Y, value2.Y, amount));
        }

        public static Vector2 Rotate(Vector2 value, float radian)
        {
            Vector2 ret = new Vector2();
            float cos = Mathf.Cos(radian);
            float sin = Mathf.Sin(radian);
            ret.X = cos * value.X - sin * value.Y;
            ret.Y = cos * value.Y + sin * value.X;

            return ret;
        }

        public static Vector2 Perpendicular(Vector2 value)
        {
            return new Vector2(-value.Y, value.X);
        }

        public static bool IsCCW(Vector2 value1, Vector2 value2)
        {
            Vector2 perpendicular = Perpendicular(value1);
            float dot = Dot(value2, perpendicular);

            return dot >= 0.0f;
        }

        #endregion
    }
}