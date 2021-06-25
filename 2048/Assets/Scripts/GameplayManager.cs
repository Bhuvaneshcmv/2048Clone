using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDir
{
    left,
    right,
    up,
    down
}
public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    [SerializeField] private List<Slot> _slots = new List<Slot>();
    [SerializeField] private List<Slot> filledSlots = new List<Slot>();
    [SerializeField] private GameObject _slotsParent;
    [SerializeField] private GameObject slotsRow;
    [SerializeField] private LevelData _levelData;
    [SerializeField] private Tile _tile;
    [SerializeField] private GameObject _emptyTilesParent;
    public static Action<MoveDir> move;
    void Start()
    {
        CreatingSlots();
        CreateTiles();
    }

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void CreatingSlots()
    {
        GameObject tempRow;
        Slot tempSlot;
        int index = 0;
        for (int i = 0; i < _levelData.slotsRowCount; i++)
        { 
            tempRow = Instantiate(slotsRow, _slotsParent.transform);
            for (int j = 0; j < _levelData.slotsColumnCount; j++)
            {
                tempSlot = Instantiate(_slot, tempRow.transform);
                tempSlot.index = index;
                _slots.Add(tempSlot);
                index++;
            }
        }
        tempRow = null;
    }

    void CreateTiles()
    {
        List<int> slotsToFillIds = _levelData.GetInitialSlotIndices(2);
        List<int> initialTilesVals = _levelData.GetInitialTileValues(2);
       
        
        Tile tempTile;
        for (int i=0; i < initialTilesVals.Count;i++)
        {
            tempTile = Instantiate(_tile);
            tempTile.SetValue(initialTilesVals[i]);
            _slots[slotsToFillIds[i]].placeTile(tempTile);
        }
    }

    void MoveTile(int presentSlotId, int futureSlotId)
    {
        Tile tempTile;
        tempTile = _slots[presentSlotId].RemoveTile();
        tempTile.transform.SetParent(_emptyTilesParent.transform);
        _slots[futureSlotId].placeTile(tempTile);
    }

    void TileMovementHandler(MoveDir movementDirection)
    {
        switch (movementDirection)
        {
            case MoveDir.left:
                break;
        }
    }
}