// Decompiled with JetBrains decompiler
// Type: TOT.frmDataQuality
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmDataQuality : Form
{
  private IContainer components = (IContainer) null;
  private TabControl tabControl1;
  private TabPage tabInicio;
  private GroupBox groupBox1;
  private TabPage tabAnalitico;
  private DataGridView dgvVariacao6m;

  public frmDataQuality() => this.InitializeComponent();

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.tabControl1 = new TabControl();
    this.tabInicio = new TabPage();
    this.tabAnalitico = new TabPage();
    this.groupBox1 = new GroupBox();
    this.dgvVariacao6m = new DataGridView();
    this.tabControl1.SuspendLayout();
    this.tabInicio.SuspendLayout();
    this.groupBox1.SuspendLayout();
    ((ISupportInitialize) this.dgvVariacao6m).BeginInit();
    this.SuspendLayout();
    this.tabControl1.Controls.Add((Control) this.tabInicio);
    this.tabControl1.Controls.Add((Control) this.tabAnalitico);
    this.tabControl1.Location = new Point(12, 12);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new Size(1042, 470);
    this.tabControl1.TabIndex = 0;
    this.tabInicio.Controls.Add((Control) this.groupBox1);
    this.tabInicio.Location = new Point(4, 22);
    this.tabInicio.Name = "tabInicio";
    this.tabInicio.Padding = new Padding(3);
    this.tabInicio.Size = new Size(1034, 444);
    this.tabInicio.TabIndex = 0;
    this.tabInicio.Text = "Início";
    this.tabInicio.UseVisualStyleBackColor = true;
    this.tabAnalitico.Location = new Point(4, 22);
    this.tabAnalitico.Name = "tabAnalitico";
    this.tabAnalitico.Padding = new Padding(3);
    this.tabAnalitico.Size = new Size(1034, 444);
    this.tabAnalitico.TabIndex = 1;
    this.tabAnalitico.Text = "Analítico";
    this.tabAnalitico.UseVisualStyleBackColor = true;
    this.groupBox1.Controls.Add((Control) this.dgvVariacao6m);
    this.groupBox1.Location = new Point(7, 7);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(1002, 140);
    this.groupBox1.TabIndex = 0;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "groupBox1";
    this.dgvVariacao6m.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvVariacao6m.Location = new Point(6, 19);
    this.dgvVariacao6m.Name = "dgvVariacao6m";
    this.dgvVariacao6m.Size = new Size(575, 108);
    this.dgvVariacao6m.TabIndex = 0;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1060, 494);
    this.Controls.Add((Control) this.tabControl1);
    this.Name = nameof (frmDataQuality);
    this.Text = nameof (frmDataQuality);
    this.tabControl1.ResumeLayout(false);
    this.tabInicio.ResumeLayout(false);
    this.groupBox1.ResumeLayout(false);
    ((ISupportInitialize) this.dgvVariacao6m).EndInit();
    this.ResumeLayout(false);
  }
}
