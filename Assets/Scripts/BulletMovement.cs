using UnityEngine;

public class BulletMovement : MonoBehaviour {


    public Vector3 speed;
    public float damage;
    private GameObject parent; 

    public void Awake()
    {
        Invoke("AutoDestroy", 5);
    }

    public void Update()
    {
        transform.Translate(speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject otherObj = other.gameObject;

        Attributes life = otherObj.GetComponent(typeof(Attributes)) as Attributes;
        if (life)
        {
            life.life = life.life - damage;
            if (life.life <= 0 && !otherObj.CompareTag("Player"))
            {
                // if an enemy died, add gold to the goldmanager
                if (otherObj.layer == 10)
                {
                    AttributesManager.instance.gold += (otherObj.GetComponent(typeof(Attributes)) as Attributes).gold;
                }

                Destroy(otherObj);
                Movement parentsMovement = parent.GetComponent(typeof(Movement)) as Movement;
                if (parentsMovement != null) { 
                    parentsMovement.ContinueMoving();
                }
            }
        }

        Destroy(gameObject);
    }

    public void AutoDestroy()
    {
        Destroy(gameObject);
    }

    public void setParent (GameObject parentObject)
    {
        parent = parentObject;
    }

}
