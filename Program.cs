// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!\n");

// Substitua pelo caminho real da pasta e do arquivo TXT.
string folderPath = @"D:\Downloads\Downloads-FullQuality\Soundeo\PsyTrance-Soundeo";
string txtFilePath = @"C:\Users\marlo\Desktop\testepsytrance.txt";

List<string> fileNames = GetFileNames(folderPath);
List<string> containedFileNames = CheckFilesInTxt(txtFilePath, fileNames);

// Imprime os nomes dos arquivos que foram encontrados no arquivo TXT.
foreach (var fileName in containedFileNames)
{
    Console.WriteLine($"{fileName} encontrado no arquivo TXT.");
}

static List<string> GetFileNames(string folderPath)
{
    List<string> fileNames = new List<string>();
    DirectoryInfo directory = new DirectoryInfo(folderPath);
    FileInfo[] files = directory.GetFiles();

    foreach (FileInfo file in files)
    {
        var tratamentoNome = file.Name.Split("- ");
        tratamentoNome = tratamentoNome[1].Split(".wav");
        tratamentoNome = tratamentoNome[0].Split(" (");
        fileNames.Add(tratamentoNome[0]);
    }

    return fileNames;
}

static List<string> CheckFilesInTxt(string txtFilePath, List<string> fileNames)
{
    List<string> containedFileNames = new List<string>();

    // Lê o conteúdo do arquivo TXT.
    string txtContent = File.ReadAllText(txtFilePath);

    // Verifica se cada nome de arquivo está contido no conteúdo do arquivo TXT.
    foreach (string fileName in fileNames)
    {
        if (txtContent.Contains(fileName))
        {
            containedFileNames.Add(fileName);
        }
    }

    return containedFileNames;
}