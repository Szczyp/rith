using Lamar;
using Rith.Exe.Input;
using Rith.Exe.Evaluator;
using Rith.Exe.Console;
using Microsoft.Extensions.DependencyInjection;

namespace Rith.Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(c =>
            {
                c.AddTransient<IEvaluator, DefaultEvaluator>()
                 .AddTransient<IConsole, DefaultConsole>();
                c.For<IInput>()
                 .Use<CommandLineArgumentInput>()
                 .Ctor<string[]>()
                 .Is(args)
                 .Transient();
                c.ForConcreteType<Rith>();
            });

            var rith = container.GetInstance<Rith>();
            rith.Run();
        }
    }
}
