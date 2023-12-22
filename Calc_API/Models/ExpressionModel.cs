namespace Calc_API.Models
{
    public class ExpressionModel
    {
        public string InputExpression { get; set; }
        public bool IsValid { get; set; }
        public int? Result { get; set; }
    }
}
