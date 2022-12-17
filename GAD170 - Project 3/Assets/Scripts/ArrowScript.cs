using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] int arrowDamage = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
                other.GetComponent<EnemyScript>().ReduceHealth(arrowDamage);
                Destroy(gameObject);
        }
    }
}
