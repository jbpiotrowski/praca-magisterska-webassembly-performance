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
            // Create a boolean array "prime[0..n]" and initialize
            // all entries it as true. A value in prime[i] will
            // finally be false if i is Not a prime, else true.
            var prime = new bool[n+1];
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
                    Console.WriteLine(i + " ");
            }
        }
        public bool gauss (double[][] ab, double[] x)
        {
            const double eps = 1e-12; // stała przybliżenia zera
            int i, j, k, n = 5;
            double m, s;

            // eliminacja współczynników
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
            // wyliczanie niewiadomych

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
        public static void Main()
        {
           Console.WriteLine(AckermanFunction(3,4));
        }
    }
}