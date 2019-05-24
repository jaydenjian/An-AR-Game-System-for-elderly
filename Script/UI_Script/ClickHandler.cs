using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int ClickCount;
    public int PreventDuplicate_ClickCopunt;

    public GameObject[] ButtonArray;

    public GameObject AnotherHandler;
    public bool Handler_Click;
    public bool AnotherHandlerState;
    public int AnotherHandlerClickCount;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        AnotherHandlerClickCount = AnotherHandler.GetComponent<ClickHandler_Another>().ClickCount;

        AnotherHandlerState = AnotherHandler.GetComponent<ClickHandler_Another>().Handler_Click;


        ComputeClickCount();

        if (ClickCount < 0)
        {
            ClickCount = ButtonArray.Length - 1;

        }

        if (ClickCount > ButtonArray.Length - 1)
        {
            ClickCount = 0;
        }

        /**********************  This Part was disable the front & back button Selected animation  *************************/


        //////////the Last button situtation//////////////////////////////////
        if (ClickCount + 1 > ButtonArray.Length - 1)
        {
            ButtonArray[0].GetComponentInChildren<Animator>().SetBool("Selected", false);
        }
        else
        {
            ButtonArray[ClickCount + 1].GetComponentInChildren<Animator>().SetBool("Selected", false);
        }

        ////////the First button situation////////////////////////////////////
        if (ClickCount - 1 < 0)
        {
            ButtonArray[ButtonArray.Length - 1].GetComponentInChildren<Animator>().SetBool("Selected", false);

        }
        else
        {
            ButtonArray[ClickCount - 1].GetComponentInChildren<Animator>().SetBool("Selected", false);

        }

        /******************************************************************************************************************/

        //enable now selected button's animation

        ButtonArray[ClickCount].GetComponentInChildren<Animator>().SetBool("Selected", true);



        EventSystem.current.SetSelectedGameObject(ButtonArray[ClickCount]);

        if (Handler_Click == true || AnotherHandlerState == true)
        {

            CheckWhetherPressAnotherHandle();
        }



    }

    private void ComputeClickCount()
    {
        if (PreventDuplicate_ClickCopunt == AnotherHandlerClickCount)
        {
            return;
        }
        ClickCount += AnotherHandlerClickCount;
        PreventDuplicate_ClickCopunt = AnotherHandlerClickCount;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Handler_Click = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ClickCount++;
        Handler_Click = false;
    }

    public void CheckWhetherPressAnotherHandle()
    {

        StartCoroutine(ForDelay());

        //Check Whether click now selected button 
        if (Handler_Click == true)
        {
            if (AnotherHandlerState == true || Input.GetKeyDown("t") )
            {

                Button button = ButtonArray[ClickCount].GetComponent<Button>();

                var pointer = new PointerEventData(EventSystem.current);
                ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.submitHandler);

            }
        }

        if (AnotherHandlerState == true)
        {
            if (Input.GetKeyDown("t") || Handler_Click == true)
            {
                Button button = ButtonArray[ClickCount].GetComponent<Button>();

                var pointer = new PointerEventData(EventSystem.current);
                ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.submitHandler);

            }
        }
    }

    IEnumerator ForDelay()
    {
        yield return new WaitForSeconds(1f);
    }
}
