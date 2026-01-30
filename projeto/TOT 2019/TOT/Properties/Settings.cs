// Decompiled with JetBrains decompiler
// Type: TOT.Properties.Settings
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace TOT.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.6.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
  private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

  private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
  {
  }

  private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
  {
  }

  public static Settings Default
  {
    get
    {
      Settings defaultInstance = Settings.defaultInstance;
      return defaultInstance;
    }
  }

  [UserScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("100")]
  public int NuMaxLinhasDataGridPrincipal
  {
    get => (int) this[nameof (NuMaxLinhasDataGridPrincipal)];
    set => this[nameof (NuMaxLinhasDataGridPrincipal)] = (object) value;
  }

  [ApplicationScopedSetting]
  [DebuggerNonUserCode]
  [DefaultSettingValue("14/05/2025")]
  public string DataVersao => (string) this[nameof (DataVersao)];
}
