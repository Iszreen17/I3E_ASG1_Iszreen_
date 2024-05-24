using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DemoComponent : MonoBehaviour
{
    public bool booleanA = true;
    //int x = 10;
    //int y = 2;
    //int z = 3;
    // int t = 3;
    float moveSpeed = 0.2f;
    float rotationSpeed = 0.2f;

    //int QuickMath()
    //{
    // Debug.Log(x/y);
    // Debug.Log(x/y-y);
    // Debug.Log(x - x);
    // Debug.Log(x * x + y * y);
    // Debug.Log(x * x + y * x + x / y);
    // return x / y;
    // }

    Vector3 moveData = Vector3.zero;
    Vector3 rotationData = Vector3.zero;

    void OnMove(InputValue Value)
    {
        moveData = Value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        Vector2 data = value.Get<Vector2>();
        rotationData = new Vector3(0, data.x, 0);

    }
    // Update is called once per frame
    void Update()
    {
        var forwardDir = transform.forward;
        var rightDir = transform.right;

        transform.position += (forwardDir * moveData.y + rightDir * moveData.x) * moveSpeed;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationData * rotationSpeed);
    }


    void OnFire()
    { }

    //void OnIntCompare()
    //{
    //intCompare();
    // }

    // void OnLoopNums()
    //{
    //LoopNums();
    // }

    // void intCompare()
    //{
    // if (z > t)
    //  {
    //   Debug.Log(z);
    //    }
    //else if (z < t)
    //    {
    // Debug.Log(t);
    //   }
    //else
    //   {
    //  Debug.Log("number are equal");
    //  }
    //}
    //void LoopNums()
    // {
    //  string s = "";
    // for (int i = 1; i < 11; ++i)
    //   {   
    // s += i.ToString();

    //    }
    //  Debug.Log(s);

    //var f = 1;
    //do
    //    {
    // Debug.Log("Hello World");
    //f++;

    //   }
    //while (f <= 10);
    // }
    // Start is called before the first frame update
    void Start()
    {
        //  QuickMath();
        // OnIntCompare();
        //  OnLoopNums();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            Debug.Log("Collectible" + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "NegativeItem")
        {
            Debug.Log("Negative" + collision.gameObject.name);
        }


    }



}

