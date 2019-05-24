using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MemoryButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject TransparencyCorner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TransparencyCorner = GameObject.Find("/Ground Plane Stage/NewBuilding2/Base/TransparencyCorner");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TransparencyCorner.GetComponent<PutTogether>().SpawnCanvas();
    }
}
