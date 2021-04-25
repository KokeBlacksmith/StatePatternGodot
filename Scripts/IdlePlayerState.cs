using Godot;
using System;

public class IdlePlayerState : Node, IState<Player>
{
    public void OnStateEnter(Player character)
    {
        character.AnimatedSprite.Play("Idle");
        character.Velocity = Vector2.Zero;
    }

    public void OnStateExit(Player character)
    {
    }

    public IState<Player> Update(Player character, float delta)
    {
       if(Input.IsActionPressed("ui_right") || Input.IsActionPressed("ui_left"))
            return character.States["Movement"];


        if(Input.IsActionPressed("ui_select"))
            return character.States["Attack"];
            
        return null;
    }
}
