using UnityEngine;

public class Item
{
    [SerializeField] private GameObject gameOb;
    [SerializeField] private Transform position;
    [SerializeField] private bool isTaken;
}


public enum GameState
{
    home,
    playing,
    pauseGame,
    gameOver
}