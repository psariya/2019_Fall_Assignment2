using System;
using System.Diagnostics;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Debug.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Debug.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Debug.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Debug.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Debug.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
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
                // Write your code here
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                // Write your code here
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
                // Write your code here
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                int time = 0;
                int prevIndex = 0;
                foreach (char c in word) //for each character in the word
                {
                    // calculate the distance between the prev and current index, and add it to the running total.
                    time += Math.Abs(prevIndex - keyboard.IndexOf(c)); 
                    prevIndex = keyboard.IndexOf(c);
                }
                return time;
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
                // Write your code here
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
                // Write your code here
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
                        // If so, return the index
                        //Debug.WriteLine(s);
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
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = str[min];
                char b = str[max];
                if (a != b)
                {
                    return false;
                }
                min++;
                max--;
            }
        }
    }
}
