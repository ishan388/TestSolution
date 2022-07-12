using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;

namespace UL_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string mathsString)
        {
            return Ok(CalculateString(mathsString));
        }

        string CalculateString(string mathsString)
        {
            string[] strOperators = { "+", "-", "*", "/" };
            Regex regex = new Regex(@"^[0-9()+\-*.\/]*$");
            if (!regex.IsMatch(mathsString))
                return "Invalid Input: " + mathsString;
            else
            {
                if (strOperators.Any(mathsString.StartsWith))
                    mathsString = mathsString.Remove(0, 1);
                if (strOperators.Any(mathsString.EndsWith))
                    mathsString = mathsString.Remove(mathsString.Length - 1, 1);
                using (DataTable dt = new DataTable())
                {
                    return dt.Compute(mathsString, string.Empty).ToString();
                }
            }
        }
    }
}
