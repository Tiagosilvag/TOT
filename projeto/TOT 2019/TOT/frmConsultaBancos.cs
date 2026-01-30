// Decompiled with JetBrains decompiler
// Type: TOT.frmConsultaBancos
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TOT.Properties;

#nullable disable
namespace TOT;

public class frmConsultaBancos : Form
{
  public static string sqlFiltroCalculo = " AND ID_ORDEM <> 15 ";
  private DateTimePicker oDateTimePicker = new DateTimePicker();
  private Microsoft.Office.Interop.Excel.Application App;
  private Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range) null;
  private IContainer components = (IContainer) null;
  private TabControl tabValidacaoResultados;
  private DataGridView dgvValidacaoResultado;
  private ImageList imgValidacaoResultado16x16;
  private ImageList imgValidacaoResultado24x24;
  private ImageList imgValidacaoResultado48x48;
  private ImageList imgValidacaoResultado32x32;
  private ToolTip tipVRDiversos;
  private ToolStripMenuItem igualToolStripMenuItem;
  private ToolStripMenuItem diferenteToolStripMenuItem;
  private ToolStripMenuItem contémlikeToolStripMenuItem;
  private ToolStripMenuItem nãoContémNotLikeToolStripMenuItem;
  private ToolStripMenuItem maiorToolStripMenuItem;
  private ToolStripMenuItem maiorOuIgualToolStripMenuItem;
  private ContextMenuStrip cmsFiltrosValidacaoResultado;
  private ContextMenuStrip cmsValidacaoResultado;
  private ToolStripMenuItem cmsItemCopiar;
  private ToolStripMenuItem cmsItemSelecionarTudo;
  private ToolStripMenuItem cmsCopiarComCabecalho;
  private ContextMenuStrip cmsPropriedadesTabelas;
  private ToolStripMenuItem cmsPropriedades;
  private ToolStripMenuItem cmsCopiarNomeTabela;
  private ToolStripSeparator toolStripSeparator1;
  private ToolStripSeparator toolStripSeparator2;
  private ToolStripMenuItem cmsLimparOperador;
  private ToolStripSeparator toolStripSeparator4;
  private ToolStripMenuItem cmsExportarResultado;
  private ToolStripMenuItem separadoPorPortoEVírgulaToolStripMenuItem;
  private ToolStripSeparator toolStripSeparator3;
  private ToolStripMenuItem cmsExportarResultadoPontoVirgula;
  private ToolStripMenuItem cmsExportarResultadoPipe;
  private ToolStripMenuItem cmsAtualizarListaTabelas;
  private ToolStripMenuItem cmsOcultarColuna;
  private OpenFileDialog ofdAcessarArquivos;
  private SaveFileDialog sfdSalvarArquivos;
  private ToolStripMenuItem cmsReexibirColunas;
  private ToolStripSeparator toolStripSeparator6;
  private ToolStripSeparator toolStripSeparator5;
  private ContextMenuStrip cmsFiltroCabecalhoValidacaoResultado;
  private ToolStripMenuItem cmsColunaFiltrada;
  private ToolStripSeparator toolStripSeparator7;
  private ToolStripComboBox cmsCmbOperadores;
  private ToolStripTextBox cmsTextoFiltrar;
  private ToolStripMenuItem cmsAdicionarFiltros;
  private ToolStripMenuItem toolStripMenuItem2;
  private ToolStripMenuItem cmsExpandirBancos;
  private ToolStripMenuItem cmsContrairBancos;
  private ToolStripSeparator toolStripSeparator8;
  private ToolStripMenuItem sinalizarCélulaToolStripMenuItem;
  private ToolStripMenuItem cmsFundoVerde;
  private ToolStripMenuItem cmsFundoAmarelo;
  private ToolStripMenuItem cmsFundoVermelho;
  private ToolStripMenuItem cmsFundoBranco;
  private TabPage tabPage1;
  private TreeView tvwValidacaoResultado;
  private TabControl tabNavegacao;
  private ToolStripMenuItem cmsInformacoesEdicao;
  private ToolStripMenuItem cmsHabilitarEdicao;
  private ToolStripSeparator toolStripSeparator9;
  private ToolStripMenuItem cmsCarregarDados;
  private ToolStripMenuItem estatísticasToolStripMenuItem;
  private ToolStripMenuItem cmsVolumetriaTabelas;
  private ToolStripMenuItem cmsAdicionaTabela;
  private ToolStripMenuItem cmsRemoverTabela;
  private ToolStripSeparator toolStripSeparator10;
  private ToolStripMenuItem cmsInformativos;
  private ListBox lbHistoricoConsultas;
  private ToolStripMenuItem cmsAddFavoritos;
  private ToolStripSeparator toolStripSeparator11;
  private ToolStripMenuItem cmsDelFavoritos;
  private ToolStripMenuItem cmsPesquisarNestaColuna;
  private ToolStripTextBox cmsTextoPesquisaValidacaoResultado;
  private ToolStripSeparator toolStripSeparator12;
  private ToolStripMenuItem cmsLimparFiltroColuna;
  private NotifyIcon notifyIcon1;
  private ToolStripMenuItem cmsExportarCronogramaInsumos;
  private ToolStripMenuItem cmsExecutarPrograma;
  private ToolStripMenuItem cmsGerarKanban;
  private ToolStripMenuItem cmsAjustarColuna;
  private ToolStripMenuItem cmsAtualizaVolumetriaInsumos;
  private ToolStripMenuItem cmsApenasGerarInformativo;
  private ToolStripMenuItem gerarEEnviarToolStripMenuItem;
  private ToolStripMenuItem cmsGerarEnviarInformativoParaMim;
  private ToolStripMenuItem cmsGerarEnviarInformativosParaColaboradores;
  private ToolStripMenuItem entreToolStripMenuItem;
  private ToolStripMenuItem toolStripMenuItem1;
  private ToolStripTextBox cmsTxFiltroInicial;
  private ToolStripMenuItem toolStripMenuItem3;
  private ToolStripTextBox cmsTxFiltroFinal;
  private ToolStripMenuItem cmsFiltrarEntre;
  private ToolStripSeparator toolStripSeparator13;
  private ToolStripMenuItem cmsAdicionarFiltrosEPesquisar;
  private ToolStripMenuItem cmsAdicionarFiltrosEPesquisarEEditar;
  private ToolStripMenuItem cmsAbrirTextoEmOutraJanela;
  private ToolStripMenuItem cmsInserirLinha;
  private ToolStripMenuItem cmsHomolog;
  private ToolStripMenuItem cmsGraficoVariacao;
  private ToolStripMenuItem tsmGerarInformativo;
  private ImageList imgValidacaoResultado64x16;
  private TabPage tpValidacaoResultadoInicio;
  private Panel panel1;
  private ComboBox cmbDelimitador;
  private CheckBox chkPreVisualizacao;
  private CheckBox chkExportar;
  private CheckBox chkModoCompatibilidade;
  private CheckBox chkRemoverDuplicados;
  private Button btnAdicionarLinhas;
  private Button btnSalvarNovasLinhas;
  private Button btnEstatisticas;
  private Button btnExcluir;
  private Button btnPesquisarEditar;
  private Button btnVRExportarExcel;
  private Button btnPesquisarValidacaoResultado;
  private GroupBox grpFiltrosValidacaoResultado;
  private Button btnSalvarConsultaValidacaoResultado;
  private Button btnGerarSQLValidacaoResultado;
  private Button btnLimpaFiltroValidacaoResultado;
  private DataGridView dgvFiltrosValidacaoResultado;
  private TabControl tabConsultaBancos;
  private TabPage tabConsultaPrincipal;
  private TabPage tabSql;
  private RichTextBox rtbSQL;
  private TextBox txtControleForms;
  private TabControl tabValidaResultAux1;
  private TabPage tabHistoricoConsultas;
  private TabControl tabOpcoes;
  private TabPage tabOpcoesConsultas;
  private ToolStripMenuItem calendárioDeDemandasToolStripMenuItem;
  private ToolStripMenuItem cmsGerarNovoKanban;
  private Button btLimparFiltroTabelas;
  private Button btPesquisarTabelas;
  private TextBox txPesquisarTabelas;
  private ContextMenuStrip cmsCombo;
  private ToolStripComboBox cmbItensDataGrid;
  private ToolStripMenuItem cmsItemComboOK;
  private ToolStripMenuItem cmsItemCombo;
  private ToolStripMenuItem cmsGerarWord;
  private ToolStripMenuItem cmsReenviarWord;
  private TabPage tpDataQuality;
  private Panel panel3;
  private TabPage tpCalculo;
  private Button btnDocumentacaoPrograma;
  private Button btnExecutarProgramas;
  private Button btnLiberarTodosProgramas;
  private Button btnBloquearTodosProgramas;
  private ComboBox cmbPeriodo;
  private Label label1;
  private Label label2;
  private ComboBox cmbSegmentos;
  private CheckBox chkOrdenarProcessos;
  private CheckBox chkEmailDeErroPraMim;
  private CheckBox chkPararCalculoSeHouverErro;
  private TextBox txTabelaAtual;
  private Button btnNovaConsultaBancos;
  private Button button7;
  private TabPage tpCalculoPrincipal;
  private TextBox txCodigoForm;
  private Panel panel4;
  private CheckBox chkFiltroDiferenciaMaiuscula;
  private GroupBox groupBox2;
  private Panel panel5;
  private GroupBox groupBox1;
  private GroupBox groupBox3;
  private Button btnExecutarProgramasCalculo;
  private Label label6;
  private ComboBox cmbTipoCalc;
  private Label label7;
  private ComboBox cmbVersaoExecCalc;
  private Label label5;
  private ComboBox cmbCanalCalc;
  private Label label3;
  private ComboBox cmbPeriodoCalc;
  private Label label4;
  private ComboBox cmbSegmentoCalc;
  private RichTextBox rtbStatusProcessamento;
  private Panel panel2;
  private Button btnLimparFiltrosCalc;
  private Button btnBloquearCalc;
  private Button btnHistoricoExecucaoCalc;
  private Button btnDetalharProgramasCalc;
  private Label label8;
  private ComboBox cmbStatusCalc;
  private GroupBox groupBox4;
  private Label label9;
  private ComboBox cmbCenarioDQ;
  private Panel panel6;
  private Button btnLimpaFiltrosDQ;
  private Button btnParametrosDataQuality;
  private Label label10;
  private ComboBox cmbTipoDQ;
  private Label label11;
  private ComboBox cmbInsumoDQ;
  private Label label12;
  private ComboBox cmbCanalDQ;
  private Label label13;
  private ComboBox cmbPeriodoDQ;
  private Label label14;
  private ComboBox cmbSegmentoDQ;
  private CheckBox chkRealizadoZerado;
  private TabPage tpCargaInsumos;
  private GroupBox groupBox5;
  private Panel panel7;
  private Button btnLimparFiltrosBases;
  private Button button2;
  private Button button3;
  private Button button4;
  private Label label16;
  private ComboBox cmbNomeBases;
  private Label label18;
  private ComboBox cmbCanalBases;
  private Label label19;
  private ComboBox cmbPeriodoBases;
  private Label label20;
  private ComboBox cmbSegmentoBases;
  private Button btnCarregarBase;
  private RichTextBox rtbStatusCargaBase;
  private ContextMenuStrip cmsProcurarArquivo;
  private ToolStripMenuItem tsmProcurarArquivo;
  private ToolStripMenuItem cmsEditarCelulaArquivoOrigem;
  private ToolStripSeparator toolStripSeparator14;
  private CheckBox chkDesativarFormatacao;
  private TextBox txConsultaAtual;
  private Button btnAbrirConsultaValidacaoResultado;
  private TabPage tpInformativos;
  private GroupBox groupBox6;
  private Label label15;
  private ComboBox cmbCargoInformativo;
  private Label label17;
  private ComboBox cmbVersaoInformativo;
  private Label label21;
  private ComboBox cmbTrimestreInformativo;
  private Label label22;
  private ComboBox cmbCanalInformativo;
  private Label label23;
  private ComboBox cmbPeriodoInformativo;
  private Label label24;
  private ComboBox cmbCalculoInformativo;
  private Button btnDivulgar;
  private Button btnEnviarParaMim;
  private Button btnApenasGerar;
  private RichTextBox rtbInformativos;

  public frmConsultaBancos() => this.InitializeComponent();

  private void frValidacaoResultado_Load(object sender, EventArgs e)
  {
    Encoding utF8 = Encoding.UTF8;
    this.dgvValidacaoResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    this.tvwValidacaoResultado.Scrollable = true;
    this.dgvValidacaoResultado.RowHeadersVisible = false;
    this.dgvValidacaoResultado.AllowUserToAddRows = false;
    this.dgvValidacaoResultado.ReadOnly = true;
    this.dgvValidacaoResultado.EnableHeadersVisualStyles = false;
    this.dgvValidacaoResultado.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
    this.dgvFiltrosValidacaoResultado.RowHeadersVisible = false;
    this.dgvFiltrosValidacaoResultado.CellBorderStyle = DataGridViewCellBorderStyle.None;
    this.dgvFiltrosValidacaoResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    this.dgvFiltrosValidacaoResultado.AllowUserToAddRows = false;
    this.dgvFiltrosValidacaoResultado.AllowUserToOrderColumns = false;
    this.dgvFiltrosValidacaoResultado.AllowUserToDeleteRows = false;
    this.dgvValidacaoResultado.AllowUserToResizeColumns = true;
    this.dgvFiltrosValidacaoResultado.AllowUserToResizeColumns = true;
    this.ativarBotoesEdicao(false);
    this.tvwValidacaoResultado.ImageList = this.imgValidacaoResultado16x16;
    this.tvwValidacaoResultado.ImageIndex = 1;
    ImageList validacaoResultado16x16 = this.imgValidacaoResultado16x16;
    ImageList validacaoResultado32x32 = this.imgValidacaoResultado32x32;
    this.cmsCombo.Items[0].Image = validacaoResultado16x16.Images[38];
    this.cmsPropriedades.Image = validacaoResultado16x16.Images[12];
    this.cmsProcurarArquivo.Items[1].Image = validacaoResultado16x16.Images[4];
    this.cmsExecutarPrograma.Image = validacaoResultado32x32.Images[0];
    this.cmsLimparOperador.Image = validacaoResultado16x16.Images[0];
    this.cmsAtualizarListaTabelas.Image = validacaoResultado16x16.Images[13];
    this.cmsPesquisarNestaColuna.Image = validacaoResultado16x16.Images[14];
    this.cmsLimparFiltroColuna.Image = validacaoResultado16x16.Images[0];
    this.cmsExportarResultado.Image = validacaoResultado16x16.Images[6];
    this.cmsItemCopiar.Image = validacaoResultado16x16.Images[15];
    this.cmsCopiarComCabecalho.Image = validacaoResultado16x16.Images[16 /*0x10*/];
    this.cmsCarregarDados.Image = validacaoResultado16x16.Images[23];
    this.cmsRemoverTabela.Image = validacaoResultado16x16.Images[24];
    this.cmsAdicionaTabela.Image = validacaoResultado16x16.Images[27];
    this.cmsAddFavoritos.Image = validacaoResultado16x16.Images[29];
    this.btnAdicionarLinhas.Image = validacaoResultado16x16.Images[31 /*0x1F*/];
    this.cmsInserirLinha.Image = validacaoResultado16x16.Images[31 /*0x1F*/];
    this.cmsDelFavoritos.Image = validacaoResultado16x16.Images[30];
    this.btnSalvarNovasLinhas.Image = validacaoResultado16x16.Images[3];
    this.cmbDelimitador.SelectedIndex = 1;
    this.cmbDelimitador.DropDownStyle = ComboBoxStyle.DropDownList;
    this.cmsCmbOperadores.DropDownStyle = ComboBoxStyle.DropDownList;
    this.cmsInformativos.Visible = false;
    this.cmsHomolog.Visible = false;
    this.button7.Enabled = true;
    this.button7.Visible = true;
    this.tipVRDiversos.SetToolTip((Control) this.btnVRExportarExcel, "Exportar o resultado da minha consulta para um arquivo texto delimitado por ';' e que pode ser aberto pelo Excel.");
    this.tipVRDiversos.SetToolTip((Control) this.btnGerarSQLValidacaoResultado, "Copiar o script SQL da sua consulta para a Área de Transferência");
    this.tipVRDiversos.SetToolTip((Control) this.btnPesquisarValidacaoResultado, "(F5) Executar consulta em banco de dados");
    this.tipVRDiversos.SetToolTip((Control) this.chkPreVisualizacao, $"Restringe o resultado em {DAL.quantidadeRegistrosPrevia().ToString()} registros. Desmarque para trazer todos os registros da sua pesquisa");
    this.tipVRDiversos.SetToolTip((Control) this.chkRemoverDuplicados, "Selecione esta opção para excluir todos os registros duplicados da sua consulta");
    this.tipVRDiversos.SetToolTip((Control) this.dgvFiltrosValidacaoResultado, "Para os filtros do tipo \"Igual a\" ou \"Diferentente de\" você pode adicionar vários valores separados por ponto e vírgula");
    this.tipVRDiversos.SetToolTip((Control) this.btnLimpaFiltroValidacaoResultado, "Limpa os filtros e apaga o resultado da consulta");
    this.tipVRDiversos.SetToolTip((Control) this.chkModoCompatibilidade, "Utilize este recurso apenas se sua pesquisa estiver retornando o erro \"Overflow\".\n\nEste erro é causado por campos contendo muitas casas depois da vírgula.\n\n*Habilitar esta função pode trazer resultados indesejados. Use com cautela.");
    this.cmsTextoPesquisaValidacaoResultado.ToolTipText = "Pesquisar um valor/texto diretamente nesta tabela de resultado.\n\nA cada caracter digitado a planilha filtrará as linhas conforme o filtro é preenchido.\n\nPara limpar seu filtro, clique no botão abaixo desta caixa de texto.";
    this.tipVRDiversos.SetToolTip((Control) this.chkExportar, "Exporta sua consulta diretamente para um arquivo texto, delimitado por \";\". Utilize este recurso quando seu resultado for muito grande para ser exibido na tela ou para melhorar o tempo de resposta.");
    this.tipVRDiversos.SetToolTip((Control) this.btnPesquisarEditar, "Pesquisar e editar");
    this.tipVRDiversos.SetToolTip((Control) this.btnExcluir, "Excluir registros do banco de dados. Use com muita cautela");
    this.tipVRDiversos.SetToolTip((Control) this.btnEstatisticas, "Visualizar a volumetria da tabela ativa");
    this.dgvValidacaoResultado.ColumnHeadersDefaultCellStyle.Font = new Font(Control.DefaultFont, FontStyle.Bold);
    this.dgvValidacaoResultado.AlternatingRowsDefaultCellStyle.BackColor = BLL.CorAmareloClaro;
    this.dgvFiltrosValidacaoResultado.ColumnHeadersDefaultCellStyle.Font = new Font(Control.DefaultFont, FontStyle.Bold);
    this.dgvFiltrosValidacaoResultado.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
    this.dgvFiltrosValidacaoResultado.DefaultCellStyle.SelectionForeColor = this.dgvFiltrosValidacaoResultado.DefaultCellStyle.ForeColor;
    this.dgvFiltrosValidacaoResultado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    this.dgvFiltrosValidacaoResultado.GridColor = BLL.CorCinzaClaro;
    this.dgvFiltrosValidacaoResultado.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
    this.cmbSegmentos.DropDownStyle = ComboBoxStyle.DropDownList;
    this.cmbPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;
    this.popularTreeviewValidacaoResultado2();
    Globals._numeroTentativas = 0;
    this.KeyPreview = true;
    this.desativarTodasTabs();
    this.ativarTab(this.tpValidacaoResultadoInicio);
    switch (BLL.controleForms)
    {
      case 1:
        this.btnPesquisarValidacaoResultado.Text = "(F5)\nExecutar";
        this.Text = "Painel de execuçãoo e cálculo";
        this.txtControleForms.Text = BLL.controleForms.ToString();
        BLL.controleForms = 1;
        this.btnPesquisarValidacaoResultado.Image = validacaoResultado32x32.Images[2];
        this.dgvValidacaoResultado.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
        this.ativarTab(this.tpCalculo);
        this.ativarTab(this.tpCalculoPrincipal);
        this.executarConsultaComParametros("GVDW_OWNER.VW_CP_ERP_CALCULOS@pdw1#ROWNUM<100");
        this.txCodigoForm.Text = "1";
        this.dgvValidacaoResultado.RowHeadersVisible = true;
        DataView dataView = new DataView(DAL.PegarDadosTOT("SELECT 0 ID_SEGMENTO, '*Selecione' SEGMENTO, '*Selecione' PERIODO FROM DUAL UNION ALL SELECT ID_SEGMENTO, SEGMENTO, PERIODO FROM (SELECT DISTINCT NVL(P.ID_SEGMENTO,0) ID_SEGMENTO, S.SEGMENTO SEGMENTO, TO_CHAR(P.PERIODO,'DD/MM/YYYY') PERIODO FROM GVDW_OWNER.RV_B2B_ORDEM_PROCESS P, GVDW_OWNER.RV_B2B_SEGMENTOS S WHERE P.ID_SEGMENTO = S.ID(+) AND P.PERIODO BETWEEN ADD_MONTHS(SYSDATE,-14) AND SYSDATE AND P.PERIODO IS NOT NULL ORDER BY SEGMENTO, TO_DATE(PERIODO) DESC) "));
        DataTable table = dataView.ToTable(true, "PERIODO");
        this.cmbSegmentos.DataSource = (object) dataView.ToTable(true, "SEGMENTO", "ID_SEGMENTO");
        this.cmbSegmentos.DisplayMember = "SEGMENTO";
        this.cmbSegmentos.ValueMember = "ID_SEGMENTO";
        this.cmbPeriodo.DataSource = (object) table;
        this.cmbPeriodo.ValueMember = "PERIODO";
        this.popularCombosCalculoConsolidado();
        break;
      case 2:
        this.Text = "Painel de Data Quality de bases (input/output)";
        this.txtControleForms.Text = BLL.controleForms.ToString();
        BLL.controleForms = 2;
        this.executarConsultaComParametros("GVDW_OWNER.VW_RV_B2B_DATAQUALITY3@pdw1#ROWNUM<100");
        this.ativarTab(this.tpDataQuality);
        this.txPesquisarTabelas.Text = "Quality";
        System.Windows.Forms.Application.DoEvents();
        this.btPesquisarTabelas.PerformClick();
        this.popularCombosDataQuality();
        this.txCodigoForm.Text = "2";
        break;
      case 3:
        this.Text = "Painel de cargas de bases";
        this.txtControleForms.Text = BLL.controleForms.ToString();
        BLL.controleForms = 3;
        this.executarConsultaComParametros("GVDW_OWNER.RV_B2B_CARGAS_BASES@pdw1#ROWNUM<100");
        this.ativarTab(this.tpCargaInsumos);
        this.txPesquisarTabelas.Text = "Cargas";
        System.Windows.Forms.Application.DoEvents();
        this.btPesquisarTabelas.PerformClick();
        this.popularCombosCargaBases();
        this.txCodigoForm.Text = BLL.controleForms.ToString();
        this.dgvValidacaoResultado.RowHeadersVisible = true;
        break;
      case 4:
        this.Text = "Painel de informativos";
        this.txtControleForms.Text = BLL.controleForms.ToString();
        BLL.controleForms = 4;
        this.executarConsultaComParametros("GVDW_B2B.VW_RESULTADO_FINAL_INFORM_TOT@pdw1#ROWNUM<100");
        this.ativarTab(this.tpInformativos);
        this.txPesquisarTabelas.Text = "INFORM_TOT";
        System.Windows.Forms.Application.DoEvents();
        this.btPesquisarTabelas.PerformClick();
        this.popularCombosInformativo();
        this.txCodigoForm.Text = BLL.controleForms.ToString();
        this.dgvValidacaoResultado.RowHeadersVisible = true;
        break;
      default:
        this.btnPesquisarValidacaoResultado.Text = "(F5)\nPesquisar";
        this.Text = "Assistente Navegação Dados";
        this.txtControleForms.Text = BLL.controleForms.ToString();
        this.btnPesquisarValidacaoResultado.Image = validacaoResultado32x32.Images[0];
        this.dgvValidacaoResultado.AlternatingRowsDefaultCellStyle.BackColor = BLL.CorAmareloClaro;
        this.txCodigoForm.Text = "0";
        break;
    }
  }

  private void popularCombosInformativo()
  {
    DataTable dataTable = new DataTable();
    try
    {
      DataView dv = new DataView(DAL.PegarDadosTOT("SELECT DISTINCT PERIODO \"Período\", CANAL \"Canal\", ID_VERSAO \"Versão\", CARGO \"Cargo\", CALCULO \"Cálculo\", TRIMESTRE \"Trimestre\" FROM GVDW_B2B.VW_RESULTADO_FINAL_INFORM_TOT ORDER BY 1 DESC"));
      this.popularComboBox(this.cmbPeriodoInformativo, dv, "Período");
      this.popularComboBox(this.cmbCanalInformativo, dv, "Canal");
      this.popularComboBox(this.cmbCargoInformativo, dv, "Cargo");
      this.popularComboBox(this.cmbVersaoInformativo, dv, "Versão");
      this.popularComboBox(this.cmbCalculoInformativo, dv, "Cálculo");
      this.popularComboBox(this.cmbTrimestreInformativo, dv, "Trimestre");
    }
    catch (Exception ex)
    {
      BLL.erro("Popular os combos de filtros de informativos.", ex.Message);
    }
  }

  private void popularCombosCalculoConsolidado()
  {
    DataTable dataTable = new DataTable();
    try
    {
      DataView dv = new DataView(DAL.PegarDadosTOT("SELECT DISTINCT \"Período\", \"Segmento\", \"Canal\", \"Tipo\", \"Execuções\", \"Status\" FROM GVDW_OWNER.VW_CP_ERP_CALCULOS ORDER BY 1"));
      this.popularComboBox(this.cmbPeriodoCalc, dv, "Período");
      this.popularComboBox(this.cmbSegmentoCalc, dv, "Segmento");
      this.popularComboBox(this.cmbCanalCalc, dv, "Canal");
      this.popularComboBox(this.cmbTipoCalc, dv, "Tipo");
      this.popularComboBox(this.cmbVersaoExecCalc, dv, "Execuções");
      this.popularComboBox(this.cmbStatusCalc, dv, "Status");
    }
    catch (Exception ex)
    {
      BLL.erro("Popular os combos de filtros do cálculo.", ex.Message);
    }
  }

  private void popularCombosDataQuality()
  {
    DataTable dataTable = new DataTable();
    DataView dv = new DataView(DAL.PegarDadosTOT("SELECT '_'||TO_CHAR(ADD_MONTHS(SYSDATE,-12),'YYYYMM')||' a '|| TO_CHAR(SYSDATE,'YYYYMM') PERIODO, '' SEGMENTO, '' CANAL, '' TIPO, '' INSUMO, '' FAIXA, '' CENARIO FROM DUAL UNION SELECT DISTINCT \"PERIODO\", \"SEGMENTO\", \"CANAL\", \"TIPO\", \"INSUMO\", \"FAIXA\",\"CENARIO\"    FROM GVDW_OWNER.VW_RV_B2B_DATAQUALITY3   ORDER BY 1,2"));
    this.popularComboBox(this.cmbSegmentoDQ, dv, "SEGMENTO");
    this.popularComboBox(this.cmbCanalDQ, dv, "CANAL");
    this.popularComboBox(this.cmbTipoDQ, dv, "TIPO");
    this.popularComboBox(this.cmbInsumoDQ, dv, "INSUMO");
    this.popularComboBox(this.cmbCenarioDQ, dv, "CENARIO");
    this.popularComboBox(this.cmbPeriodoDQ, dv, "PERIODO");
  }

  private void popularCombosCargaBases()
  {
    DataTable dataTable = new DataTable();
    DataView dv = new DataView(DAL.PegarDadosTOT("SELECT DISTINCT \"PERIODO\", \"SEGMENTO\", \"CANAL\", \"NOME_BASE\"    FROM GVDW_OWNER.RV_B2B_CARGAS_BASES   ORDER BY 1,2"));
    this.popularComboBox(this.cmbSegmentoBases, dv, "SEGMENTO");
    this.popularComboBox(this.cmbCanalBases, dv, "CANAL");
    this.popularComboBox(this.cmbPeriodoBases, dv, "PERIODO");
    this.popularComboBox(this.cmbNomeBases, dv, "NOME_BASE");
  }

  public void popularComboBox(ComboBox cmb, DataView dv, string campo)
  {
    try
    {
      dv.AddNew().EndEdit();
      dv.Sort = campo + " ASC";
      cmb.DataSource = (object) dv.ToTable(true, campo);
      cmb.DisplayMember = campo;
      cmb.ValueMember = campo;
      cmb.SelectedIndex = -1;
      cmb.DropDownStyle = ComboBoxStyle.DropDownList;
    }
    catch (Exception ex)
    {
      BLL.erro($"Falha ao tentar popular os dados do combo {cmb.Name.ToString()} - campo {campo}.", ex.Message);
    }
  }

  public void popularTreeviewValidacaoResultado2(bool filtrar = false)
  {
    try
    {
      this.tvwValidacaoResultado.Nodes.Clear();
      string str1 = "";
      string str2;
      switch (BLL.controleForms)
      {
        case 0:
          str2 = "";
          frmConsultaBancos.sqlFiltroCalculo = " AND ID_ORDEM <> 15 ";
          break;
        case 1:
          str2 = " AND G.ID_VALIDA_RESULT_GRUPO = 1 ";
          frmConsultaBancos.sqlFiltroCalculo = " AND ID_ORDEM = 15 ";
          break;
        default:
          str2 = "";
          frmConsultaBancos.sqlFiltroCalculo = " AND ID_ORDEM <> 15 ";
          break;
      }
      string upper = this.txPesquisarTabelas.Text.ToUpper();
      if (!string.IsNullOrWhiteSpace(upper))
        str1 = $"{str1} AND (UPPER(NM_TABELA) LIKE '%{upper}%' OR UPPER(NM_APELIDO) LIKE '%{upper}%') ";
      BLL.popularTreeview(this.tvwValidacaoResultado, $"SELECT DISTINCT G.ID_VALIDA_RESULT_GRUPO,G.NM_GRUPO,G.DS_GRUPO FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT_GRUPO G, GVDW_OWNER.VW_RV_B2B_VALIDA_RESULT_2 V  WHERE G.ID_VALIDA_RESULT_GRUPO = V.ID_VALIDA_RESULT_GRUPO {str2}{str1}ORDER BY G.ID_VALIDA_RESULT_GRUPO ASC ", "NM_GRUPO", campoToolTipText: "DS_GRUPO", campoText: "NM_GRUPO");
      BLL.popularTreeview(this.tvwValidacaoResultado, $"SELECT V.NM_ORDEM NM_ORDEM,V.DS_ORDEM DS_ORDEM,V.NM_GRUPO NM_GRUPO ,V.DS_GRUPO DS_GRUPO FROM gvdw_owner.VW_RV_B2B_VALIDA_RESULT V INNER JOIN GVDW_OWNER.RV_B2B_VALIDA_RESULT_ORDEM O ON O.NM_ORDEM = V.NM_ORDEM INNER JOIN (SELECT DISTINCT NM_ORDEM, NM_GRUPO FROM GVDW_OWNER.VW_RV_B2B_VALIDA_RESULT_2 WHERE 1=1 {str1}) V2 ON V.NM_GRUPO=V2.NM_GRUPO AND V.NM_ORDEM=V2.NM_ORDEM WHERE 1=1 {frmConsultaBancos.sqlFiltroCalculo}", "NM_ORDEM", "NM_GRUPO", "DS_ORDEM", "NM_GRUPO", "NM_ORDEM", true);
      BLL.popularTreeview(this.tvwValidacaoResultado, $"SELECT A.* FROM GVDW_OWNER.VW_RV_B2B_VALIDA_RESULT_2 A WHERE (LOGIN_REDE is null or UPPER(LOGIN_REDE) = '{Globals._loginRedeUsuario.ToUpper()}'){str1} ORDER BY NM_APELIDO", "NM_TABELA", "NM_ORDEM", "DS_OBS", "NM_GRUPO", "NM_APELIDO", true, 2);
      this.formatarTvwBasesConsulta(this.tvwValidacaoResultado);
    }
    catch (Exception ex)
    {
      BLL.erro("", ex.Message);
    }
  }

  private void tvwValidacaoResultado_DoubleClick(object sender, EventArgs e)
  {
    try
    {
      string name = this.tvwValidacaoResultado.SelectedNode.Name;
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      this.preencherBarraStatusPrincipal($"Procurar tabela {name} para {Globals._loginRedeUsuario}");
      DataTable dataTable = DAL.PegarDadosTOT($"SELECT FILTROS, CAMPO_CLASSIFICADO, ORDEM_CAMPO FROM GVDW_OWNER.RV_B2B_FILTROS_TOT WHERE UPPER(TABELA) = UPPER('{name.Replace("'", "''")}') AND LOGIN_USUARIO = '{Globals._loginRedeUsuario}'");
      if (!dataTable.Equals((object) null))
      {
        if (dataTable.Columns.Contains("FILTROS"))
        {
          if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["FILTROS"].ToString().Length > 0)
          {
            string str1 = dataTable.Rows[0]["FILTROS"].ToString();
            string columnName = dataTable.Rows[0]["CAMPO_CLASSIFICADO"].ToString();
            string str2 = dataTable.Rows[0]["ORDEM_CAMPO"].ToString();
            this.lbHistoricoConsultas.Items.Add((object) str1);
            this.lbHistoricoConsultas.SelectedIndex = this.lbHistoricoConsultas.Items.Count - 1;
            this.executarConsultaHistorica();
            if (!columnName.Equals(""))
              validacaoResultado.Sort(validacaoResultado.Columns[columnName], str2.Equals("Ascending") ? ListSortDirection.Ascending : ListSortDirection.Descending);
          }
          else
            this.clicouTreeView();
        }
        else
        {
          this.preencherBarraStatusPrincipal("Não encontrada a coluna FILTROS na base de consultas personalizadas");
          this.clicouTreeView();
        }
        if (dataTable.Columns.Contains("errotot"))
          BLL.erro("Erro ao recuperar consulta salva: ", dataTable.Rows[0][0].ToString());
      }
      else
        this.clicouTreeView();
      this.cmbPeriodo.SelectedIndex = -1;
      this.cmbSegmentos.SelectedIndex = -1;
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao reiniciar os filtros de periodo e segmento", ex.Message);
    }
  }

  public void popularGridValidacaoResultado(
    string tabela,
    bool consultaComFiltros,
    string consultaSQL,
    string bancoSelecionado)
  {
    try
    {
      this.tabelaEditavel();
      this.btnPesquisarValidacaoResultado.Text = "Aguarde!";
      this.btnPesquisarValidacaoResultado.Enabled = false;
      this.btnPesquisarEditar.Enabled = false;
      int dataGridPrincipal = Settings.Default.NuMaxLinhasDataGridPrincipal;
      string[] strArray = DAL.PegarConnectionString(bancoSelecionado);
      DataTable dataTable = new DataTable();
      string str = $"SELECT T2.* FROM {strArray[3]}{tabela} T2 ";
      if (!string.IsNullOrWhiteSpace(consultaSQL))
      {
        if (this.tabConsultaBancos.SelectedTab == this.tabConsultaBancos.TabPages["tabSQL"])
        {
          int num = (int) MessageBox.Show("Você está usando um recurso experimental,\nque pode apresentar resultados inesperados.\n\nMuito cuidado ao editar o SCRIPT SQL", "TOT - SQL personalizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          str = this.rtbSQL.Text.ToUpper().Replace("DELETE", "").Replace("DROP", "").Replace("TRUNCATE", "").Replace("UPDATE", "").Replace("EXECUTE", "").Replace("CREATE", "").Replace("ALTER", "");
          this.tabConsultaBancos.SelectedTab = this.tabConsultaBancos.TabPages[0];
        }
        else
          str = consultaSQL;
        BLL.SQLParaAreaDeTransferencia = str;
        this.rtbSQL.Text = str;
      }
      else if (tabela.IndexOf("SELECT ") > 0)
        str += " WHERE 1>2 ";
      DataTable dg;
      if (strArray[1].Equals("1"))
      {
        dg = DAL.PegarDadosBancos(bancoSelecionado, this.chkPreVisualizacao.Checked ? $"SELECT T1.* FROM ({str}) T1 WHERE ROWNUM <= {dataGridPrincipal.ToString()}" : str, this.chkModoCompatibilidade.Checked);
      }
      else
      {
        string banco = bancoSelecionado;
        string consulta;
        if (!this.chkPreVisualizacao.Checked)
          consulta = str;
        else
          consulta = $"SELECT TOP {dataGridPrincipal.ToString()} T1.* FROM ({str}) T1 ";
        int num = this.chkModoCompatibilidade.Checked ? 1 : 0;
        dg = DAL.PegarDadosBancos(banco, consulta, num != 0);
      }
      if (this.chkExportar.Checked)
      {
        try
        {
          this.dgvValidacaoResultado.DataSource = (object) null;
          BLL.exportarResultado(this.cmbDelimitador.Text.ToString(), dg);
          int num = (int) MessageBox.Show("Sua consulta foi exportada!", "TOT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        catch (Exception ex)
        {
          BLL.erro("Erro ao exportar sua consulta.", ex.Message);
        }
      }
      else
      {
        this.dgvValidacaoResultado.DataSource = (object) dg;
        this.txTabelaAtual.Text = DAL._tabelaAtual;
      }
      BLL.SQLParaAreaDeTransferencia = str;
      this.btnPesquisarValidacaoResultado.Text = "(F5) Pesquisar";
      this.btnPesquisarValidacaoResultado.Enabled = true;
      this.btnPesquisarEditar.Enabled = true;
      BLL.InserirLog(Globals._loginRedeUsuario.ToUpper(), $"Executou o script: /*{str.Replace("'", "''")}*/");
    }
    catch (OracleException ex)
    {
      this.btnPesquisarValidacaoResultado.Text = "(F5) Pesquisar";
      this.btnPesquisarValidacaoResultado.Enabled = true;
      this.btnPesquisarEditar.Enabled = true;
      BLL.erro("Erro ao recuperar os dados da base." + Environment.NewLine, $"{ex.Message}Codigo: {ex.Code.ToString()}");
    }
  }

  public void popularGridFiltrosValidacaoResultado()
  {
    TreeNode parent = this.tvwValidacaoResultado.SelectedNode.Parent;
    TreeNode selectedNode = this.tvwValidacaoResultado.SelectedNode;
    DataTable dataTable = new DataTable();
    this.dgvFiltrosValidacaoResultado.DataSource = (object) BLL.popularGridFiltros2(this.dgvFiltrosValidacaoResultado);
  }

  private void dgvFiltrosValidacaoResultado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
  {
    if (!e.ColumnIndex.Equals(2))
      return;
    string str = this.dgvFiltrosValidacaoResultado.Rows[e.RowIndex].Cells[2].Value.ToString().Replace("\\n", ";").Replace(Environment.NewLine, ";");
    this.dgvFiltrosValidacaoResultado.Rows[e.RowIndex].Cells[2].Value = (object) str;
    int length1 = str.Trim().Length;
    int length2 = 1000;
    if (length1 > 0)
    {
      this.dgvFiltrosValidacaoResultado.CurrentRow.DefaultCellStyle.BackColor = BLL.CorAmarela;
      if (length1 > length2)
      {
        this.dgvFiltrosValidacaoResultado.Rows[e.RowIndex].Cells[2].Value = (object) str.Substring(0, length2);
        int num = (int) MessageBox.Show($"O conteúdo do filtro não pode exceder {length2.ToString()} caracteres. O conteúdo será truncado", "TOT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }
    else
      this.dgvFiltrosValidacaoResultado.CurrentRow.DefaultCellStyle.BackColor = BLL.CorTransparente;
  }

  private void dgvFiltrosValidacaoResultado_MouseClick(object sender, MouseEventArgs e)
  {
    if (this.dgvFiltrosValidacaoResultado.RowCount <= 0 || !this.dgvFiltrosValidacaoResultado.CurrentCell.ColumnIndex.Equals(1))
      return;
    this.cmsFiltrosValidacaoResultado.Show(Cursor.Position.X, Cursor.Position.Y);
  }

  private void cmsFiltrosValidacaoResultado_ItemClicked(
    object sender,
    ToolStripItemClickedEventArgs e)
  {
    string text = e.ClickedItem.Text;
    switch (text)
    {
      case "Entre":
        break;
      case "Remover este filtro":
        this.dgvFiltrosValidacaoResultado.CurrentCell.Value = (object) "";
        this.dgvFiltrosValidacaoResultado.Rows[this.dgvFiltrosValidacaoResultado.CurrentCell.RowIndex].Cells[2].Value = (object) "";
        break;
      case "Adicionar condição...":
        string str = this.dgvFiltrosValidacaoResultado.Rows[this.dgvFiltrosValidacaoResultado.CurrentCell.RowIndex].Cells[0].Value.ToString();
        int rowIndex = this.dgvFiltrosValidacaoResultado.CurrentCell.RowIndex;
        DataTable dataSource = (DataTable) this.dgvFiltrosValidacaoResultado.DataSource;
        DataRow row = dataSource.NewRow();
        row[0] = (object) str;
        row[1] = (object) null;
        row[2] = (object) null;
        row[3] = (object) true;
        dataSource.Rows.InsertAt(row, rowIndex);
        break;
      default:
        this.dgvFiltrosValidacaoResultado.CurrentCell.Value = (object) text;
        break;
    }
  }

  private void btnPesquisarValidacaoResultado_Click(object sender, EventArgs e) => this.pesquisar();

  private void ativarBotoesEdicao(bool ativar)
  {
    if (!ativar)
      this.btnSalvarNovasLinhas.Enabled = ativar;
    this.btnAdicionarLinhas.Enabled = ativar;
    this.btnExcluir.Enabled = ativar;
    this.dgvValidacaoResultado.ReadOnly = !ativar;
  }

  private void pesquisar(bool editar = false, bool calculo = false)
  {
    string userInput = "";
    string str1 = "";
    string str2 = "";
    try
    {
      this.ativarBotoesEdicao(false);
      string[] strArray = DAL.PegarConnectionString(DAL._bancoSelecionado);
      this.dgvFiltrosValidacaoResultado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      foreach (DataGridViewRow row in (IEnumerable) this.dgvFiltrosValidacaoResultado.Rows)
      {
        string str3 = row.Cells[2].Value.ToString().Trim().Replace("'", "");
        string str4 = row.Cells[0].Value.ToString();
        string operadorSQL = row.Cells[1].Value.ToString();
        string str5 = row.Cells[3].Value.ToString();
        if (!string.IsNullOrWhiteSpace(str3) && string.IsNullOrWhiteSpace(operadorSQL))
        {
          BLL.erro($"Você está filtrando o campo {str4} com o valor {str3} mas faltou definir o operador (exemplo: Igual, Diferente, Maior...)");
          return;
        }
        if (str5.Equals("True"))
          str1 = $"{str1} A.\"{str4}\",";
        if (!string.IsNullOrWhiteSpace(operadorSQL))
        {
          if (!this.chkFiltroDiferenciaMaiuscula.Checked && !str3.Any<char>(new System.Func<char, bool>(char.IsDigit)))
          {
            string upper = str3.ToUpper();
            userInput = $"{userInput} AND UPPER(A.\"{str4}\"){this.ajustarOperadorSQL(operadorSQL, upper)}";
          }
          else
            userInput = $"{userInput} AND A.\"{str4}\"{this.ajustarOperadorSQL(operadorSQL, str3)}";
        }
        str2 = str4;
      }
      bool flag = this.chkRemoverDuplicados.Checked;
      string str6 = "";
      if (flag)
        str6 = " DISTINCT ";
      if (!BLL.checkForSQLInjection(userInput) | calculo)
      {
        if (!string.IsNullOrWhiteSpace(userInput) | calculo)
        {
          string str7 = "";
          BLL.dadosEdicaoTabela = (string[]) null;
          try
          {
            if (editar)
            {
              str7 = ", ROWID ";
              if (!this.tabelaEditavel())
              {
                this.dgvValidacaoResultado.ReadOnly = true;
                BLL.erro("Esta tabela está bloqueada para edição.\nPeça liberação para seu gestor.\n", "Tabela bloqueada para edição pelo Gestor da área.");
                return;
              }
              this.ativarBotoesEdicao(true);
            }
          }
          catch (Exception ex)
          {
            BLL.erro("Erro ao pesquisar.\n", ex.Message);
            this.dgvValidacaoResultado.ReadOnly = true;
            return;
          }
          this.popularGridValidacaoResultado("", true, $"SELECT {str6}{str1.Substring(1, str1.Length - 2)}{str7} FROM {strArray[3]}{DAL._tabelaAtual} A WHERE 1=1 {userInput}".Replace("not in ('')", "is not null").Replace("in ('')", "is null"), DAL._bancoSelecionado);
          this.salvarHistoricoPesquisa();
        }
        else
        {
          int num1 = (int) MessageBox.Show("Você não definiu nenhum filtro de pesquisa.", "TOT - Filtro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("Você utilizou termos restritos (não permitidos) em seus filtros. Verifique existem palavras como DELETE, DROP ou símbolos como '@', '-' ou outros caractéres que podem contaminar a pesquisa no banco.", "TOT - Filtro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      BLL.hignorarHistorico = false;
      this.formatarTituloColunaFiltrada();
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar executar a consulta. Verifique seus filtros corretamente.", ex.Message);
    }
    this.dgvFiltrosValidacaoResultado.SelectionMode = DataGridViewSelectionMode.CellSelect;
  }

  private void btnLimpaFiltroValidacaoResultado_Click(object sender, EventArgs e)
  {
    try
    {
      this.executarConsultaComParametros($"{this.txTabelaAtual.Text}@{DAL._bancoSelecionado}#ROWNUM<100");
    }
    catch (Exception ex)
    {
      this.preencherBarraStatusPrincipal($"Falha ao tentar limpar todos os filtros da {this.txTabelaAtual?.ToString()}. Erro: {ex.Message}", true);
    }
  }

  private string ajustarOperadorSQL(string operadorSQL, string valorSQL)
  {
    string str1 = operadorSQL;
    string str2;
    if (str1 != null)
    {
      switch (str1.Length)
      {
        case 5:
          if (str1 == "Entre")
          {
            str2 = $" between '{valorSQL.Replace(";", "' and '").Trim()}' ";
            goto label_22;
          }
          break;
        case 6:
          if (str1 == "Contém")
          {
            str2 = $" LIKE '%{valorSQL}%' ";
            goto label_22;
          }
          break;
        case 7:
          if (str1 == "Igual a")
          {
            str2 = $" in ('{valorSQL.Replace(";", "','").Trim()}') ";
            goto label_22;
          }
          break;
        case 10:
          if (str1 == "Não contém")
          {
            str2 = $" NOT LIKE '%{valorSQL}%' ";
            goto label_22;
          }
          break;
        case 11:
          switch (str1[3])
          {
            case 'a':
              if (str1 == "É maior que")
              {
                if (!BLL.ehNunero(valorSQL))
                  valorSQL = $"'{valorSQL}'";
                str2 = $"> {valorSQL} ";
                goto label_22;
              }
              break;
            case 'e':
              if (str1 == "É menor que")
              {
                if (!BLL.ehNunero(valorSQL))
                  valorSQL = $"'{valorSQL}'";
                str2 = "< " + valorSQL;
                goto label_22;
              }
              break;
          }
          break;
        case 12:
          if (str1 == "Diferente de")
          {
            str2 = $" not in ('{valorSQL.Replace(";", "','").Trim()}') ";
            goto label_22;
          }
          break;
      }
    }
    str2 = "";
label_22:
    return str2;
  }

  public void CopyToClipboardWithHeaders(DataGridView _dgv)
  {
    int count = _dgv.Rows.Count;
    DialogResult dialogResult = DialogResult.Cancel;
    int num = 1000000;
    if (count >= num)
      dialogResult = MessageBox.Show($"Sua consulta contém {count.ToString()} linhas, se tentar copiar todo esse volume podem haver problemas como estou de memória ou dados corrompidos.{Environment.NewLine}{Environment.NewLine}Deseja continuar mesmo assim?", "TOT - Risco de perda de dados", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
    if (count >= num && !dialogResult.Equals((object) DialogResult.OK))
      return;
    _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
    DataObject clipboardContent = _dgv.GetClipboardContent();
    if (clipboardContent != null)
      Clipboard.SetDataObject((object) clipboardContent);
    _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
  }

  private void dgvValidacaoResultado_MouseClick(object sender, MouseEventArgs e)
  {
    string tabelaAtual1 = DAL._tabelaAtual;
    this.txTabelaAtual.Text = DAL._tabelaAtual;
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    if (!string.IsNullOrEmpty(tabelaAtual1) && validacaoResultado.ReadOnly.Equals(false) && validacaoResultado.SelectedRows.Count <= 0 && e.Button.Equals((object) MouseButtons.Left) && tabelaAtual1.Equals("GVDW_OWNER.RV_B2B_CARGAS_BASES") && validacaoResultado.CurrentCell.OwningColumn.HeaderText.ToString().Equals("ENDERECO_BASE_ORIGEM"))
      this.cmsProcurarArquivo.Show(Cursor.Position.X, Cursor.Position.Y);
    if (!e.Button.Equals((object) MouseButtons.Right))
      return;
    this.cmsValidacaoResultado.Show(Cursor.Position.X, Cursor.Position.Y);
    if (string.IsNullOrWhiteSpace(BLL.celulaAtual))
    {
      this.cmsPesquisarNestaColuna.Enabled = false;
      this.cmsPesquisarNestaColuna.Text = "Selecione uma coluna para pesquisar";
      this.cmsOcultarColuna.Enabled = false;
      this.cmsOcultarColuna.Text = "Selecione uma coluna para ocultar";
    }
    else
    {
      this.cmsPesquisarNestaColuna.Enabled = true;
      this.cmsPesquisarNestaColuna.Text = "Pesquisar na coluna: " + BLL.celulaAtual;
      this.cmsOcultarColuna.Enabled = true;
      this.cmsOcultarColuna.Text = "Ocultar coluna " + BLL.celulaAtual;
    }
    if (!string.IsNullOrEmpty(DAL._tabelaAtual))
    {
      this.cmsInformativos.Visible = false;
      this.cmsExecutarPrograma.Visible = false;
      this.cmsExportarCronogramaInsumos.Visible = false;
      this.cmsGerarKanban.Visible = false;
      this.cmsAtualizaVolumetriaInsumos.Visible = false;
      this.cmsHomolog.Visible = false;
      string tabelaAtual2 = DAL._tabelaAtual;
      if (tabelaAtual2 != null)
      {
        switch (tabelaAtual2.Length)
        {
          case 31 /*0x1F*/:
            if (tabelaAtual2 == "GVDW_OWNER.RV_B2B_ORDEM_PROCESS")
            {
              this.cmsExecutarPrograma.Visible = true;
              goto label_28;
            }
            break;
          case 32 /*0x20*/:
            if (tabelaAtual2 == "GVDW_OWNER.VW_RV_B2B_INFORMATIVO")
            {
              this.cmsInformativos.Visible = true;
              goto label_28;
            }
            break;
          case 35:
            if (tabelaAtual2 == "GVDW_OWNER.RV_B2B_CONTROLE_DEMANDAS")
            {
              this.cmsGerarKanban.Visible = true;
              this.cmsHomolog.Visible = true;
              goto label_28;
            }
            break;
          case 36:
            if (tabelaAtual2 == "GVDW_OWNER.RV_B2B_CRONOGRAMA_INSUMOS")
            {
              this.cmsAtualizaVolumetriaInsumos.Visible = true;
              goto label_28;
            }
            break;
          case 38:
            switch (tabelaAtual2[5])
            {
              case 'B':
                if (tabelaAtual2 == "GVDW_B2B.VW_RESULTADO_FINAL_INFORM_TOT")
                {
                  this.cmsInformativos.Visible = true;
                  goto label_28;
                }
                break;
              case 'O':
                if (tabelaAtual2 == "GVDW_OWNER.VW_RV_B2B_GERAR_INFORMATIVO")
                {
                  this.cmsInformativos.Visible = true;
                  goto label_28;
                }
                break;
            }
            break;
          case 39:
            if (tabelaAtual2 == "GVDW_OWNER.VW_RV_B2B_CRONOGRAMA_INSUMOS")
            {
              this.cmsExportarCronogramaInsumos.Visible = true;
              goto label_28;
            }
            break;
          case 40:
            if (tabelaAtual2 == "GVDW_OWNER.RV_B2B_PARAMETROS_DATAQUALITY")
            {
              this.cmsExecutarPrograma.Visible = true;
              goto label_28;
            }
            break;
        }
      }
      this.cmsInformativos.Visible = false;
      this.cmsExecutarPrograma.Visible = false;
      this.cmsExportarCronogramaInsumos.Visible = false;
      this.cmsGerarKanban.Visible = false;
      this.cmsAtualizaVolumetriaInsumos.Visible = false;
      this.cmsHomolog.Visible = false;
label_28:;
    }
  }

  private void cmsItemCopiar_Click(object sender, EventArgs e)
  {
    Clipboard.SetDataObject((object) this.dgvValidacaoResultado.GetClipboardContent(), true);
  }

  private void dgvValidacaoResultado_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
  {
    try
    {
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      string celulaAtual = BLL.celulaAtual;
      BLL.ValorAnterior = validacaoResultado.CurrentCell.Value.ToString();
      BLL.ValorNovo = "";
      BLL.RowId = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["ROWID"].Value.ToString();
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao editar celulas.\n", ex.Message);
    }
  }

  private void dgvValidacaoResultado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      int index = validacaoResultado.CurrentRow.Index;
      if (!validacaoResultado.Columns.Contains("INDICE_NOVA_LINHA") || !validacaoResultado.Rows[index].Cells["INDICE_NOVA_LINHA"].Value.ToString().Equals("1"))
        ;
      string str1 = validacaoResultado.CurrentCell.OwningColumn.Name.ToString();
      string s = validacaoResultado.CurrentCell.Value.ToString();
      if (DAL.PegarDadosTOT($"SELECT EDITAVEL FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT WHERE NM_TABELA = '{DAL._tabelaAtual}' AND EDITAVEL = 1").Rows.Count > 0)
      {
        try
        {
          string str2 = !DateTime.TryParse(s, out DateTime _) ? $"'{s.Replace("'", "''")}'" : $"to_DATE('{s.Substring(0, 10)}','DD/MM/YYYY') ";
          string consulta = $"UPDATE {DAL._tabelaAtual}\nSET {str1} = {str2} \nWHERE ROWID = '{BLL.RowId}'";
          if (s.Equals(BLL.ValorAnterior))
            return;
          DataTable dataTable = DAL.PegarDadosTOT(consulta, alteracao: true);
          if (DAL._tabelaAtual.Equals("GVDW_OWNER.RV_B2B_CONTROLE_DEMANDAS") && s.Length > 1 && !s.Equals(BLL.ValorAnterior))
          {
            if (str1.Equals("DATA_CONCLUSAO"))
              this.enviarEmailMudancaStatusDemanda();
            if (str1.Equals("STATUS_HOMOLOG") && s.Equals("REVISAO"))
              this.enviarEmailMudancaStatusDemanda(2, validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["ID"].Value.ToString());
          }
          if (dataTable != null)
          {
            if (dataTable.Columns.Contains("errotot"))
              BLL.erro($"Ocorreu o seguinte erro ao tentar alterar o valor do campo {str1}:", dataTable.Rows[0][0].ToString());
          }
        }
        catch (Exception ex)
        {
          BLL.erro(ex.Message);
        }
      }
      else
      {
        string consulta = $"UPDATE {DAL._tabelaAtual}\nSET {str1} = '{s}' \nWHERE ROWID = '{BLL.RowId}'";
        if (s.Equals(BLL.ValorAnterior))
          return;
        if (MessageBox.Show($"Confirma a alteração abaixo:\n\nTabela que seá alterada: {DAL._tabelaAtual}\n\nCampo: {str1}\nID chave da linha alterada: {BLL.RowId}\n\nValor anterior: {BLL.ValorAnterior}\nValor NOVO: {s}\n\n\n\n***Essa alteração não poderá ser desfeita!", "TOT - Confirmar alterações", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.Cancel))
        {
          validacaoResultado.CurrentCell.Value = (object) BLL.ValorAnterior;
        }
        else
        {
          string texto = "";
          int num = 6;
          if (BLL.InputBox("TOT", "Informe o motivo do ajuste:", ref texto) == DialogResult.OK)
          {
            if (texto.Trim().Length < num)
            {
              BLL.erro($"O motivo deve ter ao menos {num.ToString()} caracteres.\n", "É obrigatório informar um motivo");
            }
            else
            {
              BLL.copiarParaAreaDeTransferencia(texto);
              if (DAL.PegarDadosTOT(consulta, alteracao: true) == null)
                BLL.erro("Não foi possível atualizar os dados.", "Erro ao atualizar tabela");
              if (DAL.PegarDadosTOT($"INSERT INTO GVDW_OWNER.RV_B2B_VALIDA_RESULT_EDIT_LOG\n(NM_TABELA, NM_CAMPO, VL_ANTERIOR, VL_NOVO, NM_LOGIN_USUARIO, DATA_HORA_ALTERACAO, DS_MOTIVO_ALTERACAO, DS_CONSULTA) VALUES ('{DAL._tabelaAtual}','{str1}','{BLL.ValorAnterior}','{s}','{Globals._loginRedeUsuario.ToUpper()}',TO_CHAR(SYSDATE, 'DD-MM-YY HH24:MI:SS'),'{texto}','{BLL.SQLParaAreaDeTransferencia.Replace("\"", "").Replace("'", "")}')", alteracao: true) == null)
                BLL.erro("Não foi possível atualizar os dados da tabela de LOG.", "Erro ao atualizar tabela");
            }
          }
          else
            BLL.erro("Não é possível salvar sua alteração sem informar um motivo.\n", "É obrigatório informar um motivo");
        }
      }
      this.txTabelaAtual.Text = DAL._tabelaAtual;
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao atualizar o banco de dados.\n", ex.Message);
    }
  }

  private void cmsItemSelecionarTudo_Click(object sender, EventArgs e)
  {
    this.dgvValidacaoResultado.SelectAll();
  }

  private void cmsCopiarComCabecalho_Click(object sender, EventArgs e)
  {
    this.CopyToClipboardWithHeaders(this.dgvValidacaoResultado);
  }

  private void btnGerarSQLValidacaoResultado_Click(object sender, EventArgs e)
  {
    try
    {
      if (!string.IsNullOrWhiteSpace(BLL.sql))
      {
        Clipboard.SetText(BLL.sql);
        int num = (int) MessageBox.Show("Sua consulta foi copiada para a Área de Transferência. Você já pode colar em seu editor de texto ou interface de banco de dados da sua preferência.", "TOT - Script exportado para Área de Transferência", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num1 = (int) MessageBox.Show("Não existe consulta para copiar.", "TOT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar copiar o script para a área de transferência. Aguardo uns segundos e tente novamente.", ex.Message);
    }
  }

  private void btnVRExportarExcel_Click(object sender, EventArgs e) => this.exportarResultado(";");

  private void btnAbrirConsultaValidacaoResultado_Click(object sender, EventArgs e)
  {
    MessageBox.Show($"Ao carregar uma consulta salva, tenha certeza que ela foi feita para a tabela atual [{DAL._tabelaAtual}].\n\nPoderão haver resutados inesperados caso você esteja carregando uma consulta feita para uma tabela diferente.", "TOT - mais um aviso chato...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    OpenFileDialog ofdAcessarArquivos = this.ofdAcessarArquivos;
    DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
    ofdAcessarArquivos.Filter = "Arquivo de consulta TOT (*.tot)|*.tot";
    int num = (int) ofdAcessarArquivos.ShowDialog();
    if (!ofdAcessarArquivos.CheckFileExists)
      return;
    try
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("INDICADOR", typeof (string));
      dataTable.Columns.Add("OPERADOR", typeof (string));
      dataTable.Columns.Add("VALOR", typeof (string));
      dataTable.Columns.Add(" ", typeof (bool));
      dataTable.Columns.Add("x", typeof (string));
      foreach (string readAllLine in File.ReadAllLines(ofdAcessarArquivos.FileName))
      {
        char[] chArray = new char[1]{ '|' };
        string[] strArray = readAllLine.Split(chArray);
        dataTable.Rows.Add((object[]) strArray);
      }
      dataTable.Columns.Remove("x");
      validacaoResultado.DataSource = (object) dataTable;
    }
    catch (Exception ex)
    {
      BLL.erro("Não foi possível carregar o arquivo de consulta.", ex.Message);
    }
  }

  private void btnSalvarConsultaValidacaoResultado_Click(object sender, EventArgs e)
  {
    this.salvarConsultas();
  }

  private void salvarConsultas()
  {
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    string str1 = "";
    string str2 = "";
    if (validacaoResultado.SortedColumn != null)
    {
      str1 = validacaoResultado.SortedColumn.Name;
      str2 = validacaoResultado.SortOrder.ToString();
    }
    string text1 = this.txTabelaAtual.Text;
    string text2 = this.txConsultaAtual.Text;
    string loginRedeUsuario = Globals._loginRedeUsuario;
    if (text2.Length > 1)
    {
      DAL.PegarDadosTOT($"DELETE FROM GVDW_OWNER.RV_B2B_FILTROS_TOT WHERE UPPER(TABELA) = UPPER('{text1}') AND UPPER(LOGIN_USUARIO) = UPPER('{loginRedeUsuario}') ", alteracao: true);
      DAL.PegarDadosTOT($"INSERT INTO GVDW_OWNER.RV_B2B_FILTROS_TOT (FILTROS, LOGIN_USUARIO, INICIO_AUTOMATICO, TABELA, CAMPO_CLASSIFICADO, ORDEM_CAMPO) VALUES ('{text2}','{loginRedeUsuario}','1','{text1}','{str1}','{str2}')", alteracao: true);
      this.preencherBarraStatusPrincipal($"Filtros de início de pesquisa para {text1} foram salvos.");
    }
    else
      this.preencherBarraStatusPrincipal($"Não foram identificadas alterações de filtro na {text1} para serem salvos.", true);
  }

  private void chkPreVisualizacao_CheckedChanged(object sender, EventArgs e)
  {
    string mensagem = "Atenção, ao desmarcar esta opção todos os registros serão carregados na tela.\nAntes de proseguir com sua consulta, verifique se foram aplicados filtros no maior número de campos possíveis.";
    if (!this.chkPreVisualizacao.Checked)
    {
      this.preencherBarraStatusPrincipal(mensagem, true);
    }
    else
    {
      this.chkExportar.Checked = false;
      this.preencherBarraStatusPrincipal("");
    }
  }

  private void calcularValorCelulasSelecionadas(bool validarVazias)
  {
    double num1 = 0.0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    if (this.dgvValidacaoResultado.SelectedCells.Count > 1000000)
    {
      this.preencherBarraStatusPrincipal("Quantidade muito grande de itens selecionados... Não será possível calcular soma e média aqui...", true);
    }
    else
    {
      foreach (DataGridViewCell selectedCell in (BaseCollection) this.dgvValidacaoResultado.SelectedCells)
      {
        bool flag = double.TryParse(selectedCell.Value.ToString(), out double _);
        ++num4;
        if (flag)
        {
          num1 += double.Parse(selectedCell.Value.ToString());
          ++num3;
        }
        else
        {
          if (validarVazias)
            selectedCell.Style.BackColor = BLL.CorVermelha;
          ++num2;
        }
      }
      try
      {
        if (validarVazias && num2 > 0)
        {
          int num5 = (int) MessageBox.Show($"Foram identificadas {num2.ToString()} celulas com valores inválidos e que não puderam ser somados. Estas celulas foram pintadas de vermelho.", "TOT - Calculando seleção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        if ((num3 > 0 || num2 > 0) && num4 != 0)
          this.preencherBarraStatusPrincipal($"Soma: [{Math.Round(num1, 2).ToString()}]     Média: [{Math.Round(num1 / (double) num3, 2).ToString()}]     Contagem de células selecionadas: [{num4.ToString()}]     Células desconsideradas na soma e média: [{num2.ToString()}]");
      }
      catch (Exception ex)
      {
        BLL.erro("Erro ao calcular células.", ex.Message);
      }
    }
  }

  private void preencherBarraStatusPrincipal(string mensagem, bool alerta = false)
  {
    try
    {
      ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.Text = mensagem;
      if (alerta)
      {
        ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.ForeColor = BLL.CorAzul;
        ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.BackColor = BLL.CorAmarela;
      }
      else
      {
        ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.ForeColor = BLL.CorTransparente;
        ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.BackColor = BLL.CorTransparente;
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro atualizar a barra de status", ex.Message);
    }
  }

  private void preencherBarraStatusPrincipalEmPercentual(int valor)
  {
    try
    {
      ((frmPrincipal) this.MdiParent).statusProgressBar.Maximum = 100;
      ((frmPrincipal) this.MdiParent).statusProgressBar.Value = valor;
    }
    catch (Exception ex)
    {
      BLL.erro("Erro atualizar percentual a barra de status", ex.Message);
    }
  }

  private void dgvValidacaoResultado_SelectionChanged(object sender, EventArgs e)
  {
    if (this.dgvValidacaoResultado.SelectedCells.Count > 1)
      this.calcularValorCelulasSelecionadas(false);
    if (this.dgvValidacaoResultado.SelectedCells.Count != this.dgvValidacaoResultado.Columns.Count)
      this.ativarControlesCalculoConsolidado(false, ativarExecucao: false);
    else if (this.filtrosAplicadosExecucaoCalc())
    {
      if (this.calculoAberto(this.dgvValidacaoResultado))
        this.ativarControlesCalculoConsolidado();
      else
        this.ativarControlesCalculoConsolidado(ativarExecucao: false);
    }
  }

  private void tvwValidacaoResultado_MouseClick(object sender, MouseEventArgs e)
  {
    try
    {
      if (!e.Button.Equals((object) MouseButtons.Right))
        return;
      ContextMenuStrip propriedadesTabelas = this.cmsPropriedadesTabelas;
      Point position = Cursor.Position;
      int x = position.X;
      position = Cursor.Position;
      int y = position.Y;
      propriedadesTabelas.Show(x, y);
      if (!DAL.PegarValorParametro("HABILITAR_REMOVER_TABELAS").Equals("true"))
        this.cmsRemoverTabela.Enabled = false;
      else
        this.cmsRemoverTabela.Enabled = true;
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao recuperar os dados da base." + Environment.NewLine, ex.Message);
    }
  }

  private void cmsPropriedades_Click(object sender, EventArgs e)
  {
    try
    {
      TreeNode selectedNode = this.tvwValidacaoResultado.SelectedNode;
      string name = selectedNode.Name;
      string str1 = selectedNode.Tag.ToString();
      string text = selectedNode.Text;
      string str2 = DAL.PegarDadosTOT($"SELECT DISTINCT NM_TABELA, DS_OBS FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT WHERE UPPER(NM_TABELA) = '{name.ToUpper()}'").Rows[0]["DS_OBS"].ToString();
      int num = (int) MessageBox.Show($"BANCO:\t{str1}\n\nTABELA:\t{name}\n\nDESC.:\t{str2}", $"TOT - [ {text} ]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao consultar as propriedades da tabela/view", ex.Message);
    }
  }

  private void cmsCopiarNomeTabela_Click(object sender, EventArgs e)
  {
    try
    {
      BLL.copiarParaAreaDeTransferencia(this.tvwValidacaoResultado.SelectedNode.Name);
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar copiar o nome da tabela/view", ex.Message);
    }
  }

  private void dgvFiltrosValidacaoResultado_Sorted(object sender, EventArgs e)
  {
    int num = (int) MessageBox.Show("Você reclassificou a ordem dos campos. Essa ordem é utilizada para geração da tabela com os resultados da consulta, ou seja, sua consulta pode sair com os dados em uma ordem não esperada.\n\nCaso deseje restaurar a ordem original, execute um duplo clique sobre o nome da tabela (você perderá seus filtros)", "TOT - Aviso de reordenação de campos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
  }

  private void exportarResultado(string delimitador)
  {
    try
    {
      using (SaveFileDialog saveFileDialog = new SaveFileDialog())
      {
        saveFileDialog.Filter = "Exportação dados TOT (*.csv)|*.csv";
        int num = (int) saveFileDialog.ShowDialog();
        string fileName = saveFileDialog.FileName;
        StreamWriter streamWriter = new StreamWriter((Stream) new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8);
        DataGridView validacaoResultado = this.dgvValidacaoResultado;
        for (int index = 0; index < validacaoResultado.Columns.Count; ++index)
        {
          if (validacaoResultado.Columns[index].Visible)
          {
            streamWriter.Write(validacaoResultado.Columns[index].HeaderText);
            if (index != validacaoResultado.Columns.Count)
              streamWriter.Write(delimitador);
          }
        }
        streamWriter.Write(streamWriter.NewLine);
        foreach (DataGridViewRow row in (IEnumerable) validacaoResultado.Rows)
        {
          for (int index = 0; index < validacaoResultado.Columns.Count; ++index)
          {
            streamWriter.Write(row.Cells[index].Value);
            if (index != validacaoResultado.Columns.Count)
              streamWriter.Write(delimitador);
          }
          streamWriter.Write(streamWriter.NewLine);
        }
        streamWriter.Flush();
        streamWriter.Close();
        this.preencherBarraStatusPrincipal("Arquivo salvo em " + fileName);
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao exportar o resultado para arquivo.\n\nCaso esteja com o arquivo aberto, feche-o e tente novamente.\n\nAté que este erro seja identificado e corrigido, utilize o recurso de copiar e colar.", "\n\n" + ex.Message);
    }
  }

  private void cmsExportarResultadoPontoVirgula_Click(object sender, EventArgs e)
  {
    this.exportarResultado(";");
  }

  private void cmsExportarResultadoPipe_Click(object sender, EventArgs e)
  {
    this.exportarResultado("|");
  }

  private void cmsAtualizarListaTabelas_Click(object sender, EventArgs e)
  {
    this.popularTreeviewValidacaoResultado2();
  }

  private void oDateTimePicker_CloseUp(object sender, EventArgs e)
  {
    this.oDateTimePicker.Visible = false;
  }

  private void dateTimePicker_OnTextChange(object sender, EventArgs e)
  {
    try
    {
      this.dgvValidacaoResultado.BeginEdit(true);
      this.dgvValidacaoResultado.CurrentCell.Value = (object) this.oDateTimePicker.Text.ToString();
      this.dgvValidacaoResultado.BeginEdit(false);
    }
    catch (Exception ex)
    {
      BLL.erro("Falha ao pegar os dados do calendário.", ex.Message);
    }
  }

  private void dgvValidacaoResultado_CellClick(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      if (this.dgvValidacaoResultado.CurrentCell != null)
      {
        BLL.celulaAtual = this.dgvValidacaoResultado.CurrentCell.OwningColumn.Name;
        string celulaAtual = BLL.celulaAtual;
        if (!this.dgvValidacaoResultado.ReadOnly)
          this.listaCombo(DAL._tabelaAtual, BLL.celulaAtual, this.cmbItensDataGrid.ComboBox);
      }
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      string str = validacaoResultado.Columns[validacaoResultado.CurrentCell.ColumnIndex].ValueType.ToString();
      if ((validacaoResultado.CurrentCell.Value is DateTime || str.Equals("System.DateTime")) && !validacaoResultado.ReadOnly && validacaoResultado.SortedColumn == null)
      {
        validacaoResultado.Controls.Add((Control) this.oDateTimePicker);
        this.oDateTimePicker.Format = DateTimePickerFormat.Short;
        Rectangle displayRectangle = validacaoResultado.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
        this.oDateTimePicker.Size = new Size(displayRectangle.Width, displayRectangle.Height);
        this.oDateTimePicker.Location = new Point(displayRectangle.X, displayRectangle.Y);
        this.oDateTimePicker.Value = !(validacaoResultado.CurrentCell.Value is DateTime) ? DateTime.Now : DateTime.ParseExact(validacaoResultado.CurrentCell.Value.ToString(), "dd/MM/yyyy hh:mm:ss", (IFormatProvider) CultureInfo.InvariantCulture);
        this.oDateTimePicker.CloseUp += new EventHandler(this.oDateTimePicker_CloseUp);
        this.oDateTimePicker.TextChanged += new EventHandler(this.dateTimePicker_OnTextChange);
        validacaoResultado.CurrentCellChanged += new EventHandler(this.oDateTimePicker_CloseUp);
        this.oDateTimePicker.Visible = true;
      }
      else
        this.preencherBarraStatusPrincipal("O calendário assintente não executa quando existem colunas reclassificadas...");
    }
    catch (Exception ex)
    {
      this.oDateTimePicker.Visible = false;
      BLL.erro("Não foi possível verificar se a coluna tem formato de data.", ex.Message);
    }
  }

  private void cmsOcultarColuna_Click(object sender, EventArgs e)
  {
    try
    {
      string celulaAtual = BLL.celulaAtual;
      if (string.IsNullOrWhiteSpace(celulaAtual))
        return;
      DataGridView validacaoResultado1 = this.dgvValidacaoResultado;
      DataGridView validacaoResultado2 = this.dgvFiltrosValidacaoResultado;
      validacaoResultado1.Columns[celulaAtual].Visible = false;
      for (int index = 0; index < validacaoResultado2.Rows.Count; ++index)
      {
        if (validacaoResultado2.Rows[index].Cells[0].Value.Equals((object) celulaAtual))
          validacaoResultado2.Rows[index].Cells[3].Value = (object) false;
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao ocultar coluna.", ex.Message);
    }
  }

  private void cmsReexibirColunas_Click(object sender, EventArgs e)
  {
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    int num = 0;
    foreach (DataGridViewColumn column in (BaseCollection) validacaoResultado.Columns)
    {
      if (!column.Visible)
      {
        column.Visible = true;
        ++num;
      }
    }
    this.preencherBarraStatusPrincipal("Total de colunas reexibidas: " + num.ToString());
  }

  private void dgvValidacaoResultado_ColumnHeaderMouseClick(
    object sender,
    DataGridViewCellMouseEventArgs e)
  {
    if (!e.Button.Equals((object) MouseButtons.Right))
      return;
    DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
    this.cmsCmbOperadores.SelectedIndex = 0;
    this.cmsTextoFiltrar.Text = "";
    this.cmsFiltroCabecalhoValidacaoResultado.Show(Cursor.Position.X, Cursor.Position.Y);
    this.cmsColunaFiltrada.Text = this.dgvValidacaoResultado.Columns[e.ColumnIndex].HeaderText;
    for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
    {
      if (this.cmsColunaFiltrada.Text.ToString().Equals(validacaoResultado.Rows[index].Cells[0].Value.ToString()) && !string.IsNullOrWhiteSpace(validacaoResultado.Rows[index].Cells[1].Value.ToString()))
      {
        this.cmsCmbOperadores.Text = validacaoResultado.Rows[index].Cells[1].Value.ToString();
        this.cmsTextoFiltrar.Text = validacaoResultado.Rows[index].Cells[2].Value.ToString();
        break;
      }
    }
    this.cmsTextoFiltrar.Focus();
  }

  private void cmsAdicionarFiltros_Click(object sender, EventArgs e)
  {
    DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
    for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
    {
      if (this.cmsColunaFiltrada.Text.Equals(validacaoResultado.Rows[index].Cells[0].Value.ToString(), StringComparison.OrdinalIgnoreCase))
      {
        validacaoResultado.Rows[index].Cells[1].Value = (object) this.cmsCmbOperadores.Text;
        validacaoResultado.Rows[index].Cells[2].Value = (object) this.cmsTextoFiltrar.Text;
        validacaoResultado.Rows[index].DefaultCellStyle.BackColor = BLL.CorAmarela;
        validacaoResultado.FirstDisplayedScrollingRowIndex = index;
        break;
      }
    }
  }

  private void cmsExpandirBancos_Click(object sender, EventArgs e)
  {
    this.tvwValidacaoResultado.ExpandAll();
  }

  private void cmsContrairBancos_Click(object sender, EventArgs e)
  {
    this.tvwValidacaoResultado.CollapseAll();
  }

  private void formatarTvwBasesConsulta(TreeView tvw)
  {
    foreach (TreeNode node1 in tvw.Nodes)
    {
      node1.ImageIndex = 11;
      node1.SelectedImageIndex = 11;
      foreach (TreeNode node2 in node1.Nodes)
      {
        node2.BackColor = BLL.CorTransparente;
        if (node2.Text.IndexOf("Bruta") > -1)
        {
          node2.ImageIndex = 18;
          node2.SelectedImageIndex = 18;
        }
        if (node2.Text.IndexOf("Cadastros") > -1)
        {
          node2.ImageIndex = 36;
          node2.SelectedImageIndex = 36;
        }
        if (node2.Text.IndexOf("Resulta") > -1)
        {
          node2.ImageIndex = 12;
          node2.SelectedImageIndex = 12;
        }
        if (node2.Text.IndexOf("Perso") > -1)
        {
          node2.ImageIndex = 19;
          node2.SelectedImageIndex = 19;
        }
        if (node2.Text.IndexOf("Apoio") > -1)
        {
          node2.ImageIndex = 20;
          node2.SelectedImageIndex = 20;
        }
        if (node2.Text.IndexOf("Script") > -1)
        {
          node2.ImageIndex = 28;
          node2.SelectedImageIndex = 28;
        }
        if (node2.Text.IndexOf("Meus favoritos") > -1)
        {
          node2.ImageIndex = 29;
          node2.SelectedImageIndex = 29;
        }
      }
    }
  }

  private void cmsFundoVerde_Click(object sender, EventArgs e)
  {
    this.dgvValidacaoResultado.CurrentCell.Style.BackColor = BLL.CorVerde;
  }

  private void cmsFundoAmarelo_Click(object sender, EventArgs e)
  {
    this.dgvValidacaoResultado.CurrentCell.Style.BackColor = BLL.CorAmarela;
  }

  private void cmsFundoVermelho_Click(object sender, EventArgs e)
  {
    this.dgvValidacaoResultado.CurrentCell.Style.BackColor = BLL.CorVermelha;
  }

  private void cmsFundoBranco_Click(object sender, EventArgs e)
  {
    this.dgvValidacaoResultado.CurrentCell.Style.BackColor = BLL.CorBranca;
  }

  private void SalvarConsulta()
  {
    try
    {
      SaveFileDialog sfdSalvarArquivos = this.sfdSalvarArquivos;
      sfdSalvarArquivos.Filter = "Arquivo de consulta TOT (*.tot)|*.tot";
      sfdSalvarArquivos.Title = "TOT - Salvar meus filtros para a tabela " + DAL._tabelaAtual;
      sfdSalvarArquivos.FileName = $"{DAL._tabelaAtual} [{DateTime.Now.ToString("yyyy-MM-dd")}]";
      int num = (int) sfdSalvarArquivos.ShowDialog();
      StreamWriter streamWriter = new StreamWriter(sfdSalvarArquivos.FileName);
      DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
      foreach (DataGridViewRow row in (IEnumerable) validacaoResultado.Rows)
      {
        for (int index = 0; index < validacaoResultado.Columns.Count; ++index)
        {
          streamWriter.Write(row.Cells[index].Value);
          if (index != validacaoResultado.Columns.Count)
            streamWriter.Write("|");
        }
        streamWriter.Write(streamWriter.NewLine);
      }
      streamWriter.Flush();
      streamWriter.Close();
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao exportar o resultado para arquivo.\n\nCaso esteja com o arquivo aberto, feche-o e tente novamente.\n\nAté que este erro seja identificado e corrigido, utilize o recurso de copiar e colar.", "\n\n" + ex.Message);
    }
  }

  private void dgvValidacaoResultado_DataBindingComplete(
    object sender,
    DataGridViewBindingCompleteEventArgs e)
  {
    this.informarQuantidadeLinhasEncontradas();
    string tabelaAtual = DAL._tabelaAtual;
    try
    {
      DataGridView validacaoResultado1 = this.dgvValidacaoResultado;
      DataGridView dataGridView1 = new DataGridView();
      if (validacaoResultado1.Rows.Count > 0)
      {
        DateTime today = DateTime.Today;
        Decimal result1 = 0.0M;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        string str1 = tabelaAtual;
        if (str1 != null)
        {
          switch (str1.Length)
          {
            case 25:
              if (str1 == "GVDW_B2B.TB_VALIDACAO_SQL")
              {
                for (int index = 0; index < this.cmsValidacaoResultado.Items.Count; ++index)
                {
                  if (this.cmsValidacaoResultado.Items[index].Text.Equals("VALIDAÇÃO: Gerar relatório HTML"))
                    this.cmsValidacaoResultado.Items.Remove(this.cmsValidacaoResultado.Items[index]);
                }
                validacaoResultado1.RowHeadersVisible = true;
                this.cmsValidacaoResultado.Items.Add("VALIDAÇÃO: Gerar relatório HTML").Click += new EventHandler(this.item2_Click);
                goto label_133;
              }
              break;
            case 28:
              if (str1 == "GVDW_OWNER.RV_B2B_CALENDARIO")
              {
                for (int index = 0; index < validacaoResultado1.Rows.Count; ++index)
                {
                  string s1 = validacaoResultado1.Rows[index].Cells["DATA_PREVISTA"].Value.ToString();
                  string s2 = validacaoResultado1.Rows[index].Cells["DATA_REALIZADA"].Value.ToString();
                  if (validacaoResultado1.Rows[index].Cells["ATIVIDADE"].Value.ToString().Substring(0, 1) == "*")
                  {
                    validacaoResultado1.Rows[index].Cells["ATIVIDADE"].Style.ForeColor = Color.Red;
                    validacaoResultado1.Rows[index].Cells["ATIVIDADE"].Style.Font = new Font(Control.DefaultFont, FontStyle.Bold);
                  }
                  if (s1 != "" && s2 == "")
                    validacaoResultado1.Rows[index].Cells["DATA_REALIZADA"].Style.BackColor = BLL.CorAmarela;
                  DateTime result2;
                  if (DateTime.TryParse(s1, out result2))
                  {
                    if (today > result2 && s2 == "")
                      validacaoResultado1.Rows[index].Cells["DATA_PREVISTA"].Style.BackColor = BLL.CorVermelha;
                    DateTime result3;
                    if (DateTime.TryParse(s2, out result3))
                    {
                      if (result3 <= result2)
                      {
                        validacaoResultado1.Rows[index].Cells["DATA_PREVISTA"].Style.BackColor = BLL.CorVerde;
                        validacaoResultado1.Rows[index].Cells["DATA_REALIZADA"].Style.BackColor = BLL.CorTransparente;
                      }
                      if (result3 > result2)
                        validacaoResultado1.Rows[index].Cells["DATA_PREVISTA"].Style.BackColor = BLL.CorAmarela;
                    }
                  }
                }
                goto label_133;
              }
              break;
            case 31 /*0x1F*/:
              if (str1 == "GVDW_OWNER.RV_B2B_ORDEM_PROCESS")
              {
                this.ativarControlesCalculoDetalhado();
                DataGridView validacaoResultado2 = this.dgvValidacaoResultado;
                if (this.chkOrdenarProcessos.Checked)
                {
                  validacaoResultado2.Sort(this.dgvValidacaoResultado.Columns["NUM_ORDEM"], ListSortDirection.Ascending);
                  validacaoResultado2.Columns["NUM_ORDEM"].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }
                for (int index = 0; index < validacaoResultado2.Rows.Count; ++index)
                {
                  string str2 = validacaoResultado2.Rows[index].Cells["DESCRICAO_BLOQUEIO"].Value.ToString();
                  string str3 = validacaoResultado2.Rows[index].Cells["DESCRICAO_ERRO"].Value.ToString();
                  if (!string.IsNullOrEmpty(str2))
                    validacaoResultado2.Rows[index].Cells["ID"].Style.BackColor = BLL.CorAmarela;
                  if (!string.IsNullOrEmpty(str3))
                  {
                    validacaoResultado2.Rows[index].Cells["ID"].Style.BackColor = BLL.CorVermelha;
                    validacaoResultado2.Rows[index].Cells["ID"].Style.ForeColor = BLL.CorBranca;
                  }
                }
                goto label_133;
              }
              break;
            case 33:
              if (str1 == "GVDW_OWNER.VW_RV_B2B_DATAQUALITY3")
              {
                this.ativarControlesDataQuality();
                Color color = Color.White;
                for (int index = 0; index < validacaoResultado1.Rows.Count; ++index)
                {
                  string str4 = validacaoResultado1.Rows[index].Cells["INSUMO"].Value.ToString();
                  if (index > 0 && !validacaoResultado1.Rows[index - 1].Cells["INSUMO"].Value.ToString().Equals(str4))
                    color = !color.Equals((object) BLL.CorAmareloClaro) ? BLL.CorAmareloClaro : Color.White;
                  validacaoResultado1.Rows[index].DefaultCellStyle.BackColor = color;
                  switch (validacaoResultado1.Rows[index].Cells["FAIXA"].Value.ToString())
                  {
                    case "0 - 5%":
                      validacaoResultado1.Rows[index].Cells["FAIXA"].Style.BackColor = BLL.CorCinzaClaro;
                      break;
                    case "5 - 10%":
                      validacaoResultado1.Rows[index].Cells["FAIXA"].Style.BackColor = BLL.CorVerde;
                      break;
                    case "10 - 15%":
                      validacaoResultado1.Rows[index].Cells["FAIXA"].Style.BackColor = BLL.CorAmarela;
                      break;
                    case "15 - 20%":
                      validacaoResultado1.Rows[index].Cells["FAIXA"].Style.BackColor = BLL.CorLaranja;
                      break;
                    case "20 - 25%":
                      validacaoResultado1.Rows[index].Cells["FAIXA"].Style.BackColor = BLL.CorVermelha;
                      break;
                    case "> 25%":
                      validacaoResultado1.Rows[index].Cells["FAIXA"].Style.BackColor = BLL.CorVermelha;
                      break;
                  }
                  Decimal result4;
                  validacaoResultado1.Rows[index].Cells["VARIACAO"].Style.ForeColor = !Decimal.TryParse(validacaoResultado1.Rows[index].Cells["VARIACAO"].Value.ToString(), out result4) ? BLL.CorTransparente : (!(result4 < 0M) ? BLL.CorTransparente : BLL.CorVermelha);
                }
                goto label_133;
              }
              break;
            case 34:
              if (str1 == "GVDW_OWNER.RV_B2B_EXTRATO_JUR_EXEC")
              {
                for (int index = 0; index < this.cmsValidacaoResultado.Items.Count; ++index)
                {
                  if (this.cmsValidacaoResultado.Items[index].Text.Equals("Gerar extratos"))
                    this.cmsValidacaoResultado.Items.Remove(this.cmsValidacaoResultado.Items[index]);
                }
                validacaoResultado1.RowHeadersVisible = true;
                this.cmsValidacaoResultado.Items.Add("Gerar extratos").Click += new EventHandler(this.item_Click);
                goto label_133;
              }
              break;
            case 35:
              if (str1 == "GVDW_OWNER.RV_B2B_CONTROLE_DEMANDAS")
              {
                if (!this.chkDesativarFormatacao.Checked)
                {
                  for (int index = 0; index < validacaoResultado1.Rows.Count; ++index)
                  {
                    string str5 = validacaoResultado1.Rows[index].Cells["STATUS"].Value.ToString();
                    validacaoResultado1.Rows[index].Cells["EVIDENCIAS_HOMOLOG"].Style.ForeColor = BLL.CorAzul;
                    switch (str5)
                    {
                      case "CONCLUÍDO":
                        validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorVerde;
                        validacaoResultado1.Rows[index].Cells["ID"].Style.BackColor = BLL.CorVerde;
                        ++num1;
                        break;
                      case "CONCLUIDO":
                        validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorVerde;
                        validacaoResultado1.Rows[index].Cells["ID"].Style.BackColor = BLL.CorVerde;
                        ++num1;
                        break;
                      case "EM ANDAMENTO":
                        validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorAmarela;
                        validacaoResultado1.Rows[index].Cells["ID"].Style.BackColor = BLL.CorAmarela;
                        ++num3;
                        break;
                      case "PENDENTE":
                        validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorVermelha;
                        validacaoResultado1.Rows[index].Cells["ID"].Style.BackColor = BLL.CorVermelha;
                        ++num2;
                        break;
                      default:
                        validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorTransparente;
                        validacaoResultado1.Rows[index].Cells["ID"].Style.BackColor = BLL.CorTransparente;
                        break;
                    }
                    string s3 = validacaoResultado1.Rows[index].Cells["DATA_LIMITE"].Value.ToString();
                    string s4 = validacaoResultado1.Rows[index].Cells["DATA_CONCLUSAO"].Value.ToString();
                    if (s3 != "" && s4 == "")
                      validacaoResultado1.Rows[index].Cells["DATA_CONCLUSAO"].Style.BackColor = BLL.CorAmarela;
                    DateTime result5;
                    if (DateTime.TryParse(s3, out result5))
                    {
                      if (today > result5 && s4 == "")
                        validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorVermelha;
                      DateTime result6;
                      if (DateTime.TryParse(s4, out result6))
                      {
                        if (result6 <= result5)
                        {
                          validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorVerde;
                          validacaoResultado1.Rows[index].Cells["DATA_CONCLUSAO"].Style.BackColor = BLL.CorTransparente;
                        }
                        if (result6 > result5)
                          validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorAmarela;
                      }
                    }
                  }
                }
                this.preencherBarraStatusPrincipal($"Resultado da pesquisa:  CONCLUÍDOS: {num1.ToString()} - EM ANDAMENTO: {num3.ToString()} - PENDENTES: {num2.ToString()}");
                goto label_133;
              }
              break;
            case 36:
              if (str1 == "GVDW_OWNER.RV_B2B_CRONOGRAMA_INSUMOS")
              {
                if (!this.chkDesativarFormatacao.Checked)
                {
                  for (int index = 0; index < validacaoResultado1.Rows.Count; ++index)
                  {
                    string s5 = validacaoResultado1.Rows[index].Cells["DATA_PREVISTA"].Value.ToString();
                    string s6 = validacaoResultado1.Rows[index].Cells["DATA_RECEBIMENTO"].Value.ToString();
                    if (validacaoResultado1.Rows[index].Cells["VOLUMETRIA"].Value.ToString().Trim().Length < 1)
                    {
                      validacaoResultado1.Rows[index].Cells["PERIODO"].Style.ForeColor = BLL.CorVermelha;
                      validacaoResultado1.Rows[index].Cells["PERIODO"].Style.Font = new Font(Control.DefaultFont, FontStyle.Bold);
                    }
                    else
                    {
                      Color color = validacaoResultado1.Rows[index].DefaultCellStyle.BackColor;
                      if (Decimal.TryParse(validacaoResultado1.Rows[index].Cells["VARIACAO_VOLUMETRIA"].Value.ToString(), out result1))
                      {
                        if (result1 >= -10M && result1 <= 10M)
                          color = BLL.CorVerde;
                        else if (result1 > -15M && result1 < -10M || result1 > 10M && result1 < 15M)
                          color = BLL.CorAmarela;
                        else if (result1 <= -15M || result1 >= 15M)
                          color = BLL.CorVermelha;
                        validacaoResultado1.Rows[index].Cells["INSUMO"].Style.BackColor = color;
                      }
                    }
                    if (s5 != "" && s6 == "")
                      validacaoResultado1.Rows[index].Cells["DATA_RECEBIMENTO"].Style.BackColor = BLL.CorAmarela;
                    DateTime result7;
                    if (DateTime.TryParse(s5, out result7))
                    {
                      if (today > result7 && s6 == "")
                        validacaoResultado1.Rows[index].Cells["DATA_PREVISTA"].Style.BackColor = BLL.CorVermelha;
                      DateTime result8;
                      if (DateTime.TryParse(s6, out result8))
                      {
                        if (result8 <= result7)
                        {
                          validacaoResultado1.Rows[index].Cells["DATA_PREVISTA"].Style.BackColor = BLL.CorVerde;
                          validacaoResultado1.Rows[index].Cells["DATA_RECEBIMENTO"].Style.BackColor = BLL.CorTransparente;
                        }
                        if (result8 > result7)
                          validacaoResultado1.Rows[index].Cells["DATA_PREVISTA"].Style.BackColor = BLL.CorAmarela;
                      }
                    }
                  }
                  goto label_133;
                }
                goto label_133;
              }
              break;
            case 39:
              if (str1 == "GVDW_OWNER.RV_B2B_VALIDA_RESULT_CHKLST2")
              {
                for (int index = 0; index < validacaoResultado1.Rows.Count; ++index)
                {
                  string str6 = validacaoResultado1.Rows[index].Cells["STATUS"].Value.ToString();
                  if (validacaoResultado1.Rows[index].Cells["ITEM"].Value.ToString().Length > 0)
                  {
                    if (validacaoResultado1.Rows[index].Cells["ITEM"].Value.ToString().Substring(0, 1) == "*")
                    {
                      validacaoResultado1.Rows[index].Cells["ITEM"].Style.ForeColor = Color.Red;
                      validacaoResultado1.Rows[index].Cells["ITEM"].Style.Font = new Font(Control.DefaultFont, FontStyle.Bold);
                    }
                    if (str6.Equals("1"))
                    {
                      validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorVerde;
                      validacaoResultado1.Rows[index].Cells["STATUS"].Style.ForeColor = BLL.CorVerde;
                      ++num1;
                    }
                    else
                    {
                      validacaoResultado1.Rows[index].Cells["STATUS"].Style.BackColor = BLL.CorVermelha;
                      validacaoResultado1.Rows[index].Cells["STATUS"].Style.ForeColor = BLL.CorVermelha;
                      ++num2;
                    }
                  }
                }
                this.preencherBarraStatusPrincipal($"Resultado da pesquisa:  NÃO OK = {num2.ToString()}  -  OK = {num1.ToString()}");
                goto label_133;
              }
              break;
            case 40:
              if (str1 == "GVDW_OWNER.RV_B2B_PARAMETROS_DATAQUALITY")
              {
                validacaoResultado1.RowHeadersVisible = true;
                for (int index = 0; index < validacaoResultado1.Rows.Count; ++index)
                {
                  if (validacaoResultado1.Rows[index].Cells["ERRO_ULT_EXECUCAO"].Value.ToString().Length > 1)
                    validacaoResultado1.Rows[index].Cells["TABELA"].Style.BackColor = BLL.CorVermelha;
                }
                goto label_133;
              }
              break;
          }
        }
        try
        {
          this.ativarControlesCalculoDetalhado(false);
          this.ativarControlesDataQuality(false);
        }
        catch (Exception ex)
        {
          BLL.erro("Erro ao ativar os combos de filtro.", ex.Message);
        }
label_133:
        if (tabelaAtual.Equals("GVDW_OWNER.VW_RV_B2B_INFORMATIVO") || tabelaAtual.Equals("GVDW_B2B.VW_RESULTADO_FINAL_INFORM_TOT") || tabelaAtual.Equals("GVDW_OWNER.RV_B2B_ORDEM_PROCESS") || tabelaAtual.Equals("GVDW_OWNER.VW_RV_B2B_GERAR_INFORMATIVO") || this.dgvValidacaoResultado.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.None)
        {
          validacaoResultado1.RowHeadersVisible = true;
          this.cmsInformativos.Visible = true;
        }
      }
      if (this.txTabelaAtual.Text.Equals("GVDW_OWNER.VW_CP_ERP_CALCULOS"))
      {
        DataGridView dataGridView2 = new DataGridView();
        dataGridView2 = this.dgvFiltrosValidacaoResultado;
        this.ativarControlesCalculoConsolidado(false, ativarExecucao: false);
        this.popularCombosCalculoConsolidado();
        this.dgvValidacaoResultado.MultiSelect = false;
        DataGridView validacaoResultado3 = this.dgvValidacaoResultado;
        for (int index = 0; index < validacaoResultado3.Rows.Count; ++index)
        {
          string str = validacaoResultado3.Rows[index].Cells["Status"].Value.ToString();
          int num = int.Parse(validacaoResultado3.Rows[index].Cells["Com erros"].Value.ToString());
          validacaoResultado3.Rows[index].Cells["Status"].Style.BackColor = !str.Equals("ABERTO") ? BLL.CorTransparente : BLL.CorAmarela;
          if (num > 0)
          {
            validacaoResultado3.Rows[index].Cells["Canal"].Style.ForeColor = BLL.CorVermelha;
            validacaoResultado3.Rows[index].Cells["Com erros"].Style.BackColor = BLL.CorVermelha;
            validacaoResultado3.Rows[index].Cells["Canal"].Style.Font = new Font(Control.DefaultFont, FontStyle.Bold);
          }
          else
          {
            validacaoResultado3.Rows[index].Cells["Canal"].Style.ForeColor = BLL.CorTransparente;
            validacaoResultado3.Rows[index].Cells["Com erros"].Style.BackColor = BLL.CorTransparente;
            validacaoResultado3.Rows[index].Cells["Canal"].Style.Font = new Font(Control.DefaultFont, FontStyle.Regular);
          }
        }
      }
      else
      {
        this.ativarControlesCalculoConsolidado(false, false);
        this.dgvValidacaoResultado.MultiSelect = true;
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar formatar a tabela.", ex.Message);
    }
  }

  private void informarQuantidadeLinhasEncontradas()
  {
    int count = this.dgvValidacaoResultado.Rows.Count;
    int dataGridPrincipal = Settings.Default.NuMaxLinhasDataGridPrincipal;
    this.preencherBarraStatusPrincipal($"Total: {count} linhas encontradas. {(count.Equals(dataGridPrincipal) ? (object) "ATENÇÃO: Podem haver mais registros. Para exibir todos desmarque a opção \"Pré-Visualização\" e consulte novamente!" : (object) "")}");
  }

  private void dgvFiltrosValidacaoResultado_DataBindingComplete(
    object sender,
    DataGridViewBindingCompleteEventArgs e)
  {
    this.dgvFiltrosValidacaoResultado.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    this.dgvFiltrosValidacaoResultado.Columns[0].ReadOnly = true;
    this.dgvFiltrosValidacaoResultado.Columns[1].ReadOnly = true;
    this.dgvFiltrosValidacaoResultado.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    this.dgvFiltrosValidacaoResultado.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
  }

  private void chkExportar_CheckedChanged(object sender, EventArgs e)
  {
    if (!this.chkExportar.Checked)
      return;
    this.chkPreVisualizacao.Checked = false;
  }

  private bool tabelaEditavel(string nomeTabela = "")
  {
    if (string.IsNullOrWhiteSpace(nomeTabela))
      nomeTabela = DAL._tabelaAtual;
    try
    {
      DataTable dataTable = DAL.PegarDadosTOT($"SELECT A.ID_VALIDA_RESULT ,A.NM_TABELA ,A.NM_APELIDO ,A.DS_OBS ,A.ID_ORDEM ,A.ID_VALIDA_RESULT_GRUPO ,B.ID_VALIDA_RESULT_EDIT ,B.DS_MOTIVO_EDIT ,B.DT_ABERTURA ,B.DT_FECHAMENTO ,B.CD_LOGIN_REDE FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT A INNER JOIN GVDW_OWNER.RV_B2B_VALIDA_RESULT_EDIT B ON B.NM_TABELA = A.NM_TABELA WHERE A.NM_TABELA = '{nomeTabela}'  AND SYSDATE BETWEEN B.DT_ABERTURA AND B.DT_FECHAMENTO  AND B.DDTDATE_INSERT = (SELECT MAX(C.DDTDATE_INSERT) FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT_EDIT C WHERE C.NM_TABELA = A.NM_TABELA) ");
      if (dataTable.Rows.Count.Equals(0))
        return false;
      string[] strArray = new string[12];
      strArray[1] = dataTable.Rows[0].ItemArray[1].ToString();
      strArray[7] = dataTable.Rows[0].ItemArray[7].ToString();
      strArray[8] = dataTable.Rows[0].ItemArray[8].ToString();
      strArray[9] = dataTable.Rows[0].ItemArray[9].ToString();
      strArray[10] = dataTable.Rows[0].ItemArray[10].ToString();
      BLL.dadosEdicaoTabela = strArray;
      return true;
    }
    catch (Exception ex)
    {
      Console.Write("Erro ao chegar flag 'editar' da tabela. Erro: " + ex.Message);
      return false;
    }
  }

  private void btnPesquisarEditar_Click(object sender, EventArgs e) => this.pesquisar(true);

  private void cmsInformacoesEdicao_Click(object sender, EventArgs e)
  {
    string[] dadosEdicaoTabela = BLL.dadosEdicaoTabela;
    if (dadosEdicaoTabela != null)
    {
      if (dadosEdicaoTabela.Length == 0)
        return;
      int num = (int) MessageBox.Show($"Tabela: {dadosEdicaoTabela[1].ToString()}\n\nMotivo edição: {dadosEdicaoTabela[7].ToString()}\n\nPerído disponível para edição: \n{dadosEdicaoTabela[8].ToString()} à {dadosEdicaoTabela[9].ToString()}\nResponsável pela abertura: {dadosEdicaoTabela[10].ToString()}\n\nApós este período a tabela será bloqueada novamente e somento o Gestor poderá desbloqueá-la.", "TOT - Edição de dados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    else
    {
      int num1 = (int) MessageBox.Show("Sem informações", "TOT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
  }

  private void cmsHabilitarEdicao_Click(object sender, EventArgs e)
  {
    int num1 = 0;
    DataTable dataTable = DAL.PegarDadosTOT($"SELECT 1 USUARIO_HABILITADO FROM GVDW_OWNER.RV_B2B_USUARIOS_APP A WHERE UPPER(A.CD_LOGIN_REDE) = '{Globals._loginRedeUsuario.ToUpper()}' AND A.ID_PERFIL = 0 AND A.FL_ATIVO = 1 AND EXISTS (SELECT 1 FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT B WHERE B.NM_TABELA = '{DAL._tabelaAtual}' /*AND B.ID_ORDEM in (1,2,3,8,9,10,11)*/) ");
    if (dataTable != null)
      num1 = dataTable.Rows.Count;
    if (num1 > 0)
    {
      Form form = (Form) new frmHabilitarEdicao();
      form.StartPosition = FormStartPosition.CenterScreen;
      int num2 = (int) form.ShowDialog();
    }
    else
      BLL.erro("Você não tem autorização para habilitar a edição de dados.\n", "Usuário sem perfil de administrador.");
  }

  private void tvwValidacaoResultado_Click(object sender, EventArgs e)
  {
    TreeNode selectedNode = this.tvwValidacaoResultado.SelectedNode;
    if (selectedNode == null)
      return;
    if (selectedNode.Level != 2)
    {
      this.cmsHabilitarEdicao.Enabled = false;
    }
    else
    {
      this.cmsHabilitarEdicao.Enabled = true;
      DAL._tabelaAtual = selectedNode.Name.ToString();
    }
  }

  private void CarregarArquivo()
  {
    if (!this.tabelaEditavel())
    {
      BLL.erro("Esta tabela está bloqueada para edição.\nPeça liberação para seu gestor.\n", "Tabela bloqueada para edição pelo Gestor da área.");
    }
    else
    {
      MessageBox.Show("Antes de selecionar um arquivo, verifique os seguintes pontos:\n\n- O layout do arquivo deve ser idêntico ao layout da tabela que receberá seus dados;\n- Após feita a carga, não será possível reverter os dados pelo TOT;\n- O delimitardo selecionado no TOT deve ser o mesmo utilizado no arquivo", "TOT - Verifique antes de prosseguir...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      OpenFileDialog ofdAcessarArquivos = this.ofdAcessarArquivos;
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      string str1 = "";
      string str2 = "";
      string str3 = "";
      ofdAcessarArquivos.Filter = "Base para carregar no TOT (*.CSV)|*.csv|Excel (*.xlsx)|*.xlsx";
      if (ofdAcessarArquivos.ShowDialog() == DialogResult.OK)
      {
        try
        {
          DataTable dataTable1 = new DataTable();
          int num1 = 0;
          int num2 = 0;
          string extension = Path.GetExtension(ofdAcessarArquivos.FileName);
          if (extension.Equals(".csv"))
          {
            string[] strArray = File.ReadAllLines(ofdAcessarArquivos.FileName, Encoding.GetEncoding(1252));
            for (int index1 = 0; index1 < strArray.Length; ++index1)
            {
              string[] source = strArray[index1].Split(';');
              if (index1.Equals(0))
              {
                for (int index2 = 0; index2 < ((IEnumerable<string>) source).Count<string>(); ++index2)
                {
                  dataTable1.Columns.Add(source[index2]);
                  str3 = $"{str3}{source[index2].ToString()},";
                  ++num1;
                }
                str3 = str3.Substring(0, str3.Length - 1);
              }
              else
              {
                ++num2;
                if (source.Length > num1)
                  BLL.erro($"Não consigo continuar, identifiquei que da {index1.ToString()}ª linha gerou mais colunas que o esperado.\nEsse tipo de erro geralmente ocorre quando temos um ';' no texto da coluna que será carregada e, como o sistema usa o 'ponto e vírgula' para separar as colunas, vai entender que se trata de um delimitador.\n\nPara corrigir, verifique se na linha {index1.ToString()} existe um ; no conteúdo do texto, remova ele e tente carregar novamente.\n\nTexto da linha {index1.ToString()}: \n\n{strArray[index1].ToString()}");
                dataTable1.Rows.Add((object[]) source);
              }
            }
          }
          if (extension.Equals(".xlsx"))
            dataTable1 = this.importarPlanilha(ofdAcessarArquivos.FileName);
          string str4 = $"INSERT INTO {DAL._tabelaAtual} ({str3}) ";
          validacaoResultado.DataSource = (object) dataTable1;
          for (int index = 0; index < dataTable1.Rows.Count; ++index)
          {
            for (int columnIndex = 0; columnIndex < dataTable1.Columns.Count; ++columnIndex)
              str1 = $"{str1}'{dataTable1.Rows[index][columnIndex].ToString()}',";
            str2 = $"{str2} SELECT {str1.Substring(0, str1.Length - 1)} FROM DUAL UNION ALL ";
            str1 = "";
          }
          DataTable dataTable2 = DAL.PegarDadosTOT(str4 + str2.Substring(0, str2.Length - 10), alteracao: true);
          DataColumnCollection columns = dataTable2.Columns;
          if (dataTable2 == null)
            BLL.erro("ERRO ao tentar inserir:\n\nNão foi possível carregar o arquivo. Verifique se as colunas e dados do arquivo estão aderentes ao formato da tabela do Oracle");
          if (columns.Contains("errotot"))
          {
            BLL.erro("ERRO ao tentar inserir:\n\nNão foi possível carregar o arquivo. Verifique se as colunas e dados do arquivo estão aderentes ao formato da tabela do Oracle", dataTable2.Rows[0][0].ToString());
          }
          else
          {
            int num3 = (int) MessageBox.Show("Dados carregados", "TOT - Carga manual de dados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.atuarSobreDemandasNovas();
          }
        }
        catch (Exception ex)
        {
          BLL.erro("Não foi possível carregar o arquivo. Verifique as colunas e dados do arquivo estão aderentes ao formato da tabela do Oracle.", ex.Message);
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Carregamento de arquivo cancelado.", "TOT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }
  }

  private void cmsCarregarDados_Click(object sender, EventArgs e) => this.CarregarArquivo();

  private void btnExcluir_Click(object sender, EventArgs e) => this.excluirLinhas();

  private void excluirLinhas()
  {
    if (!this.tabelaEditavel())
    {
      BLL.erro("Esta tabela está bloqueada para edição.\nPeça liberação para seu gestor.\n", "Tabela bloqueada para edição pelo Gestor da área.");
    }
    else
    {
      string str1 = "";
      foreach (DataGridViewRow row in (IEnumerable) this.dgvFiltrosValidacaoResultado.Rows)
      {
        string valorSQL = row.Cells[2].Value.ToString().Trim().Replace("'", "");
        string str2 = row.Cells[0].Value.ToString();
        string operadorSQL = row.Cells[1].Value.ToString();
        row.Cells[3].Value.ToString();
        if (!string.IsNullOrWhiteSpace(valorSQL) && string.IsNullOrWhiteSpace(operadorSQL))
        {
          BLL.erro($"Você está filtrando o campo {str2} com o valor {valorSQL} mas faltou definir o operador (exemplo: Igual, Diferente, Maior...)");
          return;
        }
        if (!string.IsNullOrWhiteSpace(operadorSQL))
          str1 = $"{str1} AND A.\"{str2}\"{this.ajustarOperadorSQL(operadorSQL, valorSQL)}";
      }
      if (MessageBox.Show($"ATENÇÃO usuário {Globals._loginRedeUsuario.ToUpper()}:\n\nVocê está prestes a excluir todos os registros da tabela [{DAL._tabelaAtual}]\n\nque atendam ao filtro: {str1.Substring(5, str1.Length - 5)}\n\nEsta ação NÃO poderá ser desfeita!\n\nTem absoluta certeza que deseja continuar?", "TOT - Excluir registros do banco", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
      {
        string str3 = "";
        int num1 = 6;
        if (BLL.InputBox("TOT", "Informe o motivo da exclusão:", ref str3) == DialogResult.OK)
        {
          if (str3.Trim().Length < num1)
          {
            BLL.erro($"O motivo deve ter ao menos {num1.ToString()} caracteres.\n", "É obrigatório informar um motivo");
          }
          else
          {
            string consulta = $"DELETE FROM {DAL._tabelaAtual} A WHERE {str1.Substring(5, str1.Length - 5)}".Replace("not in ('')", "is not null").Replace("in ('')", "is null");
            DataTable dataTable = DAL.PegarDadosTOT(consulta, alteracao: true);
            if (dataTable == null || dataTable.Rows.Count < 1)
            {
              BLL.erro("Não foi possível executar o comando de exclusão.", "Erro ao atualizar tabela");
            }
            else
            {
              try
              {
                DataColumnCollection columns = dataTable.Columns;
                if (columns.Contains("errotot"))
                  BLL.erro("Erro ao tentar excluir a tabela do TOT.", dataTable.Rows[0][0].ToString());
                else if (columns.Contains("nu_registros"))
                {
                  int num2 = (int) MessageBox.Show("Total de linha(s) excluída(s): " + dataTable.Rows[0][0].ToString(), "TOT - Exclusão de registros", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                  int num3 = (int) MessageBox.Show("Não foi obtida uma resposta do banco. Verifique manualmente se seus dados foram excluídos.", "TOT - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
              }
              catch (Exception ex)
              {
                BLL.erro("Erro ao tentar excluir: ", ex.Message);
              }
              try
              {
                if (DAL.PegarDadosTOT($"INSERT INTO GVDW_OWNER.RV_B2B_VALIDA_RESULT_EDIT_LOG\n(NM_TABELA, NM_CAMPO, VL_ANTERIOR, VL_NOVO, NM_LOGIN_USUARIO, DATA_HORA_ALTERACAO, DS_MOTIVO_ALTERACAO, DS_CONSULTA) VALUES ('{DAL._tabelaAtual}','Ação de exclusão de registros',null,null,'{Globals._loginRedeUsuario.ToUpper()}',TO_CHAR(SYSDATE, 'DD-MM-YY HH24:MI:SS'),'{str3}','{consulta.Replace("\"", "").Replace("'", "")}')", alteracao: true) == null)
                  BLL.erro("Não foi possível atualizar os dados da tabela de LOG.", "Erro ao atualizar tabela");
              }
              catch (Exception ex)
              {
                BLL.erro("Erro ao atualizar tabela de log", ex.Message);
              }
            }
          }
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Exclusão cancelada");
      }
    }
  }

  private void cmsVolumetriaTabelas_Click(object sender, EventArgs e)
  {
    this.volumetriaTabelas(DAL._tabelaAtual);
  }

  private void volumetriaTabelas(string tabela)
  {
    Form form = (Form) new frmEstatisticas();
    form.StartPosition = FormStartPosition.CenterScreen;
    int num = (int) form.ShowDialog();
  }

  private void btnEstatisticas_Click(object sender, EventArgs e)
  {
    if (!string.IsNullOrWhiteSpace(DAL._tabelaAtual))
    {
      frmEstatisticas frmEstatisticas = new frmEstatisticas();
      DAL._tabelaAtualaAux = DAL._tabelaAtual.Replace("GVDW_OWNER.", "");
      frmEstatisticas.Show();
      frmEstatisticas.MaximizeBox = true;
    }
    else
      BLL.erro("Selecione uma tabela válida antes de tentar gerar estatística");
  }

  private void cmsAdicionaTabela_Click(object sender, EventArgs e)
  {
    Form form = (Form) new frmAdicionarObjeto();
    form.StartPosition = FormStartPosition.CenterScreen;
    int num = (int) form.ShowDialog();
  }

  private void cmsRemoverTabela_Click(object sender, EventArgs e)
  {
    try
    {
      string tabelaAtual = DAL._tabelaAtual;
      if (string.IsNullOrWhiteSpace(tabelaAtual))
        BLL.erro("Parece que você ainda não selecionou uma tabela.", "Tabela não selecionada");
      else if (MessageBox.Show($"Tem certeza que deseja remover a tabela {tabelaAtual} da lista do TOT?", "TOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
      {
        DataTable dataTable = DAL.PegarDadosTOT($"delete GVDW_OWNER.RV_B2B_VALIDA_RESULT WHERE NM_TABELA = '{tabelaAtual}' ", alteracao: true);
        if (dataTable.Columns.Contains("errotot"))
        {
          BLL.erro("Erro ao tentar excluir a tabela do TOT.", dataTable.Rows[0][0].ToString());
        }
        else
        {
          int num = (int) MessageBox.Show($"Tabela  {tabelaAtual} removida com êxito.", "Remover tabela do TOT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.popularTreeviewValidacaoResultado2();
        }
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar excluir a tabela do TOT.", ex.Message);
    }
  }

  public static void CopyAndPasteFile(string filePath, string newFilePath)
  {
    try
    {
      if (!File.Exists(filePath))
        BLL.erro($"O arquivo de origem: {filePath} não foi localizado.");
      else
        File.Copy(filePath, newFilePath, true);
    }
    catch (Exception ex)
    {
      Console.WriteLine("Ocorreu um erro: " + ex.Message);
    }
  }

  private static string ToClipboardFormat(DataTable table, bool header = false)
  {
    string clipboardFormat = string.Empty;
    try
    {
      if (header)
      {
        foreach (DataColumn column in (InternalDataCollectionBase) table.Columns)
          clipboardFormat = $"{clipboardFormat}{column.ColumnName}\t";
        clipboardFormat = clipboardFormat.TrimEnd('\t') + Environment.NewLine;
      }
      foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
      {
        foreach (object obj in row.ItemArray)
          clipboardFormat = $"{clipboardFormat}{obj.ToString()}\t";
        clipboardFormat = clipboardFormat.TrimEnd('\t') + Environment.NewLine;
      }
      return clipboardFormat;
    }
    catch (Exception ex)
    {
      BLL.erro("Falha ao preparar os dados de DataTable para colar.", ex.Message);
      return "deu erro";
    }
  }

  private void DataTableParaExcel(Worksheet ws, string consultaSQL, string celula, bool cabecalho = false)
  {
    string empty = string.Empty;
    DataTable dataTable = !string.IsNullOrWhiteSpace(consultaSQL) ? DAL.PegarDadosTOT(consultaSQL) : throw new Exception($"Consulta SQL para alimentar a planilha [{ws.Name}] não foi localizada, provavelmente não está parametrizada para o respectivo indicador.\n");
    if (!dataTable.Columns.Contains("errotot"))
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Range range1 = ws.get_Range((object) celula, System.Type.Missing);
      int row = range1.Row;
      int column = range1.Column;
      int length = dataTable.Rows.Count + (cabecalho ? 1 : 0);
      int count = dataTable.Columns.Count;
      object[,] objArray = new object[length, count];
      int num = 0;
      if (cabecalho)
      {
        for (int index = 0; index < count; ++index)
          objArray[0, index] = (object) dataTable.Columns[index].ColumnName;
        num = 1;
      }
      for (int index = 0; index < dataTable.Rows.Count; ++index)
      {
        for (int columnIndex = 0; columnIndex < count; ++columnIndex)
          objArray[index + num, columnIndex] = dataTable.Rows[index][columnIndex];
      }
      // ISSUE: reference to a compiler-generated field
      if (frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Microsoft.Office.Interop.Excel.Range), typeof (frmConsultaBancos)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, Microsoft.Office.Interop.Excel.Range> target1 = frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__2.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> p2 = frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__2;
      // ISSUE: reference to a compiler-generated field
      if (frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, object, object, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, object, object, object> target2 = frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__1.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, object, object, object>> p1 = frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__1;
      // ISSUE: reference to a compiler-generated field
      if (frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__0 = CallSite<Func<CallSite, Worksheet, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Range", typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__0.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__81.\u003C\u003Ep__0, ws);
      object cell1 = ws.Cells[(object) row, (object) column];
      object cell2 = ws.Cells[(object) (row + length - 1), (object) (column + count - 1)];
      object obj2 = target2((CallSite) p1, obj1, cell1, cell2);
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Range range2 = target1((CallSite) p2, obj2);
      range2.Value2 = (object) objArray;
    }
    else
    {
      string str = dataTable.Rows[0][0].ToString();
      throw new Exception($"A consulta [{consultaSQL}] para a planilha [{ws.Name}], célula [{celula}] não retornou registros válidos. Erro: [{str}]");
    }
  }

  private string ObterValor(
    DataTable dt,
    string variavel,
    int periodo,
    string canal = null,
    string cargo = null,
    string indicador = null)
  {
    DataView dataView = new DataView(dt);
    dataView.RowFilter = $"CD_PARAMETRO = '{variavel}' AND (DS_CANAL = '{canal}' OR FL_CANAL_GERAL=1) AND {$"{periodo} >= ANO_MES_INI AND {periodo} <= ANO_MES_FIM AND "}(NM_CARGO = '{cargo}' OR FL_CARGO_GERAL=1) AND (NM_INDICADOR = '{indicador}' OR FL_INDICADOR_GERAL=1)";
    return dataView.Count > 0 ? dataView[0]["TX_VALOR"].ToString() : string.Empty;
  }

  private void InserirHyperLinkExcel(
    Worksheet sourceSheet,
    string sourceCell,
    Worksheet destinationSheet,
    string destinationCell,
    string textoParaExibir = "")
  {
    // ISSUE: reference to a compiler-generated method
    // ISSUE: variable of a compiler-generated type
    Microsoft.Office.Interop.Excel.Range Anchor = sourceSheet.get_Range((object) sourceCell, System.Type.Missing);
    string name = destinationSheet.Name;
    string SubAddress = $"'{name}'!{destinationCell}";
    if (textoParaExibir.Equals(""))
    {
      // ISSUE: reference to a compiler-generated method
      sourceSheet.Hyperlinks.Add((object) Anchor, "", (object) SubAddress, System.Type.Missing, (object) name);
    }
    else
    {
      // ISSUE: reference to a compiler-generated method
      sourceSheet.Hyperlinks.Add((object) Anchor, "", (object) SubAddress, System.Type.Missing, (object) textoParaExibir);
    }
  }

  public static string SubstituirMultiplos(
    string textoOriginal,
    Dictionary<string, string> substituicoes)
  {
    if (textoOriginal == null)
      throw new ArgumentNullException(nameof (textoOriginal));
    if (substituicoes == null)
      throw new ArgumentNullException(nameof (substituicoes));
    StringBuilder stringBuilder = new StringBuilder(textoOriginal);
    foreach (KeyValuePair<string, string> substituicoe in substituicoes)
      stringBuilder.Replace(substituicoe.Key, substituicoe.Value);
    return stringBuilder.ToString();
  }

  private void AtivarBotoesGerarInformativosExcel(bool ativar, params Control[] controles)
  {
    try
    {
      foreach (Control controle in controles)
        controle.Enabled = ativar;
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao alterar o estado dos controles de geração de informativos", ex.Message);
    }
  }

  public static string GenerateUniqueString()
  {
    return Guid.NewGuid().ToString("N").Substring(0, 32 /*0x20*/);
  }

  public static bool IsExcelRunning() => Process.GetProcessesByName("EXCEL").Length != 0;

  private void gerarInformativoExcel(int tipoGeracao = 0)
  {
    if (MessageBox.Show("ATENÇÃO\n\nPara reduzir o risco de erros na biblioteca Office,\ndurante a geração dos informativos é aconselhável fechar o Excel.\n\nVocê aceita que o TOT encerre o Excel agora e durante o processo de informativos?\n\nAntes de concordar, salve seus trabalhos abertos em Excel.", "TOT - Não use o Excel por enquanto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
    {
      this.AtivarBotoesGerarInformativosExcel(false, (Control) this.btnDivulgar, (Control) this.btnApenasGerar, (Control) this.btnEnviarParaMim, (Control) this.cmbCanalInformativo, (Control) this.cmbPeriodoInformativo, (Control) this.cmbTrimestreInformativo, (Control) this.cmbVersaoInformativo, (Control) this.cmbCargoInformativo, (Control) this.cmbCalculoInformativo);
      DateTime now1 = DateTime.Now;
      DataGridView dataGridView = new DataGridView();
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      DataTable dt = DAL.PegarDadosTOT(DAL.PegarValorParametro("P_SQL_PEGAR_PARAMETROS_GERAL"));
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      string empty6 = string.Empty;
      string str1 = "";
      string empty7 = string.Empty;
      string empty8 = string.Empty;
      string empty9 = string.Empty;
      int num1 = 0;
      Decimal num2 = 0M;
      int num3 = 0;
      string str2 = string.Empty;
      string empty10 = string.Empty;
      string empty11 = string.Empty;
      string empty12 = string.Empty;
      string caminhoArquivo1 = string.Empty;
      string empty13 = string.Empty;
      Dictionary<string, string> substituicoes = new Dictionary<string, string>();
      string str3 = now1.ToString("dd-MM-yy");
      string str4 = $"Log_informativos - {str3}.txt";
      string str5 = $"Log_informativosApenasErros - {str3}.txt";
      string str6 = $"Log_informativosApenasEnviados - {str3}.txt";
      int count1 = this.dgvValidacaoResultado.SelectedRows.Count;
      if (validacaoResultado.SelectedRows.Count > 0)
      {
        this.AppendText(this.rtbInformativos, DateTime.Now.ToShortTimeString() + " Início geração informativos...\n", BLL.CorAzul);
        for (int index1 = 0; index1 < validacaoResultado.Rows.Count; ++index1)
        {
          // ISSUE: variable of a compiler-generated type
          Workbook o = (Workbook) null;
          BLL.EnviarInformativo = true;
          validacaoResultado.Rows[index1].Cells["COLABORADOR"].Style.BackColor = BLL.CorTransparente;
          if (validacaoResultado.Rows[index1].Selected)
          {
            try
            {
              str1 = validacaoResultado.Rows[index1].Cells["COLABORADOR"].Value.ToString();
              string str7 = validacaoResultado.Rows[index1].Cells["MATRICULA"].Value.ToString();
              string str8 = validacaoResultado.Rows[index1].Cells["PERFIL"].Value.ToString();
              int int32_1 = Convert.ToInt32(validacaoResultado.Rows[index1].Cells["PERIODO"].Value.ToString());
              string str9 = validacaoResultado.Rows[index1].Cells["GERENCIA"].Value.ToString();
              string str10 = validacaoResultado.Rows[index1].Cells["CALCULO"].Value.ToString();
              string str11 = validacaoResultado.Rows[index1].Cells["ID_VERSAO"].Value.ToString();
              string canal = validacaoResultado.Rows[index1].Cells["CANAL"].Value.ToString();
              string cargo = validacaoResultado.Rows[index1].Cells["CARGO"].Value.ToString();
              string str12 = validacaoResultado.Rows[index1].Cells["TRIMESTRE"].Value.ToString();
              string str13 = validacaoResultado.Rows[index1].Cells["EMAIL"].Value.ToString();
              string str14 = this.ObterValor(dt, "P_LOCAL_PLANILHA_MODELO", int32_1, canal, cargo);
              string str15 = this.ObterValor(dt, "P_LOCAL_SALVAR_INFORMATIVOS", int32_1, canal, cargo);
              string str16 = this.ObterValor(dt, "P_NOME_PLANILHA_MODELO", int32_1, canal, cargo);
              caminhoArquivo1 = this.ObterValor(dt, "P_LOCAL_LOG", int32_1, canal, cargo) + str4;
              if (num1 == 0)
                BLL.AdicionarTextoAoArquivo(caminhoArquivo1, "Início informativos...");
              BLL.AdicionarTextoAoArquivo(caminhoArquivo1, "Início " + str1);
              this.AppendText(this.rtbInformativos, str1 + "\n", BLL.CorTransparente);
              ++num1;
              if (count1 > 0 && num1 > 0)
              {
                num2 = Math.Round((Decimal) (num1 / count1) * 100M, 0);
                this.preencherBarraStatusPrincipal($"Informativo: {num1}/{count1}: {str1}");
                System.Windows.Forms.Application.DoEvents();
              }
              frmConsultaBancos.GenerateUniqueString();
              string str17 = $"{str1}_{str10}_{int32_1.ToString()}.xlsb";
              string str18 = str15 + str17;
              if (frmConsultaBancos.IsExcelRunning())
              {
                if (!MessageBox.Show("Você ainda tem aplicações Excel em execução,\nVocê autoriza o TOT encerrar quaisquer Excel em execução?\n\nATENÇÃO\n\nPlanilhas não salvas poderão ter dados perdidos. \nSalve suas planilhas antes de continuar.", "TOT - Não use o Excel por enquanto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
                  throw new Exception("Não é possível gerar informativos enquanto todas as aplicações Excel não estejam fechadas.");
                frmConsultaBancos.EncerrarExcelEmSegundoPlano("EXCEL");
              }
              if (File.Exists(str18))
                File.Delete(str18);
              frmConsultaBancos.CopyAndPasteFile(str14 + str16, str18);
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Excel.Application instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
              instance.DisplayAlerts = false;
              instance.Visible = false;
              // ISSUE: reference to a compiler-generated method
              o = instance.Workbooks.Open(str18, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
              // ISSUE: reference to a compiler-generated field
              if (frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__0 == null)
              {
                // ISSUE: reference to a compiler-generated field
                frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, Worksheet>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Worksheet), typeof (frmConsultaBancos)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: variable of a compiler-generated type
              Worksheet ws = frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__0.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__0, o.Worksheets[(object) 1]);
              // ISSUE: variable of a compiler-generated type
              Worksheet worksheet1 = ws;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              ws.get_Range((object) this.ObterValor(dt, "P_CELULA_CAPA_MATRICULA", int32_1, canal, cargo), System.Type.Missing).set_Value(System.Type.Missing, (object) str7);
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              ws.get_Range((object) this.ObterValor(dt, "P_CELULA_CAPA_NOME_COLABORADOR", int32_1, canal, cargo), System.Type.Missing).set_Value(System.Type.Missing, (object) str1);
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              ws.get_Range((object) this.ObterValor(dt, "P_CELULA_CAPA_PERIODO", int32_1, canal, cargo), System.Type.Missing).set_Value(System.Type.Missing, (object) int32_1);
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              ws.get_Range((object) this.ObterValor(dt, "P_CELULA_CAPA_PERFIL", int32_1, canal, cargo), System.Type.Missing).set_Value(System.Type.Missing, (object) str8);
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              ws.get_Range((object) this.ObterValor(dt, "P_CELULA_CAPA_GERENCIA", int32_1, canal, cargo), System.Type.Missing).set_Value(System.Type.Missing, (object) str9);
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              ws.get_Range((object) this.ObterValor(dt, "P_CELULA_CAPA_CALCULO", int32_1, canal, cargo), System.Type.Missing).set_Value(System.Type.Missing, (object) str10);
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              ws.get_Range((object) this.ObterValor(dt, "P_CELULA_VERSAO", int32_1, canal, cargo), System.Type.Missing).set_Value(System.Type.Missing, (object) str11);
              substituicoes["{matricula}"] = str7;
              substituicoes["{perfil}"] = str8;
              substituicoes["{periodo}"] = int32_1.ToString();
              substituicoes["{gerencia}"] = str9;
              substituicoes["{calculo}"] = str10;
              substituicoes["{idVersao}"] = str11;
              substituicoes["{cargo}"] = cargo;
              substituicoes["{canal}"] = canal;
              substituicoes["{trimestre}"] = str12;
              string consultaSQL1 = frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_SQL_CAPA_PLANO_BASE", int32_1, canal, cargo), substituicoes);
              string str19 = frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_NOME_TABELA_DET_CONSOLIDADA", int32_1, canal, cargo), substituicoes);
              string str20 = frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_NOME_TABELA_DET_FATURAMENTO", int32_1, canal, cargo), substituicoes);
              string str21 = this.ObterValor(dt, "P_CELULA_CAPA_PLANO_BASE", int32_1, canal, cargo);
              this.DataTableParaExcel(ws, consultaSQL1, str21);
              string caminhoArquivo2 = caminhoArquivo1;
              DateTime now2 = DateTime.Now;
              string texto1 = now2.ToString() + " - Início P_SQL_CAPA_RESULTADO_FINAL";
              BLL.AdicionarTextoAoArquivo(caminhoArquivo2, texto1);
              string consultaSQL2 = frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_SQL_CAPA_RESULTADO_FINAL", int32_1, canal, cargo), substituicoes);
              this.DataTableParaExcel(ws, consultaSQL2, this.ObterValor(dt, "P_CELULA_CAPA_RESULTADO_FINAL", int32_1, canal, cargo));
              string caminhoArquivo3 = caminhoArquivo1;
              now2 = DateTime.Now;
              string texto2 = now2.ToString() + " - Fim P_SQL_CAPA_RESULTADO_FINAL";
              BLL.AdicionarTextoAoArquivo(caminhoArquivo3, texto2);
              string consultaSQL3 = frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_SQL_CAPA_ELEGIBILIDADE", int32_1, canal, cargo), substituicoes);
              this.DataTableParaExcel(ws, consultaSQL3, this.ObterValor(dt, "P_CELULA_CAPA_ELEGIBILIDADE", int32_1, canal, cargo));
              string consultaSQL4 = frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_SQL_CAPA_PLANO_ESTRATEGICO", int32_1, canal, cargo), substituicoes);
              string input = this.ObterValor(dt, "P_CELULA_CAPA_PLANO_ESTRATEGICO", int32_1, canal, cargo);
              this.DataTableParaExcel(ws, consultaSQL4, this.ObterValor(dt, "P_CELULA_CAPA_PLANO_ESTRATEGICO", int32_1, canal, cargo));
              string caminhoArquivo4 = caminhoArquivo1;
              now2 = DateTime.Now;
              string texto3 = now2.ToString() + " - início P_SQL_PLANO_BASE_NOMES_PLANILHAS";
              BLL.AdicionarTextoAoArquivo(caminhoArquivo4, texto3);
              DataTable dataTable = DAL.PegarDadosTOT(frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_SQL_PLANO_BASE_NOMES_PLANILHAS", int32_1, canal, cargo), substituicoes));
              string caminhoArquivo5 = caminhoArquivo1;
              now2 = DateTime.Now;
              string texto4 = now2.ToString() + " - Fim P_SQL_PLANO_BASE_NOMES_PLANILHAS";
              BLL.AdicionarTextoAoArquivo(caminhoArquivo5, texto4);
              if (dataTable.Rows.Count > 0)
              {
                string empty14 = string.Empty;
                int count2 = dataTable.Rows.Count;
                for (int index2 = 0; index2 < count2; ++index2)
                {
                  string str22 = dataTable.Rows[index2]["NM_INDICADOR"].ToString();
                  // ISSUE: reference to a compiler-generated field
                  if (frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__1 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, Worksheet>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Worksheet), typeof (frmConsultaBancos)));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: variable of a compiler-generated type
                  Worksheet worksheet2 = frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__1.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__1, o.Sheets[(object) "layoutPlanoBase"]);
                  // ISSUE: reference to a compiler-generated field
                  if (frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__3 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, Worksheet>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Worksheet), typeof (frmConsultaBancos)));
                  }
                  // ISSUE: reference to a compiler-generated field
                  Func<CallSite, object, Worksheet> target = frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__3.Target;
                  // ISSUE: reference to a compiler-generated field
                  CallSite<Func<CallSite, object, Worksheet>> p3 = frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__3;
                  // ISSUE: reference to a compiler-generated field
                  if (frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__2 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__2 = CallSite<Func<CallSite, Sheets, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Add", (IEnumerable<System.Type>) null, typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.NamedArgument, "After")
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  object obj = frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__2.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__2, o.Sheets, o.Sheets[(object) o.Sheets.Count]);
                  // ISSUE: variable of a compiler-generated type
                  Worksheet worksheet3 = target((CallSite) p3, obj);
                  // ISSUE: reference to a compiler-generated method
                  worksheet2.Cells.Copy((object) worksheet3.Cells);
                  worksheet3.Name = str22;
                  substituicoes["{nomePlanilha}"] = str22;
                  // ISSUE: reference to a compiler-generated field
                  if (frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__4 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, Worksheet>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Worksheet), typeof (frmConsultaBancos)));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: variable of a compiler-generated type
                  Worksheet worksheet4 = frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__4.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__4, o.Worksheets[(object) str22]);
                  substituicoes["{tabelaDetConsolidada}"] = str19;
                  substituicoes["{tabelaDetFaturamento}"] = str20;
                  string caminhoArquivo6 = caminhoArquivo1;
                  now2 = DateTime.Now;
                  string texto5 = now2.ToString() + " - Início P_SQL_DETALHADO";
                  BLL.AdicionarTextoAoArquivo(caminhoArquivo6, texto5);
                  string consultaSQL5 = frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_SQL_DETALHADO", int32_1, canal, cargo, str22), substituicoes);
                  string str23 = this.ObterValor(dt, "P_CELULA_DETALHADO", int32_1, canal, cargo);
                  this.DataTableParaExcel(worksheet4, consultaSQL5, str23, true);
                  // ISSUE: reference to a compiler-generated method
                  o.Save();
                  string caminhoArquivo7 = caminhoArquivo1;
                  now2 = DateTime.Now;
                  string texto6 = now2.ToString() + " - Fim P_SQL_DETALHADO";
                  BLL.AdicionarTextoAoArquivo(caminhoArquivo7, texto6);
                  string str24 = Regex.Replace(str21, "[^A-Z]", "");
                  int num4 = 0;
                  for (int index3 = 0; index3 < 2; ++index3)
                  {
                    switch (index3)
                    {
                      case 0:
                        num4 = Convert.ToInt32(Regex.Replace(str21, "[^0-9]", ""));
                        break;
                      case 1:
                        num4 = Convert.ToInt32(Regex.Replace(input, "[^0-9]", ""));
                        break;
                    }
                    for (int index4 = 0; index4 < 10; ++index4)
                    {
                      string str25;
                      try
                      {
                        // ISSUE: reference to a compiler-generated field
                        if (frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__5 == null)
                        {
                          // ISSUE: reference to a compiler-generated field
                          frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (frmConsultaBancos)));
                        }
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated method
                        // ISSUE: reference to a compiler-generated method
                        str25 = frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__5.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__5, worksheet1.get_Range((object) (str24 + (num4 + index4).ToString()), System.Type.Missing).get_Value(System.Type.Missing));
                      }
                      catch (Exception ex)
                      {
                        str25 = (string) null;
                        Console.Write(ex.Message);
                      }
                      if (!string.IsNullOrWhiteSpace(str25) && (str25.Length <= 29 ? str25 : str25.Substring(0, 29)).Equals(str22))
                        this.InserirHyperLinkExcel(worksheet1, str24 + (num4 + index4).ToString(), worksheet4, "A1");
                    }
                  }
                  int int32_2 = Convert.ToInt32(this.ObterValor(dt, "P_VALOR_PERCENTUAL_ZOOM_PLANILHAS", int32_1, canal, cargo));
                  worksheet4.Application.ActiveWindow.Zoom = (object) int32_2;
                  worksheet4.Application.ActiveWindow.DisplayGridlines = false;
                  Color color = ColorTranslator.FromHtml(this.ObterValor(dt, "P_COR_HEXADECIMAL_PLANILHAS_DETALHADO", int32_1, canal, cargo));
                  worksheet4.Tab.Color = (object) color;
                  // ISSUE: reference to a compiler-generated method
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Excel.Range range = worksheet4.get_Range((object) str23, System.Type.Missing);
                  // ISSUE: reference to a compiler-generated method
                  range.AutoFilter((object) 1, System.Type.Missing, Criteria2: System.Type.Missing, VisibleDropDown: (object) true);
                  // ISSUE: reference to a compiler-generated method
                  worksheet4.Columns.AutoFit();
                  string textoParaExibir = this.ObterValor(dt, "P_CELULA_DETLHADO_PARA_VOLTAR_CAPA_TEXTO", int32_1, canal, cargo);
                  this.InserirHyperLinkExcel(worksheet4, this.ObterValor(dt, "P_CELULA_DETALHADO_PARA_VOLTAR_CAPA", int32_1, canal, cargo), worksheet1, "A1", textoParaExibir);
                }
              }
              // ISSUE: reference to a compiler-generated field
              if (frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__6 == null)
              {
                // ISSUE: reference to a compiler-generated field
                frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, Worksheet>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Worksheet), typeof (frmConsultaBancos)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: variable of a compiler-generated type
              Worksheet worksheet5 = frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__6.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__6, o.Worksheets[(object) 1]);
              // ISSUE: reference to a compiler-generated method
              worksheet5.Activate();
              // ISSUE: reference to a compiler-generated field
              if (frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__7 == null)
              {
                // ISSUE: reference to a compiler-generated field
                frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, Worksheet>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Worksheet), typeof (frmConsultaBancos)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: variable of a compiler-generated type
              Worksheet worksheet6 = frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__7.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__88.\u003C\u003Ep__7, o.Worksheets[(object) "layoutPlanoBase"]);
              // ISSUE: reference to a compiler-generated method
              worksheet6.Delete();
              // ISSUE: reference to a compiler-generated method
              o.Save();
              if (tipoGeracao > 0 && BLL.enviarInformativo)
              {
                string emailDestinatario = "";
                switch (tipoGeracao)
                {
                  case 1:
                    emailDestinatario = BLL.emailUsuario(Globals._loginRedeUsuario.ToUpper());
                    break;
                  case 2:
                    if (this.ObterValor(dt, "P_BLOQUEIO_ENVIO_EMAIL", int32_1, canal, cargo).Equals("0"))
                    {
                      emailDestinatario = str13;
                      break;
                    }
                    BLL.EnviarInformativo = false;
                    throw new Exception($"A divulgação de emails para o canal {canal} está bloqueada no banco de dados por segurança.");
                }
                if (File.Exists(str18))
                {
                  string str26 = frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_CORPO_EMAIL_HTML", int32_1, canal, cargo), substituicoes);
                  string emailRemetente = this.ObterValor(dt, "P_EMAIL_REMETENTE", int32_1, canal, cargo);
                  string assunto = frmConsultaBancos.SubstituirMultiplos(this.ObterValor(dt, "P_ASSUNTO_EMAIL_HTML", int32_1, canal, cargo), substituicoes);
                  str2 = $"Enviando informativo para {emailDestinatario}\n";
                  BLL.AdicionarTextoAoArquivo(caminhoArquivo1, str2);
                  this.AppendText(this.rtbInformativos, str2, BLL.CorTransparente);
                  BLL.EnviarEmailComAnexo(emailRemetente, emailDestinatario, assunto, $"<img align=\"baseline\" hspace=\"0\" src=\"cid:myident\" hold=\" /> \"></img>{str26}<img align=\"baseline\" hspace=\"0\" src=\"cid:myident1\" hold=\" /> \"></img>", str15 + str17);
                  substituicoes.Clear();
                  BLL.EnviarInformativo = false;
                  string[] strArray = new string[7]
                  {
                    "INSERT INTO GVDW_B2B.TB_LOG_INFORMATIVO \n(ID_VERSAO, RE, DATA_ENVIO) \n VALUES ('",
                    str11,
                    "','",
                    str7,
                    "',TO_DATE('",
                    null,
                    null
                  };
                  now2 = DateTime.Now;
                  strArray[5] = now2.ToString("dd/MM/yyyy HH:mm:ss");
                  strArray[6] = "', 'dd/MM/yyyy hh24:mi:ss'))";
                  DAL.PegarDadosTOT(string.Concat(strArray), alteracao: true);
                }
                else
                {
                  ++num3;
                  str2 = empty10 + ": arquivo não foi localizado.";
                  BLL.EnviarInformativo = false;
                  throw new Exception(str2);
                }
              }
              this.AppendText(this.rtbInformativos, $"FIM {str1}\n", BLL.CorAzul);
            }
            catch (Exception ex)
            {
              ++num3;
              str2 = $"ERRO - {empty10}: {ex.Message}";
              BLL.AdicionarTextoAoArquivo(caminhoArquivo1, str2);
              this.AppendText(this.rtbInformativos, str2 + "\n", BLL.CorVermelha);
              BLL.EnviarInformativo = false;
              frmConsultaBancos.EncerrarExcelEmSegundoPlano("EXCEL");
            }
            finally
            {
              if (o != null)
              {
                try
                {
                  // ISSUE: reference to a compiler-generated method
                  o.Close((object) false, System.Type.Missing, System.Type.Missing);
                  frmConsultaBancos.EncerrarExcelEmSegundoPlano("EXCEL");
                }
                catch (Exception ex)
                {
                  ++num3;
                  str2 = $"ERRO - {empty10}: {ex.Message}";
                  BLL.AdicionarTextoAoArquivo(caminhoArquivo1, str2);
                  this.AppendText(this.rtbInformativos, str2, BLL.CorVermelha);
                  BLL.EnviarInformativo = false;
                }
                Marshal.ReleaseComObject((object) o);
              }
              if (str2.IndexOf("ERRO") > 0)
                validacaoResultado.Rows[index1].Cells["COLABORADOR"].Style.BackColor = BLL.CorVermelha;
              GC.Collect();
              GC.WaitForPendingFinalizers();
              BLL.AdicionarTextoAoArquivo(caminhoArquivo1, "Fim " + str1);
            }
          }
          GC.Collect();
          GC.WaitForPendingFinalizers();
        }
      }
      this.AppendText(this.rtbInformativos, DateTime.Now.ToShortTimeString() + " - Fim geração informativos...\n", BLL.CorAzul);
      TimeSpan timeSpan = DateTime.Now - now1;
      string mensagem = $"Tempo gasto: {timeSpan.Hours} horas, {timeSpan.Minutes} minutos, {timeSpan.Seconds} segundos";
      BLL.AdicionarTextoAoArquivo(caminhoArquivo1, "Fim");
      frmConsultaBancos.EncerrarExcelEmSegundoPlano("EXCEL");
      this.preencherBarraStatusPrincipal(mensagem);
    }
    this.AtivarBotoesGerarInformativosExcel(true, (Control) this.btnDivulgar, (Control) this.btnApenasGerar, (Control) this.btnEnviarParaMim, (Control) this.cmbCanalInformativo, (Control) this.cmbPeriodoInformativo, (Control) this.cmbTrimestreInformativo, (Control) this.cmbVersaoInformativo, (Control) this.cmbCargoInformativo, (Control) this.cmbCalculoInformativo);
  }

  private static void EncerrarExcelEmSegundoPlano(string nomeProcesso)
  {
    Process[] processesByName = Process.GetProcessesByName(nomeProcesso);
    if (((IEnumerable<Process>) processesByName).Any<Process>())
    {
      foreach (Process process in processesByName)
      {
        try
        {
          process.Kill();
          process.WaitForExit();
          Console.WriteLine($"Processo Excel com ID {process.Id} foi encerrado.");
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Erro ao encerrar processo Excel com ID {process.Id}: {ex.Message}");
        }
      }
    }
    else
      Console.WriteLine("Nenhum processo do Excel encontrado em execução.");
  }

  private void gerarInformativos(int tipoGeracao)
  {
    if (!(DAL._tabelaAtual == "GVDW_B2B.VW_RESULTADO_FINAL_INFORM_TOT"))
      return;
    this.gerarInformativoExcel(tipoGeracao);
  }

  private void gerarInformativoLocal(int tipoGeracao)
  {
  }

  private List<string> listaValoresSelecionadosNoGrid(string campo)
  {
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    int num = 0;
    List<string> stringList = new List<string>();
    try
    {
      for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
      {
        if (validacaoResultado.Rows[index].Selected.Equals(true))
        {
          stringList.Add(validacaoResultado.Rows[index].Cells[campo].Value.ToString());
          ++num;
        }
      }
    }
    catch (Exception ex)
    {
      stringList = (List<string>) null;
      this.preencherBarraStatusPrincipal("Falha ao listar registros selecionados no grid. Erro: " + ex.Message);
    }
    return stringList;
  }

  private void gerarInformativo(int tipoGeracao)
  {
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    int num1 = 0;
    string str1 = "C:\\Temp\\informativos\\";
    string emailDestinatario = BLL.emailUsuario(Globals._loginRedeUsuario.ToUpper());
    string str2 = BLL.lerArquivoTexto(AppDomain.CurrentDomain.BaseDirectory + "\\corpo_email.html");
    string emailAssunto = BLL.lerArquivoTexto(AppDomain.CurrentDomain.BaseDirectory + "\\assunto_email.txt");
    DateTime now = DateTime.Now;
    bool flag = false;
    if (validacaoResultado.Rows.Count > 0)
    {
      DialogResult dialogResult = MessageBox.Show("ATENÇÃO\n\nApós clicar em OK não será possível interromper a ação.\n\nDeseja continuar?", "TOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
      if (tipoGeracao == 2)
      {
        dialogResult = MessageBox.Show("ATENÇÃO\n\nVocê está prestes a enviar email para os colaboradores selecionados, antes de prosseguir tenha plena certeza que aplicou o filtros corretos.\n\nDeseja continuar?", "TOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (!dialogResult.Equals((object) DialogResult.OK))
          return;
      }
      if (!dialogResult.Equals((object) DialogResult.OK))
        return;
      try
      {
        DataTable dataTable1 = new DataTable();
        for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
        {
          if (validacaoResultado.Rows[index].Selected)
          {
            string str3 = validacaoResultado.Rows[index].Cells["ID"].Value.ToString();
            string emailNomeAnexo = $"{validacaoResultado.Rows[index].Cells["ANOMES"].Value.ToString()}_{validacaoResultado.Rows[index].Cells["NOME"].Value.ToString()}_{validacaoResultado.Rows[index].Cells["ID_VERSAO"].Value.ToString()}.html";
            DataTable dataTable2 = DAL.PegarDadosTOT($"SELECT A.INFORMATIVO HTML FROM GVDW_OWNER.RV_B2B_INFORMATIVO2 A WHERE A.ROWID = '{str3}'");
            if (dataTable2.Columns.Contains("HTML"))
            {
              string contents = dataTable2.Rows[0][0].ToString();
              File.WriteAllText(str1 + emailNomeAnexo, contents);
            }
            if (tipoGeracao > 0)
            {
              if (tipoGeracao == 2)
                emailDestinatario = validacaoResultado.Rows[index].Cells["EMAIL"].Value.ToString();
              flag = BLL.enviarEmail(emailDestinatario, emailAssunto, $"<img align=\"baseline\" hspace=\"0\" src=\"cid:myident\" hold=\" /> \"></img>{str2}<img align=\"baseline\" hspace=\"0\" src=\"cid:myident1\" hold=\" /> \"></img>", emailNomeAnexo, str1 + emailNomeAnexo);
            }
            ++num1;
          }
        }
        TimeSpan timeSpan = DateTime.Now.Subtract(now);
        double totalMinutes = timeSpan.TotalMinutes;
        double num2 = Math.Round(timeSpan.TotalMinutes, 2);
        string str4 = "";
        switch (tipoGeracao)
        {
          case 0:
            str4 = $"Foram gerados {num1.ToString()} informativos.";
            break;
          case 1:
            str4 = $"Foram enviados {num1.ToString()} informativos para o email {emailDestinatario}.";
            break;
          case 2:
            str4 = $"Foram enviados {num1.ToString()} informativos para os colaboradores.";
            break;
        }
        if (flag)
        {
          int num3 = (int) MessageBox.Show($"{str4}\n\nTempo gasto (em minutos): {num2.ToString()}", "TOT - Concluído", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (Exception ex)
      {
        BLL.erro("Ocorreu o seguinte erro ao tentar manusear os informativos:\n\n" + ex.Message);
      }
      if (num1 != 0)
        return;
      int num4 = (int) MessageBox.Show("Antes de prosseguir, selecione os informativos que deseja gerar/enviar.", "TOT - Selecione primeiro...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    else
    {
      int num5 = (int) MessageBox.Show("Primeiro faça um consulta que gere resultados, em seguida selecione os informativos que deseja utilizar.", "TOT - Nenhum informativo encontrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
  }

  private void cmsKPI_Click(object sender, EventArgs e)
  {
    Form form = (Form) new frmGrafico();
    form.StartPosition = FormStartPosition.CenterScreen;
    int num = (int) form.ShowDialog();
  }

  private void frmConsultaBancos_KeyDown(object sender, KeyEventArgs e)
  {
    if (!(e.KeyCode.ToString() == "F5"))
      return;
    this.btnPesquisarValidacaoResultado.PerformClick();
  }

  private void salvarHistoricoPesquisa()
  {
    if (BLL.hignorarHistorico)
      return;
    string str = DAL._tabelaAtual + "@" + (DAL._bancoSelecionado + "#");
    DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
    foreach (DataGridViewRow row in (IEnumerable) validacaoResultado.Rows)
    {
      for (int index = 0; index < validacaoResultado.Columns.Count; ++index)
      {
        str += row.Cells[index].Value?.ToString();
        if (index != validacaoResultado.Columns.Count)
          str += "|";
      }
      str += Environment.NewLine;
    }
    this.lbHistoricoConsultas.Items.Add((object) str);
    this.lbHistoricoConsultas.SelectedIndex = this.lbHistoricoConsultas.Items.Count - 1;
    this.txConsultaAtual.Text = str;
  }

  private void executarConsultaHistorica()
  {
    try
    {
      this.txPesquisarTabelas.Text = "";
      this.popularTreeviewValidacaoResultado2();
      string str = this.lbHistoricoConsultas.SelectedItem.ToString();
      if (string.IsNullOrWhiteSpace(str))
        return;
      int length1 = str.Length;
      int length2 = str.IndexOf("@");
      int num = str.IndexOf("#");
      string texto = str.Substring(0, length2);
      str.Substring(length2 + 1, num - length2 - 1);
      string consulta = str.Substring(num + 1, length1 - num - 1);
      this.selecionaNode(texto, this.tvwValidacaoResultado);
      BLL.hignorarHistorico = true;
      this.clicouTreeView(true, consulta);
    }
    catch (Exception ex)
    {
      BLL.erro("Falha ao tentar executar sua consulta histórica.", ex.Message);
    }
  }

  private void lbHistoricoConsultas_DoubleClick(object sender, EventArgs e)
  {
    this.executarConsultaHistorica();
  }

  private void selecionaNode(string texto, TreeView tvw)
  {
    try
    {
      if (tvw.Nodes.Count <= 0)
        return;
      for (int index = 0; index < tvw.Nodes.Count; ++index)
      {
        foreach (TreeNode treeNode in tvw.Nodes[index].Nodes.Find(texto, true))
        {
          tvw.SelectedNode = treeNode;
          tvw.SelectedNode.BackColor = Color.Yellow;
        }
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao selecionar tabela", ex.Message);
    }
  }

  private void selecionaNodeTextoParcial(string texto, TreeView tvw)
  {
    try
    {
      texto = texto.ToLower();
      if (tvw.Nodes.Count <= 0)
        return;
      for (int index1 = 0; index1 < tvw.Nodes.Count; ++index1)
      {
        TreeNode[] treeNodeArray = tvw.Nodes[index1].Nodes.Find(texto, true);
        int count = tvw.Nodes[index1].Nodes.Count;
        for (int index2 = 0; index2 < count - 1; ++index2)
        {
          if (treeNodeArray[index2].Text.ToLower().Contains(texto) || treeNodeArray[index2].Name.Contains(texto))
          {
            tvw.SelectedNode = treeNodeArray[index2];
            tvw.SelectedNode.BackColor = Color.Yellow;
          }
        }
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao selecionar tabela", ex.Message);
    }
  }

  private void tvwValidacaoResultado_AfterSelect(object sender, TreeViewEventArgs e)
  {
  }

  private void clicouTreeView(bool historico = false, string consulta = null)
  {
    try
    {
      this.dgvValidacaoResultado.ReadOnly = true;
      this.chkPreVisualizacao.Checked = true;
      if (this.tvwValidacaoResultado.SelectedNode.Equals((object) null))
        return;
      TreeNode parent = this.tvwValidacaoResultado.SelectedNode.Parent;
      TreeNode selectedNode = this.tvwValidacaoResultado.SelectedNode;
      if (selectedNode.Level < 2)
        return;
      int nodeCount = selectedNode.GetNodeCount(true);
      DAL._bancoSelecionado = parent.Parent.Text.ToLower();
      string tabela = selectedNode.Name.ToString();
      DAL._tabelaAtual = tabela;
      this.txTabelaAtual.Text = DAL._tabelaAtual;
      if (!string.IsNullOrWhiteSpace(tabela) && nodeCount.Equals(0))
      {
        this.dgvValidacaoResultado.DataSource = (object) null;
        this.popularGridValidacaoResultado(tabela, false, "", DAL._bancoSelecionado);
        this.dgvFiltrosValidacaoResultado.DataSource = (object) BLL.popularGridFiltros2(this.dgvValidacaoResultado);
        for (int index = 0; index < this.dgvFiltrosValidacaoResultado.Rows.Count; ++index)
          this.dgvFiltrosValidacaoResultado.Rows[index].Cells[3].Value = (object) true;
        this.formatarTvwBasesConsulta(this.tvwValidacaoResultado);
        if (!historico)
          return;
        try
        {
          DataTable dataTable = new DataTable();
          dataTable.Columns.Add("INDICADOR", typeof (string));
          dataTable.Columns.Add("OPERADOR", typeof (string));
          dataTable.Columns.Add("VALOR", typeof (string));
          dataTable.Columns.Add(" ", typeof (bool));
          dataTable.Columns.Add("x", typeof (string));
          string[] strArray1 = Regex.Split(consulta, Environment.NewLine);
          for (int index = 0; index < strArray1.Length - 1; ++index)
          {
            string[] strArray2 = strArray1[index].Split('|');
            dataTable.Rows.Add((object[]) strArray2);
          }
          dataTable.Columns.Remove("x");
          this.dgvFiltrosValidacaoResultado.DataSource = (object) dataTable;
          this.btnPesquisarValidacaoResultado.PerformClick();
        }
        catch (Exception ex)
        {
          BLL.erro("Não foi possível carregar o arquivo de consulta.", ex.Message);
        }
      }
      else
        this.preencherBarraStatusPrincipal("Selecione uma das tabelas disponíveis para exibir seu conteúdo", true);
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao consultar tabela/view", ex.Message);
      this.btnPesquisarValidacaoResultado.Text = "(F5) Pesquisar";
      this.btnPesquisarValidacaoResultado.Enabled = true;
      this.btnPesquisarEditar.Enabled = true;
      BLL.hignorarHistorico = true;
    }
  }

  private void lbHistoricoConsultas_KeyPress(object sender, KeyPressEventArgs e)
  {
  }

  private void lbHistoricoConsultas_KeyDown(object sender, KeyEventArgs e)
  {
    if (!e.KeyCode.ToString().Equals("Delete"))
      return;
    this.lbHistoricoConsultas.Items.Remove(this.lbHistoricoConsultas.SelectedItem);
  }

  private void tsmAdicionarCondicao_Click(object sender, EventArgs e)
  {
  }

  private void cmsAddFavoritos_Click(object sender, EventArgs e)
  {
    try
    {
      string tabelaAtual = DAL._tabelaAtual;
      DataTable dataTable = DAL.PegarDadosTOT($"INSERT INTO GVDW_OWNER.RV_B2B_VALIDA_RESULT_FAV (ID_VALIDA_RESULT, ID_USUARIO) SELECT ID_VALIDA_RESULT, (SELECT ID_USUARIO FROM GVDW_OWNER.RV_B2B_USUARIOS_APP WHERE CD_LOGIN_REDE = '{Globals._loginRedeUsuario.ToUpper()}') ID_USUARIO FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT WHERE NM_TABELA = '{tabelaAtual}'", alteracao: true);
      if (dataTable.Columns.Contains("errotot"))
      {
        BLL.erro("Erro ao tentar adicionar aos seus favoritos.", dataTable.Rows[0][0].ToString());
      }
      else
      {
        int num = (int) MessageBox.Show($"Tabela  {tabelaAtual} foi adicionada aos seus favoritos.\n\nA lista de tabelas será atualizada agora.", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.popularTreeviewValidacaoResultado2();
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Ocorreu o seguinte erro ao tentar adicionar aos seus favoritos:", ex.Message);
    }
  }

  private void cmsDelFavoritos_Click(object sender, EventArgs e)
  {
    try
    {
      string tabelaAtual = DAL._tabelaAtual;
      DataTable dataTable = DAL.PegarDadosTOT($"DELETE FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT_FAV WHERE ID_VALIDA_RESULT = (SELECT ID_VALIDA_RESULT FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT WHERE NM_TABELA = '{tabelaAtual}' )  AND ID_USUARIO = (SELECT ID_USUARIO FROM GVDW_OWNER.RV_B2B_USUARIOS_APP WHERE CD_LOGIN_REDE = '{Globals._loginRedeUsuario.ToUpper()}')", alteracao: true);
      if (dataTable.Columns.Contains("errotot"))
      {
        BLL.erro("Erro ao tentar remover dos seus favoritos.", dataTable.Rows[0][0].ToString());
      }
      else
      {
        int num = (int) MessageBox.Show($"Tabela  {tabelaAtual} foi removida dos seus favoritos.\n\nA lista de tabelas será atualizada agora.", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.popularTreeviewValidacaoResultado2();
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Ocorreu o seguinte erro ao tentar remover dos seus favoritos:", ex.Message);
    }
  }

  private void cmsTextoPesquisaValidacaoResultado_TextChanged_1(object sender, EventArgs e)
  {
    string celulaAtual = BLL.celulaAtual;
    string text = this.cmsTextoPesquisaValidacaoResultado.Text;
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    if (!string.IsNullOrWhiteSpace(celulaAtual))
    {
      (validacaoResultado.DataSource as DataTable).DefaultView.RowFilter = $"Convert([{celulaAtual}], 'System.String') LIKE '%{text}%'";
      this.preencherBarraStatusPrincipal($"Seu filtro retornou {validacaoResultado.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString()} linha(s)");
    }
    else
    {
      int num = (int) MessageBox.Show($"Antes de utilizar o filtro, clique sobre uma celula da planilha {Environment.NewLine}para definir em qual coluna a pesquisa será aplicada.", "TOT - Escolha uma coluna", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
  }

  private void cmsLimparFiltroColuna_Click_1(object sender, EventArgs e)
  {
    this.cmsTextoPesquisaValidacaoResultado.Text = "";
  }

  private void notificaoBandeja(string texto, string titulo, int tempo)
  {
    this.notifyIcon1.Visible = true;
    this.notifyIcon1.ShowBalloonTip(tempo, titulo, texto, ToolTipIcon.Info);
  }

  private void cmsExportarCronogramaInsumos_Click(object sender, EventArgs e)
  {
    this.exportarCronograma("");
  }

  private void exportarCronograma(string delimitador)
  {
    try
    {
      using (SaveFileDialog saveFileDialog = new SaveFileDialog())
      {
        saveFileDialog.Filter = "Exportação Cronograma Insumos (*.html)|*.html";
        int num = (int) saveFileDialog.ShowDialog();
        string fileName = saveFileDialog.FileName;
        StreamWriter streamWriter = new StreamWriter((Stream) new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8);
        DataGridView validacaoResultado = this.dgvValidacaoResultado;
        string str = validacaoResultado.Rows[0].Cells["Competência"].Value.ToString();
        streamWriter.Write($"<!DOCTYPE html>\n<html lang=\"pt-BR\">\n<head>\n<title>Cronograma Insumos B2B</title>\n<meta charset=\"UTF-8\"/>\n<style type=\"text/css\">\n   body {{\n       font-family: Tahoma;\n        font-size: 11px;\n   }}\n   table {{\n       font-family: Tahoma;\n        font-size: 10px;\n       border-collapse: collapse;\n   }}   td,th {{\n       white-space: nowrap;\n       padding: 5px;\n   }}\n   tr:nth-child(even) {{background-color: #F8F8F8;}}    tr:hover {{background-color:#FFFF99;}}\n </style>\n</head>\n<body>\n<h2>RH - Remuneração Variável B2B</h2>\n<h3><strong>Cronograma Mensal de Insumos - competência: <u>{str}</u></strong></h3>\n<table border=1>\n");
        streamWriter.Write(streamWriter.NewLine);
        streamWriter.Write("   <tr style=\"background-color: #4472C4; color: #ffffff\">");
        streamWriter.Write(streamWriter.NewLine);
        for (int index = 0; index < validacaoResultado.Columns.Count; ++index)
        {
          if (validacaoResultado.Columns[index].Visible)
            streamWriter.Write($"<th>{validacaoResultado.Columns[index].HeaderText}</th>");
        }
        streamWriter.Write("</tr>");
        streamWriter.Write(streamWriter.NewLine);
        foreach (DataGridViewRow row in (IEnumerable) validacaoResultado.Rows)
        {
          streamWriter.Write("<tr>");
          for (int index = 0; index < validacaoResultado.Columns.Count; ++index)
            streamWriter.Write($"<td>{row.Cells[index].Value?.ToString()}</td>");
          streamWriter.Write("</tr>");
          streamWriter.Write(streamWriter.NewLine);
        }
        streamWriter.Flush();
        streamWriter.Close();
        this.notificaoBandeja("Seu cronograma foi salvo em " + fileName, "TOT - Cronograma", 3000);
        Process.Start(fileName);
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao exportar o resultado para arquivo.\n\nCaso esteja com o arquivo aberto, feche-o e tente novamente.\n\nAté que este erro seja identificado e corrigido, utilize o recurso de copiar e colar.", "\n\n" + ex.Message);
    }
  }

  private void btnSalvarNovasLinhas_Click(object sender, EventArgs e)
  {
    if (!this.tabelaEditavel())
    {
      BLL.erro("Esta tabela está bloqueada para edição.\nPeça liberação para seu gestor.\n", "Tabela bloqueada para edição pelo Gestor da área.");
    }
    else
    {
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      DataTable dataSource = (DataTable) validacaoResultado.DataSource;
      if (validacaoResultado.Rows.Count <= 0)
      {
        BLL.erro("Antes de tentar salvar é preciso adicionar uma ou mais linhas em uma tabela.", "Tentou salvar sem ter inserido novas linhas");
      }
      else
      {
        DataColumnCollection columns1 = dataSource.Columns;
        string consulta = "";
        string str1 = "";
        string str2 = "";
        int num1 = 0;
        if (!columns1.Contains("INDICE_NOVA_LINHA"))
          return;
        for (int index1 = 0; index1 < dataSource.Rows.Count; ++index1)
        {
          if (validacaoResultado.Rows[index1].Cells["INDICE_NOVA_LINHA"].Value.ToString() == "1")
          {
            foreach (DataColumn column in (InternalDataCollectionBase) dataSource.Columns)
            {
              consulta = $"{consulta}{column.ColumnName.ToString()},";
              if (column.ColumnName.ToString() != "ROWID" && column.ColumnName.ToString() != "INDICE_NOVA_LINHA")
              {
                string s = validacaoResultado.Rows[index1].Cells[column.ColumnName].Value.ToString();
                str2 = !DateTime.TryParse(s, out DateTime _) ? $"{str2}'{validacaoResultado.Rows[index1].Cells[column.ColumnName].Value.ToString().ToUpper().Replace("'", "''")}'," : $"{str2}to_DATE('{s.Substring(0, 10)}','DD/MM/YYYY'),";
              }
            }
            ++num1;
            string str3 = consulta.Replace("ROWID,", "").Replace("INDICE_NOVA_LINHA,", "");
            consulta = $"INSERT INTO {DAL._tabelaAtual} ({str3.Substring(0, str3.Length - 1)}) VALUES ({str2.Substring(0, str2.Length - 1)})";
            try
            {
              DataTable dataTable = DAL.PegarDadosTOT(consulta, alteracao: true);
              DataColumnCollection columns2 = dataTable.Columns;
              if (columns2.Contains("errotot"))
              {
                BLL.erro("Erro ao salvar seus dados. Verifique o formato dos dados e tente novamente.", "Erro ao atualizar tabela");
                throw new Exception(dataTable.Rows[0][0].ToString());
              }
              if (columns2.Contains("nu_registros"))
              {
                string str4 = dataTable.Rows[0][0].ToString();
                for (int index2 = dataSource.Rows.Count - 1; index2 >= 0; --index2)
                {
                  DataRow row = dataSource.Rows[index2];
                  if (row["INDICE_NOVA_LINHA"].Equals((object) "1"))
                    row.Delete();
                }
                dataSource.AcceptChanges();
                this.dgvValidacaoResultado.DataSource = (object) dataSource;
                this.preencherBarraStatusPrincipal("Número de linhas inseridas: " + str4);
                this.ativarBotoesEdicao(false);
                if (this.txTabelaAtual.Text.Equals("GVDW_OWNER.RV_B2B_CONTROLE_DEMANDAS"))
                  this.atuarSobreDemandasNovas();
              }
              else
              {
                int num2 = (int) MessageBox.Show("Não foi obtida uma resposta do banco. Verifique manualmente se seus dados foram inseridos.", "TOT - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
              BLL.InserirLog(Globals._loginRedeUsuario.ToUpper(), $"Executou o script: /*{consulta.Replace("'", "''")}*/");
              consulta = "";
              str1 = "";
              str2 = "";
            }
            catch (Exception ex)
            {
              BLL.erro($"Erro ao tentar inserir os dados a partir da {num1.ToString()}ª nova linha.\nRevise seus dados e tente novamente.", ex.Message);
            }
          }
        }
      }
    }
  }

  private DataTable ConvertRangeToDataTable()
  {
    try
    {
      DataTable dataTable = new DataTable();
      int count1 = this.rng.Columns.Count;
      int count2 = this.rng.Rows.Count;
      dataTable.Columns.Add(new DataColumn()
      {
        ColumnName = "SEGMENTO"
      });
      dataTable.Columns.Add(new DataColumn()
      {
        ColumnName = "NUM PROTOCOLO"
      });
      dataTable.Columns.Add(new DataColumn()
      {
        ColumnName = "RE"
      });
      dataTable.Columns.Add(new DataColumn()
      {
        ColumnName = "STATUS"
      });
      for (int index = 0; index < count1; ++index)
      {
        DataColumn column = new DataColumn();
        DataColumn dataColumn = column;
        // ISSUE: reference to a compiler-generated field
        if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (frmConsultaBancos)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target1 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p2 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__2;
        // ISSUE: reference to a compiler-generated field
        if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object> target2 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object>> p1 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value2", typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__0.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__0, this.rng.Cells[(object) 3, (object) (index + 1)]);
        object obj2 = target2((CallSite) p1, obj1);
        string str = target1((CallSite) p2, obj2);
        dataColumn.ColumnName = str;
        dataTable.Columns.Add(column);
      }
      // ISSUE: reference to a compiler-generated field
      if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (frmConsultaBancos)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, string> target3 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__5.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string>> p5 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__5;
      // ISSUE: reference to a compiler-generated field
      if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, object> target4 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__4.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, object>> p4 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__4;
      // ISSUE: reference to a compiler-generated field
      if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value2", typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__3.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__3, this.rng.Cells[(object) 1, (object) 4]);
      object obj4 = target4((CallSite) p4, obj3);
      string str1 = target3((CallSite) p5, obj4);
      string str2 = this.App.Caption.ToString();
      string str3 = str2.Substring(0, str2.IndexOf("_"));
      // ISSUE: reference to a compiler-generated field
      if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__8 == null)
      {
        // ISSUE: reference to a compiler-generated field
        frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (frmConsultaBancos)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, string> target5 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__8.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string>> p8 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__8;
      // ISSUE: reference to a compiler-generated field
      if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__7 == null)
      {
        // ISSUE: reference to a compiler-generated field
        frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, object> target6 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__7.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, object>> p7 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__7;
      // ISSUE: reference to a compiler-generated field
      if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value2", typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__6.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__6, this.rng.Cells[(object) 1, (object) 2]);
      object obj6 = target6((CallSite) p7, obj5);
      string str4 = target5((CallSite) p8, obj6);
      string str5 = "Em análise";
      for (int RowIndex = 4; RowIndex <= count2; ++RowIndex)
      {
        DataRow row = dataTable.NewRow();
        row[0] = (object) str4;
        row[1] = (object) str3;
        row[2] = (object) str1;
        row[3] = (object) str5;
        for (int ColumnIndex = 1; ColumnIndex <= count1; ++ColumnIndex)
        {
          DataRow dataRow = row;
          int columnIndex = ColumnIndex + 3;
          // ISSUE: reference to a compiler-generated field
          if (frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__9 == null)
          {
            // ISSUE: reference to a compiler-generated field
            frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value2", typeof (frmConsultaBancos), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__9.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__116.\u003C\u003Ep__9, this.rng.Cells[(object) RowIndex, (object) ColumnIndex]);
          dataRow[columnIndex] = obj7;
        }
        dataTable.Rows.Add(row);
      }
      return dataTable;
    }
    catch
    {
      return (DataTable) null;
    }
  }

  private void _Dispose()
  {
    try
    {
      Marshal.ReleaseComObject((object) this.rng);
    }
    catch
    {
    }
    finally
    {
      this.rng = (Microsoft.Office.Interop.Excel.Range) null;
    }
    try
    {
      // ISSUE: reference to a compiler-generated method
      this.App.Quit();
      Marshal.ReleaseComObject((object) this.App);
    }
    catch
    {
    }
    finally
    {
      this.App = (Microsoft.Office.Interop.Excel.Application) null;
    }
  }

  private void cmsExecutarPrograma_Click(object sender, EventArgs e)
  {
    switch (DAL._tabelaAtual)
    {
      case "GVDW_OWNER.RV_B2B_ORDEM_PROCESS":
        this.executarProgramasCalculo();
        break;
      case "GVDW_OWNER.RV_B2B_PARAMETROS_DATAQUALITY":
        this.executarProgramasDataQuality();
        break;
    }
  }

  private void executarProgramasDataQuality()
  {
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    int num1 = 0;
    string str1 = "";
    int num2 = 0;
    if (validacaoResultado.Rows.Count <= 0 || !MessageBox.Show("ATENÇÃO\n\nApós clicar em OK não será possível interromper a ação.\n\nDeseja continuar?", "TOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
      return;
    if (validacaoResultado.SelectedRows.Count.Equals(0))
    {
      int num3 = (int) MessageBox.Show("Selecione ao menos uma linha para poder gerar informativos");
    }
    else
    {
      try
      {
        if (BLL.InputBox("TOT", "Informe o PERIODO no formato AAAAMM.Exemplo: para dezembro/22 digite 202212", ref str1) == DialogResult.OK)
        {
          for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
          {
            if (validacaoResultado.Rows[index].Selected.Equals(true))
            {
              ++num1;
              string str2 = validacaoResultado.Rows[index].Cells["TABELA"].Value.ToString();
              string str3 = validacaoResultado.Rows[index].Cells["CENARIO"].Value.ToString();
              string str4 = str1.Substring(0, 6);
              this.preencherBarraStatusPrincipal($"{str2} - executando dataquality. Item [{num1.ToString()}]");
              System.Windows.Forms.Application.DoEvents();
              DataTable dataTable = DAL.PegarDadosTOT($"call GVDW_OWNER.SP_RV_B2B_DATAQUALITY7('{str4}','{str2}','{str3}')", alteracao: true, programa: true);
              if (dataTable != null)
              {
                if (dataTable.Columns.Contains("errotot"))
                {
                  DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_PARAMETROS_DATAQUALITY SET DATA_EXECUCAO = SYSDATE,ERRO_ULT_EXECUCAO = '{dataTable.Rows[0][0].ToString()}', PERIODO_ULT_EXEC = '{str4}' WHERE TABELA = '{str2}'  AND CENARIO = '{str3}' ", alteracao: true);
                  this.notificaoBandeja($"Erro data quality: {str2}, cenário: {str3}", "Erro", 8000);
                  ++num2;
                }
                else
                  DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_PARAMETROS_DATAQUALITY SET DATA_EXECUCAO = SYSDATE,ERRO_ULT_EXECUCAO = '', PERIODO_ULT_EXEC = '{str4}' WHERE TABELA = '{str2}'  AND CENARIO = '{str3}' ", alteracao: true);
              }
            }
          }
        }
        if (num2 > 0)
        {
          int num4 = (int) MessageBox.Show($"Quantidade executados: {num1.ToString()}\n\nQuantidade que apresentaram erros: {num2.ToString()}\n\nPara verificar os detalhes de cada erro, atualize a consulta da tabela e parâmetros e consulte as colunas DATA_EXECUCAO, ERRO_ULT_EXECUCAO e PERIODO_ULT_EXEC", "TOT - Fim da execução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.preencherBarraStatusPrincipal("");
        }
        else
        {
          this.notificaoBandeja($"Foram executados {num1.ToString()} processos de data quality", "Fim", 8000);
          this.preencherBarraStatusPrincipal("");
        }
      }
      catch (Exception ex)
      {
        BLL.erro("Ocorreu o seguinte erro ao tentar executar o data quality:", ex.Message);
      }
    }
  }

  private void executarProgramasCalculo()
  {
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    DataGridView dataGridView = new DataGridView();
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    string str1 = "";
    string str2 = "";
    string upper = Globals._loginRedeUsuario.ToUpper();
    string str3 = "";
    DataTable dataTable1 = new DataTable();
    DataTable dataTable2 = DAL.PegarDadosTOT($"SELECT DISTINCT LOWER(EMAIL) email FROM GVDW_OWNER.RV_B2B_USUARIOS_APP WHERE UPPER(CD_LOGIN_REDE) = '{upper}'");
    if (dataTable2 != null && dataTable2.Columns.Contains("email"))
      str3 = dataTable2.Rows[0][0].ToString();
    dataTable1 = (DataTable) null;
    for (int index = 0; index < this.dgvValidacaoResultado.Rows.Count; ++index)
    {
      if (validacaoResultado.Rows[index].Selected)
        ++num1;
    }
    if (num1 > 0)
    {
      if (!MessageBox.Show($"Executar programa?\n\n{""}\n\nConfira os parametros com cuidado.\n\nApós iniciar a execução NÃO será possível interromper.", "TOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question).Equals((object) DialogResult.OK))
        return;
      try
      {
        string tabelaAtual = DAL._tabelaAtual;
        DataTable dataTable3 = new DataTable();
        bool flag1 = false;
        bool flag2 = false;
        this.AppendText(this.rtbStatusProcessamento, DateTime.Now.ToString("dd/MM/yyyy HH:mm tt") + ": INÍCIO novo cálculo\n", Color.DarkBlue);
        switch (this.txTabelaAtual.Text.ToUpper())
        {
          case "GVDW_OWNER.VW_CP_ERP_CALCULOS":
            string str4 = validacaoResultado.CurrentRow.Cells["ID_INICIO"].Value.ToString();
            string str5 = validacaoResultado.CurrentRow.Cells["ID_FIM"].Value.ToString();
            dataTable3 = DAL.PegarDadosTOT($"SELECT *   FROM GVDW_OWNER.RV_B2B_ORDEM_PROCESS  WHERE ID BETWEEN {str4} AND {str5} ORDER BY NUM_ORDEM");
            DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_ORDEM_PROCESS A SET NUM_EXECUCAO_CALCULO = NVL((SELECT MAX(B.NUM_EXECUCAO_CALCULO)                            FROM GVDW_OWNER.RV_B2B_ORDEM_PROCESS B                           WHERE B.ID = A.ID),0) + 1 WHERE ID BETWEEN {str4} AND {str5}", alteracao: true);
            flag2 = true;
            this.btnPesquisarValidacaoResultado.PerformClick();
            break;
          case "GVDW_OWNER.RV_B2B_ORDEM_PROCESS":
            dataTable3 = (DataTable) validacaoResultado.DataSource;
            break;
        }
        for (int index = 0; index < dataTable3.Rows.Count; ++index)
        {
          if (!flag2)
            flag1 = validacaoResultado.Rows[index].Selected;
          if (flag1 || this.txTabelaAtual.Text.Equals("GVDW_OWNER.VW_CP_ERP_CALCULOS"))
          {
            string str6;
            string str7;
            string str8;
            string str9;
            if (this.txTabelaAtual.Text.Equals("GVDW_OWNER.VW_CP_ERP_CALCULOS"))
            {
              str6 = dataTable3.Rows[index]["PROGRAMA"].ToString();
              str1 = dataTable3.Rows[index]["PROCESSO"].ToString();
              str7 = dataTable3.Rows[index]["DESCRICAO_BLOQUEIO"].ToString();
              str8 = dataTable3.Rows[index]["PERIODO"].ToString();
              str9 = dataTable3.Rows[index]["ID"].ToString();
            }
            else
            {
              str6 = this.dgvValidacaoResultado.Rows[index].Cells["PROGRAMA"].Value.ToString();
              str1 = this.dgvValidacaoResultado.Rows[index].Cells["PROCESSO"].Value.ToString();
              str7 = this.dgvValidacaoResultado.Rows[index].Cells["DESCRICAO_BLOQUEIO"].Value.ToString();
              str8 = this.dgvValidacaoResultado.Rows[index].Cells["PERIODO"].Value.ToString();
              str9 = this.dgvValidacaoResultado.Rows[index].Cells["ID"].Value.ToString();
            }
            this.preencherBarraStatusPrincipal($"Executando {str6.Replace("GVDW_OWNER.", "")}...");
            System.Windows.Forms.Application.DoEvents();
            DateTime now;
            DataTable dataTable4;
            if (string.IsNullOrWhiteSpace(str7))
            {
              DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_ORDEM_PROCESS    SET DT_INI_EXEC = SYSDATE,        USUARIO_EXECUCAO = '{Globals._loginRedeUsuario}'  WHERE ID = '{str9}' ", alteracao: true);
              RichTextBox statusProcessamento1 = this.rtbStatusProcessamento;
              string[] strArray1 = new string[5]
              {
                "► ",
                null,
                null,
                null,
                null
              };
              now = DateTime.Now;
              strArray1[1] = now.ToString("HH:mm:ss tt");
              strArray1[2] = ": Início ";
              strArray1[3] = str6;
              strArray1[4] = "\n";
              string text1 = string.Concat(strArray1);
              Color darkGreen = Color.DarkGreen;
              this.AppendText(statusProcessamento1, text1, darkGreen);
              System.Windows.Forms.Application.DoEvents();
              dataTable4 = DAL.PegarDadosTOT("call " + str6, alteracao: true, programa: true);
              RichTextBox statusProcessamento2 = this.rtbStatusProcessamento;
              string[] strArray2 = new string[5]
              {
                "► ",
                null,
                null,
                null,
                null
              };
              now = DateTime.Now;
              strArray2[1] = now.ToString("HH:mm:ss tt");
              strArray2[2] = ": Fim ";
              strArray2[3] = str6;
              strArray2[4] = "\n------------------------------------------------------------------\n";
              string text2 = string.Concat(strArray2);
              Color black = Color.Black;
              this.AppendText(statusProcessamento2, text2, black);
              System.Windows.Forms.Application.DoEvents();
              DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_ORDEM_PROCESS SET DT_FIM_EXEC = SYSDATE WHERE ID = '{str9}' ", alteracao: true);
            }
            else
            {
              str2 = $"{str2}{str6} = {str7}\n";
              dataTable4 = (DataTable) null;
            }
            if (dataTable4 != null)
            {
              if (dataTable4.Columns.Contains("errotot"))
              {
                this.notificaoBandeja($"Programa {str6} apresentou erro: {dataTable4.Rows[0][0].ToString()}", "Cálculo", 10000);
                RichTextBox statusProcessamento = this.rtbStatusProcessamento;
                string[] strArray3 = new string[5]
                {
                  "► ",
                  null,
                  null,
                  null,
                  null
                };
                now = DateTime.Now;
                strArray3[1] = now.ToString("HH:mm:ss tt");
                strArray3[2] = ": ";
                strArray3[3] = dataTable4.Rows[0][0].ToString().Replace("'", "''");
                strArray3[4] = "------------------------------------------------------------------\n";
                string text = string.Concat(strArray3);
                Color red = Color.Red;
                this.AppendText(statusProcessamento, text, red);
                DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_ORDEM_PROCESS SET DESCRICAO_ERRO = '{dataTable4.Rows[0][0].ToString().Replace("'", "''")}' WHERE PROGRAMA = '{str6.Replace("'", "''")}'  AND PERIODO = '{str8.Substring(0, 10)}' ", alteracao: true);
                ++num3;
                if (this.chkEmailDeErroPraMim.Checked)
                {
                  string emailDestinatario = str3;
                  string[] strArray4 = new string[7]
                  {
                    "<p>O programa: <font color='#0000FF'>",
                    str6,
                    "</font></p><p>apresentou o seguinte erro:<br><br><i>",
                    dataTable4.Rows[0][0].ToString(),
                    "</i><br><br><b>Email automatizado - ",
                    null,
                    null
                  };
                  now = DateTime.Now;
                  strArray4[5] = now.ToString();
                  strArray4[6] = "</b>";
                  string emailConteudo = string.Concat(strArray4);
                  BLL.enviarEmail(emailDestinatario, "Erro execução programa TOT", emailConteudo);
                }
                if (this.chkPararCalculoSeHouverErro.Checked)
                  throw new InvalidOperationException($"O programa {str6} apresentou o seguinte erro: {dataTable4.Rows[0][0].ToString()}. As demais execuções selecionadas serão interrompidas.");
              }
              else
              {
                DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_ORDEM_PROCESS SET DESCRICAO_ERRO = '' WHERE PROGRAMA = '{str6.Replace("'", "''")}'  AND PERIODO = '{str8.Substring(0, 10)}' ", alteracao: true);
                ++num2;
              }
            }
          }
        }
        if (num3 > 0)
        {
          int num4 = (int) MessageBox.Show($"O sistema identificou erro em {num3.ToString()} programas, do total de {num1.ToString()} programas executados. Verifique os logs para obter os detalhes", "TOT - Erros de execução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
          this.notificaoBandeja("Fim da execução. Total de programas executados: " + num1.ToString(), "Cálculo", 10000);
        if (str2 != "")
        {
          int num5 = (int) MessageBox.Show("Esses programas não foram executados porque contem texto de bloqueio criado pelo desenvolvedor:\n\n" + str2, "TOT - Erros de execução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        this.preencherBarraStatusPrincipal("");
      }
      catch (Exception ex)
      {
        BLL.erro("", ex.Message);
      }
    }
    else
      BLL.erro("Selecione ao menos um linha / programa para ser executado", "Nenhum programa selecionado");
  }

  private void gerarKanban()
  {
    string str1 = "";
    List<string> source1 = new List<string>(200);
    List<string> source2 = new List<string>(200);
    List<string> source3 = new List<string>(200);
    foreach (DataGridViewRow row in (IEnumerable) this.dgvValidacaoResultado.Rows)
    {
      string str2 = $"    <td>\t\t<div class=\"card\" id='card{row.Cells[0].Value?.ToString()}'>\t\t  <h5 class=\"card-header\"><b>{row.Cells[2].Value?.ToString()}</b><small> > {row.Cells[3].Value?.ToString()} > {row.Cells[4].Value?.ToString()} > {row.Cells["DATA_LIMITE"].Value?.ToString()}</small></h5>\t\t  <div class=\"card-body\">\t\t\t<h5 class=\"card-title\">{row.Cells["RESPONSAVEL"].Value?.ToString()}</h5>\t\t\t<p class=\"card-text\">{row.Cells["DEMANDAS_PARA_DESENVOLVIMENTOS"].Value?.ToString()}</p>            <button type=\"button\" class=\"btn btn-secondary position-relative\" onclick=\"document.getElementById('card{row.Cells["ID"].Value?.ToString()}').style.display = 'none';\">              Vigência: {row.Cells["VIGENCIA"].Value?.ToString()}              <span class=\"position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger\">{row.Cells["ID"].Value?.ToString()}              </span>            </button>\t\t  </div>\t\t  <div class=\"card-footer text-muted text-right\"><I>{row.Cells["PENDENCIAS_OBSERVACOES"].Value?.ToString()}\t\t  </I></div>\t\t</div>\t\t</td>";
      if (row.Cells["STATUS"].Value.ToString() == "PENDENTE")
      {
        string str3 = str2;
        source1.Add(str3);
      }
      if (row.Cells["STATUS"].Value.ToString() == "EM ANDAMENTO")
      {
        string str4 = str2.Replace("bg-danger", "bg-warning");
        source2.Add(str4);
      }
      if (row.Cells["STATUS"].Value.ToString() == "CONCLUÍDO")
      {
        string str5 = str2.Replace("bg-danger", "bg-success");
        source3.Add(str5);
      }
      if (row.Cells["STATUS"].Value.ToString() == "CONCLUIDO")
      {
        string str6 = str2.Replace("bg-danger", "bg-success");
        source3.Add(str6);
      }
    }
    Decimal num1 = (Decimal) source1.Count<string>();
    Decimal num2 = (Decimal) source2.Count<string>();
    Decimal num3 = (Decimal) source3.Count<string>();
    Decimal num4 = Math.Round(num1 / (num1 + num2 + num3) * 100M, 0);
    Decimal num5 = Math.Round(num2 / (num1 + num2 + num3) * 100M, 0);
    Decimal num6 = Math.Round(num3 / (num1 + num2 + num3) * 100M, 0);
    for (int index = 0; (Decimal) index < num2 + num3 + num1; ++index)
    {
      string str7 = str1 + "<tr>";
      string str8 = !((Decimal) index < num1) ? str7 + "<td></td>" : str7 + source1[index].ToString();
      string str9 = !((Decimal) index < num2) ? str8 + "<td></td>" : str8 + source2[index].ToString();
      str1 = $"{(!((Decimal) index < num3) ? str9 + "<td></td>" : str9 + source3[index].ToString())}</tr>{Environment.NewLine}";
    }
    string str10 = $"<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"><meta charset=\"UTF-8\"><link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css\" integrity=\"sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm\" crossorigin=\"anonymous\"><script src=\"https://code.jquery.com/jquery-3.2.1.slim.min.js\" integrity=\"sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN\" crossorigin=\"anonymous\"></script><script src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js\" integrity=\"sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q\" crossorigin=\"anonymous\"></script><script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js\" integrity=\"sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl\" crossorigin=\"anonymous\"></script><style>* {{  box-sizing: border-box;  font-family: Calibri;  font-size: 13px;}}#myInput1,#myInput2,#myInput3 {{  width: 100%;  font-size: 16px;  padding: 12px 12px 12px 12px;  border: 1px solid #ddd;  margin-bottom: 12px;}}#myTable {{  border-collapse: collapse;  width: 100%;  border: 0px solid #fff;  font-size: 17px;}}#myTable th, #myTable td {{  text-align: left;  vertical-align: top;  padding: 10px;}}#myTable tr {{  border-bottom: 0px solid #ddd;}}#myTable tr.header, #myTable;}}</style></head><body><h4>&nbsp;&nbsp;Gerência de Remuneração Variável</h4><h6>&nbsp;&nbsp;Gestão de desenvolvimentos e implantação de regras - Coordenação RV B2B</h6><hr /><table id=\"myTable\">  <tr class=\"header\">    <th style='padding: 25px;'><div class=\"progress\">  <div class=\"progress-bar bg-danger progress-bar-striped progress-bar-animated\" role=\"progressbar\" style=\"width: {num4.ToString()}%;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">{num4.ToString()}%</div></div></th>    <th style='padding: 25px;'><div class=\"progress\">  <div class=\"progress-bar bg-warning progress-bar-striped progress-bar-animated\" role=\"progressbar\" style=\"width: {num5.ToString()}%;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">{num5.ToString()}%</div></div></th>    <th style='padding: 25px;'><div class=\"progress\">  <div class=\"progress-bar bg-success progress-bar-striped progress-bar-animated\" role=\"progressbar\" style=\"width: {num6.ToString()}%;\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\">{num6.ToString()}%</div></div></th>  </tr>  <tr class=\"header\">    <th style=\"width:33%;\"><input type=\"text\" id=\"myInput1\" onkeyup=\"myFunction(0, this)\" placeholder=\"PENDENTE [{num1.ToString()}]\" title=\"Digite uma parte do texto que procura\"></th>    <th style=\"width:33%;\"><input type=\"text\" id=\"myInput2\" onkeyup=\"myFunction(1, this)\" placeholder=\"EM DESENVOLVIMENTO [{num2.ToString()}]\" title=\"Digite uma parte do texto que procura\"></th>\t<th style=\"width:33%;\"><input type=\"text\" id=\"myInput3\" onkeyup=\"myFunction(2, this)\" placeholder=\"CONCLUÍDO [{num3.ToString()}]\" title=\"Digite uma parte do texto que procura\"></th>  </tr>";
    string str11 = "</table><script>function myFunction(posicao, objeto) {  var input, filter, table, tr, td, i, txtValue;  input = document.getElementById(objeto.id);  filter = input.value.toUpperCase();  table = document.getElementById(\"myTable\");  tr = table.getElementsByTagName(\"tr\");\t  for (i = 0; i < tr.length; i++) {\t\ttd = tr[i].getElementsByTagName(\"td\")[posicao];\t\tif (td) {\t\t  txtValue = td.textContent || td.innerText;\t\t  if (txtValue.toUpperCase().indexOf(filter) > -1) {\t\t\ttr[i].style.display = \"\";\t\t  } else {\t\t\ttr[i].style.display = \"none\";\t\t  }\t\t}\t\t  }}</script></body></html>";
    if (string.IsNullOrWhiteSpace(BLL.celulaAtual))
      return;
    File.WriteAllText("C:\\Temp\\kanban.html", str10 + str1 + str11);
    Process.Start("C:\\Temp\\kanban.html");
  }

  private void cmsAjustarColuna_Click(object sender, EventArgs e)
  {
    if (this.dgvValidacaoResultado.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.AllCells)
    {
      this.dgvValidacaoResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
      this.cmsAjustarColuna.Text = "Auto ajustar colunas: Não";
      this.dgvValidacaoResultado.RowHeadersVisible = true;
    }
    else
    {
      this.dgvValidacaoResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      this.cmsAjustarColuna.Text = "Auto ajustar colunas: Sim";
      this.dgvValidacaoResultado.RowHeadersVisible = false;
    }
  }

  private void cmsCmbOperadores_SelectedIndexChanged(object sender, EventArgs e)
  {
    this.cmsTextoFiltrar.Focus();
    if (!this.cmsCmbOperadores.Text.ToString().Equals("Entre"))
      return;
    this.preencherBarraStatusPrincipal("Para usar o filtro \"Entre\", separe os valores inicial e final com \"ponto e vírgula\". Exemplo: para filtrar valores entre 1 e 10 informe: 1;10", true);
  }

  private void cmsAtualizaVolumetriaInsumos_Click(object sender, EventArgs e)
  {
    try
    {
      string str = this.dgvValidacaoResultado.Rows[0].Cells["PERIODO"].Value.ToString();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_CRONOGRAMA_INSUMOS T1 SET(VOLUMETRIA, VARIACAO_VOLUMETRIA) = (SELECT REPLACE(T2.REALIZADO, '.', '') * 1, T2.VARIACAO FROM GVDW_OWNER.VW_RV_B2B_DATAQUALITY3 T2 WHERE TO_CHAR(T2.PERIODO) = TO_CHAR(T1.PERIODO, 'YYYYMM')  AND 'GVDW_OWNER.' || T2.INSUMO = T1.TABELA_ORACLE  AND T2.CENARIO = 'VOLUMETRIA')  WHERE TO_CHAR(T1.PERIODO,'YYYYMM') = TO_CHAR(TO_DATE('{str.Substring(0, 10)}','DD/MM/YYYY'),'YYYYMM')", alteracao: true);
      if (dataTable2 == null)
        return;
      if (dataTable2.Columns.Contains("errotot"))
        BLL.erro("Ocorreu o seguinte erro ao tentar atualizar o status da volumetria: " + dataTable2.Rows[0][0].ToString());
      if (dataTable2.Columns.Contains("nu_registros"))
      {
        int num = (int) MessageBox.Show("Total de registros atualizados: " + dataTable2.Rows[0][0].ToString(), "TOT - Atualização volumetria", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Ocorreu o seguinte erro ao tentar atualizar o status da volumetria: ", ex.Message);
    }
  }

  private void dgvValidacaoResultado_DoubleClick(object sender, EventArgs e)
  {
    try
    {
      if (string.IsNullOrEmpty(DAL._tabelaAtual))
        return;
      DataGridView dataGridView = new DataGridView();
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      string str1 = "";
      string headerText = validacaoResultado.Columns[validacaoResultado.CurrentCell.ColumnIndex].HeaderText;
      string fileName = DAL.PegarValorParametro("URL_HOMOLOG_SHAREPOINT");
      string str2 = validacaoResultado.CurrentCell.Value.ToString();
      string urlEvidencias = "URL_HOMOLOG_SHAREPOINT";
      if (str2.ToUpper().IndexOf("B2C") > 0)
      {
        fileName = DAL.PegarValorParametro("URL_HOMOLOG_SHAREPOINT_B2C");
        urlEvidencias = "URL_HOMOLOG_SHAREPOINT_B2C";
      }
      switch (DAL._tabelaAtual)
      {
        case "GVDW_OWNER.RV_B2B_CRONOGRAMA_INSUMOS":
          string str3 = this.dgvValidacaoResultado.Rows[this.dgvValidacaoResultado.CurrentCell.RowIndex].Cells["TABELA_ORACLE"].Value.ToString();
          str1 = this.dgvValidacaoResultado.Rows[this.dgvValidacaoResultado.CurrentCell.RowIndex].Cells["PERIODO"].Value.ToString();
          frmEstatisticas frmEstatisticas = new frmEstatisticas();
          DAL._tabelaAtualaAux = str3.Replace("GVDW_OWNER.", "").Replace("#", "");
          frmEstatisticas.Show();
          frmEstatisticas.MaximizeBox = true;
          break;
        case "GVDW_OWNER.RV_B2B_CONTROLE_DEMANDAS":
          string str4 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["EVIDENCIAS_HOMOLOG"].Value.ToString();
          string str5 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
          string str6 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["VIGENCIA"].Value.ToString();
          if (headerText.Equals("EVIDENCIAS_HOMOLOG"))
          {
            if (str4.Length < 5)
            {
              int num = (int) MessageBox.Show("Sem informação do local onde estão as evidências.", "TOT - Evidências validação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
              DialogResult dialogResult = MessageBox.Show($"O TOT pode tentar abrir esta URL, mas por questões de segurança não é possível saber se o endereço é de uma pasta válida.\n\nDeseja acessar {fileName}  ?\n\nCaso a pasta {str5} ainda não exista, basta criá-la pelo Sharepoint, clicando em 'Novo > Pasta'", "TOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
              this.criarPastaLocalSharepoint($"{str6}\\{str5}", urlEvidencias);
              if (dialogResult.Equals((object) DialogResult.OK))
                Process.Start(fileName);
            }
            break;
          }
          break;
        case "GVDW_OWNER.RV_B2B_VALIDA_RESULT":
          this.selecionaNode(this.dgvValidacaoResultado.CurrentRow.Cells["NM_TABELA"].Value.ToString(), this.tvwValidacaoResultado);
          break;
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Ixi, alguma coisa deu errado ao clicar duas vezes na célulo.\nInforme a mensagem de erro abaixo para o responsável pelo TOT.", ex.Message);
    }
  }

  private void cmsApenasGerarInformativo_Click(object sender, EventArgs e)
  {
    this.gerarInformativoExcel();
  }

  private void cmsGerarEnviarInformativoParaMim_Click(object sender, EventArgs e)
  {
    this.gerarInformativoExcel(1);
  }

  private void cmsGerarEnviarInformativosParaColaboradores_Click(object sender, EventArgs e)
  {
    this.gerarInformativoExcel(2);
  }

  private void cmsFiltrarEntre_Click(object sender, EventArgs e)
  {
    this.dgvFiltrosValidacaoResultado.Rows[this.dgvFiltrosValidacaoResultado.CurrentCell.RowIndex].Cells[2].Value = (object) $"{this.cmsTxFiltroInicial.Text.ToString()};{this.cmsTxFiltroFinal.ToString()}";
    this.dgvFiltrosValidacaoResultado.Rows[this.dgvFiltrosValidacaoResultado.CurrentCell.RowIndex].Cells[1].Value = (object) "Entre";
  }

  private void cmsAdicionarFiltrosEPesquisar_Click(object sender, EventArgs e)
  {
    this.cmsAdicionarFiltros.PerformClick();
    this.btnPesquisarValidacaoResultado.PerformClick();
  }

  private void cmsAdicionarFiltrosEPesquisarEEditar_Click(object sender, EventArgs e)
  {
    this.cmsAdicionarFiltros.PerformClick();
    this.btnPesquisarEditar.PerformClick();
  }

  private void cmsCmbOperadores_Click(object sender, EventArgs e)
  {
  }

  private void cmsAbrirTextoEmOutraJanela_Click(object sender, EventArgs e)
  {
    try
    {
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      BLL._textoZoom = validacaoResultado.CurrentCell.Value.ToString();
      Form form = (Form) new frmZoomTexto();
      form.StartPosition = FormStartPosition.CenterScreen;
      int num1 = (int) form.ShowDialog();
      if (validacaoResultado.CurrentCell.Value.ToString() != BLL._textoZoom)
      {
        if (!this.dgvValidacaoResultado.ReadOnly)
        {
          validacaoResultado.CurrentCell.Value = (object) BLL._textoZoom;
          validacaoResultado.BeginEdit(true);
          SendKeys.Send("{TAB}");
        }
        else
        {
          BLL.copiarParaAreaDeTransferencia(BLL._textoZoom);
          int num2 = (int) MessageBox.Show("A sua consulta NÃO está em modo de edição. Seu texto foi copiado e está na área de transferência.\n\nVocê ainda pode colar agora em um arquivo para tentar utilizar mais tarde, após rodar uma nova consulta em modo de edição.", "TOT - Tabela bloqueada para edição", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      BLL._textoZoom = "";
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao abrir texto em outra janela", ex.Message);
    }
  }

  private void btnAdicionarLinhas_Click(object sender, EventArgs e)
  {
    if (!this.tabelaEditavel())
    {
      BLL.erro("Esta tabela está bloqueada para edição.\nPeça liberação para seu gestor.\n", "Tabela bloqueada para edição pelo Gestor da área.");
    }
    else
    {
      try
      {
        this.cmsLimparFiltroColuna.PerformClick();
        bool flag = false;
        DataGridView validacaoResultado = this.dgvValidacaoResultado;
        DataTable dataSource = (DataTable) validacaoResultado.DataSource;
        foreach (DataGridViewColumn column in (BaseCollection) validacaoResultado.Columns)
        {
          if (!column.HeaderCell.SortGlyphDirection.Equals((object) SortOrder.None))
            flag = true;
        }
        if (!flag)
          ;
        if (validacaoResultado.Rows.Count <= 0)
        {
          BLL.erro("Antes de tentar inserir uma linha você precisa executar uma consulta.", "Não é possível inserir linhas em uma consulta vazia.");
        }
        else
        {
          if (!dataSource.Columns.Contains("INDICE_NOVA_LINHA"))
            dataSource.Columns.Add("INDICE_NOVA_LINHA", typeof (int));
          dataSource.Rows.Add();
          int index = validacaoResultado.Rows.Count - 1;
          validacaoResultado.Rows[index].Cells["INDICE_NOVA_LINHA"].Value = (object) "1";
          validacaoResultado.FirstDisplayedScrollingRowIndex = index;
          validacaoResultado.Rows[index].DefaultCellStyle.BackColor = Color.LightBlue;
          string str = "";
          foreach (DataColumn column in (InternalDataCollectionBase) dataSource.Columns)
            str = $"{str}{column.ColumnName.ToString()},";
          int count = validacaoResultado.Columns.Count;
          validacaoResultado.Columns[count - 1].HeaderCell.SortGlyphDirection = SortOrder.Descending;
          this.btnSalvarNovasLinhas.Enabled = true;
        }
      }
      catch (Exception ex)
      {
        this.ativarBotoesEdicao(false);
        BLL.erro("Erro ao tentar adicionar linhas", ex.Message);
      }
    }
  }

  private void cmsInserirLinha_Click(object sender, EventArgs e)
  {
    this.btnAdicionarLinhas.PerformClick();
  }

  private void teste()
  {
  }

  private void cmsHomolog_Click(object sender, EventArgs e)
  {
  }

  private void cmsGraficoVariacao_Click(object sender, EventArgs e)
  {
    try
    {
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      this.volumetriaTabelas(validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["CENARIO"].Value.ToString());
    }
    catch (Exception ex)
    {
      BLL.erro(ex.Message);
    }
  }

  private void tsmGerarInformativo_Click(object sender, EventArgs e)
  {
    this.gerarInformativoLocal(0);
  }

  private void atualizaStatusVolumetriaCronograma(string periodo)
  {
    if (string.IsNullOrWhiteSpace(BLL.celulaAtual))
      return;
    DataGridView validacaoResultado1 = this.dgvValidacaoResultado;
    periodo = periodo.Substring(6, 4) + periodo.Substring(3, 2);
    try
    {
      DataTable dataTable = DAL.PegarDadosTOT($"SELECT distinct 'GVDW_OWNER.'||INSUMO INSUMO, VARIACAO, FAIXA FROM GVDW_OWNER.VW_RV_B2B_DATAQUALITY3 WHERE PERIODO = '{periodo}' AND UPPER(CENARIO) = 'VOLUMETRIA'");
      DataGridView validacaoResultado2 = this.dgvValidacaoResultado;
      Color color = BLL.CorTransparente;
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        for (int index = 0; index < validacaoResultado2.Rows.Count; ++index)
        {
          if (row["INSUMO"].ToString().Equals(validacaoResultado2.Rows[index].Cells["TABELA_ORACLE"].Value.ToString()))
          {
            DataGridViewCell cell1 = validacaoResultado2.Rows[index].Cells["INSUMO"];
            cell1.Value = (object) $"{cell1.Value?.ToString()}    {row["VARIACAO"].ToString()}%";
            DataGridViewCell cell2 = validacaoResultado2.Rows[index].Cells["TABELA_ORACLE"];
            cell2.Value = (object) (cell2.Value?.ToString() + "#");
            switch (row["FAIXA"].ToString())
            {
              case "0 - 5%":
                color = BLL.CorCinzaClaro;
                break;
              case "5 - 10%":
                color = BLL.CorVerde;
                break;
              case "10 - 15%":
                color = BLL.CorAmarela;
                break;
              case "15 - 20%":
                color = Color.Orange;
                break;
              case "20 - 25%":
                color = BLL.CorVermelha;
                break;
              case "> 25%":
                color = BLL.CorVermelha;
                break;
            }
            validacaoResultado2.Rows[index].Cells["INSUMO"].Style.BackColor = color;
          }
        }
      }
      if (dataTable != null && dataTable.Rows.Count.Equals(1))
      {
        int num = (int) MessageBox.Show("Variação: " + dataTable.Rows[0]["VARIACAO"].ToString());
      }
    }
    catch (Exception ex)
    {
      BLL.erro(ex.Message);
    }
  }

  private void atualizaCampoVolumetriaCronograma(string periodo)
  {
    if (string.IsNullOrWhiteSpace(BLL.celulaAtual))
      return;
    DataGridView validacaoResultado1 = this.dgvValidacaoResultado;
    periodo = periodo.Substring(6, 4) + periodo.Substring(3, 2);
    try
    {
      DataTable dataTable = DAL.PegarDadosTOT($"SELECT distinct 'GVDW_OWNER.'||INSUMO INSUMO, VARIACAO, FAIXA FROM GVDW_OWNER.VW_RV_B2B_DATAQUALITY3 WHERE PERIODO = '{periodo}' AND UPPER(CENARIO) = 'VOLUMETRIA'");
      DataGridView validacaoResultado2 = this.dgvValidacaoResultado;
      Color color = BLL.CorTransparente;
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        for (int index = 0; index < validacaoResultado2.Rows.Count; ++index)
        {
          if (row["INSUMO"].ToString().Equals(validacaoResultado2.Rows[index].Cells["TABELA_ORACLE"].Value.ToString()))
          {
            DataGridViewCell cell1 = validacaoResultado2.Rows[index].Cells["INSUMO"];
            cell1.Value = (object) $"{cell1.Value?.ToString()}    {row["VARIACAO"].ToString()}%";
            DataGridViewCell cell2 = validacaoResultado2.Rows[index].Cells["TABELA_ORACLE"];
            cell2.Value = (object) (cell2.Value?.ToString() + "#");
            switch (row["FAIXA"].ToString())
            {
              case "0 - 5%":
                color = BLL.CorCinzaClaro;
                break;
              case "5 - 10%":
                color = BLL.CorVerde;
                break;
              case "10 - 15%":
                color = BLL.CorAmarela;
                break;
              case "15 - 20%":
                color = Color.Orange;
                break;
              case "20 - 25%":
                color = BLL.CorVermelha;
                break;
              case "> 25%":
                color = BLL.CorVermelha;
                break;
            }
            validacaoResultado2.Rows[index].Cells["INSUMO"].Style.BackColor = color;
          }
        }
      }
      if (dataTable != null && dataTable.Rows.Count.Equals(1))
      {
        int num = (int) MessageBox.Show("Variação: " + dataTable.Rows[0]["VARIACAO"].ToString());
      }
    }
    catch (Exception ex)
    {
      BLL.erro(ex.Message);
    }
  }

  private void groupBox3_Enter(object sender, EventArgs e)
  {
  }

  private void CheckKeyword(string word, Color color, int startIndex)
  {
    this.ForeColor = Color.Black;
    if (!this.rtbSQL.Text.Contains(word))
      return;
    int num = -1;
    int selectionStart = this.rtbSQL.SelectionStart;
    while ((num = this.rtbSQL.Text.IndexOf(word, num + 1)) != -1)
    {
      this.rtbSQL.Select(num + startIndex, word.Length);
      this.rtbSQL.SelectionColor = color;
      this.rtbSQL.Select(selectionStart, 0);
      this.rtbSQL.SelectionColor = Color.Black;
    }
  }

  private void rtbSQL_TextChanged(object sender, EventArgs e)
  {
    this.rtbSQL.SelectionColor = Color.Black;
    this.rtbSQL.ForeColor = Color.Black;
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, "ELECT", Color.Blue);
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, " IN ", Color.Blue);
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, "FROM", Color.Blue);
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, "WHERE", Color.Blue);
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, "AND", Color.Blue);
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, "JOIN", Color.Blue);
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, "LEFT", Color.Blue);
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, "RIGHT", Color.Blue);
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, "SUBSTR", Color.Blue);
    frmConsultaBancos.HighlightPhrase(this.rtbSQL, "TO_CHAR", Color.Blue);
  }

  private static void HighlightPhrase(RichTextBox box, string phrase, Color color)
  {
    box.ForeColor = Color.Black;
    int selectionStart = box.SelectionStart;
    string text = box.Text;
    int startIndex = 0;
    while (true)
    {
      int num = text.IndexOf(phrase, startIndex, StringComparison.CurrentCultureIgnoreCase);
      if (num >= 0)
      {
        box.SelectionStart = num;
        box.SelectionLength = phrase.Length;
        box.SelectionColor = color;
        startIndex = num + 1;
      }
      else
        break;
    }
    box.SelectionStart = selectionStart;
    box.SelectionLength = 0;
  }

  private void cmbSegmentos_SelectedValueChanged(object sender, EventArgs e)
  {
  }

  private void cmbSegmentos_MouseUp(object sender, MouseEventArgs e)
  {
  }

  private void cmbSegmentos_SelectionChangeCommitted(object sender, EventArgs e)
  {
    DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
    for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
    {
      if (validacaoResultado.Rows[index].Cells[0].Value.Equals((object) "ID_SEGMENTO"))
      {
        validacaoResultado.Rows[index].Cells[1].Value = (object) "Igual a";
        validacaoResultado.Rows[index].Cells[2].Value = (object) this.cmbSegmentos.SelectedValue.ToString();
        validacaoResultado.Rows[index].DefaultCellStyle.BackColor = BLL.CorAmarela;
        validacaoResultado.FirstDisplayedScrollingRowIndex = index;
        break;
      }
    }
  }

  private void executarFiltroComboEmediatamente(ComboBox cb, string campo, string tipoFiltro = "Igual a")
  {
    try
    {
      DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
      string s = cb.SelectedValue.ToString();
      if (s.IndexOf(" a ") > -1)
      {
        tipoFiltro = "Entre";
        s = s.Replace(" a ", ";").Replace("_", "");
      }
      if (DateTime.TryParse(s, out DateTime _))
        s = s.Substring(0, 10);
      for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
      {
        if (validacaoResultado.Rows[index].Cells[0].Value.Equals((object) campo))
        {
          validacaoResultado.Rows[index].Cells[1].Value = (object) tipoFiltro;
          validacaoResultado.Rows[index].Cells[2].Value = (object) s;
          validacaoResultado.Rows[index].DefaultCellStyle.BackColor = BLL.CorAmarela;
          validacaoResultado.FirstDisplayedScrollingRowIndex = index;
          this.btnPesquisarValidacaoResultado.PerformClick();
          break;
        }
      }
    }
    catch (Exception ex)
    {
      BLL.erro($"Falha ao tentar filtrar pelo combo {cb.Name.ToString()}.", ex.Message);
    }
  }

  private void formatarTituloColunaFiltrada()
  {
    try
    {
      DataGridView validacaoResultado1 = this.dgvFiltrosValidacaoResultado;
      DataGridView validacaoResultado2 = this.dgvValidacaoResultado;
      validacaoResultado2.EnableHeadersVisualStyles = false;
      for (int index = 0; index < validacaoResultado1.Rows.Count; ++index)
      {
        if (validacaoResultado2.Columns.Contains(validacaoResultado1.Rows[index].Cells[0].Value.ToString()) && validacaoResultado1.Rows[index].Cells[1].Value.ToString().Length > 0)
        {
          this.dgvValidacaoResultado.Columns[index].HeaderCell.Style.BackColor = BLL.CorAmarela;
          validacaoResultado2.Columns[index].HeaderCell.Style.ForeColor = Color.Blue;
        }
        else
        {
          validacaoResultado2.Columns[index].HeaderCell.Style.BackColor = Color.Empty;
          validacaoResultado2.Columns[index].HeaderCell.Style.ForeColor = Color.Empty;
        }
      }
    }
    catch (Exception ex)
    {
      this.preencherBarraStatusPrincipal(ex.Message);
    }
  }

  private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void cmbPeriodo_SelectionChangeCommitted(object sender, EventArgs e)
  {
    DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
    for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
    {
      if (validacaoResultado.Rows[index].Cells[0].Value.Equals((object) "PERIODO"))
      {
        validacaoResultado.Rows[index].Cells[1].Value = (object) "Igual a";
        validacaoResultado.Rows[index].Cells[2].Value = (object) this.cmbPeriodo.SelectedValue.ToString();
        validacaoResultado.Rows[index].DefaultCellStyle.BackColor = BLL.CorAmarela;
        validacaoResultado.FirstDisplayedScrollingRowIndex = index;
        break;
      }
    }
  }

  private void btnExecutarProgramas_Click(object sender, EventArgs e)
  {
    this.executarProgramasCalculo();
  }

  private void btnBloquearTodosProgramas_Click(object sender, EventArgs e)
  {
    this.mudarStatusProgramas();
  }

  private void btnLiberarTodosProgramas_Click(object sender, EventArgs e)
  {
    this.mudarStatusProgramas(false);
  }

  private void mudarStatusProgramas(bool bloquear = true)
  {
    DataGridView dataGridView = new DataGridView();
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    string str1 = "";
    string str2 = "";
    int num1 = 0;
    int num2 = 0;
    DataTable dataTable = new DataTable();
    for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
    {
      if (validacaoResultado.Rows[index].Selected)
      {
        string str3 = validacaoResultado.Rows[index].Cells["DESCRICAO_BLOQUEIO"].Value.ToString();
        str1 = validacaoResultado.Rows[index].Cells["PROGRAMA"].Value.ToString();
        str2 = validacaoResultado.Rows[index].Cells["PERIODO"].Value.ToString();
        string str4 = validacaoResultado.Rows[index].Cells["ID"].Value.ToString();
        ++num2;
        if (bloquear)
        {
          if (string.IsNullOrEmpty(str3))
          {
            dataTable = DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_ORDEM_PROCESS SET DESCRICAO_BLOQUEIO = 'Bloqueado' WHERE ID = '{str4}' ", alteracao: true);
            ++num1;
          }
        }
        else if (!string.IsNullOrEmpty(str3))
        {
          dataTable = DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_ORDEM_PROCESS SET DESCRICAO_BLOQUEIO = '' WHERE ID = '{str4}' ", alteracao: true);
          ++num1;
        }
      }
    }
    if (num2 <= 0)
      return;
    int num3 = (int) MessageBox.Show($"Total de programas atualizados: {num1.ToString()}\n\nAtualize a consulta para carregar o status de bloqueio dos programas.", "TOT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
  }

  private void btnDocumentacaoPrograma1_Click(object sender, EventArgs e)
  {
  }

  private void gerarDocumentacaoHTML(string textoHTML, string programa = null)
  {
    DataTable dataTable1 = new DataTable();
    try
    {
      this.preencherBarraStatusPrincipal($"Gerando documentação do programa {programa}...");
      DataTable dataTable2 = DAL.PegarDadosTOT($"SELECT OWNER, NAME, TYPE, LINE, TEXT FROM ALL_SOURCE WHERE NAME = '{programa}' ORDER BY LINE");
      if (dataTable2.Equals((object) null))
        throw new InvalidOperationException($"É provável que você não tenha grant de execução no programa {programa}. Verifique com os responsáveis pelo banco Oracle da sua área");
      string str1 = "";
      string str2 = "";
      string str3 = dataTable2.Rows[0]["OWNER"].ToString();
      string str4 = dataTable2.Rows.Count.ToString();
      string str5 = "";
      int num = 0;
      for (int index = 0; index < dataTable2.Rows.Count; ++index)
      {
        string str6 = dataTable2.Rows[index]["TEXT"].ToString();
        str1 = $"{str1}{dataTable2.Rows[index]["TEXT"].ToString()}<br />";
        string str7 = dataTable2.Rows[index]["LINE"].ToString();
        if (str6.IndexOf("--") > -1)
        {
          int startIndex = str6.IndexOf("--");
          string oldValue = str6.Substring(startIndex);
          str6 = str6.Replace(oldValue, $"<del><i>{oldValue}</i></del>");
        }
        str2 = $"{str2}\n<p><span class=\"badge bg-light\"><small style='color: grey;'>{str7}</small></span> {str6}</p>";
      }
      StringBuilder stringBuilder1 = new StringBuilder(str2.ToLower());
      stringBuilder1.Replace("select", "<font color='blue'>SELECT</font>");
      stringBuilder1.Replace("insert into", "<font color='blue'>INSERT INTO</font>");
      stringBuilder1.Replace(" not like ", "<font color='blue'> NOT LIKE </font>");
      stringBuilder1.Replace("update ", "<font color='blue'>UPDATE </font>");
      stringBuilder1.Replace("from", "<font color='blue'>FROM</font>");
      stringBuilder1.Replace("delete", "<font color='red'>DELETE</font>");
      stringBuilder1.Replace("where", "<font color='blue'>WHERE</font>");
      stringBuilder1.Replace("and", "<font color='blue'>AND</font>");
      stringBuilder1.Replace("when", "<font color='blue'>WHEN</font>");
      stringBuilder1.Replace("case", "<font color='blue'>CASE</font>");
      stringBuilder1.Replace("begin", "<font color='blue'>BEGIN</font>");
      stringBuilder1.Replace("end ", "<font color='blue'>END </font>");
      stringBuilder1.Replace("end;", "<font color='blue'>END;</font>");
      stringBuilder1.Replace("if", "<font color='blue'>IF</font>");
      stringBuilder1.Replace("then", "<font color='blue'>THEN</font>");
      stringBuilder1.Replace("else", "<font color='blue'>ELSE</font>");
      stringBuilder1.Replace("loop", "<font color='blue'>LOOP</font>");
      stringBuilder1.Replace("like ", "<font color='blue'>LIKE </font>");
      stringBuilder1.Replace(" like", "<font color='blue'> LIKE</font>");
      stringBuilder1.Replace("commit", "<font color='orange'>COMMIT</font>");
      stringBuilder1.Replace("procedure ", "<font color='blue'><b>PROCEDURE </b></font>");
      stringBuilder1.Replace("create ", "<font color='red'>CREATE </font>");
      stringBuilder1.Replace("replace ", "<font color='red'>REPLACE </font>");
      stringBuilder1.Replace(" or ", "<font color='blue'> OR </font>");
      stringBuilder1.Replace(" as ", "<font color='blue'> AS </font>");
      stringBuilder1.Replace(" is ", "<font color='blue'> IS </font>");
      stringBuilder1.Replace("exists", "<font color='blue'>EXISTS</font>");
      stringBuilder1.Replace("is ", "<font color='blue'>IS </font>");
      stringBuilder1.Replace(" is", "<font color='blue'> IS</font>");
      stringBuilder1.Replace("is\n", "<font color='blue'>IS\n</font>");
      stringBuilder1.Replace(" in ", "<font color='blue'>IN</font>");
      stringBuilder1.Replace(" nvl(", "<font color='blue'> NVL</font>(");
      stringBuilder1.Replace(" round(", "<font color='blue'> ROUND</font>(");
      stringBuilder1.Replace("distinct ", "<font color='blue'>DISTINCT </font>");
      stringBuilder1.Replace("distinct", "<font color='blue'>DISTINCT</font>");
      stringBuilder1.Replace("group by", "<font color='blue'>GROUP BY</font>");
      stringBuilder1.Replace("lower", "<font color='blue'>LOWER</font>");
      stringBuilder1.Replace("upper", "<font color='blue'>UPPER</font>");
      stringBuilder1.Replace("null", "<font color='blue'>NULL</font>");
      stringBuilder1.Replace("sum(", "<font color='blue'>SUM</font>(");
      stringBuilder1.Replace("max(", "<font color='blue'>MAX</font>(");
      stringBuilder1.Replace("min(", "<font color='blue'>MIN</font>(");
      stringBuilder1.Replace("avg(", "<font color='blue'>AVG</font>(");
      stringBuilder1.Replace("count(", "<font color='blue'>COUNT</font>(");
      stringBuilder1.Replace("to_date(", "<font color='blue'>TO_DATE</font>(");
      stringBuilder1.Replace("to_char(", "<font color='blue'>TO_CHAR</font>(");
      stringBuilder1.Replace("execute immediate", "<font color='orange'>EXECUTE IMMEDIATE</font>");
      stringBuilder1.Replace("/*", "<button type='button' class='btn btn-light position-relative'><i>\n/*");
      stringBuilder1.Replace("*/", "</i>*/<span class=\"position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger\">Comentário<span class=\"visually-hidden\">comentário</span></span></button>");
      StringBuilder stringBuilder2 = new StringBuilder(str2.ToLower());
      stringBuilder2.Replace("select", "<font color='blue'>CONSULTAR</font>");
      stringBuilder2.Replace("insert into", "<font color='blue'>INSERIR REGISTROS NA</font>");
      stringBuilder2.Replace(" not like ", "<font color='blue'> NÃO CONTENHA </font>");
      stringBuilder2.Replace("update ", "<font color='blue'>ATUALIZAR A TABELA </font>");
      stringBuilder2.Replace("from", "<font color='blue'>DA</font>");
      stringBuilder2.Replace("delete", "<font color='red'>APAGAR</font>");
      stringBuilder2.Replace("where", "<font color='blue'>FILTRANDO</font>");
      stringBuilder2.Replace("and", "<font color='blue'>E</font>");
      stringBuilder2.Replace("when", "<font color='blue'>QUANDO</font>");
      stringBuilder2.Replace("case", "<font color='blue'>CASO</font>");
      stringBuilder2.Replace("begin", "<font color='blue'>INÍCIO</font>");
      stringBuilder2.Replace("end ", "<font color='blue'>FIM </font>");
      stringBuilder2.Replace("end;", "<font color='blue'>FIM;</font>");
      stringBuilder2.Replace("if", "<font color='blue'>SE</font>");
      stringBuilder2.Replace("then", "<font color='blue'>ENTÃO</font>");
      stringBuilder2.Replace("else", "<font color='blue'>SENÃO</font>");
      stringBuilder2.Replace("loop", "<font color='blue'>REPETIR</font>");
      stringBuilder2.Replace("like ", "<font color='blue'>CONTENHA </font>");
      stringBuilder2.Replace(" like", "<font color='blue'> CONTENHA</font>");
      stringBuilder2.Replace("commit", "<font color='orange'>SALVAR AS ALTERAÇÕES ACIMA</font>");
      stringBuilder2.Replace("procedure ", "<font color='blue'><b>PROGRAMA </b></font>");
      stringBuilder2.Replace("create ", "<font color='red'>CRIAR </font>");
      stringBuilder2.Replace("replace ", "<font color='red'>SUBSTITUIR </font>");
      stringBuilder2.Replace(" or ", "<font color='blue'> OU </font>");
      stringBuilder2.Replace(" as ", "<font color='blue'> COMO </font>");
      stringBuilder2.Replace("exists", "<font color='blue'>CASO EXISTA</font>");
      stringBuilder2.Replace("not exists", "<font color='blue'>CASO <b>NÃO</b>EXISTA</font>");
      stringBuilder2.Replace("is ", "<font color='blue'>COMO </font>");
      stringBuilder2.Replace(" is", "<font color='blue'> COMO</font>");
      stringBuilder2.Replace("is\n", "<font color='blue'>COMO\n</font>");
      stringBuilder2.Replace(" in ", "<font color='blue'>CONTENHA</font>");
      stringBuilder2.Replace(" nvl(", "<font color='blue'> SE O VALOR FOR NULO</font>(");
      stringBuilder2.Replace(" round(", "<font color='blue'> ARREDONDAR</font>(");
      stringBuilder2.Replace("distinct ", "<font color='blue'>REMOVENDO AS DUPLICADAS </font>");
      stringBuilder2.Replace("distinct", "<font color='blue'>REMOVENDO AS DUPLICADAS</font>");
      stringBuilder2.Replace("group by", "<font color='blue'>AGRUPAR O RESULTADO PELOS CAMPOS</font>");
      stringBuilder2.Replace("lower", "<font color='blue'>MINÚSCULA</font>");
      stringBuilder2.Replace("upper", "<font color='blue'>MÁIÚSCULA</font>");
      stringBuilder2.Replace("null", "<font color='blue'>VALOR NULO</font>");
      stringBuilder1.Replace("sum(", "<font color='blue'>SOMAR</font>(");
      stringBuilder1.Replace("max(", "<font color='blue'>MÁXIMO</font>(");
      stringBuilder1.Replace("min(", "<font color='blue'>MÍNIMO</font>(");
      stringBuilder1.Replace("avg(", "<font color='blue'>MÉDIA</font>(");
      stringBuilder1.Replace("count(", "<font color='blue'>CONTAR</font>(");
      stringBuilder2.Replace("to_date(", "<font color='blue'>CONVERTER PARA DATA</font>(");
      stringBuilder2.Replace("to_char(", "<font color='blue'>CONVERTER PARA TEXTO</font>(");
      stringBuilder2.Replace("execute immediate", "<font color='orange'>EXECUTAR IMEDIATAMENTE</font>");
      stringBuilder2.Replace("/*", "<button type='button' class='btn btn-light position-relative'><i>\n/*");
      stringBuilder2.Replace("*/", "</i>*/<span class=\"position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger\">Comentário<span class=\"visually-hidden\">comentário</span></span></button>");
      DataTable dataTable3 = DAL.PegarDadosTOT($"SELECT * FROM GVDW_OWNER.VW_RV_B2B_DEPENDENCIAS WHERE \"NOME DO OBJETO\" = '{programa}' ORDER BY 3 ");
      for (int index = 0; index < dataTable3.Rows.Count; ++index)
      {
        str5 = $"{str5}<tr>\n<td>{dataTable3.Rows[index]["UTILIZADO POR ESTE OBJETO"].ToString()}</td><td>{dataTable3.Rows[index]["TIPO DO OBJETO UTILIZADO"].ToString()}</td><td>{dataTable3.Rows[index]["QUANT. LINHAS (SE FOR TABELA)"].ToString()}</td></tr>";
        ++num;
      }
      string str8 = $"<div class=\"container\"><div class=\"card\"><div class=\"card-header\"><h6 class=\"card-title\">Esses são os <span class=\"badge bg-primary\">{num.ToString()}</span> objetos utilizados pelo programa <strong>{programa}</strong>:</h6></div><div class=\"card-body\"><p class=\"card-text\"><table class=\"table table-striped table-hover\">\n  <thead>\n    <tr>\n      <th scope=\"col\">Utilizado pelo programa</th>\n      <th scope=\"col\">Tipo de objeto usado</th>\n      <th scope=\"col\">Número de linhas (se for do tipo table)</th>\n    </tr>\n  </thead>\n  <tbody>\n{str5}  </tbody>\n  </table>\n</p></div></div></div>";
      string str9 = $"<div class=\"container\"><div class=\"card\"><div class=\"card-header\"><h6 class=\"card-title\">Programa: <strong>{programa}</strong></h6></div><div class=\"card-body\"><p class=\"card-text\">{str1}</p></div></div></div>";
      textoHTML = $"<html>\n<head>\n<link href = 'https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css' rel = \"stylesheet\" integrity = \"sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65\" crossorigin = \"anonymous\">\n<script src = 'https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js' integrity = \"sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4\" crossorigin = \"anonymous\" ></script>\n</head>\n<body>\n<div class=\"shadow-sm shadow2 border-bottom text-center\" style=\"background-color: #660099; color: #FFFFFF;\">\n    <h5>Remuneração Variável</h5>\n    <h6>Documentação técnica automatizada</h6><br>\n</div>\n<ul class=\"nav nav-tabs mb-3 justify-content-center p-3\" id=\"pills-tab\" role=\"tablist\">\n  <li class=\"nav-item\" role=\"presentation\">\n    <button class=\"nav-link active\" id=\"pills-home-tab\" data-bs-toggle=\"pill\" data-bs-target=\"#pills-home\" type=\"button\" role=\"tab\" aria-controls=\"pills-home\" aria-selected=\"true\">Resumo</button>\n  </li>\n  <li class=\"nav-item\" role=\"presentation\">\n    <button class=\"nav-link\" id=\"pills-profile-tab\" data-bs-toggle=\"pill\" data-bs-target=\"#pills-profile\" type=\"button\" role=\"tab\" aria-controls=\"pills-profile\" aria-selected=\"false\">Código Formatado</button>\n  </li>\n  <li class=\"nav-item\" role=\"presentation\">\n    <button class=\"nav-link\" id=\"pills-negocio-tab\" data-bs-toggle=\"pill\" data-bs-target=\"#pills-negocio\" type=\"button\" role=\"tab\" aria-controls=\"pills-negocio\" aria-selected=\"false\">Código em liguagem de negócio</button>\n  </li>\n  <li class=\"nav-item\" role=\"presentation\">\n    <button class=\"nav-link\" id=\"pills-contact-tab\" data-bs-toggle=\"pill\" data-bs-target=\"#pills-contact\" type=\"button\" role=\"tab\" aria-controls=\"pills-contact\" aria-selected=\"false\">Código fonte original</button>\n  </li>\n  <li class=\"nav-item\" role=\"presentation\">\n    <button class=\"nav-link\" id=\"pills-disabled-tab\" data-bs-toggle=\"pill\" data-bs-target=\"#pills-disabled\" type=\"button\" role=\"tab\" aria-controls=\"pills-disabled\" aria-selected=\"false\">Dependências</button>\n  </li>\n  <!--<li class=\"nav-item\" role=\"presentation\">\n    <button class=\"nav-link\" id=\"pills-dicas-tab\" data-bs-toggle=\"pill\" data-bs-target=\"#pills-dicas\" type=\"button\" role=\"tab\" aria-controls=\"pills-dicas\" aria-selected=\"false\">Ajuda</button>\n  </li>\n//-->   <li class=\"nav-item dropdown\">\n    <a class=\"nav-link dropdown-toggle\" data-bs-toggle=\"dropdown\" href=\"#\" role=\"button\" aria-expanded=\"false\">Ajuda para código</a>\n    <ul class=\"dropdown-menu\">\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_select.asp\" target='_blanck'>SELEC</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_distinct.asp\" target='_blanck'>DISTINCT</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_where.asp\" target='_blanck'>WHERE</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_and_or.asp\" target='_blanck'>AND e OR</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_insert.asp\" target ='_blanck'>INSERT</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_null_values.asp\" target='_blanck'>Valor NULL</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_update.asp\" target='_blanck'>UPDATE</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_delete.asp\" target='_blanck'>DELETE</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_min_max.asp\" target ='_blanck'>MIN e MAX</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_count_avg_sum.asp\" target ='_blanck'>COUNT, AVG e SUM</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_like.asp\" target='_blanck'>LIKE</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_between.asp\" target='_blanck'>BETWEEN</a></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/sql_join.asp\" target='_blanck'>JOIN</a></li>\n      <li><hr class=\"dropdown-divider\"></li>\n      <li><a class=\"dropdown-item\" href=\"https://www.w3schools.com/sql/default.asp\" target='_blanck'>Tutorial SQL</a></li>\n    </ul>\n  </li>\n</ul>\n<div class=\"tab-content\" id=\"pills-tabContent\">\n  <div class=\"tab-pane fade show active\" id=\"pills-home\" role=\"tabpanel\" aria-labelledby=\"pills-home-tab\" tabindex=\"0\">\n<div class=\"container\">\n<table class=\"table table-striped table-hover\" >\n  <thead>\n    <tr>\n      <th scope=\"col\">Programa</th>\n      <th scope=\"col\">Data consulta código</th>\n      <th scope=\"col\">Proprietário</th>\n      <th scope=\"col\">Quantidade de linhas de código</th>\n    </tr>\n  </thead>\n  <tbody>\n    <tr>\n      <th>{programa}</th>\n      <td>{DateTime.Now.ToString()}</td>\n      <td>{str3}</td>\n      <td>{str4}</td>\n    </tr>\n  </tbody>\n</table>\n</div>\n</div>\n  <div class=\"tab-pane fade\" id=\"pills-profile\" role=\"tabpanel\" aria-labelledby=\"pills-profile-tab\" tabindex=\"0\"><div class=\"container\">\n<div class=\"alert alert-warning alert-dismissible fade show\" role=\"alert\">Este é o código-fonte do programa: <strong>{programa}</strong>. Caso encontre dúvidas sobre os códigos ou comentários procure um dos técnicos de sua área. Obs. o sinal em uma linha -- significa que o conteúdo do código é ignorado pelo sistema, ou seja não possui efeito no programa<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button></div><br /><div class=\"card\"><div class=\"card-body\">{stringBuilder1.ToString()}</div>\n</div>\n</div>\n</div>\n  <div class=\"tab-pane fade\" id=\"pills-negocio\" role=\"tabpanel\" aria-labelledby=\"pills-negocio-tab\" tabindex=\"0\"><div class=\"container\">\n<div class=\"alert alert-warning alert-dismissible fade show\" role=\"alert\">Este é o código-fonte <u>traduzido</u> do programa: <strong>{programa}</strong>. Caso encontre dúvidas sobre os códigos ou comentários procure um dos técnicos de sua área. Obs. o sinal em uma linha -- significa que o conteúdo do código é ignorado pelo sistema, ou seja não possui efeito no programa<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button></div><br /><div class=\"card\"><div class=\"card-body\">{stringBuilder2.ToString()}</div>\n</div>\n</div>\n</div>\n  <div class=\"tab-pane fade\" id=\"pills-contact\" role=\"tabpanel\" aria-labelledby=\"pills-contact-tab\" tabindex=\"0\">{str9}</div>\n  <div class=\"tab-pane fade\" id=\"pills-disabled\" role=\"tabpanel\" aria-labelledby=\"pills-disabled-tab\" tabindex=\"0\">{str8}</div>\n</div>\n</div>\n</div>\n</div>\n</body>\n</html>";
      File.WriteAllText($"C:\\Temp\\Documentacao_do_programa_{programa}.html", textoHTML);
      Process.Start($"C:\\Temp\\Documentacao_do_programa_{programa}.html");
      this.preencherBarraStatusPrincipal("");
    }
    catch (Exception ex)
    {
      BLL.erro("Ocorreu o seguinte erro ao tentar gerar a documentação:", ex.Message);
      this.preencherBarraStatusPrincipal("");
    }
  }

  private DataTable importarPlanilha(string arquivo)
  {
    // ISSUE: variable of a compiler-generated type
    Microsoft.Office.Interop.Excel.Application instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
    if (instance == null)
    {
      Console.WriteLine("Excel is not installed!!");
      return (DataTable) null;
    }
    // ISSUE: reference to a compiler-generated method
    // ISSUE: variable of a compiler-generated type
    Workbook workbook = instance.Workbooks.Open(arquivo, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
    // ISSUE: reference to a compiler-generated field
    if (frmConsultaBancos.\u003C\u003Eo__159.\u003C\u003Ep__0 == null)
    {
      // ISSUE: reference to a compiler-generated field
      frmConsultaBancos.\u003C\u003Eo__159.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, _Worksheet>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (_Worksheet), typeof (frmConsultaBancos)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: variable of a compiler-generated type
    _Worksheet worksheet = frmConsultaBancos.\u003C\u003Eo__159.\u003C\u003Ep__0.Target((CallSite) frmConsultaBancos.\u003C\u003Eo__159.\u003C\u003Ep__0, workbook.Sheets[(object) 1]);
    // ISSUE: variable of a compiler-generated type
    Microsoft.Office.Interop.Excel.Range usedRange = worksheet.UsedRange;
    int count1 = usedRange.Rows.Count;
    int count2 = usedRange.Columns.Count;
    DataTable dataTable = new DataTable("MyDataTable");
    // ISSUE: reference to a compiler-generated method
    instance.Quit();
    Marshal.ReleaseComObject((object) instance);
    Console.ReadLine();
    return dataTable;
  }

  private void button2_Click(object sender, EventArgs e)
  {
  }

  private string demandasCalendario()
  {
    string str1 = "";
    string str2 = "";
    string str3 = "#228B22";
    string str4 = "#FF0000";
    string str5 = "#FF8C00";
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    int num1 = 0;
    if (!DAL._tabelaAtual.Equals("GVDW_OWNER.RV_B2B_CONTROLE_DEMANDAS"))
      return (string) null;
    int rowCount = validacaoResultado.RowCount;
    for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
    {
      string str6 = validacaoResultado["DATA_LIMITE", rowIndex].Value.ToString();
      string str7 = validacaoResultado["DATA_INI_DESENV", rowIndex].Value.ToString();
      string str8 = validacaoResultado["ID", rowIndex].Value.ToString();
      if (!string.IsNullOrEmpty(str6))
      {
        string str9 = validacaoResultado["DATA_CONCLUSAO", rowIndex].Value.ToString();
        string str10 = validacaoResultado["RESPONSAVEL", rowIndex].Value.ToString();
        string str11 = validacaoResultado["SEGMENTO", rowIndex].Value.ToString();
        string str12 = validacaoResultado["STATUS", rowIndex].Value.ToString();
        string str13 = validacaoResultado["DEMANDAS_PARA_DESENVOLVIMENTOS", rowIndex].Value.ToString();
        num1 = str13.Length;
        if (!string.IsNullOrWhiteSpace(str10))
          str10 = str10.ToUpper() + ": ";
        if (!string.IsNullOrWhiteSpace(str9))
          str9 = $"{str9.Substring(6, 4)}-{str9.Substring(3, 2)}-{str9.Substring(0, 2)}";
        if (str12.Equals("CONCLUÍDO") || str12.Equals("CONCLUIDO"))
          str2 = $"\n  color: '{str3}'";
        if (str12.Equals("EM ANDAMENTO"))
          str2 = $"\n  color: '{str5}'";
        if (str12.Equals("PENDENTE"))
          str2 = $"\n  color: '{str4}'";
        string str14 = $" [{str8}] ";
        string str15;
        if (string.IsNullOrWhiteSpace(str7))
          str15 = $"\n start: '{str6.Substring(6, 4)}-{str6.Substring(3, 2)}-{str6.Substring(0, 2)}',";
        else
          str15 = $"\n start: '{str7.Substring(6, 4)}-{str7.Substring(3, 2)}-{str7.Substring(0, 2)}',";
        string str16;
        if (string.IsNullOrWhiteSpace(str9))
          str16 = $"\n end: '{str6.Substring(6, 4)}-{str6.Substring(3, 2)}-{str6.Substring(0, 2)}',";
        else
          str16 = $"\n end: '{str9}',";
        string str17 = $"\n title: '{str10}{str13.ToLower().Replace("'", "*")}{str14}{str11}',";
        string str18 = $"\n url: 'javascript:alert(\\'{str11.ToUpper()}{str14}{validacaoResultado["DEMANDAS_PARA_DESENVOLVIMENTOS", rowIndex].Value.ToString().ToLower().Replace("'", "*")}\\')',";
        str1 = $"{str1}\n{{{str17}{str15}{str16}{str18}{str2}\n}},";
      }
      else
      {
        int num2 = (int) MessageBox.Show($"A demanda ID: {str8} não possui uma data limite cadastrada,\npor essa razão ela não constará na calendário HTML.", "TOT - Calendário demandas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }
    string str19 = str1.Replace(Environment.NewLine, "");
    return str19.Substring(0, str19.Length - 1);
  }

  private void cmsGerarNovoKanban_Click(object sender, EventArgs e) => this.gerarKanban();

  private void calendárioDeDemandasToolStripMenuItem_Click(object sender, EventArgs e)
  {
    string sourceFileName = "C:\\Temp\\tot_calendario_demandas_temp.html";
    this.preencherBarraStatusPrincipal(AppDomain.CurrentDomain.BaseDirectory.ToString() + "tot_calendario_demandas_temp.html");
    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + "tot_calendario_demandas_temp.html"))
      sourceFileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + "tot_calendario_demandas_temp.html";
    string str = "C:\\Temp\\tot_calendario_demandas.html";
    try
    {
      File.Copy(sourceFileName, str, true);
      string newValue = this.demandasCalendario();
      string contents = File.ReadAllText(str).Replace("__eventos__", newValue).Replace("__LINHAS_CONSOLIDADO_RESPONSAVEL__", this.tabelaDemandasConsolidasResposavel());
      File.WriteAllText(str, contents);
      Process.Start(str);
    }
    catch (IOException ex)
    {
      BLL.erro("erro ao copiar o template de demandas", ex.Message);
    }
  }

  private string tabelaDemandasConsolidasResposavel()
  {
    string str = "";
    try
    {
      foreach (DataRow row in (InternalDataCollectionBase) DAL.PegarDadosTOT("SELECT VIGENCIA,        INITCAP(NVL(RESPONSAVEL, 'Não atribuído')) RESPONSAVEL,        SUM(CASE WHEN STATUS = 'PENDENTE' THEN 1 ELSE 0 END) PENDENTE,        SUM(CASE WHEN STATUS = 'EM ANDAMENTO' THEN 1 ELSE 0 END) EM_ANDAMENTO,        SUM(CASE WHEN STATUS = 'CANCELADO' THEN 1 ELSE 0 END) CANCELADO,        SUM(CASE WHEN (STATUS = 'CONCLUÍDO' OR STATUS = 'CONCLUIDO') THEN 1 ELSE 0 END) CONCLUIDO,        COUNT(1) TOTAL   FROM GVDW_OWNER.RV_B2B_CONTROLE_DEMANDAS  GROUP BY RESPONSAVEL,        VIGENCIA  ORDER BY NVL(RESPONSAVEL, 'Não atribuído'),        VIGENCIA DESC").Rows)
        str = $"{str}  <tr>\n    <td>{row["VIGENCIA"].ToString()}    <td>{row["RESPONSAVEL"].ToString()}    <td>{row["PENDENTE"].ToString()}    <td>{row["EM_ANDAMENTO"].ToString()}    <td>{row["CANCELADO"].ToString()}    <td>{row["CONCLUIDO"].ToString()}    <td>{row["TOTAL"].ToString()}  </tr>";
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao gerar a tabela de demandas consolidadas por usuário.", ex.Message);
      return "";
    }
    return str;
  }

  private void btPesquisarTabelas_Click(object sender, EventArgs e)
  {
    this.popularTreeviewValidacaoResultado2(true);
    this.tvwValidacaoResultado.ExpandAll();
  }

  private void btLimparFiltroTabelas_Click(object sender, EventArgs e)
  {
    this.txPesquisarTabelas.Text = "";
    this.popularTreeviewValidacaoResultado2();
  }

  private void criarPastaLocalSharepoint(string pastaSharepoint, string urlEvidencias)
  {
    try
    {
      string upper = Globals._loginRedeUsuario.ToUpper();
      int startIndex = upper.IndexOf("\\") + 1;
      string newValue = upper.Substring(startIndex, upper.Length - startIndex);
      string path1 = (urlEvidencias.IndexOf("B2C") <= 0 ? DAL.PegarValorParametro("END_PASTA_EVIDENCIAS_B2B") : DAL.PegarValorParametro("END_PASTA_EVIDENCIAS_B2C")).Replace("__USUARIO__", newValue);
      string path2 = $"{path1}\\{pastaSharepoint}";
      if (!Directory.Exists(path1) || Directory.Exists(path2) || !MessageBox.Show($"Você aparentemente já possui a pasta raiz de homologações sincronizada com o OneDrive na sua máquina.\n\nGostaria de tentar criar automaticamente o diretório [{pastaSharepoint}] na sua máquina e no Sharepoint?", "TOT - Criar pasta de envidência no Sharepoint", MessageBoxButtons.OKCancel, MessageBoxIcon.Question).Equals((object) DialogResult.OK))
        return;
      Directory.CreateDirectory(path2);
      if (Directory.Exists(path2))
      {
        int num1 = (int) MessageBox.Show($"Pasta {path2} criada com sucesso no seu PC, \n\nverifique se o seu OneDrive está online e aguarde a sincronização com o Sharepoint ser concluída para que a pasta apareca no site.");
      }
      else
      {
        int num2 = (int) MessageBox.Show($"Parece que o sistema não conseguiu criar a pasta {path2}, verifique manualmente por favor.");
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar criar o diretório.", ex.Message);
    }
  }

  private void button1_Click(object sender, EventArgs e)
  {
  }

  private static void doStuff(string strName)
  {
  }

  public void listaCombo(string tabela, string campo, ComboBox combo)
  {
    try
    {
      DataTable dataTable1 = DAL.PegarDadosTOT($"SELECT SQL_RETORNO_LISTA FROM GVDW_OWNER.RV_B2B_AUX_COMBOS WHERE TABELA_ORIGEM = '{tabela}' AND CAMPO_ORIGEM = '{campo}'");
      if (dataTable1.Rows.Count <= 0)
        return;
      DataTable dataTable2 = DAL.PegarDadosTOT(dataTable1.Rows[0][0].ToString());
      if (dataTable2.Rows.Count > 0)
      {
        combo.Items.Clear();
        string str = this.dgvValidacaoResultado.CurrentCell.Value.ToString();
        for (int index = 0; index < dataTable2.Rows.Count; ++index)
          combo.Items.Add((object) dataTable2.Rows[index][0].ToString());
        for (int index = 0; index < combo.Items.Count; ++index)
        {
          if (combo.Items[index].Equals((object) str))
          {
            combo.SelectedIndex = index;
            break;
          }
        }
        ContextMenuStrip cmsCombo = this.cmsCombo;
        Point position = Cursor.Position;
        int x = position.X;
        position = Cursor.Position;
        int y = position.Y;
        cmsCombo.Show(x, y);
        combo.DropDownWidth = 240 /*0xF0*/;
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Ocorreu um erro ao tentar carregar o combo.", ex.Message);
    }
  }

  private void cmsItemComboOK_Click(object sender, EventArgs e)
  {
    try
    {
      string str = this.cmbItensDataGrid.ComboBox.SelectedItem.ToString();
      if (str == null)
        return;
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      validacaoResultado.BeginEdit(true);
      validacaoResultado.CurrentCell.Value = (object) str;
      validacaoResultado.EndEdit();
      this.cmbItensDataGrid.ComboBox.SelectedIndex = -1;
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar salvar o valor selecionado.", ex.Message);
    }
  }

  private void cmsGerarWord_Click(object sender, EventArgs e)
  {
    try
    {
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      string textoNovo1 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["RESULTADO_ESPERADO_HOMOLOG"].Value.ToString();
      string textoNovo2 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["ID"].Value.ToString();
      string textoNovo3 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["DEMANDAS_PARA_DESENVOLVIMENTOS"].Value.ToString();
      string textoNovo4 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["VIGENCIA"].Value.ToString();
      string textoNovo5 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["SOLICITANTE"].Value.ToString();
      string textoNovo6 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["SEGMENTO"].Value.ToString();
      string textoNovo7 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["RESPONSAVEL"].Value.ToString();
      string textoNovo8 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["DATA_CONCLUSAO"].Value.ToString();
      string textoNovo9 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["EVIDENCIAS_HOMOLOG"].Value.ToString();
      string textoNovo10 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["RESPONSAVEL_HOMOLOG"].Value.ToString();
      string textoNovo11 = validacaoResultado.Rows[validacaoResultado.CurrentRow.Index].Cells["INDICADOR"].Value.ToString();
      string str1 = DAL.PegarValorParametro("END_TEMPLATE_DOC_RESULTADO_ESPERADO");
      this.preencherBarraStatusPrincipal(str1);
      string str2 = "C:\\Temp\\";
      string str3 = DAL.PegarValorParametro("NOME_DOC_RESULTADO_ESPERADO").Replace(".docx", $"_{textoNovo2}_.docx");
      BLL.CopiarArquivoParaOutroLocal(str1, str2 + str3);
      if (File.Exists(str2 + str3))
      {
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_TEMPLATE_SUBSTITUIR_POR_RESULTADO_ESPERADO_HOMOLOG"), textoNovo1);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_DEMANDA_TEMPLATE_SUBSTITUIR_POR_RESULTADO_ESPERADO_HOMOLOG"), textoNovo3);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_ID_TEMPLATE_SUBSTITUIR_POR_RESULTADO_ESPERADO_HOMOLOG"), textoNovo2);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_TEMPLATE_SUBSTITUIR_POR_VIGENCIA"), textoNovo4);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_TEMPLATE_SUBSTITUIR_POR_SOLICITANTE"), textoNovo5);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_TEMPLATE_SUBSTITUIR_POR_SEGMENTO"), textoNovo6);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_TEMPLATE_SUBSTITUIR_POR_DESENVOLVEDOR"), textoNovo7);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_TEMPLATE_SUBSTITUIR_POR_DATA_CONC_DESENV"), textoNovo8);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_TEMPLATE_SUBSTITUIR_POR_LINK_SHAREPOINT"), textoNovo9);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_TEMPLATE_SUBSTITUIR_POR_HOMOLOGADOR"), textoNovo10);
        BLL.SubstituirTextoWord(str2 + str3, DAL.PegarValorParametro("TEXTO_TEMPLATE_SUBSTITUIR_POR_INDICADOR"), textoNovo11);
        if (!MessageBox.Show($"Deseja abrir o arquivo\n\n{str2}{str3}?", "TOT - Abrir arquivo externo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
          return;
        Process.Start(str2 + str3);
      }
      else
      {
        int num = (int) MessageBox.Show("O arquivo modelo ainda não terminou de ser copiado. Aguardo 1min e tente novamente", "TOT - Arquivo template ainda não carregou", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
    catch (Exception ex)
    {
      BLL.erro(ex.Message);
    }
  }

  private void cmsReenviarWord_Click(object sender, EventArgs e)
  {
    this.enviarEmailMudancaStatusDemanda();
  }

  private void tabValidacaoResultados_SelectedIndexChanged(object sender, EventArgs e)
  {
    TabControl tabControl = new TabControl();
    TabControl validacaoResultados = this.tabValidacaoResultados;
    bool flag = this.txTabelaAtual.Text.Equals("GVDW_OWNER.RV_B2B_ORDEM_PROCESS");
    if (validacaoResultados.SelectedIndex <= -1 || !(validacaoResultados.TabPages[validacaoResultados.SelectedIndex].Name.ToString() == "tpCalculo"))
      return;
    if (flag)
      this.ativarControlesCalculoDetalhado();
    else
      this.ativarControlesCalculoDetalhado(false);
  }

  private void ativarControlesCalculoDetalhado(bool ativar = true)
  {
    this.cmbPeriodo.Enabled = ativar;
    this.cmbSegmentos.Enabled = ativar;
    this.btnBloquearTodosProgramas.Enabled = ativar;
    this.btnLiberarTodosProgramas.Enabled = ativar;
    this.btnDocumentacaoPrograma.Enabled = ativar;
  }

  private void ativarControlesCalculoConsolidado(
    bool ativar = true,
    bool ativarCombos = true,
    bool ativarExecucao = true)
  {
    this.btnDetalharProgramasCalc.Enabled = ativar;
    this.btnHistoricoExecucaoCalc.Enabled = ativar;
    this.btnBloquearCalc.Enabled = ativar;
    this.btnExecutarProgramasCalculo.Enabled = ativarExecucao;
    this.cmbPeriodoCalc.Enabled = ativarCombos;
    this.cmbSegmentoCalc.Enabled = ativarCombos;
    this.cmbCanalCalc.Enabled = ativarCombos;
    this.cmbStatusCalc.Enabled = ativarCombos;
    this.cmbVersaoExecCalc.Enabled = ativarCombos;
    this.cmbTipoCalc.Enabled = ativarCombos;
  }

  private void ativarControlesDataQuality(bool ativar = true)
  {
    this.cmbPeriodoDQ.Enabled = ativar;
    this.cmbSegmentoDQ.Enabled = ativar;
    this.cmbCanalDQ.Enabled = ativar;
    this.cmbCenarioDQ.Enabled = ativar;
    this.cmbInsumoDQ.Enabled = ativar;
    this.cmbTipoDQ.Enabled = ativar;
  }

  private void expandirGridConsulta(bool expandir)
  {
    if (expandir)
    {
      this.tabNavegacao.Visible = false;
      this.tabConsultaBancos.Left = this.tabNavegacao.Left;
    }
    else
    {
      this.tabNavegacao.Visible = true;
      this.tabConsultaBancos.Left = 220;
    }
  }

  private void executarConsultaComParametros(string consulta, bool preview = false)
  {
    try
    {
      this.txPesquisarTabelas.Text = "";
      this.popularTreeviewValidacaoResultado2();
      if (string.IsNullOrWhiteSpace(consulta))
        return;
      int length1 = consulta.Length;
      int length2 = consulta.IndexOf("@");
      int num = consulta.IndexOf("#");
      string texto = consulta.Substring(0, length2);
      consulta.Substring(length2 + 1, num - length2 - 1);
      consulta = consulta.Substring(num + 1, length1 - num - 1);
      this.selecionaNode(texto, this.tvwValidacaoResultado);
      BLL.hignorarHistorico = preview;
      this.clicouTreeView(preview, consulta);
    }
    catch (Exception ex)
    {
      BLL.erro("Falha ao tentar executar sua consulta.", ex.Message);
    }
  }

  private void ativarTab(TabPage tab, bool ativar = true)
  {
    TabControl validacaoResultados = this.tabValidacaoResultados;
    try
    {
      if (!ativar)
      {
        foreach (TabPage tabPage in validacaoResultados.TabPages)
        {
          if (!tabPage.Equals((object) tab))
            validacaoResultados.TabPages.Remove(tab);
        }
      }
      else
      {
        validacaoResultados.Controls.Add((Control) tab);
        validacaoResultados.SelectedTab = tab;
      }
    }
    catch (Exception ex)
    {
      Console.Write(ex.Message);
    }
  }

  private void desativarTodasTabs()
  {
    TabControl validacaoResultados = this.tabValidacaoResultados;
    foreach (TabPage tabPage in validacaoResultados.TabPages)
      validacaoResultados.TabPages.Remove(tabPage);
  }

  private void btnDocumentacaoPrograma_Click(object sender, EventArgs e)
  {
    DataGridView dataGridView = new DataGridView();
    try
    {
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      if (!validacaoResultado.Columns.Contains("PROGRAMA") || validacaoResultado.CurrentRow.Index <= -1)
        return;
      string str = validacaoResultado.CurrentRow.Cells["PROGRAMA"].Value.ToString();
      int startIndex = str.IndexOf(".") + 1;
      int num = str.IndexOf("(");
      this.gerarDocumentacaoHTML("", str.Substring(startIndex, num - startIndex));
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao pegar o nome do programa", ex.Message);
    }
  }

  private void frmConsultaBancos_Activated(object sender, EventArgs e)
  {
    DAL._tabelaAtual = this.txTabelaAtual.Text;
    switch (this.txTabelaAtual.Text)
    {
      case "GVDW_OWNER.VW_CP_ERP_CALCULOS":
        BLL.controleForms = 1;
        break;
      case "GVDW_OWNER.RV_B2B_ORDEM_PROCESS":
        BLL.controleForms = 1;
        break;
      default:
        BLL.controleForms = 0;
        break;
    }
  }

  private void frmConsultaBancos_Leave(object sender, EventArgs e)
  {
    this.txTabelaAtual.Text = DAL._tabelaAtual;
  }

  private void btnNovaConsultaBancos_Click(object sender, EventArgs e)
  {
    string s = "0";
    if (!string.IsNullOrWhiteSpace(this.txCodigoForm.Text))
      s = this.txCodigoForm.Text;
    BLL.controleForms = int.Parse(s);
    frmConsultaBancos frmConsultaBancos = new frmConsultaBancos();
    frmConsultaBancos.MdiParent = this.ParentForm;
    frmConsultaBancos.Show();
  }

  private bool IsAllUpper(string input)
  {
    for (int index = 0; index < input.Length; ++index)
    {
      if (char.IsLetter(input[index]) && !char.IsUpper(input[index]))
        return false;
    }
    return true;
  }

  private void cmsLimparOperador_Click(object sender, EventArgs e)
  {
  }

  private void btnExecutarProgramasCalculo_Click(object sender, EventArgs e)
  {
    this.executarProgramasCalculo();
  }

  private void cmbSegmentoCalc_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "Segmento");
  }

  private void cmbPeriodoCalc_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "Período");
  }

  private void cmbCanalCalc_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "Canal");
  }

  private void cmbTipoCalc_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "Tipo");
  }

  private void cmbVersaoExecCalc_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "Execuções");
  }

  private void AppendText(RichTextBox box, string text, Color color)
  {
    box.SelectionStart = box.TextLength;
    box.SelectionLength = 0;
    box.SelectionColor = color;
    box.AppendText(text);
    box.SelectionColor = box.ForeColor;
    box.ScrollToCaret();
  }

  private void cmbStatusCalc_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "Status");
  }

  private void btnHistoricoExecucaoCalc_Click(object sender, EventArgs e)
  {
  }

  private void btnDetalharProgramasCalc_Click(object sender, EventArgs e)
  {
    if (!this.txTabelaAtual.Text.Equals("GVDW_OWNER.VW_CP_ERP_CALCULOS"))
      return;
    DataGridView dataGridView = new DataGridView();
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    string str1 = "";
    string str2 = "";
    int rowIndex = validacaoResultado.CurrentCell.RowIndex;
    if (rowIndex > -1)
    {
      str1 = validacaoResultado.Rows[rowIndex].Cells["ID_INICIO"].Value.ToString();
      str2 = validacaoResultado.Rows[rowIndex].Cells["ID_FIM"].Value.ToString();
    }
    this.executarConsultaComParametros($"GVDW_OWNER.RV_B2B_ORDEM_PROCESS@pdw1#ID|Entre|{str1};{str2}|True|\r\nPROCESSO|||True|\r\nPERIODO|||True|\r\nNUM_ORDEM|||True|\r\nPROGRAMA|||True|\r\nDT_INI_EXEC|||True|\r\nDT_FIM_EXEC|||True|\r\nPARAMETROS|||True|\r\nOBSERVACOES|||True|\r\nUSUARIO_INSERT|||True|\r\nDATA_INSERT|||True|\r\nUSUARIO_UPDATE|||True|\r\nDATA_UPDATE|||True|\r\nID_SEGMENTO|||True|\r\nPARCIAL|||True|\r\nDESCRICAO_BLOQUEIO|||True|\r\nDESCRICAO_ERRO|||True|\r\nSEGMENTO|||True|\r\nCANAL|||True|\r\nTIPO_CALCULO|||True|\r\nNUM_EXECUCAO_CALCULO|||True|\r\nSTATUS_CALCULO|||True|\r\nUSUARIO_EXECUCAO|||True|\r\n", true);
  }

  private void cmbItensDataGrid_SelectedIndexChanged(object sender, EventArgs e)
  {
    this.cmsItemComboOK.Select();
  }

  private bool calculoAberto(DataGridView dg)
  {
    try
    {
      return dg.CurrentRow.Cells["Status"].Value.ToString().ToUpper().Equals("ABERTO");
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  private void desbloquearProgramas(bool desbloquear = true)
  {
  }

  private void atualizaAcaoBotaoBloquearCalc(bool bloquear = true)
  {
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    string tabelaAtual = DAL._tabelaAtual;
    int count = this.dgvValidacaoResultado.SelectedRows.Count;
    if (this.calculoAberto(validacaoResultado))
      this.btnBloquearCalc.ImageIndex = 41;
    else
      this.btnBloquearCalc.ImageIndex = 40;
  }

  private void dgvValidacaoResultado_RowHeaderMouseClick(
    object sender,
    DataGridViewCellMouseEventArgs e)
  {
  }

  private void formatarCelula(string tabela, string coluna)
  {
    if (!(tabela == "GVDW_OWNER.VW_CP_ERP_CALCULOS"))
      return;
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    if (validacaoResultado.Rows.Count <= 0)
      return;
    for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
      validacaoResultado.Rows[index].Cells[coluna].Style.BackColor = Color.Red;
  }

  private void btnBloquearCalc_Click(object sender, EventArgs e)
  {
    DataGridView validacaoResultado = this.dgvValidacaoResultado;
    bool flag = this.calculoAberto(validacaoResultado);
    string str1 = validacaoResultado.CurrentRow.Cells["Canal"].Value.ToString();
    string str2 = validacaoResultado.CurrentRow.Cells["Segmento"].Value.ToString();
    string str3 = validacaoResultado.CurrentRow.Cells["Período"].Value.ToString();
    string str4 = validacaoResultado.CurrentRow.Cells["Com erros"].Value.ToString();
    string str5 = validacaoResultado.CurrentRow.Cells["Data quality previstos"].Value.ToString();
    string str6 = validacaoResultado.CurrentRow.Cells["Data quality vermelhos"].Value.ToString();
    string str7 = validacaoResultado.CurrentRow.Cells["Checklists"].Value.ToString();
    string str8 = validacaoResultado.CurrentRow.Cells["Checklists OK"].Value.ToString();
    string str9 = validacaoResultado.CurrentRow.Cells["Insumos Previstos"].Value.ToString();
    string str10 = validacaoResultado.CurrentRow.Cells["Insumos Carregados"].Value.ToString();
    string str11 = validacaoResultado.CurrentRow.Cells["Programas"].Value.ToString();
    string str12 = validacaoResultado.CurrentRow.Cells["Programas Executados"].Value.ToString();
    string str13 = validacaoResultado.CurrentRow.Cells["Demandas"].Value.ToString();
    string str14 = validacaoResultado.CurrentRow.Cells["Demandas OK"].Value.ToString();
    string str15 = validacaoResultado.CurrentRow.Cells["Responsável"].Value.ToString();
    string str16 = validacaoResultado.CurrentRow.Cells["Última execução"].Value.ToString();
    string str17 = validacaoResultado.CurrentRow.Cells["Tipo"].Value.ToString();
    string str18 = "";
    string str19 = $"<table><tr><td colspan=2>Olá, segue status atualizado de cálculo:</td></tr><tr><td colspan=2>&nbsp;</td></tr><td><strong>Canal:</strong></td><td>{str1}</td></tr>\n<td><strong>Período:</strong></td><td>{str3.Substring(0, 10)}</td></tr>\n<td><strong>Tipo de cálculo:</strong></td><td>{str17}</td></tr>\n<td><strong>Recálculo?</strong></td><td>{str18}</td></tr>\n<td><strong>Data última execução:</strong></td><td>{str16}</td></tr>\n<td><strong>Status:</strong></td><td style='color: red;'>__STATUS__</td></tr>\n<td><strong>Data qualitys previstos:</strong></td><td>{str5}</td></tr>\n<td><strong>Data qualitys vermelhos:</strong></td><td>{str6}</td></tr>\n<td><strong>Checklists previstos:</strong></td><td>{str7}</td></tr>\n<td><strong>Checklists OK:</strong></td><td>{str8}</td></tr>\n<td><strong>Insumos previstos:</strong></td><td>{str9}</td></tr>\n<td><strong>Insumos carregados:</strong></td><td>{str10}</td></tr>\n<td><strong>Programas previstos:</strong></td><td>{str11}</td></tr>\n<td><strong>Programas executados:</strong></td><td>{str12}</td></tr>\n<td><strong>Programas com erros:</strong></td><td>{str4}</td></tr>\n<td><strong>Demandas previstas:</strong></td><td>{str13}</td></tr>\n<td><strong>Demandas concluídas:</strong></td><td>{str14}</td></tr>\n<td><strong>Responsável:</strong></td><td>{str15}</td></tr>\n<tr><td colspan=2>&nbsp;</td><tr><td colspan=2><i>*Email enviado de forma automatiada</td></tr></table>";
    string emailAssunto = $"Mudança no status do cálculo do canal {str1} - segmento {str2} - Período: {str3.Substring(0, 10)}";
    if (flag)
    {
      if (MessageBox.Show($"Atenção usuário {Globals._loginRedeUsuario.ToUpper()}:\n\nAo definir este cálculo como FECHADO, os seguintes dados serão enviados por email aos destinatários cadastrados (podendo incluir seus superiores):\n\nCanal: \t\t\t{str1}\nSegmento: \t\t{str2}\nPeríodo: \t\t\t{str3.Substring(0, 10)}\nTipo de cálculo: \t\t{str17}\nRecálculo? \t\t{str18}\nData última execução:\t{str16}\nProgramas previstos:\t{str11}\nProgramas executados:\t{str12}\nProgramas com erros:\t{str4}\nData qualitys previstos:\t{str5}\nData qualitys vermelhos:\t{str6}\nChecklists previstos: \t{str7}\nChecklists OK: \t\t{str8}\nInsumos previstos: \t{str9}\nInsumos carregados: \t{str10}\nDemandas previstas: \t{str13}\nDemandas concluídas: \t{str14}\nResponsável: \t\t{str15}\n\nApós fechado, este cálculo só poderá ser reaberto pelo gestor.\n\nVocê confirma o fechamento deste cálculo?", "TOT - Fechar cálculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
      {
        this.fecharCalculo();
        string newValue = flag ? "FECHADO!" : "ABERTO!";
        string str20 = str19.Replace("__STATUS__", newValue);
        foreach (DataRow row in (InternalDataCollectionBase) DAL.PegarDadosTOT($"SELECT DISTINCT LOWER(EMAIL) EMAIL   FROM GVDW_OWNER.RV_B2B_USUARIOS_APP U,         GVDW_OWNER.RV_B2B_CONTROLE_CALCULO_EMAIL E  WHERE FL_ATIVO = 1 /*AND RECEBE_EMAIL_DEMANDA = 1*/   AND U.CD_LOGIN_REDE = E.CD_LOGIN_REDE   AND E.SEGMENTO = '{str1}'").Rows)
          BLL.enviarEmail(row["EMAIL"].ToString(), emailAssunto, str20 ?? "");
        DAL.PegarDadosTOT($"INSERT INTO GVDW_OWNER.TB_CP_CONTROLE_CALCULO (SEGMENTO,CANAL,STATUS,RESPONSAVEL,DATA_STATUS,TIPO,PERIODO) VALUES ('{str2}','{str1}','{newValue}','{str15}',sysdate,'{str17}','{str3.Substring(0, 10)}') ", alteracao: true);
      }
      else
      {
        int num1 = (int) MessageBox.Show("Fechamento cancelado.", "TOT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }
    else if (MessageBox.Show($"Atenção usuário {Globals._loginRedeUsuario.ToUpper()}:\n\nAo reabrir este cálculo, os seguintes dados serão enviados por email aos destinatários cadastrados (podendo incluir seus superiores):\n\nCanal: \t\t\t{str1}\nSegmento: \t\t{str2}\nPeríodo: \t\t\t{str3.Substring(0, 10)}\nTipo de cálculo: \t\t{str17}\nRecálculo? \t\t{str18}\nData última execução:\t{str16}\nProgramas previstos:\t{str11}\nProgramas executados:\t{str12}\nProgramas com erros:\t{str4}\nData qualitys previstos:\t{str5}\nData qualitys vermelhos:\t{str6}\nChecklists previstos: \t{str7}\nChecklists OK: \t\t{str8}\nInsumos previstos: \t{str9}\nInsumos carregados: \t{str10}\nDemandas previstas: \t{str13}\nDemandas concluídas: \t{str14}\nResponsável: \t\t{str15}\n\nApós aberto, este cálculo será remarcado como REcalculo.\n\nVocê confirma a reabertura deste cálculo?", "TOT - Reabrir cálculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
    {
      this.fecharCalculo(false);
      string newValue = flag ? "FECHADO!" : "ABERTO!";
      string str21 = str19.Replace("__STATUS__", newValue);
      foreach (DataRow row in (InternalDataCollectionBase) DAL.PegarDadosTOT($"SELECT DISTINCT LOWER(EMAIL) EMAIL   FROM GVDW_OWNER.RV_B2B_USUARIOS_APP U,         GVDW_OWNER.RV_B2B_CONTROLE_CALCULO_EMAIL E  WHERE FL_ATIVO = 1 /*AND RECEBE_EMAIL_DEMANDA = 1*/   AND U.CD_LOGIN_REDE = E.CD_LOGIN_REDE   AND E.SEGMENTO = '{str1}'").Rows)
        BLL.enviarEmail(row["EMAIL"].ToString(), emailAssunto, str21 ?? "");
      DAL.PegarDadosTOT($"INSERT INTO GVDW_OWNER.TB_CP_CONTROLE_CALCULO (SEGMENTO,CANAL,STATUS,RESPONSAVEL,DATA_STATUS,TIPO,PERIODO) VALUES ('{str2}','{str1}','{newValue}','{str15}',sysdate,'{str17}','{str3.Substring(0, 10)}') ", alteracao: true);
    }
    else
    {
      int num2 = (int) MessageBox.Show("Reabertura cancelada.", "TOT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
  }

  private void fecharCalculo(bool fechar = true)
  {
    try
    {
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      bool flag = this.calculoAberto(validacaoResultado);
      string str1 = validacaoResultado.CurrentRow.Cells["ID_INICIO"].Value.ToString();
      string str2 = validacaoResultado.CurrentRow.Cells["ID_FIM"].Value.ToString();
      string consulta1 = $"UPDATE GVDW_OWNER.RV_B2B_ORDEM_PROCESS \n   SET DESCRICAO_BLOQUEIO = '' \n WHERE ID BETWEEN {str1} AND {str2} ";
      string consulta2 = $"UPDATE GVDW_OWNER.RV_B2B_ORDEM_PROCESS \n   SET DESCRICAO_BLOQUEIO = 'Cálculo fechado em ' || sysdate || ' por ' || SYS_CONTEXT('USERENV','OS_USER') \n WHERE ID BETWEEN {str1} AND {str2} ";
      if (!flag && !fechar)
        DAL.PegarDadosTOT(consulta1, alteracao: true);
      if (fechar)
        DAL.PegarDadosTOT(consulta2, alteracao: true);
      this.btnPesquisarValidacaoResultado.PerformClick();
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar mudar o status do cálculo.\n\nContate o desenvolvedor.", ex.Message);
    }
  }

  private void btnLimparFiltrosCalc_Click(object sender, EventArgs e)
  {
    this.executarConsultaComParametros("GVDW_OWNER.VW_CP_ERP_CALCULOS@pdw1#ROWNUM<100");
  }

  private bool filtrosAplicadosExecucaoCalc()
  {
    DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
    string str = "";
    for (int index = 0; index < validacaoResultado.RowCount; ++index)
      str += validacaoResultado.Rows[index].Cells[1].Value.ToString();
    return !str.Equals("");
  }

  private void cmbPeriodoDQ_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "PERIODO");
  }

  private void cmbCanalDQ_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "CANAL");
  }

  private void cmbSegmentoDQ_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "SEGMENTO");
  }

  private void cmbTipoDQ_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "TIPO");
  }

  private void cmbCenarioDQ_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "CENARIO");
  }

  private void cmbInsumoDQ_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "INSUMO");
  }

  private void btnLimpaFiltrosDQ_Click(object sender, EventArgs e)
  {
    this.executarConsultaComParametros("GVDW_OWNER.VW_RV_B2B_DATAQUALITY3@pdw1#ROWNUM<100");
    this.txPesquisarTabelas.Text = "Quality";
    this.btPesquisarTabelas.PerformClick();
  }

  private void chkRealizadoZerado_CheckedChanged(object sender, EventArgs e)
  {
    bool flag = this.chkRealizadoZerado.Checked;
    DataGridView validacaoResultado = this.dgvFiltrosValidacaoResultado;
    for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
    {
      if (validacaoResultado.Rows[index].Cells[0].Value.Equals((object) "REALIZADO"))
      {
        if (flag)
        {
          validacaoResultado.Rows[index].Cells[1].Value = (object) "Igual a";
          validacaoResultado.Rows[index].Cells[2].Value = (object) "0,00";
          break;
        }
        validacaoResultado.Rows[index].Cells[1].Value = (object) "";
        validacaoResultado.Rows[index].Cells[2].Value = (object) "";
        break;
      }
    }
    this.btnPesquisarValidacaoResultado.PerformClick();
  }

  private void btnParametrosDataQuality_Click(object sender, EventArgs e)
  {
    this.executarConsultaComParametros("GVDW_OWNER.RV_B2B_PARAMETROS_DATAQUALITY@pdw1#ROWNUM<100");
  }

  private void cmbPeriodoBases_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "PERIODO");
  }

  private void cmbSegmentoBases_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "SEGMENTO");
  }

  private void cmbCanalBases_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "CANAL");
  }

  private void cmbNomeBases_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "NOME_BASE");
  }

  private void btnLimparFiltrosBases_Click(object sender, EventArgs e)
  {
    this.executarConsultaComParametros("GVDW_OWNER.RV_B2B_CARGAS_BASES@pdw1#ROWNUM<100");
    this.txPesquisarTabelas.Text = "Cargas";
    this.btPesquisarTabelas.PerformClick();
  }

  private void btnCarregarBase_Click(object sender, EventArgs e)
  {
    if (MessageBox.Show("Confirma a execução de carga das bases selecionadas?\n\nATENÇÃO: As linhas marcadas como \"APAGAR=1\" terão os dados apagados antes da carga para o período selecionado. Caso negativos os dados serão adicionados sem o delete prévio e isso pode gerar duplicidades na base de destino.\n\n\n\nApós clicar em OK não será possível cancelar a operação.", "TOT - Carga de bases", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
    {
      try
      {
        DataGridView validacaoResultado = this.dgvValidacaoResultado;
        int num = 0;
        string str1 = "";
        string sqlDelete = "";
        for (int index = 0; index < validacaoResultado.Rows.Count; ++index)
        {
          if (validacaoResultado.Rows[index].Selected)
          {
            string idCarga = validacaoResultado.Rows[index].Cells["ID"].Value.ToString();
            string str2 = validacaoResultado.Rows[index].Cells["ENDERECO_BASE_ORIGEM"].Value.ToString();
            string tabelaDestino = validacaoResultado.Rows[index].Cells["TABELA_DESTINO"].Value.ToString();
            string str3 = validacaoResultado.Rows[index].Cells["PERIODO"].Value.ToString();
            string str4 = validacaoResultado.Rows[index].Cells["APAGAR"].Value.ToString();
            string str5 = validacaoResultado.Rows[index].Cells["CAMPO_PERIODO"].Value.ToString();
            int startIndex = str2.LastIndexOf("\\");
            str1 = str2.Substring(startIndex, str2.Length - startIndex);
            string extension = Path.GetExtension(str2);
            ++num;
            if (extension.ToLower().Equals(".csv") || extension.ToLower().Equals(".txt"))
            {
              if (str4.Equals("1") || str4.ToUpper().Equals("SIM"))
                sqlDelete = $"DELETE FROM {tabelaDestino} WHERE {str5} = '{str3}'";
              this.cargaBaseManual(str2, tabelaDestino, idCarga, sqlDelete);
            }
            else
              BLL.erro($"Não foi possível carregar o arquivo [{str2}].", "Apenas extensões 'txt' e 'csv' são permitidas por enquanto.");
          }
        }
      }
      catch (Exception ex)
      {
        BLL.erro("Erro ao coletar as informações para executar a carga.", ex.Message);
      }
    }
    else
    {
      int num1 = (int) MessageBox.Show("Cargas canceladas.", "TOT", MessageBoxButtons.OK);
    }
  }

  private void cargaBaseManual(
    string nomeArquivo,
    string tabelaDestino,
    string idCarga,
    string sqlDelete = "")
  {
    try
    {
      DataTable dataTable1 = new DataTable();
      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      string str5 = "";
      string str6 = "0";
      string extension = Path.GetExtension(nomeArquivo);
      if (extension.ToLower().Equals(".csv") || extension.ToLower().Equals(".txt"))
      {
        string[] strArray = File.ReadAllLines(nomeArquivo, Encoding.GetEncoding(1252));
        int num = 0;
        num = File.ReadLines(nomeArquivo).Count<string>();
        for (int index1 = 0; index1 < strArray.Length; ++index1)
        {
          string[] source = strArray[index1].Split(';');
          if (index1.Equals(0))
          {
            for (int index2 = 0; index2 < ((IEnumerable<string>) source).Count<string>(); ++index2)
            {
              dataTable1.Columns.Add(source[index2]);
              str1 = $"{str1}{source[index2].ToString()},";
            }
            str1 = str1.Substring(0, str1.Length - 1);
          }
          else
            dataTable1.Rows.Add((object[]) source);
        }
      }
      if (!string.IsNullOrWhiteSpace(sqlDelete))
      {
        this.preencherBarraStatusPrincipal("Tentar apagar " + tabelaDestino);
        System.Windows.Forms.Application.DoEvents();
        DataTable dataTable2 = DAL.PegarDadosTOT(sqlDelete, alteracao: true);
        DataColumnCollection columns = dataTable2.Columns;
        if (dataTable2 == null)
        {
          BLL.erro("Falha ao tentar apagar registros na " + tabelaDestino);
        }
        else
        {
          if (columns.Contains("errotot"))
            BLL.erro("Erro ao tentar apagar registros: " + dataTable2.Rows[0][0].ToString());
          if (columns.Contains("nu_registros"))
          {
            str6 = dataTable2.Rows[0][0].ToString();
            this.preencherBarraStatusPrincipal($"Apagados {str6} na {tabelaDestino}");
            System.Windows.Forms.Application.DoEvents();
          }
        }
      }
      string str7 = $"INSERT INTO {tabelaDestino} ({str1}) ";
      if (!dataTable1.Equals((object) null) && dataTable1.Rows.Count > 0)
        str5 = dataTable1.Rows.Count.ToString();
      for (int index = 0; index < dataTable1.Rows.Count; ++index)
      {
        for (int columnIndex = 0; columnIndex < dataTable1.Columns.Count; ++columnIndex)
          str2 = $"{str2}'{dataTable1.Rows[index][columnIndex].ToString()}',";
        string str8 = str2.Replace(Environment.NewLine, " ");
        str3 = $"{str3} SELECT {str8.Substring(0, str8.Length - 1)} FROM DUAL UNION ALL {Environment.NewLine}";
        str2 = "";
      }
      string str9 = str7 + str3.Substring(0, str3.Length - 10);
      BLL.copiarParaAreaDeTransferencia(str9);
      BLL.copiarParaAreaDeTransferencia(".");
      DataTable dataTable3 = DAL.PegarDadosTOT(str9, alteracao: true);
      DataColumnCollection columns1 = dataTable3.Columns;
      if (dataTable3 == null)
        BLL.erro("ERRO ao tentar inserir:\n\nNão foi possível carregar o arquivo. Verifique se as colunas e dados do arquivo estão aderentes ao formato da tabela do Oracle");
      if (!columns1.Contains("nu_registros"))
        ;
      if (columns1.Contains("errotot"))
      {
        string text = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")}: ERRO ao tentar inserir:\n\nNão foi possível carregar o arquivo. Verifique se as colunas e dados do arquivo estão aderentes ao formato da tabela do Oracle. \nCódigo de erro retornado pelo banco Oracle: {dataTable3.Rows[0][0].ToString()}\n";
        this.AppendText(this.rtbStatusCargaBase, text, Color.Red);
        System.Windows.Forms.Application.DoEvents();
        DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_CARGAS_BASES    SET ERROS = '{text}' WHERE ID = '{idCarga}'", alteracao: true);
        str4 = "";
      }
      else
      {
        if (this.tabelaEditavel(tabelaDestino))
        {
          string str10 = $"+ {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")}: Carga da base {nomeArquivo} na tabela de destino {tabelaDestino}. Total de linhas apagadas antes da carga: {str6}. Total de {str5} linhas inseridas.\n";
          this.AppendText(this.rtbStatusCargaBase, str10 + "\n", Color.DarkGreen);
          System.Windows.Forms.Application.DoEvents();
          DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_CARGAS_BASES    SET LOG_CARGA = '{str10} Número registros apagados: {str6}'  WHERE ID = '{idCarga}'", alteracao: true);
        }
        else
        {
          string str11 = $"+ {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")}: Base de destino {tabelaDestino} está bloqueada para edição. Fale com seu gestor sobre a liberação da base e tente novamente.\n";
          this.AppendText(this.rtbStatusCargaBase, str11 + "\n", Color.Red);
          System.Windows.Forms.Application.DoEvents();
          DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_CARGAS_BASES    SET ERROS = '{str11}' WHERE ID = '{idCarga}'", alteracao: true);
        }
        str4 = "";
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Não foi possível carregar o arquivo. Verifique as colunas e dados do arquivo estão aderentes ao formato da tabela do Oracle.", ex.Message);
    }
  }

  private void gerarExtratoJuridico(
    string matricula,
    string periodo,
    string idVersao,
    string idModeloHTML)
  {
    try
    {
      string consulta = $"select sql as consulta, nvl(campo_filtro_periodo,'PERIODO') campo_filtro_periodo, NVL(campo_filtro_re,'RE') campo_filtro_re, fl_quebrar_pagina from GVDW_OWNER.RV_B2B_EXTRATO_JUR_SQL where sql is not null and idversao = '{idVersao}' order by ordem_geracao asc ";
      string newValue = "";
      string str1 = "";
      foreach (DataRow row in (InternalDataCollectionBase) DAL.PegarDadosTOT($"SELECT * FROM GVDW_OWNER.RV_EXTRATO_JUR_MODELO_HTML WHERE ID_VERSAO = '{idModeloHTML}'").Rows)
        str1 += row["HTML"].ToString();
      string str2 = "";
      DataTable dataTable1 = DAL.PegarDadosTOT(consulta);
      for (int index1 = 0; index1 < dataTable1.Rows.Count; ++index1)
      {
        string str3 = dataTable1.Rows[index1][0].ToString();
        string str4 = dataTable1.Rows[index1][1].ToString();
        string str5 = dataTable1.Rows[index1][2].ToString();
        string str6 = dataTable1.Rows[index1][3].ToString();
        DataTable dataTable2 = DAL.PegarDadosTOT($"{str3} and {str5} = '{matricula}' and {str4} = '{periodo}'");
        if (dataTable2 != null)
        {
          if (dataTable2.Columns.Contains("errotot"))
          {
            this.preencherBarraStatusPrincipal($"{str3} and RE = '{str5}' and PERIODO = '{str4}' erro: {dataTable2.Rows[0][0].ToString()}");
            string str7 = this.dgvValidacaoResultado.Rows[this.dgvValidacaoResultado.CurrentRow.Index].Cells["ID"].Value.ToString();
            str2 = $"{str2}Script SQL: {str3} and {str5} = '{matricula}' and {str4} = '{periodo}'\nErro Oracle: {dataTable2.Rows[0][0].ToString()}\n";
            DAL.PegarDadosTOT($"UPDATE GVDW_OWNER.RV_B2B_EXTRATO_JUR_EXEC SET DATA_ULTIMA_EXEC = SYSDATE, ERRO_ULTIMA_EXEC ='{str2.Replace("'", "*")}' WHERE ID = '{str7}'", alteracao: true);
          }
          else if (dataTable2.Rows.Count > 0)
          {
            this.preencherBarraStatusPrincipal($"Executando: {str3} and RE = '{matricula}' and PERIODO = '{periodo}'");
            string str8 = newValue + "<table id=\"customers\">\n" + "<thead>\n" + "<tr>\n";
            for (int index2 = 0; index2 < dataTable2.Columns.Count; ++index2)
              str8 = $"{str8}<th>{dataTable2.Columns[index2].ColumnName.ToString()}</th>";
            string str9 = str8 + "</tr>\n" + "</thead>\n" + "<tbody>\n";
            for (int index3 = 0; index3 < dataTable2.Rows.Count; ++index3)
            {
              string str10 = str9 + "<tr>\n";
              for (int columnIndex = 0; columnIndex < dataTable2.Columns.Count; ++columnIndex)
                str10 = $"{str10}<td>{dataTable2.Rows[index3][columnIndex].ToString()}</td>";
              str9 = str10 + "</tr>\n";
            }
            string str11 = str9 + "</tbody>\n" + "</table><br />\n";
            newValue = !str6.Equals("1") ? str11 + "<br />\n" : str11 + "<div class=\"pagebreak\"> </div>\n";
          }
        }
      }
      string str12 = str1.Replace("__CORPO__", newValue);
      File.WriteAllText($"C:\\Temp\\Extrato RV para Jurídico - Matrícula {matricula} - AnoMês {periodo}.html", str12 + "</body></html>");
      Process.Start($"C:\\Temp\\Extrato RV para Jurídico - Matrícula {matricula} - AnoMês {periodo}.html");
    }
    catch (Exception ex)
    {
      BLL.erro($"Falha ao gerar o extrado do RE {matricula} e período {periodo}.", ex.Message);
    }
  }

  private void button7_Click(object sender, EventArgs e) => this.gerarInformativoLocal(0);

  private void dadosParaGerarExtratoJuridico()
  {
    try
    {
      string text = this.txTabelaAtual.Text;
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      if (!text.Equals("GVDW_OWNER.RV_B2B_EXTRATO_JUR_EXEC"))
        return;
      int count = validacaoResultado.Rows.Count;
      int num = 0;
      if (count > 0)
      {
        for (int index = 0; index < count; ++index)
        {
          if (validacaoResultado.Rows[index].Selected)
          {
            ++num;
            string matricula = validacaoResultado.Rows[index].Cells["MATRICULA"].Value.ToString();
            string periodo = validacaoResultado.Rows[index].Cells["ANOMES"].Value.ToString();
            string idVersao = validacaoResultado.Rows[index].Cells["ID_VERSAO"].Value.ToString();
            string idModeloHTML = validacaoResultado.Rows[index].Cells["ID_MODELO_HTML"].Value.ToString();
            this.preencherBarraStatusPrincipal($"Linha = {index.ToString()}\nMatrícula: {matricula}\nANOMES: {periodo}");
            this.gerarExtratoJuridico(matricula, periodo, idVersao, idModeloHTML);
          }
        }
      }
      this.preencherBarraStatusPrincipal("");
    }
    catch (Exception ex)
    {
      BLL.erro("Falha ao preparar os dados que serão usados na geração do extrato.", ex.Message);
    }
  }

  private void item_Click(object sender, EventArgs e)
  {
    ToolStripItem toolStripItem = sender as ToolStripItem;
    this.dadosParaGerarExtratoJuridico();
  }

  private void item2_Click(object sender, EventArgs e)
  {
    ToolStripItem toolStripItem = sender as ToolStripItem;
    this.gerarRelatorioValidacao();
  }

  private void cmsEditarCelulaArquivoOrigem_Click(object sender, EventArgs e)
  {
    try
    {
      this.dgvValidacaoResultado.BeginEdit(true);
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao iniciar edição da célula", ex.Message);
    }
  }

  private void tsmProcurarArquivo_Click(object sender, EventArgs e)
  {
    try
    {
      string empty = string.Empty;
      string str = string.Empty;
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "TXT delimitado por ; (*.txt)|*.txt|Arquivo CSV (*.csv)|*.csv";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
          str = openFileDialog.FileName;
      }
      validacaoResultado.BeginEdit(true);
      validacaoResultado.CurrentCell.Value = (object) str.ToString();
      validacaoResultado.EndEdit();
    }
    catch (Exception ex)
    {
      BLL.erro("Falha ao tentar abrir a janela de pesquisa ou adicionar o endereço do arquivo", ex.Message);
    }
  }

  private void enviarEmailMudancaStatusDemanda(int tipoEmail = 0, string idDemandaDivulgar = null)
  {
    try
    {
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      string str1 = "";
      string str2 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["RESPONSAVEL_HOMOLOG"].Value.ToString();
      string str3 = idDemandaDivulgar;
      string str4 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["SEGMENTO"].Value.ToString();
      string str5 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["STATUS_HOMOLOG"].Value.ToString();
      string str6 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["VIGENCIA"].Value.ToString();
      string str7 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["DEMANDAS_PARA_DESENVOLVIMENTOS"].Value.ToString();
      string str8 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["TIPO"].Value.ToString();
      string str9 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["RESPONSAVEL"].Value.ToString();
      string str10 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["SOLICITANTE"].Value.ToString();
      DataTable dataTable1 = (DataTable) null;
      switch (tipoEmail)
      {
        case 0:
          validacaoResultado.CurrentCell.OwningColumn.Name.ToString();
          validacaoResultado.CurrentCell.Value.ToString();
          string newValue1 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
          string str11 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["DATA_CONCLUSAO"].Value.ToString();
          string str12 = DAL.PegarValorParametro("URL_HOMOLOG_SHAREPOINT");
          if (!string.IsNullOrEmpty(str11))
          {
            string emailAssunto = DAL.PegarValorParametro("ASSUNTO_EMAIL_DEMANDA_CONCLUIDA").Replace("__IDDEMANDA__", newValue1);
            string str13 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["DATA_CONCLUSAO"].Value.ToString().Substring(0, 10);
            string str14 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["SEGMENTO"].Value.ToString();
            string str15 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["EVIDENCIAS_HOMOLOG"].Value.ToString();
            string str16 = validacaoResultado.Rows[validacaoResultado.CurrentCell.RowIndex].Cells["RESPONSAVEL"].Value.ToString();
            string str17 = $"<BR><P>Olá, <P>A demanda <STRONG>{newValue1}</STRONG>, para o segmento <U>{str14}</U> teve sua data de conclusão atualizada para <U>{str13}</U>.<table><tr><td bgcolor=''>Solicitante: </td><td>{str10}</td></tr><tr><td bgcolor=''>Desenvolvedor: </td><td>{str16}</td></tr><tr><td bgcolor=''>Responsável pela homologação: </td><td>{str2}</td></tr><tr><td bgcolor=''>Vigência: </td><td>{str6}</td></tr><tr><td bgcolor=''>Demanda: </td><td>{str7}</td></tr><tr><td bgcolor=''>Tipo: </td><td>{str8}</td></tr></table><P>Favor salvar as evidências de validação no <a href='{str15}'>Sharepoint</a>.<BR><P><FONT COLOR='#4B0082'>* Atenção: </FONT>caso a pasta {newValue1} ainda não exista, você deve criá-la no endereço abaixo, clicando em [Novo] > [Pasta].<p><a href='{str12}'>{str12}</a><p>";
            DataTable dataTable2 = DAL.PegarDadosTOT($"SELECT DISTINCT U.EMAIL EMAIL FROM GVDW_OWNER.RV_B2B_USUARIOS_APP U WHERE U.NM_USUARIO IN('{str9}','{str10}','{str2}') OR U.NM_USUARIO IN(     SELECT H1.GESTOR     FROM GVDW_OWNER.VW_RV_B2B_HC_AREAS_COMPLETA H1     WHERE H1.NOME IN ('{str9}','{str10}','{str2}')     AND H1.PERIODO = TO_CHAR(ADD_MONTHS(SYSDATE,-1),'YYYYMM') )");
            for (int index = 0; index < dataTable2.Rows.Count; ++index)
              str1 = $"{str1}{dataTable2.Rows[index]["EMAIL"].ToString()};\n";
            if (MessageBox.Show($"Você concorda em enviar email para os responsáveis informando que a demanda {newValue1} foi concluída?\n\nUm email será enviado em seu nome para cada um dos seguintes destinatários:\n\n{str1}", "TOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
            {
              foreach (DataRow row in (InternalDataCollectionBase) dataTable2.Rows)
              {
                string emailDestinatario = row["EMAIL"].ToString();
                this.preencherBarraStatusPrincipal($"Enviar email para {emailDestinatario}...");
                BLL.enviarEmail(emailDestinatario, emailAssunto, $"<img align=\"baseline\" hspace=\"0\" src=\"cid:myident\" hold=\" /> \"></img>{str17}<img align=\"baseline\" hspace=\"0\" src=\"cid:myident1\" hold=\" /> \"></img>");
              }
              this.preencherBarraStatusPrincipal("Processo de envio de emails terminado.");
              break;
            }
            this.preencherBarraStatusPrincipal("Envio de email cancelado.", true);
            break;
          }
          int num = (int) MessageBox.Show("Para enviar o email de conclusão é preciso primeiro preencher a data de conclusão.", "TOT - Falta data de conclusão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          break;
        case 1:
          string str18 = idDemandaDivulgar.Remove(idDemandaDivulgar.Length - 1);
          DataTable dataTable3 = DAL.PegarDadosTOT($"select d.id id_demanda, d.responsavel, d.solicitante, d.responsavel_homolog, d.segmento, d.vigencia, d.demandas_para_desenvolvimentos, d.tipo, d.data_limite, (select max(u.email) from GVDW_OWNER.RV_B2B_USUARIOS_APP u where upper(u.nm_usuario) = d.responsavel) email from gvdw_owner.rv_b2b_controle_demandas d where d.id in ({str18})");
          if (!dataTable3.Columns.Contains("id_demanda") || !MessageBox.Show($"Identificamos que existem demandas de desenvolvimento cadastradas por você ({str18}) que ainda não foram notificadas aos desenvolvedores.\n\nVocê concorda em enviar email para os desenvolvedores responsáveis?\n\nUm email será enviado em seu nome para os desenvolvedores que ainda não foram notificados sobre demandas criadas por você.{str1}", "TOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
            break;
          for (int index = 0; index < dataTable3.Rows.Count; ++index)
          {
            dataTable3.Rows[index]["responsavel"].ToString();
            string str19 = dataTable3.Rows[index]["solicitante"].ToString();
            string str20 = dataTable3.Rows[index]["segmento"].ToString();
            string newValue2 = dataTable3.Rows[index]["id_demanda"].ToString();
            string str21 = dataTable3.Rows[index]["vigencia"].ToString();
            string str22 = dataTable3.Rows[index]["demandas_para_desenvolvimentos"].ToString();
            string str23 = dataTable3.Rows[index]["tipo"].ToString();
            string str24 = dataTable3.Rows[index]["data_limite"].ToString().Substring(0, 10);
            string emailDestinatario = dataTable3.Rows[index]["email"].ToString();
            string emailAssunto = DAL.PegarValorParametro("ASSUNTO_EMAIL_DEMANDA_NOVA").Replace("__IDDEMANDA__", newValue2);
            string str25 = $"<BR><P>Olá,<P>A demanda <STRONG>{newValue2}</STRONG>, para o segmento <U>{str20}</U> foi criada e você está definido como responsável pelo desenvolvimento.<table><tr><td bgcolor=''>Solicitante: </td><td>{str19}</td></tr><tr><td bgcolor=''>Demanda: </td><td>{str22}</td></tr><tr><td bgcolor=''>Data limite: </td><td>{str24}</td></tr><tr><td bgcolor=''>Vigência: </td><td>{str21}</td></tr><tr><td bgcolor=''>Tipo: </td><td>{str23}</td></tr></table>";
            this.preencherBarraStatusPrincipal($"Enviando email para {emailDestinatario}, demanda {newValue2}...");
            BLL.enviarEmail(emailDestinatario, emailAssunto, $"<img align=\"baseline\" hspace=\"0\" src=\"cid:myident\" hold=\" /> \"></img>{str25}<img align=\"baseline\" hspace=\"0\" src=\"cid:myident1\" hold=\" /> \"></img>");
            dataTable1 = DAL.PegarDadosTOT($"update gvdw_owner.rv_b2b_controle_demandas set ENVIOU_EMAIL_RESPONSAVEL = 'SIM' where id = '{newValue2}'", alteracao: true);
            this.preencherBarraStatusPrincipal("");
          }
          break;
        case 2:
          string emailAssunto1 = DAL.PegarValorParametro("ASSUNTO_EMAIL_DEMANDA_REVISAO").Replace("__IDDEMANDA__", idDemandaDivulgar);
          string str26 = $"<BR><P>Olá, <P>A demanda <STRONG>{idDemandaDivulgar}</STRONG>, para o segmento <U>{str4}</U> teve seu status de homologação alterado para <font color='#A72205'><U>{str5}</U></font>.<table><tr><td bgcolor=''>Solicitante: </td><td>{str10}</td></tr><tr><td bgcolor=''>Desenvolvedor: </td><td>{str9}</td></tr><tr><td bgcolor=''>Responsável pela homologação: </td><td>{str2}</td></tr><tr><td bgcolor=''>Vigência: </td><td>{str6}</td></tr><tr><td bgcolor=''>Demanda: </td><td>{str7}</td></tr><tr><td bgcolor=''>Tipo: </td><td>{str8}</td></tr></table>";
          DataTable dataTable4 = DAL.PegarDadosTOT($"SELECT DISTINCT U.EMAIL EMAIL FROM GVDW_OWNER.RV_B2B_USUARIOS_APP U WHERE U.NM_USUARIO IN('{str9}','{str10}','{str2}') OR U.NM_USUARIO IN(     SELECT H1.GESTOR     FROM GVDW_OWNER.VW_RV_B2B_HC_AREAS_COMPLETA H1     WHERE H1.NOME IN ('{str9}','{str10}','{str2}')     AND H1.PERIODO = TO_CHAR(ADD_MONTHS(SYSDATE,-1),'YYYYMM') )");
          for (int index = 0; index < dataTable4.Rows.Count; ++index)
            str1 = $"{str1}{dataTable4.Rows[index]["EMAIL"].ToString()};\n";
          if (MessageBox.Show($"Você concorda em enviar email para os responsáveis informando que a demanda {str3} teve o status da homologação alterado para {str5}?\n\nUm email será enviado em seu nome para cada um dos seguintes destinatários:\n\n{str1}", "TOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
          {
            foreach (DataRow row in (InternalDataCollectionBase) dataTable4.Rows)
            {
              string emailDestinatario = row["EMAIL"].ToString();
              this.preencherBarraStatusPrincipal($"Enviar email para {emailDestinatario}...");
              BLL.enviarEmail(emailDestinatario, emailAssunto1, $"<img align=\"baseline\" hspace=\"0\" src=\"cid:myident\" hold=\" /> \"></img>{str26}<img align=\"baseline\" hspace=\"0\" src=\"cid:myident1\" hold=\" /> \"></img>");
            }
            this.preencherBarraStatusPrincipal("Processo de envio de emails terminado.");
          }
          else
            this.preencherBarraStatusPrincipal("Envio de email cancelado.", true);
          this.preencherBarraStatusPrincipal("");
          break;
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Ocorreu o seguinte erro ao tentar enviar email:", ex.Message);
    }
  }

  private void gerarRelatorioValidacao()
  {
    try
    {
      string str1 = "";
      DataGridView validacaoResultado = this.dgvValidacaoResultado;
      string newValue = $"<!DOCTYPE html>\n<html>\n<head>\n<meta charset='UTF-8'><title>Validação</title>\n<style>\r\n                        body {{\r\n                        font-family: Arial, Helvetica,sans-serif;\r\n                        margin: 0;\r\n                        padding: 0;\r\n                        background-color: #f2f2f2;\r\n                        }}\r\n                        #container {{\r\n                        margin: 20px;\r\n                        background-color: white;\r\n                        padding: 20px;\r\n                        border-radius: 5px;\r\n                        text-align: center; /* Centralizar o conteúdo */\r\n                        }}\r\n                        #customers {{\r\n                        font-size: 10px;\r\n                        border-collapse: collapse;\r\n                        text-align: center;\r\n                        width: 100%;\r\n                        }}\r\n                        #customers td, #customers th {{\r\n                        border: 1px solid #ddd;\r\n                        /*padding: 8px;*/\r\n                        }}\r\n                        #customers tr:nth-child(even){{\r\n                        background-color: #f2f2f2;\r\n                        }}\r\n                        #customers tr:hover {{\r\n                        background-color: #ddd;\r\n                        }}\r\n                        #container {{\r\n                        margin: 20px;\r\n                        background-color: white;\r\n                        padding: 20px;\r\n                        border-radius: 5px;\r\n                        text-align: center; /* Centralizar o conteúdo */\r\n                        }}\r\n                        #customers th {{\r\n                        /*padding-top: 12px;\r\n                        padding-bottom: 12px;*/\r\n                        text-align: center;\r\n                        background-color: #883397;\r\n                        color: white;\r\n                        }}\r\n                        @media print {{\r\n                        .pagebreak {{\r\n                        clear: both;\r\n                        page-break-after: always;\r\n                        }}\r\n                        }}\r\n                        </style></head>\n<body>\n<h4><strong>Gerência de Remuneração Variável</strong></h4><h6>Relatório de validação de cenários de cálculo - {DateTime.Now.ToString("dd-MM-yyyy HH:mm")}h - {Globals._loginRedeUsuario}</h6>";
      for (int index1 = 0; index1 < validacaoResultado.RowCount; ++index1)
      {
        string consulta = validacaoResultado.Rows[index1].Cells["SQL"].Value.ToString();
        string str2 = validacaoResultado.Rows[index1].Cells["NOME_VALIDACAO"].Value.ToString();
        this.preencherBarraStatusPrincipal($"Executando consulta {str2}...");
        System.Windows.Forms.Application.DoEvents();
        DataTable dataTable = DAL.PegarDadosTOT(consulta);
        int count = dataTable.Columns.Count;
        string str3 = $"{newValue + "<table id=\"customers\">\n" + "<thead>\n"}<tr><th style='font-size: 14px;' colspan={count.ToString()}><p>{str2}</p></th></tr>" + "<tr>\n";
        for (int index2 = 0; index2 < dataTable.Columns.Count; ++index2)
          str3 = $"{str3}<th>{dataTable.Columns[index2].ColumnName.ToString()}</th>\n";
        for (int index3 = 0; index3 < dataTable.Rows.Count; ++index3)
        {
          string str4 = str3 + "<tr>\n";
          for (int columnIndex = 0; columnIndex < dataTable.Columns.Count; ++columnIndex)
            str4 = $"{str4}<td>{dataTable.Rows[index3][columnIndex].ToString()}</td>\n";
          str3 = str4 + "</tr>\n";
        }
        newValue = str3 + "</tbody>\n" + "</table><br />\n" + "<div class=\"pagebreak\"> </div>\n";
      }
      str1.Replace("__CORPO__", newValue);
      File.WriteAllText("C:\\Temp\\Relatorio Validacao.html", newValue + "</body></html>");
      Process.Start("C:\\Temp\\Relatorio Validacao.html");
      this.preencherBarraStatusPrincipal("");
    }
    catch (Exception ex)
    {
      BLL.erro("Falha ao gerar o relatório", ex.Message);
    }
  }

  private bool envioEmailsPendentesNovasDemandas() => false;

  private void atuarSobreDemandasNovas()
  {
    string upper = Globals._loginRedeUsuario.ToUpper();
    int startIndex = upper.IndexOf("\\") + 1;
    DataTable dataTable = DAL.PegarDadosTOT($"select * from GVDW_OWNER.RV_B2B_CONTROLE_DEMANDAS where upper(enviou_email_responsavel) = 'NAO' and status not in ('CONCLUIDO','CANCELADO') and upper(usuario_insert) = '{upper.Substring(startIndex, upper.Length - startIndex)}'");
    if (dataTable.Columns.Contains("errotot"))
    {
      BLL.erro("Erro ao tetar recuperar ID pendentes de divulgação:", dataTable.Rows[0][0].ToString());
    }
    else
    {
      int count = dataTable.Rows.Count;
      if (count > 0)
      {
        string idDemandaDivulgar = "";
        for (int index = 0; index < count; ++index)
          idDemandaDivulgar = $"{idDemandaDivulgar}{dataTable.Rows[index]["ID"].ToString()},";
        this.enviarEmailMudancaStatusDemanda(1, idDemandaDivulgar);
      }
    }
  }

  private void cmbPeriodoInformativo_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "PERIODO");
  }

  private void cmbCanalInformativo_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "CANAL");
  }

  private void cmbCalculoInformativo_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "CALCULO");
  }

  private void cmbVersaoInformativo_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "ID_VERSAO");
  }

  private void cmbCargoInformativo_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "CARGO");
  }

  private void cmbTrimestreInformativo_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.executarFiltroComboEmediatamente((ComboBox) sender, "TRIMESTRE");
  }

  private void btnApenasGerar_Click(object sender, EventArgs e) => this.gerarInformativoExcel();

  private void btnEnviarParaMim_Click(object sender, EventArgs e) => this.gerarInformativoExcel(1);

  private void btnDivulgar_Click(object sender, EventArgs e)
  {
    if (MessageBox.Show("Confirmar a geração e DIVULGAÇÃO dos informativos selecionados via email?\n\nApós confirmar não serão possível cancelar o envio", "TOT - Divulgação de informativos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
      this.gerarInformativoExcel(2);
    else
      this.preencherBarraStatusPrincipal("Envio de informativos cancelado");
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmConsultaBancos));
    this.tabValidacaoResultados = new TabControl();
    this.tpValidacaoResultadoInicio = new TabPage();
    this.tabOpcoes = new TabControl();
    this.tabOpcoesConsultas = new TabPage();
    this.panel1 = new Panel();
    this.chkDesativarFormatacao = new CheckBox();
    this.chkFiltroDiferenciaMaiuscula = new CheckBox();
    this.cmbDelimitador = new ComboBox();
    this.chkPreVisualizacao = new CheckBox();
    this.chkExportar = new CheckBox();
    this.chkModoCompatibilidade = new CheckBox();
    this.chkRemoverDuplicados = new CheckBox();
    this.tabValidaResultAux1 = new TabControl();
    this.tabHistoricoConsultas = new TabPage();
    this.lbHistoricoConsultas = new ListBox();
    this.grpFiltrosValidacaoResultado = new GroupBox();
    this.btnAbrirConsultaValidacaoResultado = new Button();
    this.imgValidacaoResultado16x16 = new ImageList(this.components);
    this.btnSalvarConsultaValidacaoResultado = new Button();
    this.btnGerarSQLValidacaoResultado = new Button();
    this.btnLimpaFiltroValidacaoResultado = new Button();
    this.dgvFiltrosValidacaoResultado = new DataGridView();
    this.tpDataQuality = new TabPage();
    this.groupBox4 = new GroupBox();
    this.chkRealizadoZerado = new CheckBox();
    this.label9 = new Label();
    this.cmbCenarioDQ = new ComboBox();
    this.panel6 = new Panel();
    this.btnLimpaFiltrosDQ = new Button();
    this.btnParametrosDataQuality = new Button();
    this.label10 = new Label();
    this.cmbTipoDQ = new ComboBox();
    this.label11 = new Label();
    this.cmbInsumoDQ = new ComboBox();
    this.label12 = new Label();
    this.cmbCanalDQ = new ComboBox();
    this.label13 = new Label();
    this.cmbPeriodoDQ = new ComboBox();
    this.label14 = new Label();
    this.cmbSegmentoDQ = new ComboBox();
    this.tpCalculo = new TabPage();
    this.groupBox2 = new GroupBox();
    this.panel5 = new Panel();
    this.chkOrdenarProcessos = new CheckBox();
    this.chkPararCalculoSeHouverErro = new CheckBox();
    this.chkEmailDeErroPraMim = new CheckBox();
    this.groupBox1 = new GroupBox();
    this.btnDocumentacaoPrograma = new Button();
    this.imgValidacaoResultado32x32 = new ImageList(this.components);
    this.label1 = new Label();
    this.btnExecutarProgramas = new Button();
    this.cmbSegmentos = new ComboBox();
    this.btnLiberarTodosProgramas = new Button();
    this.label2 = new Label();
    this.btnBloquearTodosProgramas = new Button();
    this.cmbPeriodo = new ComboBox();
    this.tpCalculoPrincipal = new TabPage();
    this.rtbStatusProcessamento = new RichTextBox();
    this.groupBox3 = new GroupBox();
    this.label8 = new Label();
    this.cmbStatusCalc = new ComboBox();
    this.panel2 = new Panel();
    this.btnLimparFiltrosCalc = new Button();
    this.btnBloquearCalc = new Button();
    this.btnHistoricoExecucaoCalc = new Button();
    this.btnDetalharProgramasCalc = new Button();
    this.label6 = new Label();
    this.cmbTipoCalc = new ComboBox();
    this.label7 = new Label();
    this.cmbVersaoExecCalc = new ComboBox();
    this.label5 = new Label();
    this.cmbCanalCalc = new ComboBox();
    this.label3 = new Label();
    this.cmbPeriodoCalc = new ComboBox();
    this.label4 = new Label();
    this.cmbSegmentoCalc = new ComboBox();
    this.btnExecutarProgramasCalculo = new Button();
    this.tpCargaInsumos = new TabPage();
    this.rtbStatusCargaBase = new RichTextBox();
    this.groupBox5 = new GroupBox();
    this.panel7 = new Panel();
    this.btnLimparFiltrosBases = new Button();
    this.button2 = new Button();
    this.button3 = new Button();
    this.button4 = new Button();
    this.label16 = new Label();
    this.cmbNomeBases = new ComboBox();
    this.label18 = new Label();
    this.cmbCanalBases = new ComboBox();
    this.label19 = new Label();
    this.cmbPeriodoBases = new ComboBox();
    this.label20 = new Label();
    this.cmbSegmentoBases = new ComboBox();
    this.btnCarregarBase = new Button();
    this.tpInformativos = new TabPage();
    this.groupBox6 = new GroupBox();
    this.btnDivulgar = new Button();
    this.btnEnviarParaMim = new Button();
    this.btnApenasGerar = new Button();
    this.label15 = new Label();
    this.cmbCargoInformativo = new ComboBox();
    this.label17 = new Label();
    this.cmbVersaoInformativo = new ComboBox();
    this.label21 = new Label();
    this.cmbTrimestreInformativo = new ComboBox();
    this.label22 = new Label();
    this.cmbCanalInformativo = new ComboBox();
    this.label23 = new Label();
    this.cmbPeriodoInformativo = new ComboBox();
    this.label24 = new Label();
    this.cmbCalculoInformativo = new ComboBox();
    this.button7 = new Button();
    this.btnAdicionarLinhas = new Button();
    this.btnSalvarNovasLinhas = new Button();
    this.btnExcluir = new Button();
    this.btnEstatisticas = new Button();
    this.btnVRExportarExcel = new Button();
    this.btnPesquisarEditar = new Button();
    this.btnPesquisarValidacaoResultado = new Button();
    this.imgValidacaoResultado24x24 = new ImageList(this.components);
    this.dgvValidacaoResultado = new DataGridView();
    this.imgValidacaoResultado48x48 = new ImageList(this.components);
    this.tipVRDiversos = new ToolTip(this.components);
    this.btPesquisarTabelas = new Button();
    this.btLimparFiltroTabelas = new Button();
    this.btnNovaConsultaBancos = new Button();
    this.igualToolStripMenuItem = new ToolStripMenuItem();
    this.diferenteToolStripMenuItem = new ToolStripMenuItem();
    this.contémlikeToolStripMenuItem = new ToolStripMenuItem();
    this.nãoContémNotLikeToolStripMenuItem = new ToolStripMenuItem();
    this.maiorToolStripMenuItem = new ToolStripMenuItem();
    this.maiorOuIgualToolStripMenuItem = new ToolStripMenuItem();
    this.cmsFiltrosValidacaoResultado = new ContextMenuStrip(this.components);
    this.entreToolStripMenuItem = new ToolStripMenuItem();
    this.toolStripMenuItem1 = new ToolStripMenuItem();
    this.cmsTxFiltroInicial = new ToolStripTextBox();
    this.toolStripMenuItem3 = new ToolStripMenuItem();
    this.cmsTxFiltroFinal = new ToolStripTextBox();
    this.cmsFiltrarEntre = new ToolStripMenuItem();
    this.toolStripSeparator2 = new ToolStripSeparator();
    this.cmsLimparOperador = new ToolStripMenuItem();
    this.cmsValidacaoResultado = new ContextMenuStrip(this.components);
    this.cmsExecutarPrograma = new ToolStripMenuItem();
    this.cmsPesquisarNestaColuna = new ToolStripMenuItem();
    this.cmsTextoPesquisaValidacaoResultado = new ToolStripTextBox();
    this.cmsLimparFiltroColuna = new ToolStripMenuItem();
    this.toolStripSeparator12 = new ToolStripSeparator();
    this.cmsItemSelecionarTudo = new ToolStripMenuItem();
    this.cmsItemCopiar = new ToolStripMenuItem();
    this.cmsCopiarComCabecalho = new ToolStripMenuItem();
    this.cmsAbrirTextoEmOutraJanela = new ToolStripMenuItem();
    this.cmsHomolog = new ToolStripMenuItem();
    this.cmsGerarWord = new ToolStripMenuItem();
    this.cmsReenviarWord = new ToolStripMenuItem();
    this.sinalizarCélulaToolStripMenuItem = new ToolStripMenuItem();
    this.cmsFundoVerde = new ToolStripMenuItem();
    this.cmsFundoAmarelo = new ToolStripMenuItem();
    this.cmsFundoVermelho = new ToolStripMenuItem();
    this.cmsFundoBranco = new ToolStripMenuItem();
    this.toolStripSeparator6 = new ToolStripSeparator();
    this.cmsOcultarColuna = new ToolStripMenuItem();
    this.cmsReexibirColunas = new ToolStripMenuItem();
    this.cmsAjustarColuna = new ToolStripMenuItem();
    this.cmsInserirLinha = new ToolStripMenuItem();
    this.toolStripSeparator4 = new ToolStripSeparator();
    this.cmsExportarResultado = new ToolStripMenuItem();
    this.separadoPorPortoEVírgulaToolStripMenuItem = new ToolStripMenuItem();
    this.toolStripSeparator3 = new ToolStripSeparator();
    this.cmsExportarResultadoPontoVirgula = new ToolStripMenuItem();
    this.cmsExportarResultadoPipe = new ToolStripMenuItem();
    this.toolStripSeparator5 = new ToolStripSeparator();
    this.cmsInformacoesEdicao = new ToolStripMenuItem();
    this.cmsInformativos = new ToolStripMenuItem();
    this.cmsApenasGerarInformativo = new ToolStripMenuItem();
    this.gerarEEnviarToolStripMenuItem = new ToolStripMenuItem();
    this.cmsGerarEnviarInformativoParaMim = new ToolStripMenuItem();
    this.cmsGerarEnviarInformativosParaColaboradores = new ToolStripMenuItem();
    this.cmsExportarCronogramaInsumos = new ToolStripMenuItem();
    this.cmsGerarKanban = new ToolStripMenuItem();
    this.calendárioDeDemandasToolStripMenuItem = new ToolStripMenuItem();
    this.cmsGerarNovoKanban = new ToolStripMenuItem();
    this.cmsAtualizaVolumetriaInsumos = new ToolStripMenuItem();
    this.cmsGraficoVariacao = new ToolStripMenuItem();
    this.tsmGerarInformativo = new ToolStripMenuItem();
    this.cmsPropriedadesTabelas = new ContextMenuStrip(this.components);
    this.cmsAddFavoritos = new ToolStripMenuItem();
    this.cmsDelFavoritos = new ToolStripMenuItem();
    this.toolStripSeparator11 = new ToolStripSeparator();
    this.cmsAtualizarListaTabelas = new ToolStripMenuItem();
    this.cmsCopiarNomeTabela = new ToolStripMenuItem();
    this.toolStripSeparator1 = new ToolStripSeparator();
    this.cmsExpandirBancos = new ToolStripMenuItem();
    this.cmsContrairBancos = new ToolStripMenuItem();
    this.toolStripSeparator8 = new ToolStripSeparator();
    this.cmsHabilitarEdicao = new ToolStripMenuItem();
    this.cmsCarregarDados = new ToolStripMenuItem();
    this.toolStripSeparator9 = new ToolStripSeparator();
    this.cmsPropriedades = new ToolStripMenuItem();
    this.estatísticasToolStripMenuItem = new ToolStripMenuItem();
    this.cmsVolumetriaTabelas = new ToolStripMenuItem();
    this.toolStripSeparator10 = new ToolStripSeparator();
    this.cmsAdicionaTabela = new ToolStripMenuItem();
    this.cmsRemoverTabela = new ToolStripMenuItem();
    this.ofdAcessarArquivos = new OpenFileDialog();
    this.sfdSalvarArquivos = new SaveFileDialog();
    this.cmsFiltroCabecalhoValidacaoResultado = new ContextMenuStrip(this.components);
    this.cmsColunaFiltrada = new ToolStripMenuItem();
    this.toolStripSeparator7 = new ToolStripSeparator();
    this.cmsCmbOperadores = new ToolStripComboBox();
    this.cmsTextoFiltrar = new ToolStripTextBox();
    this.cmsAdicionarFiltros = new ToolStripMenuItem();
    this.toolStripMenuItem2 = new ToolStripMenuItem();
    this.toolStripSeparator13 = new ToolStripSeparator();
    this.cmsAdicionarFiltrosEPesquisar = new ToolStripMenuItem();
    this.cmsAdicionarFiltrosEPesquisarEEditar = new ToolStripMenuItem();
    this.tabPage1 = new TabPage();
    this.txPesquisarTabelas = new TextBox();
    this.tvwValidacaoResultado = new TreeView();
    this.tabNavegacao = new TabControl();
    this.notifyIcon1 = new NotifyIcon(this.components);
    this.imgValidacaoResultado64x16 = new ImageList(this.components);
    this.tabConsultaBancos = new TabControl();
    this.tabConsultaPrincipal = new TabPage();
    this.txConsultaAtual = new TextBox();
    this.txCodigoForm = new TextBox();
    this.txTabelaAtual = new TextBox();
    this.txtControleForms = new TextBox();
    this.panel3 = new Panel();
    this.tabSql = new TabPage();
    this.rtbSQL = new RichTextBox();
    this.cmsCombo = new ContextMenuStrip(this.components);
    this.cmbItensDataGrid = new ToolStripComboBox();
    this.cmsItemComboOK = new ToolStripMenuItem();
    this.cmsItemCombo = new ToolStripMenuItem();
    this.panel4 = new Panel();
    this.cmsProcurarArquivo = new ContextMenuStrip(this.components);
    this.toolStripSeparator14 = new ToolStripSeparator();
    this.tsmProcurarArquivo = new ToolStripMenuItem();
    this.cmsEditarCelulaArquivoOrigem = new ToolStripMenuItem();
    this.rtbInformativos = new RichTextBox();
    this.tabValidacaoResultados.SuspendLayout();
    this.tpValidacaoResultadoInicio.SuspendLayout();
    this.tabOpcoes.SuspendLayout();
    this.tabOpcoesConsultas.SuspendLayout();
    this.panel1.SuspendLayout();
    this.tabValidaResultAux1.SuspendLayout();
    this.tabHistoricoConsultas.SuspendLayout();
    this.grpFiltrosValidacaoResultado.SuspendLayout();
    ((ISupportInitialize) this.dgvFiltrosValidacaoResultado).BeginInit();
    this.tpDataQuality.SuspendLayout();
    this.groupBox4.SuspendLayout();
    this.panel6.SuspendLayout();
    this.tpCalculo.SuspendLayout();
    this.groupBox2.SuspendLayout();
    this.panel5.SuspendLayout();
    this.groupBox1.SuspendLayout();
    this.tpCalculoPrincipal.SuspendLayout();
    this.groupBox3.SuspendLayout();
    this.panel2.SuspendLayout();
    this.tpCargaInsumos.SuspendLayout();
    this.groupBox5.SuspendLayout();
    this.panel7.SuspendLayout();
    this.tpInformativos.SuspendLayout();
    this.groupBox6.SuspendLayout();
    ((ISupportInitialize) this.dgvValidacaoResultado).BeginInit();
    this.cmsFiltrosValidacaoResultado.SuspendLayout();
    this.cmsValidacaoResultado.SuspendLayout();
    this.cmsPropriedadesTabelas.SuspendLayout();
    this.cmsFiltroCabecalhoValidacaoResultado.SuspendLayout();
    this.tabPage1.SuspendLayout();
    this.tabNavegacao.SuspendLayout();
    this.tabConsultaBancos.SuspendLayout();
    this.tabConsultaPrincipal.SuspendLayout();
    this.tabSql.SuspendLayout();
    this.cmsCombo.SuspendLayout();
    this.panel4.SuspendLayout();
    this.cmsProcurarArquivo.SuspendLayout();
    this.SuspendLayout();
    this.tabValidacaoResultados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.tabValidacaoResultados.Controls.Add((Control) this.tpValidacaoResultadoInicio);
    this.tabValidacaoResultados.Controls.Add((Control) this.tpDataQuality);
    this.tabValidacaoResultados.Controls.Add((Control) this.tpCalculo);
    this.tabValidacaoResultados.Controls.Add((Control) this.tpCalculoPrincipal);
    this.tabValidacaoResultados.Controls.Add((Control) this.tpCargaInsumos);
    this.tabValidacaoResultados.Controls.Add((Control) this.tpInformativos);
    this.tabValidacaoResultados.Location = new Point(220, 1);
    this.tabValidacaoResultados.Name = "tabValidacaoResultados";
    this.tabValidacaoResultados.SelectedIndex = 0;
    this.tabValidacaoResultados.Size = new Size(1243, 117);
    this.tabValidacaoResultados.TabIndex = 0;
    this.tabValidacaoResultados.SelectedIndexChanged += new EventHandler(this.tabValidacaoResultados_SelectedIndexChanged);
    this.tpValidacaoResultadoInicio.Controls.Add((Control) this.tabOpcoes);
    this.tpValidacaoResultadoInicio.Controls.Add((Control) this.tabValidaResultAux1);
    this.tpValidacaoResultadoInicio.Controls.Add((Control) this.grpFiltrosValidacaoResultado);
    this.tpValidacaoResultadoInicio.Location = new Point(4, 22);
    this.tpValidacaoResultadoInicio.Name = "tpValidacaoResultadoInicio";
    this.tpValidacaoResultadoInicio.Padding = new Padding(3);
    this.tpValidacaoResultadoInicio.Size = new Size(1235, 91);
    this.tpValidacaoResultadoInicio.TabIndex = 1;
    this.tpValidacaoResultadoInicio.Text = "Página Inicial";
    this.tpValidacaoResultadoInicio.UseVisualStyleBackColor = true;
    this.tabOpcoes.Controls.Add((Control) this.tabOpcoesConsultas);
    this.tabOpcoes.Location = new Point(447, 3);
    this.tabOpcoes.Name = "tabOpcoes";
    this.tabOpcoes.SelectedIndex = 0;
    this.tabOpcoes.Size = new Size(200, 85);
    this.tabOpcoes.TabIndex = 11;
    this.tabOpcoesConsultas.Controls.Add((Control) this.panel1);
    this.tabOpcoesConsultas.Location = new Point(4, 22);
    this.tabOpcoesConsultas.Name = "tabOpcoesConsultas";
    this.tabOpcoesConsultas.Padding = new Padding(3);
    this.tabOpcoesConsultas.Size = new Size(192 /*0xC0*/, 59);
    this.tabOpcoesConsultas.TabIndex = 0;
    this.tabOpcoesConsultas.Text = "Opções";
    this.tabOpcoesConsultas.UseVisualStyleBackColor = true;
    this.panel1.AutoScroll = true;
    this.panel1.Controls.Add((Control) this.chkDesativarFormatacao);
    this.panel1.Controls.Add((Control) this.chkFiltroDiferenciaMaiuscula);
    this.panel1.Controls.Add((Control) this.cmbDelimitador);
    this.panel1.Controls.Add((Control) this.chkPreVisualizacao);
    this.panel1.Controls.Add((Control) this.chkExportar);
    this.panel1.Controls.Add((Control) this.chkModoCompatibilidade);
    this.panel1.Controls.Add((Control) this.chkRemoverDuplicados);
    this.panel1.Location = new Point(1, 0);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(188, 64 /*0x40*/);
    this.panel1.TabIndex = 14;
    this.chkDesativarFormatacao.AutoSize = true;
    this.chkDesativarFormatacao.Location = new Point(4, 80 /*0x50*/);
    this.chkDesativarFormatacao.Name = "chkDesativarFormatacao";
    this.chkDesativarFormatacao.Size = new Size(184, 17);
    this.chkDesativarFormatacao.TabIndex = 15;
    this.chkDesativarFormatacao.Text = "Desativar formatação condicional";
    this.chkDesativarFormatacao.UseVisualStyleBackColor = true;
    this.chkFiltroDiferenciaMaiuscula.AutoSize = true;
    this.chkFiltroDiferenciaMaiuscula.Location = new Point(4, 65);
    this.chkFiltroDiferenciaMaiuscula.Name = "chkFiltroDiferenciaMaiuscula";
    this.chkFiltroDiferenciaMaiuscula.Size = new Size(216, 17);
    this.chkFiltroDiferenciaMaiuscula.TabIndex = 14;
    this.chkFiltroDiferenciaMaiuscula.Text = "Filtro diferencia maiúsculas e minúsculas";
    this.chkFiltroDiferenciaMaiuscula.UseVisualStyleBackColor = true;
    this.cmbDelimitador.BackColor = SystemColors.Info;
    this.cmbDelimitador.FlatStyle = FlatStyle.Flat;
    this.cmbDelimitador.FormattingEnabled = true;
    this.cmbDelimitador.Items.AddRange(new object[2]
    {
      (object) ";",
      (object) "|"
    });
    this.cmbDelimitador.Location = new Point(129, 49);
    this.cmbDelimitador.Name = "cmbDelimitador";
    this.cmbDelimitador.Size = new Size(30, 21);
    this.cmbDelimitador.TabIndex = 13;
    this.chkPreVisualizacao.AutoSize = true;
    this.chkPreVisualizacao.Checked = true;
    this.chkPreVisualizacao.CheckState = CheckState.Checked;
    this.chkPreVisualizacao.Location = new Point(4, 3);
    this.chkPreVisualizacao.Name = "chkPreVisualizacao";
    this.chkPreVisualizacao.Size = new Size(103, 17);
    this.chkPreVisualizacao.TabIndex = 5;
    this.chkPreVisualizacao.Text = "Pré-visualização";
    this.chkPreVisualizacao.UseVisualStyleBackColor = true;
    this.chkPreVisualizacao.CheckedChanged += new EventHandler(this.chkPreVisualizacao_CheckedChanged);
    this.chkExportar.AutoSize = true;
    this.chkExportar.Location = new Point(4, 50);
    this.chkExportar.Name = "chkExportar";
    this.chkExportar.Size = new Size(126, 17);
    this.chkExportar.TabIndex = 12;
    this.chkExportar.Text = "Exportar ao consultar";
    this.chkExportar.UseVisualStyleBackColor = true;
    this.chkExportar.CheckedChanged += new EventHandler(this.chkExportar_CheckedChanged);
    this.chkModoCompatibilidade.AutoSize = true;
    this.chkModoCompatibilidade.Location = new Point(4, 35);
    this.chkModoCompatibilidade.Name = "chkModoCompatibilidade";
    this.chkModoCompatibilidade.Size = new Size(144 /*0x90*/, 17);
    this.chkModoCompatibilidade.TabIndex = 11;
    this.chkModoCompatibilidade.Text = "Modo de compatibilidade";
    this.chkModoCompatibilidade.UseVisualStyleBackColor = true;
    this.chkRemoverDuplicados.AutoSize = true;
    this.chkRemoverDuplicados.Location = new Point(4, 19);
    this.chkRemoverDuplicados.Name = "chkRemoverDuplicados";
    this.chkRemoverDuplicados.Size = new Size(123, 17);
    this.chkRemoverDuplicados.TabIndex = 6;
    this.chkRemoverDuplicados.Text = "Remover duplicados";
    this.chkRemoverDuplicados.UseVisualStyleBackColor = true;
    this.tabValidaResultAux1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabValidaResultAux1.Controls.Add((Control) this.tabHistoricoConsultas);
    this.tabValidaResultAux1.Location = new Point(653, 3);
    this.tabValidaResultAux1.Name = "tabValidaResultAux1";
    this.tabValidaResultAux1.SelectedIndex = 0;
    this.tabValidaResultAux1.Size = new Size(579, 85);
    this.tabValidaResultAux1.TabIndex = 15;
    this.tabHistoricoConsultas.Controls.Add((Control) this.lbHistoricoConsultas);
    this.tabHistoricoConsultas.Location = new Point(4, 22);
    this.tabHistoricoConsultas.Name = "tabHistoricoConsultas";
    this.tabHistoricoConsultas.Padding = new Padding(3);
    this.tabHistoricoConsultas.Size = new Size(571, 59);
    this.tabHistoricoConsultas.TabIndex = 0;
    this.tabHistoricoConsultas.Text = "Histórico";
    this.tabHistoricoConsultas.UseVisualStyleBackColor = true;
    this.lbHistoricoConsultas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.lbHistoricoConsultas.BorderStyle = BorderStyle.None;
    this.lbHistoricoConsultas.FormattingEnabled = true;
    this.lbHistoricoConsultas.HorizontalScrollbar = true;
    this.lbHistoricoConsultas.Location = new Point(1, 1);
    this.lbHistoricoConsultas.Name = "lbHistoricoConsultas";
    this.lbHistoricoConsultas.Size = new Size(563, 52);
    this.lbHistoricoConsultas.TabIndex = 0;
    this.lbHistoricoConsultas.DoubleClick += new EventHandler(this.lbHistoricoConsultas_DoubleClick);
    this.lbHistoricoConsultas.KeyDown += new KeyEventHandler(this.lbHistoricoConsultas_KeyDown);
    this.lbHistoricoConsultas.KeyPress += new KeyPressEventHandler(this.lbHistoricoConsultas_KeyPress);
    this.grpFiltrosValidacaoResultado.Controls.Add((Control) this.btnAbrirConsultaValidacaoResultado);
    this.grpFiltrosValidacaoResultado.Controls.Add((Control) this.btnSalvarConsultaValidacaoResultado);
    this.grpFiltrosValidacaoResultado.Controls.Add((Control) this.btnGerarSQLValidacaoResultado);
    this.grpFiltrosValidacaoResultado.Controls.Add((Control) this.btnLimpaFiltroValidacaoResultado);
    this.grpFiltrosValidacaoResultado.Controls.Add((Control) this.dgvFiltrosValidacaoResultado);
    this.grpFiltrosValidacaoResultado.Location = new Point(6, 4);
    this.grpFiltrosValidacaoResultado.Name = "grpFiltrosValidacaoResultado";
    this.grpFiltrosValidacaoResultado.Size = new Size(436, 84);
    this.grpFiltrosValidacaoResultado.TabIndex = 1;
    this.grpFiltrosValidacaoResultado.TabStop = false;
    this.grpFiltrosValidacaoResultado.Text = "Filtros";
    this.btnAbrirConsultaValidacaoResultado.BackColor = Color.White;
    this.btnAbrirConsultaValidacaoResultado.ImageKey = "iconfinder_folder_closed_59915.png";
    this.btnAbrirConsultaValidacaoResultado.ImageList = this.imgValidacaoResultado16x16;
    this.btnAbrirConsultaValidacaoResultado.Location = new Point(369, 48 /*0x30*/);
    this.btnAbrirConsultaValidacaoResultado.Name = "btnAbrirConsultaValidacaoResultado";
    this.btnAbrirConsultaValidacaoResultado.Size = new Size(30, 30);
    this.btnAbrirConsultaValidacaoResultado.TabIndex = 10;
    this.btnAbrirConsultaValidacaoResultado.UseVisualStyleBackColor = false;
    this.btnAbrirConsultaValidacaoResultado.Visible = false;
    this.btnAbrirConsultaValidacaoResultado.Click += new EventHandler(this.btnAbrirConsultaValidacaoResultado_Click);
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
    this.imgValidacaoResultado16x16.Images.SetKeyName(32 /*0x20*/, "progress_amarelo.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(33, "progress_azul.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(34, "progress_verde.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(35, "progress_vermelho.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(36, "folder.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(37, "clear-filter.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(38, "gear.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(39, "document_plain_new.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(40, "lock.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(41, "lock_open.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(42, "document_time.png");
    this.btnSalvarConsultaValidacaoResultado.BackColor = Color.White;
    this.btnSalvarConsultaValidacaoResultado.ImageKey = "iconfinder_save_60025.png";
    this.btnSalvarConsultaValidacaoResultado.ImageList = this.imgValidacaoResultado16x16;
    this.btnSalvarConsultaValidacaoResultado.Location = new Point(402, 48 /*0x30*/);
    this.btnSalvarConsultaValidacaoResultado.Name = "btnSalvarConsultaValidacaoResultado";
    this.btnSalvarConsultaValidacaoResultado.Size = new Size(30, 30);
    this.btnSalvarConsultaValidacaoResultado.TabIndex = 9;
    this.btnSalvarConsultaValidacaoResultado.UseVisualStyleBackColor = false;
    this.btnSalvarConsultaValidacaoResultado.Click += new EventHandler(this.btnSalvarConsultaValidacaoResultado_Click);
    this.btnGerarSQLValidacaoResultado.BackColor = Color.White;
    this.btnGerarSQLValidacaoResultado.ImageKey = "iconfinder_document-information_59879.png";
    this.btnGerarSQLValidacaoResultado.ImageList = this.imgValidacaoResultado16x16;
    this.btnGerarSQLValidacaoResultado.Location = new Point(402, 14);
    this.btnGerarSQLValidacaoResultado.Name = "btnGerarSQLValidacaoResultado";
    this.btnGerarSQLValidacaoResultado.Size = new Size(30, 30);
    this.btnGerarSQLValidacaoResultado.TabIndex = 8;
    this.btnGerarSQLValidacaoResultado.UseVisualStyleBackColor = false;
    this.btnGerarSQLValidacaoResultado.Click += new EventHandler(this.btnGerarSQLValidacaoResultado_Click);
    this.btnLimpaFiltroValidacaoResultado.BackColor = Color.White;
    this.btnLimpaFiltroValidacaoResultado.ImageKey = "iconfinder_list-delete3_59950.png";
    this.btnLimpaFiltroValidacaoResultado.ImageList = this.imgValidacaoResultado16x16;
    this.btnLimpaFiltroValidacaoResultado.Location = new Point(369, 14);
    this.btnLimpaFiltroValidacaoResultado.Name = "btnLimpaFiltroValidacaoResultado";
    this.btnLimpaFiltroValidacaoResultado.Size = new Size(30, 30);
    this.btnLimpaFiltroValidacaoResultado.TabIndex = 7;
    this.btnLimpaFiltroValidacaoResultado.UseVisualStyleBackColor = false;
    this.btnLimpaFiltroValidacaoResultado.Click += new EventHandler(this.btnLimpaFiltroValidacaoResultado_Click);
    this.dgvFiltrosValidacaoResultado.AllowUserToAddRows = false;
    this.dgvFiltrosValidacaoResultado.AllowUserToDeleteRows = false;
    this.dgvFiltrosValidacaoResultado.BackgroundColor = SystemColors.ControlLight;
    this.dgvFiltrosValidacaoResultado.BorderStyle = BorderStyle.Fixed3D;
    this.dgvFiltrosValidacaoResultado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvFiltrosValidacaoResultado.Location = new Point(9, 14);
    this.dgvFiltrosValidacaoResultado.MultiSelect = false;
    this.dgvFiltrosValidacaoResultado.Name = "dgvFiltrosValidacaoResultado";
    this.dgvFiltrosValidacaoResultado.Size = new Size(357, 64 /*0x40*/);
    this.dgvFiltrosValidacaoResultado.TabIndex = 1;
    this.dgvFiltrosValidacaoResultado.CellEndEdit += new DataGridViewCellEventHandler(this.dgvFiltrosValidacaoResultado_CellEndEdit);
    this.dgvFiltrosValidacaoResultado.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvFiltrosValidacaoResultado_DataBindingComplete);
    this.dgvFiltrosValidacaoResultado.Sorted += new EventHandler(this.dgvFiltrosValidacaoResultado_Sorted);
    this.dgvFiltrosValidacaoResultado.MouseClick += new MouseEventHandler(this.dgvFiltrosValidacaoResultado_MouseClick);
    this.tpDataQuality.Controls.Add((Control) this.groupBox4);
    this.tpDataQuality.Location = new Point(4, 22);
    this.tpDataQuality.Name = "tpDataQuality";
    this.tpDataQuality.Size = new Size(1235, 91);
    this.tpDataQuality.TabIndex = 2;
    this.tpDataQuality.Text = "Data Quality";
    this.tpDataQuality.UseVisualStyleBackColor = true;
    this.groupBox4.Controls.Add((Control) this.chkRealizadoZerado);
    this.groupBox4.Controls.Add((Control) this.label9);
    this.groupBox4.Controls.Add((Control) this.cmbCenarioDQ);
    this.groupBox4.Controls.Add((Control) this.panel6);
    this.groupBox4.Controls.Add((Control) this.label10);
    this.groupBox4.Controls.Add((Control) this.cmbTipoDQ);
    this.groupBox4.Controls.Add((Control) this.label11);
    this.groupBox4.Controls.Add((Control) this.cmbInsumoDQ);
    this.groupBox4.Controls.Add((Control) this.label12);
    this.groupBox4.Controls.Add((Control) this.cmbCanalDQ);
    this.groupBox4.Controls.Add((Control) this.label13);
    this.groupBox4.Controls.Add((Control) this.cmbPeriodoDQ);
    this.groupBox4.Controls.Add((Control) this.label14);
    this.groupBox4.Controls.Add((Control) this.cmbSegmentoDQ);
    this.groupBox4.Location = new Point(4, 3);
    this.groupBox4.Name = "groupBox4";
    this.groupBox4.Size = new Size(636, 85);
    this.groupBox4.TabIndex = 1;
    this.groupBox4.TabStop = false;
    this.chkRealizadoZerado.AutoSize = true;
    this.chkRealizadoZerado.Location = new Point(490, 12);
    this.chkRealizadoZerado.Name = "chkRealizadoZerado";
    this.chkRealizadoZerado.Size = new Size(142, 17);
    this.chkRealizadoZerado.TabIndex = 42;
    this.chkRealizadoZerado.Text = "Apenas realizado zerado";
    this.chkRealizadoZerado.UseVisualStyleBackColor = true;
    this.chkRealizadoZerado.CheckedChanged += new EventHandler(this.chkRealizadoZerado_CheckedChanged);
    this.label9.AutoSize = true;
    this.label9.Location = new Point(310, 38);
    this.label9.Name = "label9";
    this.label9.Size = new Size(43, 13);
    this.label9.TabIndex = 40;
    this.label9.Text = "Cenário";
    this.cmbCenarioDQ.FormattingEnabled = true;
    this.cmbCenarioDQ.Location = new Point(356, 35);
    this.cmbCenarioDQ.Name = "cmbCenarioDQ";
    this.cmbCenarioDQ.Size = new Size(269, 21);
    this.cmbCenarioDQ.TabIndex = 41;
    this.cmbCenarioDQ.SelectionChangeCommitted += new EventHandler(this.cmbCenarioDQ_SelectionChangeCommitted);
    this.panel6.Controls.Add((Control) this.btnLimpaFiltrosDQ);
    this.panel6.Controls.Add((Control) this.btnParametrosDataQuality);
    this.panel6.Location = new Point(7, 10);
    this.panel6.Name = "panel6";
    this.panel6.Size = new Size(39, 71);
    this.panel6.TabIndex = 39;
    this.btnLimpaFiltrosDQ.BackColor = Color.White;
    this.btnLimpaFiltrosDQ.ImageKey = "clear-filter.png";
    this.btnLimpaFiltrosDQ.ImageList = this.imgValidacaoResultado16x16;
    this.btnLimpaFiltrosDQ.Location = new Point(3, 37);
    this.btnLimpaFiltrosDQ.Name = "btnLimpaFiltrosDQ";
    this.btnLimpaFiltrosDQ.Size = new Size(30, 30);
    this.btnLimpaFiltrosDQ.TabIndex = 24;
    this.tipVRDiversos.SetToolTip((Control) this.btnLimpaFiltrosDQ, "Remover os filtros da pesquisa");
    this.btnLimpaFiltrosDQ.UseVisualStyleBackColor = false;
    this.btnLimpaFiltrosDQ.Click += new EventHandler(this.btnLimpaFiltrosDQ_Click);
    this.btnParametrosDataQuality.BackColor = Color.White;
    this.btnParametrosDataQuality.ImageKey = "iconfinder_Tools_60094.png";
    this.btnParametrosDataQuality.ImageList = this.imgValidacaoResultado16x16;
    this.btnParametrosDataQuality.Location = new Point(3, 5);
    this.btnParametrosDataQuality.Name = "btnParametrosDataQuality";
    this.btnParametrosDataQuality.Size = new Size(30, 30);
    this.btnParametrosDataQuality.TabIndex = 21;
    this.tipVRDiversos.SetToolTip((Control) this.btnParametrosDataQuality, "Configurar parâmetros de data quality");
    this.btnParametrosDataQuality.UseVisualStyleBackColor = false;
    this.btnParametrosDataQuality.Click += new EventHandler(this.btnParametrosDataQuality_Click);
    this.label10.AutoSize = true;
    this.label10.Location = new Point(325, 14);
    this.label10.Name = "label10";
    this.label10.Size = new Size(28, 13);
    this.label10.TabIndex = 36;
    this.label10.Text = "Tipo";
    this.cmbTipoDQ.FormattingEnabled = true;
    this.cmbTipoDQ.Location = new Point(356, 10);
    this.cmbTipoDQ.Name = "cmbTipoDQ";
    this.cmbTipoDQ.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbTipoDQ.TabIndex = 35;
    this.cmbTipoDQ.SelectionChangeCommitted += new EventHandler(this.cmbTipoDQ_SelectionChangeCommitted);
    this.label11.AutoSize = true;
    this.label11.Location = new Point(322, 64 /*0x40*/);
    this.label11.Name = "label11";
    this.label11.Size = new Size(31 /*0x1F*/, 13);
    this.label11.TabIndex = 37;
    this.label11.Text = "Base";
    this.cmbInsumoDQ.FormattingEnabled = true;
    this.cmbInsumoDQ.Location = new Point(356, 60);
    this.cmbInsumoDQ.Name = "cmbInsumoDQ";
    this.cmbInsumoDQ.Size = new Size(269, 21);
    this.cmbInsumoDQ.TabIndex = 38;
    this.cmbInsumoDQ.SelectionChangeCommitted += new EventHandler(this.cmbInsumoDQ_SelectionChangeCommitted);
    this.label12.AutoSize = true;
    this.label12.Location = new Point(70, 39);
    this.label12.Name = "label12";
    this.label12.Size = new Size(34, 13);
    this.label12.TabIndex = 33;
    this.label12.Text = "Canal";
    this.cmbCanalDQ.FormattingEnabled = true;
    this.cmbCanalDQ.Location = new Point(107, 35);
    this.cmbCanalDQ.Name = "cmbCanalDQ";
    this.cmbCanalDQ.Size = new Size(194, 21);
    this.cmbCanalDQ.TabIndex = 34;
    this.cmbCanalDQ.SelectionChangeCommitted += new EventHandler(this.cmbCanalDQ_SelectionChangeCommitted);
    this.label13.AutoSize = true;
    this.label13.Location = new Point(59, 14);
    this.label13.Name = "label13";
    this.label13.Size = new Size(45, 13);
    this.label13.TabIndex = 30;
    this.label13.Text = "Período";
    this.cmbPeriodoDQ.FormattingEnabled = true;
    this.cmbPeriodoDQ.Location = new Point(107, 10);
    this.cmbPeriodoDQ.Name = "cmbPeriodoDQ";
    this.cmbPeriodoDQ.Size = new Size(194, 21);
    this.cmbPeriodoDQ.TabIndex = 29;
    this.cmbPeriodoDQ.SelectionChangeCommitted += new EventHandler(this.cmbPeriodoDQ_SelectionChangeCommitted);
    this.label14.AutoSize = true;
    this.label14.Location = new Point(49, 63 /*0x3F*/);
    this.label14.Name = "label14";
    this.label14.Size = new Size(55, 13);
    this.label14.TabIndex = 31 /*0x1F*/;
    this.label14.Text = "Segmento";
    this.cmbSegmentoDQ.FormattingEnabled = true;
    this.cmbSegmentoDQ.Location = new Point(107, 59);
    this.cmbSegmentoDQ.Name = "cmbSegmentoDQ";
    this.cmbSegmentoDQ.Size = new Size(194, 21);
    this.cmbSegmentoDQ.TabIndex = 32 /*0x20*/;
    this.cmbSegmentoDQ.SelectionChangeCommitted += new EventHandler(this.cmbSegmentoDQ_SelectionChangeCommitted);
    this.tpCalculo.Controls.Add((Control) this.groupBox2);
    this.tpCalculo.Controls.Add((Control) this.groupBox1);
    this.tpCalculo.Location = new Point(4, 22);
    this.tpCalculo.Name = "tpCalculo";
    this.tpCalculo.Size = new Size(1235, 91);
    this.tpCalculo.TabIndex = 3;
    this.tpCalculo.Text = "Cálculo detalhado";
    this.tpCalculo.UseVisualStyleBackColor = true;
    this.groupBox2.Controls.Add((Control) this.panel5);
    this.groupBox2.Location = new Point(489, 0);
    this.groupBox2.Name = "groupBox2";
    this.groupBox2.Size = new Size(200, 88);
    this.groupBox2.TabIndex = 10;
    this.groupBox2.TabStop = false;
    this.groupBox2.Text = "Opções";
    this.panel5.AutoScroll = true;
    this.panel5.Controls.Add((Control) this.chkOrdenarProcessos);
    this.panel5.Controls.Add((Control) this.chkPararCalculoSeHouverErro);
    this.panel5.Controls.Add((Control) this.chkEmailDeErroPraMim);
    this.panel5.Location = new Point(7, 20);
    this.panel5.Name = "panel5";
    this.panel5.Size = new Size(187, 65);
    this.panel5.TabIndex = 0;
    this.chkOrdenarProcessos.AutoSize = true;
    this.chkOrdenarProcessos.Location = new Point(3, 42);
    this.chkOrdenarProcessos.Name = "chkOrdenarProcessos";
    this.chkOrdenarProcessos.Size = new Size(125, 17);
    this.chkOrdenarProcessos.TabIndex = 2;
    this.chkOrdenarProcessos.Text = "Ordenar ao consultar";
    this.chkOrdenarProcessos.UseVisualStyleBackColor = true;
    this.chkPararCalculoSeHouverErro.AutoSize = true;
    this.chkPararCalculoSeHouverErro.Checked = true;
    this.chkPararCalculoSeHouverErro.CheckState = CheckState.Checked;
    this.chkPararCalculoSeHouverErro.Location = new Point(3, 5);
    this.chkPararCalculoSeHouverErro.Name = "chkPararCalculoSeHouverErro";
    this.chkPararCalculoSeHouverErro.Size = new Size(158, 17);
    this.chkPararCalculoSeHouverErro.TabIndex = 0;
    this.chkPararCalculoSeHouverErro.Text = "Parar se um programa falhar";
    this.chkPararCalculoSeHouverErro.UseVisualStyleBackColor = true;
    this.chkEmailDeErroPraMim.AutoSize = true;
    this.chkEmailDeErroPraMim.Location = new Point(3, 24);
    this.chkEmailDeErroPraMim.Name = "chkEmailDeErroPraMim";
    this.chkEmailDeErroPraMim.Size = new Size(166, 17);
    this.chkEmailDeErroPraMim.TabIndex = 1;
    this.chkEmailDeErroPraMim.Text = "Email pra mim se houver falha";
    this.chkEmailDeErroPraMim.UseVisualStyleBackColor = true;
    this.groupBox1.Controls.Add((Control) this.btnDocumentacaoPrograma);
    this.groupBox1.Controls.Add((Control) this.label1);
    this.groupBox1.Controls.Add((Control) this.btnExecutarProgramas);
    this.groupBox1.Controls.Add((Control) this.cmbSegmentos);
    this.groupBox1.Controls.Add((Control) this.btnLiberarTodosProgramas);
    this.groupBox1.Controls.Add((Control) this.label2);
    this.groupBox1.Controls.Add((Control) this.btnBloquearTodosProgramas);
    this.groupBox1.Controls.Add((Control) this.cmbPeriodo);
    this.groupBox1.Location = new Point(2, 0);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(482, 88);
    this.groupBox1.TabIndex = 17;
    this.groupBox1.TabStop = false;
    this.btnDocumentacaoPrograma.BackColor = Color.White;
    this.btnDocumentacaoPrograma.ImageAlign = ContentAlignment.TopCenter;
    this.btnDocumentacaoPrograma.ImageKey = "icons8-manual-do-usuário-32.png";
    this.btnDocumentacaoPrograma.ImageList = this.imgValidacaoResultado32x32;
    this.btnDocumentacaoPrograma.Location = new Point(393, 13);
    this.btnDocumentacaoPrograma.Name = "btnDocumentacaoPrograma";
    this.btnDocumentacaoPrograma.Size = new Size(66, 66);
    this.btnDocumentacaoPrograma.TabIndex = 28;
    this.btnDocumentacaoPrograma.Text = "Código fonte";
    this.btnDocumentacaoPrograma.TextAlign = ContentAlignment.BottomCenter;
    this.tipVRDiversos.SetToolTip((Control) this.btnDocumentacaoPrograma, "Gerar documentação do programa");
    this.btnDocumentacaoPrograma.UseVisualStyleBackColor = false;
    this.btnDocumentacaoPrograma.Click += new EventHandler(this.btnDocumentacaoPrograma_Click);
    this.imgValidacaoResultado32x32.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgValidacaoResultado32x32.ImageStream");
    this.imgValidacaoResultado32x32.TransparentColor = Color.Transparent;
    this.imgValidacaoResultado32x32.Images.SetKeyName(0, "iconfinder_play_59990.png");
    this.imgValidacaoResultado32x32.Images.SetKeyName(1, "iconfinder_79-excel_4202106.png");
    this.imgValidacaoResultado32x32.Images.SetKeyName(2, "icons8-configurações-3-32.png");
    this.imgValidacaoResultado32x32.Images.SetKeyName(3, "icons8-serviços-48.png");
    this.imgValidacaoResultado32x32.Images.SetKeyName(4, "icons8-manual-do-usuário-32.png");
    this.label1.AutoSize = true;
    this.label1.Location = new Point(6, 16 /*0x10*/);
    this.label1.Name = "label1";
    this.label1.Size = new Size(60, 13);
    this.label1.TabIndex = 22;
    this.label1.Text = "Segmentos";
    this.btnExecutarProgramas.BackColor = Color.White;
    this.btnExecutarProgramas.ImageAlign = ContentAlignment.TopCenter;
    this.btnExecutarProgramas.ImageKey = "icons8-serviços-48.png";
    this.btnExecutarProgramas.ImageList = this.imgValidacaoResultado32x32;
    this.btnExecutarProgramas.Location = new Point(324, 13);
    this.btnExecutarProgramas.Name = "btnExecutarProgramas";
    this.btnExecutarProgramas.Size = new Size(66, 66);
    this.btnExecutarProgramas.TabIndex = 27;
    this.btnExecutarProgramas.Text = "F8 Executar";
    this.btnExecutarProgramas.TextAlign = ContentAlignment.BottomCenter;
    this.tipVRDiversos.SetToolTip((Control) this.btnExecutarProgramas, "Executar programas selecionados");
    this.btnExecutarProgramas.UseVisualStyleBackColor = false;
    this.btnExecutarProgramas.Click += new EventHandler(this.btnExecutarProgramas_Click);
    this.cmbSegmentos.FormattingEnabled = true;
    this.cmbSegmentos.Location = new Point(67, 13);
    this.cmbSegmentos.Name = "cmbSegmentos";
    this.cmbSegmentos.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbSegmentos.TabIndex = 21;
    this.cmbSegmentos.SelectionChangeCommitted += new EventHandler(this.cmbSegmentos_SelectionChangeCommitted);
    this.btnLiberarTodosProgramas.BackColor = Color.White;
    this.btnLiberarTodosProgramas.ImageAlign = ContentAlignment.MiddleLeft;
    this.btnLiberarTodosProgramas.ImageKey = "iconfinder_bullet-green_59836.png";
    this.btnLiberarTodosProgramas.ImageList = this.imgValidacaoResultado16x16;
    this.btnLiberarTodosProgramas.Location = new Point(198, 40);
    this.btnLiberarTodosProgramas.Name = "btnLiberarTodosProgramas";
    this.btnLiberarTodosProgramas.Size = new Size(123, 21);
    this.btnLiberarTodosProgramas.TabIndex = 26;
    this.btnLiberarTodosProgramas.Text = "Liberar seleção";
    this.tipVRDiversos.SetToolTip((Control) this.btnLiberarTodosProgramas, "Inserir novas linhas na base");
    this.btnLiberarTodosProgramas.UseVisualStyleBackColor = false;
    this.btnLiberarTodosProgramas.Click += new EventHandler(this.btnLiberarTodosProgramas_Click);
    this.label2.AutoSize = true;
    this.label2.Location = new Point(21, 44);
    this.label2.Name = "label2";
    this.label2.Size = new Size(45, 13);
    this.label2.TabIndex = 23;
    this.label2.Text = "Período";
    this.btnBloquearTodosProgramas.BackColor = Color.White;
    this.btnBloquearTodosProgramas.ImageAlign = ContentAlignment.MiddleLeft;
    this.btnBloquearTodosProgramas.ImageKey = "iconfinder_bullet-red_59838.png";
    this.btnBloquearTodosProgramas.ImageList = this.imgValidacaoResultado16x16;
    this.btnBloquearTodosProgramas.Location = new Point(198, 13);
    this.btnBloquearTodosProgramas.Name = "btnBloquearTodosProgramas";
    this.btnBloquearTodosProgramas.Size = new Size(123, 21);
    this.btnBloquearTodosProgramas.TabIndex = 25;
    this.btnBloquearTodosProgramas.Text = "Bloquear seleção";
    this.tipVRDiversos.SetToolTip((Control) this.btnBloquearTodosProgramas, "Inserir novas linhas na base");
    this.btnBloquearTodosProgramas.UseVisualStyleBackColor = false;
    this.btnBloquearTodosProgramas.Click += new EventHandler(this.btnBloquearTodosProgramas_Click);
    this.cmbPeriodo.FormattingEnabled = true;
    this.cmbPeriodo.Location = new Point(67, 40);
    this.cmbPeriodo.Name = "cmbPeriodo";
    this.cmbPeriodo.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbPeriodo.TabIndex = 24;
    this.cmbPeriodo.SelectionChangeCommitted += new EventHandler(this.cmbPeriodo_SelectionChangeCommitted);
    this.tpCalculoPrincipal.Controls.Add((Control) this.rtbStatusProcessamento);
    this.tpCalculoPrincipal.Controls.Add((Control) this.groupBox3);
    this.tpCalculoPrincipal.Location = new Point(4, 22);
    this.tpCalculoPrincipal.Name = "tpCalculoPrincipal";
    this.tpCalculoPrincipal.Size = new Size(1235, 91);
    this.tpCalculoPrincipal.TabIndex = 4;
    this.tpCalculoPrincipal.Text = "Cálculo";
    this.tpCalculoPrincipal.UseVisualStyleBackColor = true;
    this.rtbStatusProcessamento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rtbStatusProcessamento.BorderStyle = BorderStyle.None;
    this.rtbStatusProcessamento.Location = new Point(572, 8);
    this.rtbStatusProcessamento.Name = "rtbStatusProcessamento";
    this.rtbStatusProcessamento.ReadOnly = true;
    this.rtbStatusProcessamento.Size = new Size(508, 79);
    this.rtbStatusProcessamento.TabIndex = 1;
    this.rtbStatusProcessamento.Text = "";
    this.groupBox3.Controls.Add((Control) this.label8);
    this.groupBox3.Controls.Add((Control) this.cmbStatusCalc);
    this.groupBox3.Controls.Add((Control) this.panel2);
    this.groupBox3.Controls.Add((Control) this.label6);
    this.groupBox3.Controls.Add((Control) this.cmbTipoCalc);
    this.groupBox3.Controls.Add((Control) this.label7);
    this.groupBox3.Controls.Add((Control) this.cmbVersaoExecCalc);
    this.groupBox3.Controls.Add((Control) this.label5);
    this.groupBox3.Controls.Add((Control) this.cmbCanalCalc);
    this.groupBox3.Controls.Add((Control) this.label3);
    this.groupBox3.Controls.Add((Control) this.cmbPeriodoCalc);
    this.groupBox3.Controls.Add((Control) this.label4);
    this.groupBox3.Controls.Add((Control) this.cmbSegmentoCalc);
    this.groupBox3.Controls.Add((Control) this.btnExecutarProgramasCalculo);
    this.groupBox3.Location = new Point(4, 3);
    this.groupBox3.Name = "groupBox3";
    this.groupBox3.Size = new Size(562, 85);
    this.groupBox3.TabIndex = 0;
    this.groupBox3.TabStop = false;
    this.label8.AutoSize = true;
    this.label8.Location = new Point(350, 63 /*0x3F*/);
    this.label8.Name = "label8";
    this.label8.Size = new Size(74, 13);
    this.label8.TabIndex = 40;
    this.label8.Text = "Status cálculo";
    this.cmbStatusCalc.FormattingEnabled = true;
    this.cmbStatusCalc.Location = new Point(427, 60);
    this.cmbStatusCalc.Name = "cmbStatusCalc";
    this.cmbStatusCalc.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbStatusCalc.TabIndex = 41;
    this.cmbStatusCalc.SelectionChangeCommitted += new EventHandler(this.cmbStatusCalc_SelectionChangeCommitted);
    this.panel2.Controls.Add((Control) this.btnLimparFiltrosCalc);
    this.panel2.Controls.Add((Control) this.btnBloquearCalc);
    this.panel2.Controls.Add((Control) this.btnHistoricoExecucaoCalc);
    this.panel2.Controls.Add((Control) this.btnDetalharProgramasCalc);
    this.panel2.Location = new Point(79, 10);
    this.panel2.Name = "panel2";
    this.panel2.Size = new Size(67, 71);
    this.panel2.TabIndex = 39;
    this.btnLimparFiltrosCalc.BackColor = Color.White;
    this.btnLimparFiltrosCalc.ImageKey = "clear-filter.png";
    this.btnLimparFiltrosCalc.ImageList = this.imgValidacaoResultado16x16;
    this.btnLimparFiltrosCalc.Location = new Point(34, 36);
    this.btnLimparFiltrosCalc.Name = "btnLimparFiltrosCalc";
    this.btnLimparFiltrosCalc.Size = new Size(30, 30);
    this.btnLimparFiltrosCalc.TabIndex = 24;
    this.tipVRDiversos.SetToolTip((Control) this.btnLimparFiltrosCalc, "Remover os filtros da pesquisa");
    this.btnLimparFiltrosCalc.UseVisualStyleBackColor = false;
    this.btnLimparFiltrosCalc.Click += new EventHandler(this.btnLimparFiltrosCalc_Click);
    this.btnBloquearCalc.BackColor = Color.White;
    this.btnBloquearCalc.Enabled = false;
    this.btnBloquearCalc.ImageKey = "lock.png";
    this.btnBloquearCalc.ImageList = this.imgValidacaoResultado16x16;
    this.btnBloquearCalc.Location = new Point(3, 36);
    this.btnBloquearCalc.Name = "btnBloquearCalc";
    this.btnBloquearCalc.Size = new Size(30, 30);
    this.btnBloquearCalc.TabIndex = 23;
    this.tipVRDiversos.SetToolTip((Control) this.btnBloquearCalc, "Abrir ou fechar cálculo");
    this.btnBloquearCalc.UseVisualStyleBackColor = false;
    this.btnBloquearCalc.Click += new EventHandler(this.btnBloquearCalc_Click);
    this.btnHistoricoExecucaoCalc.BackColor = Color.White;
    this.btnHistoricoExecucaoCalc.ImageKey = "document_time.png";
    this.btnHistoricoExecucaoCalc.ImageList = this.imgValidacaoResultado16x16;
    this.btnHistoricoExecucaoCalc.Location = new Point(34, 5);
    this.btnHistoricoExecucaoCalc.Name = "btnHistoricoExecucaoCalc";
    this.btnHistoricoExecucaoCalc.Size = new Size(30, 30);
    this.btnHistoricoExecucaoCalc.TabIndex = 22;
    this.tipVRDiversos.SetToolTip((Control) this.btnHistoricoExecucaoCalc, "Atalho para histórico detalhados de execução dos programas");
    this.btnHistoricoExecucaoCalc.UseVisualStyleBackColor = false;
    this.btnHistoricoExecucaoCalc.Click += new EventHandler(this.btnHistoricoExecucaoCalc_Click);
    this.btnDetalharProgramasCalc.BackColor = Color.White;
    this.btnDetalharProgramasCalc.ImageKey = "iconfinder_35_Glasses_2064510.png";
    this.btnDetalharProgramasCalc.ImageList = this.imgValidacaoResultado16x16;
    this.btnDetalharProgramasCalc.Location = new Point(3, 5);
    this.btnDetalharProgramasCalc.Name = "btnDetalharProgramasCalc";
    this.btnDetalharProgramasCalc.Size = new Size(30, 30);
    this.btnDetalharProgramasCalc.TabIndex = 21;
    this.tipVRDiversos.SetToolTip((Control) this.btnDetalharProgramasCalc, "Relação de programas que formam o cálculo");
    this.btnDetalharProgramasCalc.UseVisualStyleBackColor = false;
    this.btnDetalharProgramasCalc.Click += new EventHandler(this.btnDetalharProgramasCalc_Click);
    this.label6.AutoSize = true;
    this.label6.Location = new Point(396, 14);
    this.label6.Name = "label6";
    this.label6.Size = new Size(28, 13);
    this.label6.TabIndex = 36;
    this.label6.Text = "Tipo";
    this.cmbTipoCalc.FormattingEnabled = true;
    this.cmbTipoCalc.Location = new Point(427, 10);
    this.cmbTipoCalc.Name = "cmbTipoCalc";
    this.cmbTipoCalc.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbTipoCalc.TabIndex = 35;
    this.cmbTipoCalc.SelectionChangeCommitted += new EventHandler(this.cmbTipoCalc_SelectionChangeCommitted);
    this.label7.AutoSize = true;
    this.label7.Location = new Point(334, 39);
    this.label7.Name = "label7";
    this.label7.Size = new Size(90, 13);
    this.label7.TabIndex = 37;
    this.label7.Text = "Versão execução";
    this.cmbVersaoExecCalc.FormattingEnabled = true;
    this.cmbVersaoExecCalc.Location = new Point(427, 35);
    this.cmbVersaoExecCalc.Name = "cmbVersaoExecCalc";
    this.cmbVersaoExecCalc.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbVersaoExecCalc.TabIndex = 38;
    this.cmbVersaoExecCalc.SelectionChangeCommitted += new EventHandler(this.cmbVersaoExecCalc_SelectionChangeCommitted);
    this.label5.AutoSize = true;
    this.label5.Location = new Point(168, 64 /*0x40*/);
    this.label5.Name = "label5";
    this.label5.Size = new Size(34, 13);
    this.label5.TabIndex = 33;
    this.label5.Text = "Canal";
    this.cmbCanalCalc.FormattingEnabled = true;
    this.cmbCanalCalc.Location = new Point(205, 60);
    this.cmbCanalCalc.Name = "cmbCanalCalc";
    this.cmbCanalCalc.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbCanalCalc.TabIndex = 34;
    this.cmbCanalCalc.SelectionChangeCommitted += new EventHandler(this.cmbCanalCalc_SelectionChangeCommitted);
    this.label3.AutoSize = true;
    this.label3.Location = new Point(157, 14);
    this.label3.Name = "label3";
    this.label3.Size = new Size(45, 13);
    this.label3.TabIndex = 30;
    this.label3.Text = "Período";
    this.cmbPeriodoCalc.FormattingEnabled = true;
    this.cmbPeriodoCalc.Location = new Point(205, 10);
    this.cmbPeriodoCalc.Name = "cmbPeriodoCalc";
    this.cmbPeriodoCalc.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbPeriodoCalc.TabIndex = 29;
    this.cmbPeriodoCalc.SelectionChangeCommitted += new EventHandler(this.cmbPeriodoCalc_SelectionChangeCommitted);
    this.label4.AutoSize = true;
    this.label4.Location = new Point(147, 39);
    this.label4.Name = "label4";
    this.label4.Size = new Size(55, 13);
    this.label4.TabIndex = 31 /*0x1F*/;
    this.label4.Text = "Segmento";
    this.cmbSegmentoCalc.FormattingEnabled = true;
    this.cmbSegmentoCalc.Location = new Point(205, 35);
    this.cmbSegmentoCalc.Name = "cmbSegmentoCalc";
    this.cmbSegmentoCalc.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbSegmentoCalc.TabIndex = 32 /*0x20*/;
    this.cmbSegmentoCalc.SelectionChangeCommitted += new EventHandler(this.cmbSegmentoCalc_SelectionChangeCommitted);
    this.btnExecutarProgramasCalculo.BackColor = Color.White;
    this.btnExecutarProgramasCalculo.ImageAlign = ContentAlignment.TopCenter;
    this.btnExecutarProgramasCalculo.ImageKey = "icons8-serviços-48.png";
    this.btnExecutarProgramasCalculo.ImageList = this.imgValidacaoResultado32x32;
    this.btnExecutarProgramasCalculo.Location = new Point(6, 13);
    this.btnExecutarProgramasCalculo.Name = "btnExecutarProgramasCalculo";
    this.btnExecutarProgramasCalculo.Size = new Size(66, 66);
    this.btnExecutarProgramasCalculo.TabIndex = 28;
    this.btnExecutarProgramasCalculo.Text = "F8 Executar";
    this.btnExecutarProgramasCalculo.TextAlign = ContentAlignment.BottomCenter;
    this.tipVRDiversos.SetToolTip((Control) this.btnExecutarProgramasCalculo, "Executar programas selecionados");
    this.btnExecutarProgramasCalculo.UseVisualStyleBackColor = false;
    this.btnExecutarProgramasCalculo.Click += new EventHandler(this.btnExecutarProgramasCalculo_Click);
    this.tpCargaInsumos.Controls.Add((Control) this.rtbStatusCargaBase);
    this.tpCargaInsumos.Controls.Add((Control) this.groupBox5);
    this.tpCargaInsumos.Location = new Point(4, 22);
    this.tpCargaInsumos.Name = "tpCargaInsumos";
    this.tpCargaInsumos.Size = new Size(1235, 91);
    this.tpCargaInsumos.TabIndex = 5;
    this.tpCargaInsumos.Text = "Carga Insumos";
    this.tpCargaInsumos.UseVisualStyleBackColor = true;
    this.rtbStatusCargaBase.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rtbStatusCargaBase.BorderStyle = BorderStyle.None;
    this.rtbStatusCargaBase.Location = new Point(572, 8);
    this.rtbStatusCargaBase.Name = "rtbStatusCargaBase";
    this.rtbStatusCargaBase.ReadOnly = true;
    this.rtbStatusCargaBase.Size = new Size(508, 79);
    this.rtbStatusCargaBase.TabIndex = 2;
    this.rtbStatusCargaBase.Text = "";
    this.groupBox5.Controls.Add((Control) this.panel7);
    this.groupBox5.Controls.Add((Control) this.label16);
    this.groupBox5.Controls.Add((Control) this.cmbNomeBases);
    this.groupBox5.Controls.Add((Control) this.label18);
    this.groupBox5.Controls.Add((Control) this.cmbCanalBases);
    this.groupBox5.Controls.Add((Control) this.label19);
    this.groupBox5.Controls.Add((Control) this.cmbPeriodoBases);
    this.groupBox5.Controls.Add((Control) this.label20);
    this.groupBox5.Controls.Add((Control) this.cmbSegmentoBases);
    this.groupBox5.Controls.Add((Control) this.btnCarregarBase);
    this.groupBox5.Location = new Point(4, 3);
    this.groupBox5.Name = "groupBox5";
    this.groupBox5.Size = new Size(562, 85);
    this.groupBox5.TabIndex = 1;
    this.groupBox5.TabStop = false;
    this.panel7.Controls.Add((Control) this.btnLimparFiltrosBases);
    this.panel7.Controls.Add((Control) this.button2);
    this.panel7.Controls.Add((Control) this.button3);
    this.panel7.Controls.Add((Control) this.button4);
    this.panel7.Location = new Point(79, 10);
    this.panel7.Name = "panel7";
    this.panel7.Size = new Size(67, 71);
    this.panel7.TabIndex = 39;
    this.btnLimparFiltrosBases.BackColor = Color.White;
    this.btnLimparFiltrosBases.ImageKey = "clear-filter.png";
    this.btnLimparFiltrosBases.ImageList = this.imgValidacaoResultado16x16;
    this.btnLimparFiltrosBases.Location = new Point(34, 36);
    this.btnLimparFiltrosBases.Name = "btnLimparFiltrosBases";
    this.btnLimparFiltrosBases.Size = new Size(30, 30);
    this.btnLimparFiltrosBases.TabIndex = 24;
    this.tipVRDiversos.SetToolTip((Control) this.btnLimparFiltrosBases, "Remover os filtros da pesquisa");
    this.btnLimparFiltrosBases.UseVisualStyleBackColor = false;
    this.btnLimparFiltrosBases.Click += new EventHandler(this.btnLimparFiltrosBases_Click);
    this.button2.BackColor = Color.White;
    this.button2.Enabled = false;
    this.button2.ImageKey = "(nenhum/a)";
    this.button2.ImageList = this.imgValidacaoResultado16x16;
    this.button2.Location = new Point(3, 36);
    this.button2.Name = "button2";
    this.button2.Size = new Size(30, 30);
    this.button2.TabIndex = 23;
    this.tipVRDiversos.SetToolTip((Control) this.button2, "Abrir ou fechar cálculo");
    this.button2.UseVisualStyleBackColor = false;
    this.button3.BackColor = Color.White;
    this.button3.ImageKey = "(nenhum/a)";
    this.button3.ImageList = this.imgValidacaoResultado16x16;
    this.button3.Location = new Point(34, 5);
    this.button3.Name = "button3";
    this.button3.Size = new Size(30, 30);
    this.button3.TabIndex = 22;
    this.tipVRDiversos.SetToolTip((Control) this.button3, "Atalho para histórico detalhados de execução dos programas");
    this.button3.UseVisualStyleBackColor = false;
    this.button4.BackColor = Color.White;
    this.button4.ImageKey = "(nenhum/a)";
    this.button4.ImageList = this.imgValidacaoResultado16x16;
    this.button4.Location = new Point(3, 5);
    this.button4.Name = "button4";
    this.button4.Size = new Size(30, 30);
    this.button4.TabIndex = 21;
    this.tipVRDiversos.SetToolTip((Control) this.button4, "Relação de programas que formam o cálculo");
    this.button4.UseVisualStyleBackColor = false;
    this.label16.AutoSize = true;
    this.label16.Location = new Point(150, 62);
    this.label16.Name = "label16";
    this.label16.Size = new Size(76, 13);
    this.label16.TabIndex = 36;
    this.label16.Text = "Nome da base";
    this.cmbNomeBases.FormattingEnabled = true;
    this.cmbNomeBases.Location = new Point(228, 58);
    this.cmbNomeBases.Name = "cmbNomeBases";
    this.cmbNomeBases.Size = new Size(325, 21);
    this.cmbNomeBases.TabIndex = 35;
    this.cmbNomeBases.SelectionChangeCommitted += new EventHandler(this.cmbNomeBases_SelectionChangeCommitted);
    this.label18.AutoSize = true;
    this.label18.Location = new Point(191, 38);
    this.label18.Name = "label18";
    this.label18.Size = new Size(34, 13);
    this.label18.TabIndex = 33;
    this.label18.Text = "Canal";
    this.cmbCanalBases.FormattingEnabled = true;
    this.cmbCanalBases.Location = new Point(228, 34);
    this.cmbCanalBases.Name = "cmbCanalBases";
    this.cmbCanalBases.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbCanalBases.TabIndex = 34;
    this.cmbCanalBases.SelectionChangeCommitted += new EventHandler(this.cmbCanalBases_SelectionChangeCommitted);
    this.label19.AutoSize = true;
    this.label19.Location = new Point(180, 14);
    this.label19.Name = "label19";
    this.label19.Size = new Size(45, 13);
    this.label19.TabIndex = 30;
    this.label19.Text = "Período";
    this.cmbPeriodoBases.FormattingEnabled = true;
    this.cmbPeriodoBases.Location = new Point(228, 10);
    this.cmbPeriodoBases.Name = "cmbPeriodoBases";
    this.cmbPeriodoBases.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbPeriodoBases.TabIndex = 29;
    this.cmbPeriodoBases.SelectionChangeCommitted += new EventHandler(this.cmbPeriodoBases_SelectionChangeCommitted);
    this.label20.AutoSize = true;
    this.label20.Location = new Point(368, 14);
    this.label20.Name = "label20";
    this.label20.Size = new Size(55, 13);
    this.label20.TabIndex = 31 /*0x1F*/;
    this.label20.Text = "Segmento";
    this.cmbSegmentoBases.FormattingEnabled = true;
    this.cmbSegmentoBases.Location = new Point(426, 10);
    this.cmbSegmentoBases.Name = "cmbSegmentoBases";
    this.cmbSegmentoBases.Size = new Size((int) sbyte.MaxValue, 21);
    this.cmbSegmentoBases.TabIndex = 32 /*0x20*/;
    this.cmbSegmentoBases.SelectionChangeCommitted += new EventHandler(this.cmbSegmentoBases_SelectionChangeCommitted);
    this.btnCarregarBase.BackColor = Color.White;
    this.btnCarregarBase.ImageAlign = ContentAlignment.TopCenter;
    this.btnCarregarBase.ImageKey = "icons8-serviços-48.png";
    this.btnCarregarBase.ImageList = this.imgValidacaoResultado32x32;
    this.btnCarregarBase.Location = new Point(6, 13);
    this.btnCarregarBase.Name = "btnCarregarBase";
    this.btnCarregarBase.Size = new Size(66, 66);
    this.btnCarregarBase.TabIndex = 28;
    this.btnCarregarBase.Text = "Carregar base";
    this.btnCarregarBase.TextAlign = ContentAlignment.BottomCenter;
    this.tipVRDiversos.SetToolTip((Control) this.btnCarregarBase, "Executar programas selecionados");
    this.btnCarregarBase.UseVisualStyleBackColor = false;
    this.btnCarregarBase.Click += new EventHandler(this.btnCarregarBase_Click);
    this.tpInformativos.Controls.Add((Control) this.groupBox6);
    this.tpInformativos.Location = new Point(4, 22);
    this.tpInformativos.Name = "tpInformativos";
    this.tpInformativos.Size = new Size(1235, 91);
    this.tpInformativos.TabIndex = 6;
    this.tpInformativos.Text = "Informativos";
    this.tpInformativos.UseVisualStyleBackColor = true;
    this.groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.groupBox6.Controls.Add((Control) this.rtbInformativos);
    this.groupBox6.Controls.Add((Control) this.btnDivulgar);
    this.groupBox6.Controls.Add((Control) this.btnEnviarParaMim);
    this.groupBox6.Controls.Add((Control) this.btnApenasGerar);
    this.groupBox6.Controls.Add((Control) this.label15);
    this.groupBox6.Controls.Add((Control) this.cmbCargoInformativo);
    this.groupBox6.Controls.Add((Control) this.label17);
    this.groupBox6.Controls.Add((Control) this.cmbVersaoInformativo);
    this.groupBox6.Controls.Add((Control) this.label21);
    this.groupBox6.Controls.Add((Control) this.cmbTrimestreInformativo);
    this.groupBox6.Controls.Add((Control) this.label22);
    this.groupBox6.Controls.Add((Control) this.cmbCanalInformativo);
    this.groupBox6.Controls.Add((Control) this.label23);
    this.groupBox6.Controls.Add((Control) this.cmbPeriodoInformativo);
    this.groupBox6.Controls.Add((Control) this.label24);
    this.groupBox6.Controls.Add((Control) this.cmbCalculoInformativo);
    this.groupBox6.Location = new Point(4, 3);
    this.groupBox6.Name = "groupBox6";
    this.groupBox6.Size = new Size(1224, 85);
    this.groupBox6.TabIndex = 2;
    this.groupBox6.TabStop = false;
    this.btnDivulgar.BackColor = Color.White;
    this.btnDivulgar.ImageAlign = ContentAlignment.MiddleLeft;
    this.btnDivulgar.ImageKey = "iconfinder_bullet-red_59838.png";
    this.btnDivulgar.ImageList = this.imgValidacaoResultado16x16;
    this.btnDivulgar.Location = new Point(15, 54);
    this.btnDivulgar.Name = "btnDivulgar";
    this.btnDivulgar.Size = new Size(132, 29);
    this.btnDivulgar.TabIndex = 44;
    this.btnDivulgar.Text = "Divulgar";
    this.tipVRDiversos.SetToolTip((Control) this.btnDivulgar, "Inserir novas linhas na base");
    this.btnDivulgar.UseVisualStyleBackColor = false;
    this.btnDivulgar.Click += new EventHandler(this.btnDivulgar_Click);
    this.btnEnviarParaMim.BackColor = Color.White;
    this.btnEnviarParaMim.ImageAlign = ContentAlignment.MiddleLeft;
    this.btnEnviarParaMim.ImageKey = "iconfinder_bullet-green_59836.png";
    this.btnEnviarParaMim.ImageList = this.imgValidacaoResultado16x16;
    this.btnEnviarParaMim.Location = new Point(15, 30);
    this.btnEnviarParaMim.Name = "btnEnviarParaMim";
    this.btnEnviarParaMim.Size = new Size(132, 21);
    this.btnEnviarParaMim.TabIndex = 43;
    this.btnEnviarParaMim.Text = "Enviar para mim";
    this.tipVRDiversos.SetToolTip((Control) this.btnEnviarParaMim, "Inserir novas linhas na base");
    this.btnEnviarParaMim.UseVisualStyleBackColor = false;
    this.btnEnviarParaMim.Click += new EventHandler(this.btnEnviarParaMim_Click);
    this.btnApenasGerar.BackColor = Color.White;
    this.btnApenasGerar.ImageAlign = ContentAlignment.MiddleLeft;
    this.btnApenasGerar.ImageKey = "iconfinder_bullet-green_59836.png";
    this.btnApenasGerar.ImageList = this.imgValidacaoResultado16x16;
    this.btnApenasGerar.Location = new Point(15, 8);
    this.btnApenasGerar.Name = "btnApenasGerar";
    this.btnApenasGerar.Size = new Size(132, 21);
    this.btnApenasGerar.TabIndex = 42;
    this.btnApenasGerar.Text = "Apenas gerar";
    this.tipVRDiversos.SetToolTip((Control) this.btnApenasGerar, "Inserir novas linhas na base");
    this.btnApenasGerar.UseVisualStyleBackColor = false;
    this.btnApenasGerar.Click += new EventHandler(this.btnApenasGerar_Click);
    this.label15.AutoSize = true;
    this.label15.Location = new Point(374, 38);
    this.label15.Name = "label15";
    this.label15.Size = new Size(35, 13);
    this.label15.TabIndex = 40;
    this.label15.Text = "Cargo";
    this.cmbCargoInformativo.FormattingEnabled = true;
    this.cmbCargoInformativo.Location = new Point(412, 34);
    this.cmbCargoInformativo.Name = "cmbCargoInformativo";
    this.cmbCargoInformativo.Size = new Size(180, 21);
    this.cmbCargoInformativo.TabIndex = 41;
    this.cmbCargoInformativo.SelectionChangeCommitted += new EventHandler(this.cmbCargoInformativo_SelectionChangeCommitted);
    this.label17.AutoSize = true;
    this.label17.Location = new Point(179, 62);
    this.label17.Name = "label17";
    this.label17.Size = new Size(40, 13);
    this.label17.TabIndex = 36;
    this.label17.Text = "Versão";
    this.cmbVersaoInformativo.FormattingEnabled = true;
    this.cmbVersaoInformativo.Location = new Point(222, 58);
    this.cmbVersaoInformativo.Name = "cmbVersaoInformativo";
    this.cmbVersaoInformativo.Size = new Size(131, 21);
    this.cmbVersaoInformativo.TabIndex = 35;
    this.cmbVersaoInformativo.SelectionChangeCommitted += new EventHandler(this.cmbVersaoInformativo_SelectionChangeCommitted);
    this.label21.AutoSize = true;
    this.label21.Location = new Point(169, 38);
    this.label21.Name = "label21";
    this.label21.Size = new Size(50, 13);
    this.label21.TabIndex = 37;
    this.label21.Text = "Trimestre";
    this.cmbTrimestreInformativo.FormattingEnabled = true;
    this.cmbTrimestreInformativo.Location = new Point(222, 34);
    this.cmbTrimestreInformativo.Name = "cmbTrimestreInformativo";
    this.cmbTrimestreInformativo.Size = new Size(131, 21);
    this.cmbTrimestreInformativo.TabIndex = 38;
    this.cmbTrimestreInformativo.SelectionChangeCommitted += new EventHandler(this.cmbTrimestreInformativo_SelectionChangeCommitted);
    this.label22.AutoSize = true;
    this.label22.Location = new Point(375, 13);
    this.label22.Name = "label22";
    this.label22.Size = new Size(34, 13);
    this.label22.TabIndex = 33;
    this.label22.Text = "Canal";
    this.cmbCanalInformativo.FormattingEnabled = true;
    this.cmbCanalInformativo.Location = new Point(412, 9);
    this.cmbCanalInformativo.Name = "cmbCanalInformativo";
    this.cmbCanalInformativo.Size = new Size(180, 21);
    this.cmbCanalInformativo.TabIndex = 34;
    this.cmbCanalInformativo.SelectionChangeCommitted += new EventHandler(this.cmbCanalInformativo_SelectionChangeCommitted);
    this.label23.AutoSize = true;
    this.label23.Location = new Point(174, 14);
    this.label23.Name = "label23";
    this.label23.Size = new Size(45, 13);
    this.label23.TabIndex = 30;
    this.label23.Text = "Período";
    this.cmbPeriodoInformativo.FormattingEnabled = true;
    this.cmbPeriodoInformativo.Location = new Point(222, 10);
    this.cmbPeriodoInformativo.Name = "cmbPeriodoInformativo";
    this.cmbPeriodoInformativo.Size = new Size(131, 21);
    this.cmbPeriodoInformativo.TabIndex = 29;
    this.cmbPeriodoInformativo.SelectionChangeCommitted += new EventHandler(this.cmbPeriodoInformativo_SelectionChangeCommitted);
    this.label24.AutoSize = true;
    this.label24.Location = new Point(367, 62);
    this.label24.Name = "label24";
    this.label24.Size = new Size(42, 13);
    this.label24.TabIndex = 31 /*0x1F*/;
    this.label24.Text = "Cálculo";
    this.cmbCalculoInformativo.FormattingEnabled = true;
    this.cmbCalculoInformativo.Location = new Point(412, 58);
    this.cmbCalculoInformativo.Name = "cmbCalculoInformativo";
    this.cmbCalculoInformativo.Size = new Size(180, 21);
    this.cmbCalculoInformativo.TabIndex = 32 /*0x20*/;
    this.cmbCalculoInformativo.SelectionChangeCommitted += new EventHandler(this.cmbCalculoInformativo_SelectionChangeCommitted);
    this.button7.BackColor = Color.White;
    this.button7.ImageKey = "(none)";
    this.button7.ImageList = this.imgValidacaoResultado16x16;
    this.button7.Location = new Point(179, 42);
    this.button7.Name = "button7";
    this.button7.Size = new Size(30, 30);
    this.button7.TabIndex = 20;
    this.tipVRDiversos.SetToolTip((Control) this.button7, "Inserir novas linhas na base");
    this.button7.UseVisualStyleBackColor = false;
    this.button7.Visible = false;
    this.button7.Click += new EventHandler(this.button7_Click);
    this.btnAdicionarLinhas.BackColor = Color.White;
    this.btnAdicionarLinhas.ImageKey = "(none)";
    this.btnAdicionarLinhas.ImageList = this.imgValidacaoResultado16x16;
    this.btnAdicionarLinhas.Location = new Point(111, 6);
    this.btnAdicionarLinhas.Name = "btnAdicionarLinhas";
    this.btnAdicionarLinhas.Size = new Size(30, 30);
    this.btnAdicionarLinhas.TabIndex = 14;
    this.tipVRDiversos.SetToolTip((Control) this.btnAdicionarLinhas, "Inserir novas linhas na base");
    this.btnAdicionarLinhas.UseVisualStyleBackColor = false;
    this.btnAdicionarLinhas.Click += new EventHandler(this.btnAdicionarLinhas_Click);
    this.btnSalvarNovasLinhas.BackColor = Color.White;
    this.btnSalvarNovasLinhas.Enabled = false;
    this.btnSalvarNovasLinhas.ImageList = this.imgValidacaoResultado16x16;
    this.btnSalvarNovasLinhas.Location = new Point(77, 6);
    this.btnSalvarNovasLinhas.Name = "btnSalvarNovasLinhas";
    this.btnSalvarNovasLinhas.Size = new Size(30, 30);
    this.btnSalvarNovasLinhas.TabIndex = 13;
    this.tipVRDiversos.SetToolTip((Control) this.btnSalvarNovasLinhas, "Salvar os dados das novas linhas inseridas");
    this.btnSalvarNovasLinhas.UseVisualStyleBackColor = false;
    this.btnSalvarNovasLinhas.Click += new EventHandler(this.btnSalvarNovasLinhas_Click);
    this.btnExcluir.BackColor = Color.White;
    this.btnExcluir.ImageKey = "Excluir_16x16.png";
    this.btnExcluir.ImageList = this.imgValidacaoResultado16x16;
    this.btnExcluir.Location = new Point(145, 6);
    this.btnExcluir.Name = "btnExcluir";
    this.btnExcluir.Size = new Size(30, 30);
    this.btnExcluir.TabIndex = 11;
    this.btnExcluir.UseVisualStyleBackColor = false;
    this.btnExcluir.Click += new EventHandler(this.btnExcluir_Click);
    this.btnEstatisticas.BackColor = Color.White;
    this.btnEstatisticas.ImageKey = "grafico_barra_16x16.png";
    this.btnEstatisticas.ImageList = this.imgValidacaoResultado16x16;
    this.btnEstatisticas.Location = new Point(145, 42);
    this.btnEstatisticas.Name = "btnEstatisticas";
    this.btnEstatisticas.Size = new Size(30, 30);
    this.btnEstatisticas.TabIndex = 12;
    this.btnEstatisticas.UseVisualStyleBackColor = false;
    this.btnEstatisticas.Click += new EventHandler(this.btnEstatisticas_Click);
    this.btnVRExportarExcel.BackColor = Color.White;
    this.btnVRExportarExcel.ImageKey = "iconfinder_logo_brand_brands_logos_excel_3215579.png";
    this.btnVRExportarExcel.ImageList = this.imgValidacaoResultado16x16;
    this.btnVRExportarExcel.Location = new Point(179, 6);
    this.btnVRExportarExcel.Name = "btnVRExportarExcel";
    this.btnVRExportarExcel.Size = new Size(30, 30);
    this.btnVRExportarExcel.TabIndex = 9;
    this.btnVRExportarExcel.UseVisualStyleBackColor = false;
    this.btnVRExportarExcel.Click += new EventHandler(this.btnVRExportarExcel_Click);
    this.btnPesquisarEditar.BackColor = Color.White;
    this.btnPesquisarEditar.ImageKey = "iconfinder_play_59990_16x16.png";
    this.btnPesquisarEditar.ImageList = this.imgValidacaoResultado16x16;
    this.btnPesquisarEditar.Location = new Point(111, 42);
    this.btnPesquisarEditar.Name = "btnPesquisarEditar";
    this.btnPesquisarEditar.Size = new Size(30, 30);
    this.btnPesquisarEditar.TabIndex = 10;
    this.btnPesquisarEditar.UseVisualStyleBackColor = false;
    this.btnPesquisarEditar.Click += new EventHandler(this.btnPesquisarEditar_Click);
    this.btnPesquisarValidacaoResultado.BackColor = Color.White;
    this.btnPesquisarValidacaoResultado.ImageAlign = ContentAlignment.TopCenter;
    this.btnPesquisarValidacaoResultado.ImageKey = "iconfinder_play_59990.png";
    this.btnPesquisarValidacaoResultado.ImageList = this.imgValidacaoResultado32x32;
    this.btnPesquisarValidacaoResultado.Location = new Point(5, 6);
    this.btnPesquisarValidacaoResultado.Name = "btnPesquisarValidacaoResultado";
    this.btnPesquisarValidacaoResultado.Size = new Size(66, 66);
    this.btnPesquisarValidacaoResultado.TabIndex = 8;
    this.btnPesquisarValidacaoResultado.Text = "F5 Pesquisar";
    this.btnPesquisarValidacaoResultado.TextAlign = ContentAlignment.BottomCenter;
    this.btnPesquisarValidacaoResultado.UseVisualStyleBackColor = false;
    this.btnPesquisarValidacaoResultado.Click += new EventHandler(this.btnPesquisarValidacaoResultado_Click);
    this.imgValidacaoResultado24x24.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgValidacaoResultado24x24.ImageStream");
    this.imgValidacaoResultado24x24.TransparentColor = Color.Transparent;
    this.imgValidacaoResultado24x24.Images.SetKeyName(0, "iconfinder_filter_delete_64279.png");
    this.dgvValidacaoResultado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.dgvValidacaoResultado.BorderStyle = BorderStyle.None;
    this.dgvValidacaoResultado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvValidacaoResultado.Location = new Point(4, 5);
    this.dgvValidacaoResultado.Name = "dgvValidacaoResultado";
    this.dgvValidacaoResultado.ReadOnly = true;
    this.dgvValidacaoResultado.Size = new Size(1224, 547);
    this.dgvValidacaoResultado.TabIndex = 2;
    this.dgvValidacaoResultado.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.dgvValidacaoResultado_CellBeginEdit);
    this.dgvValidacaoResultado.CellClick += new DataGridViewCellEventHandler(this.dgvValidacaoResultado_CellClick);
    this.dgvValidacaoResultado.CellEndEdit += new DataGridViewCellEventHandler(this.dgvValidacaoResultado_CellEndEdit);
    this.dgvValidacaoResultado.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvValidacaoResultado_ColumnHeaderMouseClick);
    this.dgvValidacaoResultado.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvValidacaoResultado_DataBindingComplete);
    this.dgvValidacaoResultado.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvValidacaoResultado_RowHeaderMouseClick);
    this.dgvValidacaoResultado.SelectionChanged += new EventHandler(this.dgvValidacaoResultado_SelectionChanged);
    this.dgvValidacaoResultado.DoubleClick += new EventHandler(this.dgvValidacaoResultado_DoubleClick);
    this.dgvValidacaoResultado.MouseClick += new MouseEventHandler(this.dgvValidacaoResultado_MouseClick);
    this.imgValidacaoResultado48x48.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgValidacaoResultado48x48.ImageStream");
    this.imgValidacaoResultado48x48.TransparentColor = Color.Transparent;
    this.imgValidacaoResultado48x48.Images.SetKeyName(0, "iconfinder_033_95870.png");
    this.btPesquisarTabelas.ImageIndex = 14;
    this.btPesquisarTabelas.ImageList = this.imgValidacaoResultado16x16;
    this.btPesquisarTabelas.Location = new Point(150, 6);
    this.btPesquisarTabelas.Name = "btPesquisarTabelas";
    this.btPesquisarTabelas.Size = new Size(26, 20);
    this.btPesquisarTabelas.TabIndex = 3;
    this.tipVRDiversos.SetToolTip((Control) this.btPesquisarTabelas, "Pesquisa texto no nome da tabela ou apelido");
    this.btPesquisarTabelas.UseVisualStyleBackColor = true;
    this.btPesquisarTabelas.Click += new EventHandler(this.btPesquisarTabelas_Click);
    this.btLimparFiltroTabelas.ImageIndex = 37;
    this.btLimparFiltroTabelas.ImageList = this.imgValidacaoResultado16x16;
    this.btLimparFiltroTabelas.Location = new Point(180, 6);
    this.btLimparFiltroTabelas.Name = "btLimparFiltroTabelas";
    this.btLimparFiltroTabelas.Size = new Size(26, 20);
    this.btLimparFiltroTabelas.TabIndex = 4;
    this.tipVRDiversos.SetToolTip((Control) this.btLimparFiltroTabelas, "Limpar filtros e recarregar lista completa");
    this.btLimparFiltroTabelas.UseVisualStyleBackColor = true;
    this.btLimparFiltroTabelas.Click += new EventHandler(this.btLimparFiltroTabelas_Click);
    this.btnNovaConsultaBancos.BackColor = Color.White;
    this.btnNovaConsultaBancos.ImageKey = "document_plain_new.png";
    this.btnNovaConsultaBancos.ImageList = this.imgValidacaoResultado16x16;
    this.btnNovaConsultaBancos.Location = new Point(77, 42);
    this.btnNovaConsultaBancos.Name = "btnNovaConsultaBancos";
    this.btnNovaConsultaBancos.Size = new Size(30, 30);
    this.btnNovaConsultaBancos.TabIndex = 16 /*0x10*/;
    this.tipVRDiversos.SetToolTip((Control) this.btnNovaConsultaBancos, "Abrir uma nova tela");
    this.btnNovaConsultaBancos.UseVisualStyleBackColor = false;
    this.btnNovaConsultaBancos.Click += new EventHandler(this.btnNovaConsultaBancos_Click);
    this.igualToolStripMenuItem.Name = "igualToolStripMenuItem";
    this.igualToolStripMenuItem.Size = new Size(173, 22);
    this.igualToolStripMenuItem.Text = "Igual a";
    this.diferenteToolStripMenuItem.Name = "diferenteToolStripMenuItem";
    this.diferenteToolStripMenuItem.Size = new Size(173, 22);
    this.diferenteToolStripMenuItem.Text = "Diferente de";
    this.contémlikeToolStripMenuItem.Name = "contémlikeToolStripMenuItem";
    this.contémlikeToolStripMenuItem.Size = new Size(173, 22);
    this.contémlikeToolStripMenuItem.Text = "Contém";
    this.nãoContémNotLikeToolStripMenuItem.Name = "nãoContémNotLikeToolStripMenuItem";
    this.nãoContémNotLikeToolStripMenuItem.Size = new Size(173, 22);
    this.nãoContémNotLikeToolStripMenuItem.Text = "Não contém";
    this.maiorToolStripMenuItem.Name = "maiorToolStripMenuItem";
    this.maiorToolStripMenuItem.Size = new Size(173, 22);
    this.maiorToolStripMenuItem.Text = "É maior que";
    this.maiorOuIgualToolStripMenuItem.Name = "maiorOuIgualToolStripMenuItem";
    this.maiorOuIgualToolStripMenuItem.Size = new Size(173, 22);
    this.maiorOuIgualToolStripMenuItem.Text = "É menor que";
    this.cmsFiltrosValidacaoResultado.ImageScalingSize = new Size(24, 24);
    this.cmsFiltrosValidacaoResultado.Items.AddRange(new ToolStripItem[9]
    {
      (ToolStripItem) this.igualToolStripMenuItem,
      (ToolStripItem) this.diferenteToolStripMenuItem,
      (ToolStripItem) this.contémlikeToolStripMenuItem,
      (ToolStripItem) this.nãoContémNotLikeToolStripMenuItem,
      (ToolStripItem) this.maiorToolStripMenuItem,
      (ToolStripItem) this.maiorOuIgualToolStripMenuItem,
      (ToolStripItem) this.entreToolStripMenuItem,
      (ToolStripItem) this.toolStripSeparator2,
      (ToolStripItem) this.cmsLimparOperador
    });
    this.cmsFiltrosValidacaoResultado.Name = "cmsFiltrosValidacaoResultado";
    this.cmsFiltrosValidacaoResultado.Size = new Size(174, 186);
    this.cmsFiltrosValidacaoResultado.ItemClicked += new ToolStripItemClickedEventHandler(this.cmsFiltrosValidacaoResultado_ItemClicked);
    this.entreToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
    {
      (ToolStripItem) this.toolStripMenuItem1,
      (ToolStripItem) this.cmsTxFiltroInicial,
      (ToolStripItem) this.toolStripMenuItem3,
      (ToolStripItem) this.cmsTxFiltroFinal,
      (ToolStripItem) this.cmsFiltrarEntre
    });
    this.entreToolStripMenuItem.Name = "entreToolStripMenuItem";
    this.entreToolStripMenuItem.Size = new Size(173, 22);
    this.entreToolStripMenuItem.Text = "Entre";
    this.toolStripMenuItem1.Enabled = false;
    this.toolStripMenuItem1.Name = "toolStripMenuItem1";
    this.toolStripMenuItem1.Size = new Size(160 /*0xA0*/, 22);
    this.toolStripMenuItem1.Text = "Valor inicial";
    this.cmsTxFiltroInicial.BackColor = SystemColors.Info;
    this.cmsTxFiltroInicial.BorderStyle = BorderStyle.FixedSingle;
    this.cmsTxFiltroInicial.Name = "cmsTxFiltroInicial";
    this.cmsTxFiltroInicial.Size = new Size(100, 23);
    this.toolStripMenuItem3.Enabled = false;
    this.toolStripMenuItem3.Name = "toolStripMenuItem3";
    this.toolStripMenuItem3.Size = new Size(160 /*0xA0*/, 22);
    this.toolStripMenuItem3.Text = "Valor final";
    this.cmsTxFiltroFinal.BackColor = SystemColors.Info;
    this.cmsTxFiltroFinal.BorderStyle = BorderStyle.FixedSingle;
    this.cmsTxFiltroFinal.Name = "cmsTxFiltroFinal";
    this.cmsTxFiltroFinal.Size = new Size(100, 23);
    this.cmsFiltrarEntre.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.cmsFiltrarEntre.Name = "cmsFiltrarEntre";
    this.cmsFiltrarEntre.RightToLeft = RightToLeft.Yes;
    this.cmsFiltrarEntre.Size = new Size(160 /*0xA0*/, 22);
    this.cmsFiltrarEntre.Text = "OK";
    this.cmsFiltrarEntre.ToolTipText = "Clique aqui para enviar os valores para o filtro principal";
    this.cmsFiltrarEntre.Click += new EventHandler(this.cmsFiltrarEntre_Click);
    this.toolStripSeparator2.Name = "toolStripSeparator2";
    this.toolStripSeparator2.Size = new Size(170, 6);
    this.cmsLimparOperador.Name = "cmsLimparOperador";
    this.cmsLimparOperador.Size = new Size(173, 22);
    this.cmsLimparOperador.Text = "Remover este filtro";
    this.cmsLimparOperador.Click += new EventHandler(this.cmsLimparOperador_Click);
    this.cmsValidacaoResultado.ImageScalingSize = new Size(24, 24);
    this.cmsValidacaoResultado.Items.AddRange(new ToolStripItem[26]
    {
      (ToolStripItem) this.cmsExecutarPrograma,
      (ToolStripItem) this.cmsPesquisarNestaColuna,
      (ToolStripItem) this.cmsTextoPesquisaValidacaoResultado,
      (ToolStripItem) this.cmsLimparFiltroColuna,
      (ToolStripItem) this.toolStripSeparator12,
      (ToolStripItem) this.cmsItemSelecionarTudo,
      (ToolStripItem) this.cmsItemCopiar,
      (ToolStripItem) this.cmsCopiarComCabecalho,
      (ToolStripItem) this.cmsAbrirTextoEmOutraJanela,
      (ToolStripItem) this.cmsHomolog,
      (ToolStripItem) this.sinalizarCélulaToolStripMenuItem,
      (ToolStripItem) this.toolStripSeparator6,
      (ToolStripItem) this.cmsOcultarColuna,
      (ToolStripItem) this.cmsReexibirColunas,
      (ToolStripItem) this.cmsAjustarColuna,
      (ToolStripItem) this.cmsInserirLinha,
      (ToolStripItem) this.toolStripSeparator4,
      (ToolStripItem) this.cmsExportarResultado,
      (ToolStripItem) this.toolStripSeparator5,
      (ToolStripItem) this.cmsInformacoesEdicao,
      (ToolStripItem) this.cmsInformativos,
      (ToolStripItem) this.cmsExportarCronogramaInsumos,
      (ToolStripItem) this.cmsGerarKanban,
      (ToolStripItem) this.cmsAtualizaVolumetriaInsumos,
      (ToolStripItem) this.cmsGraficoVariacao,
      (ToolStripItem) this.tsmGerarInformativo
    });
    this.cmsValidacaoResultado.Name = "cmsValidacaoResultado";
    this.cmsValidacaoResultado.Size = new Size(299, 515);
    this.cmsExecutarPrograma.CheckOnClick = true;
    this.cmsExecutarPrograma.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.cmsExecutarPrograma.ForeColor = SystemColors.ControlText;
    this.cmsExecutarPrograma.Name = "cmsExecutarPrograma";
    this.cmsExecutarPrograma.Size = new Size(298, 22);
    this.cmsExecutarPrograma.Text = "Executar programa";
    this.cmsExecutarPrograma.Visible = false;
    this.cmsExecutarPrograma.Click += new EventHandler(this.cmsExecutarPrograma_Click);
    this.cmsPesquisarNestaColuna.Name = "cmsPesquisarNestaColuna";
    this.cmsPesquisarNestaColuna.Size = new Size(298, 22);
    this.cmsPesquisarNestaColuna.Text = "Procurar";
    this.cmsTextoPesquisaValidacaoResultado.BackColor = SystemColors.Info;
    this.cmsTextoPesquisaValidacaoResultado.BorderStyle = BorderStyle.FixedSingle;
    this.cmsTextoPesquisaValidacaoResultado.Name = "cmsTextoPesquisaValidacaoResultado";
    this.cmsTextoPesquisaValidacaoResultado.Size = new Size(100, 23);
    this.cmsTextoPesquisaValidacaoResultado.TextChanged += new EventHandler(this.cmsTextoPesquisaValidacaoResultado_TextChanged_1);
    this.cmsLimparFiltroColuna.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.cmsLimparFiltroColuna.Name = "cmsLimparFiltroColuna";
    this.cmsLimparFiltroColuna.Size = new Size(298, 22);
    this.cmsLimparFiltroColuna.Text = "Limpar filtro";
    this.cmsLimparFiltroColuna.Click += new EventHandler(this.cmsLimparFiltroColuna_Click_1);
    this.toolStripSeparator12.Name = "toolStripSeparator12";
    this.toolStripSeparator12.Size = new Size(295, 6);
    this.cmsItemSelecionarTudo.Name = "cmsItemSelecionarTudo";
    this.cmsItemSelecionarTudo.Size = new Size(298, 22);
    this.cmsItemSelecionarTudo.Text = "Selecionar tudo";
    this.cmsItemSelecionarTudo.Click += new EventHandler(this.cmsItemSelecionarTudo_Click);
    this.cmsItemCopiar.Name = "cmsItemCopiar";
    this.cmsItemCopiar.Size = new Size(298, 22);
    this.cmsItemCopiar.Text = "Copiar";
    this.cmsItemCopiar.Click += new EventHandler(this.cmsItemCopiar_Click);
    this.cmsCopiarComCabecalho.Name = "cmsCopiarComCabecalho";
    this.cmsCopiarComCabecalho.Size = new Size(298, 22);
    this.cmsCopiarComCabecalho.Text = "Copiar com cabeçalho";
    this.cmsCopiarComCabecalho.Click += new EventHandler(this.cmsCopiarComCabecalho_Click);
    this.cmsAbrirTextoEmOutraJanela.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.cmsAbrirTextoEmOutraJanela.Name = "cmsAbrirTextoEmOutraJanela";
    this.cmsAbrirTextoEmOutraJanela.Size = new Size(298, 22);
    this.cmsAbrirTextoEmOutraJanela.Text = "Abrir texto em outra janela";
    this.cmsAbrirTextoEmOutraJanela.Click += new EventHandler(this.cmsAbrirTextoEmOutraJanela_Click);
    this.cmsHomolog.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.cmsGerarWord,
      (ToolStripItem) this.cmsReenviarWord
    });
    this.cmsHomolog.Font = new Font("Segoe UI", 9f);
    this.cmsHomolog.ForeColor = SystemColors.ControlText;
    this.cmsHomolog.Name = "cmsHomolog";
    this.cmsHomolog.Size = new Size(298, 22);
    this.cmsHomolog.Text = "Gerar Word ou reenviar email de demanda";
    this.cmsHomolog.Visible = false;
    this.cmsHomolog.Click += new EventHandler(this.cmsHomolog_Click);
    this.cmsGerarWord.Name = "cmsGerarWord";
    this.cmsGerarWord.Size = new Size(293, 22);
    this.cmsGerarWord.Text = "Gerar documento Word como evidência";
    this.cmsGerarWord.Click += new EventHandler(this.cmsGerarWord_Click);
    this.cmsReenviarWord.Name = "cmsReenviarWord";
    this.cmsReenviarWord.Size = new Size(293, 22);
    this.cmsReenviarWord.Text = "Reenviar email de conclusão de demanda";
    this.cmsReenviarWord.Click += new EventHandler(this.cmsReenviarWord_Click);
    this.sinalizarCélulaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
    {
      (ToolStripItem) this.cmsFundoVerde,
      (ToolStripItem) this.cmsFundoAmarelo,
      (ToolStripItem) this.cmsFundoVermelho,
      (ToolStripItem) this.cmsFundoBranco
    });
    this.sinalizarCélulaToolStripMenuItem.Name = "sinalizarCélulaToolStripMenuItem";
    this.sinalizarCélulaToolStripMenuItem.Size = new Size(298, 22);
    this.sinalizarCélulaToolStripMenuItem.Text = "Destacar célula";
    this.cmsFundoVerde.BackColor = Color.GreenYellow;
    this.cmsFundoVerde.Name = "cmsFundoVerde";
    this.cmsFundoVerde.Size = new Size(124, 22);
    this.cmsFundoVerde.Text = "Verde";
    this.cmsFundoVerde.Click += new EventHandler(this.cmsFundoVerde_Click);
    this.cmsFundoAmarelo.BackColor = Color.Gold;
    this.cmsFundoAmarelo.Name = "cmsFundoAmarelo";
    this.cmsFundoAmarelo.Size = new Size(124, 22);
    this.cmsFundoAmarelo.Text = "Amarelo";
    this.cmsFundoAmarelo.Click += new EventHandler(this.cmsFundoAmarelo_Click);
    this.cmsFundoVermelho.BackColor = Color.OrangeRed;
    this.cmsFundoVermelho.Name = "cmsFundoVermelho";
    this.cmsFundoVermelho.Size = new Size(124, 22);
    this.cmsFundoVermelho.Text = "Vermelho";
    this.cmsFundoVermelho.Click += new EventHandler(this.cmsFundoVermelho_Click);
    this.cmsFundoBranco.Name = "cmsFundoBranco";
    this.cmsFundoBranco.Size = new Size(124, 22);
    this.cmsFundoBranco.Text = "Branco";
    this.cmsFundoBranco.Click += new EventHandler(this.cmsFundoBranco_Click);
    this.toolStripSeparator6.Name = "toolStripSeparator6";
    this.toolStripSeparator6.Size = new Size(295, 6);
    this.cmsOcultarColuna.Name = "cmsOcultarColuna";
    this.cmsOcultarColuna.Size = new Size(298, 22);
    this.cmsOcultarColuna.Text = "Ocultar coluna";
    this.cmsOcultarColuna.Click += new EventHandler(this.cmsOcultarColuna_Click);
    this.cmsReexibirColunas.Name = "cmsReexibirColunas";
    this.cmsReexibirColunas.Size = new Size(298, 22);
    this.cmsReexibirColunas.Text = "Reexibir colunas";
    this.cmsReexibirColunas.Click += new EventHandler(this.cmsReexibirColunas_Click);
    this.cmsAjustarColuna.Name = "cmsAjustarColuna";
    this.cmsAjustarColuna.Size = new Size(298, 22);
    this.cmsAjustarColuna.Text = "Auto ajustar colunas: Sim";
    this.cmsAjustarColuna.Click += new EventHandler(this.cmsAjustarColuna_Click);
    this.cmsInserirLinha.Name = "cmsInserirLinha";
    this.cmsInserirLinha.Size = new Size(298, 22);
    this.cmsInserirLinha.Text = "Inserir linha";
    this.cmsInserirLinha.Click += new EventHandler(this.cmsInserirLinha_Click);
    this.toolStripSeparator4.Name = "toolStripSeparator4";
    this.toolStripSeparator4.Size = new Size(295, 6);
    this.cmsExportarResultado.DropDownItems.AddRange(new ToolStripItem[4]
    {
      (ToolStripItem) this.separadoPorPortoEVírgulaToolStripMenuItem,
      (ToolStripItem) this.toolStripSeparator3,
      (ToolStripItem) this.cmsExportarResultadoPontoVirgula,
      (ToolStripItem) this.cmsExportarResultadoPipe
    });
    this.cmsExportarResultado.Name = "cmsExportarResultado";
    this.cmsExportarResultado.Size = new Size(298, 22);
    this.cmsExportarResultado.Text = "Exportar resultado para arquivo";
    this.separadoPorPortoEVírgulaToolStripMenuItem.Enabled = false;
    this.separadoPorPortoEVírgulaToolStripMenuItem.Name = "separadoPorPortoEVírgulaToolStripMenuItem";
    this.separadoPorPortoEVírgulaToolStripMenuItem.Size = new Size(171, 22);
    this.separadoPorPortoEVírgulaToolStripMenuItem.Text = "Exportar em texto:";
    this.toolStripSeparator3.Name = "toolStripSeparator3";
    this.toolStripSeparator3.Size = new Size(168, 6);
    this.cmsExportarResultadoPontoVirgula.Name = "cmsExportarResultadoPontoVirgula";
    this.cmsExportarResultadoPontoVirgula.Size = new Size(171, 22);
    this.cmsExportarResultadoPontoVirgula.Text = "Ponto e vírgula";
    this.cmsExportarResultadoPontoVirgula.Click += new EventHandler(this.cmsExportarResultadoPontoVirgula_Click);
    this.cmsExportarResultadoPipe.Name = "cmsExportarResultadoPipe";
    this.cmsExportarResultadoPipe.Size = new Size(171, 22);
    this.cmsExportarResultadoPipe.Text = "Pipe \"|\"";
    this.cmsExportarResultadoPipe.Click += new EventHandler(this.cmsExportarResultadoPipe_Click);
    this.toolStripSeparator5.Name = "toolStripSeparator5";
    this.toolStripSeparator5.Size = new Size(295, 6);
    this.cmsInformacoesEdicao.Name = "cmsInformacoesEdicao";
    this.cmsInformacoesEdicao.Size = new Size(298, 22);
    this.cmsInformacoesEdicao.Text = "Informações sobre edição";
    this.cmsInformacoesEdicao.Click += new EventHandler(this.cmsInformacoesEdicao_Click);
    this.cmsInformativos.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.cmsApenasGerarInformativo,
      (ToolStripItem) this.gerarEEnviarToolStripMenuItem
    });
    this.cmsInformativos.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.cmsInformativos.Name = "cmsInformativos";
    this.cmsInformativos.Size = new Size(298, 22);
    this.cmsInformativos.Text = "Informativos";
    this.cmsInformativos.Visible = false;
    this.cmsApenasGerarInformativo.Font = new Font("Segoe UI", 9f);
    this.cmsApenasGerarInformativo.Name = "cmsApenasGerarInformativo";
    this.cmsApenasGerarInformativo.Size = new Size(154, 22);
    this.cmsApenasGerarInformativo.Text = "Apenas gerar";
    this.cmsApenasGerarInformativo.Click += new EventHandler(this.cmsApenasGerarInformativo_Click);
    this.gerarEEnviarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.cmsGerarEnviarInformativoParaMim,
      (ToolStripItem) this.cmsGerarEnviarInformativosParaColaboradores
    });
    this.gerarEEnviarToolStripMenuItem.Name = "gerarEEnviarToolStripMenuItem";
    this.gerarEEnviarToolStripMenuItem.Size = new Size(154, 22);
    this.gerarEEnviarToolStripMenuItem.Text = "Gerar e enviar";
    this.cmsGerarEnviarInformativoParaMim.Font = new Font("Segoe UI", 9f);
    this.cmsGerarEnviarInformativoParaMim.Name = "cmsGerarEnviarInformativoParaMim";
    this.cmsGerarEnviarInformativoParaMim.Size = new Size(194, 22);
    this.cmsGerarEnviarInformativoParaMim.Text = "Para mim";
    this.cmsGerarEnviarInformativoParaMim.Click += new EventHandler(this.cmsGerarEnviarInformativoParaMim_Click);
    this.cmsGerarEnviarInformativosParaColaboradores.Name = "cmsGerarEnviarInformativosParaColaboradores";
    this.cmsGerarEnviarInformativosParaColaboradores.Size = new Size(194, 22);
    this.cmsGerarEnviarInformativosParaColaboradores.Text = "Para os colaboradores";
    this.cmsGerarEnviarInformativosParaColaboradores.Click += new EventHandler(this.cmsGerarEnviarInformativosParaColaboradores_Click);
    this.cmsExportarCronogramaInsumos.Name = "cmsExportarCronogramaInsumos";
    this.cmsExportarCronogramaInsumos.Size = new Size(298, 22);
    this.cmsExportarCronogramaInsumos.Text = "Gerar Cronograma de Insumos";
    this.cmsExportarCronogramaInsumos.Visible = false;
    this.cmsExportarCronogramaInsumos.Click += new EventHandler(this.cmsExportarCronogramaInsumos_Click);
    this.cmsGerarKanban.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.calendárioDeDemandasToolStripMenuItem,
      (ToolStripItem) this.cmsGerarNovoKanban
    });
    this.cmsGerarKanban.Name = "cmsGerarKanban";
    this.cmsGerarKanban.Size = new Size(298, 22);
    this.cmsGerarKanban.Text = "Gerar Relatório HTML";
    this.cmsGerarKanban.Visible = false;
    this.calendárioDeDemandasToolStripMenuItem.Name = "calendárioDeDemandasToolStripMenuItem";
    this.calendárioDeDemandasToolStripMenuItem.Size = new Size(205, 22);
    this.calendárioDeDemandasToolStripMenuItem.Text = "Calendário de demandas";
    this.calendárioDeDemandasToolStripMenuItem.Click += new EventHandler(this.calendárioDeDemandasToolStripMenuItem_Click);
    this.cmsGerarNovoKanban.Name = "cmsGerarNovoKanban";
    this.cmsGerarNovoKanban.Size = new Size(205, 22);
    this.cmsGerarNovoKanban.Text = "Kanban";
    this.cmsGerarNovoKanban.Click += new EventHandler(this.cmsGerarNovoKanban_Click);
    this.cmsAtualizaVolumetriaInsumos.Name = "cmsAtualizaVolumetriaInsumos";
    this.cmsAtualizaVolumetriaInsumos.Size = new Size(298, 22);
    this.cmsAtualizaVolumetriaInsumos.Text = "Atualizar volumetria Cronograma Insumos";
    this.cmsAtualizaVolumetriaInsumos.Visible = false;
    this.cmsAtualizaVolumetriaInsumos.Click += new EventHandler(this.cmsAtualizaVolumetriaInsumos_Click);
    this.cmsGraficoVariacao.Name = "cmsGraficoVariacao";
    this.cmsGraficoVariacao.Size = new Size(298, 22);
    this.cmsGraficoVariacao.Text = "Gráfico de variação";
    this.cmsGraficoVariacao.Visible = false;
    this.cmsGraficoVariacao.Click += new EventHandler(this.cmsGraficoVariacao_Click);
    this.tsmGerarInformativo.Name = "tsmGerarInformativo";
    this.tsmGerarInformativo.Size = new Size(298, 22);
    this.tsmGerarInformativo.Text = "Teste Novo Informativo";
    this.tsmGerarInformativo.Visible = false;
    this.tsmGerarInformativo.Click += new EventHandler(this.tsmGerarInformativo_Click);
    this.cmsPropriedadesTabelas.ImageScalingSize = new Size(24, 24);
    this.cmsPropriedadesTabelas.Items.AddRange(new ToolStripItem[17]
    {
      (ToolStripItem) this.cmsAddFavoritos,
      (ToolStripItem) this.cmsDelFavoritos,
      (ToolStripItem) this.toolStripSeparator11,
      (ToolStripItem) this.cmsAtualizarListaTabelas,
      (ToolStripItem) this.cmsCopiarNomeTabela,
      (ToolStripItem) this.toolStripSeparator1,
      (ToolStripItem) this.cmsExpandirBancos,
      (ToolStripItem) this.cmsContrairBancos,
      (ToolStripItem) this.toolStripSeparator8,
      (ToolStripItem) this.cmsHabilitarEdicao,
      (ToolStripItem) this.cmsCarregarDados,
      (ToolStripItem) this.toolStripSeparator9,
      (ToolStripItem) this.cmsPropriedades,
      (ToolStripItem) this.estatísticasToolStripMenuItem,
      (ToolStripItem) this.toolStripSeparator10,
      (ToolStripItem) this.cmsAdicionaTabela,
      (ToolStripItem) this.cmsRemoverTabela
    });
    this.cmsPropriedadesTabelas.Name = "cmsFiltrosValidacaoResultado";
    this.cmsPropriedadesTabelas.Size = new Size(229, 298);
    this.cmsAddFavoritos.Name = "cmsAddFavoritos";
    this.cmsAddFavoritos.Size = new Size(228, 22);
    this.cmsAddFavoritos.Text = "Adicionar Favoritos";
    this.cmsAddFavoritos.Click += new EventHandler(this.cmsAddFavoritos_Click);
    this.cmsDelFavoritos.Name = "cmsDelFavoritos";
    this.cmsDelFavoritos.Size = new Size(228, 22);
    this.cmsDelFavoritos.Text = "Remover Favoritos";
    this.cmsDelFavoritos.Click += new EventHandler(this.cmsDelFavoritos_Click);
    this.toolStripSeparator11.Name = "toolStripSeparator11";
    this.toolStripSeparator11.Size = new Size(225, 6);
    this.cmsAtualizarListaTabelas.Name = "cmsAtualizarListaTabelas";
    this.cmsAtualizarListaTabelas.Size = new Size(228, 22);
    this.cmsAtualizarListaTabelas.Text = "Atualizar lista de tabelas";
    this.cmsAtualizarListaTabelas.Click += new EventHandler(this.cmsAtualizarListaTabelas_Click);
    this.cmsCopiarNomeTabela.Name = "cmsCopiarNomeTabela";
    this.cmsCopiarNomeTabela.Size = new Size(228, 22);
    this.cmsCopiarNomeTabela.Text = "Copiar nome do objeto";
    this.cmsCopiarNomeTabela.Click += new EventHandler(this.cmsCopiarNomeTabela_Click);
    this.toolStripSeparator1.Name = "toolStripSeparator1";
    this.toolStripSeparator1.Size = new Size(225, 6);
    this.cmsExpandirBancos.Name = "cmsExpandirBancos";
    this.cmsExpandirBancos.Size = new Size(228, 22);
    this.cmsExpandirBancos.Text = "[+] Expandir todos os bancos";
    this.cmsExpandirBancos.Click += new EventHandler(this.cmsExpandirBancos_Click);
    this.cmsContrairBancos.Name = "cmsContrairBancos";
    this.cmsContrairBancos.Size = new Size(228, 22);
    this.cmsContrairBancos.Text = "[ - ] Contrair todos os bancos";
    this.cmsContrairBancos.Click += new EventHandler(this.cmsContrairBancos_Click);
    this.toolStripSeparator8.Name = "toolStripSeparator8";
    this.toolStripSeparator8.Size = new Size(225, 6);
    this.cmsHabilitarEdicao.Name = "cmsHabilitarEdicao";
    this.cmsHabilitarEdicao.Size = new Size(228, 22);
    this.cmsHabilitarEdicao.Text = "Habilitar edição";
    this.cmsHabilitarEdicao.Click += new EventHandler(this.cmsHabilitarEdicao_Click);
    this.cmsCarregarDados.Name = "cmsCarregarDados";
    this.cmsCarregarDados.Size = new Size(228, 22);
    this.cmsCarregarDados.Text = "Carregar dados";
    this.cmsCarregarDados.Click += new EventHandler(this.cmsCarregarDados_Click);
    this.toolStripSeparator9.Name = "toolStripSeparator9";
    this.toolStripSeparator9.Size = new Size(225, 6);
    this.cmsPropriedades.Name = "cmsPropriedades";
    this.cmsPropriedades.Size = new Size(228, 22);
    this.cmsPropriedades.Text = "Propriedades";
    this.cmsPropriedades.Click += new EventHandler(this.cmsPropriedades_Click);
    this.estatísticasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.cmsVolumetriaTabelas
    });
    this.estatísticasToolStripMenuItem.Name = "estatísticasToolStripMenuItem";
    this.estatísticasToolStripMenuItem.Size = new Size(228, 22);
    this.estatísticasToolStripMenuItem.Text = "Estatísticas";
    this.cmsVolumetriaTabelas.Name = "cmsVolumetriaTabelas";
    this.cmsVolumetriaTabelas.Size = new Size(131, 22);
    this.cmsVolumetriaTabelas.Text = "Volumetria";
    this.cmsVolumetriaTabelas.Click += new EventHandler(this.cmsVolumetriaTabelas_Click);
    this.toolStripSeparator10.Name = "toolStripSeparator10";
    this.toolStripSeparator10.Size = new Size(225, 6);
    this.cmsAdicionaTabela.Name = "cmsAdicionaTabela";
    this.cmsAdicionaTabela.Size = new Size(228, 22);
    this.cmsAdicionaTabela.Text = "Adicionar tabela";
    this.cmsAdicionaTabela.Click += new EventHandler(this.cmsAdicionaTabela_Click);
    this.cmsRemoverTabela.Name = "cmsRemoverTabela";
    this.cmsRemoverTabela.Size = new Size(228, 22);
    this.cmsRemoverTabela.Text = "Remover tabela";
    this.cmsRemoverTabela.Click += new EventHandler(this.cmsRemoverTabela_Click);
    this.cmsFiltroCabecalhoValidacaoResultado.ImageScalingSize = new Size(24, 24);
    this.cmsFiltroCabecalhoValidacaoResultado.Items.AddRange(new ToolStripItem[9]
    {
      (ToolStripItem) this.cmsColunaFiltrada,
      (ToolStripItem) this.toolStripSeparator7,
      (ToolStripItem) this.cmsCmbOperadores,
      (ToolStripItem) this.cmsTextoFiltrar,
      (ToolStripItem) this.cmsAdicionarFiltros,
      (ToolStripItem) this.toolStripMenuItem2,
      (ToolStripItem) this.toolStripSeparator13,
      (ToolStripItem) this.cmsAdicionarFiltrosEPesquisar,
      (ToolStripItem) this.cmsAdicionarFiltrosEPesquisarEEditar
    });
    this.cmsFiltroCabecalhoValidacaoResultado.Name = "contextMenuStrip1";
    this.cmsFiltroCabecalhoValidacaoResultado.Size = new Size(278, 178);
    this.cmsColunaFiltrada.Enabled = false;
    this.cmsColunaFiltrada.Name = "cmsColunaFiltrada";
    this.cmsColunaFiltrada.Size = new Size(277, 22);
    this.cmsColunaFiltrada.Text = "cmsColunaFiltrada";
    this.toolStripSeparator7.Name = "toolStripSeparator7";
    this.toolStripSeparator7.Size = new Size(274, 6);
    this.cmsCmbOperadores.FlatStyle = FlatStyle.Standard;
    this.cmsCmbOperadores.Items.AddRange(new object[7]
    {
      (object) "Igual a",
      (object) "Diferente de",
      (object) "Não contém",
      (object) "Contém",
      (object) "É maior que",
      (object) "É menor que",
      (object) "Entre"
    });
    this.cmsCmbOperadores.Name = "cmsCmbOperadores";
    this.cmsCmbOperadores.Size = new Size(121, 23);
    this.cmsCmbOperadores.SelectedIndexChanged += new EventHandler(this.cmsCmbOperadores_SelectedIndexChanged);
    this.cmsCmbOperadores.Click += new EventHandler(this.cmsCmbOperadores_Click);
    this.cmsTextoFiltrar.AcceptsReturn = true;
    this.cmsTextoFiltrar.AcceptsTab = true;
    this.cmsTextoFiltrar.BackColor = SystemColors.Info;
    this.cmsTextoFiltrar.BorderStyle = BorderStyle.FixedSingle;
    this.cmsTextoFiltrar.Name = "cmsTextoFiltrar";
    this.cmsTextoFiltrar.Size = new Size(123, 23);
    this.cmsAdicionarFiltros.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.cmsAdicionarFiltros.Name = "cmsAdicionarFiltros";
    this.cmsAdicionarFiltros.Size = new Size(277, 22);
    this.cmsAdicionarFiltros.Text = "Adicionar aos filtros";
    this.cmsAdicionarFiltros.Click += new EventHandler(this.cmsAdicionarFiltros_Click);
    this.toolStripMenuItem2.Name = "toolStripMenuItem2";
    this.toolStripMenuItem2.Size = new Size(277, 22);
    this.toolStripMenuItem2.Text = "Cancelar";
    this.toolStripSeparator13.Name = "toolStripSeparator13";
    this.toolStripSeparator13.Size = new Size(274, 6);
    this.cmsAdicionarFiltrosEPesquisar.Font = new Font("Segoe UI", 9f);
    this.cmsAdicionarFiltrosEPesquisar.ForeColor = SystemColors.Desktop;
    this.cmsAdicionarFiltrosEPesquisar.Name = "cmsAdicionarFiltrosEPesquisar";
    this.cmsAdicionarFiltrosEPesquisar.Size = new Size(277, 22);
    this.cmsAdicionarFiltrosEPesquisar.Text = "Adicionar aos filtros e pesquisar";
    this.cmsAdicionarFiltrosEPesquisar.Click += new EventHandler(this.cmsAdicionarFiltrosEPesquisar_Click);
    this.cmsAdicionarFiltrosEPesquisarEEditar.ForeColor = SystemColors.Desktop;
    this.cmsAdicionarFiltrosEPesquisarEEditar.Name = "cmsAdicionarFiltrosEPesquisarEEditar";
    this.cmsAdicionarFiltrosEPesquisarEEditar.Size = new Size(277, 22);
    this.cmsAdicionarFiltrosEPesquisarEEditar.Text = "Adicionar aos filtros, pesquisar e editar";
    this.cmsAdicionarFiltrosEPesquisarEEditar.Click += new EventHandler(this.cmsAdicionarFiltrosEPesquisarEEditar_Click);
    this.tabPage1.Controls.Add((Control) this.btLimparFiltroTabelas);
    this.tabPage1.Controls.Add((Control) this.btPesquisarTabelas);
    this.tabPage1.Controls.Add((Control) this.txPesquisarTabelas);
    this.tabPage1.Controls.Add((Control) this.tvwValidacaoResultado);
    this.tabPage1.Location = new Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new Padding(3);
    this.tabPage1.Size = new Size(211, 558);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "Navegação";
    this.tabPage1.UseVisualStyleBackColor = true;
    this.txPesquisarTabelas.Location = new Point(3, 6);
    this.txPesquisarTabelas.Name = "txPesquisarTabelas";
    this.txPesquisarTabelas.Size = new Size(141, 20);
    this.txPesquisarTabelas.TabIndex = 2;
    this.tvwValidacaoResultado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
    this.tvwValidacaoResultado.BorderStyle = BorderStyle.None;
    this.tvwValidacaoResultado.ImageKey = "iconfinder_bullet-blue_59835.png";
    this.tvwValidacaoResultado.ImageList = this.imgValidacaoResultado16x16;
    this.tvwValidacaoResultado.ItemHeight = 20;
    this.tvwValidacaoResultado.Location = new Point(3, 28);
    this.tvwValidacaoResultado.MinimumSize = new Size(200, 100);
    this.tvwValidacaoResultado.Name = "tvwValidacaoResultado";
    this.tvwValidacaoResultado.Scrollable = false;
    this.tvwValidacaoResultado.SelectedImageIndex = 2;
    this.tvwValidacaoResultado.ShowNodeToolTips = true;
    this.tvwValidacaoResultado.Size = new Size(203, 525);
    this.tvwValidacaoResultado.TabIndex = 1;
    this.tvwValidacaoResultado.AfterSelect += new TreeViewEventHandler(this.tvwValidacaoResultado_AfterSelect);
    this.tvwValidacaoResultado.Click += new EventHandler(this.tvwValidacaoResultado_Click);
    this.tvwValidacaoResultado.DoubleClick += new EventHandler(this.tvwValidacaoResultado_DoubleClick);
    this.tvwValidacaoResultado.MouseClick += new MouseEventHandler(this.tvwValidacaoResultado_MouseClick);
    this.tabNavegacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
    this.tabNavegacao.Controls.Add((Control) this.tabPage1);
    this.tabNavegacao.Location = new Point(2, 118);
    this.tabNavegacao.Name = "tabNavegacao";
    this.tabNavegacao.SelectedIndex = 0;
    this.tabNavegacao.Size = new Size(219, 584);
    this.tabNavegacao.TabIndex = 4;
    this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
    this.notifyIcon1.Icon = (Icon) componentResourceManager.GetObject("notifyIcon1.Icon");
    this.notifyIcon1.Text = "TOT - RV B2B";
    this.notifyIcon1.Visible = true;
    this.imgValidacaoResultado64x16.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgValidacaoResultado64x16.ImageStream");
    this.imgValidacaoResultado64x16.TransparentColor = Color.Transparent;
    this.imgValidacaoResultado64x16.Images.SetKeyName(0, "progress_azul.png");
    this.imgValidacaoResultado64x16.Images.SetKeyName(1, "progress_verde.png");
    this.imgValidacaoResultado64x16.Images.SetKeyName(2, "progress_amarelo.png");
    this.imgValidacaoResultado64x16.Images.SetKeyName(3, "progress_vermelho.png");
    this.imgValidacaoResultado64x16.Images.SetKeyName(4, "progress_preto.png");
    this.tabConsultaBancos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabConsultaBancos.Controls.Add((Control) this.tabConsultaPrincipal);
    this.tabConsultaBancos.Controls.Add((Control) this.tabSql);
    this.tabConsultaBancos.Location = new Point(220, 118);
    this.tabConsultaBancos.Name = "tabConsultaBancos";
    this.tabConsultaBancos.SelectedIndex = 0;
    this.tabConsultaBancos.Size = new Size(1243, 584);
    this.tabConsultaBancos.TabIndex = 5;
    this.tabConsultaPrincipal.Controls.Add((Control) this.txConsultaAtual);
    this.tabConsultaPrincipal.Controls.Add((Control) this.txCodigoForm);
    this.tabConsultaPrincipal.Controls.Add((Control) this.txTabelaAtual);
    this.tabConsultaPrincipal.Controls.Add((Control) this.dgvValidacaoResultado);
    this.tabConsultaPrincipal.Controls.Add((Control) this.txtControleForms);
    this.tabConsultaPrincipal.Controls.Add((Control) this.panel3);
    this.tabConsultaPrincipal.Location = new Point(4, 22);
    this.tabConsultaPrincipal.Name = "tabConsultaPrincipal";
    this.tabConsultaPrincipal.Padding = new Padding(3);
    this.tabConsultaPrincipal.Size = new Size(1235, 558);
    this.tabConsultaPrincipal.TabIndex = 0;
    this.tabConsultaPrincipal.Text = "Dados";
    this.tabConsultaPrincipal.UseVisualStyleBackColor = true;
    this.txConsultaAtual.Location = new Point(239, 152);
    this.txConsultaAtual.Name = "txConsultaAtual";
    this.txConsultaAtual.ReadOnly = true;
    this.txConsultaAtual.Size = new Size(153, 20);
    this.txConsultaAtual.TabIndex = 10;
    this.txConsultaAtual.Visible = false;
    this.txCodigoForm.Location = new Point(239, 117);
    this.txCodigoForm.Name = "txCodigoForm";
    this.txCodigoForm.ReadOnly = true;
    this.txCodigoForm.Size = new Size(153, 20);
    this.txCodigoForm.TabIndex = 6;
    this.txCodigoForm.Visible = false;
    this.txTabelaAtual.Location = new Point(239, 82);
    this.txTabelaAtual.Name = "txTabelaAtual";
    this.txTabelaAtual.ReadOnly = true;
    this.txTabelaAtual.Size = new Size(153, 20);
    this.txTabelaAtual.TabIndex = 5;
    this.txTabelaAtual.Visible = false;
    this.txtControleForms.Location = new Point(37, 19);
    this.txtControleForms.Name = "txtControleForms";
    this.txtControleForms.Size = new Size(26, 20);
    this.txtControleForms.TabIndex = 3;
    this.panel3.BackColor = SystemColors.Control;
    this.panel3.Location = new Point(398, 28);
    this.panel3.Name = "panel3";
    this.panel3.Size = new Size(86, 114);
    this.panel3.TabIndex = 9;
    this.tabSql.Controls.Add((Control) this.rtbSQL);
    this.tabSql.Location = new Point(4, 22);
    this.tabSql.Name = "tabSql";
    this.tabSql.Padding = new Padding(3);
    this.tabSql.Size = new Size(1235, 558);
    this.tabSql.TabIndex = 1;
    this.tabSql.Text = "SQL";
    this.tabSql.UseVisualStyleBackColor = true;
    this.rtbSQL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rtbSQL.Location = new Point(6, 6);
    this.rtbSQL.Name = "rtbSQL";
    this.rtbSQL.Size = new Size(1007, 301);
    this.rtbSQL.TabIndex = 0;
    this.rtbSQL.Text = "";
    this.rtbSQL.TextChanged += new EventHandler(this.rtbSQL_TextChanged);
    this.cmsCombo.ImageScalingSize = new Size(24, 24);
    this.cmsCombo.Items.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.cmbItensDataGrid,
      (ToolStripItem) this.cmsItemComboOK,
      (ToolStripItem) this.cmsItemCombo
    });
    this.cmsCombo.Name = "cmsCombo";
    this.cmsCombo.Size = new Size(182, 75);
    this.cmbItensDataGrid.BackColor = Color.Gold;
    this.cmbItensDataGrid.DropDownStyle = ComboBoxStyle.DropDownList;
    this.cmbItensDataGrid.Name = "cmbItensDataGrid";
    this.cmbItensDataGrid.Size = new Size(121, 23);
    this.cmbItensDataGrid.SelectedIndexChanged += new EventHandler(this.cmbItensDataGrid_SelectedIndexChanged);
    this.cmsItemComboOK.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.cmsItemComboOK.Name = "cmsItemComboOK";
    this.cmsItemComboOK.Size = new Size(181, 22);
    this.cmsItemComboOK.Text = "OK";
    this.cmsItemComboOK.Click += new EventHandler(this.cmsItemComboOK_Click);
    this.cmsItemCombo.Name = "cmsItemCombo";
    this.cmsItemCombo.Size = new Size(181, 22);
    this.cmsItemCombo.Text = "Cancelar";
    this.panel4.BackColor = SystemColors.ButtonHighlight;
    this.panel4.Controls.Add((Control) this.btnPesquisarEditar);
    this.panel4.Controls.Add((Control) this.btnNovaConsultaBancos);
    this.panel4.Controls.Add((Control) this.btnEstatisticas);
    this.panel4.Controls.Add((Control) this.button7);
    this.panel4.Controls.Add((Control) this.btnVRExportarExcel);
    this.panel4.Controls.Add((Control) this.btnExcluir);
    this.panel4.Controls.Add((Control) this.btnAdicionarLinhas);
    this.panel4.Controls.Add((Control) this.btnPesquisarValidacaoResultado);
    this.panel4.Controls.Add((Control) this.btnSalvarNovasLinhas);
    this.panel4.Location = new Point(2, 1);
    this.panel4.Name = "panel4";
    this.panel4.Size = new Size(215, 114);
    this.panel4.TabIndex = 6;
    this.cmsProcurarArquivo.ImageScalingSize = new Size(24, 24);
    this.cmsProcurarArquivo.Items.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.toolStripSeparator14,
      (ToolStripItem) this.tsmProcurarArquivo,
      (ToolStripItem) this.cmsEditarCelulaArquivoOrigem
    });
    this.cmsProcurarArquivo.Name = "cmsCombo";
    this.cmsProcurarArquivo.Size = new Size(202, 54);
    this.toolStripSeparator14.Name = "toolStripSeparator14";
    this.toolStripSeparator14.Size = new Size(198, 6);
    this.tsmProcurarArquivo.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    this.tsmProcurarArquivo.Name = "tsmProcurarArquivo";
    this.tsmProcurarArquivo.Size = new Size(201, 22);
    this.tsmProcurarArquivo.Text = "Procurar arquivo no PC";
    this.tsmProcurarArquivo.Click += new EventHandler(this.tsmProcurarArquivo_Click);
    this.cmsEditarCelulaArquivoOrigem.Name = "cmsEditarCelulaArquivoOrigem";
    this.cmsEditarCelulaArquivoOrigem.Size = new Size(201, 22);
    this.cmsEditarCelulaArquivoOrigem.Text = "Editar célula";
    this.cmsEditarCelulaArquivoOrigem.Click += new EventHandler(this.cmsEditarCelulaArquivoOrigem_Click);
    this.rtbInformativos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rtbInformativos.BorderStyle = BorderStyle.None;
    this.rtbInformativos.Location = new Point(610, 9);
    this.rtbInformativos.Name = "rtbInformativos";
    this.rtbInformativos.ReadOnly = true;
    this.rtbInformativos.Size = new Size(608, 70);
    this.rtbInformativos.TabIndex = 45;
    this.rtbInformativos.Text = "";
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1468, 706);
    this.Controls.Add((Control) this.panel4);
    this.Controls.Add((Control) this.tabConsultaBancos);
    this.Controls.Add((Control) this.tabNavegacao);
    this.Controls.Add((Control) this.tabValidacaoResultados);
    this.Name = nameof (frmConsultaBancos);
    this.Text = "frValidacaoResultado";
    this.Activated += new EventHandler(this.frmConsultaBancos_Activated);
    this.Load += new EventHandler(this.frValidacaoResultado_Load);
    this.KeyDown += new KeyEventHandler(this.frmConsultaBancos_KeyDown);
    this.Leave += new EventHandler(this.frmConsultaBancos_Leave);
    this.tabValidacaoResultados.ResumeLayout(false);
    this.tpValidacaoResultadoInicio.ResumeLayout(false);
    this.tabOpcoes.ResumeLayout(false);
    this.tabOpcoesConsultas.ResumeLayout(false);
    this.panel1.ResumeLayout(false);
    this.panel1.PerformLayout();
    this.tabValidaResultAux1.ResumeLayout(false);
    this.tabHistoricoConsultas.ResumeLayout(false);
    this.grpFiltrosValidacaoResultado.ResumeLayout(false);
    ((ISupportInitialize) this.dgvFiltrosValidacaoResultado).EndInit();
    this.tpDataQuality.ResumeLayout(false);
    this.groupBox4.ResumeLayout(false);
    this.groupBox4.PerformLayout();
    this.panel6.ResumeLayout(false);
    this.tpCalculo.ResumeLayout(false);
    this.groupBox2.ResumeLayout(false);
    this.panel5.ResumeLayout(false);
    this.panel5.PerformLayout();
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.tpCalculoPrincipal.ResumeLayout(false);
    this.groupBox3.ResumeLayout(false);
    this.groupBox3.PerformLayout();
    this.panel2.ResumeLayout(false);
    this.tpCargaInsumos.ResumeLayout(false);
    this.groupBox5.ResumeLayout(false);
    this.groupBox5.PerformLayout();
    this.panel7.ResumeLayout(false);
    this.tpInformativos.ResumeLayout(false);
    this.groupBox6.ResumeLayout(false);
    this.groupBox6.PerformLayout();
    ((ISupportInitialize) this.dgvValidacaoResultado).EndInit();
    this.cmsFiltrosValidacaoResultado.ResumeLayout(false);
    this.cmsValidacaoResultado.ResumeLayout(false);
    this.cmsValidacaoResultado.PerformLayout();
    this.cmsPropriedadesTabelas.ResumeLayout(false);
    this.cmsFiltroCabecalhoValidacaoResultado.ResumeLayout(false);
    this.cmsFiltroCabecalhoValidacaoResultado.PerformLayout();
    this.tabPage1.ResumeLayout(false);
    this.tabPage1.PerformLayout();
    this.tabNavegacao.ResumeLayout(false);
    this.tabConsultaBancos.ResumeLayout(false);
    this.tabConsultaPrincipal.ResumeLayout(false);
    this.tabConsultaPrincipal.PerformLayout();
    this.tabSql.ResumeLayout(false);
    this.cmsCombo.ResumeLayout(false);
    this.panel4.ResumeLayout(false);
    this.cmsProcurarArquivo.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
