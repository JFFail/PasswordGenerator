# Background
This is a simple application that aims to emulate the functionality of `password complex 18` that is available on [DuckDuckGo](https://duckduckgo.com/). Additionally, it will allow for the creation of multiple passwords at one time rather than just one.

## Use
    PasswordGenerator.exe length [-c] [-n #]
    PasswordGenerator.exe [-h/-?]

No parameters will display the help information. The only required parameter is the number of characters. Simple is the default value over complex. The default number of passwords returned is 1. Passwords are simply dumped to standard out so they can easily be written to a file, piped to `clip`, etc.

## Requirements
.NET is the only requirement. This can be compiled under full .NET via Visual Studio on Windows (tested with Visual Studio 2015 Community) or Mono under Linux.
