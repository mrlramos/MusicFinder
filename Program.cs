// Main method

string folderPath = @"D:\Downloads\Downloads-FullQuality\Soundeo\Peak-Soundeo";
string txtFilePath = @"C:\Users\marlo\Desktop\testepsytrance.txt";
int trackNumber = 190;

List<string> fileNamesLocalFolder = GetFileNamesInTheLocalFolder(folderPath);

Console.WriteLine($"Numbers of files(.wav) in the local folder: {fileNamesLocalFolder.Count}");

string cleanTextFromBeatport = ClearTextFileFromBeatport(txtFilePath, trackNumber);
string[] arrCleanTextFromBeatport = cleanTextFromBeatport.Split("\n");

CheckTracks(arrCleanTextFromBeatport, fileNamesLocalFolder);

//
// Methods
//

static string ClearTextFileFromBeatport(string txtContent, int trackNumber)
{
    string newFile = "";
    var textContent = File.ReadAllText(txtContent).Split("\n");
    int cont = 0;

    string[] totalTracks = new string[trackNumber];

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

static List<string> GetFileNamesInTheLocalFolder(string folderPath)
{
    List<string> fileNames = new();
    DirectoryInfo directory = new(folderPath);
    FileInfo[] files = directory.GetFiles();

    foreach (FileInfo file in files)
    {
        if (!file.Name.Contains(".ps1")) //Ignore a not track file
        {
            var nameTreat = file.Name.Split("- ");
            nameTreat = nameTreat[1].Split(".wav");
            nameTreat = nameTreat[0].Split(" (");
            fileNames.Add(nameTreat[0]);
        }
    }

    return fileNames;
}

static void CheckTracks(string[] arrCleanTextFromBeatport, List<string> fileNamesLocalFolder)
{
    List<string> containedFileNames = new();
    List<string> notContainedFileNames = new();

    int foundItems = 0;

    foreach (string fileName in arrCleanTextFromBeatport)
    {
        bool found = false; 
        foreach (string file in fileNamesLocalFolder)
        {
            if (fileName.Contains(file))
            {
                containedFileNames.Add(fileName);
                foundItems++;
                found = true;
                break; 
            }
        }

        if (!found)
        {
            notContainedFileNames.Add(fileName);
        }
    }

    Console.WriteLine($"\n\nItems from Beatport's txtFile found in the local folder: {foundItems}\n");

    Console.WriteLine("Items not found:");
    foreach (string fileName in notContainedFileNames)
    {
        Console.WriteLine(fileName);
    }
}