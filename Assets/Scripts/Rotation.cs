using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public string Axis;
    public float rate;
    private Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        if (Axis == "X")
        {
            Direction = new Vector3(1, 0, 0);
        }
        else if (Axis == "Y")
        {
            Direction = new Vector3(0, 1, 0);
        }
        else if (Axis == "Z")
        {
            Direction = new Vector3(0, 0, 1);
        }

        else
        {
            Direction = new Vector3(0, 0, 0);
            Debug.Log("Axis input is invalid");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Direction * rate * 0.1f);
    }
}
