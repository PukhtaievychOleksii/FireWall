using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour
{
    public GameObject BattleCursorObject;
    public Animator[] CursorAnimator;
    public List<SpriteRenderer> CursorRenderers;


    private Color InitialCursorColor;
    void Start()
    {
        BattleCursorObject.SetActive(false);
        DataHolder.SetBattleField(this);
        InitialCursorColor = CursorRenderers[0].color;

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
        for (int i = 0; i < 4; i++)
        {
            //CursorAnimator[i].SetTrigger("off");
            CursorAnimator[i].SetBool("active", true);
        }
        //BattleCursor.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        BattleCursorObject.GetComponent<SpriteRenderer>().color = Color.red;
        foreach(SpriteRenderer renderer in CursorRenderers)
        {
            renderer.color = Color.red;
        }
    }


    public void SetCursorUnAimed()
    {
        for (int i = 0; i < 4; i++)
        {
            //CursorAnimator[i].SetTrigger("off");
            CursorAnimator[i].SetBool("active", false);
        }
        //BattleCursorObject.GetComponent<SpriteRenderer>().color = DataHolder.BattleField.InitialCursorColor;
        foreach (SpriteRenderer renderer in CursorRenderers)
        {
            renderer.color = InitialCursorColor;
        }

    }
    public void EnableBattleCursor()
    {
        //Cursor.visible = false; 
        BattleCursorObject.SetActive(true);
        
    }

    public void DisableBattleCursor()
    {
        BattleCursorObject.SetActive(false);
        //Cursor.visible = true;
    }

    public void RestartCursor()
    {
        for (int i = 0; i < 4; i++)
	{	
            //CursorAnimator[i].SetTrigger("off");
            CursorAnimator[i].SetBool("active", false);
        }
        BattleCursorObject.GetComponent<SpriteRenderer>().color = InitialCursorColor;
        //BattleCursor.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
