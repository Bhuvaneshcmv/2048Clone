using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    [SerializeField] private List<Slot> _slots = new List<Slot>();
    [SerializeField] private GameObject _slotsParent;
    [SerializeField] private GameObject slotsRow;
    [SerializeField] private LevelData _levelData;
    [SerializeField] private Tile _tile;

    void Start()
    {
        CreatingSlots();
        CreateTiles();
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
                index++;
                tempSlot = Instantiate(_slot, tempRow.transform);
                tempSlot.index = index;
                _slots.Add(tempSlot);
            }
        }
        tempRow = null;
    }

    void CreateTiles()
    {
        List<int> slotsToFill = _levelData.GetInitialSlotIndices(2);
        List<int> initialTiles = _levelData.GetInitialTileValues(2);
       
        
        Tile temp;
        for (int i=0; i < initialTiles.Count;i++)
        {
            temp = Instantiate(_tile, _slots[slotsToFill[i]].transform);
            temp.SetValue(initialTiles[i]);
        }
    }
}