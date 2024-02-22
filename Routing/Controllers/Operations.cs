using Microsoft.AspNetCore.Mvc;

namespace Operations.Controllers
{
    [Route("Operations")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        [HttpGet("{operation}/{num1?}/{num2?}")]
        public IActionResult PerformOperation(string operation, double? num1, double? num2)
        {
            if (!num1.HasValue || !num2.HasValue)
            {
                return BadRequest("Please provide num1 and num2");
            }

            double result = 0;

            switch (operation.ToLower())
            {
                case "add":
                    result = num1.Value + num2.Value;
                    break;
                case "subtract":
                    result = num1.Value - num2.Value;
                    break;
                case "multiply":
                    result = num1.Value * num2.Value;
                    break;
                case "divide":
                    if (num2.Value == 0)
                    {
                        return BadRequest("Division by zero is not allowed");
                    }
                    result = num1.Value / num2.Value;
                    break;
                
            }

            return Ok(result);
        }
    }
}
