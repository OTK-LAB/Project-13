using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
      public int points;
      public string userName;
      public SnakeManager snakeManager;
      public List<string> names = new List<string>()
      {
  "PixelPirate",  "SonicSlinger",  "ToxicTornado",  "CrimsonChaos",  "RogueRider",  "GlitchGunner",  "NightNinja",  "CosmicCyclone",  "LunarLancer",  "Ironclad",  "GalacticGuardian",  "ViralVortex",  "NeonNemesis",  "StardustStriker",  "ShadowSlayer",  "Firestarter",  "VenomVindicator",  "ElectricEnigma",  "BlazeBlitzer",  "PlasmaPilot",  "StormySamurai",  "CyberCrusader",  "ArcaneAssassin",  "DragonDominator",  "PhoenixFury",  "NinjaNebula",  "WarriorWizard",  "PolarPaladin",  "MightyMage",  "GravityGuru",  "MetalMarauder",  "CrystalCrafter",  "GalacticGladiator",  "CosmicConqueror",  "SavageSorcerer",  "Mastermind",  "EternalEmperor",  "MysticalMercenary",  "AncientAlien",  "SoulSavior",  "TimeTraveler",  "DeathDealer",  "DimensionDestroyer",  "GrimGrimoire",  "InfiniteInquisitor",  "OblivionOverlord",  "RadiantRanger",  "ZeroZenith",  "NeptuneNemesis"
      };
      private void Start()
      {
            if (snakeManager.entityType == EntityType.AI)
                  userName = names[Random.Range(0, names.Count - 1)] + Random.Range(0, 128);
            else if (snakeManager.entityType == EntityType.User)
                  userName = SaveSystem.gameFiles.userName;
      }
      private void Update()
      {
            if (points / snakeManager.bodyParts.Count > 5 && snakeManager.bodyParts.Count <= 5)
                  snakeManager.CreateBodyPart();
      }
}
