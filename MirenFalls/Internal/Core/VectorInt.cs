using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Core {
    public class VectorInt {
        public int x;
        public int y;
        public VectorInt(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public VectorInt(float x, float y) {
            this.x = (int)x;
            this.y = (int)y;
        }

        public VectorInt(Vector2 vector) {
            this.x = (int)vector.X;
            this.y = (int)vector.Y;
        }

        public static explicit operator VectorInt(Vector2 vector) {
            return new VectorInt(vector);
        }

        public static implicit operator Vector2(VectorInt vector) {
            return new Vector2(vector.x, vector.y);
        }

        public static bool operator ==(VectorInt vector1, VectorInt vector2) {
            if (vector1.x != vector2.x) return false;
            if (vector1.y != vector2.y) return false;
            return true;
        }

        public static bool operator !=(VectorInt vector1, VectorInt vector2) {
            if (vector1.x != vector2.x) return true;
            if (vector1.y != vector2.y) return true;
            return false;
        }

        public static VectorInt operator + (VectorInt vector1, VectorInt vector2) {
            return new VectorInt(vector1.x + vector2.x, vector1.y + vector2.y);
        }

        public static VectorInt operator - (VectorInt vector1, VectorInt vector2) {
            return new VectorInt(vector1.x - vector2.x, vector1.y - vector2.y);
        }

        public override bool Equals(object obj) {
            if (obj.GetType() != this.GetType() && obj.GetType() != typeof(Vector2)) return false;
            VectorInt vector = (VectorInt)obj;
            if (vector.x != this.x) return false;
            if (vector.y != this.y) return false;
            return true;
        }

        public override int GetHashCode() {
            int hash = 13;
            hash = (hash * 7) + this.x.GetHashCode();
            hash = (hash * 7) + this.y.GetHashCode();
            return hash;
        }


        public override string ToString() {
            return "{" + $"X: {x}, Y: {y}" + "}";
        }
    }
}
