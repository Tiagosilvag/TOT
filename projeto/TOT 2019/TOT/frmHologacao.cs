// Decompiled with JetBrains decompiler
// Type: TOT.frmHologacao
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmHologacao : Form
{
  private IContainer components = (IContainer) null;
  private Panel panel1;
  private Panel panel2;
  private WebBrowser webBrowserHomolog;
  private LinkLabel linkLabel2;
  private Label label2;
  private LinkLabel linkLabel1;
  private Label label1;
  private Panel panel3;
  private Button btnBrowerAtualizar;
  private Button btnBrowserAvancar;
  private Button btnBrowserVoltar;
  private TextBox txtBrowserHomologURL;
  private ImageList imgValidacaoResultado16x16;

  public frmHologacao() => this.InitializeComponent();

  private void frmHologacao_Load(object sender, EventArgs e)
  {
  }

  private void webBrowserHomolog_Navigated(object sender, WebBrowserNavigatedEventArgs e)
  {
    this.txtBrowserHomologURL.Text = this.webBrowserHomolog.Url.ToString();
  }

  private void btnBrowerAtualizar_Click(object sender, EventArgs e)
  {
    this.webBrowserHomolog.Refresh();
  }

  private void btnBrowserAvancar_Click(object sender, EventArgs e)
  {
    this.webBrowserHomolog.GoForward();
  }

  private void btnBrowserVoltar_Click(object sender, EventArgs e)
  {
    this.webBrowserHomolog.GoBack();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmHologacao));
    this.panel1 = new Panel();
    this.panel2 = new Panel();
    this.webBrowserHomolog = new WebBrowser();
    this.label1 = new Label();
    this.label2 = new Label();
    this.linkLabel2 = new LinkLabel();
    this.linkLabel1 = new LinkLabel();
    this.panel3 = new Panel();
    this.btnBrowserVoltar = new Button();
    this.btnBrowserAvancar = new Button();
    this.btnBrowerAtualizar = new Button();
    this.imgValidacaoResultado16x16 = new ImageList(this.components);
    this.txtBrowserHomologURL = new TextBox();
    this.panel1.SuspendLayout();
    this.panel2.SuspendLayout();
    this.panel3.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.Controls.Add((Control) this.linkLabel2);
    this.panel1.Controls.Add((Control) this.label2);
    this.panel1.Controls.Add((Control) this.linkLabel1);
    this.panel1.Controls.Add((Control) this.label1);
    this.panel1.Location = new Point(12, 6);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(889, 90);
    this.panel1.TabIndex = 0;
    this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel2.Controls.Add((Control) this.webBrowserHomolog);
    this.panel2.Location = new Point(12, 133);
    this.panel2.Name = "panel2";
    this.panel2.Size = new Size(889, 348);
    this.panel2.TabIndex = 1;
    this.webBrowserHomolog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.webBrowserHomolog.Location = new Point(3, 3);
    this.webBrowserHomolog.MinimumSize = new Size(20, 20);
    this.webBrowserHomolog.Name = "webBrowserHomolog";
    this.webBrowserHomolog.Size = new Size(883, 342);
    this.webBrowserHomolog.TabIndex = 0;
    this.webBrowserHomolog.Navigated += new WebBrowserNavigatedEventHandler(this.webBrowserHomolog_Navigated);
    this.label1.AutoSize = true;
    this.label1.Location = new Point(28, 17);
    this.label1.Name = "label1";
    this.label1.Size = new Size(145, 13);
    this.label1.TabIndex = 2;
    this.label1.Text = "Endereço registrado no TOT:";
    this.label2.AutoSize = true;
    this.label2.Location = new Point(28, 42);
    this.label2.Name = "label2";
    this.label2.Size = new Size(135, 13);
    this.label2.TabIndex = 4;
    this.label2.Text = "Endereço padrão sugerido:";
    this.linkLabel2.AutoSize = true;
    this.linkLabel2.Location = new Point(189, 42);
    this.linkLabel2.Name = "linkLabel2";
    this.linkLabel2.Size = new Size(55, 13);
    this.linkLabel2.TabIndex = 5;
    this.linkLabel2.TabStop = true;
    this.linkLabel2.Text = "linkLabel2";
    this.linkLabel1.AutoSize = true;
    this.linkLabel1.Location = new Point(189, 17);
    this.linkLabel1.Name = "linkLabel1";
    this.linkLabel1.Size = new Size(55, 13);
    this.linkLabel1.TabIndex = 3;
    this.linkLabel1.TabStop = true;
    this.linkLabel1.Text = "linkLabel1";
    this.panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel3.Controls.Add((Control) this.txtBrowserHomologURL);
    this.panel3.Controls.Add((Control) this.btnBrowerAtualizar);
    this.panel3.Controls.Add((Control) this.btnBrowserAvancar);
    this.panel3.Controls.Add((Control) this.btnBrowserVoltar);
    this.panel3.Location = new Point(12, 98);
    this.panel3.Name = "panel3";
    this.panel3.Size = new Size(889, 32 /*0x20*/);
    this.panel3.TabIndex = 2;
    this.btnBrowserVoltar.Location = new Point(4, 4);
    this.btnBrowserVoltar.Name = "btnBrowserVoltar";
    this.btnBrowserVoltar.Size = new Size(26, 23);
    this.btnBrowserVoltar.TabIndex = 0;
    this.btnBrowserVoltar.Text = "<";
    this.btnBrowserVoltar.UseVisualStyleBackColor = true;
    this.btnBrowserVoltar.Click += new EventHandler(this.btnBrowserVoltar_Click);
    this.btnBrowserAvancar.Location = new Point(31 /*0x1F*/, 4);
    this.btnBrowserAvancar.Name = "btnBrowserAvancar";
    this.btnBrowserAvancar.Size = new Size(26, 23);
    this.btnBrowserAvancar.TabIndex = 1;
    this.btnBrowserAvancar.Text = ">";
    this.btnBrowserAvancar.UseVisualStyleBackColor = true;
    this.btnBrowserAvancar.Click += new EventHandler(this.btnBrowserAvancar_Click);
    this.btnBrowerAtualizar.ImageKey = "iconfinder_old-view-refresh_23502.png";
    this.btnBrowerAtualizar.ImageList = this.imgValidacaoResultado16x16;
    this.btnBrowerAtualizar.Location = new Point(63 /*0x3F*/, 4);
    this.btnBrowerAtualizar.Name = "btnBrowerAtualizar";
    this.btnBrowerAtualizar.Size = new Size(26, 23);
    this.btnBrowerAtualizar.TabIndex = 2;
    this.btnBrowerAtualizar.UseVisualStyleBackColor = true;
    this.btnBrowerAtualizar.Click += new EventHandler(this.btnBrowerAtualizar_Click);
    this.imgValidacaoResultado16x16.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgValidacaoResultado16x16.ImageStream");
    this.imgValidacaoResultado16x16.TransparentColor = Color.Transparent;
    this.imgValidacaoResultado16x16.Images.SetKeyName(0, "iconfinder_list-delete3_59950.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(1, "iconfinder_bullet-blue_59835.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(2, "iconfinder_bullet-yellow_59839.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(3, "iconfinder_save_60025.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(4, "iconfinder_folder_closed_59915.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(5, "iconfinder_document-information_59879.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(6, "iconfinder_logo_brand_brands_logos_excel_3215579.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(7, "iconfinder_ooo-math_493.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(8, "iconfinder_bullet-green_59836.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(9, "iconfinder_bullet-grey_59837.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(10, "iconfinder_bullet-red_59838.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(11, "iconfinder_Data-09_4203015.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(12, "iconfinder_document-information_59879.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(13, "iconfinder_old-view-refresh_23502.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(14, "iconfinder_filter_64280.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(15, "iconfinder_Copy_1493280.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(16 /*0x10*/, "iconfinder_copy_83610.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(17, "iconfinder_35_Glasses_2064510.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(18, "iconfinder_table_60051_tabela.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(19, "iconfinder_user1_60148.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(20, "iconfinder_Tools_60094.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(21, "iconfinder_search_60026.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(22, "iconfinder_play_59990_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(23, "iconfinder_icon-130-cloud-upload_314715.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(24, "Excluir_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(25, "grafico_barra_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(26, "iconfinder_bubble_chart_circle_bubble_4272259.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(27, "iconfinder_category_add_103433.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(28, "sql-query_21303.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(29, "favoritos_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(30, "nao_favoritos_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(31 /*0x1F*/, "plus_azul_16x16.png");
    this.txtBrowserHomologURL.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.txtBrowserHomologURL.Location = new Point(95, 6);
    this.txtBrowserHomologURL.Name = "txtBrowserHomologURL";
    this.txtBrowserHomologURL.Size = new Size(791, 20);
    this.txtBrowserHomologURL.TabIndex = 3;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(913, 493);
    this.Controls.Add((Control) this.panel3);
    this.Controls.Add((Control) this.panel2);
    this.Controls.Add((Control) this.panel1);
    this.Name = nameof (frmHologacao);
    this.Text = nameof (frmHologacao);
    this.Load += new EventHandler(this.frmHologacao_Load);
    this.panel1.ResumeLayout(false);
    this.panel1.PerformLayout();
    this.panel2.ResumeLayout(false);
    this.panel3.ResumeLayout(false);
    this.panel3.PerformLayout();
    this.ResumeLayout(false);
  }
}
