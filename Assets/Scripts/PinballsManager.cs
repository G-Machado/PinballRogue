using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinballsManager : MonoBehaviour
{

    [SerializeField]
    private ScriptableInventory inventory;

    [SerializeField]
    private ScriptableInventory allPinballsPool;

    [SerializeField]
    private Transform pinballSpawnPos;

    private int currentPinballIndex = 0;



        public static void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    public void SpawnNewPinball()
    {

        if (currentPinballIndex > inventory.prefabs.Count){
            GameOver();
            return;
        }

        GameObject newPinballObj = Instantiate(inventory.prefabs[currentPinballIndex], pinballSpawnPos.position, Quaternion.identity);

        currentPinballIndex++;
        
    }


    private void GameOver(){

    }


    // Start is called before the first frame update
    void Start()
    {
        Shuffle(inventory.prefabs);
        SpawnNewPinball();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
