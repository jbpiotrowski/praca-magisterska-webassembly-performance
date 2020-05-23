#include <stdio.h>
#include <stdbool.h>
#include <time.h>
#include <string.h>
//#include <windows.h>

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
    // Create a boolean array "prime[0..n]" and initialize
    // all entries it as true. A value in prime[i] will
    // finally be false if i is Not a prime, else true.
    bool prime[n+1];
    memset(prime, true, sizeof(prime));

    for (int p=2; p*p<=n; p++)
    {
        // If prime[p] is not changed, then it is a prime
        if (prime[p] == true)
        {
            // Update all multiples of p greater than or
            // equal to the square of it
            // numbers which are multiple of p and are
            // less than p^2 are already been marked.
            for (int i=p*p; i<=n; i += p)
                prime[i] = false;
        }
    }

    // Print all prime numbers
    for (int p=2; p<=n; p++)
        if (prime[p])
            printf("%d ", p);
}


int main() {
    clock_t start = clock();
    printf("%llu\n", AckermanFunction(3,13));
    clock_t end = clock();
    printf("%f\n", (float)(end - start) / CLOCKS_PER_SEC);
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
