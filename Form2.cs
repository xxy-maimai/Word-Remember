using System.Drawing.Text;

namespace WordRemember;

public class Form2 : Form
{
    private System.ComponentModel.IContainer? components = null;
    private const int WindowWidth = 800;
    private const int WindowHeight = 640;
    private TableLayoutPanel? wordRememberPanel;
    private Label? wordCountLabel;
    private Label? foreignWordLabel;
    private Label? chineseWordLabel;
    private Button? lastWordButton;
    private Button? rememberWordButton;
    private int wordCount = 1;
    private List<int> wordIndexes = new List<int>();
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    private void GenerateWordList()
    {
        switch (GlobalVariables.settings[1])
        {
            case "random":
                Random rand = new Random();
                for (int i = 1; i <= Convert.ToInt32(GlobalVariables.settings[0]); i++)
                {
                    int newindex = 0;
                    while (wordIndexes.Contains(newindex))
                    {
                        newindex = rand.Next(0, Convert.ToInt32(GlobalVariables.settings[0]));
                    }
                    wordIndexes.Add(newindex);
                }
                break;

            case "order":
                if (GlobalVariables.wordCount == GlobalVariables.foreignWordList.Count()) GlobalVariables.wordCount = 0;
                for (int i = 1; i <= Convert.ToInt32(GlobalVariables.settings[0]) && GlobalVariables.wordCount < GlobalVariables.foreignWordList.Count(); i++)
                {
                    wordIndexes.Add(GlobalVariables.wordCount++);
                }
                GlobalVariables.data[0] = GlobalVariables.wordCount.ToString();
                break;
        }
    }
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new Size(WindowWidth, WindowHeight);
        this.Text = "背诵";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.AliceBlue;
    }
    public Form2()
    {
        GenerateWordList();
        InitializeComponent();
        CreateControls();
    }

    private void CreateControls()
    {
        wordRememberPanel = new TableLayoutPanel();
        wordRememberPanel.Dock = DockStyle.Fill;
        wordRememberPanel.ColumnCount = 3;
        wordRememberPanel.RowCount = 3;
        for (int i = 0; i < 3; i++) wordRememberPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        for (int i = 0; i < 3; i++) wordRememberPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3F));

        wordCountLabel = new Label();
        wordCountLabel.Text = $"第{wordCount}个，共{wordIndexes.Count()}个";
        wordCountLabel.TextAlign = ContentAlignment.MiddleCenter;
        wordCountLabel.Dock = DockStyle.Fill;
        wordCountLabel.Font = new Font("仿宋", 12, FontStyle.Regular);
        wordRememberPanel.Controls.Add(wordCountLabel, 2, 2);

        lastWordButton = new Button();
        lastWordButton.Text = "上一个";
        lastWordButton.TextAlign = ContentAlignment.MiddleCenter;
        lastWordButton.Dock = DockStyle.Fill;
        lastWordButton.Font = new Font("仿宋", 16, FontStyle.Regular);
        lastWordButton.BackColor = Color.LightSkyBlue;
        lastWordButton.FlatStyle = FlatStyle.Flat;
        lastWordButton.FlatAppearance.BorderSize = 0;
        lastWordButton.Margin = new Padding(50, 50, 50, 50);
        wordRememberPanel.Controls.Add(lastWordButton, 0, 2);
        lastWordButton.Click += lastWord!;

        rememberWordButton = new Button();
        rememberWordButton.Text = "记住了";
        rememberWordButton.TextAlign = ContentAlignment.MiddleCenter;
        rememberWordButton.Dock = DockStyle.Fill;
        rememberWordButton.Font = new Font("仿宋", 16, FontStyle.Regular);
        rememberWordButton.BackColor = Color.LightSkyBlue;
        rememberWordButton.FlatStyle = FlatStyle.Flat;
        rememberWordButton.FlatAppearance.BorderSize = 0;
        rememberWordButton.Margin = new Padding(50, 50, 50, 50);
        wordRememberPanel.Controls.Add(rememberWordButton, 1, 2);
        rememberWordButton.Click += rememberWord!;

        foreignWordLabel = new Label();
        foreignWordLabel.Text = GlobalVariables.foreignWordList[wordIndexes[wordCount - 1]];
        foreignWordLabel.TextAlign = ContentAlignment.MiddleCenter;
        foreignWordLabel.Dock = DockStyle.Fill;
        foreignWordLabel.Font = new Font("仿宋", 20, FontStyle.Regular);
        wordRememberPanel.Controls.Add(foreignWordLabel, 1, 0);

        chineseWordLabel = new Label();
        chineseWordLabel.Text = GlobalVariables.chineseWordList[wordIndexes[wordCount - 1]];
        chineseWordLabel.TextAlign = ContentAlignment.MiddleCenter;
        chineseWordLabel.Dock = DockStyle.Fill;
        chineseWordLabel.Font = new Font("仿宋", 20, FontStyle.Regular);
        wordRememberPanel.Controls.Add(chineseWordLabel, 1, 1);

        this.Controls.Add(wordRememberPanel);
    }

    private void lastWord(object sender, EventArgs e)
    {
        if (wordCount > 1)
        {
            wordCount--;
            wordCountLabel!.Text = $"第{wordCount}个，共{wordIndexes.Count()}个";
            foreignWordLabel!.Text = GlobalVariables.foreignWordList[wordIndexes[wordCount - 1]];
            chineseWordLabel!.Text = GlobalVariables.chineseWordList[wordIndexes[wordCount - 1]];
        }
        else
        {
            MessageBox.Show("已经是第一个单词", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void rememberWord(object sender, EventArgs e)
    {
        if (wordCount < wordIndexes.Count())
        {
            wordCount++;
            wordCountLabel!.Text = $"第{wordCount}个，共{wordIndexes.Count()}个";
            foreignWordLabel!.Text = GlobalVariables.foreignWordList[wordIndexes[wordCount - 1]];
            chineseWordLabel!.Text = GlobalVariables.chineseWordList[wordIndexes[wordCount - 1]];
            if (wordCount == Convert.ToInt32(GlobalVariables.settings[0]))
            {
                rememberWordButton!.Text = "结束";
            }
        }
        else
        {
            MessageBox.Show("恭喜你，完成了本次背诵", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}