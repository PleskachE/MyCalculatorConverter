using Models.Calculator.Abstraction;
using Models.Calculator.Entities;
using Models.Calculator.Entities.Operations;

namespace Bll.Calculator.Converters
{
    public class OperationConverter
    {
        public BaseSymbal StringToOperation(string text)
        {
            BaseSymbal operation = null;

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
                default:
                    operation = new Number();
                    operation.Value += text;
                    break;
            }

            return operation;
        }
    }
}
