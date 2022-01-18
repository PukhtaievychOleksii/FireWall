using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float MovingSpeed;
    private float LerpIndex = 0.1f;
    public Vector3 Destination;
    public bool IShouldMove = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(IShouldMove && Destination != null && !PauseGame.GameIsPoused)
        {            
            transform.position = Vector3.MoveTowards(transform.position,Vector3.Lerp(transform.position,Destination,LerpIndex),MovingSpeed);
            if (transform.position == Destination)
            {
                IShouldMove = false;
            }
        }
    }

    
}
