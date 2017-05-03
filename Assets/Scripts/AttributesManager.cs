using UnityEngine;

public class AttributesManager : MonoBehaviour {

    public static AttributesManager instance;
    public float gold;
    public float life;
    public GameObject island;

	// Use this for initialization
	void Awake () {
        if (instance)
        {
            Destroy(gameObject);
        } else { 
            instance = this;
            gold = 500;
        }
    }

    private void Update()
    {
        life = (island.GetComponent(typeof(Attributes)) as Attributes).life;
    } 
}
