using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour {

    static public LevelUIManager instance;
    public GameObject activeDefenseTile;
    public GameObject towerPrefab;
    public GameObject lighthousePrefab;
    public GameObject nautilusPrefab;

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

    public void createTower()
    {
        if(activeDefenseTile)
        {
            createDefense(towerPrefab);
            resetActiveTile();
        }

    }

    public void createLighthouse()
    {
        if (activeDefenseTile)
        {
            createDefense(lighthousePrefab);
            resetActiveTile();
        }
    }

    public void createNautilus()
    {
        if (activeDefenseTile)
        {
            createDefense(nautilusPrefab);
            resetActiveTile();
        }
    }


    private void createDefense(GameObject prefab)
    {
        Attributes prefabAttributes = prefab.GetComponent(typeof(Attributes)) as Attributes;
        if (AttributesManager.instance.gold >= prefabAttributes.gold)
        {
            AttributesManager.instance.gold -= prefabAttributes.gold;
            Instantiate(prefab, activeDefenseTile.transform.position, activeDefenseTile.transform.rotation);
        }
        else
        {
            print("No hay suficiente oro!");
        }
    }

    public void resetActiveTile()
    {
        (activeDefenseTile.GetComponent(typeof(SpawnDefense)) as SpawnDefense).ResetTile();
        activeDefenseTile = null;
    }

    public bool checkForActiveTiles()
    {
        if (activeDefenseTile) {
            return true;
        }
        return false;
    }


}
