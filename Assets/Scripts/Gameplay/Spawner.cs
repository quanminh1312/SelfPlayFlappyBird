using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
//using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    Vector3 position = new Vector3(4.0f,0,0);

    public float spawnRate = 0.5f;
    public float minHeight = -2f;
    public float maxHeight = 3f;
    Timer spawntimer;
    bool init = false;
    List<GameObject> pipes = new List<GameObject>();
    private void Start()
    {
        EventManager.AddListener(EventName.GameStartedEvent, HandleGameStartEvent);
        EventManager.AddListener(EventName.DeActiveMenuEvent, HandleGameOverEvent);
        spawntimer = gameObject.AddComponent<Timer>();
        spawntimer.Duration = spawnRate;
        spawntimer.AddTimerFinishedEventListener(HandleCooldownTimerFinishedEvent);
    }
    private void HandleGameStartEvent(int notUsed)
    {
        if (!init)
        {
            spawntimer.Run();
            init = true;
        }
    }
    private void HandleGameOverEvent(int value)
    {
        if (value != (int)MenuName.Main) return;
        spawntimer.Stop();
        init = false;
        foreach (var pipe in pipes) 
        {
            Destroy(pipe);
        }
        pipes.Clear();
    }
    private void HandleCooldownTimerFinishedEvent()
    {
        Spawn();
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipe = Instantiate(prefab, position, Quaternion.identity);
        pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        pipes.Add(pipe);
        spawntimer.Run();
    }

}
