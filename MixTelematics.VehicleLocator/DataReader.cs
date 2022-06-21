namespace MixTelematics.VehicleLocator
{
    public class DataReader
	{
		internal static async Task<List<VehicleLocation>> ReadDataFileAsync(string filePath)
		{
			byte[] array = await ReadFileDataAsync(filePath);
			var list = new List<VehicleLocation>();

			int offset = 0;
            while (offset < array.Length)
            {
                list.Add(ReadVehicleLocation(array, ref offset));
            }
            return list;
		}

		internal static async Task<byte[]> ReadFileDataAsync(string filePath)
		{
			if (!File.Exists(filePath))
			{
				Console.WriteLine("Data file not found.");
				return null;
			}

			return await File.ReadAllBytesAsync(filePath);
		}

		private static VehicleLocation ReadVehicleLocation(byte[] data, ref int offset)
		{
			return VehicleLocation.FromBytes(data, ref offset);
		}
	}
}

