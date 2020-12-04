using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashDrive : MonoBehaviour
{
    [SerializeField]
    private Text text;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && (Input.GetKey("e")))
        {
            Destroy(this.gameObject);
            text.enabled = true;
        }
    }
}
