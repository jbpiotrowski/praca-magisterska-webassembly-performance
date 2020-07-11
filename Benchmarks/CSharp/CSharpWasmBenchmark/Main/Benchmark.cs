using System;
using System.Diagnostics;

namespace Main
{
    public class Benchmark
    {

        private const int TestRepeat = 500;
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
        public bool Gauss (int n, double[][] ab, double[] x)
        {
            const double eps = 1e-12; 
            int i, j, k;
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


        public static void CustomMethod(){
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

        public void TestCustomMethod(int testNumber)
        {
            float minTime = 100, maxTime= 0, sum = 0;
            var stopWatch = new Stopwatch();
            for (int i = 0; i<testNumber; i++){
                stopWatch.Start();
                for(int it=0; it< TestRepeat; it++){
                    CustomMethod();
                }
                stopWatch.Stop();
                float elapsedTime = stopWatch.ElapsedMilliseconds;
                if(elapsedTime < minTime)
                    minTime = elapsedTime;
                if(elapsedTime > maxTime)
                    maxTime = elapsedTime;
                sum += elapsedTime;
                stopWatch.Reset();
            }

            Console.WriteLine($"Custom method mean: {sum/testNumber}");
            Console.WriteLine($"Custom method max: {maxTime}");
            Console.WriteLine($"Custom method min: {minTime}");
        }
        public void testGauss(int testNumber){
            float minTime = 100, maxTime= 0, sum = 0;
            int[] values = {8,37, 26, 87, 13, 9, 18, 67, 99, 101, 33,
                15, 77, 93, 13, 51, 16, 477, 501, 613, 718, 413,
                18, 111, 135, 187, 15, 313, 314, 1001, 1120, 813, 1013,
                89, 234, 153, 100, 73, 67, 1300, 1402, 1513, 1478, 1069,
                372, 147, 169, 293, 14, 156, 777, 813, 616, 341, 2013,
                141, 278, 347, 847, 613, 178, 993, 3014, 205, 947, 323,
                4017, 7314, 7891, 5661, 3017, 11024, 8751, 9931, 14759, 64789, 648,
                60781, 7015, 3017, 9781, 24431, 31586, 8589, 13589, 45895, 84621, 5489,
                51684, 12354, 12387, 64898, 13325, 14798, 15435, 87982, 14898, 36548, 51687,
                15648, 235489, 546879, 564898, 302156, 486897, 38879, 68795, 13248, 65489, 16879};
            var stopWatch = new Stopwatch();
            for (int test = 0; test<testNumber; test++){
                
                stopWatch.Start();
                for(int it = 0; it < 10000; it++)
                {
                    
                    int n = 10;

                    // tworzymy macierze AB i X

                    var AB = new double [n][];
                    var X = new double[n];


                    for (var i = 0; i < n; i++) AB[i] = new double[n + 1];

                    // odczytujemy dane dla macierzy AB
                    int k = 0;
                    for (var i = 0; i < n; i++)
                    for (var j = 0; j <= n; j++) {
                        AB[i][j] = values[k];
                        k++;
                    }


                    bool result = Gauss(n, AB, X);
                    
                }
                stopWatch.Stop();
                float elapsedTime = stopWatch.ElapsedMilliseconds;
                if (elapsedTime < minTime)
                    minTime = elapsedTime;
                if (elapsedTime > maxTime)
                    maxTime = elapsedTime;
                sum += elapsedTime;
                stopWatch.Reset();
            }

            Console.WriteLine($"Gauss mean: {sum/testNumber}");
            Console.WriteLine($"Gauss max: {maxTime}");
            Console.WriteLine($"Gauss min: {minTime}");

        }
        
        void TestAckerman(int testNumber){
            float minTime = 100, maxTime= 0, sum = 0;
            var stopWatch = new Stopwatch();
            for (int i = 0; i<testNumber; i++){
                stopWatch.Start();
                for(int it=0; it< TestRepeat; it++){
                    AckermanFunction(3,8);
                }
                stopWatch.Stop();
                float elapsedTime = stopWatch.ElapsedMilliseconds;
                if(elapsedTime < minTime)
                    minTime = elapsedTime;
                if(elapsedTime > maxTime)
                    maxTime = elapsedTime;
                sum += elapsedTime;
                stopWatch.Reset();
            }

            Console.WriteLine($"Ackerman mean: {sum/testNumber}");
            Console.WriteLine($"Ackerman max: {maxTime}");
            Console.WriteLine($"Ackerman min: {minTime}");
        }
        
        void TestFibonacci(int testNumber){
            float minTime = 100, maxTime= 0, sum = 0;
            var stopwatch = new Stopwatch();
            for (int i = 0; i<testNumber; i++){
                stopwatch.Start();
                for(int it=0; it< 100000; it++){
                    FibonacciSequence(70);
                }
                stopwatch.Stop();
                float elapsedTime = stopwatch.ElapsedMilliseconds;
                if(elapsedTime < minTime)
                    minTime = elapsedTime;
                if(elapsedTime > maxTime)
                    maxTime = elapsedTime;
                sum += elapsedTime;
                stopwatch.Reset();
            }

            Console.WriteLine($"Fibonacci mean: {sum/testNumber}");
            Console.WriteLine($"Fibonacci max: {maxTime}");
            Console.WriteLine($"Fibonacci min: {minTime}");
        }

        
        void TestEratosthenes(int testNumber){
            float minTime = 100, maxTime= 0, sum = 0;
            var stopWatch = new Stopwatch();
            for (int i = 0; i<testNumber; i++){
                stopWatch.Start();
                for(int it=0; it< 10; it++){
                    SieveOfEratosthenes(1000000);
                }

                stopWatch.Stop();
                float elapsedTime = stopWatch.ElapsedMilliseconds;
                if(elapsedTime < minTime)
                    minTime = elapsedTime;
                if(elapsedTime > maxTime)
                    maxTime = elapsedTime;
                sum += elapsedTime;
                stopWatch.Reset();
            }

            Console.WriteLine($"Eratosthenes mean: {sum/testNumber}");
            Console.WriteLine($"Eratosthenes max: {maxTime}");
            Console.WriteLine($"Eratosthenes min: {minTime}");
        }
        public static void Main()
        {
           CustomMethod();
        }
    }
}