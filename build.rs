fn main() {
    csbindgen::Builder::default()
        .input_extern_file("src/lib.rs")
        .csharp_dll_name("mylib")
        .csharp_class_name("NativeMethods")
        .generate_csharp_file("./csproj/cs-bindtest/NativeMethods.cs")
        .unwrap();
}
