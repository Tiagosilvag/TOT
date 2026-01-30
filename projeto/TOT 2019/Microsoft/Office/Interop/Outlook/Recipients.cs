// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Outlook.Recipients
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Office.Interop.Outlook;

[CompilerGenerated]
[DefaultMember("Item")]
[Guid("0006303B-0000-0000-C000-000000000046")]
[TypeIdentifier]
[ComImport]
public interface Recipients : IEnumerable
{
  [SpecialName]
  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  sealed extern void _VtblGap1_6();

  [DispId(111)]
  [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
  [return: MarshalAs(UnmanagedType.Interface)]
  Recipient Add([MarshalAs(UnmanagedType.BStr), In] string Name);
}
