using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableData 
{
    public string unlockableFolder;
    public string unlockableID;
    public bool isUnlocked;
    public bool hasPreviousleyBeenDisplayed;


    public void Unlock()
    {
        isUnlocked = true;
    }

    public void UpdateHasBeenDisplayed()
    {
        hasPreviousleyBeenDisplayed = true;
    }

   
}
