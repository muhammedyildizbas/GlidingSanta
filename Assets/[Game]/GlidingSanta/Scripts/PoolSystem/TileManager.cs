using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    public GameObject[] tilePrefabs;

    private int howMuchPrefab=5;

    public float tileSpeed;
    public float tileDistance;

    public List<GameObject> activeTiles;
    private List<GameObject> pool;

    private void Start()
    {
        activeTiles = new List<GameObject>();
        pool = new List<GameObject>();

        for (int i = 0; i < tilePrefabs.Length; i++)
        {
            for (int j = 0; j < howMuchPrefab; j++)
            {
                pool.Add(Instantiate(tilePrefabs[i],transform.position,Quaternion.identity));

                pool[pool.Count - 1].SetActive(false);
            }
        }
        //With this code, we create 15(tilePrefabs*howMuchPrefab) prefabs for pool.Then we deactivate prefabs.

        for (int i = 0; i < 5; i++)
        {
            SpawnTile(i*tileDistance);
        }
        //For the prefab positions to be spaced.
        //And because of the for loop we call SpawnTile 5 times so there will be 5 active prefab when we use "pool[randomTile].SetActive(true);"
    }

    private void SpawnTile(float replacePosition)
    {
        int randomTile = Random.Range(0, pool.Count - 1);
     
        pool[randomTile].SetActive(true);
        //SetActive random prefab in pool.
        pool[randomTile].transform.position = Vector3.forward * replacePosition;
        //This is for the position of the prefab that we activated
        activeTiles.Add(pool[randomTile]);
        //Adding Activated prefabs in the pool List to activeTiles List
        pool.RemoveAt(randomTile);
        //Remove active prefabs in the pool List.
    }
    public void DeleteTile(GameObject deletedTile)
    {
        if (!activeTiles.Contains(deletedTile))
            return;
        //Check
        pool.Add(deletedTile);
        
        activeTiles.Remove(deletedTile);

        deletedTile.SetActive(false);

        SpawnTile(tileDistance*4f);
        //When DeleteTile called we have to callback SpawnTile for making a loop.
        //With this code next prefab position will be end of the prefabs.
    }
    
}
