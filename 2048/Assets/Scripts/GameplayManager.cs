using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    [SerializeField] private LevelData _levelData;
    [SerializeField] private SlotsManager slotsManager;
    //[SerializeField] private NumberTile _tile;
    //[SerializeField] private GameObject _emptyTilesParent;
    //private List<int> slotToMove = new List<int>();
    //private float thresholdMovement = 0.5f;

    void Start()
    {
        slotsManager.CreateSlots(_levelData.slotsRowCount, _levelData.slotsColumnCount);
        //CreateTiles();
    }

    //private void OnEnable()
    //{
    //    InputActionHandler.MoveDirectionBroadcast += TileMovementHandler;
    //}

    //private void OnDisable()
    //{
    //    InputActionHandler.MoveDirectionBroadcast -= TileMovementHandler;
    //}

    //void TileMovementHandler(Vector2 movementDirection)
    //{
    //    if (movementDirection.magnitude == 1)
    //    {
    //        foreach (var slot in _slots)
    //        {
    //            if (slot.GetTileWithin() != null)
    //            {
    //                Debug.Log("Tile is present ");
    //                slotToMove.Add(slot.index);
    //            }
    //        }
    //    }
    //    MoveTilesHandler(movementDirection);
    //}

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