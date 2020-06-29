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
     static void sieveOfEratosthenes(int n)
    {
        // Create a boolean array "prime[0..n]" and initialize
        // all entries it as true. A value in prime[i] will
        // finally be false if i is Not a prime, else true.
        boolean[] prime = new boolean[n+1];
        for(int i=0;i<n;i++)
            prime[i] = true;

        for(int p = 2; p*p <=n; p++)
        {
            // If prime[p] is not changed, then it is a prime
            if(prime[p])
            {
                // Update all multiples of p
                for(int i = p*p; i <= n; i += p)
                    prime[i] = false;
            }
        }

        // Print all prime numbers
        for(int i = 2; i <= n; i++)
        {
            if(prime[i])
                System.out.print(i + " ");
        }
    }


    boolean gauss (double[][] AB, double[] X)
    {
     final double eps = 1e-12; // stała przybliżenia zera
        int i, j, k, n = 5;
        double m, s;

        // eliminacja współczynników
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
        // wyliczanie niewiadomych

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

    public static void main(String[] args) {
    System.out.println("Testing WASM");
    }
}
