using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProgramming2D
{
    [Serializable]
    public class GameData
    {
        public int Score;
        public PlayerData PlayerData;
        public List<EnemyData> EnemyDatas;
    }
}
