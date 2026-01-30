// Decompiled with JetBrains decompiler
// Type: TOT.frmCalendario
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmCalendario : Form
{
  private IContainer components = (IContainer) null;
  private TabPage tabPage1;
  private TabControl tabCalendario;
  private DataGridView dgvCalendario;
  private GroupBox grpCalendario;
  private ImageList img48px;
  private Button button1;

  public frmCalendario() => this.InitializeComponent();

  private void frmCalendario_Load(object sender, EventArgs e)
  {
    this.Text = "Calendário";
    this.carregarDadosIniciais();
  }

  private void carregarDadosIniciais()
  {
    new BLL().EstiloDataGrid(this.dgvCalendario);
    this.dgvCalendario.DataSource = (object) DAL.PegarDadosTOT("SELECT A.* FROM GVDW_OWNER.VW_RV_B2B_VALIDA_RESULT_CAL A ");
  }

  private void formatarCelular()
  {
    foreach (DataGridViewRow row in (IEnumerable) this.dgvCalendario.Rows)
      row.Cells["STATUS"].Value = (object) this.img48px.Images[2];
  }

  private void button1_Click(object sender, EventArgs e) => this.formatarCelular();

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmCalendario));
    this.tabPage1 = new TabPage();
    this.dgvCalendario = new DataGridView();
    this.grpCalendario = new GroupBox();
    this.tabCalendario = new TabControl();
    this.img48px = new ImageList(this.components);
    this.button1 = new Button();
    this.tabPage1.SuspendLayout();
    ((ISupportInitialize) this.dgvCalendario).BeginInit();
    this.grpCalendario.SuspendLayout();
    this.tabCalendario.SuspendLayout();
    this.SuspendLayout();
    this.tabPage1.Controls.Add((Control) this.dgvCalendario);
    this.tabPage1.Controls.Add((Control) this.grpCalendario);
    this.tabPage1.Location = new Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new Padding(3);
    this.tabPage1.Size = new Size(1145, 429);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "Cargas insumos";
    this.tabPage1.UseVisualStyleBackColor = true;
    this.dgvCalendario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.dgvCalendario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvCalendario.Location = new Point(3, 109);
    this.dgvCalendario.Name = "dgvCalendario";
    this.dgvCalendario.Size = new Size(1139, 317);
    this.dgvCalendario.TabIndex = 1;
    this.grpCalendario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.grpCalendario.Controls.Add((Control) this.button1);
    this.grpCalendario.Location = new Point(3, 3);
    this.grpCalendario.Name = "grpCalendario";
    this.grpCalendario.Size = new Size(1139, 100);
    this.grpCalendario.TabIndex = 0;
    this.grpCalendario.TabStop = false;
    this.grpCalendario.Text = "Pesquisar";
    this.tabCalendario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabCalendario.Controls.Add((Control) this.tabPage1);
    this.tabCalendario.Location = new Point(2, 2);
    this.tabCalendario.Name = "tabCalendario";
    this.tabCalendario.SelectedIndex = 0;
    this.tabCalendario.Size = new Size(1153, 455);
    this.tabCalendario.TabIndex = 0;
    this.img48px.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("img48px.ImageStream");
    this.img48px.TransparentColor = Color.Transparent;
    this.img48px.Images.SetKeyName(0, "bola_verde_32px.png");
    this.img48px.Images.SetKeyName(1, "bola_vermelha_32px.png");
    this.img48px.Images.SetKeyName(2, "bola_amarela_32px.png");
    this.img48px.Images.SetKeyName(3, "bola_cinza_32px.png");
    this.button1.Location = new Point(31 /*0x1F*/, 45);
    this.button1.Name = "button1";
    this.button1.Size = new Size(75, 23);
    this.button1.TabIndex = 0;
    this.button1.Text = "button1";
    this.button1.UseVisualStyleBackColor = true;
    this.button1.Click += new EventHandler(this.button1_Click);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1156, 457);
    this.Controls.Add((Control) this.tabCalendario);
    this.Name = nameof (frmCalendario);
    this.Text = nameof (frmCalendario);
    this.Load += new EventHandler(this.frmCalendario_Load);
    this.tabPage1.ResumeLayout(false);
    ((ISupportInitialize) this.dgvCalendario).EndInit();
    this.grpCalendario.ResumeLayout(false);
    this.tabCalendario.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
