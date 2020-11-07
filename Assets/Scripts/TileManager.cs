using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] roadTilesPrefabs;
    private int tilesOnScreenNum = 10; // how many tiles we want to display
    private float spawnPosition = -22.0f; //z coordinate of new tile
    private float tileLength = 22.0f; // size of one tile
    private float noTilesDestroyingDistance = 30.0f; //how long we shouldn't destroy any tiles 
    private List<GameObject> actualTiles; // list of tiles which we currently need
    private Transform runnerTrasnform;
    private int lastTileRenderedIndex = 0; // what tile type was rendered

    // Creating new tile
    private void createTile(int prefabInd = -1)
    {
        GameObject tile;
        if (prefabInd == -1)
            tile = Instantiate(roadTilesPrefabs[randomizeNextTile()]) as GameObject;
        else 
            tile = Instantiate(roadTilesPrefabs[prefabInd]) as GameObject;
        tile.transform.SetParent(transform);
        tile.transform.position = Vector3.forward * spawnPosition;
        actualTiles.Add(tile);
        spawnPosition += tileLength;
    }

    // deleting tiles we don't need anymore
    // destroying first element of actual tiles list
    private void destroyTile()
    {
        Destroy(actualTiles[0]);
        actualTiles.RemoveAt(0);
    }

    // making tiles random 
    private int randomizeNextTile()
    {
        if (roadTilesPrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastTileRenderedIndex;
        while(randomIndex == lastTileRenderedIndex)
        {
            randomIndex = Random.Range(0, roadTilesPrefabs.Length);
        }

        lastTileRenderedIndex = randomIndex;
        return randomIndex;

    }

    // Start is called before the first frame update
    void Start()
    {
        actualTiles = new List<GameObject>();
        // we decide should we generate new part of path according to current player position
        // getting player position
        runnerTrasnform = GameObject.FindGameObjectWithTag("Player").transform;
        // generate some tiles
        for (int i=0; i < tilesOnScreenNum; i++)
        {
            if (i < 3)
            {
                createTile(0);
            }
            else
            {
                createTile();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // the end of the road is near - spawn some more tiles
        if (runnerTrasnform.position.z - noTilesDestroyingDistance > (spawnPosition - tilesOnScreenNum * tileLength))
        {
            createTile();
            destroyTile();
        }
    }
}
