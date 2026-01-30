// Decompiled with JetBrains decompiler
// Type: TOT.Globals
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

#nullable disable
namespace TOT;

public class Globals
{
  private static string _tabelaoracle;
  private static string _consultaoracle;
  private static string _usuariobanco;
  private static string _senhabanco;
  private static string _queryprincipal;
  private static int _numerotentativas;
  private static string _loginredeusuario;

  public static string _tabelaOracle
  {
    set => Globals._tabelaoracle = value;
    get => Globals._tabelaoracle;
  }

  public static string _consultaOracle
  {
    set => Globals._consultaoracle = value;
    get => Globals._consultaoracle;
  }

  public static string _usuarioBanco
  {
    set => Globals._usuariobanco = value;
    get => Globals._usuariobanco;
  }

  public static string _senhaBanco
  {
    set => Globals._senhabanco = value;
    get => Globals._senhabanco;
  }

  public static string _queryPrincipal
  {
    set => Globals._queryprincipal = value;
    get => Globals._queryprincipal;
  }

  public static int _numeroTentativas
  {
    set => Globals._numerotentativas = value;
    get => Globals._numerotentativas;
  }

  public static string _loginRedeUsuario
  {
    set => Globals._loginredeusuario = value;
    get => Globals._loginredeusuario;
  }
}
