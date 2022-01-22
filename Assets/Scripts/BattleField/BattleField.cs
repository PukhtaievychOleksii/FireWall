using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour
{
    public GameObject BattleCursor;

    private Color InitialCursorColor;
    void Start()
    {
        BattleCursor.SetActive(false);   
        DataHolder.SetBattleField(this);
        InitialCursorColor = BattleCursor.GetComponent<SpriteRenderer>().color;
        
    }

    void Update()
    {
        Vector2 CursorPos = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        CursorPos = new Vector2(CursorPos.x, CursorPos.y);
        BattleCursor.transform.position = CursorPos;
    }

    private void OnMouseOver()
    {
        DataHolder.Cannon.FollowMouse();
    }
    private void OnMouseEnter()
    {
        DataHolder.Cannon.CanShoot = true;
        Cursor.visible = false;
        BattleCursor.SetActive(true);
        SetCursorUnAimed();
        
        
    }
    private void OnMouseExit()
    {
        DataHolder.Cannon.CanShoot = false;
        UnityEngine.Cursor.visible = true;
        BattleCursor.SetActive(false);
    }


    public void SetCursorAimed()
    {
        
        BattleCursor.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        BattleCursor.GetComponent<SpriteRenderer>().color = Color.red;
    }
    public  void SetCursorUnAimed()
    {
        
        BattleCursor.GetComponent<SpriteRenderer>().color = InitialCursorColor;
        BattleCursor.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
