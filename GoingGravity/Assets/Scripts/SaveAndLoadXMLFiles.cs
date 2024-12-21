using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoadXMLFiles : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private PlayerStats P_stats = new PlayerStats();

    public string playerSaveFile;
    public string folderPath;
    public string combinedFilePath;

    private void Start()
    {
        folderPath = Application.streamingAssetsPath;
        combinedFilePath = Path.Combine(folderPath, playerSaveFile);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            loadPlayerXml();
            loadPlayerPosition();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            savePlayerData();
            savePlayerXml();
        }
    }

    private void savePlayerData()
    {
        P_stats.playerName = player.transform.name;
        P_stats.playerHealth = 5f;
        P_stats.playerPosition = player.transform.position;
    }

    private void savePlayerXml()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerStats));

        using (StreamWriter sw = new StreamWriter(combinedFilePath))
        {
            serializer.Serialize(sw, P_stats);
            Debug.Log("Saving player data");
        }
    }

    private void loadPlayerXml()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerStats));

        using (StreamReader reader = new StreamReader(combinedFilePath))
        {
            P_stats = (PlayerStats)serializer.Deserialize(reader);
            Debug.Log("Loading Player Data");
        }
    }

    private void loadPlayerPosition()
    {
        XmlDocument document = new XmlDocument();
        document.Load(combinedFilePath);

        XmlNode position = document.SelectSingleNode("/PlayerStats/playerPosition");

        if (position != null)
        {
            string xNode = position.SelectSingleNode("x")?.InnerText;
            string yNode = position.SelectSingleNode("y")?.InnerText;
            string zNode = position.SelectSingleNode("z")?.InnerText;

            setPlayerPosition(xNode, yNode, zNode);
        }
        else
        {
            Debug.Log("error");
        }
    }

    private void setPlayerPosition(string x, string y, string z)
    {
        Vector3 savedPosition = new Vector3(float.Parse(x), float.Parse(y), float.Parse(z));
        player.transform.position = savedPosition;
        P_stats.playerPosition = savedPosition;
    }
}


