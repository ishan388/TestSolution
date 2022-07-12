using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnSpotTests.Models
{
    public class TestSolutions
    {
        

        static int diagonalDifference(List<List<int>> arr)
        {
            int res = 0, sumL2R = 0, sumR2L = 0;
            if (arr?.Count > 0)
            {
                Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
                List<int> temp;
                foreach (List<int> a in arr)
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
                if (dict.Count > 0)
                {
                    foreach (KeyValuePair<int, List<int>> item in dict)
                    {
                        sumL2R = 0; sumR2L = 0;
                        if (item.Key == 1 && item.Value.Count == 2)
                        {
                            sumL2R = item.Value[0];
                            sumR2L = item.Value[1];
                        }
                        else if (item.Key > 1 && item.Value.Count == (item.Key * item.Key))
                        {
                            for (int i = 0; i < item.Value.Count; i += (item.Key + 1))
                                sumL2R += item.Value[i];
                            for (int i = (item.Key - 1); i < (item.Value.Count - 1); i += (item.Key - 1))
                                sumR2L += item.Value[i];
                        }
                    }
                }
                res = sumL2R - sumR2L;
            }
            return (res < 0) ? (-1 * res) : res;
        }

        static List<int> countingSort(List<int> arr)
        {
            int[] res = new int[100];
            for (int i = 0; i < arr.Count; i++)
                res[arr[i]] += 1;

            return res.ToList();
        }

        bool isAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            char[] s1Array = s1.ToLower().ToCharArray();
            char[] s2Array = s2.ToLower().ToCharArray();

            Array.Sort(s1Array);
            Array.Sort(s2Array);

            s1 = new string(s1Array);
            s2 = new string(s2Array);

            return s1 == s2;
        }

        int findMedian(List<int> arr)
        {
            int res = 0;
            if (arr?.Count > 0)
            {
                arr.Sort();
                res = arr[arr.Count / 2];
            }
            return res;
        }

        static int lonelyinteger(List<int> a)
        {
            int res = 0;
            if (a?.Count > 0)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (a.Where(e => e == a[i]).Count() == 1)
                    {
                        res = a[i];
                        break;
                    }
                }
            }
            return res;
        }

        string timeConversion(string s)
        {
            string res = "";
            if (s?.Length > 0 && System.Text.RegularExpressions.Regex.IsMatch(s, @"([0-9]|0[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])\s*([AaPp][Mm])"))
            {
                string ampm = s.Substring(s.Length - 2).ToLower();
                int hh = Convert.ToInt32(s.Split(':')[0]);
                int mm = Convert.ToInt32(s.Split(':')[1]);
                int ss = Convert.ToInt32(s.Split(':')[2].Substring(0, 2));

                if (!(hh >= 24 || mm >= 60 || ss >= 60 || hh < 0 || mm < 0 || ss < 0))
                {
                    switch (ampm)
                    {
                        case "am":
                            if (hh >= 12)
                                hh -= 12;
                            break;
                        case "pm":
                            if (hh < 12)
                                hh += 12;
                            break;
                        default:
                            break;
                    }
                    res = ((hh < 10) ? "0" : String.Empty) + hh.ToString() + ":" + ((mm < 10) ? "0" : String.Empty) + mm.ToString() + ":" + ((ss < 10) ? "0" : String.Empty) + ss.ToString();
                }
                else
                    res = "Invalid Time Format";
            }
            return res;
        }
    }
}