// Decompiled with JetBrains decompiler
// Type: TOT.FrmLogin
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Data.OracleClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class FrmLogin : Form
{
  private IContainer components = (IContainer) null;
  private StatusStrip statusStrip1;
  private ToolStripStatusLabel tssLogin;
  private GroupBox groupBox1;
  private TextBox txtSenha;
  private TextBox txtLogin;
  private Label label2;
  private Label label1;
  private Button btnLogin;
  private Button btnCancelar;
  private Label lblBemVindo;
  private CheckBox chkLembrarUsuario;

  public FrmLogin() => this.InitializeComponent();

  private void FrmLogin_Load(object sender, EventArgs e)
  {
    this.ControlBox = false;
    this.Text = "RH - Remuneração Variável";
    this.tssLogin.Text = Globals._loginRedeUsuario;
    this.AcceptButton = (IButtonControl) this.btnLogin;
    this.lblBemVindo.Text = "TOT - Sistema de Informações Gerenciais";
    if (!this.chkLembrarUsuario.Checked)
      return;
    try
    {
      this.txtLogin.Text = BLL.lerArquivoTexto(AppDomain.CurrentDomain.BaseDirectory + "\\tmp_user.tot");
    }
    catch (Exception ex)
    {
      BLL.erro("Não foi possível lembrar seu usuário. Por favor, informe manualmente.", ex.Message);
      this.txtLogin.Focus();
    }
  }

  private void btnCancelar_Click(object sender, EventArgs e) => Environment.Exit(0);

  private void btnCancelar_Click_1(object sender, EventArgs e) => Environment.Exit(0);

  private void Login()
  {
    DAL._usuarioPDW1 = this.txtLogin.Text;
    DAL._senhaPDW1 = this.txtSenha.Text;
    if (string.IsNullOrWhiteSpace(DAL._usuarioPDW1) || string.IsNullOrWhiteSpace(DAL._senhaPDW1))
    {
      BLL.erro("Preencha corretamento os campos Usuário e Senha.", "Login obrigatório");
    }
    else
    {
      this.LogarPDW1(DAL._usuarioPDW1, DAL._senhaPDW1);
      if (this.chkLembrarUsuario.Checked)
      {
        try
        {
          this.txtLogin.Text = BLL.lerArquivoTexto(AppDomain.CurrentDomain.BaseDirectory + "\\tmp_user.tot", true, DAL._usuarioPDW1);
        }
        catch (Exception ex)
        {
          BLL.erro("Erro ao tentar lembrar seu usuário.\n\nProsiga normalmente.", ex.Message);
        }
      }
    }
  }

  private void btnLogin_Click(object sender, EventArgs e) => this.Login();

  private void LogarPDW1(string usuario, string senha)
  {
    try
    {
      using (OracleConnection oracleConnection = new OracleConnection(DAL.MontarConnStringTOT(usuario, senha)))
        oracleConnection.Open();
      BLL.InserirLog(Globals._loginRedeUsuario, "Entrou");
      this.Close();
    }
    catch (OracleException ex)
    {
      ++Globals._numeroTentativas;
      BLL.erro("Erro ao tentar conectar ao banco TOT.", ex.Message);
      if (Globals._numeroTentativas <= 1)
        return;
      BLL.erro("Você errou a senha por duas vezes. A aplicação será fechada. Só tente novamente após ter certeza que tem as credenciais corretas.");
      Application.Exit();
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.statusStrip1 = new StatusStrip();
    this.tssLogin = new ToolStripStatusLabel();
    this.groupBox1 = new GroupBox();
    this.label2 = new Label();
    this.label1 = new Label();
    this.txtSenha = new TextBox();
    this.txtLogin = new TextBox();
    this.btnLogin = new Button();
    this.btnCancelar = new Button();
    this.lblBemVindo = new Label();
    this.chkLembrarUsuario = new CheckBox();
    this.statusStrip1.SuspendLayout();
    this.groupBox1.SuspendLayout();
    this.SuspendLayout();
    this.statusStrip1.Items.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.tssLogin
    });
    this.statusStrip1.Location = new Point(0, 268);
    this.statusStrip1.Name = "statusStrip1";
    this.statusStrip1.Size = new Size(357, 22);
    this.statusStrip1.TabIndex = 0;
    this.statusStrip1.Text = "statusStrip1";
    this.tssLogin.Name = "tssLogin";
    this.tssLogin.Size = new Size(0, 17);
    this.groupBox1.Controls.Add((Control) this.label2);
    this.groupBox1.Controls.Add((Control) this.label1);
    this.groupBox1.Controls.Add((Control) this.txtSenha);
    this.groupBox1.Controls.Add((Control) this.txtLogin);
    this.groupBox1.Location = new Point(13, 55);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(331, 152);
    this.groupBox1.TabIndex = 1;
    this.groupBox1.TabStop = false;
    this.label2.AutoSize = true;
    this.label2.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.label2.ForeColor = SystemColors.GrayText;
    this.label2.Location = new Point(49, 92);
    this.label2.Name = "label2";
    this.label2.Size = new Size(65, 24);
    this.label2.TabIndex = 3;
    this.label2.Text = "Senha";
    this.label1.AutoSize = true;
    this.label1.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.label1.ForeColor = SystemColors.GrayText;
    this.label1.Location = new Point(49, 37);
    this.label1.Name = "label1";
    this.label1.Size = new Size(74, 24);
    this.label1.TabIndex = 2;
    this.label1.Text = "Usuário";
    this.txtSenha.BackColor = SystemColors.Info;
    this.txtSenha.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.txtSenha.ForeColor = SystemColors.WindowFrame;
    this.txtSenha.Location = new Point(136, 90);
    this.txtSenha.Name = "txtSenha";
    this.txtSenha.Size = new Size(178, 29);
    this.txtSenha.TabIndex = 1;
    this.txtSenha.UseSystemPasswordChar = true;
    this.txtLogin.BackColor = SystemColors.Info;
    this.txtLogin.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.txtLogin.ForeColor = SystemColors.WindowFrame;
    this.txtLogin.Location = new Point(136, 35);
    this.txtLogin.Name = "txtLogin";
    this.txtLogin.Size = new Size(178, 29);
    this.txtLogin.TabIndex = 0;
    this.btnLogin.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.btnLogin.ForeColor = SystemColors.MenuText;
    this.btnLogin.Location = new Point(246, 219);
    this.btnLogin.Name = "btnLogin";
    this.btnLogin.Size = new Size(98, 32 /*0x20*/);
    this.btnLogin.TabIndex = 2;
    this.btnLogin.Text = "Entrar";
    this.btnLogin.UseVisualStyleBackColor = true;
    this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
    this.btnCancelar.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.btnCancelar.ForeColor = SystemColors.MenuText;
    this.btnCancelar.Location = new Point(142, 219);
    this.btnCancelar.Name = "btnCancelar";
    this.btnCancelar.Size = new Size(98, 32 /*0x20*/);
    this.btnCancelar.TabIndex = 3;
    this.btnCancelar.Text = "Cancelar";
    this.btnCancelar.UseVisualStyleBackColor = true;
    this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click_1);
    this.lblBemVindo.AutoSize = true;
    this.lblBemVindo.Location = new Point(13, 25);
    this.lblBemVindo.Name = "lblBemVindo";
    this.lblBemVindo.Size = new Size(35, 13);
    this.lblBemVindo.TabIndex = 4;
    this.lblBemVindo.Text = "label3";
    this.chkLembrarUsuario.AutoSize = true;
    this.chkLembrarUsuario.Checked = true;
    this.chkLembrarUsuario.CheckState = CheckState.Checked;
    this.chkLembrarUsuario.Location = new Point(16 /*0x10*/, 229);
    this.chkLembrarUsuario.Name = "chkLembrarUsuario";
    this.chkLembrarUsuario.Size = new Size(101, 17);
    this.chkLembrarUsuario.TabIndex = 5;
    this.chkLembrarUsuario.Text = "Lembrar usuário";
    this.chkLembrarUsuario.UseVisualStyleBackColor = true;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(357, 290);
    this.Controls.Add((Control) this.chkLembrarUsuario);
    this.Controls.Add((Control) this.lblBemVindo);
    this.Controls.Add((Control) this.btnCancelar);
    this.Controls.Add((Control) this.btnLogin);
    this.Controls.Add((Control) this.groupBox1);
    this.Controls.Add((Control) this.statusStrip1);
    this.Name = nameof (FrmLogin);
    this.Text = nameof (FrmLogin);
    this.Load += new EventHandler(this.FrmLogin_Load);
    this.statusStrip1.ResumeLayout(false);
    this.statusStrip1.PerformLayout();
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
