// Decompiled with JetBrains decompiler
// Type: TOT.frmParametros
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

public class frmParametros : Form
{
  private IContainer components = (IContainer) null;
  private TabPage tabConexoes;
  private DataGridView dtgConexoes;
  private TabControl tabParametros;
  private TabPage tabPage1;
  private TabPage tabPage2;
  private TabPage tabPage3;

  public frmParametros() => this.InitializeComponent();

  private void frmConexoes_Load(object sender, EventArgs e)
  {
    this.Text = "Gerenciador de Parâmetros";
    this.dtgConexoes.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    BLL bll = new BLL();
    bll.EstiloTabControl(this.tabParametros);
    bll.EstiloDataGrid(this.dtgConexoes);
    this.preencherBarraStatusPrincipal("Nesta área você configura todos os bancos necessários para o funcionamento do sistema.", false);
    this.PopularGridConexoes();
    this.WindowState = FormWindowState.Maximized;
  }

  private void PopularGridConexoes()
  {
    try
    {
      if (BLL.conexoes == null)
      {
        DataTable dataTable = DAL.PegarDadosTOT("SELECT G.NM_GRUPO Banco ,T.DS_DB Tipo ,G.ID_TIPO_DB \"ID TIPO\" ,G.DS_CONNECTIONSTRING ENDERECO FROM GVDW_OWNER.RV_B2B_VALIDA_RESULT_GRUPO G INNER JOIN GVDW_OWNER.RV_B2B_VALIDA_RESULT_TIPO_DB T ON T.ID_TIPO_DB = G.ID_TIPO_DB /*WHERE LOWER(NM_GRUPO) <> 'pdw1' */");
        dataTable.Columns.Add("USUARIO", typeof (string));
        dataTable.Columns.Add("SENHA", typeof (string));
        this.dtgConexoes.DataSource = (object) dataTable;
        for (int index = 0; index < this.dtgConexoes.Rows.Count; ++index)
        {
          if (this.dtgConexoes.Rows[index].Cells[0].Value.ToString().Equals("pdw1", StringComparison.OrdinalIgnoreCase))
          {
            this.dtgConexoes.Rows[index].Cells[4].Value = (object) DAL._usuarioPDW1;
            this.dtgConexoes.Rows[index].Cells[5].Value = (object) DAL._senhaPDW1;
          }
        }
      }
      else
        this.dtgConexoes.DataSource = (object) BLL.conexoes;
      this.dtgConexoes.Columns["BANCO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.dtgConexoes.Columns["ENDERECO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.dtgConexoes.Columns["SENHA"].DefaultCellStyle.Font = new Font("Cruze", 1f, FontStyle.Strikeout, GraphicsUnit.Pixel);
      this.dtgConexoes.Columns["SENHA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.dtgConexoes.ReadOnly = false;
      this.dtgConexoes.Columns[0].ReadOnly = true;
      this.dtgConexoes.Columns[1].ReadOnly = true;
      this.dtgConexoes.Columns[2].ReadOnly = true;
      DataGridViewButtonColumn viewButtonColumn1 = new DataGridViewButtonColumn();
      viewButtonColumn1.HeaderText = "";
      viewButtonColumn1.Name = "btnSenha";
      viewButtonColumn1.Text = "Senha";
      viewButtonColumn1.UseColumnTextForButtonValue = true;
      this.dtgConexoes.Columns.Add((DataGridViewColumn) viewButtonColumn1);
      DataGridViewButtonColumn viewButtonColumn2 = new DataGridViewButtonColumn();
      viewButtonColumn2.HeaderText = "";
      viewButtonColumn2.Name = "btnTestar";
      viewButtonColumn2.Text = "Testar";
      viewButtonColumn2.UseColumnTextForButtonValue = true;
      this.dtgConexoes.Columns.Add((DataGridViewColumn) viewButtonColumn2);
      this.dtgConexoes.Columns[5].Visible = false;
    }
    catch (Exception ex)
    {
      BLL.erro("", ex.Message);
    }
  }

  private void dtgConexoes_EditingControlShowing(
    object sender,
    DataGridViewEditingControlShowingEventArgs e)
  {
  }

  private void dtgConexoes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
  {
  }

  private void dtgConexoes_DataBindingComplete(
    object sender,
    DataGridViewBindingCompleteEventArgs e)
  {
    BLL.conexoes = this.dtgConexoes.DataSource as DataTable;
  }

  private void dtgConexoes_CellClick(object sender, DataGridViewCellEventArgs e)
  {
    string str1 = this.dtgConexoes.Rows[e.RowIndex].Cells["USUARIO"].Value.ToString();
    string str2 = this.dtgConexoes.Rows[e.RowIndex].Cells["SENHA"].Value.ToString();
    string banco = this.dtgConexoes.Rows[e.RowIndex].Cells["BANCO"].Value.ToString();
    if (e.ColumnIndex.Equals(1))
    {
      if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
        BLL.erro("Antes de testar uma conexão, informe um usuário e uma senha válidos");
      else if (BLL.TestarConexãoBanco(banco))
      {
        int num = (int) MessageBox.Show($"Conexão com banco {banco.ToUpper()} realizada com sucesso!", "TOT - Teste de conexão", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        ++Globals._numeroTentativas;
        BLL.erro("Não foi possível conectar!\n\nAtenção: Verifique com cuidade seu usuário e senha antes de testar novamente.\n\nExceder o número de tentativas pode bloquear seu acesso");
      }
    }
    string str3 = "";
    int rowIndex = this.dtgConexoes.CurrentCell.RowIndex;
    if (!this.dtgConexoes.CurrentCell.ColumnIndex.Equals(0) || BLL.InputBox2("Conectar ao banco: " + banco, "Informe sua senha para usuário: " + str1, ref str3) != DialogResult.OK)
      return;
    if (!string.IsNullOrWhiteSpace(str3))
      this.dtgConexoes.Rows[rowIndex].Cells["SENHA"].Value = (object) str3;
    else
      BLL.erro("Senha vazia/em branco.\n\nPreencha o campo com uma senha válida.", "0");
  }

  private void preencherBarraStatusPrincipal(string mensagem, bool alerta)
  {
    try
    {
      ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.Text = mensagem;
      if (alerta)
      {
        ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.ForeColor = BLL.CorAzul;
        ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.BackColor = BLL.CorAmarela;
      }
      else
      {
        ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.ForeColor = BLL.CorTransparente;
        ((frmPrincipal) this.MdiParent).statusLabelFormPrincipal.BackColor = BLL.CorTransparente;
      }
    }
    catch (Exception ex)
    {
      BLL.erro("Erro atualizar a barra de status", ex.Message);
    }
  }

  private void dtgConexoes_KeyDown(object sender, KeyEventArgs e)
  {
  }

  private void dtgConexoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
  {
  }

  private void dtgConexoes_CellLeave(object sender, DataGridViewCellEventArgs e)
  {
  }

  private void dtgConexoes_KeyPress(object sender, KeyPressEventArgs e)
  {
  }

  private void dtgConexoes_Click(object sender, EventArgs e)
  {
  }

  private void dtgConexoes_ContextMenuStripChanged(object sender, EventArgs e)
  {
  }

  private void dtgConexoes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
  {
  }

  private void dtgConexoes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
  {
  }

  private void dtgConexoes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
    this.tabConexoes = new TabPage();
    this.dtgConexoes = new DataGridView();
    this.tabParametros = new TabControl();
    this.tabPage1 = new TabPage();
    this.tabPage2 = new TabPage();
    this.tabPage3 = new TabPage();
    this.tabConexoes.SuspendLayout();
    ((ISupportInitialize) this.dtgConexoes).BeginInit();
    this.tabParametros.SuspendLayout();
    this.SuspendLayout();
    this.tabConexoes.Controls.Add((Control) this.dtgConexoes);
    this.tabConexoes.Location = new Point(4, 22);
    this.tabConexoes.Name = "tabConexoes";
    this.tabConexoes.Padding = new Padding(3);
    this.tabConexoes.Size = new Size(1236, 430);
    this.tabConexoes.TabIndex = 0;
    this.tabConexoes.Text = "Conexões";
    this.tabConexoes.UseVisualStyleBackColor = true;
    this.dtgConexoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.dtgConexoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dtgConexoes.Location = new Point(3, 3);
    this.dtgConexoes.Name = "dtgConexoes";
    this.dtgConexoes.Size = new Size(1230, 427);
    this.dtgConexoes.TabIndex = 0;
    this.dtgConexoes.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.dtgConexoes_CellBeginEdit);
    this.dtgConexoes.CellClick += new DataGridViewCellEventHandler(this.dtgConexoes_CellClick);
    this.dtgConexoes.CellContentClick += new DataGridViewCellEventHandler(this.dtgConexoes_CellContentClick);
    this.dtgConexoes.CellEndEdit += new DataGridViewCellEventHandler(this.dtgConexoes_CellEndEdit);
    this.dtgConexoes.CellLeave += new DataGridViewCellEventHandler(this.dtgConexoes_CellLeave);
    this.dtgConexoes.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dtgConexoes_CellMouseClick);
    this.dtgConexoes.CellMouseLeave += new DataGridViewCellEventHandler(this.dtgConexoes_CellMouseLeave);
    this.dtgConexoes.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dtgConexoes_DataBindingComplete);
    this.dtgConexoes.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dtgConexoes_EditingControlShowing);
    this.dtgConexoes.ContextMenuStripChanged += new EventHandler(this.dtgConexoes_ContextMenuStripChanged);
    this.dtgConexoes.Click += new EventHandler(this.dtgConexoes_Click);
    this.dtgConexoes.KeyDown += new KeyEventHandler(this.dtgConexoes_KeyDown);
    this.dtgConexoes.KeyPress += new KeyPressEventHandler(this.dtgConexoes_KeyPress);
    this.tabParametros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabParametros.Controls.Add((Control) this.tabConexoes);
    this.tabParametros.Controls.Add((Control) this.tabPage1);
    this.tabParametros.Controls.Add((Control) this.tabPage2);
    this.tabParametros.Controls.Add((Control) this.tabPage3);
    this.tabParametros.Location = new Point(1, 3);
    this.tabParametros.Name = "tabParametros";
    this.tabParametros.SelectedIndex = 0;
    this.tabParametros.Size = new Size(1244, 456);
    this.tabParametros.TabIndex = 1;
    this.tabPage1.Location = new Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Size = new Size(1236, 430);
    this.tabPage1.TabIndex = 1;
    this.tabPage1.Text = "Tabelas";
    this.tabPage1.UseVisualStyleBackColor = true;
    this.tabPage2.Location = new Point(4, 22);
    this.tabPage2.Name = "tabPage2";
    this.tabPage2.Size = new Size(1236, 430);
    this.tabPage2.TabIndex = 2;
    this.tabPage2.Text = "Interface";
    this.tabPage2.UseVisualStyleBackColor = true;
    this.tabPage3.Location = new Point(4, 22);
    this.tabPage3.Name = "tabPage3";
    this.tabPage3.Padding = new Padding(3);
    this.tabPage3.Size = new Size(1236, 430);
    this.tabPage3.TabIndex = 3;
    this.tabPage3.Text = "Ajustes de bases";
    this.tabPage3.UseVisualStyleBackColor = true;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1246, 460);
    this.Controls.Add((Control) this.tabParametros);
    this.Name = nameof (frmParametros);
    this.Load += new EventHandler(this.frmConexoes_Load);
    this.tabConexoes.ResumeLayout(false);
    ((ISupportInitialize) this.dtgConexoes).EndInit();
    this.tabParametros.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
