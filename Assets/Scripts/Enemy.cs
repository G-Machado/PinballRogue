using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DestructableObject
{

    [SerializeField] private EnemyGroup enemyGroup;

    protected override void OnBeforeDestroy()
    {
        base.OnBeforeDestroy();
        enemyGroup.EnemyDeath(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        AtStart();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
