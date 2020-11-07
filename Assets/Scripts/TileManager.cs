using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] roadTilesPrefabs;
    private int tilesOnScreenNum = 10; // how many tiles we want to display
    private float spawnPosition = 0.0f; //z coordinate of new tile
    private float tileLength = 22.0f; // size of one tile
    private Transform runnerTrasnform;

    // Creating new tile
    private void createTile(int prefabInd = -1)
    {
        GameObject tile;
        tile = Instantiate(roadTilesPrefabs[0]) as GameObject;
        //tile.transform.SetParent(transform);
        tile.transform.position = Vector3.forward * spawnPosition;
        spawnPosition += tileLength;
    }

    // Start is called before the first frame update
    void Start()
    {
        // we decide should we generate new part of path according to current player position
        // getting player position
        runnerTrasnform = GameObject.FindGameObjectWithTag("Player").transform;
        // generate some tiles
        for (int i=0; i < tilesOnScreenNum; i++)
        {
            createTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // the end of the road is near - spawn some more tiles
        if (runnerTrasnform.position.z > (spawnPosition - tilesOnScreenNum * tileLength))
        {
            createTile();
        }
    }
}
