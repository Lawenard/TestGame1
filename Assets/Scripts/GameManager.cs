using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Level { get; private set; }
    public UnityEvent LevelUp { get; private set; }

    private int killCount = 0;

    private void Awake()
    {
        Instance = this;
        LevelUp = new UnityEvent();

        Level = 1;
    }

    public void CountKill()
    {
        killCount++;
        if (killCount == 3)
        {
            killCount = 0;
            Level++;
            LevelUp.Invoke();
        }
    }
}
