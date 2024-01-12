using CsBindgen;
using System.Text;

unsafe
{
    var i32Buffer = NativeMethods.alloc_i32_buffer();
    var u8String = NativeMethods.alloc_u8_string();
    try
    {
        var str = Encoding.UTF8.GetString(u8String->AsSpan());
        Console.WriteLine(str);

        Console.WriteLine("----");

        var i32Span = i32Buffer->AsSpan<int>();
        foreach (var item in i32Span)
        {
            Console.WriteLine(item);
        }
    }
    finally
    {
        NativeMethods.free_i32_buffer(i32Buffer);
        NativeMethods.free_u8_string(u8String);
    }
}

unsafe
{
    var str = "foobarbaz:あいうえお"; // ENG:JPN(Unicode, testing for UTF16)
    fixed (char* p = str)
    {
        NativeMethods.csharp_to_rust_string((ushort*)p, str.Length);
    }
}

Console.WriteLine("\nTest finished.");
