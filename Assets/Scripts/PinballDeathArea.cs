using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballDeathArea : MonoBehaviour
{

    [SerializeField]
    private PinballsManager pinballsManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pinball"))
        {
            pinballsManager.SpawnNewPinball();
            Destroy(other.gameObject);
        }
    }

}
