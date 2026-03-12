using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    // [SerializeField]private Animator animator;
    [SerializeField]private float Speed=2f;
    [SerializeField]GameObject ConstantCam;
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            // animator.SetBool("IsRun",true);
            transform.Translate(0,0,Speed*Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destination")
        {
            ConstantCam.SetActive(true);
        }
        if (other.gameObject.tag == "Turn")
        {
            transform.Rotate(0,-90,0);
        }
    }
}
