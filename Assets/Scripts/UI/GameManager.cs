using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float time;
    public bool sessionEnded;
    int liveScore;
    public int totalCargo = 3;

    [SerializeField] Hook hook;
    [SerializeField] CraneRotate crane;

    [SerializeField] private Timer timer;
    [SerializeField] private GameData data;
    [SerializeField] private ShowAnalytics showAnalytics;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField] private Animator truckAnimator;
    [SerializeField] private GameObject TruckFollowCam;

    [Header("Trucks")]
    [SerializeField] private GameObject[] trucks;


    private void Start()
    {
        ClearTrucks();
    }



    private void Update()
    {
        if (!hook.isGameStarted) return;

        if (sessionEnded)
        {
            hook.enabled = false;
            crane.enabled = false;
            return;
        }

        if(totalCargo == hook.totalCargoReleased)
        {
            
            //TruckFollowCam.SetActive(true);
            //StartCoroutine(PlayTruckAnimAfter());
            UpdateSessionResults();
            sessionEnded = true;
            showAnalytics.UpdateAnalyticsDisplay(data);
        }

        UpdateLiveScore();
        timer.Play();
        time = timer.timeInSec;

    }

    //private IEnumerator PlayTruckAnimAfter()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    truckAnimator.SetBool("IsRun",true);
    //    yield return new WaitForSeconds(10f);
        
    //}



    void UpdateLiveScore()
    {
        int cargo = hook.totalCargoReleased;
        liveScore = cargo * data.scorePerCargo;


        scoreTxt.text = liveScore.ToString();
    } 




    public void UpdateSessionResults()
    {

        data.time = System.TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
        data.cargo = hook.totalCargoReleased;
        data.finalScore = Mathf.RoundToInt(liveScore + (hook.totalCargoReleased / time) * 100) * 10;
        data.collisionCount = hook.ObstacleCollisionCount;
        data.totalCargoCollected = hook.totalCargoReleased;
        data.reps = (int)((hook.repCount) / 2) / 60;
        data.totalHoldTime = System.TimeSpan.FromSeconds(hook.holdTimer).ToString(@"mm\:ss");
        data.postureBreaks = (int) hook.postureBreaks / 120;
        float approxReactionTime = 1 - (hook.totalCargoReleased / (hook.repCount / 2)) * 1.5f;
        data.reactionTime = System.TimeSpan.FromSeconds(approxReactionTime).ToString(@"mm\:ss");
        data.calories = (int)((((hook.repCount) / 2) / 60) * 0.4f);
    }


    public GameData GetSessionResults()
    {
        return data;
    }


    public void SpawnTrucks(int numOfTrucks)
    {
        for(int i = 0;  i < numOfTrucks;)
        {
            if (!trucks[i].activeSelf)
            {
                trucks[i].SetActive(true);
            }
            i++;
        }
    }

    public void ClearTrucks()
    {
        foreach(GameObject truck in trucks)
        {
            truck.SetActive(false);
        }
    }

}
