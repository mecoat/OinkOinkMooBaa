using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance;

    private List<ScriptableAnimal> animals;

    private void Awake()
    {
        Instance = this;

        animals = Resources.LoadAll<ScriptableAnimal>("Animals").ToList();
    }


    public void SpawnAnimal(ScriptableAnimal animalToSpawn, int noToSpawn)
    {
        var animalPrefab = animalToSpawn.animalPrefab;

        for (int i = 0; i < noToSpawn; i++)
        {
            var spawnedAnimal = Instantiate(animalPrefab);
            var randomSpawnTile = GridManager.Instance.GetSpawnTile();

            randomSpawnTile.SetAnimal(spawnedAnimal);

        }
    }

   //public void SpawnAnimals()
    //{
      //  int animalCount = 3;
      //
        //for (int i=0; i< animalCount; i++)
        //{
            //var randomPrefab = getRandomAnimal<BaseAnimal>(Animal.duck);
            //var randomPrefab = getRandomAnimal<BaseAnimal>();

          //  var randomPrefab = animals[Random.Range(0, animals.Count - 1)].animalPrefab;

            //var spawnedAnimal = Instantiate(randomPrefab);
            //var randomSpawnTile = GridManager.Instance.GetSpawnTile();

            //randomSpawnTile.SetAnimal(spawnedAnimal);
        //}

        //GameManager.Instance.UpdateGameState(GameState.Playing);
    //}

    //private T getRandomAnimal<T>(Animal animal) where T : BaseAnimal
//    private T getRandomAnimal<T>() where T : BaseAnimal
  //  {
    //    Debug.Log("calling getrandAn");

        //return (T)animals.Where(u => u.Animal == animal).OrderBy(o => Random.value).First().animalPrefab;
      //  return (T)animals.OrderBy(o => Random.value).First().animalPrefab;
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
