using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int collectableCount = 0;

    // Update is called once per frame
    public void AddCollectable()
    {
        collectableCount++;
    }
}
