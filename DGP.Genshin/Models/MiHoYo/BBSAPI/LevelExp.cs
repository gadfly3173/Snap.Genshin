﻿using DGP.Snap.Framework.Attributes.DataModel;
using Newtonsoft.Json;

namespace DGP.Genshin.Models.MiHoYo.BBSAPI
{
    [JsonModel]
    public class LevelExp
    {
        [JsonProperty("level")] public int Level { get; set; }
        [JsonProperty("exp")] public int Exp { get; set; }
        [JsonProperty("game_id")] public int GameId { get; set; }
    }
}