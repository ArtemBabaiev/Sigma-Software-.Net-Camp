using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.entities
{
    internal struct Position : IEquatable<Position>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Position()
        {
            Random random = new();
            X = random.Next(1, 10);
            Y = random.Next(1, 10);
        }
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position && Equals(position);
        }

        public bool Equals(Position other)
        {
            return X == other.X &&
                   Y == other.Y;
        }

        public override string? ToString()
        {
            return $"{{x:{X}, y:{Y}}}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
