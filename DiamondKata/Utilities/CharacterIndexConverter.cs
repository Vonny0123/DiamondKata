using System;

namespace DiamondKata.Utilities
{
    public class CharacterIndexConverter : IConverter<char, int>
    {
        private const int IndexOffset = 65;
        private const int MinIndex = 0;
        private const int MaxIndex = 25;

        /// <inheritdoc/>
        public int Convert(char input)
        {
            int converted = input - IndexOffset;

            if (converted < MinIndex ||  converted > MaxIndex)
            {
                throw new ArgumentException($"Input must be an upper-case letter of the alphabet, not {input}");
            }

            return converted;
        }

        /// <inheritdoc/>
        public char Convert(int input)
        {
            if (input < MinIndex || input > MaxIndex)
            {
                throw new ArgumentException($"Input must be an integer between {MinIndex} and {MaxIndex} (inclusive), not {input}");
            }

            return (char)(input + IndexOffset);
        }
    }
}
