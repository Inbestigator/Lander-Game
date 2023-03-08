using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetHitbox : MonoBehaviour
{
    public Canvas ControlShip;

    private void OnCollisionEnter(Collision collision)
    {
        ControlShip.enabled = false;
        Debug.Log("Object enabled!");
    }
}
