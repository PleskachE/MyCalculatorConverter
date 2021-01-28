using Model.Abstraction;
using Model.Operations;

namespace Bll.Converters
{
    public class OperationConverter
    {
        public BaseOperation StringToOperation(string text)
        {
            BaseOperation operation = null;

            switch (text)
            {
                case "+":
                    operation = new Summation();
                    break;
                case "-":
                    operation = new Subtraction();
                    break;
                case "*":
                    operation = new Multiply();
                    break;
                case "/":
                    operation = new Division();
                    break;
                case "^":
                    operation = new Exponentiation();
                    break;
                case "(":
                    operation = new OpeningParenthesis();
                    break;
                case ")":
                    operation = new ClosingParenthesis();
                    break;
            }

            return operation;
        }
    }
}
