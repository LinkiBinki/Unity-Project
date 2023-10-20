using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KameraMovement : MonoBehaviour
{
    void Start()
    {

    }

    public Transform head; 

    void Update()
    {
        if (head != null)
        {
            Vector3 cameraPosition = new Vector3(head.position.x, head.position.y, head.position.z);
            transform.position = cameraPosition;
        }
    }
}
