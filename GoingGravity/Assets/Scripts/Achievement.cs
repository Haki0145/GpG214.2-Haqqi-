using UnityEngine;

public class Achievement : MonoBehaviour
{
    public float timeLimit = 30f;
    public GameObject unlockPanel;

    [SerializeField]private Timer timer;

    public Unlockable UnlockManager;

   


    public void CheckAchievementConditions()
    {

        Debug.Log(timer.enabled);
        Debug.Log(UnlockManager.enabled);

        if (timer.ElapsedTime <= timeLimit && !UnlockManager.isUnlocked)
        {
            unlockPanel.SetActive(true);
            UnlockManager.isUnlocked = true;
            UnlockManager.unlockFile.isUnlocked = true;
            UnlockManager.Save();
        }
    }
}




