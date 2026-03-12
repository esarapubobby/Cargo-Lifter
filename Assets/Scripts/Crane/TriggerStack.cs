using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStack : MonoBehaviour
{

    [SerializeField] Hook hook;
    [SerializeField] CraneRotate craneRotate;
    public int MaxCargo = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag == "Cargo"))
        {
            if (other.gameObject.tag == "DropZone" && hook.cargoStack.Count > 0 && craneRotate.isAtDropPoint)
            {
                //StartCoroutine(ReleaseCargoAfter());
                hook.ReleaseCargo();
            }
            return;
        }

        if (hook.cargoStack.Contains(other.gameObject))
            return;
        if (hook.cargoStack.Count < MaxCargo)
        {
            hook.StackCargo(other.gameObject);
            FindAnyObjectByType<CraneAudio>().Pickup();
            if(craneRotate.rotationSpeed < 0)
            {
                craneRotate.rotationSpeed *= -1;
            }
        }
    }


    //private IEnumerator ReleaseCargoAfter()
    //{
    //    yield return new WaitForSeconds(0.8f);
    //    hook.ReleaseCargo();
    //}
}
