using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField]
    private GameObject mainGameObject;

    [SerializeField] private Animator animator;


    public void TakeDamage(Rigidbody ballRB, float ballDamageMultiplier)
    {
        // velocity magnitude varies from 0 to 20
        float damageReceived = ballRB.velocity.magnitude * damageNormalizerAux * damageTakenPercentage * ballDamageMultiplier;
        Debug.Log(damageReceived);
        currentLife -= damageReceived;

        if (healthBar != null)
        { 
            Vector3 newScale = healthBar.localScale;
            newScale.x = healthBarXScale * (currentLife / maxLife);
            healthBar.localScale = newScale;

            
        }
        if (currentLife <= 0)
        {

            if (healthBar != null){
                Vector3 newScale = healthBar.localScale;
                newScale.x = 0;
                healthBar.localScale = newScale;
            }
            currentLife = 0;
            StartCoroutine(Die());

            if (animator)
                animator.Play("Die");
        }
        else
        {
            if(animator)
                animator.Play("GetHit");
        }
    }

    protected virtual void OnBeforeDestroy()
    {
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(deathAnimationDuration);
        OnBeforeDestroy();
        if (mainGameObject)
            Destroy(mainGameObject);
        else
            Destroy(gameObject);
    }


    protected void AtStart()
    {
        currentLife = maxLife;
        if (healthBar != null)
            healthBarXScale = healthBar.localScale.x;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        AtStart();
    }

    // Update is called once per frame
    protected void Update()
    {
    }
}
