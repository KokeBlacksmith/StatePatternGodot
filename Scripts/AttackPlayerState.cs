using Godot;
using System;

public class AttackPlayerState : Node, IState<Player>
{
    public void OnStateEnter(Player character)
    {
        character.Velocity = Vector2.Zero;
        character.AnimatedSprite.Play("Attack");
    }

    public void OnStateExit(Player character)
    {
        
    }

    public IState<Player> Update(Player character, float delta)
    {
        if(!Input.IsActionPressed("ui_select"))
            return character.States["Idle"];

        return null;
    }
}
