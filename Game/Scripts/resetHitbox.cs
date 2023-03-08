using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetShipHitbox : MonoBehaviour
{
    public Canvas winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reset"))
        {
            winScreen.enabled = false;
        }
    }
}
