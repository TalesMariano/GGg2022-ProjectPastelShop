using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{

    //Singleton
    public static MySceneManager I = null;
    void Awake()
    {
        if (I == null)           //Check if instance already exists
            I = this;            //if not, set instance to this
        else if (I != this)
        {      //If instance already exists and it's not this:
            //instance.LoadNext();
            Destroy(gameObject);        //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }
        DontDestroyOnLoad(gameObject);  //Sets this to not be destroyed when reloading scene
    }
    public void LoadSceneInt(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void LoadSceneNAme(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
