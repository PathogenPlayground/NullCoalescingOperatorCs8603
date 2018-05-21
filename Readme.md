This repository demonstrates a bug in the 05/14/18 C# [Nullable Reference Types Preview](https://github.com/dotnet/csharplang/wiki/Nullable-Reference-Types-Preview) with Visual Studio 2017 15.7.1. It corresponds to [dotnet/roslyn#27009](https://github.com/dotnet/roslyn/issues/27009).

# Project Setup

The project features a handful of properties on `Program` that return non-null references using the null coalescing operator:

Property|Description
----|----
`FooProperty`|Lazy-initializes a field inside the right-hand side of a null coalescing operator
`FooProperty2`|"Lazy-initializes" a local variable inside the right-hand side of a null coalescing operator
`FooProperty3`|Returns a field or a new instance using a null coalescing operator
`FooProperty4`|Lazy-initializes a field without using the null coalescing operator

(`FooProperty2` exists to make sure this problem isn't related to [dotnet/roslyn#9978](https://github.com/dotnet/roslyn/issues/9978).)

# Actual Behavior

The compiler reports the following warning for `FooProperty` and `FooProperty2`:

```
warning CS8603: Possible null reference return.
```

# Expected Behavior

No warning is reported because the assignment causes the `_foo` field/`ret` variable to be initialized with a non-null value.
