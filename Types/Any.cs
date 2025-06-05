using MSGO.Server.Sessions;

public abstract class Any<T1> : BaseSession where T1 : BaseSession
{
    protected Any() => throw new InvalidOperationException("Any<T> is not meant to be instantiated.");
}

public abstract class Any<T1, T2> : BaseSession
    where T1 : BaseSession
    where T2 : BaseSession
{
    protected Any() => throw new InvalidOperationException("Any<T1, T2> is not meant to be instantiated.");
}

public abstract class Any<T1, T2, T3> : BaseSession
    where T1 : BaseSession
    where T2 : BaseSession
    where T3 : BaseSession
{
    protected Any() => throw new InvalidOperationException("Any<T1, T2, T3> is not meant to be instantiated.");
}