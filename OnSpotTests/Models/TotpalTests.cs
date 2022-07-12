using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnSpotTests.Models
{
    public class TotpalTests
    {
        public static string[] solution(string S, string[] B)
        {
            List<string> res = new List<string>();
            if (B?.Length > 0)
            {
                double final = 0;
                for (int i = 0; i < B.Length; i++)
                {
                    double sum = 0, exs = Convert.ToDouble(S);
                    for (int j = i; j < B.Length; j++)
                    {
                        sum += Convert.ToDouble(B[j]);
                    }
                    final = exs * (Convert.ToDouble(B[i]) / sum);
                    S = (exs - final).ToString();
                    res.Add(final.ToString());
                }
            }

            return res.ToArray();
        }

        public static string solution(int x, string str = "")
        {
            string res = str;
            bool isHour = res.ToLower().Contains("h");
            int m = 60;
            int h = m * m;
            int d = h * 24;
            int w = d * 7;
            if (x > 0)
            {
                int cal;
                if (x < m && !isHour)
                {
                    res += x.ToString() + "s";
                }
                else if (x >= m && x < h)
                {
                    cal = x / m;
                    if (isHour)
                        cal += 1;
                    res += cal.ToString() + "m";
                    res = solution(x - (cal * m), res);
                }
                else if (x >= h && x < d)
                {
                    cal = x / h;
                    res += cal.ToString() + "h";
                    res = solution(x - (cal * h), res);
                }
                else if (x >= d && x < w)
                {
                    cal = x / w;
                    res += cal.ToString() + "w";
                    res = solution(x - (cal * h), res);
                }
            }
            return res;
        }

        public static int solution(int X, int[] B, int Z)
        {
            int res = 0;
            int sum = 0;
            int avg = 0;
            try
            {
                if (B?.Length > 0)
                {
                    sum = B.Sum();
                    if (X == sum)
                        res = 0;
                    else
                    {
                        if (B.Length >= Z && B.Length > 2)
                            avg = (B[B.Length - 1] + B[B.Length - 2]) / Z;
                        else
                            avg = B[0] / Z;
                        res = (X - sum) / avg;
                    }
                }
                else
                    res = -1;
            }
            catch (DivideByZeroException)
            {
                res = -1;
            }
            catch (Exception)
            {
                res = -1;
            }
            return res;
        }


        /// <summary>
        /// Practice Test
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int solution(int[] a)
        {
            int res = 1;
            if (a?.Length > 0)
            {
                a = a.Distinct().ToArray();
                Array.Sort(a);
                if (a.Length == 1 && a[0] > 0)
                    res = a[0];
                else
                {
                    for (int i = 1; i < a.Length; i++)
                    {
                        if (a[i] > 0 && a[i - 1] > 0 && a[i] - a[i - 1] > 1)
                        {
                            res = a[i - 1] + 1;
                        }
                    }
                    if (a[a.Length - 1] > 1 && res == 1)
                        res = a[a.Length - 1] + 1;
                }
            }
            return res;
        }
    }
}