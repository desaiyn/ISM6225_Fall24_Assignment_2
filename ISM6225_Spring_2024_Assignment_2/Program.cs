using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1,1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0,1,2 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 3,2,4 };
            int target = 6;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 10;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = {4,5,6,7,0,1,2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 131;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 3;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> missingNumbers = new List<int>();
                bool[] present = new bool[nums.Length + 1]; // Boolean array 

                
                for (int i = 0; i < nums.Length; i++)
                {
                    present[nums[i]] = true; 
                }

                // Adding missing numbers to the result
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!present[i])
                    {
                        missingNumbers.Add(i); // if i is not present, add it to the list
                    }
                }

                return missingNumbers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in FindMissingNumbers: {ex.Message}");
                return new List<int>(); // Return an empty list in case of an error
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                List<int> even = new List<int>();
                List<int> odd = new List<int>();

                // separating even and odd numbers
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        even.Add(nums[i]); // even list
                    }
                    else
                    {
                        odd.Add(nums[i]); // odd list
                    }
                }

                even.AddRange(odd); // add all odd numbers after even numbers
                return even.ToArray();  
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in SortArrayByParity: {ex.Message}");
                return new int[0]; 
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> numMap = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i]; 

                    // checking if complement exists in the dictionary
                    if (numMap.ContainsKey(complement))
                    {
                        return new int[] { numMap[complement], i };
                    }
                    numMap[nums[i]] = i;
                }

                return new int[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in TwoSum: {ex.Message}");
                return new int[0];
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums);
                int n = nums.Length;

                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3]; // product of three largest numbers
                int product2 = nums[0] * nums[1] * nums[n - 1];  // product of two smallest negatives and the largest number

                return Math.Max(product1, product2); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in MaximumProduct: {ex.Message}");
                return -1; // Return -1 in case of an error
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) return "0";

                string binary = ""; // storing binary representation

                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary; 
                    decimalNumber /= 2; 
                }

                return binary;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in DecimalToBinary: {ex.Message}");
                return ""; 
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

                if (nums[left] < nums[right])
                {
                    return nums[left];
                }

                // binary search to find the minimum
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    //if mid element is greater than the rightmost element
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1; // minimum is in the right half
                    }
                    else
                    {
                        right = mid;  // minimum is in the left half
                    }
                }

                return nums[left]; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in FindMin: {ex.Message}");
                return -1; 
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // negative numbers are not palindromes
                if (x < 0 || (x % 10 == 0 && x != 0))
                {
                    return false;
                }

                int reversed = 0; 

                // reverse the number
                while (x > reversed)
                {
                    reversed = reversed * 10 + x % 10; // add last digit of x to reversed
                    x /= 10;  
                }

                return x == reversed || x == reversed / 10;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in IsPalindrome: {ex.Message}");
                return false; // Return false in case of an error
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // base cases
                if (n < 0) return -1; // invalid input
                if (n == 0) return 0; // F(0) = 0
                if (n == 1) return 1; // F(1) = 1

                int a = 0;  // F(0)
                int b = 1;  // F(1)

                for (int i = 2; i <= n; i++)
                {
                    int temp = a;
                    a = b;
                    b = temp + b; 
                }

                return b; // F(n)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in Fibonacci: {ex.Message}");
                return -1; 
            }
        }
    }
}
