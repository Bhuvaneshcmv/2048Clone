using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    [SerializeField] private List<Slot> _slots = new List<Slot>();
    [SerializeField] private GameObject _slotsParent;
    [SerializeField] private GameObject slotsRow;
    [SerializeField] private LevelData _levelData;
    [SerializeField] private NumberTile _tile;
    [SerializeField] private GameObject _emptyTilesParent;
    private List<int> slotToMove = new List<int>();
    private float thresholdMovement = 0.5f;
    
    void Start()
    {
        CreatingSlots();
        CreateTiles();
    }

    private void OnEnable()
    {
        InputActionHandler.MoveDirectionBroadcast += TileMovementHandler;
    }

    private void OnDisable()
    {
        InputActionHandler.MoveDirectionBroadcast -= TileMovementHandler;
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


        NumberTile tempTile;
        for (int i = 0; i < initialTilesVals.Count; i++)
        {
            tempTile = Instantiate(_tile);
            tempTile.SetValue(initialTilesVals[i]);
            _slots[slotsToFillIds[i]].placeTile(tempTile);
        }
    }

    void MoveTile(int presentSlotId, int futureSlotId)
    {
        Debug.Log($"Moving tile from {presentSlotId} to {futureSlotId}");
        NumberTile tempTile;
        tempTile = _slots[presentSlotId].RemoveTile();
        _slots[futureSlotId].placeTile(tempTile);
    }

    void TileMovementHandler(Vector2 movementDirection)
    {
        if (movementDirection.magnitude ==1)
        {
            foreach (var slot in _slots)
            {
                if (slot.GetTileWithin() != null)
                {
                    Debug.Log("Tile is present ");
                    slotToMove.Add(slot.index);
                }
            }
        }
        MoveTilesHandler(movementDirection);
    }
    
    void MoveTilesHandler(Vector2 moveDir)
    {
        Debug.Log("Move tiles called " + slotToMove.Count);
        int slotDelta;
        int targetSlot;
        if (moveDir.x > 0)
            slotDelta = 1;
        else if (moveDir.x < 0)
            slotDelta = -1;
        else if (moveDir.y < 0)
            slotDelta = _levelData.slotsColumnCount;
        else
            slotDelta = -_levelData.slotsColumnCount;
        
        foreach (var slot in slotToMove)
        {
            targetSlot = slot + slotDelta;
            if (targetSlot >= 0 && targetSlot < _slots.Count)
            {
                if(_slots[targetSlot].GetTileWithin() == null)
                    MoveTile(slot,targetSlot);
            }
        }
        slotToMove.Clear();
    }
}