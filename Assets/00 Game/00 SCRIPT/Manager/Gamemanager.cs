
using DesignPattern.Singleton;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }
}