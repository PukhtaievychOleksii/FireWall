using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public Game Game;
    [HideInInspector]
    public GameObject CharacterGameObject;
    [HideInInspector]
    public MovementComponent MovementComponent;
    // Start is called before the first frame update
   
    public  Character()
    {

    }
    void Awake()
    {
        MovementComponent = this.gameObject.GetComponent<MovementComponent>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTo(Vector3 desination)
    {
        MovementComponent.IShouldMove = true;
        MovementComponent.Destination = desination;
    }


}
