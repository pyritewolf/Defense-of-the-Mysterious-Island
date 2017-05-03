using UnityEngine;

public class Movement : MonoBehaviour {
    
    public Vector3 speed;
    private bool isGrounded;

    public void Awake()
    {
        isGrounded = false;
    } 

    public void Update()
    {
        if (!isGrounded)
        {
            transform.Translate(speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8
             && !isGrounded)
        {
            isGrounded = true;
        }
        
    }

    public void  ContinueMoving()
    {
        isGrounded = false;
    }

}
