// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Excel.Hyperlinks
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Office.Interop.Excel;

[CompilerGenerated]
[DefaultMember("_Default")]
[Guid("00024430-0000-0000-C000-000000000046")]
[InterfaceType(2)]
[TypeIdentifier]
[ComImport]
public interface Hyperlinks : IEnumerable
{
  [SpecialName]
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  sealed extern void _VtblGap1_3();

  [DispId(181)]
  [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
  [return: MarshalAs(UnmanagedType.IDispatch)]
  object Add(
    [MarshalAs(UnmanagedType.IDispatch), In] object Anchor,
    [MarshalAs(UnmanagedType.BStr), In] string Address,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object SubAddress,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object ScreenTip,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object TextToDisplay);
}
