using Xunit;
using Rith.Exe.Input;
using Rith.Exe.Evaluator;

using Rith.Exe.Test.Console;

namespace Rith.Exe.Test
{
    public class RithTest
    {
        private readonly IEvaluator evaluator;

        public RithTest()
        {
            this.evaluator = new DefaultEvaluator();
        }

        [Theory]
        [InlineData("10", "5+5")]
        [InlineData("14", "4+5*2")]
        [InlineData("6.5", "4+5/2")]
        [InlineData("5.5", "4+5/2-1")]
        public void ValidInput(string result, string arg)
        {
            var rith = new Rith(
                this.evaluator,
                new TestConsole(result),
                new CommandLineArgumentInput(new[] { arg })
                );

            rith.Run();
        }
    }
}