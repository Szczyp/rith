using Xunit;
using Rith.Exe.Console;

namespace Rith.Exe.Test.Console
{
    public class TestConsole : IConsole
    {
        private readonly string result;

        public TestConsole(string result)
        {
            this.result = result;
        }

        public void WriteLine(string str)
        {
            Assert.Equal(this.result, str);
        }
    }
}