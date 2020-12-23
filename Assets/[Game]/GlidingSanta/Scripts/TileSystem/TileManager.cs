using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    public GameObject[] tilePrefabs;
    private float spawnZ = 0.0f;
    private float tileLenght = 40.0f;
    private int amountTilesOnScreen = 5;
    private Transform playerTransform;
    private float safeZone = 15.0f;
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

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < 5; i++)
        {
            SpawnTile(i*tileDistance);
        }
    }

    private void SpawnTile(float replacePosition)
    {
        int randomTile = Random.Range(0, pool.Count - 1);
        
        /*while (activeTiles.Contains(pool[randomTile]))
        {
            randomTile = Random.Range(0, pool.Count - 1);
        }*/
        pool[randomTile].SetActive(true);
        
        //pool[randomTile].transform.SetParent(transform);
        pool[randomTile].transform.position = Vector3.forward * replacePosition;
        
        activeTiles.Add(pool[randomTile]);
        pool.RemoveAt(randomTile);
    }
    public void DeleteTile(GameObject deletedTile)
    {
        if (!activeTiles.Contains(deletedTile))
            return;
        pool.Add(deletedTile);
        activeTiles.Remove(deletedTile);

        deletedTile.SetActive(false);

        SpawnTile(tileDistance*4f);

    }
    
}
