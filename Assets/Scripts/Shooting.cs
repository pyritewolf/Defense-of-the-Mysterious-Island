using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    public float initialDelay;
    public float firingSpeed;

	// Use this for initialization
	void Awake () {
        Invoke("Fire", initialDelay);
	}

    void Fire(){
        GameObject firedBullet = Instantiate(bullet, transform.position, transform.rotation);
        BulletMovement firedBulletMovement = firedBullet.GetComponent(typeof(BulletMovement)) as BulletMovement;
        firedBulletMovement.setParent(gameObject);
        Invoke("Fire", firingSpeed);
    }
	
}
