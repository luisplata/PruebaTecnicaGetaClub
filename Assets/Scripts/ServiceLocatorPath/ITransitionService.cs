using System;

public interface ITransitionService
{
    void Open(Action callback);
    void Close(Action callback);
}