using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMotion : MonoBehaviour
{

    private GameObject ObjectToMove;
    public string Axis;
    public float Distance;
    public float Speed;
    private Vector3 Direction;
    private float Sign;
    private float DeltaPos;

    private Vector3 DestinationP;
    private Vector3 DestinationN;
    // Start is called before the first frame update
    void Start()
    {
        Sign = 1;

        if(Axis == "X")
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

        DestinationP = Distance * Direction;
        DestinationN = this.GetComponent<Transform>().position;  //-1 * Distance * Direction;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, DestinationP + DestinationN, Speed * 0.001f);
        if (Vector3.Distance(transform.position,DestinationP + DestinationN) < 0.001f)
        {
            // Swap the position of the cylinder.
            DestinationP *= -1.0f;
        }

    }
}
