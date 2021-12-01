using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    [SerializeField] private LevelData _levelData;
    [SerializeField] private SlotsManager slotsManager;

    private direction movementDir;

    void Start()
    {
        slotsManager.CreateSlots(_levelData.slotsRowCount, _levelData.slotsColumnCount);
    }

    private void OnEnable()
    {
        InputActionHandler.MoveDirectionBroadcast += HandleDirection;
    }

    private void OnDisable()
    {
        InputActionHandler.MoveDirectionBroadcast -= HandleDirection;
    }

    void HandleDirection(Vector2 moveVec)
    {
        if (moveVec.magnitude > 0.5f)
        {
            if (moveVec.x > 0)
            {
                movementDir = direction.right;
            }
            else if (moveVec.x < 0)
            {
                movementDir = direction.left;
            }
            else if (moveVec.y < 0)
            {
                movementDir = direction.down;
            }
            else if (moveVec.y > 0)
            {
                movementDir = direction.up;
            }

            slotsManager.MoveTiles(movementDir);
        }
    }
}