namespace Politics.Scripts.Models;

public struct RangeValue
{
    public float Value;
    public float Max;

    public RangeValue(float max)
    {
        Max = max;
        Value = max;
    }
    
    public RangeValue(float max, float value)
    {
        Max = max;
        Value = value;
    }
}