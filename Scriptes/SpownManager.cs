using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownManager : MonoBehaviour
{
    public GameObject[] animals;
    private float PosZ = 20f;
    private float PosX = 20f;
    private float timeBefore = 2;
    private float timeIntrval = 1.5f;
     // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpownAnimals", timeBefore, timeIntrval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpownAnimals()
    {
        int animalIndex = Random.Range(0, animals.Length);
        Vector3 spownPos = new Vector3(Random.Range(-PosX, PosX), 0, PosZ);
        Instantiate(animals[animalIndex], spownPos, animals[animalIndex].transform.rotation);
    }
}

