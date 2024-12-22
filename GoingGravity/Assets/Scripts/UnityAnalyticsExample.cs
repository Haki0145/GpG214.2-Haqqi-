using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;

public class UnityAnalyticsExample : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return UnityServices.InitializeAsync();

        AnalyticsService.Instance.StartDataCollection();

        //AnalyticsService.Instance.StopDataCollection();

        //AnalyticsService.Instance.RequestDataDeletion();

    CustomEvent OnPlayerDeath = new CustomEvent("playerDeaths")
    {
        {"playerDeaths", 1},
        {"playerDeathPosition", transform.position.ToString() }
    };



        AnalyticsService.Instance.RecordEvent(OnPlayerDeath);
        Debug.Log("On on player Deaths called");
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class GameEvents
{
    public static CustomEvent OnPlayerDeath = new CustomEvent("playerDeaths")
    {
        {"playerDeaths", 1}
    };

    public static CustomEvent OnStartUpEvent = new CustomEvent("StartUpInformation")
        {
            { "Devicetype", SystemInfo.deviceType.ToString() },
            {"DevicePlatform", Application.platform.ToString() }
        };
}



