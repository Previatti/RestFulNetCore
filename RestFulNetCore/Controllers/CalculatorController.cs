using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestFulNetCore.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        
        // GET api/calculator/sum/5/3
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Número inválido");
        }

        // GET api/calculator/subtraction/5/3
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Número inválido");
        }

        // GET api/calculator/subtraction/5/3
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Número inválido");
        }

        // GET api/calculator/subtraction/5/3
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Número inválido");
        }

        // GET api/calculator/subtraction/5/3
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());
            }

            return BadRequest("Número inválido");
        }

        // GET api/calculator/subtraction/5/3
        [HttpGet("square-root/{number}")]
        public ActionResult<string> SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(squareRoot.ToString());
            }

            return BadRequest("Número inválido");
        }

        

        private decimal ConvertToDecimal(string value)
        {
            decimal decimalValue;
            if (decimal.TryParse(value, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string value)
        {
            double numberDouble;
            bool isNumber = double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numberDouble);
            return isNumber;
        }
    }
}
