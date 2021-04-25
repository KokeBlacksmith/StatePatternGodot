using Godot;
using System;

public class MovementPlayerState : Node, IState<Player>
{
    public void OnStateEnter(Player character)
    {
        character.AnimatedSprite.Play("Walk");
    }

    public void OnStateExit(Player character)
    {
    }

    public IState<Player> Update(Player character, float delta)
    {
        character.CalculateSpriteFlip();

        Vector2 tmpVelocity = Vector2.Zero;
        if(Input.IsActionPressed("ui_right"))
        {
            tmpVelocity.x = character.Speed;
        }
        else if(Input.IsActionPressed("ui_left"))
        {
            tmpVelocity.x = -character.Speed;
        }
        else
        {
            return character.States["Idle"];
        }

        if(Input.IsActionPressed("ui_select"))
            return character.States["Attack"];

        character.Velocity = tmpVelocity;

        return null;
    }
}
