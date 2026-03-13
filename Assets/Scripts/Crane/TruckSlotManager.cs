using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSlotManager : MonoBehaviour
{
    [SerializeField] public List<Transform> truckSlots = new List<Transform>();

    public int currentSlotIndex = 0;

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
        cargo.rotation = truckSlot.rotation;

        cargo.transform.SetParent(truckSlot);
    }
}
