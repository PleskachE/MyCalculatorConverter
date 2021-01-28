﻿using Model.Abstraction;
using Model.Common;
using System;

namespace Model.Operations
{
    public class Exponentiation : BaseOperation
    {
        public Operation Operation { get; set; }

        public Exponentiation()
        {
            Operation = Operation.Division;
            Priority = Priority.High;
            Value = "^";
        }

        public override string Result(string leftNumber, string rightNumber)
        {
            double result = 0;
            double _left = 0;
            double _right = 0;
            Double.TryParse(leftNumber, out _left);
            Double.TryParse(rightNumber, out _right);
            result = Math.Pow(_left,_right);
            return result.ToString();
        }
    }
}
