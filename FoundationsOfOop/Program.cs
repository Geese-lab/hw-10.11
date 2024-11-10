using Automotive;

var car1 = new Car("Opel", "Insignia", 65, 10);
//var car2 = new Car("Ford", null, 100, 19);

Console.WriteLine($"{car1.Brand} {car1.Model} has tank capacity of {car1.TankCapacity} " +
    $"and takes {car1.FuelConsumption} liter per 100 km");

//for an experiment with the limit
car1.Max();

car1.Tank(10);
Console.WriteLine($"We now have {car1.FuelLevel} liters");

car1.Tank(5);
Console.WriteLine($"We now have {car1.FuelLevel} liters");

car1.Drive(50);
Console.WriteLine($"Odometer: {car1.Odometer}, Daily odometer: {car1.DailyOdometer:F1}, Fuel level: {car1.FuelLevel}");

car1.Drive(60);
Console.WriteLine($"Odometer: {car1.Odometer}, Daily odometer: {car1.DailyOdometer:F1}, Fuel level: {car1.FuelLevel}");

car1.Reset();

car1.Drive(60);
Console.WriteLine($"Odometer: {car1.Odometer}, Daily odometer: {car1.DailyOdometer:F1}, Fuel level: {car1.FuelLevel}");
