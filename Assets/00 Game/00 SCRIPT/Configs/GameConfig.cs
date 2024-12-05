using UnityEngine;
using DesignPattern.Singleton;

public class GameConfig : Singleton<GameConfig>
{
    // Override Awake to customize behavior
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        Application.targetFrameRate = 60;
    }
}
