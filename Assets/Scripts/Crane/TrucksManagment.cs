using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class TrucksManagment : MonoBehaviour
{
    [SerializeField] private GameObject[] trucks;

    [SerializeField] private GameObject lastTruckFollowCam;

    [SerializeField] private Hook hook;
    bool wasReleasingLastFrame = false;

    private void Update()
    {
        bool isReleaseStarted = hook.isReleasing && !wasReleasingLastFrame;
        for (int i = 0; i < trucks.Length; i++)
        {
            if(isReleaseStarted)
                AssignSlotToCargo(trucks[i], i);
        }
        wasReleasingLastFrame = hook.isReleasing;
    }

    public bool CheckTruckFilled(GameObject truck)
    {
        Transform slotContainer = truck.transform.GetChild(11);
        TruckSlotManager truckSlotManager = truck.GetComponent<TruckSlotManager>();

        if(slotContainer != null && truckSlotManager != null)
        {
            if(slotContainer.childCount == truckSlotManager.truckSlots.Count)
            {
                return true;
            }
        }
        return false;
    }

    public void PlayTruckAnimation(GameObject truck, int index)
    {
        Animator truckAnim = truck.GetComponent<Animator>();

        if(!truckAnim.GetBool("IsRun" + index))
        {
            truckAnim.SetBool("IsRun" + index, true);
        }
    }

    public void AssignSlotToCargo(GameObject truck, int i)
    {
        TruckSlotManager truckSlotManager = truck.GetComponent<TruckSlotManager>();

        Transform slot = truckSlotManager.GetNextSlot();
        if (slot != null)
        {
            if (hook.cargoStack.Count == 0) return;

            StartCoroutine(truckSlotManager.MoveCargoToSlot(hook.cargoStack[0].gameObject.transform, slot));
        }
        if (CheckTruckFilled(truck))
        {
            PlayTruckAnimation(truck, i);

            if(truck == trucks[trucks.Length - 1])
            {
                lastTruckFollowCam.SetActive(true);
            }
        }
    }


}         
