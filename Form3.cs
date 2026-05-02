using Microsoft.VisualBasic;

namespace WordRemember;

class Form3 : Form
{
    private System.ComponentModel.IContainer? components = null;
    private const int WindowWidth = 800;
    private const int WindowHeight = 640;
    private TableLayoutPanel? settingsPanel;
    private Label? titleLabel;
    private Label? singleCountLabel;
    private Button? singleCountButton;
    private Label? ModeLabel;
    private Button? ModeButton;
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new Size(WindowWidth, WindowHeight);
        this.Text = "设置";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.AliceBlue;
    }
    public Form3()
    {
        InitializeComponent();
        CreateControls();
    }

    private void CreateControls()
    {
        settingsPanel = new TableLayoutPanel();
        settingsPanel.Dock = DockStyle.Fill;
        settingsPanel.ColumnCount = 2;
        settingsPanel.RowCount = 5;

        for (int i = 0; i < 5; i++) settingsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        for (int i = 0; i < 2; i++) settingsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

        titleLabel = new Label();
        titleLabel.Text = "设置";
        titleLabel.TextAlign = ContentAlignment.MiddleCenter;
        titleLabel.Dock = DockStyle.Fill;
        titleLabel.Font = new Font("仿宋", 20, FontStyle.Bold);
        titleLabel.ForeColor = Color.DarkBlue;
        settingsPanel.Controls.Add(titleLabel, 0, 0);
        settingsPanel.SetColumnSpan(titleLabel, 2);

        singleCountLabel = new Label();
        singleCountLabel.Text = $"每次背诵单词个数：{GlobalVariables.settings[0]}";
        singleCountLabel.TextAlign = ContentAlignment.MiddleCenter;
        singleCountLabel.Dock = DockStyle.Fill;
        singleCountLabel.Font = new Font("仿宋", 16, FontStyle.Regular);
        settingsPanel.Controls.Add(singleCountLabel, 0, 1);

        singleCountButton = new Button();
        singleCountButton.Text = "更改";
        singleCountButton.TextAlign = ContentAlignment.MiddleCenter;
        singleCountButton.Dock = DockStyle.Fill;
        singleCountButton.FlatStyle = FlatStyle.Flat;
        singleCountButton.FlatAppearance.BorderSize = 0;
        singleCountButton.Margin = new Padding(50, 20, 50, 20);
        singleCountButton.Font = new Font("仿宋", 16, FontStyle.Regular);
        singleCountButton.BackColor = Color.LightSkyBlue;
        settingsPanel.Controls.Add(singleCountButton, 1, 1);
        singleCountButton.Click += singleCountButtonClick!;

        ModeLabel = new Label();
        ModeLabel.Text = $"模式：{GlobalVariables.settings[1]}";
        ModeLabel.TextAlign = ContentAlignment.MiddleCenter;
        ModeLabel.Dock = DockStyle.Fill;
        ModeLabel.Font = new Font("仿宋", 16, FontStyle.Regular);
        settingsPanel.Controls.Add(ModeLabel, 0, 2);

        ModeButton = new Button();
        ModeButton.Text = "更改";
        ModeButton.TextAlign = ContentAlignment.MiddleCenter;
        ModeButton.Dock = DockStyle.Fill;
        ModeButton.FlatStyle = FlatStyle.Flat;
        ModeButton.FlatAppearance.BorderSize = 0;
        ModeButton.Margin = new Padding(50, 20, 50, 20);
        ModeButton.Font = new Font("仿宋", 16, FontStyle.Regular);
        ModeButton.BackColor = Color.LightSkyBlue;
        settingsPanel.Controls.Add(ModeButton, 1, 2);
        ModeButton.Click += ModeButtonClick!;

        this.Controls.Add(settingsPanel);
    }

    private void singleCountButtonClick(object sender, EventArgs e)
    {
        string val;
        while (string.IsNullOrEmpty(val = Interaction.InputBox("请输入要更改的值：", "设置", "")) || Convert.ToInt32(val) < 0 || Convert.ToInt32(val) > GlobalVariables.foreignWordList.Count())
        {
            MessageBox.Show("请输入正确的值！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        GlobalVariables.settings[0] = val;
        singleCountLabel!.Text = $"每次背诵单词个数：{GlobalVariables.settings[0]}";
        MessageBox.Show("更改完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ModeButtonClick(object sender, EventArgs e)
    {
        GlobalVariables.settings[1] = GlobalVariables.settings[1] == "random" ? "order" : "random";
        ModeLabel!.Text = $"模式：{GlobalVariables.settings[1]}";
        MessageBox.Show("更改完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}