using System;

namespace ConsoleApplication1
{
    struct MyFrac
    {
        public long nom, denom;
        public MyFrac(long nom_, long denom_)
        {
            nom = nom_;
            denom = denom_;
            if (denom<0)
            {
                denom *= -1;
                nom *= -1;
            }
            long a = nom;
            long b = denom;
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            nom /= a; 
            denom/=a;
        }

        public override string ToString() => denom != 1 ? $"{nom}/{denom}" : $"{nom}";
    }
    internal class Program
    {
        static string ToStringWithIntegerPart(MyFrac f)
        {
            var nom = f.nom;
            var denom = f.denom;
            if (nom>denom)
            {
                return $"{nom/denom} + {nom%denom}/{denom}";
            }
            else if(nom==denom)
            {
                return $"{nom / denom}";
            }
            else
            {
                return $"{nom}/{denom}";
            }
        }
        
        static double DoubleValue(MyFrac f)
        {
            return Convert.ToDouble(f.nom) / Convert.ToDouble(f.denom);
        }

        static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f2.nom * f1.denom, f1.denom * f2.denom);
        }
        static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f2.nom * f1.denom, f1.denom * f2.denom);
        }

        static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }
        static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }

        static MyFrac CalcSum1(int n)
        {
            MyFrac first = new MyFrac (1, 2);
            for (int j = 2; j <= n; j++)
            {
                MyFrac neu = new MyFrac(1, j * (j + 1));
                first = Plus(first, neu);
            }
            return first;
        }
        static MyFrac CalcSum2(int n)
        {
            MyFrac first = new MyFrac (3, 4);
            for (int j = 3; j <= n; j++)
            {
                MyFrac neu = new MyFrac(j*j-1, j * j);
                first = Multiply(first, neu);
            }
            return first;
        }
        public static void Main(string[] args)
        { 
            MyFrac res_1 = new MyFrac(34, 8);
            MyFrac res_2 = new MyFrac(3, 4);
            Console.WriteLine(res_1);
            Console.WriteLine(ToStringWithIntegerPart(res_1));
            Console.WriteLine($"Результат: {DoubleValue(res_1)}");
            Console.WriteLine($"Результат додавання двох дробів: {Plus(res_1,res_2)}");
            Console.WriteLine($"Результат віднімання двох дробів:{Minus(res_1,res_2)}");
            Console.WriteLine($"Результат множення двох дробів: {Multiply(res_1,res_2)}");
            Console.WriteLine($"Результат ділення двох дробів: {Divide(res_1,res_2)}");
            Console.WriteLine($"{CalcSum1(6)}");
            Console.WriteLine($"{CalcSum2(8)}");
        }
    }
}