using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public byte AlphaValue = 100;
    private bool CheckAttach;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckAttach = transform.GetComponent<PutTogether>().Already_attach;
        if (CheckAttach)
        {
            AlphaValue = 0;
        }
        else
        {
            AlphaValue = 100;
        }

        SetMaterialTransparent();
    }
    private void SetMaterialTransparent()
    {

        /////////////////////////ColorChangePart////////////////////////////////////////////////

        for (int i = 0; i < this.transform.childCount; i++) //ChildLoop
        {
            Material[] MyMaterials = null;
            GameObject Child = transform.GetChild(i).gameObject;
            if (Child.CompareTag("Item"))
            {
                break;
            }
            MyMaterials = Child.GetComponent<Renderer>().materials;

            for (int j = 0; j < MyMaterials.Length; j++) //MaterialsLoop
            {

                byte R = (byte)((MyMaterials[j].color.r * 255) % 256); //transform the float to byte
                byte G = (byte)((MyMaterials[j].color.g * 255) % 256);
                byte B = (byte)((MyMaterials[j].color.b * 255) % 256);
                byte A = (byte)((MyMaterials[j].color.a * 255) % 256);

                MyMaterials[j].SetFloat("_Mode", 3); //set to transparent mode
                MyMaterials[j].color = new Color32(0, 0, 0, AlphaValue);//color use float 0~1 ,color32 use byte 0~255

                MyMaterials[j].SetInt("_ScrBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                MyMaterials[j].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                MyMaterials[j].SetInt("_ZWrite", 0);
                MyMaterials[j].DisableKeyword("_AlPHATEST_ON");
                MyMaterials[j].EnableKeyword("_ALPHABLEND_ON");
                MyMaterials[j].DisableKeyword("_ALPHAPREMULTIPLY_ON");
                MyMaterials[j].renderQueue = 3000;

            }

        }
        ///////////////////////////////////////////////////////////////////////////

    }

}
