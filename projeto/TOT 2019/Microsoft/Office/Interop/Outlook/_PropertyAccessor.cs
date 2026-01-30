// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Outlook._PropertyAccessor
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Office.Interop.Outlook;

[CompilerGenerated]
[Guid("0006302D-0000-0000-C000-000000000046")]
[TypeIdentifier]
[ComImport]
public interface _PropertyAccessor
{
  [SpecialName]
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  sealed extern void _VtblGap1_5();

  [DispId(64252)]
  [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
  void SetProperty([MarshalAs(UnmanagedType.BStr), In] string SchemaName, [MarshalAs(UnmanagedType.Struct), In] object Value);
}
