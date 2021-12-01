using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField] 
    private Slot _slot;
    [SerializeField] 
    private List<Slot> _slots = new List<Slot>();
    [SerializeField] 
    private GameObject _slotsParent;
    [SerializeField] 
    private GameObject slotsRow;

    public void CreateSlots(int row, int column)
    {
        GameObject tempRow;
        Slot tempSlot;
        int index = 0;
        for (int i = 0; i < row; i++)
        {
            tempRow = Instantiate(slotsRow, _slotsParent.transform);
            for (int j = 0; j <column; j++)
            {
                tempSlot = Instantiate(_slot, tempRow.transform);
                tempSlot.index = index;
                _slots.Add(tempSlot);
                index++;
            }
        }
        tempRow = null;
    }

    void MoveTile(int presentSlotId, int futureSlotId)
    {
        Debug.Log($"Moving tile from {presentSlotId} to {futureSlotId}");
        NumberTile tempTile;
        tempTile = _slots[presentSlotId].RemoveTile();
        _slots[futureSlotId].placeTile(tempTile);
    }
    void CreateTiles()
    {
        //List<int> slotsToFillIds = _levelData.GetInitialSlotIndices(2);
        //List<int> initialTilesVals = _levelData.GetInitialTileValues(2);


        //NumberTile tempTile;
        //for (int i = 0; i < initialTilesVals.Count; i++)
        //{
        //    tempTile = Instantiate(_tile);
        //    tempTile.SetValue(initialTilesVals[i]);
        //    _slots[slotsToFillIds[i]].placeTile(tempTile);
        //}
    }
}
