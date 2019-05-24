using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroFilm : MonoBehaviour
{
    private Animator Anim;
    public GameObject FindSceneManager;

    // Start is called before the first frame update
    void Start()
    {
        Anim = transform.GetComponent<Animator>();
        FindSceneManager = GameObject.Find("SceneManager");
    }

    // Update is called once per frame
    void Update()
    {

        if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            FindSceneManager.GetComponent<Scene_Manager>().SpawnScene(1);
            Destroy(this.gameObject);
        }

    }
}
