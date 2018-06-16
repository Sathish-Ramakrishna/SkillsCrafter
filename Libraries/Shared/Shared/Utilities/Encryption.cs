using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SkillsCrafter.Shared.Utilities
{
	public static class Encryption
	{
		#region Methods.Private

		private static Byte[] Key(string seed)
		{
			Byte[] key = new Byte[32];
			//
			using (SHA1Managed sha = new SHA1Managed())
			{
				Byte[] hash = sha.ComputeHash(Encoding.Unicode.GetBytes(seed));
				//
				for (int i = 0; i < 32; i++)
				{
					if (i < 20) key[i] = hash[i];
					else key[i] = hash[i - 20];
				}
			}
			//
			return key;
		}

		private static Byte[] Vector(string seed)
		{
			Byte[] vector = new Byte[16];
			//
			using (SHA1Managed sha = new SHA1Managed())
			{
				Byte[] hash = sha.ComputeHash(Encoding.Unicode.GetBytes(seed));
				//
				for (int i = 0; i < 16; i++) vector[i] = hash[i];
			}
			//
			return vector;
		}

		#endregion

		#region Methods.Public

		public static String Decrypt(byte[] data, string seed)
		{
			String result = String.Empty;
			//
			if (data == null || data.Length == 0) return result;
			//
#if NETCF
			RijndaelManaged aes = new RijndaelManaged();
#else
			AesManaged aes = new AesManaged();
#endif
			//
			aes.IV = Encryption.Vector(seed);
			aes.Key = Encryption.Key(seed);
			//
			try
			{
				using (MemoryStream memory = new MemoryStream(data))
				using (CryptoStream crypto = new CryptoStream(memory, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
				using (StreamReader reader = new StreamReader(crypto))
				{
					result = reader.ReadToEnd();
				}
			}
			catch
			{
				result = String.Empty;
			}
			finally
			{
				if (aes != null) aes.Clear(); 
			}
			//
			return result;
		}

		public static Byte[] Encrypt(string data, string seed)
		{
			Byte[] result = new Byte[] { };
			//
			if (String.IsNullOrEmpty(data)) return result;
			//
#if NETCF
			RijndaelManaged aes = new RijndaelManaged();
#else
			AesManaged aes = new AesManaged();
#endif
			//
			aes.IV = Encryption.Vector(seed);
			aes.Key = Encryption.Key(seed);
			//
			try
			{
				using (MemoryStream memory = new MemoryStream())
				{
					using (CryptoStream crypto = new CryptoStream(memory, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
					using (StreamWriter writer = new StreamWriter(crypto))
					{
						writer.Write(data);
					}
					//
					result = memory.ToArray();
				}
			}
			catch
			{
				result = new Byte[] { };
			}
			finally
			{
				if (aes != null) aes.Clear();
			}
			//
			return result;
		}

		#endregion
	}
}
