// Decompiled with JetBrains decompiler
// Type: TOT.frmPreferencias
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TOT.Properties;

#nullable disable
namespace TOT;

public class frmPreferencias : Form
{
  private IContainer components = (IContainer) null;
  private TabControl tabControl1;
  private TabPage tabPage1;
  private Label lblQuantRegDataGridPrincipal;
  private TextBox txtQuantMaxRegDataGridPrincipal;
  private Button btnSalvar;
  private Button btnCancelar;
  private TabPage tabSeguranca;
  private GroupBox groupBox1;
  private TextBox txtSenhaNova;
  private TextBox txtSenhaAtual;
  private TextBox txtUsuario;
  private Label label5;
  private Button btnAlterarSenha;
  private Label label4;
  private Label label3;
  private Label label2;
  private Label label1;

  public frmPreferencias() => this.InitializeComponent();

  private void pegarValoresConfiguracoes()
  {
    this.txtQuantMaxRegDataGridPrincipal.Text = Settings.Default.NuMaxLinhasDataGridPrincipal.ToString();
  }

  private void frmPreferencias_Load(object sender, EventArgs e)
  {
    this.pegarValoresConfiguracoes();
    this.MaximumSize = this.Size;
    this.MinimumSize = this.Size;
  }

  private void btnSalvar_Click(object sender, EventArgs e)
  {
    Settings.Default.NuMaxLinhasDataGridPrincipal = int.Parse(this.txtQuantMaxRegDataGridPrincipal.Text);
    Settings.Default.Save();
  }

  private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

  private void txtQuantMaxRegDataGridPrincipal_TextChanged(object sender, EventArgs e)
  {
    TextBox dataGridPrincipal = this.txtQuantMaxRegDataGridPrincipal;
    int result;
    if (!int.TryParse(dataGridPrincipal.Text, out result))
      return;
    if (result > 1000)
      dataGridPrincipal.Text = "1000";
    else if (result < 10)
      dataGridPrincipal.Text = "10";
  }

  private void btnAlterarSenha_Click(object sender, EventArgs e) => this.alterarSenhaPDW1();

  private void alterarSenhaPDW1()
  {
    try
    {
      string text1 = this.txtUsuario.Text;
      string text2 = this.txtSenhaAtual.Text;
      string text3 = this.txtSenhaNova.Text;
      string erroPersonalizado = "";
      if (string.IsNullOrWhiteSpace(text1))
        erroPersonalizado += "Usuário não pode ser vazio\n";
      if (string.IsNullOrWhiteSpace(text2))
        erroPersonalizado += "Senha atual não pode ser vazio\n";
      if (string.IsNullOrWhiteSpace(text3))
        erroPersonalizado += "Senha nova não pode ser vazio\n";
      if (erroPersonalizado.Equals(""))
      {
        DataTable dataTable = DAL.PegarDadosTOT($"alter user {text1} identified by \"{text3}\" replace \"{text2}\"", alteracao: true);
        if (dataTable.Columns.Contains("errotot"))
        {
          BLL.erro("ERRO ao tentar alterar senha.", dataTable.Rows[0][0].ToString());
        }
        else
        {
          int num = (int) MessageBox.Show("Aparentemente sua senha foi alterada porque não foi retornada mensagem de erro.\n\nPor segurança o TOT será fechado, para que você faça login novamente com sua NOVA senha.", "TOT - Alteração de senha Oracle", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          Environment.Exit(0);
        }
      }
      else
        BLL.erro(erroPersonalizado);
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao tentar trocar senha:", ex.Message);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPreferencias));
    this.tabControl1 = new TabControl();
    this.tabPage1 = new TabPage();
    this.lblQuantRegDataGridPrincipal = new Label();
    this.txtQuantMaxRegDataGridPrincipal = new TextBox();
    this.tabSeguranca = new TabPage();
    this.btnSalvar = new Button();
    this.btnCancelar = new Button();
    this.groupBox1 = new GroupBox();
    this.txtUsuario = new TextBox();
    this.txtSenhaAtual = new TextBox();
    this.txtSenhaNova = new TextBox();
    this.label1 = new Label();
    this.label2 = new Label();
    this.label3 = new Label();
    this.label4 = new Label();
    this.btnAlterarSenha = new Button();
    this.label5 = new Label();
    this.tabControl1.SuspendLayout();
    this.tabPage1.SuspendLayout();
    this.tabSeguranca.SuspendLayout();
    this.groupBox1.SuspendLayout();
    this.SuspendLayout();
    this.tabControl1.Controls.Add((Control) this.tabPage1);
    this.tabControl1.Controls.Add((Control) this.tabSeguranca);
    this.tabControl1.Location = new Point(7, 12);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new Size(773, 407);
    this.tabControl1.TabIndex = 0;
    this.tabPage1.Controls.Add((Control) this.lblQuantRegDataGridPrincipal);
    this.tabPage1.Controls.Add((Control) this.btnSalvar);
    this.tabPage1.Controls.Add((Control) this.txtQuantMaxRegDataGridPrincipal);
    this.tabPage1.Location = new Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new Padding(3);
    this.tabPage1.Size = new Size(765, 381);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "Consultas";
    this.tabPage1.UseVisualStyleBackColor = true;
    this.lblQuantRegDataGridPrincipal.AutoSize = true;
    this.lblQuantRegDataGridPrincipal.Location = new Point(100, 19);
    this.lblQuantRegDataGridPrincipal.Name = "lblQuantRegDataGridPrincipal";
    this.lblQuantRegDataGridPrincipal.Size = new Size(295, 13);
    this.lblQuantRegDataGridPrincipal.TabIndex = 1;
    this.lblQuantRegDataGridPrincipal.Text = "Limite de registros  prévio para consulta em bancos de dados";
    this.txtQuantMaxRegDataGridPrincipal.Location = new Point(16 /*0x10*/, 15);
    this.txtQuantMaxRegDataGridPrincipal.MaxLength = 4;
    this.txtQuantMaxRegDataGridPrincipal.Name = "txtQuantMaxRegDataGridPrincipal";
    this.txtQuantMaxRegDataGridPrincipal.Size = new Size(77, 20);
    this.txtQuantMaxRegDataGridPrincipal.TabIndex = 0;
    this.txtQuantMaxRegDataGridPrincipal.TextChanged += new EventHandler(this.txtQuantMaxRegDataGridPrincipal_TextChanged);
    this.tabSeguranca.Controls.Add((Control) this.groupBox1);
    this.tabSeguranca.Location = new Point(4, 22);
    this.tabSeguranca.Name = "tabSeguranca";
    this.tabSeguranca.Size = new Size(765, 381);
    this.tabSeguranca.TabIndex = 1;
    this.tabSeguranca.Text = "Segurança";
    this.tabSeguranca.UseVisualStyleBackColor = true;
    this.btnSalvar.DialogResult = DialogResult.Cancel;
    this.btnSalvar.Location = new Point(684, 352);
    this.btnSalvar.Name = "btnSalvar";
    this.btnSalvar.Size = new Size(75, 23);
    this.btnSalvar.TabIndex = 1;
    this.btnSalvar.Text = "Salvar";
    this.btnSalvar.UseVisualStyleBackColor = true;
    this.btnSalvar.Click += new EventHandler(this.btnSalvar_Click);
    this.btnCancelar.Location = new Point(695, 422);
    this.btnCancelar.Name = "btnCancelar";
    this.btnCancelar.Size = new Size(75, 23);
    this.btnCancelar.TabIndex = 2;
    this.btnCancelar.Text = "Cancelar";
    this.btnCancelar.UseVisualStyleBackColor = true;
    this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
    this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.groupBox1.Controls.Add((Control) this.label5);
    this.groupBox1.Controls.Add((Control) this.btnAlterarSenha);
    this.groupBox1.Controls.Add((Control) this.label4);
    this.groupBox1.Controls.Add((Control) this.label3);
    this.groupBox1.Controls.Add((Control) this.label2);
    this.groupBox1.Controls.Add((Control) this.label1);
    this.groupBox1.Controls.Add((Control) this.txtSenhaNova);
    this.groupBox1.Controls.Add((Control) this.txtSenhaAtual);
    this.groupBox1.Controls.Add((Control) this.txtUsuario);
    this.groupBox1.Location = new Point(14, 16 /*0x10*/);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(738, 125);
    this.groupBox1.TabIndex = 0;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Alterar senha de acesso ao PDW1 (Oracle)";
    this.txtUsuario.CharacterCasing = CharacterCasing.Upper;
    this.txtUsuario.Location = new Point(73, 33);
    this.txtUsuario.MaxLength = 100;
    this.txtUsuario.Name = "txtUsuario";
    this.txtUsuario.Size = new Size(124, 20);
    this.txtUsuario.TabIndex = 0;
    this.txtSenhaAtual.Location = new Point(290, 33);
    this.txtSenhaAtual.MaxLength = 100;
    this.txtSenhaAtual.Name = "txtSenhaAtual";
    this.txtSenhaAtual.Size = new Size(124, 20);
    this.txtSenhaAtual.TabIndex = 1;
    this.txtSenhaAtual.UseSystemPasswordChar = true;
    this.txtSenhaNova.Location = new Point(503, 33);
    this.txtSenhaNova.MaxLength = 100;
    this.txtSenhaNova.Name = "txtSenhaNova";
    this.txtSenhaNova.Size = new Size(124, 20);
    this.txtSenhaNova.TabIndex = 2;
    this.txtSenhaNova.UseSystemPasswordChar = true;
    this.label1.AutoSize = true;
    this.label1.Location = new Point(6, 37);
    this.label1.Name = "label1";
    this.label1.Size = new Size(66, 13);
    this.label1.TabIndex = 3;
    this.label1.Text = "Seu usuário:";
    this.label2.AutoSize = true;
    this.label2.Location = new Point(208 /*0xD0*/, 37);
    this.label2.Name = "label2";
    this.label2.Size = new Size(79, 13);
    this.label2.TabIndex = 4;
    this.label2.Text = "Senha ATUAL:";
    this.label3.AutoSize = true;
    this.label3.Location = new Point(531, 53);
    this.label3.Name = "label3";
    this.label3.Size = new Size(0, 13);
    this.label3.TabIndex = 5;
    this.label4.AutoSize = true;
    this.label4.Location = new Point(426, 37);
    this.label4.Name = "label4";
    this.label4.Size = new Size(74, 13);
    this.label4.TabIndex = 6;
    this.label4.Text = "Senha NOVA:";
    this.btnAlterarSenha.Location = new Point(644, 32 /*0x20*/);
    this.btnAlterarSenha.Name = "btnAlterarSenha";
    this.btnAlterarSenha.Size = new Size(75, 23);
    this.btnAlterarSenha.TabIndex = 7;
    this.btnAlterarSenha.Text = "Alterar";
    this.btnAlterarSenha.UseVisualStyleBackColor = true;
    this.btnAlterarSenha.Click += new EventHandler(this.btnAlterarSenha_Click);
    this.label5.AutoSize = true;
    this.label5.ForeColor = Color.Blue;
    this.label5.Location = new Point(4, 75);
    this.label5.Name = "label5";
    this.label5.Size = new Size(731, 39);
    this.label5.TabIndex = 8;
    this.label5.Text = componentResourceManager.GetString("label5.Text");
    this.AcceptButton = (IButtonControl) this.btnSalvar;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.btnSalvar;
    this.ClientSize = new Size(785, 450);
    this.Controls.Add((Control) this.btnCancelar);
    this.Controls.Add((Control) this.tabControl1);
    this.Name = nameof (frmPreferencias);
    this.Text = "Preferências";
    this.Load += new EventHandler(this.frmPreferencias_Load);
    this.tabControl1.ResumeLayout(false);
    this.tabPage1.ResumeLayout(false);
    this.tabPage1.PerformLayout();
    this.tabSeguranca.ResumeLayout(false);
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.ResumeLayout(false);
  }
}
