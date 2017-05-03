using UnityEngine;

public class WaveManager : MonoBehaviour {

    public static WaveManager instance;
    
    public int killedWaves;


    // Use this for initialization
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
    
}
