namespace Calculator;
public static class Calculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите выражение:");
        string? expression = Console.ReadLine();

        int result = CalculateWithPriority(expression);
        Console.WriteLine("Результат с приоритетом операций: " + result);

        result = CalculateWithoutPriority(expression);
        Console.WriteLine("Результат без приоритета операций: " + result);
    }

    public static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    public static bool HasHigherPriority(char op1, char op2)
    {
        if (op2 == '(' || op2 == ')')
            return false;
        if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
            return false;
        return true;
    }

    public static int EvaluateExpr(int operand1, int operand2, char op)
    {
        switch (op)
        {
            case '+':
                return operand1 + operand2;
            case '-':
                return operand1 - operand2;
            case '*':
                return operand1 * operand2;
            case '/':
                return operand1 / operand2;
            default:
                throw new ArgumentException("Invalid operator");
        }
    }
    public static int CalculateWithPriority(string expression)
    {
        Stack<int> operands = new Stack<int>();
        Stack<char> operators = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            if (Char.IsDigit(expression[i]))
            {
                int num = 0;
                while (i < expression.Length && Char.IsDigit(expression[i]))
                {
                    num = num * 10 + (expression[i] - '0');
                    i++;
                }
                i--;

                operands.Push(num);
            }
            else if (expression[i] == '(')
            {
                operators.Push(expression[i]);
            }
            else if (expression[i] == ')')
            {
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    int operand2 = operands.Pop();
                    int operand1 = operands.Pop();
                    char op = operators.Pop();

                    int result = EvaluateExpr(operand1, operand2, op);
                    operands.Push(result);
                }

                if (operators.Count > 0 && operators.Peek() == '(')
                {
                    operators.Pop();
                }
            }
            else if (IsOperator(expression[i]))
            {
                while (operators.Count > 0 && HasHigherPriority(expression[i], operators.Peek()))
                {
                    int operand2 = operands.Pop();
                    int operand1 = operands.Pop();
                    char op = operators.Pop();

                    int result = EvaluateExpr(operand1, operand2, op);
                    operands.Push(result);
                }

                operators.Push(expression[i]);
            }
        }

        while (operators.Count > 0)
        {
            int operand2 = operands.Pop();
            int operand1 = operands.Pop();
            char op = operators.Pop();

            int result = EvaluateExpr(operand1, operand2, op);
            operands.Push(result);
        }

        return operands.Pop();
    }

    public static int CalculateWithoutPriority(string expression)
    {
        Stack<int> operands = new Stack<int>();
        Stack<char> operators = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            if (Char.IsDigit(expression[i]))
            {
                int num = 0;
                while (i < expression.Length && Char.IsDigit(expression[i]))
                {
                    num = num * 10 + (expression[i] - '0');
                    i++;
                }
                i--;

                operands.Push(num);
            }
            else if (IsOperator(expression[i]))
            {
                while (operators.Count > 0)
                {
                    int operand2 = operands.Pop();
                    int operand1 = operands.Pop();
                    char op = operators.Pop();

                    int result = EvaluateExpr(operand1, operand2, op);
                    operands.Push(result);
                }

                operators.Push(expression[i]);
            }
        }

        while (operators.Count > 0)
        {
            int operand2 = operands.Pop();
            int operand1 = operands.Pop();
            char op = operators.Pop();

            int result = EvaluateExpr(operand1, operand2, op);
            operands.Push(result);
        }

        return operands.Pop();
    }

    public class ExpressionParser
    {
        private string expression;
        private int index;
        private static readonly Exception exception = new Exception("ERROR");

        private void SkipSpaces()
        {
            while (index < expression.Length && char.IsWhiteSpace(expression[index]))
            {
                index++;
            }
        }
        public bool IsValidExpression(string expression)
        {
            this.expression = expression;
            this.index = 0;

            try
            {
                ParseExpression();
                return index == expression.Length;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ParseExpression()
        {
            SkipSpaces();
            ParseTerm();

            if (index < expression.Length && (expression[index] == '+' || expression[index] == '-'))
            {
                index++;
                if (index < expression.Length && (Calculator.IsOperator(expression[index])))
                {
                    throw exception;
                }
                ParseExpression();
            }
        }


        private void ParseTerm()
        {
            ParseFactor();

            if (index < expression.Length && (expression[index] == '*' || expression[index] == '/'))
            {
                index++;
                if (index < expression.Length && (Calculator.IsOperator(expression[index])))
                {
                    throw exception;
                }
                ParseTerm();
            }
        }

        private void ParseFactor()
        {
            if (index >= expression.Length)
            {
                throw exception;
            }

            if (char.IsDigit(expression[index]) || char.IsLetter(expression[index]))
            {
                while (index < expression.Length && (char.IsDigit(expression[index]) || char.IsLetter(expression[index])))
                {
                    index++;
                }
            }

            else if (expression[index] == '(')
            {
                index++;
                ParseExpression();

                if (index >= expression.Length || expression[index] != ')')
                {
                    throw exception;
                }

                index++;
            }

            else if (Calculator.IsOperator(expression[index]))
            {
                index++;
                if (Calculator.IsOperator(expression[index]))
                {
                    throw exception;
                }
                ParseExpression();
            }

            else
            {
                throw exception;
            }
        }
    }
}
