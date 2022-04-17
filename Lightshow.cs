using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightshow : MonoBehaviour
{
    public float interval = 0.5f;
    bool lightShowRUnning;

    public enum LightModes
    {
        SINGLE,
        AIRPLANE,
        PINGPONG,
        ALL_AT_ONCE
    }
    public LightModes lightMode;

    [System.Serializable]
    public class LightSet
    {
        public SpriteRenderer sp;
        public Sprite on, off;
    }

    public List<LightSet> lightList = new List<LightSet>();
    int lightIndex;
    int direction = 1;

    IEnumerator Blink()
    {
        if(lightShowRunning)
        {
            yield break;
        }
        lightShowRUnning = true;
        direction = 1;

        while(lightShowRunning)
        {
            if(lightMode == LightModes.SINGLE)
            {
                //ON
                lightList[0].sp.sprite = lightList[0].on;
                //WAIT
                yield return new WaitForSeconds(interval);

                //OFF
                lightList[0].sp.sprite = lightList[0].off;
                //WAIT
                yield return new WaitForSeconds(interval);
            }

            if(lightMode == LightModes.AIRPLANE)
            {
                //ON
                lightList[lightIndex].sp.sprite = lightList[lightIndex].on;
                //WAIT
                yield return new WaitForSeconds(interval);

                //OFF
                lightList[lightIndex].sp.sprite = lightList[lightIndex].off;
                //WAIT
                yield return new WaitForSeconds(interval);

                lightIndex++;

                if (lightIndex>lightList.Count-1)
                {
                    lightIndex = 0;
                }
            }

            if(lightMode == LightModes.PINGPONG)
            {
                //ON
                lightList[lightIndex].sp.sprite = lightList[lightIndex].on;
                //WAIT
                yield return new WaitForSeconds(interval);

                //OFF
                lightList[lightIndex].sp.sprite = lightList[lightIndex].off;
                //WAIT
                yield return new WaitForSeconds(interval);

                lightIndex += 1*direction;

                if (lightIndex>lightList.Count - 1)
                {
                    lightIndex = lightList.Count - 1;
                    direction = -1;
                }

                else if(lightIndex<0)
                {
                    lightIndex = 0;
                    direction = 1;
                }
            }

            if(lightMode == LightModes.ALL_AT_ONCE)
            {
                foreach (var l in lightList)
                {
                    //ON
                l.sp.sprite = l.on;
                }
                //WAIT
                yield return new WaitForSeconds(interval);
                
                foreach (var l in lightList)
                {
                    //ON
                l.sp.sprite = l.off;
                }
                //WAIT
                yield return new WaitForSeconds(interval);
            }
        }
        
    }
}
