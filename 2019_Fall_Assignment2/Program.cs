using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 3;
            int[] nums = { 1, 3, 5, 6 };
            Debug.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Debug.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Debug.WriteLine("\n");

            int[] A = { 5, 7, 7, 5, 2 };//{ 9, 9, 8, 8 };//
            Debug.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Debug.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0, 0 }, { 1, 0, 1, 0 }, { 0, 1, 0, 1 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Debug.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Debug.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Debug.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Debug.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Debug.Write("\n");

            string s = "abca";
            if (ValidPalindrome(s))
            {
                Debug.WriteLine("The given string \"{0}\" can be made PALINDROME", s, "");
            }
            else
            {
                Debug.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s, "");
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Debug.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Debug.Write(a[i, j] + "\t");
                }
                Debug.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int first = 0;
                int last = nums.Length;
                int index = 0;

                index = Array.IndexOf(nums, target);
                //If target value is present in the array, then return it's index and exit the method
                if (index >= 0)
                {
                    return index;
                }
                //if target value is not present in the array, find its position to insert the value
                else if (index < 0)
                {
                    //binary search to find the position of the target value
                    while (((last - first) / 2) > 0) //loop until we have exhausted the array
                    {
                        int mid = first + (last - first) / 2; //calculate the mid value. 
                        if (nums[mid] < target)
                            first = mid + 1;
                        else
                            last = mid;
                    }
                    return nums[first] >= target ? first : last;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception occured while computing SearchInsert()" + e);
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                List<int> result = new List<int>();
                Dictionary<int, int> myDict = new Dictionary<int, int>();
                //convert array to dictionary
                foreach (int value in nums1)
                {
                    try
                    {
                        myDict.Add(value, 1);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                        myDict[value]++;
                    }
                }
                //for each interger in num2, check if that value is present in myDict Dictionary.
                foreach (int value in nums2)
                {
                    if (myDict.ContainsKey(value) && myDict[value] > 0)
                    {
                        myDict[value]--;
                        result.Add(value);
                    }
                }

                return result.ToArray();
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                Array.Sort(A);
                Array.Reverse(A);
                int length = A.Length;
                int i;

                for (i = 0; i < length; i++)
                {
                    if (Array.IndexOf(A, A[i]) < length - 1)
                    {
                        if (A[i] == A[i + 1])
                        {
                            i = i + 1;
                        }
                        else if (A[i] != A[i + 1])
                        {
                            return A[i];
                        }
                    }
                    else
                    {
                        return A[i];
                    }
                }
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return -1;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                int time = 0;
                int prevIndex = 0;
                foreach (char c in word) //for each character in the word
                {
                    // calculate the distance between the prev and current index, and add it to the running total called time.
                    time += Math.Abs(prevIndex - keyboard.IndexOf(c)); 
                    prevIndex = keyboard.IndexOf(c); //save the prev index value
                }
                return time; //return the time taken to traverse the keyboard
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                int rows = A.GetLength(0);
                int cols = A.GetLength(1);
                //swap the values of integer in row of the 2D array
                for (int i = 0; i <= rows - 1; i++)
                {
                    int j = 0;
                    int k = cols - 1;
                    while (j < k)
                    {
                        int temp = A[i, j];
                        A[i, j] = A[i, k];
                        A[i, k] = temp;
                        j++;
                        k--;
                    }
                }
                //repalce 1s with 0s in the entire 2D array
                for (int i = 0; i <= rows - 1; i++)
                {
                    for (int j = 0; j <= cols - 1; j++)
                    {
                        if (A[i, j] == 0)
                        {
                            A[i, j] = 1;
                        }
                        else if (A[i, j] == 1)
                        {
                            A[i, j] = 0;
                        }
                    }
                }

                return A;
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                //Sort the 2D array in ascending order, only by the first value of each row.
                for (int i = 0; i < intervals.GetLength(0) - 1; i++)
                {
                    for (int j = intervals.GetLength(1) - 1; j > 0; j--)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            if (intervals[i, k] > intervals[i + 1, k])
                            {
                                //swap the first item of the pair
                                int myTemp1 = intervals[i, k];
                                intervals[i, k] = intervals[i + 1, k];
                                intervals[i + 1, k] = myTemp1;

                                //swap the second item of the pair
                                int myTemp2 = intervals[i, k + 1];
                                intervals[i, k + 1] = intervals[i + 1, k + 1];
                                intervals[i + 1, k + 1] = myTemp2;
                            }
                        }
                    }
                }
                //our meeting lists are now sorted in assending order
                //Count the meeting rooms required
                int meetingRooms = 1; //because we will need atleast 1 room for the meetings
                for (int i = 0; i < intervals.GetLength(0) - 1; i++) //for each row in the meetings list
                {
                    for (int j = intervals.GetLength(1) - 1; j > 0; j--) //for each column in the meeting list
                    {
                        for (int k = 0; k < j; k++)
                        {
                            if (intervals[i, k] < intervals[i + 1, k]) //if start time of meeting2 is after meeting1
                            {
                                if ((intervals[i, k + 1] > intervals[i + 1, k + 1])) //and if endtime if meeting2 is before meeting1
                                {
                                    meetingRooms += 1; //we will need one more meeting room due to timing overlap.
                                }

                            }
                        }
                    }
                }
                return meetingRooms;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception occured while computing MinMeetingRooms()" + ex.ToString());
            }

            return 0;
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                int length = A.Length;
                int i;
                for (i = 0; i < length; i++) //square all the values in the array
                {
                    A[i] = A[i] * A[i];
                }
                Array.Sort(A); //sort the array
                return A; //return the sorted array
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                for (int c = 0; c < s.Length; c++)
                {
                    if (IsPalindrome(s.Remove(c, 1)))
                    {
                        // If so, return true. that is, it is a palindrome (or modified palindrome)
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception occured while computing ValidPalindrome(): " + e);
            }

            return false;
        }

        public static bool IsPalindrome(string str)
        {
            int min = 0;
            int max = str.Length - 1;
            while (true) //loop until it's false
            {
                if (min > max) //if we have reached the middle (or beyond middle) of the string, its a palindrome, and return true.
                {
                    return true;
                }
                char a = str[min]; //traversing forward, left to right in the string
                char b = str[max]; //traversing backwards, right to left, in the string
                if (a != b) // the exact character from either side should have the same value to qualify as palindrome
                {
                    return false; //if the values don't match, it's not a palindrome.
                }
                min++;
                max--;
            }
        }
    }
}
