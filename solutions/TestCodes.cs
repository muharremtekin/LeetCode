

// Example 1:

// Input: str1 = "ABCABC", str2 = "ABC"
// Output: "ABC"
// Example 2:

// Input: str1 = "ABABAB", str2 = "ABAB"
// Output: "AB"
// Example 3:

// Input: str1 = "LEET", str2 = "CODE"
// Output: ""

// long sum(long n)
// {

// }
/// verilen N sayısının mutlak değerini verir
/// [int n]
long mutlak(long num) => num >= 0 ? num : -1 * num;

long SumN(long n) =>
    n >= 0 ? // n 0'dan büyük mü?
        n * (n + 1) / 2 : // büyük ise normal işlem
        -1 * n * (mutlak(n) + 1) / 2; // mutlak değeri alıp -1 ile çarparak pozitife döndürüyoruz
long NeKadarOlanTekSayTopla(long n)
{
    n = (++n) / 2;
    return n * n;
}
long NeKadarOlanCiftSayTopla(long n) =>
    n / 2 * (n / 2 + 1);
const double PI = 3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679;
// 31,41592653589793
// const double PI = 3.14;
// 31,400000000000002
double daireCevresi(double r) =>  PI * r * r;

double daireAlani(double r, double a) => a / 360 * daireCevresi(r);


Console.WriteLine(daireAlani(100, 50));