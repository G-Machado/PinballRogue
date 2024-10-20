using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> enemySetupsPrefabs;

    private GameObject currentEnemyGroupObj;
    private EnemyGroup currentEnemyGroup;

    private void SpawnEnemies(){
        int randomIndex = Random.Range(0, enemySetupsPrefabs.Count);
        GameObject randomEnemyPrefab = enemySetupsPrefabs[randomIndex];

        currentEnemyGroupObj = Instantiate(randomEnemyPrefab);
        currentEnemyGroup = currentEnemyGroupObj.GetComponent<EnemyGroup>();
        currentEnemyGroup.enemyManager = this;
    }

    public void EnemiesCleared(){

    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
