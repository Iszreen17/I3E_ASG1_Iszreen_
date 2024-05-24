using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject messageBox;
    public float messageDuration = 0.5f; // Time in seconds the message box should be visible

    int currentScore = 0;
    private bool hasMessageBoxShown = false;

    public int CurrentScore
    {
        get { return currentScore; }
    }
    public void IncreaseScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        Debug.Log(currentScore);
        scoreText.text = currentScore.ToString();

        if (!hasMessageBoxShown)
        {
            messageBox.SetActive(true);
            hasMessageBoxShown = true;
        }


        // Start the coroutine to hide the message box after a delay
        StartCoroutine(HideMessageBoxAfterDelay());
    }

    private IEnumerator HideMessageBoxAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        messageBox.SetActive(false);
    }
}
