using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour {

    public float life;
    public float gold;
    public Image hpBar;
    private float maxHP;

	// Use this for initialization
	void Start () {
        maxHP = life;
	}
	
	// Update is called once per frame
	void Update () {

        if (hpBar != null) { 
            hpBar.fillAmount = life / maxHP;
        }

    }
}
