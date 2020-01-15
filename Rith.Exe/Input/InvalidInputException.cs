using System;

namespace Rith.Exe.Input
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Invalid input.")
        {
        }
    }
}
