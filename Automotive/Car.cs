using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Automotive;

public class Car
{
    private string _brand;
    private string _model;
    private int _tankCapacity;
    private double _fuelConsumption;
    private double _fuelLevel;
    private double _odometer;
    private double _dailyOdometer;

    public Car(string brand, string model, int tankCapacity, double fuelConsumption)
    {
        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentNullException(nameof(brand), "The brand cannot be empty");

        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentNullException(nameof(model), "The model cannot be empty");

        if (tankCapacity <= 0)
            throw new ArgumentException("The tankCapacity must be positive", nameof(tankCapacity));

        if (fuelConsumption <= 0)
            throw new ArgumentException("The fuelConsumption must be positive", nameof(fuelConsumption));

        _brand = brand;
        _model = model;
        _tankCapacity = tankCapacity;
        _fuelConsumption = fuelConsumption;
    }

    public void Drive(int distance)
    {
        var maximumDistance = _fuelLevel / _fuelConsumption * 100;

        if (maximumDistance > distance)
        {
            _odometer += distance;
            if (_odometer > 999999) _odometer = _odometer - 999999;
            _dailyOdometer += distance;
            if (_dailyOdometer > 999.9) _dailyOdometer = _dailyOdometer - 999.9;
            _fuelLevel -= _fuelConsumption * distance / 100;
        }
        else
        {
            _odometer += maximumDistance;
            if (_odometer > 999999) _odometer = _odometer - 999999;
            _dailyOdometer += maximumDistance;
            if (_dailyOdometer > 999.9) _dailyOdometer = _dailyOdometer - 999.9;
            _fuelLevel = 0;
        }
        _dailyOdometer = Math.Round(_dailyOdometer, 1);
    }

    public void Tank(double amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be non-negative");

        _fuelLevel += amount;

        if (_fuelLevel > _tankCapacity)
            _fuelLevel = _tankCapacity;
    }
    public void Reset()
    {
        _dailyOdometer = 0;
        _dailyOdometer = Math.Round(_dailyOdometer, 1);
    }

    //for an experiment with the limit
    public void Max()
    {
        _odometer = 999900;
    }

    public string Brand => _brand;
    public string Model => _model;
    public int TankCapacity => _tankCapacity;
    public double FuelConsumption => _fuelConsumption;

    public int FuelLevel => (int)_fuelLevel;
    public int Odometer => (int)_odometer;
    public double DailyOdometer => (double)_dailyOdometer;
}