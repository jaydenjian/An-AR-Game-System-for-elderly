using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class ClickHandler_Another : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int ClickCount = 0;

    public bool Handler_Click;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickCount = 0;
        Handler_Click = true;

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ClickCount--;
        Handler_Click = false;
    }
}
