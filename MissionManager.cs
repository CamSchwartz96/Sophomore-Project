using System.Collection;
using System.Collection.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    bool timeBasedMissionActive;
    
    void Awake()
    {
        instance = this;

    }

    public List<Mission> missionList = new List<Mission>();

    public void StartMission(int ID)
    {
        foreach (Mission mission in missionList)
        {
            if(mission.missionId == ID)
            {
                // Time based Missions
                if(!mission.missionComplete && !mission.active && mission.timeToComplete >0 && !timeBasedMissionActive)
                {
                    mission.active = true;
                    timeBasedMissionActive = true;


                    // Start timer
                    StartCoroutine(Timer(mission.timeToComplete, ID));
                }

                // Not time based missions
                else if (!mission.missionComplete && !mission.active &&mission.timeToComplete <=0)
                {
                    mission.active = true;
                }
            }
        }
    } 
    IEnumberator Timer (float t, int ID)
    {
        float tempTime = t;
        while(timeBasedMissionActive && tempTime >0 )
        {
            yield return new WaitForSeconds(1f);
            tempTime -=1;
            Debug.Log(tempTime);
        }

        //Deactive
        timeBasedMissionActive = false;
        DeactivateMission(ID);
    }
    void DeactivateMission( int ID)
    {
        missionList.Find(m => m.missionId == ID).DeactivateMission();
        if(timeBasedMissionActive)
        {
            timeBasedMissionActive = false;
        }
        Debug.Log("Mission has been Ended");
    }

    public void UpdateMission(int ID)
    {
        missionList.Find(m=>m.missionId == ID).UpdateMission();
    }

    public void StopTimer()
    {
      timeBasedMissionActive = false;  
    }

    public bool CheckIfMissionStarted(int ID)
    {
        return missionList.Find(m => m.missionId == ID).GetMissionActive();
    }
    
}