using System;

namespace NumberOfDiscIntersections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] {1, 5, 2, 1, 4, 0};
            Console.WriteLine(new Solution().solution(mas));           
        }
    }
    class Solution
    {
        public int solution(int[] A)
        {
            int n = A.Length;
            int[] sum = new int[n];

            for (int i = 0; i < n; i++)
            {
                int right;
                //if i+A[i]<= n-1, that's it, extract this i+A[i], let sum[i+A[i]]++, means there is one disk that i+A[i]
                if (n - i - 1 >= A[i])
                {
                    right = i + A[i];
                }
                else
                {
                    right = n - 1;
                }

                sum[right]++;
            }

            for (int i = 1; i < n; i++)
            {
                sum[i] += sum[i - 1];  //sum[i] means that there are sum[i] number of values that <= i;
            }

            long ans = (long)n * (n - 1) / 2;

            for (int i = 0; i < n; i++)
            {
                int left;

                if (A[i] > i)
                {
                    left = 0;
                }
                else
                {
                    left = i - A[i];// Find the positive i-A[i].     
                }

                if (left > 0)
                {
                    ans -= sum[left - 1];//Find the number that is smaller than 1-A[i], sum[n-1] will never be used as we only need sum[n-1-1] at most.  
                }
            }

            if (ans > 10000000)
            {
                return -1;
            }

            return (int)ans;
        }
    }
}
