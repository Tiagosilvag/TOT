// Decompiled with JetBrains decompiler
// Type: TOT.DAL
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using Teradata.Client.Provider;

#nullable disable
namespace TOT;

public class DAL
{
  private static string _bancoselecionado;
  private static string _instanciabanco;
  private static string _usuariopdw1;
  private static string _senhapdw1;
  private static string _usuariosgr;
  private static string _senhasgr;
  private static string _usuariotop;
  private static string _senhatop;
  private static string _tabelaatual;
  private static string _tabelaatualaux;
  private static string _tablecatalog;

  public static string _bancoSelecionado
  {
    set => DAL._bancoselecionado = value;
    get => DAL._bancoselecionado;
  }

  public static string _instanciaBanco
  {
    set => DAL._instanciabanco = value;
    get => DAL._instanciabanco;
  }

  public static string _usuarioPDW1
  {
    set => DAL._usuariopdw1 = value;
    get => DAL._usuariopdw1;
  }

  public static string _senhaPDW1
  {
    set => DAL._senhapdw1 = value;
    get => DAL._senhapdw1;
  }

  public static string _usuarioSGR
  {
    set => DAL._usuariosgr = value;
    get => DAL._usuariosgr;
  }

  public static string _senhaSGR
  {
    set => DAL._senhasgr = value;
    get => DAL._senhasgr;
  }

  public static string _usuarioTOP
  {
    set => DAL._usuariotop = value;
    get => DAL._usuariotop;
  }

  public static string _senhaTOP
  {
    set => DAL._senhatop = value;
    get => DAL._senhatop;
  }

  public static string _tabelaAtual
  {
    set => DAL._tabelaatual = value;
    get => DAL._tabelaatual;
  }

  public static string _tabelaAtualaAux
  {
    set => DAL._tabelaatualaux = value;
    get => DAL._tabelaatualaux;
  }

  public static int tempoMaximoConexao() => 900;

  public static int quantidadeRegistrosPrevia() => 1000;

  public static int quantidadeRegistrosInicial() => 100;

  public static string _tableCatalog
  {
    set => DAL._tablecatalog = value;
    get => DAL._tablecatalog;
  }

  public static string lerArquivoTexto(string arquivo)
  {
    try
    {
      return File.ReadAllText(arquivo);
    }
    catch (Exception ex)
    {
      return ex.Data.Count.ToString();
    }
  }

  public static string MontarConnStringTOT(string usuario, string senha)
  {
    if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
      return (string) null;
    try
    {
      string str = $"{BLL.lerArquivoTexto(AppDomain.CurrentDomain.BaseDirectory + "\\conn.tot")}\n{";User Id="}{usuario}{";Password="}\n{senha}{";"}";
      Console.WriteLine($"Usuario {usuario} tentou conectar...");
      return str;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Tentativa de executar método MontarConnStringTOT, parâmetros usuario = {usuario} e senha = não informar por segurança. Mensagem de erro do TOT: {ex.Message}");
      return (string) null;
    }
  }

  public static DataTable PegarDadosTOT(
    string consulta,
    bool specificTypes = false,
    bool alteracao = false,
    bool programa = false)
  {
    try
    {
      string connectionString = DAL.MontarConnStringTOT(DAL._usuarioPDW1, DAL._senhaPDW1);
      DataTable dataTable1 = new DataTable();
      using (OracleConnection oracleConnection = new OracleConnection(connectionString))
      {
        oracleConnection.Open();
        if (alteracao)
        {
          OracleTransaction tx = oracleConnection.BeginTransaction(IsolationLevel.ReadCommitted);
          DataTable dataTable2 = new DataTable();
          try
          {
            using (OracleCommand oracleCommand = new OracleCommand(consulta, oracleConnection, tx))
            {
              int num = oracleCommand.ExecuteNonQuery();
              if (!programa)
                ;
              tx.Commit();
              dataTable2.Columns.Add("nu_registros", typeof (string));
              dataTable2.Rows.Add((object) num);
              oracleConnection.Close();
              return dataTable2;
            }
          }
          catch (OracleException ex)
          {
            tx.Rollback();
            dataTable2.Columns.Add("errotot", typeof (string));
            dataTable2.Rows.Add((object) ex.Message.ToString());
            throw new Exception($"A consulta [{consulta}] retornou o seguinte erro: [{ex.Message}]");
          }
        }
        else
        {
          OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(consulta, oracleConnection);
          oracleDataAdapter.SelectCommand.CommandTimeout = DAL.tempoMaximoConexao();
          if (specificTypes)
            oracleDataAdapter.ReturnProviderSpecificTypes = true;
          else
            oracleDataAdapter.ReturnProviderSpecificTypes = false;
          oracleDataAdapter.Fill(dataTable1);
          oracleConnection.Close();
          return dataTable1;
        }
      }
    }
    catch (Exception ex)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("errotot", typeof (string));
      dataTable.Rows.Add((object) ex.Message.ToString());
      dataTable.Rows[0][0].ToString();
      return dataTable;
    }
  }

  public static string[] PegarConnectionString(string nomeBanco)
  {
    if (string.IsNullOrEmpty(nomeBanco))
      nomeBanco = "PDW1";
    DataTable dataTable = DAL.PegarDadosTOT($"SELECT DISTINCT DS_CONNECTIONSTRING, ID_TIPO_DB, NM_OWNER, DB_LINK FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT_GRUPO WHERE LOWER(NM_GRUPO) = '{nomeBanco.ToLower()}'  AND FL_ATIVO = 1 ");
    string[] strArray = new string[4];
    if (dataTable.Rows.Count <= 0)
      return (string[]) null;
    strArray[0] = dataTable.Rows[0].ItemArray[0].ToString();
    strArray[1] = dataTable.Rows[0].ItemArray[1].ToString();
    strArray[2] = dataTable.Rows[0].ItemArray[2].ToString();
    strArray[3] = dataTable.Rows[0].ItemArray[3].ToString();
    return strArray;
  }

  public static DataTable PegarDadosBancos(string banco, string consulta, bool specificTypes = false)
  {
    string[] strArray = BLL.PegarConnectionStringCompleta(banco);
    DataTable dataTable = new DataTable();
    BLL.sql = consulta;
    switch (strArray[1])
    {
      case "1":
        using (OracleConnection selectConnection = new OracleConnection(strArray[0]))
        {
          OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(consulta, selectConnection);
          if (specificTypes)
            oracleDataAdapter.ReturnProviderSpecificTypes = true;
          else
            oracleDataAdapter.ReturnProviderSpecificTypes = false;
          oracleDataAdapter.SelectCommand.CommandTimeout = DAL.tempoMaximoConexao();
          selectConnection.Open();
          oracleDataAdapter.Fill(dataTable);
          return dataTable;
        }
      case "2":
        using (SqlConnection selectConnection = new SqlConnection(strArray[0]))
        {
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, selectConnection);
          if (specificTypes)
            sqlDataAdapter.ReturnProviderSpecificTypes = true;
          else
            sqlDataAdapter.ReturnProviderSpecificTypes = false;
          sqlDataAdapter.SelectCommand.CommandTimeout = DAL.tempoMaximoConexao();
          selectConnection.Open();
          sqlDataAdapter.Fill(dataTable);
          return dataTable;
        }
      case "3":
        using (TdConnection tdConnection = new TdConnection(strArray[0]))
        {
          TdDataAdapter tdDataAdapter = new TdDataAdapter(consulta, tdConnection);
          if (specificTypes)
            ((DataAdapter) tdDataAdapter).ReturnProviderSpecificTypes = true;
          else
            ((DataAdapter) tdDataAdapter).ReturnProviderSpecificTypes = false;
          ((DbCommand) tdDataAdapter.SelectCommand).CommandTimeout = DAL.tempoMaximoConexao();
          ((DbConnection) tdConnection).Open();
          ((DbDataAdapter) tdDataAdapter).Fill(dataTable);
          return dataTable;
        }
      default:
        return (DataTable) null;
    }
  }

  public static string PegarValorParametro(string parametro)
  {
    try
    {
      string connectionString = DAL.MontarConnStringTOT(DAL._usuarioPDW1, DAL._senhaPDW1);
      DataTable dataTable = new DataTable();
      using (OracleConnection selectConnection = new OracleConnection(connectionString))
      {
        selectConnection.Open();
        OracleDataAdapter oracleDataAdapter = new OracleDataAdapter($"SELECT DISTINCT VALOR FROM GVDW_OWNER.RV_B2B_PARAMETROS WHERE PARAMETRO = '{parametro}'", selectConnection);
        oracleDataAdapter.SelectCommand.CommandTimeout = DAL.tempoMaximoConexao();
        oracleDataAdapter.Fill(dataTable);
        string str = dataTable.Rows.Count <= 0 ? "" : dataTable.Rows[0][0].ToString();
        selectConnection.Close();
        return str;
      }
    }
    catch (Exception ex)
    {
      Console.Write("Erro ao consultar o banco: " + ex.Message);
      return (string) null;
    }
  }

  public static string PegarValorParametroInformativos(
    string parametro,
    string periodo,
    string canal = "",
    string cargo = "")
  {
    try
    {
      string connectionString = DAL.MontarConnStringTOT(DAL._usuarioPDW1, DAL._senhaPDW1);
      DataTable dataTable = new DataTable();
      string selectCommandText = $"SELECT DISTINCT TX_VALOR FROM GVDW_B2B.TB_PARAMETROS_INFORMATIVO WHERE CD_PARAMETRO = '{parametro}' AND (DS_CANAL = '{canal}' OR FL_CANAL_GERAL=1) AND {periodo} >= ANO_MES_INI AND {periodo} <= ANO_MES_FIM AND (NM_CARGO = '{cargo}' OR FL_CARGO_GERAL=1)";
      using (OracleConnection selectConnection = new OracleConnection(connectionString))
      {
        selectConnection.Open();
        OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommandText, selectConnection);
        oracleDataAdapter.SelectCommand.CommandTimeout = DAL.tempoMaximoConexao();
        oracleDataAdapter.Fill(dataTable);
        string str = dataTable.Rows.Count <= 0 ? "" : dataTable.Rows[0][0].ToString();
        selectConnection.Close();
        return str;
      }
    }
    catch (Exception ex)
    {
      Console.Write("Erro ao consultar o banco: " + ex.Message);
      return (string) null;
    }
  }
}
