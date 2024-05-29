namespace VUtils.generic.iterator;

public class StepBy<T>(Iterator<T?> iterator, int step): Iterator<T?>
{
    public override Option<T?> Next()
    {
        var next = iterator.Next();
        for (int i = 0; i < step - 1; i++)
        {
            next = iterator.Next();
        }

        return next;
    }
}