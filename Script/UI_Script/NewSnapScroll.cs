using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSnapScroll : MonoBehaviour
{
    [Header("Handler")]
    public GameObject R_Handler;
    public int ClickCount;

    //[Range(1, 50)]
    [Header("Controllers")]

    [Range(0, 500)]
    public int panOffset; // object's between distance

    [Range(0f, 20f)]
    public float snapSpeed;

    [Range(0f, 5f)]
    public float scaleOffset;

    [Range(1f, 20f)]
    public float scaleSpeed;

    [Header("Other Objects")]


    public ScrollRect scrollRect;//use to know the scrolling speed


    public GameObject[] instPans;
    public Vector2[] pansPos;
    private Vector2[] pansScale;
    public Vector2 testScale;

    public RectTransform contentRect;
    private Vector2 contentVector;//use to move the nearest obj to middle

    public int selectedPanID;
    public bool isScrolling;

    public Vector2 contentPos;// use to change contentPos


    // Start is called before the first frame update
    private void Start()
    {

        //obj's location array
        pansPos = new Vector2[instPans.Length];

        //get the "content" rectTransform , in order to  find the anchoredPosition
        contentRect = GetComponent<RectTransform>();

        //obj's scale array
        pansScale = new Vector2[instPans.Length];

        for (int i = 0; i < instPans.Length; i++)
        {

            //setting obj's location , first obj no need,so if i=0 than continue
            if (i == 0) continue;
            instPans[i].transform.localPosition = new Vector2(instPans[i - 1].transform.localPosition.x + instPans[i - 1].GetComponent<RectTransform>().sizeDelta.x + panOffset,
                                                                instPans[i].transform.localPosition.y);

            pansPos[i] = -instPans[i].transform.localPosition; // obj's position.x is equal to "content" position.x _negative value , so add a negative symbol


        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //prevent scroll over the view/////
        if (contentRect.anchoredPosition.x >= pansPos[0].x && !isScrolling || contentRect.anchoredPosition.x <= pansPos[pansPos.Length - 1].x && !isScrolling)
        {
            scrollRect.inertia = false;
        }

        /////////Check Button/////////////////

        ClickCount = R_Handler.GetComponent<ClickHandler>().ClickCount;


        contentPos = this.transform.localPosition;
        contentPos.x = Mathf.SmoothStep(contentPos.x, -instPans[ClickCount].transform.localPosition.x + 398.0584f, scaleSpeed * Time.fixedDeltaTime);
        //contentPos.x = -instPans[ClickCount].transform.localPosition.x + 398.0584f;
        this.transform.localPosition = contentPos;


        ////////////////////////////////////////////////// 

        float nearstPos = float.MaxValue; //use to find the obj who is the most close to the middle of "content" 

        for (int i = 0; i < instPans.Length; i++)
        {
            //find the distance from middle to obj
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);

            if (distance < nearstPos)
            {
                nearstPos = distance;
                selectedPanID = i;
            }

        }

        //Restrict the inertia if the scrolling speed too quick
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;

        //let the nearest obj to set to the middle
        if (isScrolling || scrollVelocity > 400) return; //when scrolling , dont work
        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll; //whether scrolling
        if (scroll) scrollRect.inertia = true;
    }


}
