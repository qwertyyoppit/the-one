
public class StatModifier
{
    public StatType Type = 0;
    public float Value;
    public IOperationStrategy Operation;

    public StatModifier(StatType type, float value, IOperationStrategy operation)
    {
        Type = type;
        Value = value;
        if (operation is PercentOperation) Operation = new PercentOperation(ref value);
        if (operation is AddOperation) Operation = new AddOperation(ref value);
        if (operation is MultiplyOperation) Operation = new MultiplyOperation(ref value);
    }

    public void Handle()
    {

    }
}