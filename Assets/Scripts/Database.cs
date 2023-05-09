using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
[System.Serializable]
public class SkinDatabase : SerializableDictionaryBase<SkinID, SkinData> { }
[CreateAssetMenu(fileName = "Database", menuName = "Snake Game/Database", order = 0)]
public class Database : ScriptableObject
{
      public SkinDatabase skinDatabase;
}
public enum SkinID
{
      None, Basketball, Camo, RedAndBrown, Bee, King
}
[System.Serializable]
public class SkinData
{
      public GameObject gameObject;
      public int price;
}