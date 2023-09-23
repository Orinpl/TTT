using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public LayerMask grideLayerMask; // 用于指定射线检测的层级
    public Gride curGride;
    // Start is called before the first frame update
    void Start()
    {
        grideLayerMask = LayerMask.GetMask("Gride");
    }

    // Update is called once per frame
    void Update()
    {
        mouseInput();
    }

    public void mouseInput()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, grideLayerMask);
        if (hit.collider != null)
        {
            GameObject gameObject = hit.collider.gameObject;
            Gride gride = gameObject.GetComponent<Gride>();
            if(gride!=curGride)
            {
                //Debug.Log("Hit object with tag: " + hit.collider.tag);
                curGride?.onExit();
                curGride = gride;
                curGride.onPoint();
            }
            if (Input.GetMouseButtonDown(0))
            {
                if(GameManager.Instance.isWin||GameManager.Instance.isDraw)
                {
                    return;
                }
                curGride.onClick();
            }
        }
        else
        {
            curGride?.onExit();
            curGride = null;
        }

    }

}
