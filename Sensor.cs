using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool isStarter;//TRIGGER TO START MISSIONS
    public bool isCounter;//COUNT RUNNING MISSIONS
    [Space]
    public int triggerId; //MISSION ID TO TRIGGER

    void OnTriggerEnter(Collider col)
    {
        bool startedAlready = MissionManager.instance.CheckIfMissionStarted(triggerId);
        if(isStarter)
        {
            MissionManager.instance.StartMission(triggerId);
        }

        if(isCounter && startedAlready)
        {
            MissionManager.instance.UpdateMission(triggerId);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("bumped");
        bool startedAlready = MissionManager.instance.CheckIfMissionStarted(triggerId);
        if(isStarter)
        {
            MissionManager.instance.StartMission(triggerId);
        }

        if(isCounter && startedAlready)
        {
            MissionManager.instance.UpdateMission(triggerId);
        }
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = new Color32(0,0,255,125);
        Gismos.matrix = transform.localToWorldIdMatrix;
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }

}
