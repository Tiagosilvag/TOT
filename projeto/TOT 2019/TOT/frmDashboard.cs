// Decompiled with JetBrains decompiler
// Type: TOT.frmDashboard
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmDashboard : Form
{
  private IContainer components = (IContainer) null;
  private TabControl tabVariacoes;
  private TabPage tabMetaXRealizado;
  private Panel panMetaXRealizado;
  private Button btnPesquisarMetaXRealizado;
  private GroupBox groupBox1;
  private DataGridView dgvVolumetria;
  private TabPage tabVolumetria;
  private GroupBox groupBox2;
  private DataGridView dgvVolumetriaInsumos;

  public frmDashboard() => this.InitializeComponent();

  private void frmDashboard_Load(object sender, EventArgs e)
  {
    this.carregarDataGrid();
    this.carregarDataGridVolumetria();
    this.dgvVolumetria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    this.dgvVolumetria.RowHeadersVisible = false;
    this.dgvVolumetria.ReadOnly = true;
    this.dgvVolumetria.AllowUserToAddRows = false;
    this.dgvVolumetria.ColumnHeadersDefaultCellStyle.Font = new Font(Control.DefaultFont, FontStyle.Bold);
  }

  private void carregarDataGrid()
  {
    string consulta1 = "select DISTINCT PERIODO     from GVDW_OWNER.VW_RV_B2B_DATAQUALITY2      where periodo BETWEEN '01/09/2021' and '01/03/2022' order by 1 desc";
    string str = "";
    DataTable dataTable = DAL.PegarDadosTOT(consulta1);
    for (int index = 0; index < dataTable.Rows.Count; ++index)
      str = $"{str}'{dataTable.Rows[index]["PERIODO"].ToString().Substring(0, 10)}',";
    string consulta2 = $" WITH T AS    (      select PERIODO, UPPER(CENARIO) CENARIO, VARIACAO      from GVDW_OWNER.VW_RV_B2B_DATAQUALITY2      where periodo BETWEEN '01/09/2021' and '01/03/2022'      order by periodo desc    )    SELECT *      FROM T      PIVOT (MAX(VARIACAO) FOR PERIODO in ({str.Substring(0, str.Length - 1)})) P";
    DAL.PegarDadosTOT(consulta2);
    this.dgvVolumetria.DataSource = (object) DAL.PegarDadosTOT(consulta2);
    foreach (DataGridViewColumn column in (BaseCollection) this.dgvVolumetria.Columns)
    {
      column.HeaderText = column.HeaderText.ToString().Replace("'", "");
      if (column.Index > 0)
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }
  }

  private void carregarDataGridVolumetria()
  {
    string consulta1 = "select DISTINCT PERIODO     from GVDW_OWNER.RV_B2B_CRONOGRAMA_INSUMOS      where periodo BETWEEN '01/09/2021' and '01/03/2022' order by 1 desc";
    string str = "";
    DataTable dataTable = DAL.PegarDadosTOT(consulta1);
    for (int index = 0; index < dataTable.Rows.Count; ++index)
      str = $"{str}'{dataTable.Rows[index]["PERIODO"].ToString().Substring(0, 10)}',";
    string consulta2 = $"WITH T   AS   (     SELECT PERIODO, INSUMO||' ['||CANAL||']' BASES, VOLUMETRIA  FROM GVDW_OWNER.RV_B2B_CRONOGRAMA_INSUMOS WHERE PERIODO BETWEEN '01/10/2021' AND '01/03/2022'   )   SELECT * FROM T    PIVOT (max(VOLUMETRIA) for PERIODO in ({str.Substring(0, str.Length - 1)})) P";
    DAL.PegarDadosTOT(consulta2);
    this.dgvVolumetriaInsumos.DataSource = (object) DAL.PegarDadosTOT(consulta2);
    foreach (DataGridViewColumn column in (BaseCollection) this.dgvVolumetriaInsumos.Columns)
    {
      column.HeaderText = column.HeaderText.ToString().Replace("'", "");
      if (column.Index > 0)
        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }
  }

  private void gerarRelatorioHTML()
  {
    try
    {
      string str1 = "C:\\Temp\\";
      string str2 = "metaXrealizado.html";
      string newValue1 = "";
      string str3 = "";
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = DAL.PegarDadosTOT("SELECT HTML FROM GVDW_OWNER.RV_B2B_RELATORIOS_HTML WHERE NOME ='META X REALIZADO' AND VERSAO = 1");
      if (dataTable2.Columns.Contains("HTML"))
      {
        string str4 = dataTable2.Rows[0][0].ToString();
        DataTable dataTable3 = DAL.PegarDadosTOT("SELECT     PERIODO,     SEGMENTO,     INDICADOR,     META,     REALIZADO,     VARIACAO_META_REAL,     VAR_METAO_POR_PERIODO,     VAR_REALIZADO_POR_PERIODO FROM      GVDW_OWNER.VW_RV_B2B_DATAQUALITY_RESULT T1 ");
        string newValue2 = str3 + "<tr><th>PERIODO</th><th>SEGMENTO</th><th>INDICADOR</th><th>META</th><th>REALIZADO</th><th>VARIACAO_META_REAL</th><th>VAR_METAO_POR_PERIODO</th><th>VAR_REALIZADO_POR_PERIODO</th>";
        foreach (DataRow row in (InternalDataCollectionBase) dataTable3.Rows)
          newValue1 = $"{newValue1}<tr><td>{row["PERIODO"]?.ToString()}</td><td>{row["SEGMENTO"]?.ToString()}</td><td>{row["INDICADOR"]?.ToString()}</td><td>{row["META"]?.ToString()}</td><td>{row["REALIZADO"]?.ToString()}</td><td>{row["VARIACAO_META_REAL"]?.ToString()}</td><td>{row["VAR_METAO_POR_PERIODO"]?.ToString()}</td><td>{row["VAR_REALIZADO_POR_PERIODO"]?.ToString()}</td>";
        string contents = str4.Replace("__LINHAS1__", newValue1).Replace("__CABECALIO1__", newValue2);
        File.WriteAllText(str1 + str2, contents);
        Process.Start(str1 + str2);
      }
      else
        BLL.erro("Nenhum registro encontrado");
    }
    catch (Exception ex)
    {
      BLL.erro(ex.Message);
    }
  }

  private void btnPesquisarMetaXRealizado_Click(object sender, EventArgs e)
  {
    this.carregarDataGrid();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.tabVariacoes = new TabControl();
    this.tabMetaXRealizado = new TabPage();
    this.panMetaXRealizado = new Panel();
    this.groupBox1 = new GroupBox();
    this.dgvVolumetria = new DataGridView();
    this.btnPesquisarMetaXRealizado = new Button();
    this.tabVolumetria = new TabPage();
    this.groupBox2 = new GroupBox();
    this.dgvVolumetriaInsumos = new DataGridView();
    this.tabVariacoes.SuspendLayout();
    this.tabMetaXRealizado.SuspendLayout();
    this.panMetaXRealizado.SuspendLayout();
    this.groupBox1.SuspendLayout();
    ((ISupportInitialize) this.dgvVolumetria).BeginInit();
    this.tabVolumetria.SuspendLayout();
    this.groupBox2.SuspendLayout();
    ((ISupportInitialize) this.dgvVolumetriaInsumos).BeginInit();
    this.SuspendLayout();
    this.tabVariacoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabVariacoes.Controls.Add((Control) this.tabMetaXRealizado);
    this.tabVariacoes.Controls.Add((Control) this.tabVolumetria);
    this.tabVariacoes.Location = new Point(3, 3);
    this.tabVariacoes.Name = "tabVariacoes";
    this.tabVariacoes.SelectedIndex = 0;
    this.tabVariacoes.Size = new Size(1240, 480);
    this.tabVariacoes.TabIndex = 0;
    this.tabMetaXRealizado.Controls.Add((Control) this.panMetaXRealizado);
    this.tabMetaXRealizado.Location = new Point(4, 22);
    this.tabMetaXRealizado.Name = "tabMetaXRealizado";
    this.tabMetaXRealizado.Padding = new Padding(3);
    this.tabMetaXRealizado.Size = new Size(1232, 454);
    this.tabMetaXRealizado.TabIndex = 0;
    this.tabMetaXRealizado.Text = "Cenários Data Quality";
    this.tabMetaXRealizado.UseVisualStyleBackColor = true;
    this.panMetaXRealizado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panMetaXRealizado.AutoScroll = true;
    this.panMetaXRealizado.Controls.Add((Control) this.groupBox1);
    this.panMetaXRealizado.Controls.Add((Control) this.btnPesquisarMetaXRealizado);
    this.panMetaXRealizado.Location = new Point(0, 0);
    this.panMetaXRealizado.Name = "panMetaXRealizado";
    this.panMetaXRealizado.Size = new Size(1232, 454);
    this.panMetaXRealizado.TabIndex = 0;
    this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.groupBox1.Controls.Add((Control) this.dgvVolumetria);
    this.groupBox1.Location = new Point(7, 7);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(1219, 215);
    this.groupBox1.TabIndex = 10;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "groupBox1";
    this.dgvVolumetria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.dgvVolumetria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvVolumetria.Location = new Point(7, 20);
    this.dgvVolumetria.Name = "dgvVolumetria";
    this.dgvVolumetria.Size = new Size(1206, 189);
    this.dgvVolumetria.TabIndex = 0;
    this.btnPesquisarMetaXRealizado.BackColor = Color.White;
    this.btnPesquisarMetaXRealizado.ImageAlign = ContentAlignment.TopCenter;
    this.btnPesquisarMetaXRealizado.ImageKey = "iconfinder_play_59990.png";
    this.btnPesquisarMetaXRealizado.Location = new Point(964, 350);
    this.btnPesquisarMetaXRealizado.Name = "btnPesquisarMetaXRealizado";
    this.btnPesquisarMetaXRealizado.Size = new Size(75, 64 /*0x40*/);
    this.btnPesquisarMetaXRealizado.TabIndex = 9;
    this.btnPesquisarMetaXRealizado.Text = "(F5) Pesquisar";
    this.btnPesquisarMetaXRealizado.TextAlign = ContentAlignment.BottomCenter;
    this.btnPesquisarMetaXRealizado.UseVisualStyleBackColor = false;
    this.btnPesquisarMetaXRealizado.Click += new EventHandler(this.btnPesquisarMetaXRealizado_Click);
    this.tabVolumetria.Controls.Add((Control) this.groupBox2);
    this.tabVolumetria.Location = new Point(4, 22);
    this.tabVolumetria.Name = "tabVolumetria";
    this.tabVolumetria.Padding = new Padding(3);
    this.tabVolumetria.Size = new Size(1232, 454);
    this.tabVolumetria.TabIndex = 1;
    this.tabVolumetria.Text = "Volumetria Insumos";
    this.tabVolumetria.UseVisualStyleBackColor = true;
    this.groupBox2.Controls.Add((Control) this.dgvVolumetriaInsumos);
    this.groupBox2.Location = new Point(6, 6);
    this.groupBox2.Name = "groupBox2";
    this.groupBox2.Size = new Size(1220, 442);
    this.groupBox2.TabIndex = 0;
    this.groupBox2.TabStop = false;
    this.dgvVolumetriaInsumos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvVolumetriaInsumos.Location = new Point(5, 12);
    this.dgvVolumetriaInsumos.Name = "dgvVolumetriaInsumos";
    this.dgvVolumetriaInsumos.Size = new Size(1211, 249);
    this.dgvVolumetriaInsumos.TabIndex = 0;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1241, 482);
    this.Controls.Add((Control) this.tabVariacoes);
    this.Name = nameof (frmDashboard);
    this.Text = "frmDashboards";
    this.Load += new EventHandler(this.frmDashboard_Load);
    this.tabVariacoes.ResumeLayout(false);
    this.tabMetaXRealizado.ResumeLayout(false);
    this.panMetaXRealizado.ResumeLayout(false);
    this.groupBox1.ResumeLayout(false);
    ((ISupportInitialize) this.dgvVolumetria).EndInit();
    this.tabVolumetria.ResumeLayout(false);
    this.groupBox2.ResumeLayout(false);
    ((ISupportInitialize) this.dgvVolumetriaInsumos).EndInit();
    this.ResumeLayout(false);
  }
}
