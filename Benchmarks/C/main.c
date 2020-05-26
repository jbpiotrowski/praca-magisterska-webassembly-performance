#include <stdio.h>
#include <stdbool.h>
#include <time.h>
#include <string.h>
//#include <windows.h>
#include <math.h>
unsigned  long long int AckermanFunction(unsigned  long long int m, unsigned  long long int n){
    if (m == 0)
        return (n+1);
    if (m> 0 && n == 0)
        return AckermanFunction(m - 1, 1);
    if (m > 0 && n > 0)
        return AckermanFunction(m - 1, AckermanFunction(m, n - 1));
    return n;
}

long long unsigned int FibonacciSequence(int n){
    if (n == 0 ) return 0;
    if (n == 1) return  1;
    long long unsigned int a = 0;
    long long unsigned int b = 1;
    long long unsigned int sum;
    for(int i = 2; i <= n; i++){
        sum = a + b;
        a = b;
        b = sum;
    }
    return b;
}
void SieveOfEratosthenes(int n)
{
    bool prime[n+1];
    memset(prime, true, sizeof(prime));

    for (int p=2; p*p<=n; p++)
    {
        if (prime[p] == true)
        {
            for (int i=p*p; i<=n; i += p)
                prime[i] = false;
        }
    }
    for (int p=2; p<=n; p++)
        if (prime[p])
            printf("%d ", p);
}
bool gauss (  double ** AB, double * X )
{
    const double eps = 1e-12; // stała przybliżenia zera
    int i, j, k, n = 5;
    double m, s;

    // eliminacja współczynników
    for( i = 0; i < n - 1; i++ )
    {
        for( j = i + 1; j < n; j++ )
        {
            if( fabs ( AB [ i ][ i ] ) < eps ) return false;
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
        if( fabs ( AB [ i ][ i ] ) < eps ) return false;
        X [ i ] = s / AB [ i ][ i ];
    }
    return true;
}

int main() {
    clock_t start = clock();
    printf("%llu\n", AckermanFunction(3,13));
//    SieveOfEratosthenes(50);
    clock_t end = clock();
    printf("%f\n", (float)(end - start) / CLOCKS_PER_SEC);
    scanf("%d");
//    float seconds = (float)(end - start) / CLOCKS_PER_SEC;

//    LARGE_INTEGER frequency;        // ticks per second
//    LARGE_INTEGER t1, t2;           // ticks
//    double elapsedTime;
//
//    // get ticks per second
//    QueryPerformanceFrequency(&frequency);
//
//    // start timer
//    QueryPerformanceCounter(&t1);
//

//    // stop timer
//    QueryPerformanceCounter(&t2);
//
//    // compute and print the elapsed time in millisec
//    elapsedTime = (t2.QuadPart - t1.QuadPart) * 1000.0 / frequency.QuadPart;
//    printf("\n%f", elapsedTime);
    return 0;
}
