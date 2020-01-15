using Xunit;
using Rith.Exe.Input;

namespace Rith.Exe.Test
{
    public class CommandLineArgumentInputTest
    {
        [Fact]
        public void ValidInput()
        {
            var str = "1+2";
            var input = new CommandLineArgumentInput(new[] { str });

            Assert.Equal(input.Get(), str);
        }

        [Theory]
        [InlineData()]
        [InlineData("1+2", "2")]
        public void InvalidInput(params string[] args)
        {
            var input = new CommandLineArgumentInput(args);
            Assert.Throws<InvalidInputException>(input.Get);
        }
    }
}
