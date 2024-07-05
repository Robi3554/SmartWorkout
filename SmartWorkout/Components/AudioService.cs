using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AudioService
{
    public List<string> FilesList { get; private set; } = new List<string>();
    public string CurrentAudio { get; private set; }
    public string CurrentAudioName { get; private set; }
    private int currentIndex = -1;

    public void LoadAudioFiles(string path)
    {
        if (FilesList.Count == 0)
        {
            var files = Directory.GetFiles(path, "*.mp3");
            FilesList.AddRange(files.Select(Path.GetFileName));
        }
    }

    public void PlayAudio(string fileName)
    {
        currentIndex = FilesList.IndexOf(fileName);
        SetCurrentAudio(fileName);
    }

    public void PlayNextAudio()
    {
        if (FilesList.Count == 0)
        {
            return;
        }

        currentIndex = (currentIndex + 1) % FilesList.Count;
        SetCurrentAudio(FilesList[currentIndex]);
    }

    private void SetCurrentAudio(string fileName)
    {
        CurrentAudio = "/audio/" + fileName;
        CurrentAudioName = fileName.Split('.')[0];
    }
}
