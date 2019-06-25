using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            /*
                Step 1 :-
                Divide the given equation string into 3 differnt strings, each representing a number/operand.
                Here s1,s2 and s3 are corresponding string representation of the 3 numbers.
            */

            string s1 = "";
            string s2 = "";
            string s3 = "";
            bool is_mult_sign_encountered = false;
            bool is_equal_sign_encountered = false;
            int question_mark = 0;
            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '*')
                {
                    is_mult_sign_encountered = true;
                    continue;
                }
                if (equation[i] == '=')
                {
                    is_equal_sign_encountered = true;
                    continue;
                }
                if (!is_mult_sign_encountered)
                {
                    s1 = s1 + equation[i];
                    if (equation[i] == '?')
                    {
                        question_mark = 1;
                    }
                }
                if (is_mult_sign_encountered && !is_equal_sign_encountered)
                {
                    s2 = s2 + equation[i];
                    if (equation[i] == '?')
                    {
                        question_mark = 2;
                    }
                }
                if (is_mult_sign_encountered && is_equal_sign_encountered)
                {
                    s3 = s3 + equation[i];
                    if (equation[i] == '?')
                    {
                        question_mark = 3;
                    }
                }
            }

            /*
                Step 2 :-
                Determine the faulty string/number and perform the corresponding operation of the rest 
                two string/number.
            */

            string res = "";
            string faulty_string = "";
            if (question_mark == 1)
            {
                res = Double.Parse(s3) / Double.Parse(s2) + "";
                faulty_string = s1;
            }
            else if (question_mark == 2)
            {
                res = Double.Parse(s3) / Double.Parse(s1) + "";
                faulty_string = s2;
            }
            else
            {
                res = Double.Parse(s1) * Double.Parse(s2) + "";
                faulty_string = s3;
            }

            /*
                Step 3 :-
                if the length of the resulted string/number which is obtained by the operation of the two string/numbers
                except the faulty string/number, differs in the length as of the string/number given in the equation,
                gives an indication for the following cases :
                    1.) Either the resulted number is not an integer i.e. contains decimal fraction.
                    2.) It contains leading zeros.
            */

            if (res.Length != faulty_string.Length)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < res.Length; i++)
                {
                    /*
                        Step 4 :-
                        if the resultant string/number obtained mismatches with the string/number provided in the
                        equation at any position except '?', we simply return -1
                    */

                    if (res[i] != faulty_string[i] && faulty_string[i] != '?')
                    {
                        return -1;
                    }

                    /*
                        Step 5 :-
                        if we encounter a '?', we return the corresponding digit.
                    */

                    if (res[i] != faulty_string[i] && faulty_string[i] == '?')
                    {
                        return Int32.Parse(res[i].ToString());
                    }
                }
            }
            return -1;
        }
    }
}
