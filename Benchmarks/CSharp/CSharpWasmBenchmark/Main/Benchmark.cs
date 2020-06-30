using System;

namespace Main
{
    public class Benchmark
    {
    
        public static int AckermanFunction(int m, int n){
            if(m == 0)
                return n+1;
            if(m > 0 && n == 0)
                return AckermanFunction(m-1 , 1);
            if(m > 0 && n > 0)
                return AckermanFunction(m - 1,AckermanFunction(m, n-1));
            return n;
        }
        public static long  FibonacciSequence(int n){
            if (n == 0 ) return 0;
            if (n == 1) return  1;
            long  a = 0;
            long  b = 1;
            long  sum;
            for(int i = 2; i <= n; i++){
                sum = a + b;
                a = b;
                b = sum;
            }
            return b;
        }
        public static void SieveOfEratosthenes(int n)
        {
            var prime = new bool[n+1];
            for(int i=0;i<n;i++)
                prime[i] = true;

            for(int p = 2; p*p <=n; p++)
            {
                if(prime[p])
                {
                    for(int i = p*p; i <= n; i += p)
                        prime[i] = false;
                }
            }
            
        }
        public bool Gauss (double[][] ab, double[] x)
        {
            const double eps = 1e-12; 
            int i, j, k, n = 5;
            double m, s;
            
            for( i = 0; i < n - 1; i++ )
            {
                for( j = i + 1; j < n; j++ )
                {
                    if( Math.Abs ( ab [ i ][ i ] ) < eps ) return false;
                    m = -ab [ j ][ i ] / ab [ i ][ i ];
                    for( k = i + 1; k <= n; k++ )
                        ab [ j ][ k ] += m * ab [ i ][ k ];
                }
            }

            for( i = n - 1; i >= 0; i-- )
            {
                s = ab [ i ][ n ];
                for( j = n - 1; j >= i + 1; j-- )
                    s -= ab [ i ][ j ] * x [ j ];
                if( Math.Abs ( ab [ i ][ i ] ) < eps ) return false;
                x [ i ] = s / ab [ i ][ i ];
            }
            return true;
        }
        
        public static int Partition(int[] array, int low, int high)
        {
            var x = array[low];
            int i = low, j = high, w;
            while (true)
            {
                while (array[j] > x)
                    j--;
                while (array[i] < x)
                    i++;
                if (i < j)
                {
                    w = array[i];
                    array[i] = array[j];
                    array[j] = w;
                    i++;
                    j--;
                }
                else
                    return j;
            }
        }

        public static void QuickSort(int[] array, int low, int high)
        {
            int pivot;
            if (low < high)
            {
                pivot = Partition(array, low, high);
                QuickSort(array, low, pivot);
                QuickSort(array, pivot + 1, high);
            }
        }


        public static void CustomTestMethod(){
            int moduloNumber = 867;
            double sum = 0;
            int array_length = 1000000;
            int innerLoopBound = 100000;
            var array = new int[array_length];

            for (int index = 0; index < array_length; index++)
                array[index] = index % moduloNumber;

            for (int iteration = 0; iteration < 100; iteration++)
            for (int innerloop = 0; innerloop < innerLoopBound; innerloop++)
                sum += array[(iteration + innerloop) % array_length];
            Console.WriteLine("sum " + sum);
            QuickSort(array, 0, array_length - 1);

            array = null;
        }
        public static void Main()
        {
           CustomTestMethod();
        }
    }
}