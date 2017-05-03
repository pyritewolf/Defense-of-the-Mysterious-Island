using UnityEngine;

public class SpawnDefense : MonoBehaviour {
    
    public GameObject emptySpawnerControls;
    public Material onClickMaterial;
    private Material oldMaterial;

    private void Awake()
    {
        oldMaterial = GetComponent<Renderer>().material;
    }

    void OnMouseDown()
    {
        emptySpawnerControls.SetActive(true);
        GetComponent<Renderer>().material = onClickMaterial;

        UIManager.instance.activeDefenseTile = gameObject;
        
    }

    public void ResetTile()
    {

        GetComponent<Renderer>().material = oldMaterial;
        emptySpawnerControls.SetActive(false);
    }

}
