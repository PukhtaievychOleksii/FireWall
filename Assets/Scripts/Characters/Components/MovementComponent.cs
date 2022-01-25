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
        if(IShouldMove && VariablesFilled() && !PauseGame.GameIsPaused)
        {
            if(gameObject.GetComponent<Wizzard>() != null)
            {
                Owner.transform.position = Vector3.MoveTowards(Owner.transform.position, Vector3.Lerp(Owner.transform.position, Destination, 0.065f),MovingSpeed / 50);
            }
            else if (Destination.x < Owner.transform.position.x)
            {
                Owner.transform.position = new Vector3(Owner.transform.position.x - Time.deltaTime * MovingSpeed, Owner.transform.position.y);
                if (Owner.transform.position.x <= Destination.x) IShouldMove = false;
            }
            else 
            {
                Owner.transform.position = new Vector3(Owner.transform.position.x + Time.deltaTime * MovingSpeed, Owner.transform.position.y);
                if (Owner.transform.position.x >= Destination.x) IShouldMove = false;
            }
            //Vector3.MoveTowards(Owner.transform.position, Destination,MovingSpeed);
        }
    }

    private bool VariablesFilled()
    {
        if (Destination == null || Owner == null) return false;
        return true;
    }
}
