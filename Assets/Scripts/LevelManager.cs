using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public float totalWaves;


    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveManager.instance.killedWaves == totalWaves)
        {
            SceneManager.LoadScene("Won");
        } else if (AttributesManager.instance.life <= 0)
        {
            SceneManager.LoadScene("Lost");
        }
    }
    
}
