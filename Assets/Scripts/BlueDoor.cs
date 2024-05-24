using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour
{
   bool opened = false;
   public float closeDelay = 0.5f;
    public int requiredScore = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !opened)
        {   
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null && player.CurrentScore >= requiredScore)
            {
                OpenDoor();
            }
            
        }
    }

    /// <summary>
    /// Handles door opening 
    /// </summary>
    void OpenDoor()
    {
        Vector3 newRotation = transform.eulerAngles;

        newRotation.y += 90f;

        transform.eulerAngles = newRotation;

        opened = true;

        // Start the coroutine to close the door after a delay
        StartCoroutine(CloseDoorAfterDelay());
    }

    /// <summary>
    /// Coroutine to handle door closing after a delay
    /// </summary>
    IEnumerator CloseDoorAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(closeDelay);

        CloseDoor();
    }

    /// <summary>
    /// Handles door closing
    /// </summary>
    void CloseDoor()
    {
        Vector3 newRotation = transform.eulerAngles;

        newRotation.y -= 90f;

        transform.eulerAngles = newRotation;

        opened = false;
    }
}
