// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Excel.Window
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Office.Interop.Excel;

[CompilerGenerated]
[InterfaceType(2)]
[Guid("00020893-0000-0000-C000-000000000046")]
[TypeIdentifier]
[ComImport]
public interface Window
{
  [SpecialName]
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  sealed extern void _VtblGap1_15();

  [DispId(645)]
  bool DisplayGridlines { [DispId(645), MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(645), MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

  [SpecialName]
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  sealed extern void _VtblGap2_68();

  [DispId(663)]
  object Zoom { [DispId(663), MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(663), MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: MarshalAs(UnmanagedType.Struct), In] set; }
}
