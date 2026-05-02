namespace WordRemember;

public class Form1 : Form
{
    private System.ComponentModel.IContainer? components = null;
    private const int WindowWidth = 800;
    private const int WindowHeight = 640;
    private TableLayoutPanel? mainInterfacePanel;
    private Label? greetingLabel;
    private Button? rememberWordButton;
    private Button? importWordButton;
    private Button? settingsButton;
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
        this.Text = "屑小鱼单词背诵器";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.AliceBlue;
    }
    public Form1()
    {
        InitializeComponent();
        CreateControls();
    }

    private void CreateControls()
    {
        mainInterfacePanel = new TableLayoutPanel();
        mainInterfacePanel.Dock = DockStyle.Fill;
        mainInterfacePanel.ColumnCount = 1;
        mainInterfacePanel.RowCount = 4;

        mainInterfacePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

        for (int i = 0; i < 4; i++) mainInterfacePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

        greetingLabel = new Label();
        greetingLabel.Text = "欢迎使用屑小鱼单词背诵器";
        greetingLabel.TextAlign = ContentAlignment.MiddleCenter;
        greetingLabel.Dock = DockStyle.Fill;
        greetingLabel.Font = new Font("仿宋", 20, FontStyle.Bold);
        greetingLabel.ForeColor = Color.DarkBlue;
        mainInterfacePanel.Controls.Add(greetingLabel, 0, 0);

        rememberWordButton = new Button();
        rememberWordButton.Text = "开始背诵";
        rememberWordButton.TextAlign = ContentAlignment.MiddleCenter;
        rememberWordButton.Dock = DockStyle.Fill;
        rememberWordButton.Font = new Font("仿宋", 16, FontStyle.Regular);
        rememberWordButton.BackColor = Color.LightSkyBlue;
        rememberWordButton.FlatStyle = FlatStyle.Flat;
        rememberWordButton.FlatAppearance.BorderSize = 0;
        rememberWordButton.Cursor = Cursors.Hand;
        rememberWordButton.Margin = new Padding(200, 30, 200, 30);
        mainInterfacePanel.Controls.Add(rememberWordButton, 0, 1);
        rememberWordButton.Click += OpenRememberWordForm!;

        importWordButton = new Button();
        importWordButton.Text = "导入词库";
        importWordButton.TextAlign = ContentAlignment.MiddleCenter;
        importWordButton.Dock = DockStyle.Fill;
        importWordButton.Font = new Font("仿宋", 16, FontStyle.Regular);
        importWordButton.BackColor = Color.LightSkyBlue;
        importWordButton.FlatStyle = FlatStyle.Flat;
        importWordButton.FlatAppearance.BorderSize = 0;
        importWordButton.Cursor = Cursors.Hand;
        importWordButton.Margin = new Padding(200, 30, 200, 30);
        mainInterfacePanel.Controls.Add(importWordButton, 0, 2);
        importWordButton.Click += importWord!;

        settingsButton = new Button();
        settingsButton.Text = "设置";
        settingsButton.TextAlign = ContentAlignment.MiddleCenter;
        settingsButton.Dock = DockStyle.Fill;
        settingsButton.Font = new Font("仿宋", 16, FontStyle.Regular);
        settingsButton.BackColor = Color.LightSkyBlue;
        settingsButton.FlatStyle = FlatStyle.Flat;
        settingsButton.FlatAppearance.BorderSize = 0;
        settingsButton.Cursor = Cursors.Hand;
        settingsButton.Margin = new Padding(200, 30, 200, 30);
        mainInterfacePanel.Controls.Add(settingsButton, 0, 3);
        settingsButton.Click += OpenSettingsForm!;

        this.Controls.Add(mainInterfacePanel);
    }

    private void OpenRememberWordForm(object sender, EventArgs e)
    {
        Form2 newform = new Form2();
        newform.ShowDialog();
    }

    private void OpenSettingsForm(object sender, EventArgs e)
    {
        Form3 newform = new Form3();
        newform.ShowDialog();
    }

    private void importWord(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();

        openFileDialog.Filter = "文本文件(*.txt)|*.txt";
        openFileDialog.FilterIndex = 1;
        openFileDialog.InitialDirectory = "C:/";
        openFileDialog.RestoreDirectory = true;
        openFileDialog.Title = "请选择外语单词列表";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string foreignFileName = openFileDialog.FileName;
            File.Copy(foreignFileName, System.IO.Directory.GetCurrentDirectory() + "./WordList/Foreign.txt", true);
        }

        openFileDialog.Title = "请选择中文单词列表";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string chineseFileName = openFileDialog.FileName;
            File.Copy(chineseFileName, System.IO.Directory.GetCurrentDirectory() + "./WordList/Chinese.txt", true);
        }
        FileOperations operations = new FileOperations();
        operations.ReadWords();
    }
}
