using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableInventory", menuName = "ScriptableObjects/ScriptableInventory", order = 1)]

public class ScriptableInventory : ScriptableObject
{ 
    [SerializeField] public List<GameObject> prefabs;
}
