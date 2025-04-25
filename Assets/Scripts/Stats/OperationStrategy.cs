public interface IOperationStrategy
{
    public float Calculate(float value);
}

public class PercentOperation : IOperationStrategy
{
    private readonly float _value;

    public PercentOperation(ref float value)
    {
        _value = value;
    }

    public float Calculate(float value)
    {
        return value + value * _value;
    }
}

public class AddOperation : IOperationStrategy
{
    private readonly float _value;

    public AddOperation(ref float value)
    {
        _value = value;
    }

    public float Calculate(float value)
    {
        return _value + value;
    }
}

public class MultiplyOperation : IOperationStrategy
{
    private readonly float _value;

    public MultiplyOperation(ref float value)
    {
        _value = value;
    }

    public float Calculate(float value)
    {
        return _value * value;
    }
}