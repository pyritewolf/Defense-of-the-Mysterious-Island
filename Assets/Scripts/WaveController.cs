using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public List<GameObject> attackers;
    public float spawnDelay;
    public GameObject nextWave;
    public float nextWaveDelay;
    public List<GameObject> spawnPoints;

	// Use this for initialization
	void Awake()
    {
        Invoke("SpawnWave", spawnDelay);
    }

    private void SpawnWave()
    {
        // while there's any attacker waves
        while (attackers.Count > 0)
        {

            //pick a random wave
            int rnd = Random.Range(0,attackers.Count);
            int rnd2 = Random.Range(0, spawnPoints.Count);

            
            GameObject wave = attackers[rnd];
            GameObject spawnPoint = spawnPoints[rnd2];

            //spawn and locate the wave
            float rotationY = spawnPoint.transform.eulerAngles.y;
            float displacementX = spawnPoint.transform.position.x;
            float displacementZ = spawnPoint.transform.position.z;
            
            
            Instantiate(wave, new Vector3(displacementX, 0, displacementZ), Quaternion.Euler(new Vector3(0, rotationY, 0)));

            //remove the wave from the attackers list
            attackers.RemoveAt(rnd);
            spawnPoints.RemoveAt(rnd2);
            
        }

    }
}
