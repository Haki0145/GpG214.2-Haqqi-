using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class Unlockable : MonoBehaviour
{
    public GameObject Timer;

    public GameObject unlockPanel;
    public GameObject player;
    private SpriteRenderer playerRenderer;

    public string fileName;
    public string path;
    public UnlockJson unlockFile;
    public bool isUnlocked = false;

    

    void Start()
    {
        playerRenderer = player.GetComponent<SpriteRenderer>();
        unlockFile = new UnlockJson();
        unlockFile.isUnlocked = false;

        path = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(path))
        {
            Load();
        }
        else
        {
            Save();
        }
    }


    public void ChooseGreen()
    {
        playerRenderer.color = Color.green;
        unlockPanel.SetActive(false);
        Timer.SetActive(true);
    }

    public void ChooseYellow()
    {
        playerRenderer.color = Color.yellow;
        unlockPanel.SetActive(false);
        Timer.SetActive(true);
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(unlockFile);
        File.WriteAllText(path, json);
    }

    public void Load()
    {
        string fileContent = File.ReadAllText(path);
        unlockFile = JsonUtility.FromJson<UnlockJson>(fileContent);
        unlockPanel.SetActive(unlockFile.isUnlocked);

        Timer.SetActive(!unlockFile.isUnlocked);
    }
}



