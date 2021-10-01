# Introduction
Use the `Option` class to avoid handling null.

This `Option` class allows us to avoid handling null values.
This is the equivalent to the Option construct in F#

## To use a None object
```
Option<string>.None;
```

## To create a new object
```
var option = Option<int>.Create(5);
```

## Check if option is empty
```
if (option.IsNone)
{
  ...
}
```
