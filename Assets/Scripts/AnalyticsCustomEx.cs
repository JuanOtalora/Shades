using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsCustomEx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportFinishLevel()
    {
        AnalyticsEvent.Custom("Finish", new Dictionary<string, object>
    {
        { "level", 1},
        { "time_elapsed", Time.timeSinceLevelLoad }
    });
    }
}
