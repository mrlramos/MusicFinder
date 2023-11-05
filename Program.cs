// Main method

string folderPath = @"D:\Downloads\Downloads-FullQuality\Soundeo\Peak-Soundeo";
string txtFilePath = @"C:\Users\marlo\Desktop\testepsytrance.txt";
int trackNumber = 190;

List<string> fileNames = GetFileNames(folderPath);

Console.WriteLine($"Numbers of files(.wav) in the local folder: {fileNames.Count}");

string fomatedFile = ClearTextFileFromBeatport(txtFilePath, trackNumber);
string[] fomatedFileFileNames = fomatedFile.Split("\n");

CheckFilesInTxt(fomatedFileFileNames, fileNames);

//
// Methods
//

static string ClearTextFileFromBeatport(string txtContent, int trackNumber)
{
    string newFile = "";
    var textContent = File.ReadAllText(txtContent).Split("\n");
    int cont = 0;

    string[] totalTracks = new string[trackNumber];

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
    Console.WriteLine($"Songs taken from Beatport playlist: {cont}");

    return newFile;
}

static List<string> GetFileNames(string folderPath)
{
    List<string> fileNames = new();
    DirectoryInfo directory = new(folderPath);
    FileInfo[] files = directory.GetFiles();

    foreach (FileInfo file in files)
    {
        if (!file.Name.Contains(".ps1")) //Ignore a not track file
        {
            var tratamentoNome = file.Name.Split("- ");
            tratamentoNome = tratamentoNome[1].Split(".wav");
            tratamentoNome = tratamentoNome[0].Split(" (");
            fileNames.Add(tratamentoNome[0]);
        }
    }

    return fileNames;
}

static void CheckFilesInTxt(string[] txtFilePath, List<string> fileNames)
{
    List<string> containedFileNames = new();
    List<string> notContainedFileNames = new();

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

    Console.WriteLine($"\n\nItems from Beatport's txtFile found in the local folder: {itensEncontrados}\n");

    // Imprime os itens não encontrados.
    Console.WriteLine("Items not found:");
    foreach (string fileName in notContainedFileNames)
    {
        Console.WriteLine(fileName);
    }
}