package com.company;


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
    public static void sieveOfEratosthenes(int n)
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
    }


    public static boolean gauss (double[][] AB, double[] X)
    {
     final double eps = 1e-12;
        int i, j, k, n = 5;
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


    public static void customTestMethod(){
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
        System.out.println("sum " + sum);
        quickSort(array, 0, array_length - 1);

        array = null;
    }

    public static void main(String[] args) {

        customTestMethod();

    }
}
