using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    //Holds all of the tiles in the game.
    public class TileDataManager : Singleton<TileDataManager>
    {
        public readonly static TileData AIR_TILE = new TileData(TileData.TileType.AIR);
        public readonly static TileData GRASS_TILE = new TileData(TileData.TileType.GRASS);

    }
}
