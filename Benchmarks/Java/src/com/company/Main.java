package com.company;

;

public class Main {

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
    public static int sieveOfEratosthenes(int n)
    {
        boolean[] prime = new boolean[n+1];
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
        int primeNumbersCount = 0;
            for (int i = 2; i< n + 1; i++){
                if(prime[i])
                    primeNumbersCount++;
            }        
        return primeNumbersCount;
    }


    public static boolean gauss (int n, double[][] AB, double[] X)
    {
        final double eps = 1e-12;
        int i, j, k;
        double m, s;

        for( i = 0; i < n - 1; i++ )
        {
            for( j = i + 1; j < n; j++ )
            {
                if( Math.abs ( AB [ i ][ i ] ) < eps ) return false;
                m = -AB [ j ][ i ] / AB [ i ][ i ];
                for( k = i + 1; k <= n; k++ )
                    AB [ j ][ k ] += m * AB [ i ][ k ];
            }
        }

        for( i = n - 1; i >= 0; i-- )
        {
            s = AB [ i ][ n ];
            for( j = n - 1; j >= i + 1; j-- )
                s -= AB [ i ][ j ] * X [ j ];
            if( Math.abs ( AB [ i ][ i ] ) < eps ) return false;
            X [ i ] = s / AB [ i ][ i ];
        }
        return true;
    }


    public static int partition(int[] array, int low, int high)
    {
        int x = array[low];
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

    public static void quickSort(int[] array, int low, int high)
    {
        int pivot;
        if (low < high)
        {
            pivot = partition(array, low, high);
            quickSort(array, low, pivot);
            quickSort(array, pivot + 1, high);
        }
    }


    public static long CustomMethod(){
        int moduloNumber = 867;
        long sum = 0;
        int array_length = 1000000;
        int innerLoopBound = 100000;
        var array = new int[array_length];

        for (int index = 0; index < array_length; index++)
            array[index] = index % moduloNumber;
        quickSort(array, 0, array_length - 1);
        for (int iteration = 0; iteration < 100; iteration++)
            for (int innerloop = 0; innerloop < innerLoopBound; innerloop++)
                sum += array[(iteration + innerloop) % array_length];                
        return sum;
    }


    public static void TestCustomMethod(int testNumber)
    {        

        for (int i = 0; i<testNumber; i++){
            var start = System.nanoTime();            
            var result = CustomMethod();            
            var stop = System.nanoTime();
            var elapsedTime = (stop - start) / 1000000.0;
            if(result!=428714300)
                    System.out.println("Wrong result!");
            System.out.println("custom_java, " + elapsedTime);
        }

    }

    public static void testGauss(int testNumber){
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
        for (int test = 0; test<testNumber; test++){
            float elapsedTime = 0;

            for(int repetition = 0; repetition<5000; repetition++){
                int n = 10;
                var AB = new double [n][];
                var X = new double[n];

                for (var i = 0; i < n; i++) AB[i] = new double[n + 1];
                int k = 0;
                for (var i = 0; i < n; i++)
                    for (var j = 0; j <= n; j++) {
                        AB[i][j] = values[k];
                        k++;
                    }
                var start = System.nanoTime();
                var result = gauss(n, AB, X);
                var stop = System.nanoTime();
                if(!result) System.out.println("Wrong result!");
                elapsedTime += (stop - start) / 1000000.0;
            }
            System.out.println("gauss_java, " + elapsedTime);
        }
    }

    static void TestAckerman(int testNumber){
        for (int i = 0; i<testNumber; i++){
            var start = System.nanoTime();            
            var result = AckermanFunction(3,10);            
            var stop = System.nanoTime();
            var elapsedTime = (stop - start) / 1000000.0;
            if(result != 8189)
                System.out.println("Wrong result!");
            System.out.println("ackerman_java, " + elapsedTime);
        }
    }

  static   void TestFibonacci(int testNumber){
        for (int i = 0; i<testNumber; i++){
            var start = System.nanoTime();
            for (int it = 0; it < 90; it++)
                {
                    for (int j = -1; j < it * 100; j++)
                        FibonacciSequence(it);
                }               
            var stop  = System.nanoTime();
            var elapsedTime = (stop - start) / 1000000.0;
            System.out.println("fibonacci_java, " + elapsedTime);
        }
    }

   static void TestEratosthenes(int testNumber){
        for (int i = 0; i<testNumber; i++){
            var start = System.nanoTime();            
            var result = sieveOfEratosthenes(500000);
            var stop = System.nanoTime();
            var elapsedTime = (stop - start) / 1000000.0;
            if(result != 41538)
                System.out.println("Wrong result!");
            System.out.println("eratosthenes_java, " + elapsedTime);
        }


    }
    public static void main(String[] args) {
        
        // TestAckerman(100);
        TestEratosthenes(1);
        // TestFibonacci(100);
        // testGauss(100);
        // TestCustomMethod(100);
    }
}
