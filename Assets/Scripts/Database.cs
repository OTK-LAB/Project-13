using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
[System.Serializable]
public class SkinDatabase : SerializableDictionaryBase<SkinID, GameObject> { }
[CreateAssetMenu(fileName = "Database", menuName = "Snake Game/Database", order = 0)]
public class Database : ScriptableObject
{
      public SkinDatabase skinDatabase;
}
public enum SkinID
{
      Basketball, Camo, RedAndBrown, Bee, King
}
