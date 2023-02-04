using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddd : MonoBehaviour
{
    public Transform rect;

    public bool isMoving = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isMoving = true;
            Debug.Log("a");
        }

        if (isMoving)
        {
            Vector2.Lerp(transform.position, rect.position, 2f*Time.deltaTime);
        }
    }
}
