// Decompiled with JetBrains decompiler
// Type: TOT.frmHabilitarEdicao
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmHabilitarEdicao : Form
{
  private IContainer components = (IContainer) null;
  private GroupBox groupBox1;
  private RichTextBox txtMotivoAjuste;
  private Label label2;
  private Label label1;
  private DateTimePicker dtpFim;
  private DateTimePicker dtpInicio;
  private Button btnOk;
  private Button btnCancelar;
  private Label lblTabela;
  private Label label3;

  public frmHabilitarEdicao()
  {
    this.InitializeComponent();
    this.lblTabela.Text = DAL._tabelaAtual;
  }

  private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

  private void btnOk_Click(object sender, EventArgs e)
  {
    try
    {
      DateTime dateTime1 = this.dtpInicio.Value;
      DateTime dateTime2 = this.dtpFim.Value;
      string text = this.txtMotivoAjuste.Text;
      string erroSistema = "";
      string tabelaAtual = DAL._tabelaAtual;
      string loginRedeUsuario = Globals._loginRedeUsuario;
      if (string.IsNullOrWhiteSpace(text))
        erroSistema += "\n- Motivo não informado.";
      if ((dateTime2 - dateTime1).Seconds < 0)
        erroSistema += "\n- Período inválido.";
      if (BLL.checkForSQLInjection(text))
        erroSistema += "\n- Você utilizou algum caracter restrito e não permitido no seu texto (como CAST, DEL, @, _, etc).";
      if (string.IsNullOrWhiteSpace(erroSistema))
      {
        if (DAL.PegarDadosTOT($"INSERT INTO GVDW_OWNER.RV_B2B_VALIDA_RESULT_EDIT (DT_ABERTURA, DT_FECHAMENTO, NM_TABELA, CD_LOGIN_REDE, DS_MOTIVO_EDIT) VALUES ('{dateTime1.ToString()}','{dateTime2.ToString()}','{tabelaAtual}','{loginRedeUsuario}','{text}')", alteracao: true) == null)
        {
          BLL.erro("Não foi possível liberar a tabela.", "Erro ao atualizar tabela");
        }
        else
        {
          int num = (int) MessageBox.Show($"Edição da tabela {tabelaAtual} habilitada até {dateTime2.ToString()}.", "TOT - Tabela aberta para edição", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.Close();
        }
      }
      else
        BLL.erro("Revise os dados fornecidos:\n", erroSistema);
    }
    catch (Exception ex)
    {
      BLL.erro("Não foi possível liberar a tabela.", ex.Message);
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
    this.groupBox1 = new GroupBox();
    this.txtMotivoAjuste = new RichTextBox();
    this.label2 = new Label();
    this.label1 = new Label();
    this.dtpFim = new DateTimePicker();
    this.dtpInicio = new DateTimePicker();
    this.btnOk = new Button();
    this.btnCancelar = new Button();
    this.label3 = new Label();
    this.lblTabela = new Label();
    this.groupBox1.SuspendLayout();
    this.SuspendLayout();
    this.groupBox1.Controls.Add((Control) this.lblTabela);
    this.groupBox1.Controls.Add((Control) this.label3);
    this.groupBox1.Controls.Add((Control) this.txtMotivoAjuste);
    this.groupBox1.Controls.Add((Control) this.label2);
    this.groupBox1.Controls.Add((Control) this.label1);
    this.groupBox1.Controls.Add((Control) this.dtpFim);
    this.groupBox1.Controls.Add((Control) this.dtpInicio);
    this.groupBox1.Location = new Point(12, 12);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(554, 294);
    this.groupBox1.TabIndex = 0;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Informar período de ajustes";
    this.txtMotivoAjuste.Location = new Point(18, 110);
    this.txtMotivoAjuste.Name = "txtMotivoAjuste";
    this.txtMotivoAjuste.Size = new Size(518, 167);
    this.txtMotivoAjuste.TabIndex = 4;
    this.txtMotivoAjuste.Text = "";
    this.label2.AutoSize = true;
    this.label2.Location = new Point(22, 42);
    this.label2.Name = "label2";
    this.label2.Size = new Size(37, 13);
    this.label2.TabIndex = 3;
    this.label2.Text = "Início:";
    this.label1.AutoSize = true;
    this.label1.Location = new Point(294, 42);
    this.label1.Name = "label1";
    this.label1.Size = new Size(26, 13);
    this.label1.TabIndex = 2;
    this.label1.Text = "Fim:\r\n";
    this.dtpFim.CustomFormat = "dd/MM/yyyy HH:mm tt";
    this.dtpFim.Format = DateTimePickerFormat.Custom;
    this.dtpFim.Location = new Point(338, 38);
    this.dtpFim.Name = "dtpFim";
    this.dtpFim.Size = new Size(198, 20);
    this.dtpFim.TabIndex = 1;
    this.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm tt";
    this.dtpInicio.Format = DateTimePickerFormat.Custom;
    this.dtpInicio.Location = new Point(80 /*0x50*/, 38);
    this.dtpInicio.Name = "dtpInicio";
    this.dtpInicio.Size = new Size(198, 20);
    this.dtpInicio.TabIndex = 0;
    this.btnOk.Location = new Point(470, 325);
    this.btnOk.Name = "btnOk";
    this.btnOk.Size = new Size(96 /*0x60*/, 23);
    this.btnOk.TabIndex = 1;
    this.btnOk.Text = "OK";
    this.btnOk.UseVisualStyleBackColor = true;
    this.btnOk.Click += new EventHandler(this.btnOk_Click);
    this.btnCancelar.Location = new Point(368, 325);
    this.btnCancelar.Name = "btnCancelar";
    this.btnCancelar.Size = new Size(96 /*0x60*/, 23);
    this.btnCancelar.TabIndex = 2;
    this.btnCancelar.Text = "Cancelar";
    this.btnCancelar.UseVisualStyleBackColor = true;
    this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
    this.label3.AutoSize = true;
    this.label3.Location = new Point(22, 82);
    this.label3.Name = "label3";
    this.label3.Size = new Size(46, 13);
    this.label3.TabIndex = 5;
    this.label3.Text = "Tabela: ";
    this.lblTabela.AutoSize = true;
    this.lblTabela.Location = new Point(77, 82);
    this.lblTabela.Name = "lblTabela";
    this.lblTabela.Size = new Size(36, 13);
    this.lblTabela.TabIndex = 6;
    this.lblTabela.Text = "tabela";
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(578, 362);
    this.Controls.Add((Control) this.btnCancelar);
    this.Controls.Add((Control) this.btnOk);
    this.Controls.Add((Control) this.groupBox1);
    this.Name = nameof (frmHabilitarEdicao);
    this.Text = "TOT - Abrir período de ajuste individual";
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.ResumeLayout(false);
  }
}
