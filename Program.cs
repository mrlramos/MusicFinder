// Substitua pelo caminho real da pasta e do arquivo TXT.
string folderPath = @"D:\Downloads\Downloads-FullQuality\Soundeo\Peak-Soundeo";
string txtFilePath = @"C:\Users\marlo\Desktop\testepsytrance.txt";

List<string> fileNames = GetFileNames(folderPath);



List<string> containedFileNames = CheckFilesInTxt(txtFilePath, fileNames);

Console.WriteLine($"Quantidade de arquivos na pasta: {folderPath}");
Console.WriteLine($"{fileNames.Count}\n\n");

// Imprime os nomes dos arquivos que foram encontrados no arquivo TXT.
foreach (var fileName in containedFileNames)
{
    //Console.WriteLine($"{fileName} encontrado no arquivo TXT.");

}

static List<string> GetFileNames(string folderPath)
{
    List<string> fileNames = new List<string>();
    DirectoryInfo directory = new DirectoryInfo(folderPath);
    FileInfo[] files = directory.GetFiles();

    foreach (FileInfo file in files)
    {
        if (!file.Name.Contains(".ps1"))
        {
            var tratamentoNome = file.Name.Split("- ");
            tratamentoNome = tratamentoNome[1].Split(".wav");
            tratamentoNome = tratamentoNome[0].Split(" (");
            fileNames.Add(tratamentoNome[0]);
        }
    }

    return fileNames;
}

static List<string> CheckFilesInTxt(string txtFilePath, List<string> fileNames)
{
    List<string> containedFileNames = new List<string>();
    List<string> notContainedFileNames = new List<string>();

    int itensEncontrados = 0;
    // Lê o conteúdo do arquivo TXT.
    string txtContent = File.ReadAllText(txtFilePath);

    var text = ClearFile(txtContent);

    // Verifica se cada nome de arquivo está contido no conteúdo do arquivo TXT.
    foreach (string fileName in fileNames)
    {
        if (txtContent.Contains(fileName))
        {
            containedFileNames.Add(fileName);
            itensEncontrados++;
        } else
        {
            notContainedFileNames.Add(fileName);
        }
    }

    Console.WriteLine($"Itens encontrados: {itensEncontrados}\n\n");

    foreach (string fileName in notContainedFileNames)
    {
        Console.WriteLine($"Itens não encontrados: {fileName}");
    }

    return containedFileNames;
}

static string ClearFile(string txtContent)
{
    string nova = "";
    var conteudoDoTexto = txtContent.Split("\n");

    string[] totalTracks = new string[182];
    List<string> nomesCorrigidos = new List<string>();

    for (int i = 0; i < totalTracks.Length; i++)
    {
        totalTracks[i] = (i+1)+"\r";
    }

    int cont = 0;
    for (int i = 0; i < conteudoDoTexto.Length; i++)
    {
        if (conteudoDoTexto[i] == totalTracks[cont]) 
        {
            nova += conteudoDoTexto[i+1]+'\n';
            cont++;
        }
    }
    Console.WriteLine($"Cont: {cont}");
    Console.WriteLine(nova);

    foreach (string str in nomesCorrigidos)
    {
        Console.WriteLine(str);
    }

    return "";
}

//for (int z = 0; i < totalTracks.Length; i++)
//{
//    if (conteudoDoTexto[z] == totalTracks[z])
//    {
//        nomesCorrigidos.Add(conteudoDoTexto[z + 1]);
//    }
//}