// Decompiled with JetBrains decompiler
// Type: TOT.frmProcesso
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmProcesso : Form
{
  private IContainer components = (IContainer) null;
  private TabControl tabControl1;
  private TabPage tabPage1;
  private TabPage tabPage2;
  private TabPage tabPage3;
  private TabPage tabPage4;
  private TabPage tabPage5;

  public frmProcesso() => this.InitializeComponent();

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.tabControl1 = new TabControl();
    this.tabPage1 = new TabPage();
    this.tabPage2 = new TabPage();
    this.tabPage3 = new TabPage();
    this.tabPage4 = new TabPage();
    this.tabPage5 = new TabPage();
    this.tabControl1.SuspendLayout();
    this.SuspendLayout();
    this.tabControl1.Controls.Add((Control) this.tabPage1);
    this.tabControl1.Controls.Add((Control) this.tabPage4);
    this.tabControl1.Controls.Add((Control) this.tabPage2);
    this.tabControl1.Controls.Add((Control) this.tabPage3);
    this.tabControl1.Controls.Add((Control) this.tabPage5);
    this.tabControl1.Location = new Point(2, 3);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new Size(932, 479);
    this.tabControl1.TabIndex = 1;
    this.tabPage1.Location = new Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new Padding(3);
    this.tabPage1.Size = new Size(924, 453);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "Usuários";
    this.tabPage1.UseVisualStyleBackColor = true;
    this.tabPage2.Location = new Point(4, 22);
    this.tabPage2.Name = "tabPage2";
    this.tabPage2.Padding = new Padding(3);
    this.tabPage2.Size = new Size(924, 453);
    this.tabPage2.TabIndex = 1;
    this.tabPage2.Text = "Segmento";
    this.tabPage2.UseVisualStyleBackColor = true;
    this.tabPage3.Location = new Point(4, 22);
    this.tabPage3.Name = "tabPage3";
    this.tabPage3.Size = new Size(924, 453);
    this.tabPage3.TabIndex = 2;
    this.tabPage3.Text = "Período";
    this.tabPage3.UseVisualStyleBackColor = true;
    this.tabPage4.Location = new Point(4, 22);
    this.tabPage4.Name = "tabPage4";
    this.tabPage4.Size = new Size(924, 453);
    this.tabPage4.TabIndex = 3;
    this.tabPage4.Text = "Tabelas";
    this.tabPage4.UseVisualStyleBackColor = true;
    this.tabPage5.Location = new Point(4, 22);
    this.tabPage5.Name = "tabPage5";
    this.tabPage5.Size = new Size(924, 453);
    this.tabPage5.TabIndex = 4;
    this.tabPage5.Text = "Indicador";
    this.tabPage5.UseVisualStyleBackColor = true;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(935, 482);
    this.Controls.Add((Control) this.tabControl1);
    this.Name = "formProcesso";
    this.Text = "Parâmetros";
    this.tabControl1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
