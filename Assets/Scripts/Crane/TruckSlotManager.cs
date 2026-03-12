using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSlotManager : MonoBehaviour
{
    [SerializeField] private List<Transform> truckSlots = new List<Transform>();
    [SerializeField] private Hook hook;

    int currentSlotIndex = 0;

    public Transform GetNextSlot()
    {
        if(currentSlotIndex >= truckSlots.Count)
        {
            return null;
        }

        Transform slot = truckSlots[currentSlotIndex];
        currentSlotIndex++;

        return slot;
    }


    public IEnumerator MoveCargoToSlot(Transform cargo, Transform truckSlot)
    {
        Vector3 startPos = cargo.position;
        Vector3 endPos = truckSlot.position;

        float time = 0f;
        float duration = 3f;

        if(time < duration)
        {
            cargo.position = Vector3.Lerp(startPos, endPos, time/duration);
            time += Time.deltaTime;
            yield return null;
        }

        cargo.position = endPos;
        cargo.localRotation = truckSlot.localRotation;

        GameObject slotParent = truckSlot.transform.parent.gameObject;
        GameObject truckObj = slotParent.transform.parent.gameObject;
        cargo.transform.SetParent(truckObj.transform);
    }
}
