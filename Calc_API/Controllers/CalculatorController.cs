using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.RegularExpressions;
using Calculator;

namespace Calc_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpPost("Calculate With Priority")]
        [SwaggerOperation(Summary = "Evaluate the given mathematical expression")]
        [SwaggerResponse(200, "The result of the evaluation")]
        public ActionResult<int> EvaluateExpression1([FromBody] string expression)
        {
            if (!IsValidExpression(expression))
            {
                return BadRequest("Invalid expression");
            }

            int resultWithPriority = Calculator.Calculator.CalculateWithPriority(expression);
            return Ok(resultWithPriority);
        }

        [HttpPost("Calculate Without Priority")]
        [SwaggerOperation(Summary = "Evaluate the given mathematical expression")]
        [SwaggerResponse(200, "The result of the evaluation")]
        public ActionResult<int> EvaluateExpression2([FromBody] string expression)
        {
            if (!IsValidExpression(expression))
            {
                return BadRequest("Invalid expression");
            }

            int resultWithoutPriority = Calculator.Calculator.CalculateWithoutPriority(expression);
            return Ok(resultWithoutPriority);
        }

        [HttpPost("Parse Expression")]
        [SwaggerOperation(Summary = "Is the given expression valid?")]
        [SwaggerResponse(200, "The result of the parsing")]
        public ActionResult<int> ParseExpression([FromBody] string expression)
        {
            if (IsValidExpression(expression))
            {
                return BadRequest("Invalid expression");
            }
            return Ok("This expression is valid!");
        }

        private bool IsValidExpression(string expression)
        {
            var regex = new Regex(@"^[0-9\+\-\*\/\(\)]+$");
            return regex.IsMatch(expression);
        }
    }
}