// Decompiled with JetBrains decompiler
// Type: TOT.frmZoomTexto
// Assembly: TOT 2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84777FBD-8041-4AAF-9125-1A03BA42CC7F
// Assembly location: C:\Users\A0166936\Documents\TOT 2019_1_0_0_154\TOT 2019.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace TOT;

public class frmZoomTexto : Form
{
  private IContainer components = (IContainer) null;
  private TextBox txtTextoZoom;
  private Button btnFecharTextoZoom;
  private Button btnEnviarAlteracoes;
  private Button btnGerarWord;
  private Label label1;
  private Button btnTextoMenor;
  private Button btnTextoMaior;

  public frmZoomTexto() => this.InitializeComponent();

  private void frmZoomTexto_Load(object sender, EventArgs e)
  {
    this.Text = "TOT - Visualizador de textos";
    this.WindowState = FormWindowState.Normal;
    this.txtTextoZoom.Text = BLL._textoZoom;
    this.btnEnviarAlteracoes.Enabled = false;
    this.btnGerarWord.Visible = false;
  }

  private void btnFecharTextoZoom_Click(object sender, EventArgs e)
  {
    if (this.btnEnviarAlteracoes.Enabled)
    {
      if (!MessageBox.Show("Deseja sair sem salvar?\n\nSuas alterações serão perdidas", "TOT - Corfimar descarte das alterações", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).Equals((object) DialogResult.OK))
        return;
      this.Close();
    }
    else
      this.Close();
  }

  private void btnEnviarAlteracoes_Click(object sender, EventArgs e)
  {
    BLL._textoZoom = this.txtTextoZoom.Text;
    this.Close();
  }

  private void txtTextoZoom_TextChanged(object sender, EventArgs e)
  {
    this.btnEnviarAlteracoes.Enabled = true;
  }

  private void cmbTamanhoFonte_SelectedIndexChanged(object sender, EventArgs e)
  {
    this.txtTextoZoom.Font = new Font(this.txtTextoZoom.Font.FontFamily, 16f);
  }

  private void btnTextoMaior_Click(object sender, EventArgs e) => this.tamanhoTexto(1);

  private void btnTextoMenor_Click(object sender, EventArgs e) => this.tamanhoTexto(-1);

  private void tamanhoTexto(int acao)
  {
    float emSize = this.txtTextoZoom.Font.Size + (float) acao;
    if ((double) emSize >= 18.25)
      emSize = 18.25f;
    if ((double) emSize <= 8.25)
      emSize = 8.25f;
    this.txtTextoZoom.Font = new Font(this.txtTextoZoom.Font.FontFamily, emSize);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.txtTextoZoom = new TextBox();
    this.btnFecharTextoZoom = new Button();
    this.btnEnviarAlteracoes = new Button();
    this.btnGerarWord = new Button();
    this.label1 = new Label();
    this.btnTextoMenor = new Button();
    this.btnTextoMaior = new Button();
    this.SuspendLayout();
    this.txtTextoZoom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.txtTextoZoom.Location = new Point(12, 12);
    this.txtTextoZoom.Multiline = true;
    this.txtTextoZoom.Name = "txtTextoZoom";
    this.txtTextoZoom.ScrollBars = ScrollBars.Both;
    this.txtTextoZoom.Size = new Size(1027, 419);
    this.txtTextoZoom.TabIndex = 0;
    this.txtTextoZoom.TextChanged += new EventHandler(this.txtTextoZoom_TextChanged);
    this.btnFecharTextoZoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnFecharTextoZoom.Location = new Point(966, 447);
    this.btnFecharTextoZoom.Name = "btnFecharTextoZoom";
    this.btnFecharTextoZoom.Size = new Size(73, 23);
    this.btnFecharTextoZoom.TabIndex = 1;
    this.btnFecharTextoZoom.Text = "Cancelar";
    this.btnFecharTextoZoom.UseVisualStyleBackColor = true;
    this.btnFecharTextoZoom.Click += new EventHandler(this.btnFecharTextoZoom_Click);
    this.btnEnviarAlteracoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnEnviarAlteracoes.Enabled = false;
    this.btnEnviarAlteracoes.Location = new Point(888, 447);
    this.btnEnviarAlteracoes.Name = "btnEnviarAlteracoes";
    this.btnEnviarAlteracoes.Size = new Size(72, 23);
    this.btnEnviarAlteracoes.TabIndex = 3;
    this.btnEnviarAlteracoes.Text = "Salvar";
    this.btnEnviarAlteracoes.UseVisualStyleBackColor = true;
    this.btnEnviarAlteracoes.Click += new EventHandler(this.btnEnviarAlteracoes_Click);
    this.btnGerarWord.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnGerarWord.Location = new Point(12, 447);
    this.btnGerarWord.Name = "btnGerarWord";
    this.btnGerarWord.Size = new Size(145, 23);
    this.btnGerarWord.TabIndex = 4;
    this.btnGerarWord.Text = "Gerar documento Word";
    this.btnGerarWord.UseVisualStyleBackColor = true;
    this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.label1.AutoSize = true;
    this.label1.Location = new Point(676, 452);
    this.label1.Name = "label1";
    this.label1.Size = new Size(82, 13);
    this.label1.TabIndex = 5;
    this.label1.Text = "Tamanho fonte:";
    this.btnTextoMenor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnTextoMenor.Location = new Point(788, 447);
    this.btnTextoMenor.Name = "btnTextoMenor";
    this.btnTextoMenor.Size = new Size(25, 23);
    this.btnTextoMenor.TabIndex = 6;
    this.btnTextoMenor.Text = "-";
    this.btnTextoMenor.UseVisualStyleBackColor = true;
    this.btnTextoMenor.Click += new EventHandler(this.btnTextoMenor_Click);
    this.btnTextoMaior.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnTextoMaior.Location = new Point(819, 447);
    this.btnTextoMaior.Name = "btnTextoMaior";
    this.btnTextoMaior.Size = new Size(25, 23);
    this.btnTextoMaior.TabIndex = 7;
    this.btnTextoMaior.Text = "+";
    this.btnTextoMaior.UseVisualStyleBackColor = true;
    this.btnTextoMaior.Click += new EventHandler(this.btnTextoMaior_Click);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1051, 482);
    this.Controls.Add((Control) this.btnTextoMaior);
    this.Controls.Add((Control) this.btnTextoMenor);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.btnGerarWord);
    this.Controls.Add((Control) this.btnEnviarAlteracoes);
    this.Controls.Add((Control) this.btnFecharTextoZoom);
    this.Controls.Add((Control) this.txtTextoZoom);
    this.Name = nameof (frmZoomTexto);
    this.Text = nameof (frmZoomTexto);
    this.Load += new EventHandler(this.frmZoomTexto_Load);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
