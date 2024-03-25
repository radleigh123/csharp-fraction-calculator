using System;

namespace FractionForm
{
    public class Fraction
    {
        private int num;
        private int deno;

        public Fraction(int num, int deno)
        {
            if (deno == 0)
                throw new System.ArgumentException("Denominator cannot be zero.");

            this.num = num;
            this.deno = deno;
        }

        public int GetNum() => num;
        public int GetDeno() => deno;

        public static Fraction operator +(Fraction f1) => f1;
        public static Fraction operator -(Fraction f1) => new Fraction(-f1.num, f1.deno);

        public static Fraction operator +(Fraction f1, Fraction f2)
            => new Fraction(f1.num * f2.deno + f2.num * f1.deno, f1.deno * f2.deno);

        public static Fraction operator -(Fraction f1, Fraction f2)
            => f1 + (-f2);

        public static Fraction operator *(Fraction f1, Fraction f2) 
            => new Fraction(f1.num * f2.num, f1.deno * f2.deno);

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.num == 0)
                throw new DivideByZeroException();

            return new Fraction(f1.num * f2.deno, f1.deno * f2.num);
        }

        public override string ToString() => $"{num}/{deno}";
    }
}