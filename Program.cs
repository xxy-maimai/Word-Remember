namespace WordRemember;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        FileOperations operations = new FileOperations();
        operations.ReadSettings();
        operations.ReadWords();
        operations.ReadData();
        Application.Run(new Form1());
        operations.WriteSettings();
        operations.WriteData();
    }    
}