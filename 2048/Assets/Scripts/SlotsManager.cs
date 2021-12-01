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
    private List<Slot> slots = new List<Slot>();
    [SerializeField] 
    private GameObject slotsParent;
    [SerializeField] 
    private GameObject slotsRow;
    [SerializeField]
    private TilesManager tilesManager; 

    public void CreateSlots(int row, int column)
    {
        GameObject tempRow;
        Slot tempSlot;
        int index = 0;
        for (int i = 0; i < row; i++)
        {
            tempRow = Instantiate(slotsRow, slotsParent.transform);
            for (int j = 0; j <column; j++)
            {
                tempSlot = Instantiate(_slot, tempRow.transform);
                tempSlot.index = index;
                slots.Add(tempSlot);
                index++;
            }
        }
        tempRow = null;
    }

    public void MoveTiles(direction dir)
    {
        switch(dir)
        {
            case (direction.up):
                Debug.Log(dir);
                break;
            case (direction.down):
                Debug.Log(dir);
                break;
            case (direction.left):
                Debug.Log(dir);
                break;
            case (direction.right):
                Debug.Log(dir);
                break;
        }
    }


}
