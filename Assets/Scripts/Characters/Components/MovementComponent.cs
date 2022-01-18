using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float MovingSpeed;
    public Vector3 Destination;
    public bool IShouldMove = false;
    public GameObject Owner;
    void Start()
    {
        Owner = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(IShouldMove && VariablesFilled() && !PauseGame.GameIsPoused)
        {
            Owner.transform.position = Vector3.MoveTowards(Owner.transform.position, Destination,MovingSpeed);
            if (Owner.transform.position == Destination) IShouldMove = false;
        }
    }

    private bool VariablesFilled()
    {
        if (Destination == null || Owner == null) return false;
        return true;
    }
}
