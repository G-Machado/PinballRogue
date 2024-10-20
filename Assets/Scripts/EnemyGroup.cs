using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{

    public EnemyManager enemyManager;

    [SerializeField]
    private List<GameObject> enemies;



    public void EnemyDeath(GameObject enemy){
        enemies.Remove(enemy);
        if (enemies.Count <= 0){
            enemyManager.EnemiesCleared();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
