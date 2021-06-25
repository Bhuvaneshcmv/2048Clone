using UnityEngine;

public class Slot : MonoBehaviour
{
    public int index { get; set;}
    public Tile tileWithin;

    public void placeTile(Tile tile)
    {
        tile.transform.position = transform.position;
        tile.transform.SetParent(transform);
        tileWithin = tile;
    }

    public Tile RemoveTile()
    {
        Tile tempTile = tileWithin;
        tileWithin.transform.SetParent(null);
        tileWithin = null;
        return tempTile;
    }
}
