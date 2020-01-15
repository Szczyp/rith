using System;
using Rith.Exe.Input;
using Rith.Exe.Evaluator;
using Rith.Exe.Console;

namespace Rith.Exe
{
    public class Rith
    {
        private readonly IEvaluator evaluator;
        private readonly IConsole console;
        private readonly IInput input;

        public Rith(IEvaluator evaluator, IConsole console, IInput input)
        {
            this.evaluator = evaluator;
            this.console = console;
            this.input = input;
        }

        public void Run()
        {
            try
            {
                var input = this.input.Get();
                var result = evaluator.Evaluate(input);
                console.WriteLine(result.ToString());
            }
            catch (ParsingException ex)
            {
                console.WriteLine($"Parsing {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                console.WriteLine(ex.Message);
            }
            catch (InvalidInputException ex)
            {
                console.WriteLine(ex.Message);
            }
        }
    }
}
