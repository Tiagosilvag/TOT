// Decompiled with JetBrains decompiler
// Type: TOT.frmPrincipal
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Security.Claims;
using System.Security.Principal;
using System.Windows.Forms;
using TOT.Properties;

#nullable disable
namespace TOT;

public class frmPrincipal : Form
{
  private IContainer components = (IContainer) null;
  private MenuStrip menuFormPrincipal;
  private ToolStripMenuItem arquivoToolStripMenuItem;
  private ToolStripMenuItem mnsSair;
  private ToolStripMenuItem ajudaToolStripMenuItem;
  private ToolStripMenuItem mnsSobre;
  private ToolStripStatusLabel statusFormPrincipalUsuario;
  public StatusStrip statusFormPrincipal;
  public ToolStripProgressBar statusProgressBar;
  public ToolStripStatusLabel statusLabelFormPrincipal;
  private ToolStripMenuItem processosToolStripMenuItem;
  private ToolStripMenuItem mnsConsultasBancoDeDados;
  private ImageList imgPrincipal16x16;
  private ToolStripMenuItem parâmetrosToolStripMenuItem;
  private ToolStripMenuItem cmsDataQuality;
  private ToolStripMenuItem cmsConfiguracoes;
  private ToolStripMenuItem cálculoToolStripMenuItem;
  private ToolStripMenuItem cmsUploadBases;
  private ToolStripMenuItem tsmInformativos;
  private ToolStripMenuItem provisãoToolStripMenuItem;
  private ToolStripMenuItem tsmFolhaDePagamento;
  private ToolStripMenuItem toolStripMenuItem2;
  private ToolStripMenuItem toolStripMenuItem3;
  private ToolStripMenuItem tsmJanelas;
  private ToolStripMenuItem mnsPainelControle;
  private ToolStripMenuItem menuVariacoes;
  private ToolStripMenuItem cmsPreferencias;
  private ToolStripMenuItem cmsConexoes;
  private ToolStripMenuItem mnsDataVersaoTOT;

  public frmPrincipal() => this.InitializeComponent();

  private void frmPrincipal_Load(object sender, EventArgs e)
  {
    this.WindowState = FormWindowState.Maximized;
    Globals._loginRedeUsuario = ((ClaimsIdentity) WindowsIdentity.GetCurrent()).Name;
    this.statusFormPrincipalUsuario.Text = Globals._loginRedeUsuario;
    this.statusFormPrincipalUsuario.Alignment = ToolStripItemAlignment.Right;
    ImageList imgPrincipal16x16 = this.imgPrincipal16x16;
    this.mnsConsultasBancoDeDados.Image = imgPrincipal16x16.Images[0];
    this.mnsSobre.Image = imgPrincipal16x16.Images[1];
    this.mnsSair.Image = imgPrincipal16x16.Images[2];
    this.AbrirFormLogin();
    this.validacaoInicial();
    if (MessageBox.Show($"LEIA COM ATENÇÃO:{Environment.NewLine}{Environment.NewLine}- Esta aplicação utilizará os usuários e senhas informados aqui para realizar consultas, inserções e alterações em dados de bancos pré-definidos.{Environment.NewLine}- As informações geradas estão sugeitas à política interna de segurança da empresa.{Environment.NewLine}- Suas consultas e demais ações realizadas nesta ferramenta poderão ser registradas pelo programa em uma tabela de 'log'.{Environment.NewLine}- Só continue se você possuir as devidas autorizações de acesso e estiver ciente das normas, riscos e regras de uso e acesso aos dados da Cia.{Environment.NewLine}- Em caso de dúvida não continue e procure seu gestor imediato.{Environment.NewLine}{Environment.NewLine}Deseja continuar com a execução do programa?", "TOT - Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) != DialogResult.OK)
      Application.Exit();
    BLL.controleForms = 0;
    this.abreFormFilho((Form) new frmParametros());
    this.abreFormFilho((Form) new frmConsultaBancos());
    this.mnsDataVersaoTOT.Text = "Data versão: " + Settings.Default.DataVersao.ToString();
    try
    {
      string newValue1 = Settings.Default.DataVersao.ToString();
      string newValue2 = DAL.PegarValorParametro("DATA_ULTIMA_VERSAO_TOT");
      string str1 = DAL.PegarValorParametro("MENSAGEM_ULTIMA_VERSAO_TOT");
      string str2 = DAL.PegarValorParametro("LOCAL_INSTALADOR_TOT");
      if (newValue1.Equals(newValue2) || !MessageBox.Show(str1.Replace("__DATAAPPLOCAL__", newValue1).Replace("__DATAAPPATUALIZADO__", newValue2).Replace("__LOCALINSTALADORTOT__", str2), "TOT - Nova versão disponível", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk).Equals((object) DialogResult.OK))
        return;
      Process.Start("explorer.exe", str2);
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar recupar data da versão do aplicativo", ex.Message);
    }
  }

  private void mnsSair_Click(object sender, EventArgs e) => Environment.Exit(0);

  private void ConsultaDWMenuFormPrincipal_Click(object sender, EventArgs e)
  {
    this.abreFormFilho((Form) new frmDWTeradata());
  }

  private void abreFormFilho(Form form)
  {
    form.MdiParent = (Form) this;
    form.Show();
    form.WindowState = FormWindowState.Maximized;
  }

  private void mnsSobre_Click(object sender, EventArgs e)
  {
    int num = (int) MessageBox.Show("TOT\n\nAplicação criada com Visual Studio 2013, em linguagem C# e baseada no conceito de sistemas tipo SIG\n\n[SIG] = Sistema de Informação Gerencial\n\n" + $"Versão desta aplicação: {Application.ProductVersion}", "RH - Coordenação de Remuneração Variável", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
  }

  private void mnsConsultasBancoDeDados_Click(object sender, EventArgs e)
  {
    BLL.controleForms = 0;
    this.abreFormFilho((Form) new frmConsultaBancos());
  }

  private void mnsETL_Click(object sender, EventArgs e)
  {
    BLL.controleForms = 3;
    this.abreFormFilho((Form) new frmConsultaBancos());
  }

  private void AbrirFormLogin()
  {
    if (string.IsNullOrWhiteSpace(DAL._usuarioPDW1) || string.IsNullOrWhiteSpace(DAL._senhaPDW1))
    {
      FrmLogin frmLogin = new FrmLogin();
      frmLogin.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmLogin.ShowDialog();
    }
    else
    {
      int num1 = (int) MessageBox.Show("Você já está logado");
    }
  }

  private void conexõesToolStripMenuItem_Click(object sender, EventArgs e)
  {
    this.abreFormFilho((Form) new frmParametros());
  }

  private void validacaoInicial()
  {
    try
    {
      bool flag1 = BLL.validarVersao();
      bool flag2 = BLL.validarUsuario(Globals._loginRedeUsuario);
      if (!flag1)
      {
        BLL.erro("Esta versão está obsoleta. Procure o responsável pela ferramenta e autalize para a versão atual.");
        Environment.Exit(0);
      }
      if (flag2)
        return;
      BLL.erro("Você não está autorizado.");
      Environment.Exit(0);
    }
    catch (Exception ex)
    {
      BLL.erro("Erro crítico ao validar a versão da ferramenta. Essa aplicação será fechada", ex.Message);
      Environment.Exit(0);
    }
  }

  private void parâmetrosToolStripMenuItem_Click(object sender, EventArgs e)
  {
    this.abreFormFilho((Form) new frmParametros());
  }

  private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
  {
    BLL.InserirLog(Globals._loginRedeUsuario, "Saiu");
  }

  private void cmsCalendario_Click(object sender, EventArgs e)
  {
  }

  private void tsmKPI_Click(object sender, EventArgs e)
  {
    this.abreFormFilho((Form) new frmGrafico());
  }

  private void mnsPainelControle_Click(object sender, EventArgs e)
  {
    BLL.controleForms = 1;
    this.abreFormFilho((Form) new frmConsultaBancos());
  }

  private void menuVariacoes_Click(object sender, EventArgs e)
  {
    this.abreFormFilho((Form) new frmEstatisticas());
  }

  private void cmsPreferencias_Click(object sender, EventArgs e)
  {
    frmPreferencias frmPreferencias = new frmPreferencias();
    frmPreferencias.StartPosition = FormStartPosition.CenterScreen;
    int num = (int) frmPreferencias.ShowDialog();
  }

  private void tsmDataQuality_Click(object sender, EventArgs e)
  {
    BLL.controleForms = 2;
    this.abreFormFilho((Form) new frmConsultaBancos());
  }

  private void cmsConexoes_Click(object sender, EventArgs e)
  {
    this.abreFormFilho((Form) new frmParametros());
  }

  private void cmsDataQuality_Click(object sender, EventArgs e)
  {
    BLL.controleForms = 2;
    this.abreFormFilho((Form) new frmConsultaBancos());
  }

  private void tsmInformativos_Click(object sender, EventArgs e)
  {
    BLL.controleForms = 4;
    this.abreFormFilho((Form) new frmConsultaBancos());
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPrincipal));
    this.menuFormPrincipal = new MenuStrip();
    this.arquivoToolStripMenuItem = new ToolStripMenuItem();
    this.mnsSair = new ToolStripMenuItem();
    this.cmsConfiguracoes = new ToolStripMenuItem();
    this.cmsPreferencias = new ToolStripMenuItem();
    this.cmsConexoes = new ToolStripMenuItem();
    this.processosToolStripMenuItem = new ToolStripMenuItem();
    this.mnsConsultasBancoDeDados = new ToolStripMenuItem();
    this.parâmetrosToolStripMenuItem = new ToolStripMenuItem();
    this.cmsUploadBases = new ToolStripMenuItem();
    this.cmsDataQuality = new ToolStripMenuItem();
    this.cálculoToolStripMenuItem = new ToolStripMenuItem();
    this.mnsPainelControle = new ToolStripMenuItem();
    this.tsmInformativos = new ToolStripMenuItem();
    this.provisãoToolStripMenuItem = new ToolStripMenuItem();
    this.tsmFolhaDePagamento = new ToolStripMenuItem();
    this.toolStripMenuItem3 = new ToolStripMenuItem();
    this.toolStripMenuItem2 = new ToolStripMenuItem();
    this.menuVariacoes = new ToolStripMenuItem();
    this.tsmJanelas = new ToolStripMenuItem();
    this.ajudaToolStripMenuItem = new ToolStripMenuItem();
    this.mnsSobre = new ToolStripMenuItem();
    this.mnsDataVersaoTOT = new ToolStripMenuItem();
    this.statusFormPrincipal = new StatusStrip();
    this.statusFormPrincipalUsuario = new ToolStripStatusLabel();
    this.statusLabelFormPrincipal = new ToolStripStatusLabel();
    this.statusProgressBar = new ToolStripProgressBar();
    this.imgPrincipal16x16 = new ImageList(this.components);
    this.menuFormPrincipal.SuspendLayout();
    this.statusFormPrincipal.SuspendLayout();
    this.SuspendLayout();
    this.menuFormPrincipal.ImageScalingSize = new Size(24, 24);
    this.menuFormPrincipal.Items.AddRange(new ToolStripItem[14]
    {
      (ToolStripItem) this.arquivoToolStripMenuItem,
      (ToolStripItem) this.cmsConfiguracoes,
      (ToolStripItem) this.processosToolStripMenuItem,
      (ToolStripItem) this.parâmetrosToolStripMenuItem,
      (ToolStripItem) this.cmsUploadBases,
      (ToolStripItem) this.cmsDataQuality,
      (ToolStripItem) this.cálculoToolStripMenuItem,
      (ToolStripItem) this.tsmInformativos,
      (ToolStripItem) this.provisãoToolStripMenuItem,
      (ToolStripItem) this.tsmFolhaDePagamento,
      (ToolStripItem) this.toolStripMenuItem3,
      (ToolStripItem) this.toolStripMenuItem2,
      (ToolStripItem) this.tsmJanelas,
      (ToolStripItem) this.ajudaToolStripMenuItem
    });
    this.menuFormPrincipal.Location = new Point(0, 0);
    this.menuFormPrincipal.MdiWindowListItem = this.tsmJanelas;
    this.menuFormPrincipal.Name = "menuFormPrincipal";
    this.menuFormPrincipal.Size = new Size(1208, 24);
    this.menuFormPrincipal.TabIndex = 0;
    this.menuFormPrincipal.Text = "menuStrip1";
    this.arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.mnsSair
    });
    this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
    this.arquivoToolStripMenuItem.Size = new Size(61, 20);
    this.arquivoToolStripMenuItem.Text = "Arquivo";
    this.mnsSair.Name = "mnsSair";
    this.mnsSair.Size = new Size(93, 22);
    this.mnsSair.Text = "Sair";
    this.mnsSair.Click += new EventHandler(this.mnsSair_Click);
    this.cmsConfiguracoes.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.cmsPreferencias,
      (ToolStripItem) this.cmsConexoes
    });
    this.cmsConfiguracoes.Name = "cmsConfiguracoes";
    this.cmsConfiguracoes.Size = new Size(96 /*0x60*/, 20);
    this.cmsConfiguracoes.Text = "Configurações";
    this.cmsConfiguracoes.Click += new EventHandler(this.cmsCalendario_Click);
    this.cmsPreferencias.Name = "cmsPreferencias";
    this.cmsPreferencias.Size = new Size(138, 22);
    this.cmsPreferencias.Text = "Preferências";
    this.cmsPreferencias.Click += new EventHandler(this.cmsPreferencias_Click);
    this.cmsConexoes.Name = "cmsConexoes";
    this.cmsConexoes.Size = new Size(138, 22);
    this.cmsConexoes.Text = "Conexões";
    this.cmsConexoes.Click += new EventHandler(this.cmsConexoes_Click);
    this.processosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.mnsConsultasBancoDeDados
    });
    this.processosToolStripMenuItem.Name = "processosToolStripMenuItem";
    this.processosToolStripMenuItem.Size = new Size(71, 20);
    this.processosToolStripMenuItem.Text = "Consultas";
    this.mnsConsultasBancoDeDados.Name = "mnsConsultasBancoDeDados";
    this.mnsConsultasBancoDeDados.Size = new Size(163, 22);
    this.mnsConsultasBancoDeDados.Text = "Bancos de dados";
    this.mnsConsultasBancoDeDados.Click += new EventHandler(this.mnsConsultasBancoDeDados_Click);
    this.parâmetrosToolStripMenuItem.Enabled = false;
    this.parâmetrosToolStripMenuItem.Name = "parâmetrosToolStripMenuItem";
    this.parâmetrosToolStripMenuItem.Size = new Size(79, 20);
    this.parâmetrosToolStripMenuItem.Text = "Parâmetros";
    this.parâmetrosToolStripMenuItem.Visible = false;
    this.parâmetrosToolStripMenuItem.Click += new EventHandler(this.parâmetrosToolStripMenuItem_Click);
    this.cmsUploadBases.Name = "cmsUploadBases";
    this.cmsUploadBases.Size = new Size(87, 20);
    this.cmsUploadBases.Text = "Cargas bases";
    this.cmsUploadBases.Click += new EventHandler(this.mnsETL_Click);
    this.cmsDataQuality.Name = "cmsDataQuality";
    this.cmsDataQuality.Size = new Size(84, 20);
    this.cmsDataQuality.Text = "Data Quality";
    this.cmsDataQuality.Click += new EventHandler(this.cmsDataQuality_Click);
    this.cálculoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.mnsPainelControle
    });
    this.cálculoToolStripMenuItem.Name = "cálculoToolStripMenuItem";
    this.cálculoToolStripMenuItem.Size = new Size(59, 20);
    this.cálculoToolStripMenuItem.Text = "Cálculo";
    this.mnsPainelControle.Name = "mnsPainelControle";
    this.mnsPainelControle.Size = new Size(124, 22);
    this.mnsPainelControle.Text = "Execução";
    this.mnsPainelControle.Click += new EventHandler(this.mnsPainelControle_Click);
    this.tsmInformativos.Name = "tsmInformativos";
    this.tsmInformativos.Size = new Size(86, 20);
    this.tsmInformativos.Text = "Informativos";
    this.tsmInformativos.Click += new EventHandler(this.tsmInformativos_Click);
    this.provisãoToolStripMenuItem.Enabled = false;
    this.provisãoToolStripMenuItem.Name = "provisãoToolStripMenuItem";
    this.provisãoToolStripMenuItem.Size = new Size(64 /*0x40*/, 20);
    this.provisãoToolStripMenuItem.Text = "Provisão";
    this.provisãoToolStripMenuItem.Visible = false;
    this.tsmFolhaDePagamento.Enabled = false;
    this.tsmFolhaDePagamento.Name = "tsmFolhaDePagamento";
    this.tsmFolhaDePagamento.Size = new Size(128 /*0x80*/, 20);
    this.tsmFolhaDePagamento.Text = "Folha de pagamento";
    this.toolStripMenuItem3.Enabled = false;
    this.toolStripMenuItem3.Name = "toolStripMenuItem3";
    this.toolStripMenuItem3.Size = new Size(85, 20);
    this.toolStripMenuItem3.Text = "Contestação";
    this.toolStripMenuItem3.Visible = false;
    this.toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.menuVariacoes
    });
    this.toolStripMenuItem2.Name = "toolStripMenuItem2";
    this.toolStripMenuItem2.Size = new Size(76, 20);
    this.toolStripMenuItem2.Text = "Dashboard";
    this.menuVariacoes.Name = "menuVariacoes";
    this.menuVariacoes.Size = new Size(123, 22);
    this.menuVariacoes.Text = "Variações";
    this.menuVariacoes.Click += new EventHandler(this.menuVariacoes_Click);
    this.tsmJanelas.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.tsmJanelas.Name = "tsmJanelas";
    this.tsmJanelas.Size = new Size(58, 20);
    this.tsmJanelas.Text = "Janelas";
    this.ajudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.mnsSobre,
      (ToolStripItem) this.mnsDataVersaoTOT
    });
    this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
    this.ajudaToolStripMenuItem.Size = new Size(50, 20);
    this.ajudaToolStripMenuItem.Text = "Ajuda";
    this.mnsSobre.Name = "mnsSobre";
    this.mnsSobre.Size = new Size(104, 22);
    this.mnsSobre.Text = "Sobre";
    this.mnsSobre.Click += new EventHandler(this.mnsSobre_Click);
    this.mnsDataVersaoTOT.Name = "mnsDataVersaoTOT";
    this.mnsDataVersaoTOT.Size = new Size(104, 22);
    this.statusFormPrincipal.ImageScalingSize = new Size(24, 24);
    this.statusFormPrincipal.Items.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.statusFormPrincipalUsuario,
      (ToolStripItem) this.statusLabelFormPrincipal,
      (ToolStripItem) this.statusProgressBar
    });
    this.statusFormPrincipal.Location = new Point(0, 364);
    this.statusFormPrincipal.Name = "statusFormPrincipal";
    this.statusFormPrincipal.Size = new Size(1208, 22);
    this.statusFormPrincipal.TabIndex = 1;
    this.statusFormPrincipal.Text = "statusStrip1";
    this.statusFormPrincipalUsuario.DisplayStyle = ToolStripItemDisplayStyle.Text;
    this.statusFormPrincipalUsuario.Name = "statusFormPrincipalUsuario";
    this.statusFormPrincipalUsuario.Size = new Size(0, 17);
    this.statusFormPrincipalUsuario.TextAlign = ContentAlignment.MiddleRight;
    this.statusFormPrincipalUsuario.ToolTipText = "Login do usuário logado na máquina";
    this.statusLabelFormPrincipal.Name = "statusLabelFormPrincipal";
    this.statusLabelFormPrincipal.Size = new Size(0, 17);
    this.statusProgressBar.Name = "statusProgressBar";
    this.statusProgressBar.Size = new Size(100, 16 /*0x10*/);
    this.imgPrincipal16x16.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgPrincipal16x16.ImageStream");
    this.imgPrincipal16x16.TransparentColor = Color.Transparent;
    this.imgPrincipal16x16.Images.SetKeyName(0, "iconfinder_Data-09_4203015.png");
    this.imgPrincipal16x16.Images.SetKeyName(1, "iconfinder_Help_1493288.png");
    this.imgPrincipal16x16.Images.SetKeyName(2, "iconfinder_exit_3855614.png");
    this.imgPrincipal16x16.Images.SetKeyName(3, "iconfinder_calculator-math-tool-school_2824440.png");
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1208, 386);
    this.Controls.Add((Control) this.statusFormPrincipal);
    this.Controls.Add((Control) this.menuFormPrincipal);
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsMdiContainer = true;
    this.MainMenuStrip = this.menuFormPrincipal;
    this.Name = nameof (frmPrincipal);
    this.Text = "Gerência de Remuneração Variável";
    this.FormClosed += new FormClosedEventHandler(this.frmPrincipal_FormClosed);
    this.Load += new EventHandler(this.frmPrincipal_Load);
    this.menuFormPrincipal.ResumeLayout(false);
    this.menuFormPrincipal.PerformLayout();
    this.statusFormPrincipal.ResumeLayout(false);
    this.statusFormPrincipal.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
