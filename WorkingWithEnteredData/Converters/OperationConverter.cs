using WorkingWithEnteredData.Common;

namespace WorkingWithEnteredData.Converters
{
    public class OperationConverter
    {
        public Operation StringToOperation(string text)
        {
            Operation operation = Operation.Summation; // пока так оставим, потом что небудь придумаю

            switch (text)
            {
                case "+":
                    operation = Operation.Summation;
                    break;
                case "-":
                    operation = Operation.Subtraction;
                    break;
                case "*":
                    operation = Operation.Multiply;
                    break;
                case "/":
                    operation = Operation.Division;
                    break;
            }

            return operation;
        }
    }
}
