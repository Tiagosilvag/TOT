// Decompiled with JetBrains decompiler
// Type: TOT.frmListaEmailDemandaConcluida
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

public class frmListaEmailDemandaConcluida : Form
{
  public string returnString;
  private IContainer components = (IContainer) null;
  private GroupBox groupBox1;
  private Button btnRemoverTodos;
  private Button btnAdicionarTodos;
  private Button btnRemover;
  private Button btnAdicionar;
  private ListBox lbEmailsSelecionados;
  private ListBox lbEmailsDisponiveis;
  private Button btnOK;
  private Button btnCancelar;
  private Label label2;
  private Label label1;
  private ComboBox cbGruposDestinatariosDemanda;
  private Label label3;
  private Button btNovoGrupoEmail;
  private Button btSalvarGrupoEmail;
  private ImageList imgValidacaoResultado16x16;
  private ToolTip ttEnvioEmailsDemandas;

  public frmListaEmailDemandaConcluida() => this.InitializeComponent();

  private void frmListaEmailDemandaConcluida_Load(object sender, EventArgs e)
  {
    this.carregarListaEmails();
    this.btNovoGrupoEmail.Image = this.imgValidacaoResultado16x16.Images[39];
    this.btSalvarGrupoEmail.Image = this.imgValidacaoResultado16x16.Images[3];
    this.ttEnvioEmailsDemandas.SetToolTip((Control) this.btNovoGrupoEmail, "Cria um novo grupo de emails baseada na seleção de destinatários atual");
    this.ttEnvioEmailsDemandas.SetToolTip((Control) this.btSalvarGrupoEmail, "Salva as alterações nos destinatários do grupo atual");
    this.cbGruposDestinatariosDemanda.DropDownStyle = ComboBoxStyle.DropDownList;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
  }

  private void carregarListaEmails(string grupoSelecionado = null)
  {
    try
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      DataTable dataTable3 = new DataTable();
      string upper = Globals._loginRedeUsuario.ToUpper();
      this.lbEmailsDisponiveis.Items.Clear();
      this.lbEmailsSelecionados.Items.Clear();
      DataTable dataTable4 = DAL.PegarDadosTOT($"SELECT DISTINCT INITCAP(GRUPO) GRUPO FROM GVDW_OWNER.RV_B2B_EMAIL_DEMANDAS WHERE LOGIN_REDE = '{upper}' ORDER BY 1 ");
      this.cbGruposDestinatariosDemanda.Items.Clear();
      this.cbGruposDestinatariosDemanda.Items.Add((object) "");
      foreach (DataRow row in (InternalDataCollectionBase) dataTable4.Rows)
        this.cbGruposDestinatariosDemanda.Items.Add(row["GRUPO"]);
      DataTable dataTable5 = DAL.PegarDadosTOT("SELECT DISTINCT INITCAP(EMAIL) EMAIL FROM GVDW_OWNER.RV_B2B_USUARIOS_APP WHERE FL_ATIVO = 1 AND RECEBE_EMAIL_DEMANDA = 1 ORDER BY 1 ");
      this.lbEmailsDisponiveis.Items.Clear();
      this.lbEmailsSelecionados.Items.Clear();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable5.Rows)
        this.lbEmailsDisponiveis.Items.Add(row["EMAIL"]);
      if (!string.IsNullOrWhiteSpace(grupoSelecionado))
      {
        DataTable dataTable6 = DAL.PegarDadosTOT($"SELECT DISTINCT INITCAP(EMAIL_DESTINATARIO) EMAIL FROM GVDW_OWNER.RV_B2B_EMAIL_DEMANDAS WHERE LOGIN_REDE = '{upper}'  AND INITCAP(GRUPO) = '{grupoSelecionado}' ORDER BY 1 ");
        foreach (DataRow row in (InternalDataCollectionBase) dataTable5.Rows)
          this.lbEmailsDisponiveis.Items.Add(row["EMAIL"]);
        ListBox emailsDisponiveis = this.lbEmailsDisponiveis;
        foreach (DataRow row in (InternalDataCollectionBase) dataTable6.Rows)
        {
          for (int index = emailsDisponiveis.Items.Count - 1; index >= 0; --index)
          {
            if (emailsDisponiveis.Items[index].ToString().Equals(row["EMAIL"]))
            {
              this.lbEmailsSelecionados.Items.Add(emailsDisponiveis.Items[index]);
              this.lbEmailsDisponiveis.Items.Remove(emailsDisponiveis.Items[index]);
            }
          }
        }
        ComboBox destinatariosDemanda = this.cbGruposDestinatariosDemanda;
        for (int index = 0; index < destinatariosDemanda.Items.Count; ++index)
        {
          if (destinatariosDemanda.Items[index].ToString().Equals(grupoSelecionado))
            destinatariosDemanda.SelectedIndex = index;
        }
      }
      this.lbEmailsDisponiveis.SelectionMode = SelectionMode.MultiExtended;
      this.lbEmailsSelecionados.SelectionMode = SelectionMode.MultiExtended;
      this.lbEmailsDisponiveis.Sorted = true;
      this.lbEmailsSelecionados.Sorted = true;
    }
    catch (Exception ex)
    {
      BLL.erro("Erro ao gerar lista de destinatários.", ex.Message);
    }
  }

  private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

  private void btnAdicionar_Click(object sender, EventArgs e)
  {
    ListBox.SelectedObjectCollection objectCollection = new ListBox.SelectedObjectCollection(this.lbEmailsDisponiveis);
    ListBox.SelectedObjectCollection selectedItems = this.lbEmailsDisponiveis.SelectedItems;
    if (this.lbEmailsDisponiveis.SelectedIndex == -1)
      return;
    for (int index = selectedItems.Count - 1; index >= 0; --index)
    {
      this.lbEmailsSelecionados.Items.Add(selectedItems[index]);
      this.lbEmailsDisponiveis.Items.Remove(selectedItems[index]);
    }
  }

  private void btnRemover_Click(object sender, EventArgs e)
  {
    ListBox.SelectedObjectCollection objectCollection = new ListBox.SelectedObjectCollection(this.lbEmailsSelecionados);
    ListBox.SelectedObjectCollection selectedItems = this.lbEmailsSelecionados.SelectedItems;
    if (this.lbEmailsSelecionados.SelectedIndex == -1)
      return;
    for (int index = selectedItems.Count - 1; index >= 0; --index)
    {
      this.lbEmailsDisponiveis.Items.Add(selectedItems[index]);
      this.lbEmailsSelecionados.Items.Remove(selectedItems[index]);
    }
  }

  private void btnAdicionarTodos_Click(object sender, EventArgs e)
  {
    for (int index = this.lbEmailsDisponiveis.Items.Count - 1; index >= 0; --index)
    {
      this.lbEmailsSelecionados.Items.Add(this.lbEmailsDisponiveis.Items[index]);
      this.lbEmailsDisponiveis.Items.Remove(this.lbEmailsDisponiveis.Items[index]);
    }
  }

  private void btnRemoverTodos_Click(object sender, EventArgs e)
  {
    for (int index = this.lbEmailsSelecionados.Items.Count - 1; index >= 0; --index)
    {
      this.lbEmailsDisponiveis.Items.Add(this.lbEmailsSelecionados.Items[index]);
      this.lbEmailsSelecionados.Items.Remove(this.lbEmailsSelecionados.Items[index]);
    }
  }

  private void btnOK_Click(object sender, EventArgs e)
  {
    ListBox emailsSelecionados = this.lbEmailsSelecionados;
    this.returnString = (string) null;
    if (emailsSelecionados.Items.Count > 0)
    {
      for (int index = 0; index < emailsSelecionados.Items.Count; ++index)
        this.returnString = $"{this.returnString}{emailsSelecionados.Items[index].ToString()};";
      this.Close();
    }
    else
    {
      int num = (int) MessageBox.Show("Selecione ao menos um destinatário antes de enviar.", "Nenhum destinatário selecionado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
  }

  private void cbGruposDestinatariosDemanda_SelectionChangeCommitted(object sender, EventArgs e)
  {
    this.carregarListaEmails(this.cbGruposDestinatariosDemanda.Items[this.cbGruposDestinatariosDemanda.SelectedIndex].ToString());
  }

  private void btSalvarGrupoEmail_Click(object sender, EventArgs e) => this.salvarGrupoEmails();

  private void btNovoGrupoEmail_Click(object sender, EventArgs e)
  {
    int num = (int) MessageBox.Show(this.cbGruposDestinatariosDemanda.Text);
  }

  private void btExcluirGrupo_Click(object sender, EventArgs e)
  {
  }

  private void salvarGrupoEmails()
  {
    ComboBox destinatariosDemanda = this.cbGruposDestinatariosDemanda;
    ListBox emailsSelecionados = this.lbEmailsSelecionados;
    string loginRedeUsuario = Globals._loginRedeUsuario;
    if (destinatariosDemanda.SelectedIndex <= 0)
      return;
    string text = destinatariosDemanda.Text;
    DataTable dataTable = DAL.PegarDadosTOT($"DELETE FROM GVDW_OWNER.RV_B2B_EMAIL_DEMANDAS WHERE UPPER(GRUPO) = '{text.ToUpper()}' ", alteracao: true);
    for (int index = 0; index < emailsSelecionados.Items.Count; ++index)
      dataTable = DAL.PegarDadosTOT($"INSERT INTO GVDW_OWNER.RV_B2B_EMAIL_DEMANDAS (LOGIN_REDE, GRUPO, EMAIL_DESTINATARIO) VALUES ('{loginRedeUsuario}','{text}','{emailsSelecionados.Items[index]?.ToString()}')", alteracao: true);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmListaEmailDemandaConcluida));
    this.groupBox1 = new GroupBox();
    this.label2 = new Label();
    this.label1 = new Label();
    this.btnRemoverTodos = new Button();
    this.btnAdicionarTodos = new Button();
    this.btnRemover = new Button();
    this.btnAdicionar = new Button();
    this.lbEmailsSelecionados = new ListBox();
    this.lbEmailsDisponiveis = new ListBox();
    this.btnOK = new Button();
    this.btnCancelar = new Button();
    this.cbGruposDestinatariosDemanda = new ComboBox();
    this.label3 = new Label();
    this.btSalvarGrupoEmail = new Button();
    this.btNovoGrupoEmail = new Button();
    this.imgValidacaoResultado16x16 = new ImageList(this.components);
    this.ttEnvioEmailsDemandas = new ToolTip(this.components);
    this.groupBox1.SuspendLayout();
    this.SuspendLayout();
    this.groupBox1.Controls.Add((Control) this.btNovoGrupoEmail);
    this.groupBox1.Controls.Add((Control) this.btSalvarGrupoEmail);
    this.groupBox1.Controls.Add((Control) this.label3);
    this.groupBox1.Controls.Add((Control) this.cbGruposDestinatariosDemanda);
    this.groupBox1.Controls.Add((Control) this.label2);
    this.groupBox1.Controls.Add((Control) this.label1);
    this.groupBox1.Controls.Add((Control) this.btnRemoverTodos);
    this.groupBox1.Controls.Add((Control) this.btnAdicionarTodos);
    this.groupBox1.Controls.Add((Control) this.btnRemover);
    this.groupBox1.Controls.Add((Control) this.btnAdicionar);
    this.groupBox1.Controls.Add((Control) this.lbEmailsSelecionados);
    this.groupBox1.Controls.Add((Control) this.lbEmailsDisponiveis);
    this.groupBox1.Location = new Point(14, 17);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new Size(803, 445);
    this.groupBox1.TabIndex = 2;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Confirme os destinatários";
    this.label2.AutoSize = true;
    this.label2.Location = new Point(434, 28);
    this.label2.Name = "label2";
    this.label2.Size = new Size(147, 13);
    this.label2.TabIndex = 9;
    this.label2.Text = "Usuários que receberão email";
    this.label1.AutoSize = true;
    this.label1.Location = new Point(6, 28);
    this.label1.Name = "label1";
    this.label1.Size = new Size(109, 13);
    this.label1.TabIndex = 8;
    this.label1.Text = "Usuários cadastrados";
    this.btnRemoverTodos.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.btnRemoverTodos.Location = new Point(385, 253);
    this.btnRemoverTodos.Name = "btnRemoverTodos";
    this.btnRemoverTodos.Size = new Size(34, 30);
    this.btnRemoverTodos.TabIndex = 7;
    this.btnRemoverTodos.Text = "<<";
    this.btnRemoverTodos.UseVisualStyleBackColor = true;
    this.btnRemoverTodos.Click += new EventHandler(this.btnRemoverTodos_Click);
    this.btnAdicionarTodos.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.btnAdicionarTodos.Location = new Point(385, 220);
    this.btnAdicionarTodos.Name = "btnAdicionarTodos";
    this.btnAdicionarTodos.Size = new Size(34, 30);
    this.btnAdicionarTodos.TabIndex = 6;
    this.btnAdicionarTodos.Text = ">>";
    this.btnAdicionarTodos.UseVisualStyleBackColor = true;
    this.btnAdicionarTodos.Click += new EventHandler(this.btnAdicionarTodos_Click);
    this.btnRemover.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.btnRemover.Location = new Point(385, 175);
    this.btnRemover.Name = "btnRemover";
    this.btnRemover.Size = new Size(34, 30);
    this.btnRemover.TabIndex = 5;
    this.btnRemover.Text = "<";
    this.btnRemover.UseVisualStyleBackColor = true;
    this.btnRemover.Click += new EventHandler(this.btnRemover_Click);
    this.btnAdicionar.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.btnAdicionar.Location = new Point(385, 142);
    this.btnAdicionar.Name = "btnAdicionar";
    this.btnAdicionar.Size = new Size(34, 30);
    this.btnAdicionar.TabIndex = 4;
    this.btnAdicionar.Text = ">";
    this.btnAdicionar.UseVisualStyleBackColor = true;
    this.btnAdicionar.Click += new EventHandler(this.btnAdicionar_Click);
    this.lbEmailsSelecionados.FormattingEnabled = true;
    this.lbEmailsSelecionados.Location = new Point(437, 47);
    this.lbEmailsSelecionados.Name = "lbEmailsSelecionados";
    this.lbEmailsSelecionados.Size = new Size(359, 355);
    this.lbEmailsSelecionados.TabIndex = 3;
    this.lbEmailsDisponiveis.FormattingEnabled = true;
    this.lbEmailsDisponiveis.Location = new Point(6, 47);
    this.lbEmailsDisponiveis.Name = "lbEmailsDisponiveis";
    this.lbEmailsDisponiveis.Size = new Size(359, 355);
    this.lbEmailsDisponiveis.TabIndex = 2;
    this.btnOK.Location = new Point(741, 474);
    this.btnOK.Name = "btnOK";
    this.btnOK.Size = new Size(75, 25);
    this.btnOK.TabIndex = 3;
    this.btnOK.Text = "OK";
    this.btnOK.UseVisualStyleBackColor = true;
    this.btnOK.Click += new EventHandler(this.btnOK_Click);
    this.btnCancelar.Location = new Point(660, 474);
    this.btnCancelar.Name = "btnCancelar";
    this.btnCancelar.Size = new Size(75, 25);
    this.btnCancelar.TabIndex = 4;
    this.btnCancelar.Text = "Cancelar";
    this.btnCancelar.UseVisualStyleBackColor = true;
    this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
    this.cbGruposDestinatariosDemanda.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.cbGruposDestinatariosDemanda.FormattingEnabled = true;
    this.cbGruposDestinatariosDemanda.Location = new Point(507, 412);
    this.cbGruposDestinatariosDemanda.Name = "cbGruposDestinatariosDemanda";
    this.cbGruposDestinatariosDemanda.Size = new Size(222, 21);
    this.cbGruposDestinatariosDemanda.TabIndex = 6;
    this.cbGruposDestinatariosDemanda.SelectionChangeCommitted += new EventHandler(this.cbGruposDestinatariosDemanda_SelectionChangeCommitted);
    this.label3.AutoSize = true;
    this.label3.Location = new Point(434, 415);
    this.label3.Name = "label3";
    this.label3.Size = new Size(71, 13);
    this.label3.TabIndex = 10;
    this.label3.Text = "Meus grupos:";
    this.btSalvarGrupoEmail.BackColor = Color.White;
    this.btSalvarGrupoEmail.ImageKey = "document_plain_new.png";
    this.btSalvarGrupoEmail.Location = new Point(735, 408);
    this.btSalvarGrupoEmail.Name = "btSalvarGrupoEmail";
    this.btSalvarGrupoEmail.Size = new Size(30, 30);
    this.btSalvarGrupoEmail.TabIndex = 17;
    this.btSalvarGrupoEmail.UseVisualStyleBackColor = false;
    this.btSalvarGrupoEmail.Click += new EventHandler(this.btSalvarGrupoEmail_Click);
    this.btNovoGrupoEmail.BackColor = Color.White;
    this.btNovoGrupoEmail.ImageKey = "document_plain_new.png";
    this.btNovoGrupoEmail.Location = new Point(767 /*0x02FF*/, 408);
    this.btNovoGrupoEmail.Name = "btNovoGrupoEmail";
    this.btNovoGrupoEmail.Size = new Size(30, 30);
    this.btNovoGrupoEmail.TabIndex = 18;
    this.btNovoGrupoEmail.UseVisualStyleBackColor = false;
    this.btNovoGrupoEmail.Click += new EventHandler(this.btNovoGrupoEmail_Click);
    this.imgValidacaoResultado16x16.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgValidacaoResultado16x16.ImageStream");
    this.imgValidacaoResultado16x16.TransparentColor = Color.Transparent;
    this.imgValidacaoResultado16x16.Images.SetKeyName(0, "iconfinder_list-delete3_59950.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(1, "iconfinder_bullet-blue_59835.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(2, "iconfinder_bullet-yellow_59839.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(3, "iconfinder_save_60025.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(4, "iconfinder_folder_closed_59915.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(5, "iconfinder_document-information_59879.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(6, "iconfinder_logo_brand_brands_logos_excel_3215579.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(7, "iconfinder_ooo-math_493.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(8, "iconfinder_bullet-green_59836.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(9, "iconfinder_bullet-grey_59837.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(10, "iconfinder_bullet-red_59838.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(11, "iconfinder_Data-09_4203015.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(12, "iconfinder_document-information_59879.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(13, "iconfinder_old-view-refresh_23502.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(14, "iconfinder_filter_64280.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(15, "iconfinder_Copy_1493280.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(16 /*0x10*/, "iconfinder_copy_83610.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(17, "iconfinder_35_Glasses_2064510.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(18, "iconfinder_table_60051_tabela.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(19, "iconfinder_user1_60148.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(20, "iconfinder_Tools_60094.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(21, "iconfinder_search_60026.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(22, "iconfinder_play_59990_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(23, "iconfinder_icon-130-cloud-upload_314715.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(24, "Excluir_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(25, "grafico_barra_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(26, "iconfinder_bubble_chart_circle_bubble_4272259.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(27, "iconfinder_category_add_103433.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(28, "sql-query_21303.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(29, "favoritos_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(30, "nao_favoritos_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(31 /*0x1F*/, "plus_azul_16x16.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(32 /*0x20*/, "progress_amarelo.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(33, "progress_azul.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(34, "progress_verde.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(35, "progress_vermelho.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(36, "folder.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(37, "clear-filter.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(38, "gear.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(39, "document_plain_new.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(40, "lock.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(41, "lock_open.png");
    this.imgValidacaoResultado16x16.Images.SetKeyName(42, "document_time.png");
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(831, 511 /*0x01FF*/);
    this.Controls.Add((Control) this.btnCancelar);
    this.Controls.Add((Control) this.btnOK);
    this.Controls.Add((Control) this.groupBox1);
    this.Name = nameof (frmListaEmailDemandaConcluida);
    this.Text = "Destinatários";
    this.Load += new EventHandler(this.frmListaEmailDemandaConcluida_Load);
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.ResumeLayout(false);
  }
}
