// Decompiled with JetBrains decompiler
// Type: TOT.frmEstatisticas
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

#nullable disable
namespace TOT;

public class frmEstatisticas : Form
{
  private IContainer components = (IContainer) null;
  private DataGridView dgvVolumetria;
  private Button btnFechar;
  private Label lblNomeTabela;
  private Chart chaVolumetria;
  private TextBox txtMesesVolumetria;
  private Label label2;
  private GroupBox groupBox1;
  private ComboBox cmbInsumo;
  private ComboBox cmbCenario;
  private Label label1;

  public frmEstatisticas() => this.InitializeComponent();

  private void frmEstatisticas_Load(object sender, EventArgs e)
  {
    DataTable table = DAL.PegarDadosTOT("SELECT T.INSUMO INSUMO FROM GVDW_OWNER.VW_RV_B2B_DATAQUALITY3 T WHERE T.PERIODO > TO_CHAR(ADD_MONTHS(SYSDATE,-12),'YYYYMM')");
    this.Text = "Variação Insumos";
    this.dgvVolumetria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    this.dgvVolumetria.RowHeadersVisible = false;
    this.dgvVolumetria.AllowUserToAddRows = false;
    this.dgvVolumetria.ReadOnly = true;
    this.dgvVolumetria.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
    this.dgvVolumetria.AlternatingRowsDefaultCellStyle.BackColor = BLL.CorAmareloClaro;
    this.cmbInsumo.DataSource = (object) new DataView(table).ToTable(true, "INSUMO");
    this.cmbInsumo.DisplayMember = "INSUMO";
    this.chaVolumetria.Series.Add("EIXO_X");
    this.chaVolumetria.Series["EIXO_X"].XValueMember = "PERIODO";
    this.chaVolumetria.Series["EIXO_X"].YValueMembers = "REALIZADO";
    this.chaVolumetria.Series["EIXO_X"].IsValueShownAsLabel = true;
    this.chaVolumetria.Series["EIXO_X"].IsVisibleInLegend = false;
    this.chaVolumetria.Series["Series1"].IsVisibleInLegend = false;
    this.cmbInsumo.DropDownStyle = ComboBoxStyle.DropDownList;
    this.lblNomeTabela.Text = "Insumo:";
    this.atualizarVolumetria(DAL._tabelaAtualaAux, "");
  }

  private void btnFechar_Click(object sender, EventArgs e) => this.Close();

  private void atualizarVolumetria(string insumo, string cenario)
  {
    try
    {
      if (string.IsNullOrWhiteSpace(insumo))
        return;
      DataTable table = DAL.PegarDadosTOT($"SELECT T.INSUMO, T.CENARIO, REPLACE(REPLACE(T.REALIZADO,'.',''),',','.') REALIZADO, T.PERIODO, T.VARIACAO, T.FAIXA FROM GVDW_OWNER.VW_RV_B2B_DATAQUALITY3 T WHERE INSUMO = '{insumo}' AND T.PERIODO > TO_CHAR(ADD_MONTHS(SYSDATE,-12),'YYYYMM') AND CENARIO = 'VOLUMETRIA' ");
      this.dgvVolumetria.DataSource = (object) table;
      this.cmbCenario.DataSource = (object) new DataView(table).ToTable(true, "CENARIO");
      this.cmbCenario.DisplayMember = "CENARIO";
      if (this.chaVolumetria.Series.IndexOf("EIXO_X") > -1)
        this.chaVolumetria.Series.Remove(this.chaVolumetria.Series["EIXO_X"]);
      this.chaVolumetria.Series.Add("EIXO_X");
      if (this.chaVolumetria.Series.IndexOf("EIXO_X2") > -1)
        this.chaVolumetria.Series.Remove(this.chaVolumetria.Series["EIXO_X2"]);
      this.chaVolumetria.Series.Add("EIXO_X2");
      this.chaVolumetria.Series["EIXO_X2"].YAxisType = AxisType.Secondary;
      this.chaVolumetria.Series["EIXO_X"].XValueMember = "PERIODO";
      this.chaVolumetria.Series["EIXO_X"].YValueMembers = "REALIZADO";
      this.chaVolumetria.Series["EIXO_X"].IsValueShownAsLabel = true;
      this.chaVolumetria.Series["EIXO_X"].LabelBackColor = Color.White;
      this.chaVolumetria.Series["EIXO_X"].IsVisibleInLegend = false;
      this.chaVolumetria.Series["EIXO_X2"].XValueMember = "PERIODO";
      this.chaVolumetria.Series["EIXO_X2"].YValueMembers = "VARIACAO";
      this.chaVolumetria.Series["EIXO_X2"].IsValueShownAsLabel = true;
      this.chaVolumetria.Series["EIXO_X2"].LabelBackColor = Color.White;
      this.chaVolumetria.Series["EIXO_X2"].IsVisibleInLegend = false;
      this.chaVolumetria.Series["EIXO_X2"].ChartType = SeriesChartType.Line;
      this.chaVolumetria.ChartAreas[0].AxisY.LineColor = this.chaVolumetria.BackColor;
      this.chaVolumetria.ChartAreas[0].AxisY2.LineColor = this.chaVolumetria.BackColor;
      this.chaVolumetria.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
      this.chaVolumetria.ChartAreas[0].AxisY2.LabelStyle.Enabled = false;
      this.chaVolumetria.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;
      this.chaVolumetria.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8f, FontStyle.Regular);
      this.chaVolumetria.ChartAreas[0].AxisX.Interval = 1.0;
      this.chaVolumetria.DataSource = (object) table;
      this.chaVolumetria.DataBind();
      for (int index = 0; index < this.chaVolumetria.Series["EIXO_X"].Points.Count; ++index)
      {
        this.chaVolumetria.Series["EIXO_X"].Points[index].Color = Color.DarkViolet;
        this.chaVolumetria.Series["EIXO_X"].Points[index].Font = new Font(this.Font.Name, 8f, FontStyle.Bold);
        this.chaVolumetria.Series["EIXO_X2"].Points[index].Color = Color.Gold;
      }
      this.chaVolumetria.Series["EIXO_X2"].BorderWidth = 5;
      this.chaVolumetria.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
      this.chaVolumetria.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
      this.chaVolumetria.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
      this.chaVolumetria.ChartAreas[0].AxisX2.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
      this.chaVolumetria.ChartAreas[0].AxisY2.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
      this.chaVolumetria.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
      this.chaVolumetria.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
      this.chaVolumetria.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
      this.chaVolumetria.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
      this.chaVolumetria.ChartAreas[0].AxisY2.MajorTickMark.Enabled = false;
      this.chaVolumetria.ChartAreas[0].AxisX2.MinorTickMark.Enabled = false;
      int num = 0;
      while (num < this.chaVolumetria.Series["EIXO_X2"].Points.Count)
        ++num;
      if (this.chaVolumetria.Series["EIXO_X"].Points.Count > 0)
      {
        this.chaVolumetria.Series["EIXO_X"].Points.FindMaxByValue("Y").Color = Color.Purple;
        this.chaVolumetria.Series["EIXO_X"].Points.FindMinByValue("Y").Color = Color.Plum;
      }
      this.cmbInsumo.Text = insumo;
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar gerar estatísticas de insumos", ex.Message);
    }
  }

  private void cmbInsumo_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.cmbInsumo.Items[this.cmbInsumo.SelectedIndex].ToString();
    DataRowView selectedItem = this.cmbInsumo.SelectedItem as DataRowView;
    string empty = string.Empty;
    if (selectedItem != null)
      empty = selectedItem.Row["INSUMO"] as string;
    this.atualizarVolumetria(empty, "");
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ChartArea chartArea = new ChartArea();
    Legend legend = new Legend();
    Series series = new Series();
    this.dgvVolumetria = new DataGridView();
    this.btnFechar = new Button();
    this.lblNomeTabela = new Label();
    this.chaVolumetria = new Chart();
    this.txtMesesVolumetria = new TextBox();
    this.label2 = new Label();
    this.groupBox1 = new GroupBox();
    this.cmbCenario = new ComboBox();
    this.label1 = new Label();
    this.cmbInsumo = new ComboBox();
    ((ISupportInitialize) this.dgvVolumetria).BeginInit();
    this.chaVolumetria.BeginInit();
    this.groupBox1.SuspendLayout();
    this.SuspendLayout();
    this.dgvVolumetria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.dgvVolumetria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvVolumetria.Location = new Point(16 /*0x10*/, 313);
    this.dgvVolumetria.Name = "dgvVolumetria";
    this.dgvVolumetria.Size = new Size(876, 176 /*0xB0*/);
    this.dgvVolumetria.TabIndex = 0;
    this.btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnFechar.Location = new Point(1208, 514);
    this.btnFechar.Name = "btnFechar";
    this.btnFechar.Size = new Size(75, 23);
    this.btnFechar.TabIndex = 1;
    this.btnFechar.Text = "Fechar";
    this.btnFechar.UseVisualStyleBackColor = true;
    this.btnFechar.Click += new EventHandler(this.btnFechar_Click);
    this.lblNomeTabela.AutoSize = true;
    this.lblNomeTabela.Location = new Point(6, 16 /*0x10*/);
    this.lblNomeTabela.Name = "lblNomeTabela";
    this.lblNomeTabela.Size = new Size(44, 13);
    this.lblNomeTabela.TabIndex = 2;
    this.lblNomeTabela.Text = "Insumo:";
    this.chaVolumetria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    chartArea.Name = "ChartArea1";
    this.chaVolumetria.ChartAreas.Add(chartArea);
    legend.Name = "Legend1";
    this.chaVolumetria.Legends.Add(legend);
    this.chaVolumetria.Location = new Point(16 /*0x10*/, 50);
    this.chaVolumetria.Name = "chaVolumetria";
    series.ChartArea = "ChartArea1";
    series.Legend = "Legend1";
    series.Name = "Series1";
    this.chaVolumetria.Series.Add(series);
    this.chaVolumetria.Size = new Size(876, 257);
    this.chaVolumetria.TabIndex = 3;
    this.chaVolumetria.Text = "chart1";
    this.txtMesesVolumetria.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.txtMesesVolumetria.Enabled = false;
    this.txtMesesVolumetria.Location = new Point(1189, 16 /*0x10*/);
    this.txtMesesVolumetria.Name = "txtMesesVolumetria";
    this.txtMesesVolumetria.Size = new Size(38, 20);
    this.txtMesesVolumetria.TabIndex = 5;
    this.txtMesesVolumetria.Text = "12";
    this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.label2.AutoSize = true;
    this.label2.Location = new Point(1233, 18);
    this.label2.Name = "label2";
    this.label2.Size = new Size(50, 13);
    this.label2.TabIndex = 6;
    this.label2.Text = "Períodos";
    this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.groupBox1.Controls.Add((Control) this.cmbCenario);
    this.groupBox1.Controls.Add((Control) this.label1);
    this.groupBox1.Controls.Add((Control) this.cmbInsumo);
    this.groupBox1.Controls.Add((Control) this.lblNomeTabela);
    this.groupBox1.Location = new Point(16 /*0x10*/, 3);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(876, 41);
    this.groupBox1.TabIndex = 7;
    this.groupBox1.TabStop = false;
    this.cmbCenario.FormattingEnabled = true;
    this.cmbCenario.Location = new Point(351, 13);
    this.cmbCenario.Name = "cmbCenario";
    this.cmbCenario.Size = new Size(218, 21);
    this.cmbCenario.TabIndex = 5;
    this.cmbCenario.Visible = false;
    this.label1.AutoSize = true;
    this.label1.Location = new Point(301, 16 /*0x10*/);
    this.label1.Name = "label1";
    this.label1.Size = new Size(46, 13);
    this.label1.TabIndex = 4;
    this.label1.Text = "Cenário:";
    this.label1.Visible = false;
    this.cmbInsumo.FormattingEnabled = true;
    this.cmbInsumo.Location = new Point(69, 13);
    this.cmbInsumo.Name = "cmbInsumo";
    this.cmbInsumo.Size = new Size(218, 21);
    this.cmbInsumo.TabIndex = 3;
    this.cmbInsumo.SelectionChangeCommitted += new EventHandler(this.cmbInsumo_SelectionChangeCommitted);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(904, 501);
    this.Controls.Add((Control) this.groupBox1);
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.txtMesesVolumetria);
    this.Controls.Add((Control) this.chaVolumetria);
    this.Controls.Add((Control) this.btnFechar);
    this.Controls.Add((Control) this.dgvVolumetria);
    this.Name = nameof (frmEstatisticas);
    this.Text = nameof (frmEstatisticas);
    this.Load += new EventHandler(this.frmEstatisticas_Load);
    ((ISupportInitialize) this.dgvVolumetria).EndInit();
    this.chaVolumetria.EndInit();
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
