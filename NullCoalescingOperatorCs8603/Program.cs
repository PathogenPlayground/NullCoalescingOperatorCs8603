using System;

namespace NullCoalescingOperatorCs8603
{
    class Foo
    {
        private static int _nextInstanceNumber = 0;
        public int InstanceNumber { get; }

        public Foo()
        {
            InstanceNumber = _nextInstanceNumber;
            _nextInstanceNumber++;
        }

        public override string ToString()
            => $"Foo #{InstanceNumber}";
    }

    class Program
    {
        private static Foo? _foo = null;
        public static Foo FooProperty
        {
            get => _foo ?? (_foo = new Foo()); // warning CS8603: Possible null reference return.
        }

        public static Foo FooProperty2
        {
            get
            {
                Foo? ret = null;
                return ret ?? (ret = new Foo()); // warning CS8603: Possible null reference return.
            }
        }

        private static Foo? _foo3 = null;
        public static Foo FooProperty3
        {
            get => _foo3 ?? new Foo(); // No warning
        }

        private static Foo? _foo4 = null;
        public static Foo FooProperty4
        {
            get
            {
                if (_foo4 == null)
                { _foo4 = new Foo(); }

                return _foo4; // warning CS8603: Possible null reference return.
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(FooProperty);
            Console.WriteLine(FooProperty);
            Console.WriteLine(FooProperty2);
            Console.WriteLine(FooProperty2);
            Console.WriteLine(FooProperty3);
            Console.WriteLine(FooProperty3);
            Console.WriteLine(FooProperty4);
            Console.WriteLine(FooProperty4);
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
