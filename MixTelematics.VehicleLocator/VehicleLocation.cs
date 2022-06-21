using System.Text;

namespace MixTelematics.VehicleLocator
{
    internal class VehicleLocation
	{
		public int ID;

		public string Registration;

		public float Latitude;

		public float Longitude;

		public DateTime RecordedTimeUTC;

		internal byte[] GetBytes()
		{
			List<byte> list = new List<byte>();
			list.AddRange(BitConverter.GetBytes(ID));
			list.AddRange(Helper.ToNullTerminatedString(Registration));
			list.AddRange(BitConverter.GetBytes(Latitude));
			list.AddRange(BitConverter.GetBytes(Longitude));
			list.AddRange(BitConverter.GetBytes(Helper.ToCTime(RecordedTimeUTC)));
			return list.ToArray();
		}

		internal static VehicleLocation FromBytes(byte[] buffer, ref int offset)
		{
            var vehiclePosition = new VehicleLocation
            {
                ID = BitConverter.ToInt32(buffer, offset)
            };

            Interlocked.Add(ref offset, 4);
			var stringBuilder = new StringBuilder();

			while (buffer[offset] != 0)
			{
				stringBuilder.Append((char)buffer[offset]);
				Interlocked.Add(ref offset, 1);
			}

			vehiclePosition.Registration = stringBuilder.ToString();
			Interlocked.Add(ref offset, 1);
			vehiclePosition.Latitude = BitConverter.ToSingle(buffer, offset);
			Interlocked.Add(ref offset, 4);
			vehiclePosition.Longitude = BitConverter.ToSingle(buffer, offset);
			Interlocked.Add(ref offset, 4);
			ulong cTime = BitConverter.ToUInt64(buffer, offset);
			vehiclePosition.RecordedTimeUTC = Helper.FromCTime(cTime);
			Interlocked.Add(ref offset, 8);

			return vehiclePosition;
		}
	}
}

