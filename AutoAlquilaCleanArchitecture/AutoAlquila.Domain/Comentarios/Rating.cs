using AutoAlquila.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAlquila.Domain.Comentarios
{
    public sealed record Rating
    {
        public static readonly Error Invalid = new(
            "Rating.Invalid",
            "El rating es invalid"
        );

        public int Value { get; init; }

        private Rating(int value) => Value = value;

        public static Result<Rating>Create(int value)
        {
            if (value < 1 || value > 5)
            {
                return Result.Failure<Rating>(Invalid);
            }

            return new Rating(value);
        }
    }
}
