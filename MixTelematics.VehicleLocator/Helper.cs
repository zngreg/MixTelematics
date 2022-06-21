using System.Text;

namespace MixTelematics.VehicleLocator
{
	public class Helper
	{
		internal static DateTime BaseDate => new DateTime(1970, 1, 1, 0, 0, 0, 0);

        internal static byte[] ToNullTerminatedString(string registration)
        {
            byte[] bytes = Encoding.Default.GetBytes(registration);
            byte[] array = new byte[bytes.Length + 1];
            bytes.CopyTo(array, 0);
            return array;
        }

        internal static string SelectRandom(Random rnd, string[] values)
		{
			int num = rnd.Next(values.Length - 1);
			return values[num];
		}

		internal static ulong ToCTime(DateTime time)
		{
			return Convert.ToUInt64((time - BaseDate).TotalSeconds);
		}

		internal static DateTime FromCTime(ulong cTime)
		{
			return BaseDate.AddSeconds(cTime);
		}

		internal static Coordinates[] BuildCoordinates()
		{
			Coordinates[] array = new Coordinates[10];
			array[0].Latitude = 34.544909f;
			array[0].Longitude = -102.100843f;
			array[1].Latitude = 32.345544f;
			array[1].Longitude = -99.123124f;
			array[2].Latitude = 33.234235f;
			array[2].Longitude = -100.214124f;
			array[3].Latitude = 35.195739f;
			array[3].Longitude = -95.348899f;
			array[4].Latitude = 31.895839f;
			array[4].Longitude = -97.789573f;
			array[5].Latitude = 32.895839f;
			array[5].Longitude = -101.789573f;
			array[6].Latitude = 34.115839f;
			array[6].Longitude = -100.225732f;
			array[7].Latitude = 32.335839f;
			array[7].Longitude = -99.992232f;
			array[8].Latitude = 33.535339f;
			array[8].Longitude = -94.792232f;

			array[9].Latitude = 32.234235f;
			array[9].Longitude = -100.222222f;
			return array;
		}
	}

	internal struct Coordinates
	{
		public float Latitude;

		public float Longitude;
	}
}

