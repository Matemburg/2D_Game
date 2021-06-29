using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private TuretRandomSpawner TuretsSpawner;
    public AsteroidRandomSpawner AsteroidsSpawner, AsteroidsSpawnerParalax, AsteroidsSpawnerParalax2;
    public int Level = 1;
    public int TuretNumber;

    private void Awake()
    {
        TuretsSpawner = GameObject.FindGameObjectWithTag("TuretSpawner").GetComponent<TuretRandomSpawner>();
        FirstLvl();
    }

    void FirstLvl()
    {
        TuretNumber = Level;
        TuretsSpawner.SpawnTurets(TuretNumber);
        AsteroidsSpawner.Spawn();
        AsteroidsSpawnerParalax2.Spawn();
    }
    public void NewLvl()
    {
        Level++;
        TuretNumber = Level;
        AsteroidsSpawner.Destroy();
        TuretsSpawner.SpawnTurets(TuretNumber);
        AsteroidsSpawner.Spawn();
    }
}
