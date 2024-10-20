using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{

    [SerializeField] private float maxLife = 10;
    [SerializeField] private float currentLife = 0;
    [SerializeField] private float damageTakenPercentage = 1;

    [SerializeField] private float damageNormalizerAux = 0.5f;
    [SerializeField] private float deathAnimationDuration = 1;

    [SerializeField] private Transform healthBar;
    private float healthBarXScale;

   

    public void TakeDamage(Rigidbody ballRB, float ballDamageMultiplier)
    {
        // velocity magnitude varies from 0 to 20
        float damageReceived = ballRB.velocity.magnitude * damageNormalizerAux * damageTakenPercentage * ballDamageMultiplier;
        currentLife -= damageReceived;

        Vector3 newScale = healthBar.localScale;
        newScale.x = healthBarXScale * (currentLife / maxLife);
        healthBar.localScale = newScale;

        if (currentLife <= 0)
        {
            newScale.x = 0;
            healthBar.localScale = newScale;
            currentLife = 0;
            StartCoroutine(Die());
        }

    }

    protected virtual void OnBeforeDestroy()
    {
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(deathAnimationDuration);
        OnBeforeDestroy();
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        healthBarXScale = healthBar.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
