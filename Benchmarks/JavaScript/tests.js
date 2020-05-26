function AckermanFunction(m,  n){
    if (m == 0)
        return (n+1);
    if (m> 0 && n == 0)
        return AckermanFunction(m - 1, 1);
    if (m > 0 && n > 0)
        return AckermanFunction(m - 1, AckermanFunction(m, n - 1));
    return n;
}

function FibonacciSequence( n){
    if (n == 0 ) return 0;
    if (n == 1) return  1;
    var a = 0;
    var  b = 1;
    var sum;
    for(var i = 2; i <= n; i++){
        sum = a + b;
        a = b;
        b = sum;
    }
    return b;
}

function SieveOfEratosthenes( n)
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
    for (var p=2; p<=n; p++)
        if (prime[p])
            console.log(`${p} `);
}
SieveOfEratosthenes(50)