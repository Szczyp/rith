using static Rith.Lib;

namespace Rith.Exe.Evaluator
{
    public class DefaultEvaluator : IEvaluator
    {
        public decimal Evaluate(string str)
        {
            return Expr.Parse(str).Evaluate();
        }
    }
}
