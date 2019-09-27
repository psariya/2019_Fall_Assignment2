using System;
using System.Diagnostics;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            //int target = 5;
            //int[] nums = { 1, 3, 5, 6 };
            //Debug.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            //int[] nums1 = { 1, 2, 2, 1 };
            //int[] nums2 = { 2, 2 };
            //int[] intersect = Intersect(nums1, nums2);
            //Debug.WriteLine("Intersection of two arrays is: ");
            //DisplayArray(intersect);
            //Debug.WriteLine("\n");

            //int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            //Debug.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            //string keyboard = "abcdefghijklmnopqrstuvwxyz";
            //string word = "cba";
            //Debug.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            //int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            //int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            //Debug.WriteLine("The resulting flipped and inverted image is:\n");
            //Display2DArray(flipAndInvertedImage);
            //Debug.Write("\n");

            //int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 }};
            int[,] intervals = { { 7, 10 }, { 2, 4 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Debug.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            //int[] arr = { -4, -1, 0, 3, 10 };
            //int[] sortedSquares = SortedSquares(arr);
            //Debug.WriteLine("Squares of the array in sorted order is:");
            //DisplayArray(sortedSquares);
            //Debug.Write("\n");

            //string s = "abca";
            //if(ValidPalindrome(s)) {
            //    Debug.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            //}
            //else
            //{
            //    Debug.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            //}
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
                int index = 0;
                int prevIndex = 0;
                foreach (char c in word)
                {
                    index = index + Math.Abs(prevIndex - keyboard.IndexOf(c));
                    prevIndex = keyboard.IndexOf(c);
                }
                return index;
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
                //Sort the 2D array
                for (int i = 0; i < intervals.GetLength(0) - 1; i++)
                {
                    //Debug.WriteLine("loop 1 " + i);
                    for (int j = intervals.GetLength(1) - 1; j > 0; j--)
                    {
                        //Debug.WriteLine("loop 2 " + j);
                        for (int k = 0; k < j; k++)
                        {
                            //Debug.WriteLine("loop 3 " + k);
                            //if (intervals[i, k] > intervals[i, k + 1])
                            if (intervals[i, k] > intervals[i + 1, k])
                            {
                                //Debug.WriteLine("if statement ");
                                int myTemp1 = intervals[i, k];
                                intervals[i, k] = intervals[i + 1, k];
                                intervals[i + 1, k] = myTemp1;

                                int myTemp2 = intervals[i, k + 1];
                                intervals[i, k + 1] = intervals[i + 1, k + 1];
                                intervals[i + 1, k + 1] = myTemp2;
                            }
                        }
                    }
                }
                //Print the 2D array
                //Debug.WriteLine("sorted array " + intervals.GetLength(0) + " " + intervals.GetLength(1));
                //Debug.WriteLine(intervals[0, 0] + " " + intervals[0, 1]);
                //Debug.WriteLine(intervals[1, 0] + " " + intervals[1, 1]);
                //Debug.WriteLine(intervals[2, 0] + " " + intervals[2, 1]);
                //for (int x = 0; x < intervals.GetLength(0); x++)
                //{
                //    for (int y = 0; y < intervals.GetLength(1); y++)
                //    {
                //        Debug.Write(intervals[x, y] + "\t");
                //    }
                //}
                int meetingRooms = 1; //because we will need atleast 1 room for the meetings
                for (int i = 0; i < intervals.GetLength(0) - 1; i++)
                {
                    Debug.WriteLine("loop 1 " + i);
                    for (int j = intervals.GetLength(1) - 1; j > 0; j--)
                    {
                        Debug.WriteLine("loop 2 " + j);
                        for (int k = 0; k < j; k++)
                        {
                            Debug.WriteLine("loop 3 " + k);
                            if (intervals[i, k] < intervals[i + 1, k]) //if start time of meeting2 is after meeting1
                            {
                                Debug.WriteLine("if start time of meeting2 is after meeting1");
                                if ((intervals[i, k + 1] > intervals[i + 1, k + 1])) //and if endtime if meeting2 is before meeting1
                                {
                                    Debug.WriteLine("and if endtime if meeting2 is before meeting1");
                                    meetingRooms += 1; //we will need one more meeting room due to timing overlap.
                                }

                            }
                        }
                    }
                }
                Debug.WriteLine("Number of Meeting Rooms " + meetingRooms);
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
                // Write your code here
            }
            catch
            {
                Debug.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}
