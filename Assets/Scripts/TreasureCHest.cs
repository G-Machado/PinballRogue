using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCHest : DestructableObject
{

    [SerializeField] private GameObject reward;

    protected override void OnBeforeDestroy()
    {
        base.OnBeforeDestroy();
        if (reward != null ) { Instantiate(reward, transform.position, Quaternion.identity); }
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
