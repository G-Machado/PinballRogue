using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


public class PinballsManager : MonoBehaviour
{
    [SerializeField]
    private bool sidewaysLaunch = false;
    


        [SerializeField]
    private ScriptableInventory inventory;

    [SerializeField]
    private ScriptableInventory allPinballsPool;

    [SerializeField]
    private Transform pinballSpawnPos;

    private int currentPinballIndex = 0;
    private bool needStartImpulse = true;
    private bool hasStartedImpulse = false;
    private float startImpulseTimer = 0;
    [SerializeField] private float maxImpulseTimer = 3;

    [SerializeField] private float startImpulseForceContsAux = 1;

    private GameObject currentPinballObj;
    private Rigidbody currentPinballRB;


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

        if (currentPinballIndex >= inventory.prefabs.Count){
            GameOver();
            return;
        }

        currentPinballObj = Instantiate(inventory.prefabs[currentPinballIndex], pinballSpawnPos.position, Quaternion.identity);
        currentPinballRB = currentPinballObj.GetComponent<Rigidbody>();
        needStartImpulse = true;
        currentPinballIndex++;
        
    }



    private void ApplyStartImpulse(){

        Vector3 launchVector = sidewaysLaunch ? Vector3.right : Vector3.up;


        currentPinballRB.AddForce(launchVector * 10 + launchVector * startImpulseTimer * startImpulseForceContsAux, ForceMode.Impulse);
        startImpulseTimer = 0;
        hasStartedImpulse = false;
        needStartImpulse = false;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pinball"))
        { 
            needStartImpulse = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pinball"))
        {
            currentPinballRB.velocity = currentPinballRB.velocity.normalized;
            needStartImpulse = true;
        }
    }


    private void GameOver(){
        SceneLoaderManager.instance.TriggerSceneOver();
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
        if (needStartImpulse){ 
            if (!hasStartedImpulse && Input.GetKeyDown(KeyCode.Space))
            {
                hasStartedImpulse = true;
            }
            if (hasStartedImpulse)
            {
                startImpulseTimer += Time.deltaTime;
                if (Input.GetKeyUp(KeyCode.Space)){
                    ApplyStartImpulse();
                }
                else if (startImpulseTimer >= maxImpulseTimer) {
                    startImpulseTimer = maxImpulseTimer;
                    ApplyStartImpulse();
                }
            }
        }
    }
}
