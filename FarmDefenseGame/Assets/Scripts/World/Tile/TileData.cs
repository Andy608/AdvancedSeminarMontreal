using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    public enum TileType
    {
        AIR,
        GRASS,
        DIRT,
        WATER
    }

    public TileType tileType;

    public TileData(TileType type)
    {
        tileType = type;
    }
}
