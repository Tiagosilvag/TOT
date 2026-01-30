// Decompiled with JetBrains decompiler
// Type: TOT.frmETL
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmETL : Form
{
  private IContainer components = (IContainer) null;
  private TabControl tabETL;
  private TabPage tabExtracao;
  private TabPage tabTransformacao;
  private TabPage tabCarga;
  private TabControl tabTransfFilho;
  private TabPage tabTransfManual;
  private Panel pnlETLTransfManual;
  private DataGridView dgvETLTransfManual;
  private TabControl tabETLManualTranfTabelas;
  private TabPage tabPage1;
  private TreeView tvwETLTransfManual;
  private Button btnRemoverCampoAlterar;
  private Button btnAdicionaCampoAlterar;
  private GroupBox groupBox2;
  private DataGridView dgvCamposAlterar;
  private GroupBox groupBox1;
  private DataGridView dgvFiltros;
  private Button btnSalvar;
  private ImageList imgETL32x32;

  public frmETL() => this.InitializeComponent();

  private void frmETL_Load(object sender, EventArgs e)
  {
    this.Text = "ETL";
    this.tabETL.SelectedIndex = 1;
    BLL bll = new BLL();
    bll.EstiloDataGrid(this.dgvETLTransfManual);
    bll.EstiloDataGrid(this.dgvFiltros);
    bll.EstiloDataGrid(this.dgvCamposAlterar);
    bll.EstiloTreeView(this.tvwETLTransfManual);
    bll.EstiloTabControl(this.tabETLManualTranfTabelas);
    this.dgvCamposAlterar.ColumnCount = 2;
    this.dgvCamposAlterar.Columns[0].Name = "CAMPO";
    this.dgvCamposAlterar.Columns[1].Name = "NOVO VALOR";
    this.dgvCamposAlterar.ReadOnly = false;
    this.dgvCamposAlterar.Columns[0].ReadOnly = true;
    this.dgvCamposAlterar.Columns[1].DefaultCellStyle.BackColor = BLL.CorAmareloClaro;
    this.PopularTvw();
  }

  private void PopularTvw()
  {
    try
    {
      BLL.popularTreeview(this.tvwETLTransfManual, "SELECT ID_VALIDA_RESULT_GRUPO,NM_GRUPO,DS_GRUPO FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT_GRUPO ORDER BY ID_VALIDA_RESULT_GRUPO ASC ", "NM_GRUPO", campoToolTipText: "DS_GRUPO", campoText: "NM_GRUPO");
      BLL.popularTreeview(this.tvwETLTransfManual, "SELECT A.ID_VALIDA_RESULT ID_VALIDA_RESULT ,A.NM_TABELA NM_TABELA ,A.NM_APELIDO NM_APELIDO ,A.DS_OBS DS_OBS ,A.ID_VALIDA_RESULT_GRUPO ID_VALIDA_RESULT_GRUPO ,B.NM_GRUPO NM_GRUPO ,B.DS_GRUPO DS_GRUPO FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT A, GVDW_OWNER.RV_B2B_VALIDA_RESULT_GRUPO B WHERE A.ID_VALIDA_RESULT_GRUPO = B.ID_VALIDA_RESULT_GRUPO  AND A.FL_EDITAR = 1 ORDER BY B.NM_GRUPO, A.NM_APELIDO ", "NM_TABELA", "NM_GRUPO", "DS_OBS", "NM_GRUPO", "NM_APELIDO", true);
    }
    catch (Exception ex)
    {
      BLL.erro("", ex.Message);
    }
  }

  private void tvwETLTransfManual_DoubleClick(object sender, EventArgs e)
  {
    this.dgvFiltros.DataSource = (object) BLL.popularGridFiltros(this.tvwETLTransfManual.SelectedNode.Name, this.tvwETLTransfManual.SelectedNode.Parent.Text.ToString().ToLower());
  }

  private void btnAdicionaCampoAlterar_Click(object sender, EventArgs e)
  {
    string str = this.dgvFiltros.Rows[this.dgvFiltros.CurrentRow.Index].Cells[0].Value.ToString();
    if (!this.dgvFiltros.SelectedCells.Count.Equals(1))
      return;
    if (this.dgvCamposAlterar.Rows.Count > 0)
    {
      for (int index = 0; index < this.dgvCamposAlterar.Rows.Count; ++index)
      {
        if (this.dgvCamposAlterar.Rows[index].Cells[0].Value.ToString().Equals(str, StringComparison.OrdinalIgnoreCase))
        {
          BLL.erro("Este campo já foi adicionado");
          return;
        }
      }
    }
    this.dgvCamposAlterar.Rows.Add(new object[1]
    {
      (object) str
    });
  }

  private void btnRemoverCampoAlterar_Click(object sender, EventArgs e)
  {
    if (!this.dgvCamposAlterar.SelectedCells.Count.Equals(1))
      return;
    this.dgvCamposAlterar.Rows.RemoveAt(this.dgvCamposAlterar.CurrentRow.Index);
  }

  private void btnSalvar_Click(object sender, EventArgs e)
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
    this.components = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmETL));
    this.tabETL = new TabControl();
    this.tabExtracao = new TabPage();
    this.tabTransformacao = new TabPage();
    this.tabTransfFilho = new TabControl();
    this.tabTransfManual = new TabPage();
    this.tabETLManualTranfTabelas = new TabControl();
    this.tabPage1 = new TabPage();
    this.tvwETLTransfManual = new TreeView();
    this.dgvETLTransfManual = new DataGridView();
    this.pnlETLTransfManual = new Panel();
    this.btnSalvar = new Button();
    this.imgETL32x32 = new ImageList(this.components);
    this.btnRemoverCampoAlterar = new Button();
    this.btnAdicionaCampoAlterar = new Button();
    this.groupBox2 = new GroupBox();
    this.dgvCamposAlterar = new DataGridView();
    this.groupBox1 = new GroupBox();
    this.dgvFiltros = new DataGridView();
    this.tabCarga = new TabPage();
    this.tabETL.SuspendLayout();
    this.tabTransformacao.SuspendLayout();
    this.tabTransfFilho.SuspendLayout();
    this.tabTransfManual.SuspendLayout();
    this.tabETLManualTranfTabelas.SuspendLayout();
    this.tabPage1.SuspendLayout();
    ((ISupportInitialize) this.dgvETLTransfManual).BeginInit();
    this.pnlETLTransfManual.SuspendLayout();
    this.groupBox2.SuspendLayout();
    ((ISupportInitialize) this.dgvCamposAlterar).BeginInit();
    this.groupBox1.SuspendLayout();
    ((ISupportInitialize) this.dgvFiltros).BeginInit();
    this.SuspendLayout();
    this.tabETL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabETL.Controls.Add((Control) this.tabExtracao);
    this.tabETL.Controls.Add((Control) this.tabTransformacao);
    this.tabETL.Controls.Add((Control) this.tabCarga);
    this.tabETL.Location = new Point(0, 3);
    this.tabETL.Name = "tabETL";
    this.tabETL.SelectedIndex = 0;
    this.tabETL.Size = new Size(1267, 509);
    this.tabETL.TabIndex = 0;
    this.tabExtracao.CausesValidation = false;
    this.tabExtracao.Location = new Point(4, 22);
    this.tabExtracao.Name = "tabExtracao";
    this.tabExtracao.Padding = new Padding(3);
    this.tabExtracao.Size = new Size(1259, 483);
    this.tabExtracao.TabIndex = 0;
    this.tabExtracao.Text = "Extração";
    this.tabExtracao.UseVisualStyleBackColor = true;
    this.tabTransformacao.Controls.Add((Control) this.tabTransfFilho);
    this.tabTransformacao.Location = new Point(4, 22);
    this.tabTransformacao.Name = "tabTransformacao";
    this.tabTransformacao.Padding = new Padding(3);
    this.tabTransformacao.Size = new Size(1259, 483);
    this.tabTransformacao.TabIndex = 1;
    this.tabTransformacao.Text = "Transformação";
    this.tabTransformacao.UseVisualStyleBackColor = true;
    this.tabTransfFilho.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabTransfFilho.Controls.Add((Control) this.tabTransfManual);
    this.tabTransfFilho.Location = new Point(-4, 0);
    this.tabTransfFilho.Name = "tabTransfFilho";
    this.tabTransfFilho.SelectedIndex = 0;
    this.tabTransfFilho.Size = new Size(1267, 487);
    this.tabTransfFilho.TabIndex = 0;
    this.tabTransfManual.Controls.Add((Control) this.tabETLManualTranfTabelas);
    this.tabTransfManual.Controls.Add((Control) this.dgvETLTransfManual);
    this.tabTransfManual.Controls.Add((Control) this.pnlETLTransfManual);
    this.tabTransfManual.Location = new Point(4, 22);
    this.tabTransfManual.Name = "tabTransfManual";
    this.tabTransfManual.Padding = new Padding(3);
    this.tabTransfManual.Size = new Size(1259, 461);
    this.tabTransfManual.TabIndex = 1;
    this.tabTransfManual.Text = "Ajustes Manuais";
    this.tabTransfManual.UseVisualStyleBackColor = true;
    this.tabETLManualTranfTabelas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
    this.tabETLManualTranfTabelas.Controls.Add((Control) this.tabPage1);
    this.tabETLManualTranfTabelas.Location = new Point(0, 256 /*0x0100*/);
    this.tabETLManualTranfTabelas.Name = "tabETLManualTranfTabelas";
    this.tabETLManualTranfTabelas.SelectedIndex = 0;
    this.tabETLManualTranfTabelas.Size = new Size(220, 209);
    this.tabETLManualTranfTabelas.TabIndex = 3;
    this.tabPage1.Controls.Add((Control) this.tvwETLTransfManual);
    this.tabPage1.Location = new Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new Padding(3);
    this.tabPage1.Size = new Size(212, 183);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "Tabelas";
    this.tabPage1.UseVisualStyleBackColor = true;
    this.tvwETLTransfManual.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
    this.tvwETLTransfManual.Location = new Point(0, 0);
    this.tvwETLTransfManual.Name = "tvwETLTransfManual";
    this.tvwETLTransfManual.Size = new Size(212, 180);
    this.tvwETLTransfManual.TabIndex = 1;
    this.tvwETLTransfManual.DoubleClick += new EventHandler(this.tvwETLTransfManual_DoubleClick);
    this.dgvETLTransfManual.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.dgvETLTransfManual.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvETLTransfManual.Location = new Point(222, 256 /*0x0100*/);
    this.dgvETLTransfManual.Name = "dgvETLTransfManual";
    this.dgvETLTransfManual.Size = new Size(1034, 202);
    this.dgvETLTransfManual.TabIndex = 2;
    this.pnlETLTransfManual.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.pnlETLTransfManual.BackColor = Color.WhiteSmoke;
    this.pnlETLTransfManual.Controls.Add((Control) this.btnSalvar);
    this.pnlETLTransfManual.Controls.Add((Control) this.btnRemoverCampoAlterar);
    this.pnlETLTransfManual.Controls.Add((Control) this.btnAdicionaCampoAlterar);
    this.pnlETLTransfManual.Controls.Add((Control) this.groupBox2);
    this.pnlETLTransfManual.Controls.Add((Control) this.groupBox1);
    this.pnlETLTransfManual.Location = new Point(0, 0);
    this.pnlETLTransfManual.Name = "pnlETLTransfManual";
    this.pnlETLTransfManual.Size = new Size(1256, 250);
    this.pnlETLTransfManual.TabIndex = 0;
    this.btnSalvar.BackColor = Color.White;
    this.btnSalvar.ImageAlign = ContentAlignment.TopCenter;
    this.btnSalvar.ImageKey = "iconfinder_save_60025 (1).png";
    this.btnSalvar.ImageList = this.imgETL32x32;
    this.btnSalvar.Location = new Point(4, 7);
    this.btnSalvar.Name = "btnSalvar";
    this.btnSalvar.Size = new Size(75, 64 /*0x40*/);
    this.btnSalvar.TabIndex = 9;
    this.btnSalvar.Text = "Salvar";
    this.btnSalvar.TextAlign = ContentAlignment.BottomCenter;
    this.btnSalvar.UseVisualStyleBackColor = false;
    this.btnSalvar.Click += new EventHandler(this.btnSalvar_Click);
    this.imgETL32x32.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgETL32x32.ImageStream");
    this.imgETL32x32.TransparentColor = Color.Transparent;
    this.imgETL32x32.Images.SetKeyName(0, "iconfinder_play_59990.png");
    this.imgETL32x32.Images.SetKeyName(1, "iconfinder_79-excel_4202106.png");
    this.imgETL32x32.Images.SetKeyName(2, "iconfinder_save_60025 (1).png");
    this.btnRemoverCampoAlterar.Location = new Point(538, 134);
    this.btnRemoverCampoAlterar.Name = "btnRemoverCampoAlterar";
    this.btnRemoverCampoAlterar.Size = new Size(27, 23);
    this.btnRemoverCampoAlterar.TabIndex = 3;
    this.btnRemoverCampoAlterar.Text = "<";
    this.btnRemoverCampoAlterar.UseVisualStyleBackColor = true;
    this.btnRemoverCampoAlterar.Click += new EventHandler(this.btnRemoverCampoAlterar_Click);
    this.btnAdicionaCampoAlterar.Location = new Point(538, 105);
    this.btnAdicionaCampoAlterar.Name = "btnAdicionaCampoAlterar";
    this.btnAdicionaCampoAlterar.Size = new Size(27, 23);
    this.btnAdicionaCampoAlterar.TabIndex = 2;
    this.btnAdicionaCampoAlterar.Text = ">";
    this.btnAdicionaCampoAlterar.UseVisualStyleBackColor = true;
    this.btnAdicionaCampoAlterar.Click += new EventHandler(this.btnAdicionaCampoAlterar_Click);
    this.groupBox2.Controls.Add((Control) this.dgvCamposAlterar);
    this.groupBox2.Location = new Point(576, 7);
    this.groupBox2.Name = "groupBox2";
    this.groupBox2.Size = new Size(310, 240 /*0xF0*/);
    this.groupBox2.TabIndex = 1;
    this.groupBox2.TabStop = false;
    this.groupBox2.Text = "Campos que serão alterados";
    this.dgvCamposAlterar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvCamposAlterar.Location = new Point(6, 19);
    this.dgvCamposAlterar.Name = "dgvCamposAlterar";
    this.dgvCamposAlterar.Size = new Size(298, 215);
    this.dgvCamposAlterar.TabIndex = 1;
    this.groupBox1.Controls.Add((Control) this.dgvFiltros);
    this.groupBox1.Location = new Point(216, 7);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(310, 240 /*0xF0*/);
    this.groupBox1.TabIndex = 0;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Filtros";
    this.dgvFiltros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvFiltros.Location = new Point(6, 19);
    this.dgvFiltros.Name = "dgvFiltros";
    this.dgvFiltros.Size = new Size(298, 215);
    this.dgvFiltros.TabIndex = 0;
    this.tabCarga.CausesValidation = false;
    this.tabCarga.Location = new Point(4, 22);
    this.tabCarga.Name = "tabCarga";
    this.tabCarga.Size = new Size(1259, 483);
    this.tabCarga.TabIndex = 2;
    this.tabCarga.Text = "Carga";
    this.tabCarga.UseVisualStyleBackColor = true;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1267, 506);
    this.Controls.Add((Control) this.tabETL);
    this.Name = nameof (frmETL);
    this.Text = nameof (frmETL);
    this.Load += new EventHandler(this.frmETL_Load);
    this.tabETL.ResumeLayout(false);
    this.tabTransformacao.ResumeLayout(false);
    this.tabTransfFilho.ResumeLayout(false);
    this.tabTransfManual.ResumeLayout(false);
    this.tabETLManualTranfTabelas.ResumeLayout(false);
    this.tabPage1.ResumeLayout(false);
    ((ISupportInitialize) this.dgvETLTransfManual).EndInit();
    this.pnlETLTransfManual.ResumeLayout(false);
    this.groupBox2.ResumeLayout(false);
    ((ISupportInitialize) this.dgvCamposAlterar).EndInit();
    this.groupBox1.ResumeLayout(false);
    ((ISupportInitialize) this.dgvFiltros).EndInit();
    this.ResumeLayout(false);
  }
}
