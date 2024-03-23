using Microsoft.AspNetCore.Mvc;

namespace api_calculadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
                
            }   


            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
                
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult getMult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());

            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult getDiv(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());

            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult getMean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());

            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("square/{firstNumber}")]
        public IActionResult getSquare(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var square = Math.Sqrt(ConvertToDecimal(firstNumber));
                return Ok(square.ToString());

            }

            return BadRequest("Invalid Input");
        }



        private int ConvertToDecimal(string firstNumber)
        { 
            if (int.TryParse(firstNumber, out int number))
            {
                return number;
            }
            return 0;
        }

        private bool IsNumeric(string firstNumber)
        {
            if (firstNumber == null)
            {
                return false;
            }

            return double.TryParse(firstNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out _);
        }
    }
}
