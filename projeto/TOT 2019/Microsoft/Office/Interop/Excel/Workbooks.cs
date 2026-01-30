// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Excel.Workbooks
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
[Guid("000208DB-0000-0000-C000-000000000046")]
[DefaultMember("_Default")]
[TypeIdentifier]
[ComImport]
public interface Workbooks : IEnumerable
{
  [SpecialName]
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  sealed extern void _VtblGap1_3();

  [DispId(181)]
  [LCIDConversion(1)]
  [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
  [return: MarshalAs(UnmanagedType.Interface)]
  Workbook Add([MarshalAs(UnmanagedType.Struct), In, Optional] object Template);

  [SpecialName]
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  sealed extern void _VtblGap2_8();

  [DispId(1923)]
  [LCIDConversion(15)]
  [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
  [return: MarshalAs(UnmanagedType.Interface)]
  Workbook Open(
    [MarshalAs(UnmanagedType.BStr), In] string Filename,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object UpdateLinks,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object ReadOnly,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object Format,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object Password,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object WriteResPassword,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object IgnoreReadOnlyRecommended,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object Origin,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object Delimiter,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object Editable,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object Notify,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object Converter,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object AddToMru,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object Local,
    [MarshalAs(UnmanagedType.Struct), In, Optional] object CorruptLoad);
}
