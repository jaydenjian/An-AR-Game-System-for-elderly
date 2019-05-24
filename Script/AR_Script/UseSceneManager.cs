using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSceneManager : MonoBehaviour
{
    public GameObject FindSceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindSceneManager = GameObject.Find("SceneManager");

    }

    public void UseSceneManagerScript(int SpawnScene)
    {
        FindSceneManager.GetComponent<Scene_Manager>().SpawnScene(SpawnScene);
    }

    public void SceneManagerOpenGame()
    {
        FindSceneManager.GetComponent<Scene_Manager>().ChangeToGame();

    }

    public void SceneManagerReturnUI()
    {
        FindSceneManager.GetComponent<Scene_Manager>().ChangeToUI();
    }

    public void ReturnUI_Collective()
    {
        FindSceneManager.GetComponent<Scene_Manager>().ChangeToUI_Collective();
    }

    public void ReturnUI_Travel()
    {
        FindSceneManager.GetComponent<Scene_Manager>().ChangeToUI_Travel();
    }
    public void ReturnUI_Member()
    {
        FindSceneManager.GetComponent<Scene_Manager>().ChangeToUI_Member();
    }



    public void SceneManagerReturnMainMenu()
    {
        FindSceneManager.GetComponent<Scene_Manager>().ReturnMainMenu();
    }
}
