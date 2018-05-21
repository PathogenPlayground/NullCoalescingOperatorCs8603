using System;

namespace NullCoalescingOperatorCs8603
{
    class TestWithoutStatic
    {
        private Foo? _foo = null;
        public Foo FooProperty
        {
            get => _foo ?? (_foo = new Foo()); // warning CS8603: Possible null reference return.
        }

        public Foo FooProperty2
        {
            get
            {
                Foo? ret = null;
                return ret ?? (ret = new Foo()); // warning CS8603: Possible null reference return.
            }
        }

        private Foo? _foo3 = null;
        public Foo FooProperty3
        {
            get => _foo3 ?? new Foo(); // No warning
        }

        private Foo? _foo4 = null;
        public Foo FooProperty4
        {
            get
            {
                if (_foo4 == null)
                { _foo4 = new Foo(); }

                return _foo4; // No warning
            }
        }

        public TestWithoutStatic()
        {
            Console.WriteLine(FooProperty);
            Console.WriteLine(FooProperty);
            Console.WriteLine(FooProperty2);
            Console.WriteLine(FooProperty2);
            Console.WriteLine(FooProperty3);
            Console.WriteLine(FooProperty3);
            Console.WriteLine(FooProperty4);
            Console.WriteLine(FooProperty4);
        }
    }
}
