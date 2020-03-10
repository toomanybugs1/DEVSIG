using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    /* Trey Shaw
     * 
     * This singleton will be used to change scenes in all the different levels
     * we create. This MUST be used so we can change all of them at once, rather than
     * going to each level because the indicies changed.
     *
     * All you have to do is call GameManager.Method() to use these. There will be
     * a game manger object that stays in every scene. Don't create one yourself, or
     * it will take up unnecessary space.
     */

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "GameManager";
                    instance = go.AddComponent<GameManager>();

                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void WinLevel()
    {
        char diffChar = SceneManager.GetActiveScene().name[0];
        //use the difficulty to change the win rate

        //load the start scene
        SceneManager.LoadScene(1);
    }

    public static void LoseLevel()
    {
        //reloads the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
