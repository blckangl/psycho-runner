using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -6.0f;
    private float tileLength = 9.5f;
    private int amountTileOnScreen = 7;
    private float safeZone = 15.0f;
    private int lastPrefabIndex = 0;
   

    private List<GameObject> activeTiles;
	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        activeTiles = new List<GameObject>();

        for(int i = 0; i< amountTileOnScreen; i++)
        {
            if (i < 4) { 
            SpawnTile(4);
            }
            else
            SpawnTile();
        }
    }
	
	// Update is called once per frame
	void Update () {
       
        
        if(playerTransform.position.z -safeZone  > (spawnZ - amountTileOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
		
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
