# THE WHAT?

You heard that right! With this library, you can obtain an instance of `void` (although boxed). It has never been easier!

```cs
object @void = Void.Get();
```

Don't believe me? Try it for yourself!

```cs
Assert.Equal(typeof(void), @void.GetType()); // True
```
