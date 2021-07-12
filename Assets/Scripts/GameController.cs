using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static string levelEnvironment;

    void Awake()
    {
        levelEnvironment = "Lava";
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneToInt(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ChangeSceneToName(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
