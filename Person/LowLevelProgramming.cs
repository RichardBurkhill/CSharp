using System;
using System.Runtime.InteropServices;

public class LowLevelProgramming
{
    [Flags]
    public enum FilePermissions : byte
    {
        None = 0,
        Read = 1 << 0,  // 0001
        Write = 1 << 1, // 0010
        Execute = 1 << 2 // 0100
    }

    public static void RunDemonstration()
    {
        Console.WriteLine("\n--- Demonstrating Low-Level Programming with Span<T> and Bit Manipulation ---");

        DemonstrateSpan();
        DemonstrateBitManipulation();
    }

    private static void DemonstrateSpan()
    {
        Console.WriteLine("\n--- Span<T> Demonstration ---");

        // 1. Span over an array
        int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        Console.WriteLine($"Original array: {string.Join(", ", numbers)}");

        // Create a Span over a portion of the array
        Span<int> slice = numbers.AsSpan(2, 5); // From index 2, take 5 elements (30, 40, 50, 60, 70)
        Console.WriteLine($"Span slice (original values): {string.Join(", ", slice.ToArray())}");

        // Modify elements through the Span
        for (int i = 0; i < slice.Length; i++)
        {
            slice[i] *= 2;
        }
        Console.WriteLine($"Span slice (modified values): {string.Join(", ", slice.ToArray())}");
        Console.WriteLine($"Array after Span modification: {string.Join(", ", numbers)}"); // Array is also modified

        // 2. Span with stackalloc (for small, fixed-size buffers on the stack)
        Console.WriteLine("\nUsing Span with stackalloc:");
        Span<byte> stackBuffer = stackalloc byte[10];
        for (int i = 0; i < stackBuffer.Length; i++)
        {
            stackBuffer[i] = (byte)(i * 10);
        }
        Console.WriteLine($"Stack allocated Span: {string.Join(", ", stackBuffer.ToArray())}");

        // 3. Read-only Span for strings
        string longString = "This is a very long string that we want to process efficiently.";
        ReadOnlySpan<char> wordSpan = longString.AsSpan(10, 4); // "very"
        Console.WriteLine($"ReadOnlySpan from string: '{wordSpan.ToString()}'");

        // Span for interop with unmanaged memory (advanced)
        // IntPtr unmanagedPtr = Marshal.AllocHGlobal(100);
        // Span<byte> unmanagedSpan = new Span<byte>(unmanagedPtr.ToPointer(), 100);
        // Marshal.FreeHGlobal(unmanagedPtr);
    }

    private static void DemonstrateBitManipulation()
    {
        Console.WriteLine("\n--- Bit Manipulation (BitField Concept) Demonstration ---");

        byte userPermissions = (byte)FilePermissions.None; // Start with no permissions
        Console.WriteLine($"Initial permissions: {Convert.ToString(userPermissions, 2).PadLeft(8, '0')} (Decimal: {userPermissions})");

        // Grant Read permission
        userPermissions |= (byte)FilePermissions.Read;
        Console.WriteLine($"After granting Read: {Convert.ToString(userPermissions, 2).PadLeft(8, '0')} (Decimal: {userPermissions})");

        // Grant Write permission
        userPermissions |= (byte)FilePermissions.Write;
        Console.WriteLine($"After granting Write: {Convert.ToString(userPermissions, 2).PadLeft(8, '0')} (Decimal: {userPermissions})");

        // Check for Read permission
        bool hasRead = (userPermissions & (byte)FilePermissions.Read) != 0;
        Console.WriteLine($"Has Read permission? {hasRead}");

        // Check for Execute permission
        bool hasExecute = (userPermissions & (byte)FilePermissions.Execute) != 0;
        Console.WriteLine($"Has Execute permission? {hasExecute}");

        // Grant Execute permission
        userPermissions |= (byte)FilePermissions.Execute;
        Console.WriteLine($"After granting Execute: {Convert.ToString(userPermissions, 2).PadLeft(8, '0')} (Decimal: {userPermissions})");

        // Revoke Write permission
        userPermissions &= (byte)~FilePermissions.Write; // Use bitwise NOT to create a mask
        Console.WriteLine($"After revoking Write: {Convert.ToString(userPermissions, 2).PadLeft(8, '0')} (Decimal: {userPermissions})");

        // Check all permissions
        Console.WriteLine($"Final permissions: Read={((userPermissions & (byte)FilePermissions.Read) != 0)}, Write={((userPermissions & (byte)FilePermissions.Write) != 0)}, Execute={((userPermissions & (byte)FilePermissions.Execute) != 0)}");
    }
}
