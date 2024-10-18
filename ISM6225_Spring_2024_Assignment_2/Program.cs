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
            int palindromeNumber = 10;
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
                bool[] present = new bool[nums.Length + 1]; // Boolean array to track seen numbers

                // Step 1: Mark numbers as present
                for (int i = 0; i < nums.Length; i++)
                {
                    present[nums[i]] = true;  // Mark the number as seen
                }

                // Step 2: Add missing numbers to the result
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!present[i])
                    {
                        missingNumbers.Add(i); // If number i is not present, add it to the list
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

                // Step 1: Separate even and odd numbers
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        even.Add(nums[i]); // Add to even list if number is even
                    }
                    else
                    {
                        odd.Add(nums[i]); // Add to odd list if number is odd
                    }
                }

                // Step 2: Combine even and odd lists
                even.AddRange(odd); // Add all odd numbers after even numbers
                return even.ToArray();  // Convert the result back to an array
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in SortArrayByParity: {ex.Message}");
                return new int[0]; // Return an empty array in case of an error
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> numMap = new Dictionary<int, int>();

                // Step 1: Traverse the array
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i]; // Find the complement (target - current number)

                    // Step 2: Check if complement exists in the dictionary
                    if (numMap.ContainsKey(complement))
                    {
                        return new int[] { numMap[complement], i };
                    }

                    // Step 3: Store the current number and its index in the dictionary
                    numMap[nums[i]] = i;
                }

                return new int[0]; // Return empty array if no solution is found
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in TwoSum: {ex.Message}");
                return new int[0]; // Return an empty array in case of an error
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Step 1: Sort the array
                int n = nums.Length;

                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3]; // Product of the three largest numbers
                int product2 = nums[0] * nums[1] * nums[n - 1];  // Product of the two smallest (negatives) and the largest number

                return Math.Max(product1, product2); // Step 3: Return the maximum of the two products
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
                if (decimalNumber == 0) return "0"; // Special case for 0

                string binary = ""; // To store the binary representation

                while (decimalNumber > 0) // Loop until the number is 0
                {
                    binary = (decimalNumber % 2) + binary; // Prepend the remainder(0 or 1) to the binary string
                    decimalNumber /= 2; // Divide the number by 2
                }

                return binary; // Return the binary representation
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in DecimalToBinary: {ex.Message}");
                return ""; // Return empty string in case of an error
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

                // If the array is not rotated (the smallest element is the first one)
                if (nums[left] < nums[right])
                {
                    return nums[left];
                }

                // Binary search to find the minimum
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    // Check if mid element is greater than the rightmost element
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1; // The minimum is in the right half
                    }
                    else
                    {
                        right = mid;  // The minimum is in the left half (including mid)
                    }
                }

                return nums[left]; // When left == right, we found the minimum
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in FindMin: {ex.Message}");
                return -1; // Return -1 in case of an error
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Step 1: Negative numbers are not palindromes
                if (x < 0 || (x % 10 == 0 && x != 0))
                {
                    return false;
                }

                int reversed = 0; // This will hold the reversed number

                // Reverse the number
                while (x > reversed)
                {
                    reversed = reversed * 10 + x % 10; // Add the last digit of x to reversed
                    x /= 10;  // Remove the last digit from x
                }

                // Handles both odd and even length numbers
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
                // Handle base cases
                if (n < 0) return -1; // Invalid input
                if (n == 0) return 0; // F(0) = 0
                if (n == 1) return 1; // F(1) = 1

                // Initialize the first two Fibonacci numbers
                int a = 0;  // F(0)
                int b = 1;  // F(1)

                // Calculate Fibonacci iteratively
                for (int i = 2; i <= n; i++)
                {
                    int temp = a;
                    a = b;
                    b = temp + b; // Update b to the new Fibonacci number
                }

                return b; // F(n)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in Fibonacci: {ex.Message}");
                return -1; // Return -1 in case of an error
            }
        }
    }
}
