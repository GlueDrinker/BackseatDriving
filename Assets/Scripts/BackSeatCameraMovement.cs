using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSeatCameraMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z"))
        {
            transform.localPosition = new Vector3(-2f, 0.56f);
        }
        else if (Input.GetKey("x"))
        {
            transform.localPosition = new Vector3(2f, 0.56f);
        }
        else transform.localPosition = new Vector3(0f, 0.56f);
    }
}
