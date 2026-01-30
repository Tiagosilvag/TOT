// Decompiled with JetBrains decompiler
// Type: TOT.BLL
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using DocumentFormat.OpenXml.Packaging;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Teradata.Client.Provider;

#nullable disable
namespace TOT;

internal class BLL
{
  public static string SQLParaAreaDeTransferencia = "";
  public static string celulaAtual = "";
  public static bool hignorarHistorico = false;
  public static readonly Color CorVermelha = Color.OrangeRed;
  public static readonly Color CorAmarela = Color.Gold;
  public static readonly Color CorLaranja = Color.Orange;
  public static readonly Color CorAmareloClaro = Color.LightGoldenrodYellow;
  public static readonly Color CorVerde = Color.GreenYellow;
  public static readonly Color CorTransparente = Color.Empty;
  public static readonly Color CorAzul = Color.Blue;
  public static readonly Color CorBranca = Color.White;
  public static readonly Color CorCinzaClaro = Color.LightGray;
  public static readonly Color CorVivoOficial = Color.BlueViolet;
  public static string sql;
  public static int controleforms;
  public static string rowid;
  public static string[] dadosEdicaoTabela;
  public static string valorAnterior;
  public static string valorNovo;
  public static DataTable conexoes;
  public static DataTable dataTableTemp;
  public static bool enviarInformativo;
  private static string _textozoom;

  public static string Sql
  {
    set => BLL.sql = value;
    get => BLL.sql;
  }

  public static int controleForms
  {
    set => BLL.controleforms = value;
    get => BLL.controleforms;
  }

  public static string RowId
  {
    set => BLL.rowid = value;
    get => BLL.rowid;
  }

  public static string[] DadosEdicaoTabela
  {
    set => BLL.dadosEdicaoTabela = value;
    get => BLL.dadosEdicaoTabela;
  }

  public static string ValorAnterior
  {
    set => BLL.valorAnterior = value;
    get => BLL.valorAnterior;
  }

  public static string ValorNovo
  {
    set => BLL.valorNovo = value;
    get => BLL.valorNovo;
  }

  public static DataTable Conexoes
  {
    set => BLL.conexoes = value;
    get => BLL.conexoes;
  }

  public static DataTable DataTableTemp
  {
    set => BLL.dataTableTemp = value;
    get => BLL.dataTableTemp;
  }

  public static bool EnviarInformativo
  {
    set => BLL.enviarInformativo = value;
    get => BLL.enviarInformativo;
  }

  public static string _textoZoom
  {
    set => BLL._textozoom = value;
    get => BLL._textozoom;
  }

  public static void copiarParaAreaDeTransferencia(string texto)
  {
    try
    {
      Clipboard.SetText(texto);
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar conteúdo para a Área de Transferência do seu computador.", ex.Message);
    }
  }

  public static void AdicionarTextoAoArquivo(string caminhoArquivo, string texto)
  {
    using (StreamWriter streamWriter = File.AppendText(caminhoArquivo))
    {
      DateTime now = DateTime.Now;
      streamWriter.WriteLine($"{now.ToShortTimeString()}: {texto}\n");
    }
  }

  public static bool ehNunero(string valor) => int.TryParse(valor, out int _);

  public static void popularCombo(
    ComboBox combo,
    string SQL,
    string campoVisual,
    string campoValor)
  {
    combo.DataSource = (object) DAL.PegarDadosTOT(SQL);
    combo.DisplayMember = campoVisual;
    combo.ValueMember = campoValor;
  }

  public static bool validarUsuario(string loginRede)
  {
    try
    {
      using (DataTable dataTable = DAL.PegarDadosTOT($"SELECT ID_USUARIO,ID_PERFIL,FL_ATIVO,CD_LOGIN_REDE FROM GVDW_OWNER.RV_B2B_USUARIOS_APP WHERE UPPER(CD_LOGIN_REDE) = '{loginRede.ToUpper()}' AND FL_ATIVO = 1 "))
        return dataTable.Rows.Count >= 1;
    }
    catch (Exception ex)
    {
      throw new Exception("Erro ao executar SQL no banco Oracle. " + ex.Message);
    }
  }

  public static string emailUsuario(string loginRede)
  {
    try
    {
      using (DataTable dataTable = DAL.PegarDadosTOT($"SELECT ID_USUARIO,ID_PERFIL,FL_ATIVO,CD_LOGIN_REDE, EMAIL FROM GVDW_OWNER.RV_B2B_USUARIOS_APP WHERE UPPER(CD_LOGIN_REDE) = '{loginRede.ToUpper()}' AND FL_ATIVO = 1 "))
        return dataTable.Rows.Count < 1 ? "" : dataTable.Rows[0].ItemArray[4].ToString();
    }
    catch (Exception ex)
    {
      throw new Exception("Erro ao executar SQL no banco Oracle. " + ex.Message);
    }
  }

  public static void popularTreeview(
    TreeView tv,
    string consulta,
    string noFilho,
    string noPai = "",
    string campoToolTipText = "",
    string campoTag = "",
    string campoText = "",
    bool naoExpandir = false,
    int nivel = 0)
  {
    using (DataTable dataTable = DAL.PegarDadosTOT(consulta))
    {
      string columnName1 = campoToolTipText;
      string columnName2 = campoTag;
      string columnName3 = campoText;
      string str = noPai;
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        if (!string.IsNullOrWhiteSpace(campoToolTipText))
          campoToolTipText = row[columnName1].ToString();
        if (!string.IsNullOrWhiteSpace(campoTag))
          campoTag = row[columnName2].ToString();
        if (!string.IsNullOrWhiteSpace(campoText))
          campoText = row[columnName3].ToString();
        if (!string.IsNullOrWhiteSpace(noPai))
          str = row[noPai].ToString();
        TreeNode node1 = new TreeNode(row[noFilho].ToString());
        node1.Name = row[noFilho].ToString();
        node1.ToolTipText = campoToolTipText;
        node1.Tag = (object) campoTag;
        node1.Text = campoText;
        if (string.IsNullOrWhiteSpace(noPai))
        {
          tv.Nodes.Add(node1);
        }
        else
        {
          if (nivel.Equals(0))
          {
            foreach (TreeNode node2 in tv.Nodes)
            {
              if (node2.Text.Equals(str))
                node2.Nodes.Add(node1);
            }
          }
          if (nivel.Equals(2))
          {
            foreach (TreeNode node3 in tv.Nodes)
            {
              foreach (TreeNode node4 in node3.Nodes)
              {
                if (node4.Text.Equals(str, StringComparison.OrdinalIgnoreCase) && node4.Parent.Text.Equals(campoTag, StringComparison.OrdinalIgnoreCase))
                  node4.Nodes.Add(node1);
              }
            }
          }
        }
      }
    }
    if (tv.Nodes.Count <= 0)
      return;
    tv.Nodes[0].Expand();
  }

  public static TreeNode FindNode(string name, TreeNode root)
  {
    if (root.Name == name)
      return root;
    Stack<TreeNode> treeNodeStack = new Stack<TreeNode>();
    treeNodeStack.Push(root);
    while (treeNodeStack.Count > 0)
    {
      foreach (TreeNode node in treeNodeStack.Pop().Nodes)
      {
        if (node.Name == name)
          return node;
        treeNodeStack.Push(node);
      }
    }
    return (TreeNode) null;
  }

  public static void NoTreeView(TreeView tv, string textoProcurado)
  {
    TreeNode selectedNode = tv.SelectedNode;
    if (selectedNode.Nodes.Count <= 0)
      return;
    for (int index = 0; index < selectedNode.Nodes.Count; ++index)
    {
      selectedNode.TreeView.SelectedNode = selectedNode.Nodes[index];
      if (selectedNode.Nodes[index].Text.ToLower().IndexOf(textoProcurado.ToLower()) > -1)
      {
        selectedNode.Expand();
        break;
      }
    }
  }

  public static void erro(string erroPersonalizado, string erroSistema = "")
  {
    try
    {
      int num = (int) MessageBox.Show($"{erroPersonalizado}{Environment.NewLine}Código do erro: {erroSistema}", "TOT - Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show($"Erro ao tentar exibir a descrição do erro tratado{Environment.NewLine}Código do erro secundário: {ex.Message}", "TOT - Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  public void EstiloDataGrid(DataGridView dgv)
  {
    dgv.AllowUserToAddRows = false;
    dgv.AllowUserToOrderColumns = false;
    dgv.AllowUserToDeleteRows = false;
    dgv.AlternatingRowsDefaultCellStyle.BackColor = BLL.CorAmareloClaro;
    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    dgv.BorderStyle = BorderStyle.None;
    dgv.ColumnHeadersDefaultCellStyle.Font = new Font(Control.DefaultFont, FontStyle.Bold);
    dgv.ReadOnly = true;
    dgv.RowHeadersVisible = false;
  }

  public void EstiloTreeView(TreeView tvw)
  {
    tvw.BorderStyle = BorderStyle.None;
    tvw.Scrollable = true;
  }

  public void EstiloTabControl(TabControl tab)
  {
  }

  public static string lerArquivoTexto(string arquivo, bool escrever = false, string texto = null)
  {
    try
    {
      if (!escrever)
        return File.ReadAllText(arquivo);
      File.WriteAllText(arquivo, texto);
      return (string) null;
    }
    catch (Exception ex)
    {
      return ex.Data.Count.ToString();
    }
  }

  public static Color corStatusDataPrevReal(DateTime dataPrevista, DateTime dataRealizada)
  {
    Color corBranca = BLL.CorBranca;
    return !(DateTime.Today > dataPrevista) ? BLL.CorAmarela : BLL.CorVermelha;
  }

  public static bool checkForSQLInjection(string userInput)
  {
    bool flag = false;
    string[] strArray = new string[32 /*0x20*/]
    {
      "--",
      ";--",
      ";",
      "/*",
      "*/",
      "@@",
      "@",
      " char",
      "nchar",
      "varchar",
      "nvarchar",
      "alter ",
      "begin",
      "cast ",
      "create ",
      "cursor ",
      "declare ",
      "delete ",
      "drop ",
      " end",
      "end ",
      "exec ",
      "execute",
      "fetch",
      "insert",
      "kill",
      "select",
      "sys",
      "sysobjects",
      "syscolumns",
      "table",
      "update"
    };
    string str = userInput.Replace("'", "''");
    for (int index = 0; index <= strArray.Length - 1; ++index)
    {
      if (str.IndexOf(strArray[index], StringComparison.OrdinalIgnoreCase) >= 0)
        flag = true;
    }
    return flag;
  }

  public static string[] PegarConnectionStringCompleta(string banco)
  {
    int count = BLL.conexoes.Rows.Count;
    if (string.IsNullOrEmpty(banco))
      banco = "pdw1";
    string[] strArray = new string[2];
    if (count > 0)
    {
      for (int index = 0; index < count; ++index)
      {
        if (banco.Equals(BLL.conexoes.Rows[index][0].ToString(), StringComparison.OrdinalIgnoreCase))
        {
          strArray[0] = $"{BLL.conexoes.Rows[index][3].ToString()}User id={BLL.conexoes.Rows[index][4].ToString()};Password={BLL.conexoes.Rows[index][5].ToString()};";
          strArray[1] = BLL.conexoes.Rows[index][2].ToString();
        }
      }
    }
    return strArray;
  }

  public static bool TestarConexãoBanco(string banco)
  {
    string[] strArray = BLL.PegarConnectionStringCompleta(banco);
    try
    {
      switch (strArray[1])
      {
        case "1":
          using (OracleConnection oracleConnection = new OracleConnection(strArray[0]))
          {
            oracleConnection.Open();
            return oracleConnection.State.Equals((object) ConnectionState.Open);
          }
        case "2":
          using (SqlConnection sqlConnection = new SqlConnection(strArray[0]))
          {
            sqlConnection.Open();
            return sqlConnection.State.Equals((object) ConnectionState.Open);
          }
        case "3":
          try
          {
            TdConnection tdConnection = new TdConnection();
            ((DbConnection) tdConnection).ConnectionString = strArray[0];
            ((DbConnection) tdConnection).Open();
            return ((DbConnection) tdConnection).State.Equals((object) ConnectionState.Open);
          }
          catch (TdException ex)
          {
            Console.Write(((Exception) ex).Message);
            return false;
          }
        default:
          return false;
      }
    }
    catch (Exception ex)
    {
      Console.Write(ex.Message);
      return false;
    }
  }

  public static bool validarVersao()
  {
    try
    {
      using (DataTable dataTable = DAL.PegarDadosTOT($"SELECT ID_VERSAO_APP,CD_VERSAO,FL_VERSAO FROM GVDW_OWNER.RV_B2B_VERSAO_APP WHERE CD_VERSAO = '{System.Windows.Forms.Application.ProductVersion}'AND FL_VERSAO = 1 "))
        return dataTable.Rows.Count >= 1;
    }
    catch (OracleException ex)
    {
      Console.Write(ex.Message);
      return false;
    }
  }

  public static DataTable popularGridFiltros2(DataGridView dgv)
  {
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("CAMPO", typeof (string));
    dataTable.Columns.Add("OPERADOR", typeof (string));
    dataTable.Columns.Add("VALOR", typeof (string));
    dataTable.Columns.Add(" ", typeof (bool));
    for (int index = 0; index < dgv.Columns.Count; ++index)
    {
      DataRow row = dataTable.NewRow();
      row["CAMPO"] = (object) dgv.Columns[index].Name.ToString();
      row["OPERADOR"] = (object) null;
      row["VALOR"] = (object) null;
      row[" "] = (object) true;
      dataTable.Rows.Add(row);
    }
    return dataTable;
  }

  public static DataTable popularGridFiltros(string tabela, string banco)
  {
    try
    {
      DataTable dataTable1 = new DataTable();
      string consulta = "";
      string[] strArray = DAL.PegarConnectionString(banco);
      string[] source = tabela.Split('.');
      int index = ((IEnumerable<string>) source).Count<string>() - 1;
      if (strArray[1].Equals("1"))
        consulta = $"SELECT column_name CAMPO, null OPERADOR, null VALOR FROM all_tab_cols WHERE table_name = '{source[index]}' AND owner = '{strArray[2]}' ORDER BY COLUMN_ID ASC ";
      else if (strArray[1].Equals("2"))
        consulta = $"SELECT column_name CAMPO, '' OPERADOR, '' VALOR FROM {strArray[3]}[{strArray[2]}].[information_schema].[columns] WHERE table_name = '{source[index]}' AND table_catalog = '{strArray[2]}' ORDER BY ordinal_position ASC ";
      else if (strArray[1].Equals("3"))
        consulta = $"SELECT TRIM(columnname) CAMPO, '' OPERADOR, '' VALOR FROM dbc.columns WHERE tablename = '{source[index]}' AND databasename = '{strArray[2]}' ORDER BY COLUMNID ASC ";
      else if (strArray[1].Equals("4"))
        consulta = "";
      DataTable dataTable2 = DAL.PegarDadosBancos(banco, consulta);
      dataTable2.Columns.Add(" ", typeof (bool));
      return dataTable2;
    }
    catch (Exception ex)
    {
      Console.Write(ex.Message);
      return (DataTable) null;
    }
  }

  public static void exportarResultado(string delimitador, DataTable dg)
  {
    try
    {
      using (SaveFileDialog saveFileDialog = new SaveFileDialog())
      {
        saveFileDialog.Filter = "Exportação dados TOT (*.csv)|*.csv";
        saveFileDialog.Title = "TOT - Salvar meus filtros para a tabela " + DAL._tabelaAtual;
        saveFileDialog.FileName = $"{DAL._tabelaAtual} [{DateTime.Now.ToString("yyyy-MM-dd")}]";
        int num = (int) saveFileDialog.ShowDialog();
        StreamWriter streamWriter = new StreamWriter((Stream) new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8);
        for (int index = 0; index < dg.Columns.Count; ++index)
        {
          streamWriter.Write(dg.Columns[index].ColumnName.ToString());
          if (index != dg.Columns.Count)
            streamWriter.Write(delimitador);
        }
        streamWriter.Write(streamWriter.NewLine);
        foreach (DataRow row in (InternalDataCollectionBase) dg.Rows)
        {
          for (int columnIndex = 0; columnIndex < dg.Columns.Count; ++columnIndex)
          {
            streamWriter.Write(row[columnIndex].ToString());
            if (columnIndex != dg.Columns.Count)
              streamWriter.Write(delimitador);
          }
          streamWriter.Write(streamWriter.NewLine);
        }
        streamWriter.Flush();
        streamWriter.Close();
        dg.Dispose();
      }
    }
    catch (Exception ex)
    {
      Console.Write("Erro ao gerar resultado para arquivo CSV: " + ex.Message);
    }
  }

  public static DialogResult InputBox(
    string title,
    string promptText,
    ref string value,
    bool recuperarTextoAreaTransferencia = false)
  {
    Form form = new Form();
    Label label = new Label();
    TextBox textBox = new TextBox();
    Button button1 = new Button();
    Button button2 = new Button();
    form.Text = title;
    label.Text = promptText;
    button1.Text = "OK";
    button2.Text = "Cancel";
    button1.DialogResult = DialogResult.OK;
    button2.DialogResult = DialogResult.Cancel;
    label.SetBounds(9, 20, 372, 13);
    textBox.SetBounds(12, 36, 372, 100);
    textBox.Multiline = true;
    textBox.ScrollBars = ScrollBars.Both;
    textBox.AcceptsReturn = true;
    button1.SetBounds(228, 150, 75, 23);
    button2.SetBounds(309, 150, 75, 23);
    label.AutoSize = true;
    textBox.Anchor |= AnchorStyles.Right;
    button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    form.ClientSize = new Size(396, 190);
    form.Controls.AddRange(new Control[4]
    {
      (Control) label,
      (Control) textBox,
      (Control) button1,
      (Control) button2
    });
    form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
    form.FormBorderStyle = FormBorderStyle.FixedDialog;
    form.StartPosition = FormStartPosition.CenterScreen;
    form.MinimizeBox = false;
    form.MaximizeBox = false;
    form.AcceptButton = (IButtonControl) button1;
    form.CancelButton = (IButtonControl) button2;
    try
    {
      if (recuperarTextoAreaTransferencia)
        textBox.Text = Clipboard.GetText().ToString();
    }
    catch (Exception ex)
    {
      textBox.Text = "";
      BLL.erro("Erro ao recuperar texto da área de transferência.", ex.Message);
    }
    DialogResult dialogResult = form.ShowDialog();
    value = textBox.Text;
    return dialogResult;
  }

  public static DialogResult InputBox2(string title, string promptText, ref string value)
  {
    Form form = new Form();
    Label label = new Label();
    TextBox textBox = new TextBox();
    Button button1 = new Button();
    Button button2 = new Button();
    form.Text = title;
    label.Text = promptText;
    button1.Text = "OK";
    button2.Text = "Cancel";
    button1.DialogResult = DialogResult.OK;
    button2.DialogResult = DialogResult.Cancel;
    label.SetBounds(9, 20, 372, 13);
    textBox.SetBounds(12, 36, 372, 23);
    textBox.PasswordChar = '*';
    textBox.AcceptsReturn = true;
    button1.SetBounds(228, 150, 75, 23);
    button2.SetBounds(309, 150, 75, 23);
    label.AutoSize = true;
    textBox.Anchor |= AnchorStyles.Right;
    button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    form.ClientSize = new Size(396, 190);
    form.Controls.AddRange(new Control[4]
    {
      (Control) label,
      (Control) textBox,
      (Control) button1,
      (Control) button2
    });
    form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
    form.FormBorderStyle = FormBorderStyle.FixedDialog;
    form.StartPosition = FormStartPosition.CenterScreen;
    form.MinimizeBox = false;
    form.MaximizeBox = false;
    form.AcceptButton = (IButtonControl) button1;
    form.CancelButton = (IButtonControl) button2;
    DialogResult dialogResult = form.ShowDialog();
    value = textBox.Text;
    return dialogResult;
  }

  public static string InserirLog(string usuario, string acao)
  {
    try
    {
      string consulta = $"INSERT INTO GVDW_OWNER.RV_B2B_VALIDA_RESULT_LOG (CD_LOGIN_REDE, DS_ATIVIDADE) VALUES ('{usuario.ToUpper()}','{acao}')";
      return acao.IndexOf("RV_B2B_VALIDA_RESULT_LOG") < 0 ? DAL.PegarDadosTOT(consulta, alteracao: true).Rows.Count.ToString() : "0";
    }
    catch (Exception ex)
    {
      return "#" + ex.Message;
    }
  }

  public static void graficoKPI(DataTable dt)
  {
  }

  public static void EnviarEmailComAnexo(
    string emailRemetente,
    string emailDestinatario,
    string assunto,
    string corpoEmailEmHTML,
    string localAnexo)
  {
    try
    {
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Outlook.Application instance = (Microsoft.Office.Interop.Outlook.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")));
      // ISSUE: reference to a compiler-generated field
      if (BLL.\u003C\u003Eo__79.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BLL.\u003C\u003Eo__79.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, MailItem>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (MailItem), typeof (BLL)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      MailItem mailItem = BLL.\u003C\u003Eo__79.\u003C\u003Ep__0.Target((CallSite) BLL.\u003C\u003Eo__79.\u003C\u003Ep__0, instance.CreateItem(OlItemType.olMailItem));
      mailItem.Subject = assunto;
      mailItem.HTMLBody = corpoEmailEmHTML;
      mailItem.To = emailDestinatario;
      string str1 = DAL.PegarValorParametro("P_CORPO_EMAIL_LOCAL_IMG_TOPO");
      string str2 = DAL.PegarValorParametro("P_CORPO_EMAIL_LOCAL_IMG_RODAPE");
      DAL.PegarValorParametro("EMAIL_COPIA_ENVIO_INFORMATIVO");
      // ISSUE: variable of a compiler-generated type
      Attachments attachments1 = mailItem.Attachments;
      if (!File.Exists(str1))
        throw new FileNotFoundException("Imagem do cabeçalio email não encontrada: " + str1);
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Attachment attachment1 = attachments1.Add((object) str1, System.Type.Missing, System.Type.Missing, System.Type.Missing);
      // ISSUE: reference to a compiler-generated method
      attachment1.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", (object) "image/png");
      // ISSUE: reference to a compiler-generated method
      attachment1.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", (object) "myident");
      // ISSUE: reference to a compiler-generated method
      mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", (object) true);
      if (!File.Exists(str2))
        throw new FileNotFoundException("Imagem do rodapé do email não encontrada: " + str2);
      // ISSUE: variable of a compiler-generated type
      Attachments attachments2 = mailItem.Attachments;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Attachment attachment2 = attachments2.Add((object) str2, System.Type.Missing, System.Type.Missing, System.Type.Missing);
      // ISSUE: reference to a compiler-generated method
      attachment2.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", (object) "image/jpeg");
      // ISSUE: reference to a compiler-generated method
      attachment2.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", (object) "myident1");
      foreach (Account account in (IEnumerable) instance.Session.Accounts)
      {
        if (account.SmtpAddress == emailRemetente)
        {
          mailItem.SendUsingAccount = account;
          break;
        }
      }
      if (string.IsNullOrEmpty(localAnexo))
        throw new FileNotFoundException("Anexo não encontrado: " + localAnexo);
      // ISSUE: reference to a compiler-generated method
      mailItem.Attachments.Add((object) localAnexo, (object) OlAttachmentType.olByValue, System.Type.Missing, System.Type.Missing);
      // ISSUE: reference to a compiler-generated method
      mailItem.Send();
      Console.WriteLine("Email enviado com sucesso!");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Erro ao enviar email: " + ex.Message);
      throw;
    }
  }

  public static bool enviarEmail(
    string emailDestinatario,
    string emailAssunto,
    string emailConteudo,
    string emailNomeAnexo = null,
    string emailEnderecoAnexo = null)
  {
    try
    {
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Outlook.Application instance = (Microsoft.Office.Interop.Outlook.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")));
      // ISSUE: reference to a compiler-generated field
      if (BLL.\u003C\u003Eo__80.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BLL.\u003C\u003Eo__80.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, MailItem>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (MailItem), typeof (BLL)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      MailItem mailItem = BLL.\u003C\u003Eo__80.\u003C\u003Ep__0.Target((CallSite) BLL.\u003C\u003Eo__80.\u003C\u003Ep__0, instance.CreateItem(OlItemType.olMailItem));
      string str = DAL.PegarValorParametro("P_CORPO_EMAIL_LOCAL_IMG_TOPO");
      string Source = DAL.PegarValorParametro("P_CORPO_EMAIL_LOCAL_IMG_RODAPE");
      DAL.PegarValorParametro("EMAIL_COPIA_ENVIO_INFORMATIVO");
      // ISSUE: variable of a compiler-generated type
      Attachments attachments1 = mailItem.Attachments;
      if (File.Exists(str))
      {
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Attachment attachment1 = attachments1.Add((object) str, System.Type.Missing, System.Type.Missing, System.Type.Missing);
        // ISSUE: reference to a compiler-generated method
        attachment1.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", (object) "image/png");
        // ISSUE: reference to a compiler-generated method
        attachment1.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", (object) "myident");
        // ISSUE: reference to a compiler-generated method
        mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", (object) true);
        // ISSUE: variable of a compiler-generated type
        Attachments attachments2 = mailItem.Attachments;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Attachment attachment2 = attachments2.Add((object) Source, System.Type.Missing, System.Type.Missing, System.Type.Missing);
        // ISSUE: reference to a compiler-generated method
        attachment2.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", (object) "image/jpeg");
        // ISSUE: reference to a compiler-generated method
        attachment2.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", (object) "myident1");
      }
      mailItem.HTMLBody = emailConteudo;
      if (emailEnderecoAnexo != null)
      {
        string DisplayName = emailNomeAnexo;
        int Position = mailItem.Body.Length + 1;
        int Type = 1;
        // ISSUE: reference to a compiler-generated method
        mailItem.Attachments.Add((object) emailEnderecoAnexo, (object) Type, (object) Position, (object) DisplayName);
      }
      mailItem.Subject = emailAssunto;
      // ISSUE: variable of a compiler-generated type
      Recipients recipients = mailItem.Recipients;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Recipient recipient = recipients.Add(emailDestinatario);
      // ISSUE: reference to a compiler-generated method
      recipient.Resolve();
      // ISSUE: reference to a compiler-generated method
      mailItem.Send();
      return true;
    }
    catch (Exception ex)
    {
      BLL.erro("Ocorreu o seguinte erro: " + ex.Message);
      return false;
    }
  }

  public static void CopiarArquivoParaOutroLocal(string arquivoOrigem, string arquivoDestino)
  {
    string sourceFileName = arquivoOrigem;
    string destFileName = arquivoDestino;
    try
    {
      File.Copy(sourceFileName, destFileName, true);
      int num = (int) MessageBox.Show($"Arquivo: {arquivoOrigem}\n\ncopiado para:{arquivoDestino}", "TOT - Copiando arquivo...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    catch (IOException ex)
    {
      Console.WriteLine(ex.Message);
      BLL.erro("Erro ao copiar arquivo.\n", ex.Message);
    }
  }

  public static void SubstituirTextoWord(string document, string textoProcurado, string textoNovo)
  {
    int num = int.Parse(DAL.PegarValorParametro("NUMERO_TENTATIVAS_GERACAO_WORD_EVIDENCIAS"));
    bool flag = true;
    while (flag)
    {
      try
      {
        Thread.Sleep(int.Parse(DAL.PegarValorParametro("TEMPO_INTERVALO_DURANTE_GERACAO_WORD_EVIDENCIAS")));
        using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(document, true))
        {
          string input = (string) null;
          using (StreamReader streamReader = new StreamReader(wordprocessingDocument.MainDocumentPart.GetStream()))
            input = streamReader.ReadToEnd();
          string str = new Regex(textoProcurado).Replace(input, textoNovo);
          using (StreamWriter streamWriter = new StreamWriter(wordprocessingDocument.MainDocumentPart.GetStream(FileMode.Create)))
            streamWriter.Write(str);
        }
        flag = false;
      }
      catch (Exception ex)
      {
        --num;
        if (num <= 0)
        {
          BLL.erro($"Ocorreu o seguinte erro ao gerar o Word:\n\n{document}\n\n{textoProcurado}\n\n{textoNovo}", ex.Message);
          flag = false;
        }
      }
    }
  }

  public static void SubstituirTextoExcel(int row, int column, string val)
  {
    // ISSUE: variable of a compiler-generated type
    Microsoft.Office.Interop.Excel.Application instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
    // ISSUE: reference to a compiler-generated method
    // ISSUE: variable of a compiler-generated type
    Workbook workbook = instance.Workbooks.Add((object) XlWBATemplate.xlWBATWorksheet);
    // ISSUE: reference to a compiler-generated field
    if (BLL.\u003C\u003Eo__83.\u003C\u003Ep__0 == null)
    {
      // ISSUE: reference to a compiler-generated field
      BLL.\u003C\u003Eo__83.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, Worksheet>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (Worksheet), typeof (BLL)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: variable of a compiler-generated type
    Worksheet worksheet = BLL.\u003C\u003Eo__83.\u003C\u003Ep__0.Target((CallSite) BLL.\u003C\u003Eo__83.\u003C\u003Ep__0, workbook.Worksheets[(object) 1]);
  }
}
