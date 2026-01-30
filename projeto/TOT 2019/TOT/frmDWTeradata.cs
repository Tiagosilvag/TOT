// Decompiled with JetBrains decompiler
// Type: TOT.frmDWTeradata
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Teradata.Client.Provider;

#nullable disable
namespace TOT;

public class frmDWTeradata : Form
{
  private IContainer components = (IContainer) null;
  private TabControl tabControlConsultaDW;
  private TabPage tabPage1;
  private DataGridView dtgConsultaDW;
  private Panel panel1;
  private Button btnConsultaDWMovel;
  private ToolStrip toolStrip1;
  private DateTimePicker dataFinal;
  private Label label4;
  private Label label3;
  private DateTimePicker dataInicial;
  private GroupBox groupBox1;
  private GroupBox groupBox2;
  private ComboBox comboConsultaDWMovel;
  private TextBox campoPesquisaRegistrosDW;
  private Panel painelTipoPesquisaDW;
  private RadioButton radioMovimentoDW;
  private RadioButton radioServicoDW;
  private RadioButton radioParqueDW;
  private BackgroundWorker backgroundWorker1;
  private Panel panel2;
  private CheckBox checkCarteiraB2B;
  private CheckBox checkParqueAtivo;
  private CheckBox checkAltasBaixas;
  private GroupBox groupBox3;
  private Label label2;
  private TextBox textSenhaTeradata;
  private Label label1;
  private TextBox textUsuarioTeradata;
  private ContextMenuStrip contextMenuStrip1;
  private ToolStripMenuItem menuExportarSQL;
  private ToolStripMenuItem menuCopiarResultado;
  private GroupBox groupBox4;
  private CheckBox checkPortabilidade;
  private GroupBox groupBox5;
  private Label label6;
  private Label label5;
  private TextBox textPesquisarNoGrid1;
  private TabPage tabPage2;
  private GroupBox groupBox6;
  private TextBox textCampoPesquisaCarteira;
  private Panel panel4;
  private Button btnConsultaCarteira;
  private Panel panel3;
  private ComboBox comboTipoPesquisa;
  private GroupBox groupBox7;
  private CheckedListBox checkedListBox1;
  private Label label8;

  public frmDWTeradata() => this.InitializeComponent();

  private void formDWTeradata_Load(object sender, EventArgs e)
  {
    this.tabControlConsultaDW.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.dtgConsultaDW.RowsDefaultCellStyle.BackColor = Color.GhostWhite;
    this.dtgConsultaDW.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
    this.dtgConsultaDW.AllowUserToAddRows = false;
    this.dtgConsultaDW.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dtgConsultaDW_CellFormatting);
    this.Controls.Add((Control) this.dtgConsultaDW);
    this.comboConsultaDWMovel.SelectedIndex = 0;
  }

  public string ultimoDiaMes(string dataHora)
  {
    dataHora = Convert.ToDateTime(dataHora).ToString("yyyy-MM-01");
    DateTime today = DateTime.Today;
    DateTime dateTime1 = Convert.ToDateTime(dataHora);
    dateTime1 = dateTime1.AddMonths(1);
    DateTime dateTime2 = dateTime1.AddDays(-1.0);
    if (dateTime2 > today.AddDays(-3.0))
    {
      DateTime dateTime3 = Convert.ToDateTime(dataHora);
      dateTime3 = dateTime3.AddMonths(0);
      dateTime2 = dateTime3.AddDays(-1.0);
    }
    return dateTime2.ToString("yyyy-MM-dd");
  }

  private void btnConsultaDWMovel_Estado(bool estado)
  {
    if (estado)
    {
      this.atualizarBarraStatus("");
      this.btnConsultaDWMovel.Enabled = true;
      this.btnConsultaDWMovel.Text = "Pesquisar (F5)";
      this.btnConsultaDWMovel.Font = new Font(this.btnConsultaDWMovel.Font, FontStyle.Regular);
      this.atualizarBarraStatus($"Sua consulta retornou {this.dtgConsultaDW.RowCount.ToString()} registros");
    }
    else
    {
      this.atualizarBarraStatus($"[{DateTime.Now.ToString()}] Aguarde... Executando consulta no banco de dados...");
      this.btnConsultaDWMovel.Text = "Aguarde";
      this.btnConsultaDWMovel.Enabled = false;
      this.btnConsultaDWMovel.Font = new Font(this.btnConsultaDWMovel.Font, FontStyle.Bold);
    }
  }

  private void consultaDWMovel()
  {
    this.btnConsultaDWMovel_Estado(false);
    string str1 = "";
    string str2 = "";
    string str3 = "";
    string text1 = this.dataInicial.Text;
    string text2 = this.dataFinal.Text;
    string text3 = this.campoPesquisaRegistrosDW.Text;
    if (text3.Length > 0)
    {
      string str4 = (text3 + Environment.NewLine).Replace(Environment.NewLine, "','");
      string text4 = this.comboConsultaDWMovel.Text;
      if (this.radioMovimentoDW.Checked)
      {
        str1 = "DISTINCT MOV.NR_TLFN AS TELEFONE, C.ID_TIPO_MVMT_LNHA AS \"MOVIMENTO\", C.DS_TIPO_MVMT_LNHA AS \"DESC MOVIMENTO\", TO_CHAR(MOV.DT_MVMT_LNHA,'DD/MM/YYYY') AS \"DATA MOVIMENTO\", PSS.NR_DCTO_PRNC AS \"DOCUMENTO\", PSS.NM_PSSA AS \"CLIENTE\", CASE WHEN MOV.ID_ATND < 1 THEN MOV.NM_LOGN_ATND ELSE ATN.CD_ATND END AS \"ATENDENTE\", ATN.NM_ATND AS \"NOME ATENDENTE\", (CASE WHEN MOV.FL_PRQE_ATVO = 1 THEN 'SIM' ELSE 'NÃO' END) AS \"PARQUE ATIVO\", MOV.ID_TIPO_MTRL_SRVC AS \"COD MATERIAL\", D.DS_TIPO_MTRL AS \"MATERIAL\", E.DS_PLTF AS PLATAFORMA, F.DS_PLNO AS PLANO ";
        if (this.checkPortabilidade.Checked)
          str1 += ", (SELECT\t\tMAX(P.DT_ALTR_STTS) AS  DT_ALTR_STTS FROM \t\t    VW_FAT_MVMT_PRTB_HSTR P WHERE          P.NR_TLFN = MOV.NR_TLFN AND    \t\t    P.ID_TIPO_PRTB IN (1,4) AND \t\t\t\tP.ID_STTS_TRNS_PRTB = 14 AND \t\t\t\tP.DT_ALTR_STTS >= MOV.DT_MVMT_LNHA ) AS PORTABILIDADE ";
        str2 = "VW_FAT_MVMT_LNHA AS MOV JOIN VW_DIM_PSSA AS PSS ON PSS.ID_PSSA = MOV.ID_PSSA JOIN VW_DIM_TIPO_MTRL AS D ON D.ID_TIPO_MTRL = MOV.ID_TIPO_MTRL_SRVC JOIN VW_DIM_TIPO_MVMT_LNHA AS C ON C.ID_TIPO_MVMT_LNHA = MOV.ID_TIPO_MVMT_LNHA JOIN VW_DIM_PLTF AS E ON E.ID_PLTF = MOV.ID_PLTF JOIN VW_DIM_PLNO AS F ON F.ID_PLNO = MOV.ID_PLNO JOIN VW_DIM_ATND AS ATN ON ATN.ID_ATND = MOV.ID_ATND JOIN VW_DIM_PNTO_VNDA AS PTOA ON PTOA.ID_PNTO_VNDA = MOV.ID_PNTO_VNDA ";
        str3 = $"AND MOV.DT_MVMT_LNHA BETWEEN DATE '{Convert.ToDateTime(text1).ToString("yyyy-MM-dd")}' AND DATE '{Convert.ToDateTime(text2).ToString("yyyy-MM-dd")}' ";
        if (this.checkParqueAtivo.Checked)
          str3 += "AND MOV.FL_PRQE_ATVO = 1 ";
        if (this.checkCarteiraB2B.Checked)
          str3 += "AND MOV.ID_TIPO_CRTR = 2 ";
        if (this.checkAltasBaixas.Checked)
          str3 += "AND MOV.ID_TIPO_MVMT_LNHA IN (101,102) ";
      }
      if (this.radioServicoDW.Checked)
      {
        str1 = "DISTINCT PAR.NR_TLFN AS TELEFONE, (CASE WHEN PAR.FL_PRQE_ATVO = 1 THEN 'SIM' ELSE 'NÃO' END) AS \"PARQUE ATIVO\", TO_CHAR(PAR.DT_FOTO_LNHA,'DD/MM/YYYY') AS \"DATA FOTO\", SRV.CD_SRVC AS \"SERVICE NAME\", SRV.DS_SRVC AS \"SERVICE DESC\", (CASE WHEN LNH.FL_PLNO = 1 THEN 'PLANO' ELSE 'SERVIÇO' END) AS \"TIPO ATIVAÇÃO\", TO_CHAR(LNH.DT_ATVC_SRVC,'DD/MM/YYYY') AS \"DATA ATIV SERV\", TO_CHAR(LNH.DT_DSTV_SRVC,'DD/MM/YYYY') AS \"DATA DESAT SERV\", CASE WHEN LNH.ID_ATND_ATVC < 1 THEN LNH.NM_LOGN_ATND_ATVC ELSE ATN.CD_ATND END AS \"ATENDENTE ATIV\", ATN.NM_ATND AS \"NOME ATENDENTE ATIV\", LNH.CD_PNTO_VNDA_ATVC AS \"PONTO VENDA ATIV\", PTOA.NM_RZAO_SCAL AS \"NOME PONTO VENDA ATIV\", PSS.NR_DCTO_PRNC AS \"DOCUMENTO\", PAR.ID_NTZA_PSSA AS \"TIPO CLIENTE\", PSS.NM_PSSA AS \"CLIENTE\" ";
        str2 = "VW_RLC_LNHA_SRVC AS LNH JOIN VW_FAT_PRQE_LNHA_DSPT AS PAR ON PAR.ID_LNHA = LNH.ID_LNHA JOIN VW_DIM_PSSA AS PSS ON PSS.ID_PSSA = PAR.ID_PSSA JOIN VW_DIM_SRVC AS SRV ON SRV.ID_SRVC = LNH.ID_SRVC JOIN VW_DIM_ATND AS ATN ON ATN.ID_ATND = LNH.ID_ATND_ATVC JOIN VW_DIM_PNTO_VNDA AS PTOA ON PTOA.ID_PNTO_VNDA = LNH.ID_PNTO_VNDA_ATVC ";
        str3 = $"{str3}AND PAR.FL_PRQE_OFCL = 1 AND PAR.DT_FOTO_LNHA = DATE '{this.ultimoDiaMes(text2)}' AND LNH.DT_ATVC_SRVC BETWEEN DATE '{Convert.ToDateTime(text1).ToString("yyyy-MM-dd")}' AND DATE '{Convert.ToDateTime(text2).ToString("yyyy-MM-dd")}' ";
      }
      if (this.radioParqueDW.Checked)
      {
        str1 = "DISTINCT PAR.NR_TLFN AS TELEFONE, TO_CHAR(PAR.DT_FOTO_LNHA,'DD/MM/YYYY') AS \"DATA FOTO\", PSS.NR_DCTO_PRNC AS \"DOCUMENTO\", PAR.ID_NTZA_PSSA AS \"TIPO CLIENTE\", PSS.NM_PSSA AS \"CLIENTE\", (CASE WHEN PAR.FL_PRQE_ATVO = 1 THEN 'SIM' ELSE 'NÃO' END) AS \"PARQUE ATIVO\", D.DS_TIPO_MTRL AS \"MATERIAL\", E.DS_PLTF AS PLATAFORMA, F.DS_PLNO AS PLANO ";
        str2 = "VW_FAT_PRQE_LNHA_DSPT AS PAR JOIN VW_DIM_PSSA AS PSS ON PSS.ID_PSSA = PAR.ID_PSSA JOIN VW_DIM_TIPO_MTRL AS D ON D.ID_TIPO_MTRL = PAR.ID_TIPO_MTRL_SRVC JOIN VW_DIM_PLTF AS E ON PAR.ID_PLTF = E.ID_PLTF JOIN VW_DIM_PLNO AS F ON PAR.ID_PLNO = F.ID_PLNO ";
        str3 = $"{str3}AND PAR.FL_PRQE_OFCL = 1 AND PAR.DT_FOTO_LNHA BETWEEN DATE '{this.ultimoDiaMes(text1)}' AND DATE '{this.ultimoDiaMes(text2)}' ";
        if (this.checkParqueAtivo.Checked)
          str3 += "AND PAR.FL_PRQE_ATVO = 1 ";
      }
      switch (text4)
      {
        case "Cod. Cli.":
          str3 = $"{str3}AND ('40'||SUBSTR(PSS.NR_CNPJ,1,8) in ('{str4}') OR '10'||SUBSTR(PSS.NR_CPF,1,8) in ('{str4}')) ";
          break;
        case "CNPJ ou CPF":
          str3 = $"{str3}AND PSS.NR_DCTO_PRNC in ('{str4}') ";
          break;
        case "Nome cliente":
          str3 = $"{str3}AND PSS.NM_PSSA LIKE '%{str4}%' ";
          break;
        case "Núm. telefones":
          str3 = !this.radioMovimentoDW.Checked ? $"{str3}AND PAR.NR_TLFN in ('{str4}') " : $"{str3}AND MOV.NR_TLFN in ('{str4}') ";
          break;
        case "Service name":
          if (this.radioServicoDW.Checked)
          {
            str3 = $"{str3}AND SRV.CD_SRVC in ('{str4}') ";
            break;
          }
          int num1 = (int) MessageBox.Show("A pesquisa por Service Name só funciona para consultas na base de serviço.", "TOT - Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          return;
        case "Atendente (Adabas)":
          if (this.radioMovimentoDW.Checked)
            str3 = $"{str3}AND (ATN.CD_ATND in ('{str4}') OR MOV.NM_LOGN_ATND in ('{str4}'))";
          if (this.radioServicoDW.Checked)
          {
            str3 = $"{str3}AND (ATN.CD_ATND in ('{str4}') OR LNH.NM_LOGN_ATND_ATVC in ('{str4}'))";
            break;
          }
          break;
      }
      string querySQL = $"SELECT {str1} FROM {str2} WHERE 1=1 {str3}".Replace(",''", "");
      try
      {
        this.pesquisarTerada(querySQL);
        BLL.SQLParaAreaDeTransferencia = querySQL;
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show(ex.Message + Environment.NewLine + querySQL, "TOT - Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      finally
      {
        this.btnConsultaDWMovel_Estado(true);
      }
    }
    else
    {
      this.btnConsultaDWMovel_Estado(true);
      int num = (int) MessageBox.Show("Forneça um ou mais códigos para pesquisar (Adabas, Nº telefone, outros)");
    }
  }

  private void btnConsultaDWMovel_Click(object sender, EventArgs e) => this.consultaDWMovel();

  private void pesquisarTerada(string querySQL)
  {
    try
    {
      string text1 = this.textUsuarioTeradata.Text;
      string text2 = this.textSenhaTeradata.Text;
      if (text1.Length < 1 || text2.Length < 1)
      {
        int num = (int) MessageBox.Show("Informe um usuário e senha válidos", "TOT - Confira usuário e senha", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return;
      }
      TdConnectionStringBuilder connectionStringBuilder = new TdConnectionStringBuilder();
      connectionStringBuilder.DataSource = "teradwu.redecorp.br";
      connectionStringBuilder.Database = "P_VIEDB";
      connectionStringBuilder.UserId = text1;
      connectionStringBuilder.Password = text2;
      connectionStringBuilder.AuthenticationMechanism = "LDAP";
      connectionStringBuilder.PersistSecurityInfo = false;
      connectionStringBuilder.CommandTimeout = 1800;
      using (TdConnection tdConnection = new TdConnection())
      {
        ((DbConnection) tdConnection).ConnectionString = ((DbConnectionStringBuilder) connectionStringBuilder).ConnectionString;
        ((DbConnection) tdConnection).Open();
        TdCommand command = tdConnection.CreateCommand();
        ((DbCommand) command).CommandText = querySQL;
        DataTable dataTable = new DataTable();
        ((DbDataAdapter) new TdDataAdapter(command)).Fill(dataTable);
        this.dtgConsultaDW.DataSource = (object) dataTable;
        if (((DbConnection) tdConnection).State == ConnectionState.Open)
          ((DbConnection) tdConnection).Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show($"Erro ao executar consulta no Teradata [{ex.Message}]{Environment.NewLine}Consulta SQL:{Environment.NewLine}{querySQL}");
    }
    finally
    {
      this.CopiarSQLParaClipboard(BLL.SQLParaAreaDeTransferencia);
    }
    this.btnConsultaDWMovel_Estado(true);
  }

  private void label1_Click(object sender, EventArgs e)
  {
  }

  private void comboConsultaDWMovimento_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void radioButton1_CheckedChanged(object sender, EventArgs e)
  {
  }

  private void dtgConsultaDW_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
  {
    if (!this.dtgConsultaDW.Columns[e.ColumnIndex].Name.Equals("ATENDENTE ATIV") && !this.dtgConsultaDW.Columns[e.ColumnIndex].Name.Equals("ATENDENTE"))
      return;
    string str = e.Value.ToString();
    if (str != "")
    {
      if (str.Substring(0, 2).ToUpper() != "MP")
      {
        e.CellStyle.BackColor = Color.Gold;
        e.CellStyle.ForeColor = Color.Red;
      }
    }
    else
    {
      e.CellStyle.BackColor = Color.Gold;
      e.CellStyle.ForeColor = Color.Red;
    }
  }

  private void campoPesquisaRegistrosDW_TextChanged(object sender, EventArgs e)
  {
    string str1 = this.campoPesquisaRegistrosDW.Text + Environment.NewLine;
    if (str1.Length > 0)
      str1 = str1.Replace(Environment.NewLine, "','");
    int num = str1.IndexOf("'", 1);
    string str2 = str1;
    switch (num)
    {
      case 10:
        this.comboConsultaDWMovel.SelectedIndex = this.comboConsultaDWMovel.FindString("Cod.Cli.");
        break;
      case 11:
        this.comboConsultaDWMovel.SelectedIndex = this.comboConsultaDWMovel.FindString("Núm. telefones");
        break;
      case 14:
        this.comboConsultaDWMovel.SelectedIndex = this.comboConsultaDWMovel.FindString("CNPJ ou CPF");
        break;
    }
    if (!(str2.Substring(0, 2).ToUpper() == "MP"))
      return;
    this.comboConsultaDWMovel.SelectedIndex = this.comboConsultaDWMovel.FindString("Atendente (Adabas)");
  }

  private string validarPesquisa() => "x";

  private void CopiarSQLParaClipboard(string scriptSQL)
  {
    try
    {
      if (scriptSQL.Length <= 1)
        return;
      Clipboard.SetText(scriptSQL);
      this.atualizarBarraStatus("Script SQL copiado para a área de transferência...");
    }
    catch
    {
      int num = (int) MessageBox.Show("Não foi possível copiar o SQL para a área de transferência", "TOT - Erra com área de transferência", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
  {
  }

  private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
  {
  }

  private void label2_Click(object sender, EventArgs e)
  {
  }

  private string SafeSqlLiteral(string inputSQL)
  {
    try
    {
      return Regex.Replace(inputSQL, "[^0-9a-zA-Z\\r\\n\\sáéíóúàèìòùâêîôûãõçÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕÇ]+", "");
    }
    catch
    {
      return inputSQL;
    }
  }

  private void painelTipoPesquisaDW_Paint(object sender, PaintEventArgs e)
  {
  }

  private void dtgConsultaDW_MouseClick(object sender, MouseEventArgs e)
  {
    if (e.Button != MouseButtons.Right)
      return;
    ContextMenuStrip contextMenuStrip1 = this.contextMenuStrip1;
    Point position = Cursor.Position;
    int x = position.X;
    position = Cursor.Position;
    int y = position.Y;
    contextMenuStrip1.Show(x, y);
  }

  private void copyAlltoClipboard()
  {
    try
    {
      this.dtgConsultaDW.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
      this.dtgConsultaDW.MultiSelect = true;
      this.dtgConsultaDW.SelectAll();
      DataObject clipboardContent = this.dtgConsultaDW.GetClipboardContent();
      if (clipboardContent != null)
        Clipboard.SetDataObject((object) clipboardContent);
      this.dtgConsultaDW.ClearSelection();
      this.atualizarBarraStatus("Tabela copiada para a área de transferência.");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show($"Erro ao tentar copiar o conteúdo da tabela: [{ex.Message}]", "TOT - Erro ao copiar", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void menuCopiarResultado_Click(object sender, EventArgs e) => this.copyAlltoClipboard();

  private void atualizarBarraStatus(string texto)
  {
    try
    {
      (this.MdiParent as frmPrincipal).statusLabelFormPrincipal.Text = texto;
    }
    catch
    {
      int num = (int) MessageBox.Show("Erro ao atualizar a barra de status", "TOT - Erro ao copiar", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void menuExportarSQL_Click(object sender, EventArgs e)
  {
    this.CopiarSQLParaClipboard(BLL.SQLParaAreaDeTransferencia);
  }

  private void checkPortabilidade_CheckedChanged(object sender, EventArgs e)
  {
    if (this.checkPortabilidade.Checked)
      this.atualizarBarraStatus("Atenção! Exibir o campo PORTABILIDADE aumentará o tempo de pesquisa");
    else
      this.atualizarBarraStatus("");
  }

  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    bool flag = false;
    if (keyData == Keys.F5)
    {
      this.consultaDWMovel();
      flag = true;
    }
    return flag;
  }

  public TimeSpan GetHourSpan(DateTime fromTime, DateTime toTime)
  {
    TimeSpan ts = TimeSpan.FromHours((double) fromTime.Second);
    TimeSpan hourSpan = TimeSpan.FromHours((double) toTime.Second).Subtract(ts);
    TimeSpan timeSpan = toTime - fromTime;
    return hourSpan;
  }

  private void dtgConsultaDW_SelectionChanged(object sender, EventArgs e)
  {
    this.atualizarBarraStatus($"Total de {this.dtgConsultaDW.SelectedCells.Count.ToString()} celula(s) selecionada(s)");
  }

  private void textPesquisarNoGrid1_TextChanged(object sender, EventArgs e)
  {
    string celulaAtual = BLL.celulaAtual;
    string text = this.textPesquisarNoGrid1.Text;
    if (celulaAtual != "" && celulaAtual != null)
    {
      (this.dtgConsultaDW.DataSource as DataTable).DefaultView.RowFilter = $"Convert([{celulaAtual}], 'System.String') LIKE '%{text}%'";
      this.atualizarBarraStatus($"Seu filtro retornou {this.dtgConsultaDW.Rows.GetRowCount(DataGridViewElementStates.Visible).ToString()} linha(s)");
    }
    else
    {
      int num = (int) MessageBox.Show($"Antes de utilizar o filtro, clique sobre uma celula da planilha {Environment.NewLine}para definir em qual coluna a pesquisa será aplicada.", "TOT - Escolha uma coluna", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
  }

  private void dtgConsultaDW_CellClick(object sender, DataGridViewCellEventArgs e)
  {
    try
    {
      BLL.celulaAtual = this.dtgConsultaDW.CurrentCell.OwningColumn.Name;
      this.label6.Text = BLL.celulaAtual.ToUpper();
    }
    catch (Exception ex)
    {
      this.atualizarBarraStatus("Erro ao tentar selecionar o campo filtro... " + ex?.ToString());
    }
  }

  private void dtgConsultaDW_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    this.tabControlConsultaDW = new TabControl();
    this.tabPage1 = new TabPage();
    this.groupBox5 = new GroupBox();
    this.textPesquisarNoGrid1 = new TextBox();
    this.label5 = new Label();
    this.label6 = new Label();
    this.groupBox4 = new GroupBox();
    this.checkPortabilidade = new CheckBox();
    this.groupBox3 = new GroupBox();
    this.label2 = new Label();
    this.textSenhaTeradata = new TextBox();
    this.label1 = new Label();
    this.textUsuarioTeradata = new TextBox();
    this.groupBox2 = new GroupBox();
    this.panel2 = new Panel();
    this.checkCarteiraB2B = new CheckBox();
    this.checkParqueAtivo = new CheckBox();
    this.checkAltasBaixas = new CheckBox();
    this.dataFinal = new DateTimePicker();
    this.label4 = new Label();
    this.label3 = new Label();
    this.dataInicial = new DateTimePicker();
    this.groupBox1 = new GroupBox();
    this.painelTipoPesquisaDW = new Panel();
    this.radioParqueDW = new RadioButton();
    this.radioServicoDW = new RadioButton();
    this.radioMovimentoDW = new RadioButton();
    this.campoPesquisaRegistrosDW = new TextBox();
    this.comboConsultaDWMovel = new ComboBox();
    this.panel1 = new Panel();
    this.btnConsultaDWMovel = new Button();
    this.tabPage2 = new TabPage();
    this.groupBox7 = new GroupBox();
    this.checkedListBox1 = new CheckedListBox();
    this.label8 = new Label();
    this.groupBox6 = new GroupBox();
    this.panel3 = new Panel();
    this.comboTipoPesquisa = new ComboBox();
    this.textCampoPesquisaCarteira = new TextBox();
    this.panel4 = new Panel();
    this.btnConsultaCarteira = new Button();
    this.dtgConsultaDW = new DataGridView();
    this.toolStrip1 = new ToolStrip();
    this.backgroundWorker1 = new BackgroundWorker();
    this.contextMenuStrip1 = new ContextMenuStrip(this.components);
    this.menuExportarSQL = new ToolStripMenuItem();
    this.menuCopiarResultado = new ToolStripMenuItem();
    this.tabControlConsultaDW.SuspendLayout();
    this.tabPage1.SuspendLayout();
    this.groupBox5.SuspendLayout();
    this.groupBox4.SuspendLayout();
    this.groupBox3.SuspendLayout();
    this.groupBox2.SuspendLayout();
    this.panel2.SuspendLayout();
    this.groupBox1.SuspendLayout();
    this.painelTipoPesquisaDW.SuspendLayout();
    this.panel1.SuspendLayout();
    this.tabPage2.SuspendLayout();
    this.groupBox7.SuspendLayout();
    this.groupBox6.SuspendLayout();
    this.panel4.SuspendLayout();
    ((ISupportInitialize) this.dtgConsultaDW).BeginInit();
    this.contextMenuStrip1.SuspendLayout();
    this.SuspendLayout();
    this.tabControlConsultaDW.Controls.Add((Control) this.tabPage1);
    this.tabControlConsultaDW.Controls.Add((Control) this.tabPage2);
    this.tabControlConsultaDW.Location = new Point(1, 25);
    this.tabControlConsultaDW.Name = "tabControlConsultaDW";
    this.tabControlConsultaDW.SelectedIndex = 0;
    this.tabControlConsultaDW.Size = new Size(1249, 131);
    this.tabControlConsultaDW.TabIndex = 0;
    this.tabPage1.Controls.Add((Control) this.groupBox5);
    this.tabPage1.Controls.Add((Control) this.groupBox4);
    this.tabPage1.Controls.Add((Control) this.groupBox3);
    this.tabPage1.Controls.Add((Control) this.groupBox2);
    this.tabPage1.Controls.Add((Control) this.groupBox1);
    this.tabPage1.Controls.Add((Control) this.panel1);
    this.tabPage1.Location = new Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new Padding(3);
    this.tabPage1.RightToLeft = RightToLeft.No;
    this.tabPage1.Size = new Size(1241, 105);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "Teradata Móvel";
    this.tabPage1.UseVisualStyleBackColor = true;
    this.groupBox5.Controls.Add((Control) this.textPesquisarNoGrid1);
    this.groupBox5.Controls.Add((Control) this.label5);
    this.groupBox5.Controls.Add((Control) this.label6);
    this.groupBox5.Location = new Point(1095, 6);
    this.groupBox5.Name = "groupBox5";
    this.groupBox5.Size = new Size(139, 93);
    this.groupBox5.TabIndex = 7;
    this.groupBox5.TabStop = false;
    this.groupBox5.Text = "Filtrar";
    this.textPesquisarNoGrid1.Location = new Point(9, 65);
    this.textPesquisarNoGrid1.Name = "textPesquisarNoGrid1";
    this.textPesquisarNoGrid1.Size = new Size(124, 20);
    this.textPesquisarNoGrid1.TabIndex = 14;
    this.textPesquisarNoGrid1.TextChanged += new EventHandler(this.textPesquisarNoGrid1_TextChanged);
    this.label5.AutoSize = true;
    this.label5.Location = new Point(18, 19);
    this.label5.Name = "label5";
    this.label5.Size = new Size(100, 13);
    this.label5.TabIndex = 13;
    this.label5.Text = "Campo selecionado";
    this.label6.AutoSize = true;
    this.label6.Enabled = false;
    this.label6.ForeColor = SystemColors.ControlDarkDark;
    this.label6.Location = new Point(18, 41);
    this.label6.Name = "label6";
    this.label6.Size = new Size(47, 13);
    this.label6.TabIndex = 12;
    this.label6.Text = "Nenhum";
    this.label6.TextAlign = ContentAlignment.MiddleCenter;
    this.groupBox4.Controls.Add((Control) this.checkPortabilidade);
    this.groupBox4.Location = new Point(807, 6);
    this.groupBox4.Name = "groupBox4";
    this.groupBox4.Size = new Size(139, 93);
    this.groupBox4.TabIndex = 6;
    this.groupBox4.TabStop = false;
    this.groupBox4.Text = "Visualizar";
    this.checkPortabilidade.AutoSize = true;
    this.checkPortabilidade.Location = new Point(6, 20);
    this.checkPortabilidade.Name = "checkPortabilidade";
    this.checkPortabilidade.Size = new Size(87, 17);
    this.checkPortabilidade.TabIndex = 4;
    this.checkPortabilidade.Text = "Portabilidade";
    this.checkPortabilidade.UseVisualStyleBackColor = true;
    this.checkPortabilidade.CheckedChanged += new EventHandler(this.checkPortabilidade_CheckedChanged);
    this.groupBox3.Controls.Add((Control) this.label2);
    this.groupBox3.Controls.Add((Control) this.textSenhaTeradata);
    this.groupBox3.Controls.Add((Control) this.label1);
    this.groupBox3.Controls.Add((Control) this.textUsuarioTeradata);
    this.groupBox3.Location = new Point(950, 6);
    this.groupBox3.Name = "groupBox3";
    this.groupBox3.Size = new Size(139, 93);
    this.groupBox3.TabIndex = 5;
    this.groupBox3.TabStop = false;
    this.groupBox3.Text = "Login Teradata";
    this.label2.AutoSize = true;
    this.label2.Location = new Point(4, 68);
    this.label2.Name = "label2";
    this.label2.Size = new Size(38, 13);
    this.label2.TabIndex = 10;
    this.label2.Text = "Senha";
    this.label2.Click += new EventHandler(this.label2_Click);
    this.textSenhaTeradata.Location = new Point(56, 65);
    this.textSenhaTeradata.MaxLength = 30;
    this.textSenhaTeradata.Name = "textSenhaTeradata";
    this.textSenhaTeradata.Size = new Size(74, 20);
    this.textSenhaTeradata.TabIndex = 9;
    this.textSenhaTeradata.UseSystemPasswordChar = true;
    this.label1.AutoSize = true;
    this.label1.Location = new Point(4, 41);
    this.label1.Name = "label1";
    this.label1.Size = new Size(43, 13);
    this.label1.TabIndex = 8;
    this.label1.Text = "Usuário";
    this.textUsuarioTeradata.CharacterCasing = CharacterCasing.Upper;
    this.textUsuarioTeradata.Location = new Point(56, 38);
    this.textUsuarioTeradata.MaxLength = 30;
    this.textUsuarioTeradata.Name = "textUsuarioTeradata";
    this.textUsuarioTeradata.Size = new Size(74, 20);
    this.textUsuarioTeradata.TabIndex = 0;
    this.groupBox2.Controls.Add((Control) this.panel2);
    this.groupBox2.Controls.Add((Control) this.dataFinal);
    this.groupBox2.Controls.Add((Control) this.label4);
    this.groupBox2.Controls.Add((Control) this.label3);
    this.groupBox2.Controls.Add((Control) this.dataInicial);
    this.groupBox2.Location = new Point(463, 6);
    this.groupBox2.Name = "groupBox2";
    this.groupBox2.Size = new Size(340, 93);
    this.groupBox2.TabIndex = 4;
    this.groupBox2.TabStop = false;
    this.groupBox2.Text = "Filtros";
    this.panel2.Controls.Add((Control) this.checkCarteiraB2B);
    this.panel2.Controls.Add((Control) this.checkParqueAtivo);
    this.panel2.Controls.Add((Control) this.checkAltasBaixas);
    this.panel2.Location = new Point(9, 44);
    this.panel2.Name = "panel2";
    this.panel2.Size = new Size(325, 43);
    this.panel2.TabIndex = 7;
    this.checkCarteiraB2B.AutoSize = true;
    this.checkCarteiraB2B.Checked = true;
    this.checkCarteiraB2B.CheckState = CheckState.Checked;
    this.checkCarteiraB2B.Location = new Point(3, 3);
    this.checkCarteiraB2B.Name = "checkCarteiraB2B";
    this.checkCarteiraB2B.Size = new Size(77, 17);
    this.checkCarteiraB2B.TabIndex = 2;
    this.checkCarteiraB2B.Text = "Carteira PJ";
    this.checkCarteiraB2B.UseVisualStyleBackColor = true;
    this.checkParqueAtivo.AutoSize = true;
    this.checkParqueAtivo.Checked = true;
    this.checkParqueAtivo.CheckState = CheckState.Checked;
    this.checkParqueAtivo.Location = new Point(3, 23);
    this.checkParqueAtivo.Name = "checkParqueAtivo";
    this.checkParqueAtivo.Size = new Size(86, 17);
    this.checkParqueAtivo.TabIndex = 1;
    this.checkParqueAtivo.Text = "Parque ativo";
    this.checkParqueAtivo.UseVisualStyleBackColor = true;
    this.checkAltasBaixas.AutoSize = true;
    this.checkAltasBaixas.Checked = true;
    this.checkAltasBaixas.CheckState = CheckState.Checked;
    this.checkAltasBaixas.Location = new Point(94, 3);
    this.checkAltasBaixas.Name = "checkAltasBaixas";
    this.checkAltasBaixas.Size = new Size(91, 17);
    this.checkAltasBaixas.TabIndex = 0;
    this.checkAltasBaixas.Text = "Altas e baixas";
    this.checkAltasBaixas.UseVisualStyleBackColor = true;
    this.dataFinal.Format = DateTimePickerFormat.Short;
    this.dataFinal.Location = new Point(228, 15);
    this.dataFinal.Name = "dataFinal";
    this.dataFinal.Size = new Size(96 /*0x60*/, 20);
    this.dataFinal.TabIndex = 6;
    this.label4.AutoSize = true;
    this.label4.Location = new Point(171, 19);
    this.label4.Name = "label4";
    this.label4.Size = new Size(52, 13);
    this.label4.TabIndex = 5;
    this.label4.Text = "Data final";
    this.label3.AutoSize = true;
    this.label3.Location = new Point(6, 19);
    this.label3.Name = "label3";
    this.label3.Size = new Size(59, 13);
    this.label3.TabIndex = 4;
    this.label3.Text = "Data inicial";
    this.dataInicial.Format = DateTimePickerFormat.Short;
    this.dataInicial.Location = new Point(70, 15);
    this.dataInicial.Name = "dataInicial";
    this.dataInicial.Size = new Size(96 /*0x60*/, 20);
    this.dataInicial.TabIndex = 3;
    this.groupBox1.Controls.Add((Control) this.painelTipoPesquisaDW);
    this.groupBox1.Controls.Add((Control) this.campoPesquisaRegistrosDW);
    this.groupBox1.Controls.Add((Control) this.comboConsultaDWMovel);
    this.groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.groupBox1.Location = new Point(82, 6);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(377, 93);
    this.groupBox1.TabIndex = 3;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Campo de pesquisa";
    this.painelTipoPesquisaDW.Controls.Add((Control) this.radioParqueDW);
    this.painelTipoPesquisaDW.Controls.Add((Control) this.radioServicoDW);
    this.painelTipoPesquisaDW.Controls.Add((Control) this.radioMovimentoDW);
    this.painelTipoPesquisaDW.Location = new Point(200, 38);
    this.painelTipoPesquisaDW.Name = "painelTipoPesquisaDW";
    this.painelTipoPesquisaDW.Size = new Size(170, 52);
    this.painelTipoPesquisaDW.TabIndex = 7;
    this.painelTipoPesquisaDW.Paint += new PaintEventHandler(this.painelTipoPesquisaDW_Paint);
    this.radioParqueDW.AutoSize = true;
    this.radioParqueDW.Location = new Point(87, 6);
    this.radioParqueDW.Name = "radioParqueDW";
    this.radioParqueDW.Size = new Size(59, 17);
    this.radioParqueDW.TabIndex = 2;
    this.radioParqueDW.Text = "Parque";
    this.radioParqueDW.UseVisualStyleBackColor = true;
    this.radioParqueDW.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
    this.radioServicoDW.AutoSize = true;
    this.radioServicoDW.Location = new Point(4, 29);
    this.radioServicoDW.Name = "radioServicoDW";
    this.radioServicoDW.Size = new Size(61, 17);
    this.radioServicoDW.TabIndex = 1;
    this.radioServicoDW.Text = "Serviço";
    this.radioServicoDW.UseVisualStyleBackColor = true;
    this.radioMovimentoDW.AutoSize = true;
    this.radioMovimentoDW.Checked = true;
    this.radioMovimentoDW.Location = new Point(4, 6);
    this.radioMovimentoDW.Name = "radioMovimentoDW";
    this.radioMovimentoDW.Size = new Size(77, 17);
    this.radioMovimentoDW.TabIndex = 0;
    this.radioMovimentoDW.TabStop = true;
    this.radioMovimentoDW.Text = "Movimento";
    this.radioMovimentoDW.UseVisualStyleBackColor = true;
    this.campoPesquisaRegistrosDW.Location = new Point(6, 16 /*0x10*/);
    this.campoPesquisaRegistrosDW.Multiline = true;
    this.campoPesquisaRegistrosDW.Name = "campoPesquisaRegistrosDW";
    this.campoPesquisaRegistrosDW.ScrollBars = ScrollBars.Vertical;
    this.campoPesquisaRegistrosDW.Size = new Size(188, 71);
    this.campoPesquisaRegistrosDW.TabIndex = 1;
    this.campoPesquisaRegistrosDW.TextChanged += new EventHandler(this.campoPesquisaRegistrosDW_TextChanged);
    this.comboConsultaDWMovel.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboConsultaDWMovel.FormattingEnabled = true;
    this.comboConsultaDWMovel.Items.AddRange(new object[8]
    {
      (object) "Núm. telefones",
      (object) "Atendente (Adabas)",
      (object) "Ponto de venda",
      (object) "CNPJ ou CPF",
      (object) "Cod.Cli.",
      (object) "Nome do cliente",
      (object) "Service Desc",
      (object) "Service Name"
    });
    this.comboConsultaDWMovel.Location = new Point(200, 16 /*0x10*/);
    this.comboConsultaDWMovel.Name = "comboConsultaDWMovel";
    this.comboConsultaDWMovel.Size = new Size(170, 21);
    this.comboConsultaDWMovel.TabIndex = 2;
    this.panel1.Controls.Add((Control) this.btnConsultaDWMovel);
    this.panel1.Location = new Point(7, 6);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(74, 93);
    this.panel1.TabIndex = 0;
    this.btnConsultaDWMovel.Location = new Point(4, 16 /*0x10*/);
    this.btnConsultaDWMovel.Name = "btnConsultaDWMovel";
    this.btnConsultaDWMovel.Size = new Size(65, 71);
    this.btnConsultaDWMovel.TabIndex = 0;
    this.btnConsultaDWMovel.Text = "Pesquisar (F5)";
    this.btnConsultaDWMovel.UseVisualStyleBackColor = true;
    this.btnConsultaDWMovel.Click += new EventHandler(this.btnConsultaDWMovel_Click);
    this.tabPage2.Controls.Add((Control) this.groupBox7);
    this.tabPage2.Controls.Add((Control) this.groupBox6);
    this.tabPage2.Controls.Add((Control) this.panel4);
    this.tabPage2.Location = new Point(4, 22);
    this.tabPage2.Name = "tabPage2";
    this.tabPage2.Size = new Size(1241, 105);
    this.tabPage2.TabIndex = 1;
    this.tabPage2.Text = "Carteira comercial";
    this.tabPage2.UseVisualStyleBackColor = true;
    this.groupBox7.Controls.Add((Control) this.checkedListBox1);
    this.groupBox7.Controls.Add((Control) this.label8);
    this.groupBox7.Location = new Point(463, 6);
    this.groupBox7.Name = "groupBox7";
    this.groupBox7.Size = new Size(340, 93);
    this.groupBox7.TabIndex = 6;
    this.groupBox7.TabStop = false;
    this.groupBox7.Text = "Filtros";
    this.checkedListBox1.FormattingEnabled = true;
    this.checkedListBox1.Items.AddRange(new object[4]
    {
      (object) "Item 1",
      (object) "item 2",
      (object) "Item 3",
      (object) "Item 4"
    });
    this.checkedListBox1.Location = new Point(81, 16 /*0x10*/);
    this.checkedListBox1.Name = "checkedListBox1";
    this.checkedListBox1.ScrollAlwaysVisible = true;
    this.checkedListBox1.Size = new Size(142, 64 /*0x40*/);
    this.checkedListBox1.TabIndex = 8;
    this.label8.AutoSize = true;
    this.label8.Location = new Point(6, 19);
    this.label8.Name = "label8";
    this.label8.Size = new Size(59, 13);
    this.label8.TabIndex = 4;
    this.label8.Text = "Data inicial";
    this.groupBox6.Controls.Add((Control) this.panel3);
    this.groupBox6.Controls.Add((Control) this.comboTipoPesquisa);
    this.groupBox6.Controls.Add((Control) this.textCampoPesquisaCarteira);
    this.groupBox6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.groupBox6.Location = new Point(82, 6);
    this.groupBox6.Name = "groupBox6";
    this.groupBox6.Size = new Size(377, 93);
    this.groupBox6.TabIndex = 5;
    this.groupBox6.TabStop = false;
    this.groupBox6.Text = "Campo de pesquisa";
    this.panel3.Location = new Point(200, 38);
    this.panel3.Name = "panel3";
    this.panel3.Size = new Size(170, 52);
    this.panel3.TabIndex = 8;
    this.comboTipoPesquisa.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboTipoPesquisa.FormattingEnabled = true;
    this.comboTipoPesquisa.Items.AddRange(new object[4]
    {
      (object) "Adabas",
      (object) "CNPJ ou CPF",
      (object) "Cod.Cli.",
      (object) "Nome do cliente"
    });
    this.comboTipoPesquisa.Location = new Point(200, 16 /*0x10*/);
    this.comboTipoPesquisa.Name = "comboTipoPesquisa";
    this.comboTipoPesquisa.Size = new Size(170, 21);
    this.comboTipoPesquisa.TabIndex = 3;
    this.textCampoPesquisaCarteira.Location = new Point(6, 16 /*0x10*/);
    this.textCampoPesquisaCarteira.Multiline = true;
    this.textCampoPesquisaCarteira.Name = "textCampoPesquisaCarteira";
    this.textCampoPesquisaCarteira.ScrollBars = ScrollBars.Vertical;
    this.textCampoPesquisaCarteira.Size = new Size(188, 71);
    this.textCampoPesquisaCarteira.TabIndex = 1;
    this.panel4.Controls.Add((Control) this.btnConsultaCarteira);
    this.panel4.Location = new Point(7, 6);
    this.panel4.Name = "panel4";
    this.panel4.Size = new Size(74, 93);
    this.panel4.TabIndex = 4;
    this.btnConsultaCarteira.Location = new Point(4, 16 /*0x10*/);
    this.btnConsultaCarteira.Name = "btnConsultaCarteira";
    this.btnConsultaCarteira.Size = new Size(65, 71);
    this.btnConsultaCarteira.TabIndex = 0;
    this.btnConsultaCarteira.Text = "Pesquisar (F5)";
    this.btnConsultaCarteira.UseVisualStyleBackColor = true;
    this.dtgConsultaDW.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.dtgConsultaDW.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    this.dtgConsultaDW.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dtgConsultaDW.Location = new Point(1, 156);
    this.dtgConsultaDW.Name = "dtgConsultaDW";
    this.dtgConsultaDW.RowHeadersVisible = false;
    this.dtgConsultaDW.Size = new Size(1249, 276);
    this.dtgConsultaDW.TabIndex = 1;
    this.dtgConsultaDW.CellClick += new DataGridViewCellEventHandler(this.dtgConsultaDW_CellClick);
    this.dtgConsultaDW.CellContentClick += new DataGridViewCellEventHandler(this.dtgConsultaDW_CellContentClick);
    this.dtgConsultaDW.SelectionChanged += new EventHandler(this.dtgConsultaDW_SelectionChanged);
    this.dtgConsultaDW.MouseClick += new MouseEventHandler(this.dtgConsultaDW_MouseClick);
    this.toolStrip1.Location = new Point(0, 0);
    this.toolStrip1.Name = "toolStrip1";
    this.toolStrip1.Size = new Size(1250, 25);
    this.toolStrip1.TabIndex = 2;
    this.toolStrip1.Text = "toolStrip1";
    this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
    this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
    this.contextMenuStrip1.Items.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.menuExportarSQL,
      (ToolStripItem) this.menuCopiarResultado
    });
    this.contextMenuStrip1.Name = "contextMenuStrip1";
    this.contextMenuStrip1.Size = new Size(226, 48 /*0x30*/);
    this.menuExportarSQL.Name = "menuExportarSQL";
    this.menuExportarSQL.Size = new Size(225, 22);
    this.menuExportarSQL.Text = "Copiar script SQL";
    this.menuExportarSQL.Click += new EventHandler(this.menuExportarSQL_Click);
    this.menuCopiarResultado.Name = "menuCopiarResultado";
    this.menuCopiarResultado.Size = new Size(225, 22);
    this.menuCopiarResultado.Text = "Copiar resultado da consulta";
    this.menuCopiarResultado.Click += new EventHandler(this.menuCopiarResultado_Click);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.AutoSize = true;
    this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    this.ClientSize = new Size(1250, 434);
    this.Controls.Add((Control) this.toolStrip1);
    this.Controls.Add((Control) this.dtgConsultaDW);
    this.Controls.Add((Control) this.tabControlConsultaDW);
    this.Name = "formDWTeradata";
    this.ShowIcon = false;
    this.Text = "Consultas DW Teradata";
    this.Load += new EventHandler(this.formDWTeradata_Load);
    this.tabControlConsultaDW.ResumeLayout(false);
    this.tabPage1.ResumeLayout(false);
    this.groupBox5.ResumeLayout(false);
    this.groupBox5.PerformLayout();
    this.groupBox4.ResumeLayout(false);
    this.groupBox4.PerformLayout();
    this.groupBox3.ResumeLayout(false);
    this.groupBox3.PerformLayout();
    this.groupBox2.ResumeLayout(false);
    this.groupBox2.PerformLayout();
    this.panel2.ResumeLayout(false);
    this.panel2.PerformLayout();
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.painelTipoPesquisaDW.ResumeLayout(false);
    this.painelTipoPesquisaDW.PerformLayout();
    this.panel1.ResumeLayout(false);
    this.tabPage2.ResumeLayout(false);
    this.groupBox7.ResumeLayout(false);
    this.groupBox7.PerformLayout();
    this.groupBox6.ResumeLayout(false);
    this.groupBox6.PerformLayout();
    this.panel4.ResumeLayout(false);
    ((ISupportInitialize) this.dtgConsultaDW).EndInit();
    this.contextMenuStrip1.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
