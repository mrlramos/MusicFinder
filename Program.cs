// Substitua pelo caminho real da pasta e do arquivo TXT.
string folderPath = @"D:\Downloads\Downloads-FullQuality\Soundeo\Peak-Soundeo";
string txtFilePath = @"C:\Users\marlo\Desktop\testepsytrance.txt";

string fomatedFile = ClearFile(txtFilePath);
string[] fomatedFileFileNames = fomatedFile.Split("\n");

List<string> fileNames = GetFileNames(folderPath);

Console.WriteLine($"Quantidade de arquivos na pasta: {folderPath}");
Console.WriteLine($"{fileNames.Count}\n\n");

List<string> containedFileNames = CheckFilesInTxt(fomatedFileFileNames, fileNames);



static string ClearFile(string txtContent)
{
    string newFile = "";
    var textContent = File.ReadAllText(txtContent).Split("\n");
    int cont = 0;

    string[] totalTracks = new string[190];
    List<string> fixNames = new List<string>();

    //Creating an array to numbers of tracks
    for (int i = 0; i < totalTracks.Length; i++)
    {
        totalTracks[i] = (i + 1) + "\r";
    }

    for (int i = 0; i < textContent.Length; i++)
    {
        if (textContent[i] == totalTracks[cont])
        {
            newFile += textContent[i + 1] + '\n';
            cont++;
        }
    }
    Console.WriteLine($"Cont: {cont}");

    return newFile;
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

static List<string> CheckFilesInTxt(string[] txtFilePath, List<string> fileNames)
{
    List<string> containedFileNames = new List<string>();
    List<string> notContainedFileNames = new List<string>();

    int itensEncontrados = 0;

    // Verifica se cada nome de arquivo está contido no conteúdo do arquivo TXT.
    foreach (string fileName in txtFilePath)
    {
        bool found = false; // Variável para indicar se o arquivo foi encontrado.
        foreach (string file in fileNames)
        {
            if (fileName.Contains(file))
            {
                containedFileNames.Add(fileName);
                itensEncontrados++;
                found = true;
                break; // Sai do loop interno, pois o arquivo já foi encontrado.
            }
        }

        // Se o arquivo não foi encontrado, adiciona à lista de não encontrados.
        if (!found)
        {
            notContainedFileNames.Add(fileName);
        }
    }

    Console.WriteLine($"Itens encontrados: {itensEncontrados}\n\n");

    // Imprime os itens não encontrados.
    Console.WriteLine("Itens não encontrados:");
    foreach (string fileName in notContainedFileNames)
    {
        Console.WriteLine(fileName);
    }

    return containedFileNames;
}




//for (int z = 0; i < totalTracks.Length; i++)
//{
//    if (conteudoDoTexto[z] == totalTracks[z])
//    {
//        nomesCorrigidos.Add(conteudoDoTexto[z + 1]);
//    }
//}