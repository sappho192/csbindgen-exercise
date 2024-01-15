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

unsafe
{
    Console.WriteLine("Sending int array to rust...");
    var data = new uint[] { 25906, 8702, 7801, 25856 };
    fixed (uint* p = data)
    {
        NativeMethods.csharp_to_rust_u32_array(p, data.Length);
    }
}

unsafe
{
    Console.WriteLine("Testing tokenizer...");
    var data = new uint[] { 25906, 8702, 7801, 25856 };
    fixed (uint* p = data)
    {
        var decoded = NativeMethods.tokenizer_decode(p, data.Length);
        try
        {
            var str = Encoding.UTF8.GetString(decoded->AsSpan());
            Console.WriteLine(str);
        }
        finally
        {
            NativeMethods.free_u8_string(decoded);
        }
    }
}

Console.WriteLine("\nTest finished.");
