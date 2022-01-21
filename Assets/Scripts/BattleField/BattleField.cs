using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour
{
    public GameObject BattleCursor;
    private float BattleCursorSizeX;
    private float BattleCursorSizeY;
    void Start()
    {
        BattleCursor.SetActive(false);
        SpriteRenderer Renderer = BattleCursor.GetComponent<SpriteRenderer>();
        BattleCursorSizeX = Renderer.sprite.bounds.size.x;
        BattleCursorSizeY = Renderer.sprite.bounds.size.y;
        
    }

    void Update()
    {
        Vector2 CursorPos = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        CursorPos = new Vector2(CursorPos.x /*+ BattleCursorSizeX / 2*/, CursorPos.y /*+ BattleCursorSizeY / 2*/);
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
        
    }
    private void OnMouseExit()
    {
        DataHolder.Cannon.CanShoot = false;
        Cursor.visible = true;
        BattleCursor.SetActive(false);
    }
}
