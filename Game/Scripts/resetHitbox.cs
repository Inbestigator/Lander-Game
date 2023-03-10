using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetHitbox : MonoBehaviour
{
    public Canvas winScreen;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reset"))
        {
            winScreen.enabled = false;
        }
    }
}
