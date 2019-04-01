using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToppingScript : MonoBehaviour
{
    public GameObject Veggie;
    public GameObject Anchovie;
    
    [SerializeField] float SpawnInterval;
    [SerializeField] float MinSpawnX;
    [SerializeField] float MaxSpawnX;

    Vector2 SpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTopping", 0.0f, SpawnInterval);
        SpawnLocation = this.transform.position;
    }

    void SpawnTopping()
    {
        GameObject c;
        if(Random.Range(1.0f, 10.0f) > 8.0f)
        {
            c = Instantiate(Anchovie);
        }
        else
        {
            c = Instantiate(Veggie);
        }

        SpawnLocation.x = Random.Range(MinSpawnX, MaxSpawnX);
        c.transform.position = SpawnLocation;
        //Debug.Log("Spawned a Topping");
    }

    public void GameOver()
    {
        CancelInvoke("SpawnTopping");
    }
}
