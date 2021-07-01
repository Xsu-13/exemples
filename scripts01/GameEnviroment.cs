using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public sealed class GameEnviroment 
{
    private static GameEnviroment instance;
    private List<GameObject> checkpoints = new List<GameObject>();
    public List<GameObject> Chackpoints = new List<GameObject>();

    public static GameEnviroment Singleton
    {
        get
        {
            if (instance==null)
            {
                instance = new GameEnviroment();
                instance.Chackpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));

                instance.checkpoints = instance.checkpoints.OrderBy(waypoints => waypoints.name).ToList();
            }
            return instance;
        }
    }
    
}
