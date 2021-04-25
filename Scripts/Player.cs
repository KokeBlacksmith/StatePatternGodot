using Godot;
using System;
using System.Collections.Generic;

public class Player : Character<Player>
{

    public override void _Ready()
    {
        base._Ready();
        this.ChangeCurrentState(States["Idle"]);
    }

    public override void FetchStates()
    {
        States = new Dictionary<string, IState<Player>>()
        {
            {"Idle", (IdlePlayerState)GetNode("States/Idle")},
            {"Movement", (MovementPlayerState)GetNode("States/Movement")},
            {"Attack", (AttackPlayerState)GetNode("States/Attack")}
        };
    }
}
