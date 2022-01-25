using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour
{
    public GameObject BattleCursorObject;
    public Vector3 CursorSpawnPosition;
    private Color InitialCursorColor;
    void Start()
    {
        BattleCursorObject.SetActive(false);
        BattleCursorObject.transform.position = CursorSpawnPosition;
        DataHolder.SetBattleField(this);
        InitialCursorColor = BattleCursorObject.GetComponent<SpriteRenderer>().color;

    }

    void Update()
    {
        Vector2 CursorPos = DataHolder.MainCamera.ScreenToWorldPoint(Input.mousePosition);
       // CursorPos = new Vector2(CursorPos.x, CursorPos.y);
        BattleCursorObject.transform.position = CursorPos;
    }

    private void OnMouseOver()
    {
        DataHolder.Cannon.FollowMouse();
    }
    private void OnMouseEnter()
    {
        DataHolder.Cannon.CanShoot = true;
        EnableBattleCursor();
        SetCursorUnAimed();


    }
    private void OnMouseExit()
    {
        DataHolder.Cannon.CanShoot = false;
        DisableBattleCursor();
    }


    public void SetCursorAimed()
    {

        BattleCursorObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        BattleCursorObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    public void SetCursorUnAimed()
    {

        BattleCursorObject.GetComponent<SpriteRenderer>().color = InitialCursorColor;
        BattleCursorObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void EnableBattleCursor()
    {
        BattleCursorObject.SetActive(true);
        Cursor.visible = false;
    }

    public void DisableBattleCursor()
    {
        BattleCursorObject.SetActive(false);
        Cursor.visible = true;
    }

    public void RestartCursor()
    {
        Vector3 pos = BattleCursorObject.transform.position;
        BattleCursorObject.transform.position = CursorSpawnPosition;
        BattleCursorObject.transform.position = pos;
    }
}
