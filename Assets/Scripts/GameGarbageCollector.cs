using System.Collections;
using UnityEngine;

public class GameGarbageCollector : AwakeMonoBehaviour
{
    const int TIME_COLLECTOR = 30;
    void Start()
    {
        StartCoroutine(GarbageCollector(TIME_COLLECTOR));       
    }

    WaitForSeconds waitForSeconds;
    IEnumerator GarbageCollector(int second)
    {
        while (true)
        {
            System.GC.Collect();
            yield return waitForSeconds = new WaitForSeconds(second);
        }
        
    }
}
