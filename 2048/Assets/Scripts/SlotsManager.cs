using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void MoveTiles(Direction dir)
    {
        List<Slot> filledSlots = new List<Slot>();

        foreach (Slot slot in slots)
        {
            if (slot.GetTileWithin() != null)
                filledSlots.Add(slot);
        }
        List<Slot> tempSlots = filledSlots.OrderBy(b => b.transform.position.x).ThenBy(b => b.transform.position.y).ToList();
        if (dir == Direction.right || dir == Direction.up)
            tempSlots.Reverse();

        //List<Tile> orderedTiles = new List<Tile>();
        //foreach (Slot slot in tempSlots)
        //{
        //    orderedTiles.Add(slot.GetTileWithin());
        //}

        

        //switch(dir)
        //{
        //    case (Direction.up):                
        //        MoveTilesUp();
        //        break;
        //    case (Direction.down):
        //        MoveTilesDown();
        //        break;
        //    case (Direction.left):
        //        MoveTilesLeft();
        //        break;
        //    case (Direction.right):
        //        MoveTilesRight();
        //        break;
        //}
    }

    public void Init()
    {
        var tempSlots = new List<Slot>();
        int slotsCount = 2;
        tempSlots =  RandomList.shuffleAndGenerateRandom(slots,slotsCount);
        for(int i = 0; i < slotsCount; i++)
        {
            tempSlots[i].CreateTile(Instantiate(tilePrefab),2);
        }
    }
    private void MoveTilesUp()
    {
        Debug.Log("up");
    }    
    private void MoveTilesDown()
    {
        Debug.Log("Down");
    }
    private void MoveTilesRight()
    {
        Debug.Log("Right");
    }
    private void MoveTilesLeft()
    {
        Debug.Log("Left");
    }
}
