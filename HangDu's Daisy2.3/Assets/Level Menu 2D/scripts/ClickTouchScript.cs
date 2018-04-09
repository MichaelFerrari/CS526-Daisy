using UnityEngine;
using System.Collections;

public class ClickTouchScript : MonoBehaviour
{

    private Vector2 downPos, upPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;



            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == this.gameObject.name)
            {
                Debug.Log(this.gameObject.name + " touched");
                GameObject touchObject = hit.transform.gameObject;

                // Detect which of the Menu's object is this
                //LevelMenu2D.I.autoActivateMenu(this.gameObject);

                if (LevelMenu2D.I.isMoving)
                    return;

                if (LevelMenu2D.I.isBounded == false)
                {
                    if (LevelMenu2D.I.showNextBackButtons && touchObject.name.Equals(LevelMenu2D.I.nextButtonObject.name))
                    {
                        LevelMenu2D.I.gotoNextItem();
                    }
                    else if (LevelMenu2D.I.showNextBackButtons && touchObject.name.Equals(LevelMenu2D.I.backButtonObject.name))
                    {
                        LevelMenu2D.I.gotoBackItem();
                    }
                    else
                    {
                        if (LevelMenu2D.I.CurrentItem == LevelMenu2D.I.indexOf(touchObject))
                        {
                            LevelMenu2D.I.dispatchCurrentItemClick(LevelMenu2D.I.CurrentItem, touchObject);
                        }
                        else LevelMenu2D.I.gotoItem(touchObject);
                    }
                }
                else
                {
                    LevelMenu2D.I.dispatchCurrentItemClick(LevelMenu2D.I.indexOf(touchObject), touchObject);
                }
            }
        }

    }

    void OnMouseDown()
    {
        //Debug.Log("MouseDown");
        downPos = (Vector2)Input.mousePosition;
    }

    void OnMouseUp()
    {
        upPos = (Vector2)Input.mousePosition;

        // Detect which of the Menu's object is this
        //LevelMenu2D.I.autoActivateMenu(this.gameObject);

        if (LevelMenu2D.I.isMoving)
            return;

        //Debug.Log("MouseUp");
        if (LevelMenu2D.I.isBounded == false)
        {
            if (LevelMenu2D.I.showNextBackButtons && this.name.Equals(LevelMenu2D.I.nextButtonObject.name))
            {
                LevelMenu2D.I.gotoNextItem();
                //LevelMenu2D.I.gotoItem(LevelMenu2D.I.CurrentItem+1);
            }
            else if (LevelMenu2D.I.showNextBackButtons && this.name.Equals(LevelMenu2D.I.backButtonObject.name))
            {
                LevelMenu2D.I.gotoBackItem();
                //LevelMenu2D.I.gotoItem(LevelMenu2D.I.CurrentItem-1);
            }
            else
            {
                if (LevelMenu2D.I.CurrentItem == LevelMenu2D.I.indexOf(this.gameObject) && upPos == downPos)
                {
                    LevelMenu2D.I.dispatchCurrentItemClick(LevelMenu2D.I.CurrentItem, this.gameObject);
                }
                //LevelMenu2D.I.gotoItem(LevelMenu2D.I.itemsList.IndexOf(this.gameObject));
                else LevelMenu2D.I.gotoItem(this.gameObject);
            }
        }
        else
        {
            if (upPos == downPos)
            {
                LevelMenu2D.I.dispatchCurrentItemClick(LevelMenu2D.I.indexOf(this.gameObject), this.gameObject);
            }
        }
    }
}
