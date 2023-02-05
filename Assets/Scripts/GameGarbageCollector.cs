using System.Collections;
using UnityEngine;

public class GameGarbageCollector : AwakeMonoBehaviour
{
    private const int TIME_COLLECTOR = 30;

    private void Start()
    {
        StartCoroutine(GarbageCollector(TIME_COLLECTOR));       
    }

    private WaitForSeconds waitForSeconds;

    private IEnumerator GarbageCollector(int second)
    {
        while (true)
        {
            System.GC.Collect();
            yield return waitForSeconds = new WaitForSeconds(second);
        }   
    }
}
