using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
//using System.Diagnostics;

namespace numbertowords
{
    class Program
    {
        public static List<string> onesarr=new List<string>{ "zero","one", "two", "three", "four", "five", "six", 
        "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", 
        "seventeen", "eighteen", "nineteen" };

        public static List<string> tensarr=new List<string>{ "twenty", "thirty", "forty", "fifty", "sixty", 
        "seventy", "eighty", "ninety"};

        public static List<string> higher=new List<string>{"thousand","million","billion",
        "trillion", "quadrillion"};

        static String tonum(double n) //converts double to words
        {
            if(n==0)
                return "zero";
            string words = "";
            bool tens = false;
            if (n < 0) {
                words += "minus ";
                n *= -1;
            }
            int power = (higher.Count + 1) * 3;
            while (power > 3) 
            {
                double pow = Math.Pow(10, power);
                if (n >= pow) {
                    if (n % pow > 0) 
                        words += tonum(Math.Floor(n / pow)) + " " + higher[(power / 3) - 1] +" ";
                    else if (n % pow == 0) 
                        words += tonum(Math.Floor(n / pow)) + " " + higher[(power / 3) - 1];
                    n %= pow;
                }
                power -= 3;
            }
            if (n >= 1000) {
                if (n % 1000 > 0) 
                    words += tonum(Math.Floor(n / 1000)) + " thousand ";
                else 
                    words += tonum(Math.Floor(n / 1000)) + " thousand";
                n %= 1000;
            }
            if (0 <= n && n <= 999) {
                if ((int)n / 100 > 0) {
                    words += tonum(Math.Floor(n / 100)) + " hundred";
                    n %= 100;
                }

                if ((int)n / 10 > 1) {
                    if (words != "")
                        words += " ";
                    words += tensarr[(int)n / 10 -2];
                    tens = true;
                    n %= 10;
                }

                if (n < 20 && n > 0) {
                    if (words != "" && tens == false)
                        words += " ";
                    words += (tens ? " " + onesarr[(int)n ] : onesarr[(int)n]);
                    n -= Math.Floor(n);
                }
            }
            return words.TrimEnd();
        }
        private static string todec(string s)
        {
            string tempstr="";
            foreach(char c in s)
            {
                tempstr+=(onesarr[c-'0']+" ");
            }    
            return tempstr.TrimEnd();
        }
        private static string outform(string words)
        {
            char[] arr=words.ToCharArray();
            arr[0]=char.ToUpper(arr[0]);
            words=new string(arr);
            return Regex.Replace(words, " {2,}", " ");
        }
        
        public static void Main(String[] args)
        {
            //string str=Console.ReadLine();
            //var watch = new Stopwatch();
            //watch.Start();
            string str=Console.ReadLine();
            
            string words="";

            if(Double.Parse(str)!=0 && str.Where(x => x!='-').First()=='0')
            {
                Console.WriteLine("Wrong output");
                return;
            }
            if(str.Contains('.'))
            {
                string[] temp=str.Split('.').ToArray();
                words=tonum(Double.Parse(temp[0]))+" point "+todec(temp[1]);
            }
            else
                words=tonum(Double.Parse(str));

            if(words.Split(' ').ToArray().Length==2 && words.Split(' ').ToArray().First()=="one")
                words=words.Split(' ').ToArray().Last();
            
            Console.WriteLine(outform(words));

            //watch.Stop();
            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            
        }
    }
}