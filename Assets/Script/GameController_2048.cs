using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_2048 : MonoBehaviour
{
    public static GameController_2048 instance;

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public enum GameState_2048
    {
        WELCOME,
        SETTING,
        GAMEING,
        GAMEOVER,
        QUIT
    }

    public GameState_2048 gameState_2048;

    private void Start()
    {
        gameState_2048 = GameState_2048.WELCOME;
    }



}
