namespace VUtils.generic;

public class Option<T>
{
    private T? value;
    private bool has;

    private Option(T t)
    {
        this.value = t;
        has = true;
    }
    
    private Option()
    {
        this.value = default;
        has = false;
    }

    public bool Has()
    {
        return has;
    }

    public T Get()
    {
        if (Has())
        {
            return value;
        }

        throw new NullReferenceException("Unwrapped Null-type option!");
    }
    
    public Option<T> Take()
    {
        if (has)
        {
            has = false;
            return this;
        }

        return None<T>();
    }
    
    public static implicit operator bool(Option<T?> instance)
    {
        return instance.Has();
    }
    
    public static Option<R> None<R>()
    {
        return new Option<R>();
    }
    
    public static Option<R> Some<R>(R t)
    {
        return new Option<R>(t);
    }
}