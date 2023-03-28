using System.Security.Cryptography;
using System;
using System.Timers;
using System.Diagnostics;
using System.Threading;

long glb = 0;
long glb1 = 0;
long methodToAnalysis(int[] arr)//             kaštai | kartai
{
    long n = arr.Length;//                            c1 + c2 | 1
    long k = n;//                                         c1 | 1
    glb = glb + 2;
    if (arr[0] > 0)//                                     c3 | 1
    {
        for (int i = 0; i < n; i++)//                     c4 | n
        {
            glb++;
            for (int j = 0; j < n; j++)//                 c5 | n^2
            {
                glb++;
                k -= 2;//                                 c6 | n^2
            }
        }
    }
    glb += 2;
    return k;//                                           c7  | 1
}


long methodToAnalysis1(int n)//             kaštai | kartai
{
    long k = 0;//                               c1 | 1
    int[] arr = new int[n];//                   c2 | 1   
    Random randNum = new Random();//            c3 | 1 
    glb1 += 3;
    for (int i = 0; i < n; i++)//               c4 | n
    {

        arr[i] = randNum.Next(0, n);//         c5 | n   
        k += arr[i] + FF2(i, arr);//          c6 | n
        glb1 += 3;
    }
    glb1++;
    return k;//                                c7 | 1
}



long FF2(int n, int[] arr)//             kaštai | kartai
{
    if (n > 0 && arr.Length > n && arr[n] > 0)// c1 + c2 + c3 | 1
    {
        return FF2(n - 1, arr) + FF2(n - 3, arr); //T(n-1) + T(n-3)  | 1
    }
    glb1 += 4;
    return n;//                                    c4 | 1   
}
void Main()
{
    int Count = 75000;
    int[] arr = new int[Count];
    Random randNum = new Random();
    for (int i = 0; i < Count; i++)
    {
        arr[i] = randNum.Next(-100000 , 0);
        //Console.WriteLine(arr[i]);
    }
    Stopwatch sw = new Stopwatch();
    /*sw.Start();
    methodToAnalysis(arr);
    sw.Stop();
    Console.WriteLine("test");
    Console.WriteLine(sw.ElapsedMilliseconds);
    Console.WriteLine(glb);
    sw.Reset();*/
    sw.Start();
    methodToAnalysis1(50);
    sw.Stop();
    Console.WriteLine(glb1);
    Console.WriteLine(sw.ElapsedMilliseconds);
}
Main();