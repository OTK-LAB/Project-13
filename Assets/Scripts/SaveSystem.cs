using UnityEngine;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Security.Cryptography;
public static class SaveSystem
{
      private static readonly byte[] Key = new byte[] { 0x03, 0x02, 0x03, 0x01, 0x04, 0x02, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
      private static readonly byte[] Iv = new byte[] { 0x03, 0x01, 0x02, 0x01, 0x04, 0x02, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
      public static GameFiles gameFiles = new GameFiles();
      private static string directory = "/SaveData/";
      private static string fileName = "Gamedata.txt";
      public static void Save()
      {
            string dir = Application.persistentDataPath + directory;
            if (!(Directory.Exists(dir)))
                  Directory.CreateDirectory(dir);
            string jsonFile = JsonUtility.ToJson(gameFiles, true);
            string encyrptedJsonFile = Encrypt(jsonFile);
            File.WriteAllText(dir + fileName, encyrptedJsonFile);
      }

      //We Save The GameFiles class as Save.json here.
      public static void Load()
      {
            string fullPath = Application.persistentDataPath + directory + fileName;

            if (File.Exists(fullPath))
            {
                  string jsonFile = File.ReadAllText(fullPath);
                  string decyrptedJsonFile = Decrypt(jsonFile);
                  gameFiles = JsonUtility.FromJson<GameFiles>(decyrptedJsonFile);
            }
            else
            {
                  Save();
            }
            // LanguageManager.LanguageSelector();
      }

      public static string Encrypt(string plainText)
      {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (Aes aes = Aes.Create())
            {
                  aes.Key = Key;
                  aes.IV = Iv;
                  using (MemoryStream memoryStream = new MemoryStream())
                  {
                        CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        byte[] cipherTextBytes = memoryStream.ToArray();
                        return Convert.ToBase64String(cipherTextBytes);
                  }
            }
      }
      public static string Decrypt(string cipherText)
      {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                  aes.Key = Key;
                  aes.IV = Iv;
                  using (MemoryStream memoryStream = new MemoryStream())
                  {
                        CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
                        cryptoStream.Write(cipherTextBytes, 0, cipherTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        byte[] plainTextBytes = memoryStream.ToArray();
                        return Encoding.UTF8.GetString(plainTextBytes);
                  }
            }
      }
}