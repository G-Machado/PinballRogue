using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Pool;

public class MenuBallSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider spawnBox;
    [SerializeField] private GameObject ballPrefab;
    private ObjectPool<GameObject> ballPool;
    [SerializeField] private int maxPoolSize;
    [SerializeField] private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        ballPool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, 10, maxPoolSize);
        StartCoroutine(SpawnRoutine());
    }

    private void OnDestroyPoolObject(GameObject @object)
    {
        Destroy(@object);
    }

    private void OnReturnedToPool(GameObject @object)
    {
        @object.SetActive(false);
    }

    private void OnTakeFromPool(GameObject @object)
    {
        @object.SetActive(true);
    }

    private GameObject CreatePooledItem()
    {
        return Instantiate(ballPrefab);
    }

    public void SpawnBall()
    {
        GameObject ball = ballPool.Get();

        Vector3 randomPos = new Vector3(Random.Range(-spawnBox.size.x/2, spawnBox.size.x / 2),
            Random.Range(-spawnBox.size.y/2, spawnBox.size.z/2),
            Random.Range(-spawnBox.size.z/2, spawnBox.size.z/2)) + spawnBox.gameObject.transform.position;

        ball.transform.position = randomPos;
    }
    private IEnumerator SpawnRoutine()
    {
        SpawnBall();
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnRoutine());
    }
}
