using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState Gamestate;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(GameState newState) // fonction pour changer de phase
    {
        Gamestate = newState;
        switch(newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.GenerateEnemiesKyoko:
                break;
            case GameState.GenerateYoko:
                break;
            case GameState.BattlePhase:
                break;
            default:
                throw new System.ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }



    public enum GameState // liste des Phases de jeu
    {
        GenerateGrid = 0,
        GenerateEnemiesKyoko = 1,
        GenerateYoko =2,
        BattlePhase =3
    }

}
