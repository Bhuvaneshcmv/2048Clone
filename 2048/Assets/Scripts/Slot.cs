using UnityEngine;

public class Slot : MonoBehaviour
{
    public int index { get; set;}
    private NumberTile tileWithin;

    public void placeTile(NumberTile tile)
    {
        tile.transform.position = transform.position;
        tile.transform.SetParent(transform);
        tileWithin = tile;
    }

    public NumberTile RemoveTile()
    {
        NumberTile tempTile = tileWithin;
        tileWithin.transform.SetParent(null);
        tileWithin = null;
        return tempTile;
    }

    public NumberTile GetTileWithin()
    {
        return tileWithin;
    }
}
