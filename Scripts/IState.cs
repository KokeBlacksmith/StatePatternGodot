public interface IState<T>
{
    void OnStateEnter(T character);
    void OnStateExit(T character);
    IState<T> Update(T character, float delta);
}