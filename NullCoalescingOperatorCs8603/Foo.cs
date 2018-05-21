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
}
