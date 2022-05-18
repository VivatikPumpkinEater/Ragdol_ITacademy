using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCastle : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("yes");
        if (col.GetComponentInParent<EnemyWR>())
        {
            Debug.Log("Punch");
            col.GetComponentInParent<EnemyWR>().PunchCastle();
        }
    }
}
