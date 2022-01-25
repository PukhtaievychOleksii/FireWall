using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCursor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.gameObject.GetComponent<Virus>() != null)
        {
            DataHolder.BattleField.SetCursorAimed();
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Virus>() != null)
        {
            DataHolder.BattleField.SetCursorUnAimed();
        }
    }
}
