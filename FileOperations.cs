using System.Configuration;
using System.Text;
using System.Xml;

namespace WordRemember;

class FileOperations
{
    private StreamReader? reader;
    private StreamWriter? writer;
    public void ReadSettings()
    {
        try
        {
            reader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "/Settings/settings", Encoding.UTF8);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                GlobalVariables.settings.Add(line);
            }
        }
        catch (FileNotFoundException)
        {
            MessageBox.Show("未找到设置文件！请检查设置文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        reader.Close();
    }
    public void ReadData()
    {
        try
        {
            reader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "/Data/data", Encoding.UTF8);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                GlobalVariables.data.Add(line);
            }
            GlobalVariables.wordCount = Convert.ToInt32(GlobalVariables.data[0]);
        }
        catch (FileNotFoundException)
        {
            MessageBox.Show("未找到数据文件！请检查数据文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        reader.Close();
    }
    public void ReadWords()
    {
        GlobalVariables.chineseWordList.Clear();
        GlobalVariables.foreignWordList.Clear();
        string line;
        try
        {
            reader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "./WordList/Foreign.txt", Encoding.UTF8);
            while ((line = reader.ReadLine()) != null)
            {
                GlobalVariables.foreignWordList.Add(line);
            }
        }
        catch (FileNotFoundException)
        {
            MessageBox.Show("未找到外文词库文件！请检查词库文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        reader.Close();

        try
        {
            reader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "./WordList/Chinese.txt", Encoding.UTF8);
            while ((line = reader.ReadLine()) != null)
            {
                GlobalVariables.chineseWordList.Add(line);
            }
        }

        catch (FileNotFoundException)
        {
            MessageBox.Show("未找到中文词库文件！请检查词库文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        if (GlobalVariables.foreignWordList.Count() != GlobalVariables.chineseWordList.Count())
        {
            MessageBox.Show("中英文词库长度不一致！请检查词库文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        reader.Close();
    }
    public void WriteSettings()
    {
        writer = new StreamWriter(System.IO.Directory.GetCurrentDirectory() + "/Settings/settings");
        for (int i = 0; i < GlobalVariables.settings.Count(); i++)
            writer.WriteLine(GlobalVariables.settings[i]);
        writer.Close();
    }
    public void WriteData()
    {
        writer = new StreamWriter(System.IO.Directory.GetCurrentDirectory() + "/Data/data");
        for (int i = 0; i < GlobalVariables.data.Count(); i++)
            writer.WriteLine(GlobalVariables.data[i]);
        writer.Close();
    }
}