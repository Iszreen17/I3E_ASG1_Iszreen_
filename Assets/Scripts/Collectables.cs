using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collectables : MonoBehaviour
{
    int myScore = 5;

    void Start()
    {

    }

    void GetCollected()
    {
        Debug.Log("I got colected");
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {   
        //check if the object that touched me has a "player" tag
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.gameObject.GetComponent<Player>().IncreaseScore(myScore);
            GetCollected();
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("something is not touching me");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("something is touching me");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something enter the area");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("something left the area");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("something is still in the area");
    }

    private void Update()
    {

    }










}

