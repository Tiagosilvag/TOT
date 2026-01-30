// Decompiled with JetBrains decompiler
// Type: TOT.frmCalculo
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmCalculo : Form
{
  private IContainer components = (IContainer) null;
  private TabControl tabCalculoRV;
  private TabPage tabPaginaInicial;
  private TabControl tabGrids;
  private TabPage tabNovaConsulta;
  private TabControl tabControl1;
  private TabPage tabConexoes;
  private Panel panel1;
  private TreeView trvConexoes;

  public frmCalculo() => this.InitializeComponent();

  private void frmCalculo_Load(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    TreeNode treeNode = new TreeNode("Principal");
    this.tabCalculoRV = new TabControl();
    this.tabPaginaInicial = new TabPage();
    this.tabGrids = new TabControl();
    this.tabNovaConsulta = new TabPage();
    this.tabControl1 = new TabControl();
    this.tabConexoes = new TabPage();
    this.panel1 = new Panel();
    this.trvConexoes = new TreeView();
    this.tabCalculoRV.SuspendLayout();
    this.tabGrids.SuspendLayout();
    this.tabControl1.SuspendLayout();
    this.tabConexoes.SuspendLayout();
    this.panel1.SuspendLayout();
    this.SuspendLayout();
    this.tabCalculoRV.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.tabCalculoRV.Controls.Add((Control) this.tabPaginaInicial);
    this.tabCalculoRV.Location = new Point(3, 2);
    this.tabCalculoRV.Name = "tabCalculoRV";
    this.tabCalculoRV.SelectedIndex = 0;
    this.tabCalculoRV.Size = new Size(1235, 117);
    this.tabCalculoRV.TabIndex = 0;
    this.tabPaginaInicial.Location = new Point(4, 22);
    this.tabPaginaInicial.Name = "tabPaginaInicial";
    this.tabPaginaInicial.Padding = new Padding(3);
    this.tabPaginaInicial.Size = new Size(1227, 91);
    this.tabPaginaInicial.TabIndex = 0;
    this.tabPaginaInicial.Text = "Página inicial";
    this.tabPaginaInicial.UseVisualStyleBackColor = true;
    this.tabGrids.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabGrids.Controls.Add((Control) this.tabNovaConsulta);
    this.tabGrids.Location = new Point(268, 121);
    this.tabGrids.Name = "tabGrids";
    this.tabGrids.SelectedIndex = 0;
    this.tabGrids.Size = new Size(970, 380);
    this.tabGrids.TabIndex = 2;
    this.tabNovaConsulta.Location = new Point(4, 22);
    this.tabNovaConsulta.Name = "tabNovaConsulta";
    this.tabNovaConsulta.Padding = new Padding(3);
    this.tabNovaConsulta.Size = new Size(962, 354);
    this.tabNovaConsulta.TabIndex = 1;
    this.tabNovaConsulta.Text = "*Nova";
    this.tabNovaConsulta.UseVisualStyleBackColor = true;
    this.tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
    this.tabControl1.Controls.Add((Control) this.tabConexoes);
    this.tabControl1.Location = new Point(3, 121);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new Size(263, 380);
    this.tabControl1.TabIndex = 0;
    this.tabConexoes.Controls.Add((Control) this.panel1);
    this.tabConexoes.Location = new Point(4, 22);
    this.tabConexoes.Name = "tabConexoes";
    this.tabConexoes.Padding = new Padding(3);
    this.tabConexoes.Size = new Size((int) byte.MaxValue, 354);
    this.tabConexoes.TabIndex = 0;
    this.tabConexoes.Text = "Conexões";
    this.tabConexoes.UseVisualStyleBackColor = true;
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.AutoScroll = true;
    this.panel1.Controls.Add((Control) this.trvConexoes);
    this.panel1.Location = new Point(0, 0);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size((int) byte.MaxValue, 354);
    this.panel1.TabIndex = 0;
    this.trvConexoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.trvConexoes.Location = new Point(6, 4);
    this.trvConexoes.Name = "trvConexoes";
    treeNode.Name = "Node0";
    treeNode.Text = "Principal";
    this.trvConexoes.Nodes.AddRange(new TreeNode[1]
    {
      treeNode
    });
    this.trvConexoes.Size = new Size(246, 347);
    this.trvConexoes.TabIndex = 0;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1237, 503);
    this.Controls.Add((Control) this.tabControl1);
    this.Controls.Add((Control) this.tabGrids);
    this.Controls.Add((Control) this.tabCalculoRV);
    this.Name = nameof (frmCalculo);
    this.Text = "Cálculo RV";
    this.Load += new EventHandler(this.frmCalculo_Load);
    this.tabCalculoRV.ResumeLayout(false);
    this.tabGrids.ResumeLayout(false);
    this.tabControl1.ResumeLayout(false);
    this.tabConexoes.ResumeLayout(false);
    this.panel1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
