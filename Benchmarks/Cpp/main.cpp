#include <cstdio>

#include <ctime>
#include <cstring>
//#include <windows.h>
#include <cmath>
#include <iomanip>
#include <iostream>
#include <chrono>

using  namespace std;
using namespace std::chrono;

const int TEST_REPEAT = 100;
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
void SieveOfEratosthenes(long long unsigned int n)
{
    bool prime[n+1];
    memset(prime, true, sizeof(prime));

    for (long long unsigned int p=2; p*p<=n; p++)
    {
        if (prime[p])
        {
            for (long long unsigned int i=p*p; i<=n; i += p)
                prime[i] = false;
        }
    }
//    for (int p=2; p<=n; p++)
//        if (prime[p])
//            printf("%d ", p);
}
bool gauss (int n,  double ** AB, double * X )
{
    const double eps = 1e-12; // stała przybliżenia zera
    int i, j, k;
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

void testGauss(int testNumber){
    float minTime = 100, maxTime= 0, sum = 0;
    int values[] = {8,37, 26, 87, 13, 9, 18, 67, 99, 101, 33,
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
        clock_t start = clock();
        for(int it = 0; it < 10000; it++) {

            double **AB, *X;
            int n = 10, i, j;

            // tworzymy macierze AB i X

            AB = new double *[n];
            X = new double[n];


            for (i = 0; i < n; i++) AB[i] = new double[n + 1];

            // odczytujemy dane dla macierzy AB
            int k = 0;
            for (i = 0; i < n; i++)
                for (j = 0; j <= n; j++) {
                    AB[i][j] = values[k];
                    k++;
                }
//            auto start_time = std::chrono::high_resolution_clock::now();


            bool result = gauss(n, AB, X);
            delete AB;
            delete X;
//            auto end_time = std::chrono::high_resolution_clock::now();
//            if (result) {
//                for (i = 0; i < n; i++)
//                    cout << "x" << i + 1 << " = " << setw(9) << X[i]
//                         << endl;
//            } else
//                cout << "DZIELNIK ZERO\n";

        }
        clock_t end = clock();
        float elapsedTime =(float)(end - start) / CLOCKS_PER_SEC;
//            float elapsedTime = (end_time - start_time) / std::chrono::nanoseconds(1);
        if (elapsedTime < minTime)
            minTime = elapsedTime;
        if (elapsedTime > maxTime)
            maxTime = elapsedTime;
        sum += elapsedTime;
    }

    cout<<"Gauss mean: "<<sum/testNumber<<endl;
    cout<<"Gauss max: "<<maxTime<<endl;
    cout<<"Gauss min: "<<minTime<<endl;

}

void testAckerman(int testNumber){
    float minTime = 100, maxTime= 0, sum = 0;
    for (int i = 0; i<testNumber; i++){
        clock_t start = clock();
        for(int it=0; it< TEST_REPEAT; it++){
            AckermanFunction(3,8);
        }
    clock_t end = clock();
    float elapsedTime =(float)(end - start) / CLOCKS_PER_SEC;
    if(elapsedTime < minTime)
        minTime = elapsedTime;
    if(elapsedTime > maxTime)
        maxTime = elapsedTime;
    sum += elapsedTime;
    }

    cout<<"Ackerman mean: "<<sum/testNumber<<endl;
    cout<<"Ackerman max: "<<maxTime<<endl;
    cout<<"Ackerman min: "<<minTime<<endl;
}
void testFibonacci(int testNumber){
    float minTime = 100, maxTime= 0, sum = 0;
    for (int i = 0; i<testNumber; i++){
        clock_t start = clock();
        for(int it=0; it< 100000; it++){
            FibonacciSequence(70);
        }
        clock_t end = clock();
        float elapsedTime =(float)(end - start) / CLOCKS_PER_SEC;
        if(elapsedTime < minTime)
            minTime = elapsedTime;
        if(elapsedTime > maxTime)
            maxTime = elapsedTime;
        sum += elapsedTime;
    }

    cout<<"Fibonacci mean: "<<sum/testNumber<<endl;
    cout<<"Fibonacci max: "<<maxTime<<endl;
    cout<<"Fibonacci min: "<<minTime<<endl;
}

void testEratosthenes(int testNumber){
    float minTime = 100, maxTime= 0, sum = 0;
    for (int i = 0; i<testNumber; i++){
        clock_t start = clock();
        for(int it=0; it< 10; it++){
            SieveOfEratosthenes(1000000);
        }

        clock_t end = clock();
        float elapsedTime =(float)(end - start) / CLOCKS_PER_SEC;
        if(elapsedTime < minTime)
            minTime = elapsedTime;
        if(elapsedTime > maxTime)
            maxTime = elapsedTime;
        sum += elapsedTime;
    }

    cout<<"Eratosthenes mean: "<<sum/testNumber<<endl;
    cout<<"Eratosthenes max: "<<maxTime<<endl;
    cout<<"Eratosthenes min: "<<minTime<<endl;
}



int main() {
    testEratosthenes(20);
    testAckerman(20);
    testFibonacci(20);
    testGauss(20);
    return 0;
}
