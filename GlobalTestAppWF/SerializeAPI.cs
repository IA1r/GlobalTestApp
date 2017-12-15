using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTestAppWF
{
	[Serializable]
	public class FileData
	{
		public string FilePath { get; set; }
		public byte[] FileBytes { get; set; }
	}

	/// <summary>
	/// Оbject that stores directories and files that need to be serialized
	/// </summary>
	[Serializable]
	public class SerializeData
	{
		public string[] Directories { get; set; }

		public FileData[] Files { get; set; }
	}

	/// <summary>
	/// Serialize API
	/// </summary>
	public class SerializeAPI
	{
		BinaryFormatter formatter;

		/// <summary>
		/// Initializes a new instance of the <see cref="SerializeAPI"/> class.
		/// </summary>
		public SerializeAPI()
		{
			this.formatter = new BinaryFormatter();
		}

		/// <summary>
		/// Serializes the specified folder to file.
		/// </summary>
		/// <param name="pathToFolder">The path to folder.</param>
		/// <param name="pathToSave">The path to save.</param>
		public void Serialize(string pathToFolder, string pathToSave)
		{
			SerializeData serializeData = new SerializeData();

			serializeData.Directories = Directory.GetDirectories(pathToFolder, "*.*", SearchOption.AllDirectories)
				.Select(d => d.Remove(0, pathToFolder.Length))
				.ToArray();

			serializeData.Files = Directory.GetFiles(pathToFolder, "*.*", SearchOption.AllDirectories)
				.Select(f => new FileData
				{
					FilePath = f.Remove(0, pathToFolder.Length),
					FileBytes = File.ReadAllBytes(f)
				}).ToArray();

			using (FileStream fs = new FileStream(pathToSave, FileMode.OpenOrCreate))
			{
				this.formatter.Serialize(fs, serializeData);
			}
		}

		/// <summary>
		/// Deserializes the specified file to folder.
		/// </summary>
		/// <param name="pathToFile">The path to file.</param>
		/// <param name="pathToSave">The path to save.</param>
		public void Deserialize(string pathToFile, string pathToSave)
		{
			using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
			{
				SerializeData serializeData1 = (SerializeData)this.formatter.Deserialize(fs);

				foreach (string item in serializeData1.Directories)
					Directory.CreateDirectory(pathToSave + item);

				foreach (FileData item in serializeData1.Files)
				{
					string destFile = Path.Combine(pathToSave, item.FilePath);
					File.WriteAllBytes(destFile, item.FileBytes);
				}
			}
		}
	}
}
