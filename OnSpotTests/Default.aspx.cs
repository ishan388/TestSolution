using OnSpotTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnSpotTests
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region few tests
            //Response.Write(isAnagram("brake", "bakers"));
            //Response.Write(isAnagram("brake", "baker"));
            //plusMinus(new List<int> { 0, -2, 3, -4, 5, 6, });
            //miniMaxSum(new List<int> { 1, 2, 5, 3, 4 });
            //miniMaxSum(new List<int> { 12, 11, 13, 14, 15 });
            //Response.Write(timeConversion("12:45:54PM") + "<br>");
            //Response.Write(timeConversion("11:45:45 AM") + "<br>");
            //Response.Write(timeConversion("12:40:22AM") + "<br>");
            //Response.Write(findMedian(new List<int> { 0, 1, 2, 4, 6, 5, 3 }));
            //Response.Write(findMedian(new List<int> { 1, 2, 3, 4, 5, 6 }));
            //Response.Write(lonelyinteger(new List<int> { 1, 2, 3, 4, 3, 2, 1 }));

            //List<List<int>> arr = new List<List<int>>();
            //arr.Add(new List<int> { 3 });
            //arr.Add(new List<int> { 11, 2, 4 });
            //arr.Add(new List<int> { 4, 5, 6 });
            //arr.Add(new List<int> { 10, 8, -12 });
            //Response.Write(diagonalDifference(arr));

            //List<List<int>> arr1 = new List<List<int>>();
            //arr1.Add(new List<int> { 11, 2, 4, 1 });
            //arr1.Add(new List<int> { 4, 5, 6, 1 });
            //arr1.Add(new List<int> { 10, 8, -12, 1 });
            //arr1.Add(new List<int> { 4, 3, -2, 1 });
            //Response.Write(diagonalDifference(arr1));

            //Response.Write(countingSort(new List<int> { 63, 25, 73, 1, 98, 73, 56, 1 }));
            #endregion

            //Response.Write(solution(new int[] { 1, 3, 6, 4, 1, 2 }));
            //Response.Write(solution(new int[] { 1, 2, 3 }));
            //Response.Write(solution(new int[] { -3, -1, 0 }));
            //Response.Write(solution(new int[] { -3, -1, 0, 1, 5 }));

            //Response.Write(solution(new int[] { -1, -3, 0, 1, 5 }));
            //Response.Write(solution(new int[] { 11, 1, 8, 12, 14 }));
            //Response.Write(solution(new int[] { 5, 5, 5, 5, 5 }));

            Response.Write(solution("abccbd", new int[] { 0, 1, 2, 3, 4, 5 }));
            Response.Write(solution("aabbcc", new int[] { 1, 2, 1, 2, 1, 2 }));
            Response.Write(solution("aaaa", new int[] { 3, 4, 5, 6 }));
            Response.Write(solution("ababa", new int[] { 10, 5, 10, 5, 10 }));

            #region totpal test
            //Response.Write(TotpalTests.solution(100, new int[] { 10, 6, 6, 8 }, 2));
            //Response.Write(TotpalTests.solution(100));
            //Response.Write(TotpalTests.solution(7263));
            //Response.Write(TotpalTests.solution("300.01", new string[] { "300", "200", "100" }));
            #endregion
        }

        public int solution(string S, int[] C)
        {
            int res = 0;
            if (C?.Length == 0 || S?.Length == 0 || S?.Length != C?.Length)
                res = 0;
            else
            {
                for (int i = 0; i < C.Length - 1; i++)
                {
                    if (S[i + 1].ToString().ToLower() == S[i].ToString().ToLower())
                        res += (C[i + 1] >= C[i]) ? C[i] : C[i + 1];
                }
            }
            return res;
        }

        public bool solution(int[] A)
        {
            bool res = false;
            if (A?.Length <= 1)
                res = false;
            else
            {
                Array.Sort(A);
                for (int i = 1; i < A.Length; i++)
                {
                    if (A[i] - A[i - 1] == 1)
                    {
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }

        static int flippingMatrix(List<List<int>> matrix)
        {
            int res = 0;
            if (matrix?.Count > 0)
            {
                Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
                List<int> temp;
                foreach (List<int> a in matrix)
                {
                    temp = new List<int>();
                    if (a?.Count > 0)
                    {
                        if (dict.ContainsKey(a.Count))
                        {
                            temp = dict[a.Count];
                            foreach (int i in a)
                            {
                                temp.Add(i);
                            }
                            dict[a.Count] = temp;
                        }
                        else
                            dict.Add(a.Count, a);
                    }
                }
            }

            return res;
        }
        void miniMaxSum(List<int> arr)
        {
            int min = 0, max = 0;
            if (arr?.Count > 0)
            {
                arr.Sort();
                for (int i = 0; i < arr.Count; i++)
                {
                    if (i > 0)
                        max += arr[i];

                    if (i < arr.Count - 1)
                        min += arr[i];
                }
            }
            Response.Write(min + "<br>");
            Response.Write(max + "<br>");
        }

        public void plusMinus(List<int> arr)
        {
            decimal d = (decimal)(arr?.Count), p = 0, n = 0, z = 0;
            if (d > 0)
            {
                foreach (int i in arr)
                {
                    if (i < 0)
                        n++;
                    else if (i > 0)
                        p++;
                    else
                        z++;
                }
                Response.Write(p / d + "<br>");
                Response.Write(n / d + "<br>");
                Response.Write(z / d);
            }
        }
    }
}