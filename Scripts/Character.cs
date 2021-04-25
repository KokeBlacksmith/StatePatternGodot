using Godot;
using System.Collections.Generic;
using System;

public abstract class Character<T> : KinematicBody2D, IStateManager<T> where T : Character<T>
{
    [Export]
    private int _speed = 100;

    public Dictionary<string, IState<T>> States { get; protected set; }
    protected IState<T> _currentState = null;

    public AnimatedSprite AnimatedSprite { get; protected set; }
    public Vector2 Velocity { get; set; }

    public int Speed { get => _speed; }

    public override void _Ready()
    {
        FetchStates();
        AnimatedSprite = (AnimatedSprite)GetNode("AnimatedSprite");
        Velocity = Vector2.Zero;
    }

    public virtual void FetchStates()
    {
        throw new NotImplementedException();
    }

    public IState<T> GetCurrentState()
    {
        return _currentState;
    }

    public IState<T> ChangeCurrentState(IState<T> newState)
    {
        _currentState?.OnStateExit((T)this);
        _currentState = newState;
        _currentState?.OnStateEnter((T)this);
        return _currentState;
    }

    public override void _PhysicsProcess(float delta)
    {
        IState<T> newState = this.GetCurrentState().Update((T)this, delta);

        if(newState != null)
            this.ChangeCurrentState(newState);

        Velocity = this.MoveAndSlide(Velocity, Vector2.Up);
    }

    public virtual void Flip()
    {
        AnimatedSprite.FlipH = !AnimatedSprite.FlipH;
    }

    public bool CalculateSpriteFlip()
    {
        if((Velocity.x > 0 && AnimatedSprite.FlipH) || (Velocity.x < 0 && !AnimatedSprite.FlipH))
        {
            Flip();
            return true;
        }

        return false;
    }

}