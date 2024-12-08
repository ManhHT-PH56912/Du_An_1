using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DesignPattern.Singleton;

public class ScoreManager : Singleton<ScoreManager>
{
    protected override void Awake()
    {
        base.Awake();
    }
}
