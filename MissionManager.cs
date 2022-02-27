using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    void Awake()
    {
        instance = this;
    }

    public List<Mission> missionList = new List<Mission>();
}
