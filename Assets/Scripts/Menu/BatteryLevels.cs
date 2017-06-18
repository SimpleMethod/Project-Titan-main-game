using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class BatteryLevels : MonoBehaviour
{

    public Text[] Battery;
    public int RefreshStatus;
    // Use this for initialization
    void Start()
    {

        StartCoroutine(ChangeBatteryLevel());
    }

    IEnumerator ChangeBatteryLevel()
    {
#if UNITY_EDITOR
        float status = Mathf.Clamp01(0.1f);
#else
         float status =  Mathf.Clamp01(SystemInfo.batteryLevel);
#endif
        while (true)
        {
            // -1 Brak baterii
            // 0-5 level 0
            // 6-25 level 1
            // 26-50 level 2
            // 51-75 level 3
            // 76-100 level 4

            if (status == 0f)
            {
                foreach (Text i in Battery)
                {
                    i.enabled = false;

                }
            }
            else if (status <= 0.05f && status >= 0f)
            {
                Battery[0].enabled = true;
                Battery[1].enabled = false;
                Battery[2].enabled = false;
                Battery[3].enabled = false;
                Battery[4].enabled = false;
            }
            else if (status <= 0.25f && status >= 0.06f)
            {
                Battery[1].enabled = true;
                Battery[2].enabled = false;
                Battery[3].enabled = false;
                Battery[4].enabled = false;
            }
            else if (status <= 0.50f && status >= 0.26f)
            {
                Battery[2].enabled = true;
                Battery[3].enabled = false;
                Battery[4].enabled = false;
            }
            else if (status <= 0.75f && status >= 0.51f)
            {
                Battery[3].enabled = true;
                Battery[4].enabled = false;
            }
            else if (status <= 1f && status >= 0.76f)
            {
                Battery[4].enabled = true;
            }
            yield return new WaitForSeconds(RefreshStatus);


        }
    }
}
