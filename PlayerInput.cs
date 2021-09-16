using Godot;

public class PlayerInput : Node
{
    public Vector2 Player1Movement => _player1Movement;

    private Vector2 _player1Movement = new Vector2(0, 0);

    private void GetHorizontalMovement()
    {
        float horizontal = 0;
        float vertical = 0;

        var leftNegative = Input.GetActionStrength("player1_left");
        var rightpositive = Input.GetActionStrength("player1_right");
        var upPositive = Input.GetActionStrength("player1_up");
        var downNegative = Input.GetActionStrength("player1_down");

        if (leftNegative > rightpositive) horizontal = -leftNegative;
        if (rightpositive > leftNegative) horizontal = rightpositive;
        if (upPositive > downNegative) vertical = upPositive;
        if (downNegative > upPositive) vertical = -downNegative;

        _player1Movement.x = horizontal;
        _player1Movement.y = -vertical;
    }

    public override void _PhysicsProcess(float delta)
    {
        GetHorizontalMovement();
    }
}