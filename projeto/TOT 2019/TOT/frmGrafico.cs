// Decompiled with JetBrains decompiler
// Type: TOT.frmGrafico
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

#nullable disable
namespace TOT;

public class frmGrafico : Form
{
  private IContainer components = (IContainer) null;
  private GroupBox gbGrafico;
  private GroupBox groupBox1;
  private Button btnPesquisar;
  private CheckedListBox clbSegmento;
  private TableLayoutPanel tableLayoutPanel1;
  private Chart chtFator;
  private Chart chtAtingimento;

  public frmGrafico() => this.InitializeComponent();

  private void frmGrafico_Load(object sender, EventArgs e)
  {
    this.Text = "KPI - Assertividade";
    this.popularGrafico("select nvl(SEGMENTO, 'B2B') SEGMENTO, \"ASSERT.ATING.\"*1 as ASSERTIVIDADE from GVDW_OWNER.VW_RV_B2B_ASSERTIV_RE a WHERE a.ANOMES = 201911 order by \"ASSERT.ATING.\"*1 desc", "SEGMENTO", "ASSERTIVIDADE", this.chtAtingimento, "ASSERTIVIDADE");
    this.popularGrafico("select nvl(SEGMENTO, 'B2B') SEGMENTO, \"ASSERT.FATOR\"*1 as FATOR from GVDW_OWNER.VW_RV_B2B_ASSERTIV_RE a WHERE A.ANOMES = 201911 order by \"ASSERT.FATOR\"*1 desc", "SEGMENTO", "FATOR", this.chtFator, "FATOR");
    this.popularCombo(this.clbSegmento, "SELECT DISTINCT ANOMES from GVDW_OWNER.VW_RV_B2B_ASSERTIV_RE a order by 1 desc", "ANOMES");
  }

  private void popularGrafico(
    string sql,
    string eixoX,
    string eixoY,
    Chart grafico,
    string titulo)
  {
    DataTable source = DAL.PegarDadosTOT(sql);
    string[] array1 = source.AsEnumerable().Select<DataRow, string>((System.Func<DataRow, string>) (p => p.Field<string>(eixoX))).ToArray<string>();
    Decimal[] array2 = source.AsEnumerable().Select<DataRow, Decimal>((System.Func<DataRow, Decimal>) (p => p.Field<Decimal>(eixoY))).ToArray<Decimal>();
    grafico.Titles.Add(titulo);
    grafico.Series[0].ChartType = SeriesChartType.Column;
    grafico.Series[0].IsValueShownAsLabel = true;
    grafico.Series[0].Points.DataBindXY((IEnumerable) array1, (IEnumerable) array2);
    grafico.Legends.Clear();
    grafico.ChartAreas[0].AxisX.LabelStyle.Interval = 1.0;
    grafico.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;
    grafico.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
    grafico.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
    grafico.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
    grafico.Palette = ChartColorPalette.Excel;
    foreach (DataPoint point in (Collection<DataPoint>) grafico.Series[0].Points)
      ;
    grafico.ChartAreas[0].AxisY.LineColor = grafico.BackColor;
    grafico.Series[0].Points.FindMaxByValue("Y").Color = Color.Green;
    grafico.Series[0].Points.FindMinByValue("Y").Color = Color.Red;
    grafico.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
  }

  private void popularCombo(CheckedListBox clb, string sql, string campo)
  {
    DataTable dataTable = DAL.PegarDadosTOT(sql);
    clb.DataSource = (object) dataTable;
    clb.DisplayMember = campo;
    clb.ValueMember = campo;
  }

  private void btnPesquisar_Click(object sender, EventArgs e)
  {
    object[] objArray = (object[]) null;
    objArray = this.clbSegmento.CheckedItems.OfType<object>().ToArray<object>();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ChartArea chartArea1 = new ChartArea();
    Legend legend1 = new Legend();
    Series series1 = new Series();
    ChartArea chartArea2 = new ChartArea();
    Legend legend2 = new Legend();
    Series series2 = new Series();
    this.gbGrafico = new GroupBox();
    this.tableLayoutPanel1 = new TableLayoutPanel();
    this.chtFator = new Chart();
    this.chtAtingimento = new Chart();
    this.groupBox1 = new GroupBox();
    this.clbSegmento = new CheckedListBox();
    this.btnPesquisar = new Button();
    this.gbGrafico.SuspendLayout();
    this.tableLayoutPanel1.SuspendLayout();
    this.chtFator.BeginInit();
    this.chtAtingimento.BeginInit();
    this.groupBox1.SuspendLayout();
    this.SuspendLayout();
    this.gbGrafico.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.gbGrafico.BackColor = SystemColors.Window;
    this.gbGrafico.Controls.Add((Control) this.tableLayoutPanel1);
    this.gbGrafico.Location = new Point(3, 103);
    this.gbGrafico.Name = "gbGrafico";
    this.gbGrafico.Size = new Size(1000, 390);
    this.gbGrafico.TabIndex = 1;
    this.gbGrafico.TabStop = false;
    this.tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.tableLayoutPanel1.ColumnCount = 2;
    this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
    this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
    this.tableLayoutPanel1.Controls.Add((Control) this.chtFator, 0, 0);
    this.tableLayoutPanel1.Controls.Add((Control) this.chtAtingimento, 0, 0);
    this.tableLayoutPanel1.Location = new Point(6, 19);
    this.tableLayoutPanel1.Name = "tableLayoutPanel1";
    this.tableLayoutPanel1.RowCount = 1;
    this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
    this.tableLayoutPanel1.Size = new Size(988, 365);
    this.tableLayoutPanel1.TabIndex = 2;
    this.chtFator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    chartArea1.Name = "ChartArea1";
    this.chtFator.ChartAreas.Add(chartArea1);
    legend1.Name = "Legend1";
    this.chtFator.Legends.Add(legend1);
    this.chtFator.Location = new Point(497, 3);
    this.chtFator.Name = "chtFator";
    series1.ChartArea = "ChartArea1";
    series1.Legend = "Legend1";
    series1.Name = "Series1";
    this.chtFator.Series.Add(series1);
    this.chtFator.Size = new Size(488, 359);
    this.chtFator.TabIndex = 3;
    this.chtFator.Text = "chart1";
    this.chtAtingimento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    chartArea2.Name = "ChartArea1";
    this.chtAtingimento.ChartAreas.Add(chartArea2);
    legend2.Name = "Legend1";
    this.chtAtingimento.Legends.Add(legend2);
    this.chtAtingimento.Location = new Point(3, 3);
    this.chtAtingimento.Name = "chtAtingimento";
    series2.ChartArea = "ChartArea1";
    series2.Legend = "Legend1";
    series2.Name = "Series1";
    this.chtAtingimento.Series.Add(series2);
    this.chtAtingimento.Size = new Size(488, 359);
    this.chtAtingimento.TabIndex = 2;
    this.chtAtingimento.Text = "grafico";
    this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.groupBox1.Controls.Add((Control) this.clbSegmento);
    this.groupBox1.Controls.Add((Control) this.btnPesquisar);
    this.groupBox1.Location = new Point(3, 12);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(1000, 88);
    this.groupBox1.TabIndex = 2;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "KPI Assertividade";
    this.clbSegmento.FormattingEnabled = true;
    this.clbSegmento.Location = new Point(3, 15);
    this.clbSegmento.Name = "clbSegmento";
    this.clbSegmento.Size = new Size(195, 64 /*0x40*/);
    this.clbSegmento.TabIndex = 5;
    this.btnPesquisar.Anchor = AnchorStyles.Right;
    this.btnPesquisar.Location = new Point(900, 38);
    this.btnPesquisar.Name = "btnPesquisar";
    this.btnPesquisar.Size = new Size(90, 23);
    this.btnPesquisar.TabIndex = 4;
    this.btnPesquisar.Text = "Consultar";
    this.btnPesquisar.UseVisualStyleBackColor = true;
    this.btnPesquisar.Click += new EventHandler(this.btnPesquisar_Click);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1005, 499);
    this.Controls.Add((Control) this.groupBox1);
    this.Controls.Add((Control) this.gbGrafico);
    this.Name = nameof (frmGrafico);
    this.Text = nameof (frmGrafico);
    this.Load += new EventHandler(this.frmGrafico_Load);
    this.gbGrafico.ResumeLayout(false);
    this.tableLayoutPanel1.ResumeLayout(false);
    this.chtFator.EndInit();
    this.chtAtingimento.EndInit();
    this.groupBox1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
