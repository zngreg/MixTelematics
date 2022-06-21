using System.Diagnostics;
using MixTelematics.VehicleLocator;

var filePath = "VehiclePositions.dat";
var stopwatch = Stopwatch.StartNew();

var vehiclePositions = await DataReader.ReadDataFileAsync(filePath);

stopwatch.Stop();
long readerTimestamp = stopwatch.ElapsedMilliseconds;
stopwatch.Restart();

Parallel.ForEach(Helper.BuildCoordinates(), coord =>
{
	double maxDistance = double.MaxValue;
	VehicleLocation? closest = null;

	Parallel.ForEach(vehiclePositions, (vehclePos) =>
	{
		var dist = GeoLocate.DistanceTo(coord.Latitude, coord.Longitude, vehclePos.Latitude, vehclePos.Longitude, 'M');

		if (dist < maxDistance)
		{
			closest = vehclePos;
			maxDistance = dist;
		}
	});
});

stopwatch.Stop();
Console.WriteLine($"Data file read execution time : {readerTimestamp} ms");
Console.WriteLine($"Closest position calculation execution time : {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"Total execution time : {readerTimestamp + stopwatch.ElapsedMilliseconds} ms");
Console.ReadLine();
