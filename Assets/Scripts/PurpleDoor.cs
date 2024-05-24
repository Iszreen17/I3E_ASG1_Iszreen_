using System.Collections;
using UnityEngine;

public class PurpleDoor : MonoBehaviour
{
    bool opened = false;
    public float closeDelay = 0.2f;
    public int requiredScore = 30;

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
        Debug.Log("Opening door.");

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
        Debug.Log("Starting close door coroutine.");

        // Wait for the specified delay
        yield return new WaitForSeconds(closeDelay);

        CloseDoor();
    }

    /// <summary>
    /// Handles door closing
    /// </summary>
    void CloseDoor()
    {
        Debug.Log("Closing door.");

        Vector3 newRotation = transform.eulerAngles;
        newRotation.y -= 90f;
        transform.eulerAngles = newRotation;

        opened = false;
    }
}
