string path = args[0];
string files = args[1];
string searchText = args[2];

var datas = Directory.GetFiles(path, files);

foreach (var data in datas)
{
    if (File.ReadAllText(data).Contains(searchText))
    {
        System.Console.WriteLine(data);
    }
}

//foreach (var file in files)
//{
//    string[] lines = File.ReadAllLines(files);
//
//    for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
//    {
//        string line = lines[lineNumber];
//
//        if (line.Contains(searchText))
//        {
//            Console.WriteLine(file);
//            Console.WriteLine($"{lineNumber + 1}: {line}");
//        }
//    }
//}

int totalFoundFiles = 0;
int totalFoundLines = 0;
int totalOccurrences = 0;

foreach (var file in files)
{
    string[] lines = File.ReadAllLines(files);

    bool fileContainsText = false;
    int foundLinesInFile = 0;
    int occurrencesInFile = 0;

    for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
    {
        string line = lines[lineNumber];

        if (line.Contains(searchText))
        {
            Console.WriteLine(file);
            Console.WriteLine($"{lineNumber + 1}: {line}");

            foundLinesInFile++;
            occurrencesInFile += CountOccurrences(line, searchText);
        }
    }

    if (foundLinesInFile > 0)
    {
        totalFoundFiles++;
        totalFoundLines += foundLinesInFile;
        totalOccurrences += occurrencesInFile;
    }
}

Console.WriteLine("SUMMARY: ");
Console.WriteLine($"Number of found files: {totalFoundFiles}");
Console.WriteLine($"Number of found lines: {totalFoundLines}");
Console.WriteLine($"Number of occurrences: {totalOccurrences}");


int CountOccurrences(string text, string searchText)
{
    int count = 0;
    int index = 0;

    while ((index = text.IndexOf(searchText, index)) != -1)
    {
        count++;
        index += searchText.Length;
    }
    return count;
}




