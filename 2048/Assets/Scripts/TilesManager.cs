using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [SerializeField]
    private Tile tilePrefab;
    
    Tile CreateTile(int value)
    {
        Tile tile = Instantiate(tilePrefab);
        tile.SetValue(value);
        return tile;
    }

    void MoveTile(Slot slot1, Slot slot2)
    {
        Tile tile = slot1.RemoveTile();
        slot2.PlaceTile(tile);
    }
    void CreateTiles(List<Slot> slots,List<int> tileVals)
    {
        for(int i = 0; i < slots.Count; i++)
        {
            Tile tile = CreateTile(tileVals[i]);
            slots[i].PlaceTile(tile);
        }
    }
    //void MoveTilesHandler(Vector2 moveDir)
    //{
    //    Debug.Log("Move tiles called " + slotToMove.Count);
    //    int slotDelta;
    //    int targetSlot;
    //    if (moveDir.x > 0)
    //        slotDelta = 1;
    //    else if (moveDir.x < 0)
    //        slotDelta = -1;
    //    else if (moveDir.y < 0)
    //        slotDelta = _levelData.slotsColumnCount;
    //    else
    //        slotDelta = -_levelData.slotsColumnCount;

    //    foreach (var slot in slotToMove)
    //    {
    //        targetSlot = slot + slotDelta;
    //        if (targetSlot >= 0 && targetSlot < _slots.Count)
    //        {
    //            if (_slots[targetSlot].GetTileWithin() == null)
    //                MoveTile(slot, targetSlot);
    //        }
    //    }
    //    slotToMove.Clear();
    //}
}
