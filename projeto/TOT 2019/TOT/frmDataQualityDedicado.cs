// Decompiled with JetBrains decompiler
// Type: TOT.frmDataQualityDedicado
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmDataQualityDedicado : Form
{
  public static string baseDataQuality = DAL.PegarValorParametro("BASE_DATA_QUALITY_CONSULTA");
  public static CheckedListBox checkListBoxSelecionado;
  private IContainer components = (IContainer) null;
  private TabControl tabControl1;
  private TabPage tabDataQualityPagInicial;
  private Label label6;
  private Label label5;
  private Label label4;
  private Label label3;
  private Label label2;
  private Label label1;
  private Button btnPesquisar;
  private DataGridView dgvDataQuality;
  private CheckedListBox clbSegmento;
  private CheckedListBox clbTipo;
  private CheckedListBox clbCenario;
  private CheckedListBox clbBase;
  private CheckedListBox clbCanal;
  private CheckedListBox clbPeriodo;
  private ContextMenuStrip cmsFiltrosDataQuality;
  private ToolStripMenuItem tsmNomeFiltro;
  private ToolStripSeparator toolStripSeparator1;
  private ToolStripMenuItem tsmSelecionarTodos;
  private ToolStripMenuItem tsmLimparSelecao;
  private CheckedListBox clbResponsavel;
  private Label label7;

  public frmDataQualityDedicado() => this.InitializeComponent();

  private void frmDataQualityDedicado_Load(object sender, EventArgs e)
  {
    this.Text = "Data quality de bases";
    BLL bll = new BLL();
    this.WindowState = FormWindowState.Maximized;
    this.carregarListaFiltros();
    this.cargaDadosDataGrid();
  }

  private void carregarListaFiltros()
  {
    this.cargaDadosCheckListBox(this.clbPeriodo, $"select distinct UPPER(periodo) as periodo from {frmDataQualityDedicado.baseDataQuality} order by 1 desc");
    this.cargaDadosCheckListBox(this.clbCenario, $"select distinct UPPER(cenario) as cenario from {frmDataQualityDedicado.baseDataQuality} order by 1");
    this.cargaDadosCheckListBox(this.clbBase, $"select distinct UPPER(insumo) as insumo from {frmDataQualityDedicado.baseDataQuality} order by 1");
  }

  private void cargaDadosDataGrid(bool previa = true, string SQL = "")
  {
    DataGridView dgvDataQuality = this.dgvDataQuality;
    string str1 = $"SELECT * FROM {frmDataQualityDedicado.baseDataQuality} WHERE ROWNUM < 100";
    string str2 = $"SELECT * FROM {frmDataQualityDedicado.baseDataQuality} WHERE 1=1 {SQL}";
    string consulta = previa ? str1 : str2;
    dgvDataQuality.DataSource = (object) DAL.PegarDadosTOT(consulta);
  }

  private void cargaDadosCheckListBox(CheckedListBox clb, string SQL)
  {
    try
    {
      DataTable dataTable = DAL.PegarDadosTOT(SQL);
      for (int index = 0; index < dataTable.Rows.Count; ++index)
        clb.Items.Add((object) dataTable.Rows[index][0].ToString());
    }
    catch (Exception ex)
    {
    }
  }

  private void btnPesquisar_Click(object sender, EventArgs e)
  {
    string str1 = this.montarFiltros(this.clbPeriodo);
    string str2 = this.montarFiltros(this.clbCenario);
    string str3 = this.montarFiltros(this.clbBase);
    this.cargaDadosDataGrid(false, (str1.Length > 0 ? $" and periodo in ({str1})" : "") + (str2.Length > 0 ? $" and cenario in ({str2})" : "") + (str3.Length > 0 ? $" and insumo in ({str3})" : ""));
  }

  private string montarFiltros(CheckedListBox filtroSelecionado)
  {
    string str = "";
    for (int index = 0; index < filtroSelecionado.Items.Count; ++index)
    {
      if (filtroSelecionado.GetItemChecked(index))
        str = $"{str}'{filtroSelecionado.Items[index].ToString()}',";
    }
    if (str.Length > 1)
      str = str.Substring(0, str.Length - 1);
    return str;
  }

  private void clbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void clbPeriodo_ItemCheck(object sender, ItemCheckEventArgs e)
  {
  }

  private void clbPeriodo_MouseClick(object sender, MouseEventArgs e)
  {
  }

  private void pegarNomeFiltro(MouseEventArgs e)
  {
  }

  private void clbPeriodo_Click(object sender, EventArgs e)
  {
  }

  private void clbPeriodo_MouseCaptureChanged(object sender, EventArgs e)
  {
  }

  private void clbPeriodo_MouseUp(object sender, MouseEventArgs e)
  {
    if (!e.Button.Equals((object) MouseButtons.Right))
      return;
    this.tsmNomeFiltro.Text = "Período";
    this.cmsFiltrosDataQuality.Show(Cursor.Position.X, Cursor.Position.Y);
    frmDataQualityDedicado.checkListBoxSelecionado = this.clbPeriodo;
  }

  private void selecionarTodosItensCheckedListBox(CheckedListBox objeto, bool selecionarTudo = true)
  {
    for (int index = 0; index < objeto.Items.Count; ++index)
      objeto.SetItemChecked(index, selecionarTudo);
  }

  private void tsmSelecionarTodos_Click(object sender, EventArgs e)
  {
    this.selecionarTodosItensCheckedListBox(frmDataQualityDedicado.checkListBoxSelecionado);
  }

  private void tsmLimparSelecao_Click(object sender, EventArgs e)
  {
    this.selecionarTodosItensCheckedListBox(frmDataQualityDedicado.checkListBoxSelecionado, false);
  }

  private void clbBase_MouseUp(object sender, MouseEventArgs e)
  {
    if (!e.Button.Equals((object) MouseButtons.Right))
      return;
    this.tsmNomeFiltro.Text = "Base";
    this.cmsFiltrosDataQuality.Show(Cursor.Position.X, Cursor.Position.Y);
    frmDataQualityDedicado.checkListBoxSelecionado = this.clbBase;
  }

  private void clbCenario_MouseUp(object sender, MouseEventArgs e)
  {
    if (!e.Button.Equals((object) MouseButtons.Right))
      return;
    this.tsmNomeFiltro.Text = "Cenário";
    this.cmsFiltrosDataQuality.Show(Cursor.Position.X, Cursor.Position.Y);
    frmDataQualityDedicado.checkListBoxSelecionado = this.clbCenario;
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
    this.tabControl1 = new TabControl();
    this.tabDataQualityPagInicial = new TabPage();
    this.clbSegmento = new CheckedListBox();
    this.clbTipo = new CheckedListBox();
    this.clbCenario = new CheckedListBox();
    this.clbBase = new CheckedListBox();
    this.clbCanal = new CheckedListBox();
    this.clbPeriodo = new CheckedListBox();
    this.label6 = new Label();
    this.label5 = new Label();
    this.label4 = new Label();
    this.label3 = new Label();
    this.label2 = new Label();
    this.label1 = new Label();
    this.btnPesquisar = new Button();
    this.dgvDataQuality = new DataGridView();
    this.cmsFiltrosDataQuality = new ContextMenuStrip(this.components);
    this.tsmNomeFiltro = new ToolStripMenuItem();
    this.toolStripSeparator1 = new ToolStripSeparator();
    this.tsmSelecionarTodos = new ToolStripMenuItem();
    this.tsmLimparSelecao = new ToolStripMenuItem();
    this.clbResponsavel = new CheckedListBox();
    this.label7 = new Label();
    this.tabControl1.SuspendLayout();
    this.tabDataQualityPagInicial.SuspendLayout();
    ((ISupportInitialize) this.dgvDataQuality).BeginInit();
    this.cmsFiltrosDataQuality.SuspendLayout();
    this.SuspendLayout();
    this.tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.tabControl1.Controls.Add((Control) this.tabDataQualityPagInicial);
    this.tabControl1.Location = new Point(2, 3);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new Size(1248, 137);
    this.tabControl1.TabIndex = 0;
    this.tabDataQualityPagInicial.Controls.Add((Control) this.clbResponsavel);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.label7);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.clbSegmento);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.clbTipo);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.clbCenario);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.clbBase);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.clbCanal);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.clbPeriodo);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.label6);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.label5);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.label4);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.label3);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.label2);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.label1);
    this.tabDataQualityPagInicial.Controls.Add((Control) this.btnPesquisar);
    this.tabDataQualityPagInicial.Location = new Point(4, 22);
    this.tabDataQualityPagInicial.Name = "tabDataQualityPagInicial";
    this.tabDataQualityPagInicial.Padding = new Padding(3);
    this.tabDataQualityPagInicial.Size = new Size(1240, 111);
    this.tabDataQualityPagInicial.TabIndex = 0;
    this.tabDataQualityPagInicial.Text = "Página Inicial";
    this.tabDataQualityPagInicial.UseVisualStyleBackColor = true;
    this.clbSegmento.CheckOnClick = true;
    this.clbSegmento.FormattingEnabled = true;
    this.clbSegmento.HorizontalScrollbar = true;
    this.clbSegmento.Location = new Point(177, 22);
    this.clbSegmento.Name = "clbSegmento";
    this.clbSegmento.Size = new Size(90, 79);
    this.clbSegmento.TabIndex = 20;
    this.clbTipo.CheckOnClick = true;
    this.clbTipo.FormattingEnabled = true;
    this.clbTipo.HorizontalScrollbar = true;
    this.clbTipo.Location = new Point(920, 22);
    this.clbTipo.Name = "clbTipo";
    this.clbTipo.Size = new Size(120, 79);
    this.clbTipo.TabIndex = 19;
    this.clbCenario.CheckOnClick = true;
    this.clbCenario.FormattingEnabled = true;
    this.clbCenario.HorizontalScrollbar = true;
    this.clbCenario.Location = new Point(700, 22);
    this.clbCenario.Name = "clbCenario";
    this.clbCenario.Size = new Size(215, 79);
    this.clbCenario.TabIndex = 18;
    this.clbCenario.MouseUp += new MouseEventHandler(this.clbCenario_MouseUp);
    this.clbBase.CheckOnClick = true;
    this.clbBase.FormattingEnabled = true;
    this.clbBase.HorizontalScrollbar = true;
    this.clbBase.Location = new Point(445, 22);
    this.clbBase.Name = "clbBase";
    this.clbBase.Size = new Size(250, 79);
    this.clbBase.TabIndex = 17;
    this.clbBase.MouseUp += new MouseEventHandler(this.clbBase_MouseUp);
    this.clbCanal.CheckOnClick = true;
    this.clbCanal.FormattingEnabled = true;
    this.clbCanal.HorizontalScrollbar = true;
    this.clbCanal.Location = new Point(271, 22);
    this.clbCanal.Name = "clbCanal";
    this.clbCanal.Size = new Size(170, 79);
    this.clbCanal.TabIndex = 16 /*0x10*/;
    this.clbPeriodo.CheckOnClick = true;
    this.clbPeriodo.FormattingEnabled = true;
    this.clbPeriodo.HorizontalScrollbar = true;
    this.clbPeriodo.Location = new Point(86, 22);
    this.clbPeriodo.Name = "clbPeriodo";
    this.clbPeriodo.Size = new Size(87, 79);
    this.clbPeriodo.TabIndex = 14;
    this.clbPeriodo.ItemCheck += new ItemCheckEventHandler(this.clbPeriodo_ItemCheck);
    this.clbPeriodo.Click += new EventHandler(this.clbPeriodo_Click);
    this.clbPeriodo.MouseClick += new MouseEventHandler(this.clbPeriodo_MouseClick);
    this.clbPeriodo.SelectedIndexChanged += new EventHandler(this.clbPeriodo_SelectedIndexChanged);
    this.clbPeriodo.MouseCaptureChanged += new EventHandler(this.clbPeriodo_MouseCaptureChanged);
    this.clbPeriodo.MouseUp += new MouseEventHandler(this.clbPeriodo_MouseUp);
    this.label6.AutoSize = true;
    this.label6.Location = new Point(922, 6);
    this.label6.Name = "label6";
    this.label6.Size = new Size(28, 13);
    this.label6.TabIndex = 13;
    this.label6.Text = "Tipo";
    this.label5.AutoSize = true;
    this.label5.Location = new Point(700, 6);
    this.label5.Name = "label5";
    this.label5.Size = new Size(43, 13);
    this.label5.TabIndex = 12;
    this.label5.Text = "Cenário";
    this.label4.AutoSize = true;
    this.label4.Location = new Point(445, 6);
    this.label4.Name = "label4";
    this.label4.Size = new Size(31 /*0x1F*/, 13);
    this.label4.TabIndex = 11;
    this.label4.Text = "Base";
    this.label3.AutoSize = true;
    this.label3.Location = new Point(270, 6);
    this.label3.Name = "label3";
    this.label3.Size = new Size(34, 13);
    this.label3.TabIndex = 10;
    this.label3.Text = "Canal";
    this.label2.AutoSize = true;
    this.label2.Location = new Point(177, 6);
    this.label2.Name = "label2";
    this.label2.Size = new Size(55, 13);
    this.label2.TabIndex = 9;
    this.label2.Text = "Segmento";
    this.label1.AutoSize = true;
    this.label1.Location = new Point(85, 6);
    this.label1.Name = "label1";
    this.label1.Size = new Size(45, 13);
    this.label1.TabIndex = 8;
    this.label1.Text = "Período";
    this.btnPesquisar.Location = new Point(8, 22);
    this.btnPesquisar.Name = "btnPesquisar";
    this.btnPesquisar.Size = new Size(65, 48 /*0x30*/);
    this.btnPesquisar.TabIndex = 0;
    this.btnPesquisar.Text = "Pesquisar";
    this.btnPesquisar.UseVisualStyleBackColor = true;
    this.btnPesquisar.Click += new EventHandler(this.btnPesquisar_Click);
    this.dgvDataQuality.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.dgvDataQuality.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvDataQuality.Location = new Point(2, 144 /*0x90*/);
    this.dgvDataQuality.Name = "dgvDataQuality";
    this.dgvDataQuality.Size = new Size(1244, 334);
    this.dgvDataQuality.TabIndex = 1;
    this.cmsFiltrosDataQuality.Items.AddRange(new ToolStripItem[4]
    {
      (ToolStripItem) this.tsmNomeFiltro,
      (ToolStripItem) this.toolStripSeparator1,
      (ToolStripItem) this.tsmSelecionarTodos,
      (ToolStripItem) this.tsmLimparSelecao
    });
    this.cmsFiltrosDataQuality.Name = "cmsFiltrosDataQuality";
    this.cmsFiltrosDataQuality.Size = new Size(162, 76);
    this.tsmNomeFiltro.Enabled = false;
    this.tsmNomeFiltro.Name = "tsmNomeFiltro";
    this.tsmNomeFiltro.Size = new Size(161, 22);
    this.tsmNomeFiltro.Text = "filtro";
    this.toolStripSeparator1.Name = "toolStripSeparator1";
    this.toolStripSeparator1.Size = new Size(158, 6);
    this.tsmSelecionarTodos.Name = "tsmSelecionarTodos";
    this.tsmSelecionarTodos.Size = new Size(161, 22);
    this.tsmSelecionarTodos.Text = "Selecionar todos";
    this.tsmSelecionarTodos.Click += new EventHandler(this.tsmSelecionarTodos_Click);
    this.tsmLimparSelecao.Name = "tsmLimparSelecao";
    this.tsmLimparSelecao.Size = new Size(161, 22);
    this.tsmLimparSelecao.Text = "Limpar seleção";
    this.tsmLimparSelecao.Click += new EventHandler(this.tsmLimparSelecao_Click);
    this.clbResponsavel.CheckOnClick = true;
    this.clbResponsavel.FormattingEnabled = true;
    this.clbResponsavel.HorizontalScrollbar = true;
    this.clbResponsavel.Location = new Point(1045, 22);
    this.clbResponsavel.Name = "clbResponsavel";
    this.clbResponsavel.Size = new Size(186, 79);
    this.clbResponsavel.TabIndex = 22;
    this.label7.AutoSize = true;
    this.label7.Location = new Point(1045, 6);
    this.label7.Name = "label7";
    this.label7.Size = new Size(69, 13);
    this.label7.TabIndex = 21;
    this.label7.Text = "Responsável";
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1251, 483);
    this.Controls.Add((Control) this.dgvDataQuality);
    this.Controls.Add((Control) this.tabControl1);
    this.Name = nameof (frmDataQualityDedicado);
    this.Text = nameof (frmDataQualityDedicado);
    this.Load += new EventHandler(this.frmDataQualityDedicado_Load);
    this.tabControl1.ResumeLayout(false);
    this.tabDataQualityPagInicial.ResumeLayout(false);
    this.tabDataQualityPagInicial.PerformLayout();
    ((ISupportInitialize) this.dgvDataQuality).EndInit();
    this.cmsFiltrosDataQuality.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
