function AckermanFunction(m, n){
    if (m == 0)
        return (n+1);
    if (m> 0 && n == 0)
        return AckermanFunction(m - 1, 1);
    if (m > 0 && n > 0)
        return AckermanFunction(m - 1, AckermanFunction(m, n - 1));
    return n;
}

function FibonacciSequence(n){
    if (n == 0 ) return 0;
    if (n == 1) return  1;
    var a = 0, b = 1, sum;
    
    for(var i = 2; i <= n; i++){
        sum = a + b;
        a = b;
        b = sum;
    }
    return b;
}

function SieveOfEratosthenes(n)
{
    var prime = [];
    for(var i = 0; i < n; i++)
        prime.push(true);

    for (var p=2; p*p<=n; p++)
    {
        if (prime[p] == true)
        {
            for (var i=p*p; i<=n; i += p)
                prime[i] = false;
        }
    }   
}

function gauss (n, AB,  X )
{
    const  eps = 1e-12; // stała przybliżenia zera
    var i, j, k;
    var m, s;

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

function partition(array, low, high)
{
    var x = array[low];
    var i = low, j = high, w;
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

function quickSort(array, low, high)
{
    var pivot;
    if (low < high)
    {
        pivot = partition(array, low, high);
        quickSort(array, low, pivot);
        quickSort(array, pivot + 1, high);
    }
}


function customTestMethod(){
    var moduloNumber = 867;
    var sum = 0;
    var array_length = 1000000;
    var innerLoopBound = 100000;
    var array = new Array(array_length);

    for (var index = 0; index < array_length; index++)
        array[index] = index % moduloNumber;

    for (var iteration = 0; iteration < 100; iteration++)
        for (var innerloop = 0; innerloop < innerLoopBound; innerloop++)
            sum += array[(iteration + innerloop) % array_length];
    console.log(`sum ${sum}`);
    quickSort(array, 0, array_length - 1);
    
    array = 0;
}

function testAckerman(testNumber){
    var minTime = 100, maxTime= 0, sum = 0;
    for (var i = 0; i<testNumber; i++){
        var start = new Date();
        for(var it = 0; it< 100; it++){
            AckermanFunction(3,8);
        }
    var end = new Date();
    var elapsedTime =(end - start);
    if(elapsedTime < minTime)
        minTime = elapsedTime;
    if(elapsedTime > maxTime)
        maxTime = elapsedTime;
    sum += elapsedTime;
    }

    console.log("Ackerman mean: " + (sum/testNumber)/1000)
    console.log("Ackerman max: " +(maxTime)/1000)
    console.log("Ackerman min: "+(minTime)/1000)
}
function testFibonacci(testNumber){
    var minTime = 100, maxTime= 0, sum = 0;
    for (var i = 0; i<testNumber; i++){
        var start = new Date();
        for(var it = 0; it< 100000; it++){
            FibonacciSequence(70);
        }
         
        var  end = new Date();
        var  elapsedTime =(end - start);
        if(elapsedTime < minTime)
            minTime = elapsedTime;
        if(elapsedTime > maxTime)
            maxTime = elapsedTime;
        sum += elapsedTime;
    }

    console.log("Fibonacci mean: " + (sum/testNumber)/1000)
    console.log("Fibonacci max: " +(maxTime)/1000)
    console.log("Fibonacci min: "+(minTime)/1000)
}

function testEratosthenes( testNumber){
    var minTime = 100, maxTime= 0, sum = 0;
    for (var i = 0; i<testNumber; i++){
        var start = new Date();
        for(var it = 0; it< 10; it++){
            SieveOfEratosthenes(1000000);
        }
        var end = new Date();
        var elapsedTime =(end - start);
        if(elapsedTime < minTime)
            minTime = elapsedTime;
        if(elapsedTime > maxTime)
            maxTime = elapsedTime;
        sum += elapsedTime;
    }

    console.log("Eratosthenes mean: " + (sum/testNumber)/1000)
    console.log("Eratosthenes max: " +(maxTime)/1000)
    console.log("Eratosthenes min: "+(minTime)/1000)
}

function testGauss(testNumber){
    var minTime = 100, maxTime= 0, sum = 0;
    var values = [[8,37, 26, 87, 13, 9, 18, 67, 99, 101, 33],
                    [15, 77, 93, 13, 51, 16, 477, 501, 613, 718, 413],
                    [18, 111, 135, 187, 15, 313, 314, 1001, 1120, 813, 1013],
                    [89, 234, 153, 100, 73, 67, 1300, 1402, 1513, 1478, 1069],
                    [372, 147, 169, 293, 14, 156, 777, 813, 616, 341, 2013],
                    [141, 278, 347, 847, 613, 178, 993, 3014, 205, 947, 323],
                    [4017, 7314, 7891, 5661, 3017, 11024, 8751, 9931, 14759, 64789, 648],
                    [60781, 7015, 3017, 9781, 24431, 31586, 8589, 13589, 45895, 84621, 5489],
                    [51684, 12354, 12387, 64898, 13325, 14798, 15435, 87982, 14898, 36548, 51687],
                    [15648, 235489, 546879, 564898, 302156, 486897, 38879, 68795, 13248, 65489, 16879]];

    for (var test = 0; test<testNumber; test++){
        var start = new Date();
        for(var it = 0; it < 10000; it++) {

            var AB =[], X=[];
            var n = 10, i, j;

            // for (i = 0; i < n; i++) AB[i] = new double[n + 1];

            // odczytujemy dane dla macierzy AB
            var k = 0;
            for (i = 0; i < n; i++)                
                AB.push(values[i])                    
                
//            auto start_time = std::chrono::high_resolution_clock::now();


            var result = gauss(n, AB, X);

//            auto end_time = std::chrono::high_resolution_clock::now();
//            if (result) {
//                for (i = 0; i < n; i++)
//                    cout << "x" << i + 1 << " = " << setw(9) << X[i]
//                         << endl;
//            } else
//                cout << "DZIELNIK ZERO\n";

        }
        var end = new Date();
        var elapsedTime =(end - start);
//            float elapsedTime = (end_time - start_time) / std::chrono::nanoseconds(1);
        if (elapsedTime < minTime)
            minTime = elapsedTime;
        if (elapsedTime > maxTime)
            maxTime = elapsedTime;
        sum += elapsedTime;
    }
    console.log("Gauss mean: " + (sum/testNumber)/1000)
    console.log("Gauss max: " +(maxTime)/1000)
    console.log("Gauss min: "+(minTime)/1000)
}


// testEratosthenes(20);
// testAckerman(20);
// testFibonacci(20);
// testGauss(20);
customTestMethod();