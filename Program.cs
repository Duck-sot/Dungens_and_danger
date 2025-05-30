
using var game = new Dungens_and_danger.Game1();
game.Run();



/*
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

List<AttackMove> attacks = new();
attacks.Add(new PowerAttack()); 
attacks.Add(new SmashAttack());

foreach (var a in attacks)
{
    a.Attack();   
}

using var game = new Dungens_and_danger.Game1();
game.Run();


interface AttackMove
{

    void Attack();
}

class PowerAttack : AttackMove
{
    float power;
    public void Attack()
    {
        Console.WriteLine("Shooting");
    }
}

class SmashAttack : AttackMove
{
    float power;
    public void Attack()
    {
        Console.WriteLine("Smashattack!");
    }
}

*/

