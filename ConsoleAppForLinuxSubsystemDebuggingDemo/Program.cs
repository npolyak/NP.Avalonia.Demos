using System.Runtime.InteropServices;

// Various ways to get information about the OS

bool isLinux = OperatingSystem.IsLinux();

if (isLinux)
{
    Console.WriteLine("Yes, it is Linux!!!");
}
else
{
    Console.WriteLine("No, it is not Linux");
}

if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    Console.WriteLine("Yes, indeed Linux!!!");
}

Console.WriteLine($"RuntimeInformation.OSDescription = '{RuntimeInformation.OSDescription}'");

// gives Linux type, version number and architecture:
Console.WriteLine($"RuntimeInformation.RuntimeIdentifier = '{RuntimeInformation.RuntimeIdentifier}'");

Console.WriteLine($"Environment.OSVersion = '{Environment.OSVersion}'");