using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    private List<Slot> _slots = new List<Slot>();
    private List<NumberTile> _tiles = new List<NumberTile>();
    [SerializeField] private GameObject _slotsParent;
    [SerializeField] private GameObject slotsRow;
    [SerializeField] private LevelData _levelData;
    [SerializeField] private NumberTile _tile;
    [SerializeField] private GameObject _emptyTilesParent;
    [SerializeField] private List<TileType> _types;
    private List<int> slotToMove = new List<int>();
    private float thresholdMovement = 0.5f;
    private GameState _state;
    private int _round;
    private TileType GetTileTypeByValue(int value) => _types.First(t => t.value == value);

    void Start()
    {
        CreatingSlots();
    }
    private void Update()
    {
        if (_state != GameState.WaitingInput) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) Shift(Vector2.left);
    }

    private void ChangeState(GameState newState)
    {
        _state = newState;

        switch (newState)
        {
            case GameState.Generatelevel:
                CreatingSlots();
                break;
            case GameState.SpawningTiles:
                CreateTiles(_round++ == 0 ? 2 : 1) ;
                break;
            case GameState.WaitingInput:
                break;
            case GameState.Moving:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
        }
    }
    private void CreateTiles(int amount)
    {
        var freeSlots = _slots.Where(n => n.tileWithin == null).OrderBy(b => Random.value);

        foreach(var slot in freeSlots.Take(amount))
        {
            var tile = Instantiate(_tile, slot.transform);
            tile.Init(GetTileTypeByValue(Random.value>0.8f ? 4 :2));
        }
        
        if (freeSlots.Count() == 1)
        {
            //Lost the game
            return;
        }
        ChangeState(GameState.WaitingInput);
    }


    void CreatingSlots()
    {
        _round = 0;
        GameObject tempRow;
        Slot tempSlot;
        int index = 0;
        for (int i = 0; i < _levelData.slotsRowCount; i++)
        {
            tempRow = Instantiate(slotsRow, _slotsParent.transform);
            for (int j = 0; j < _levelData.slotsColumnCount; j++)
            {
                Debug.Log(j);
                tempSlot = Instantiate(_slot, tempRow.transform);
                tempSlot.index = index;
                _slots.Add(tempSlot);
                index++;
            }
        }

        tempRow = null;
        ChangeState(GameState.SpawningTiles);
    }

    void Shift(Vector2 dir)
    {
        
    }
}

[Serializable]
public struct TileType
{
    public int value;
    public Color color;
}

public enum GameState
{
    Generatelevel,
    SpawningTiles,
    WaitingInput,
    Moving,
    Win,
    Lose
}