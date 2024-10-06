using Microsoft.AspNetCore.Mvc;
using service_template.Services.Interfaces;

namespace service_template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : Controller
    {
        private readonly IMathService _mathService;

        public MathController(IMathService mathService)
        {
            _mathService = mathService;
        }

        [HttpPost("average")]
        public IActionResult CalculateAverage([FromBody] IEnumerable<int> numbers)
        {
            try
            {
                var average = _mathService.CalculateAverage(numbers);
                return Ok(average);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("max")]
        public IActionResult FindMaximum([FromBody] IEnumerable<int> numbers)
        {
            try
            {
                var max = _mathService.FindMaximum(numbers);
                return Ok(max);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("min")]
        public IActionResult FindMinimum([FromBody] IEnumerable<int> numbers)
        {
            try
            {
                var min = _mathService.FindMinimum(numbers);
                return Ok(min);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("sort")]
        public IActionResult SortNumbers([FromBody] IEnumerable<int> numbers)
        {
            var sortedNumbers = _mathService.SortNumbers(numbers);
            return Ok(sortedNumbers);
        }
    }
}
