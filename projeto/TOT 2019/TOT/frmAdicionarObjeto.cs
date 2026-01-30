// Decompiled with JetBrains decompiler
// Type: TOT.frmAdicionarObjeto
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmAdicionarObjeto : Form
{
  private IContainer components = (IContainer) null;
  private ComboBox cmbTabelas;
  private Label label1;
  private Label label2;
  private ComboBox cmbBanco;
  private TextBox txtApelidoTabela;
  private Label label4;
  private RichTextBox rtbDescricao;
  private Label label5;
  private GroupBox groupBox1;
  private Button btnCancelar;
  private Button btnLogin;
  private ComboBox cmbGrupo;
  private Label label3;
  private Label label6;
  private TextBox txtVolumetria;

  public frmAdicionarObjeto() => this.InitializeComponent();

  private void frmAdicionarObjeto_Load(object sender, EventArgs e)
  {
    try
    {
      this.Text = "Adicionar tabelas/view";
      this.ControlBox = false;
      string SQL1 = DAL.PegarValorParametro("SQL_LISTA_TABELAS_GRANT_USUARIO");
      string SQL2 = DAL.PegarValorParametro("SQL_LISTA_BANCOS_USUARIO");
      string SQL3 = DAL.PegarValorParametro("SQL_LISTA_GRUPOS_BASES");
      BLL.popularCombo(this.cmbTabelas, SQL1, "VISUAL", "VALOR");
      BLL.popularCombo(this.cmbBanco, SQL2, "BANCO", "ID");
      BLL.popularCombo(this.cmbGrupo, SQL3, "GRUPO", "ID");
    }
    catch (Exception ex)
    {
      BLL.erro("Ocorreu um falha ao carregar a lista de bases/grupos e/ou bancos.", ex.Message);
    }
  }

  private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

  private void btnLogin_Click(object sender, EventArgs e)
  {
    try
    {
      string userInput1 = this.cmbTabelas.SelectedValue != null ? this.cmbTabelas.SelectedValue.ToString() : this.cmbTabelas.Text;
      string text1 = this.txtApelidoTabela.Text;
      string text2 = this.rtbDescricao.Text;
      string userInput2 = this.cmbGrupo.SelectedValue.ToString();
      string userInput3 = this.cmbBanco.SelectedValue.ToString();
      string text3 = this.txtVolumetria.Text;
      if (BLL.checkForSQLInjection(userInput1) || BLL.checkForSQLInjection(text1) || BLL.checkForSQLInjection(text2) || BLL.checkForSQLInjection(userInput2) || BLL.checkForSQLInjection(userInput3) || BLL.checkForSQLInjection(text3))
      {
        BLL.erro("Você utilizou em seu formulário um texto ou caracter restrito à linguagem SQL.\nRevise seus dados e substitua quaisquer caracteres especiais ou outros que possam conflitar com comandos SQL.");
      }
      else
      {
        DataTable dataTable = DAL.PegarDadosTOT($"insert into GVDW_OWNER.RV_B2B_VALIDA_RESULT (NM_TABELA,NM_APELIDO,DS_OBS,ID_ORDEM,ID_VALIDA_RESULT_GRUPO,NM_CAMPO_VOLUMETRIA) values ('{userInput1}','{text1}','{text2}','{userInput2}','{userInput3}','{text3}')", alteracao: true);
        if (dataTable.Columns.Contains("errotot"))
        {
          BLL.erro("Erro ao inserir nova tabela", dataTable.Rows[0][0].ToString());
        }
        else
        {
          int num = (int) MessageBox.Show("Base de dados adicionada.\nAtualize a lista de tabelas para visualizá-la.", "Base adicionada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.Close();
        }
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao inserir nova tabela", ex.Message);
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
    this.cmbTabelas = new ComboBox();
    this.label1 = new Label();
    this.label2 = new Label();
    this.cmbBanco = new ComboBox();
    this.txtApelidoTabela = new TextBox();
    this.label4 = new Label();
    this.rtbDescricao = new RichTextBox();
    this.label5 = new Label();
    this.groupBox1 = new GroupBox();
    this.label6 = new Label();
    this.txtVolumetria = new TextBox();
    this.cmbGrupo = new ComboBox();
    this.label3 = new Label();
    this.btnCancelar = new Button();
    this.btnLogin = new Button();
    this.groupBox1.SuspendLayout();
    this.SuspendLayout();
    this.cmbTabelas.FormattingEnabled = true;
    this.cmbTabelas.Location = new Point(100, 69);
    this.cmbTabelas.Name = "cmbTabelas";
    this.cmbTabelas.Size = new Size(354, 21);
    this.cmbTabelas.TabIndex = 0;
    this.label1.AutoSize = true;
    this.label1.Location = new Point(11, 73);
    this.label1.Name = "label1";
    this.label1.Size = new Size(40, 13);
    this.label1.TabIndex = 1;
    this.label1.Text = "Tabela";
    this.label2.AutoSize = true;
    this.label2.Location = new Point(11, 111);
    this.label2.Name = "label2";
    this.label2.Size = new Size(36, 13);
    this.label2.TabIndex = 3;
    this.label2.Text = "Grupo";
    this.cmbBanco.FormattingEnabled = true;
    this.cmbBanco.Location = new Point(100, 145);
    this.cmbBanco.Name = "cmbBanco";
    this.cmbBanco.Size = new Size(354, 21);
    this.cmbBanco.TabIndex = 2;
    this.txtApelidoTabela.Location = new Point(100, 32 /*0x20*/);
    this.txtApelidoTabela.Name = "txtApelidoTabela";
    this.txtApelidoTabela.Size = new Size(354, 20);
    this.txtApelidoTabela.TabIndex = 6;
    this.label4.AutoSize = true;
    this.label4.Location = new Point(11, 35);
    this.label4.Name = "label4";
    this.label4.Size = new Size(60, 13);
    this.label4.TabIndex = 7;
    this.label4.Text = "Título TOT";
    this.rtbDescricao.Location = new Point(100, 183);
    this.rtbDescricao.Name = "rtbDescricao";
    this.rtbDescricao.Size = new Size(354, 103);
    this.rtbDescricao.TabIndex = 8;
    this.rtbDescricao.Text = "";
    this.label5.AutoSize = true;
    this.label5.Location = new Point(11, 185);
    this.label5.Name = "label5";
    this.label5.Size = new Size(55, 13);
    this.label5.TabIndex = 9;
    this.label5.Text = "Descrição";
    this.groupBox1.Controls.Add((Control) this.label6);
    this.groupBox1.Controls.Add((Control) this.txtVolumetria);
    this.groupBox1.Controls.Add((Control) this.label1);
    this.groupBox1.Controls.Add((Control) this.cmbTabelas);
    this.groupBox1.Controls.Add((Control) this.label5);
    this.groupBox1.Controls.Add((Control) this.cmbBanco);
    this.groupBox1.Controls.Add((Control) this.rtbDescricao);
    this.groupBox1.Controls.Add((Control) this.label2);
    this.groupBox1.Controls.Add((Control) this.label4);
    this.groupBox1.Controls.Add((Control) this.cmbGrupo);
    this.groupBox1.Controls.Add((Control) this.txtApelidoTabela);
    this.groupBox1.Controls.Add((Control) this.label3);
    this.groupBox1.Location = new Point(7, 12);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(469, 340);
    this.groupBox1.TabIndex = 11;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Dados da base";
    this.label6.AutoSize = true;
    this.label6.Location = new Point(11, 309);
    this.label6.Name = "label6";
    this.label6.Size = new Size(130, 13);
    this.label6.TabIndex = 11;
    this.label6.Text = "Instrução para volumetria*";
    this.txtVolumetria.BackColor = SystemColors.InactiveBorder;
    this.txtVolumetria.Location = new Point(147, 306);
    this.txtVolumetria.Name = "txtVolumetria";
    this.txtVolumetria.Size = new Size(307, 20);
    this.txtVolumetria.TabIndex = 10;
    this.cmbGrupo.FormattingEnabled = true;
    this.cmbGrupo.Location = new Point(100, 107);
    this.cmbGrupo.Name = "cmbGrupo";
    this.cmbGrupo.Size = new Size(354, 21);
    this.cmbGrupo.TabIndex = 4;
    this.label3.AutoSize = true;
    this.label3.Location = new Point(11, 149);
    this.label3.Name = "label3";
    this.label3.Size = new Size(38, 13);
    this.label3.TabIndex = 5;
    this.label3.Text = "Banco";
    this.btnCancelar.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.btnCancelar.ForeColor = SystemColors.MenuText;
    this.btnCancelar.Location = new Point(274, 365);
    this.btnCancelar.Name = "btnCancelar";
    this.btnCancelar.Size = new Size(98, 32 /*0x20*/);
    this.btnCancelar.TabIndex = 13;
    this.btnCancelar.Text = "Cancelar";
    this.btnCancelar.UseVisualStyleBackColor = true;
    this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
    this.btnLogin.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.btnLogin.ForeColor = SystemColors.MenuText;
    this.btnLogin.Location = new Point(378, 365);
    this.btnLogin.Name = "btnLogin";
    this.btnLogin.Size = new Size(98, 32 /*0x20*/);
    this.btnLogin.TabIndex = 12;
    this.btnLogin.Text = "Adicionar";
    this.btnLogin.UseVisualStyleBackColor = true;
    this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(483, 406);
    this.Controls.Add((Control) this.btnCancelar);
    this.Controls.Add((Control) this.btnLogin);
    this.Controls.Add((Control) this.groupBox1);
    this.Name = nameof (frmAdicionarObjeto);
    this.Text = nameof (frmAdicionarObjeto);
    this.Load += new EventHandler(this.frmAdicionarObjeto_Load);
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.ResumeLayout(false);
  }
}
