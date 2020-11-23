using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/*
 * Spawns the Mover Objects (Enemies) with an interval you determine.
 */
public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnableObjects;
   

   
    [SerializeField] private GameObject Spawnvolume;

    private Jump jumper;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    public float Timer = 2;

    private void Awake()
    {
        jumper = GetComponentInChildren<Jump>();
        //Subscribes to Reset of Player
        jumper.OnReset += DestroyAllSpawnedObjects;

      
    }

   private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {

            GameObject newEnemyBlock = Instantiate(GetRandomSpawnableFromList().gameObject);
            newEnemyBlock.transform.localPosition = Spawnvolume.transform.position;




            spawnedObjects.Add(newEnemyBlock);

            Timer = 2f;
        }
    }

    private void DestroyAllSpawnedObjects()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedObjects[i]);
            spawnedObjects.RemoveAt(i);
        }
    }
    private GameObject GetRandomSpawnableFromList()
    {
        int randomIndex = UnityEngine.Random.Range(0, spawnableObjects.Count);
       
        return spawnableObjects[randomIndex];
    }
}