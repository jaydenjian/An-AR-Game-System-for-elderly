using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] CanvasArray;

    void Update()
    {

    }

    public void ChangeToGame()
    {
        //StartCoroutine(ChangeScene());
        SceneManager.LoadScene("ARGameScene");
    }


    public void ChangeToUI()
    {
        SceneManager.LoadScene("ReturnScene");
    }


    public void ChangeToUI_Travel()
    {
        SceneManager.LoadScene("TravelMenu");
        Debug.Log("travel");
    }

    public void ChangeToUI_Member()
    {
        SceneManager.LoadScene("MemberOnly");
    }

    public void ChangeToUI_Collective()
    {
        SceneManager.LoadScene("CollectiveMenu");
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("00-GameMenu");
    }

    public void SpawnScene(int WhichCanvas)
    {
        Instantiate(CanvasArray[WhichCanvas], new Vector3(0, 0, 0), Quaternion.identity);
    }


    public void CloseScene(int AnimatorCount)
    {
        StartCoroutine(Close_LoadScene(AnimatorCount));
        //SceneManager.LoadScene(SceneName);


    }

    IEnumerator Close_LoadScene(int WhichAnimator)
    {
       
        CanvasArray[WhichAnimator].GetComponentInChildren<Animator>().SetBool("ChangeScene", true);

        yield return new WaitForSeconds(1.5f);
       
    }



    public void OpenScene(int AnimatorCount)
    {
        StartCoroutine(Open_LoadScene(AnimatorCount));

    }

    IEnumerator Open_LoadScene(int WhichAnimator)
    {
       
        CanvasArray[WhichAnimator].GetComponentInChildren<Animator>().SetBool("ChangeScene", false);

        yield return new WaitForSeconds(1.5f);
    
    }

}
