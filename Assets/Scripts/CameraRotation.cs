using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public float rotationSpeed;
    private bool rotating;
    private float rotatingTowards;

    void Awake()
    {
        rotating = false;
    }

    void Update()
    {
        if (rotating && rotatingTowards == transform.eulerAngles.y && rotatingTowards >= 0)
        {
            rotating = false;
        } else if (rotatingTowards == -90 && rotating && 270 == transform.eulerAngles.y)
        {
            rotating = false;
        }
        else if (rotatingTowards == 360 && rotating && transform.eulerAngles.y < 180)
        {
            rotating = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !rotating)
        {
                rotatingTowards = transform.eulerAngles.y + 90;
                rotating = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && !rotating)
        {
                rotatingTowards = transform.eulerAngles.y - 90;
            rotating = true;
        }

        if (rotating) {
            float currentRotation;
            if (rotatingTowards < 0 && transform.eulerAngles.y > 180)
            {
                currentRotation = transform.eulerAngles.y - 360;
            }
            /*else if (rotatingTowards == 360 && transform.eulerAngles.y > 180) {
                currentRotation = 360 - transform.eulerAngles.y;
            }*/
            else
            {
                currentRotation = transform.eulerAngles.y;
            }

            float rotation = Mathf.MoveTowards(currentRotation, rotatingTowards, rotationSpeed);
            
            
            transform.eulerAngles = new Vector3(0, rotation, 0);
            
            if (LevelUIManager.instance.activeDefenseTile)
            {
                LevelUIManager.instance.resetActiveTile();
            }

        }
    }
}
