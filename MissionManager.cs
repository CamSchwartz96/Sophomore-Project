using System.Collections;
using System.Collections.Generic;
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
            if (mission.missionID == ID)
            {
                if(!mission.missionComplete && !mission.active && mission.timeToComplete>0 && !timeBasedMissionActive)
                {
                    mission.active = true;
                    timeBasedMissionActive = true;
                }

                else if(!mission.missionComplete && !mission.active && mission.timeToComplete <= 0)
                {
                    mission.active = true;
                }
            }

        }
    }
}
