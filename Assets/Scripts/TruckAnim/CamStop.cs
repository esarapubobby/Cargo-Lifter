using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CamStop : MonoBehaviour
{
    [SerializeField]GameObject ConstantCam;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Truck")
        {
            ConstantCam.SetActive(true);
        }
    }
}
