using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Next_Test
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(int.MaxValue.ToString());
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            //lblResult.Text = CheckInput(Convert.ToInt32(txtInput.Text));
            string msg = "@User_One @UserABC! @ishan@gmail.com Have you seen this from @Userxyz? @?is-388! @is_22?";
            lblResult.Text = GetRecipient(msg, Convert.ToInt32(txtInput.Text));
        }

        public string GetRecipient(string message, int position)
        {
            List<string> lstStrResult = new List<string>();
            string[] strArr = message.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArr)
            {
                if (str.StartsWith("@") && !new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(str.Substring(1)).Success)
                    lstStrResult.Add(Regex.Replace(str.Substring(1), @"[^0-9a-zA-Z_-]+", ""));
            }
            if (position > 0 && lstStrResult.Count > 0 && lstStrResult.Count > (position - 1))
                return lstStrResult[position - 1].ToString();
            else
                return string.Empty;
        }

        private bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

        private bool ValidateUsername(string username)
        {
            bool result = false;
            if (username.StartsWith("@"))
                result = !ValidateEmail(username.Substring(1));
            return result;
        }

        private string CheckInput(int n)
        {
            if (n < 0)
                return "Invalid Input";
            else if (n > 0 && n % 3 == 0 && n % 5 == 0)
                return "FizzBuzz";
            else if (n > 0 && n % 3 == 0)
                return "Fizz";
            else if (n > 0 && n % 5 == 0)
                return "Buzz";
            else
                return NumberToText(n);
        }

        private string NumberToText(int n)
        {
            if (n < 0)
                return "Minus " + NumberToText(-n);
            else if (n == 0)
                return "Zero";
            else if (n <= 19)
                return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
                                "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                                "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
            else if (n <= 99)
                return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
                                "Eighty", "Ninety"}[n / 10 - 2] + " " + NumberToText(n % 10);
            else if (n <= 199)
                return "One Hundred " + NumberToText(n % 100);
            else if (n <= 999)
                return NumberToText(n / 100) + "Hundred " + NumberToText(n % 100);
            else if (n <= 1999)
                return "One Thousand " + NumberToText(n % 1000);
            else if (n <= 999999)
                return NumberToText(n / 1000) + "Thousand " + NumberToText(n % 1000);
            else if (n <= 1999999)
                return "One Million " + NumberToText(n % 1000000);
            else if (n <= 999999999)
                return NumberToText(n / 1000000) + "Million " + NumberToText(n % 1000000);
            else if (n <= 1999999999)
                return "One Billion " + NumberToText(n % 1000000000);
            else
                return NumberToText(n / 1000000000) + "Billion " + NumberToText(n % 1000000000);
        }
    }
}