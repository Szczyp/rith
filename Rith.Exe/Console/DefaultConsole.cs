namespace Rith.Exe.Console
{
    class DefaultConsole : IConsole
    {
        public void WriteLine(string str)
        {
            System.Console.WriteLine(str);
        }
    }
}
