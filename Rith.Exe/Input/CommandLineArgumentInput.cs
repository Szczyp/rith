using System;
using System.Linq;

namespace Rith.Exe.Input
{
    public class CommandLineArgumentInput : IInput
    {
        private readonly string[] args;

        public CommandLineArgumentInput(string[] args)
        {
            this.args = args;
        }
        public string Get()
        {
            try
            {
                return args.Single();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidInputException();
            }
        }
    }
}
