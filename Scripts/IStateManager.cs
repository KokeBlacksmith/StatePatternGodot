using System.Collections.Generic;

public interface IStateManager<T>
{
    Dictionary<string, IState<T>> States { get; }
    void FetchStates();

    IState<T> GetCurrentState();
    IState<T> ChangeCurrentState(IState<T> newState);
}