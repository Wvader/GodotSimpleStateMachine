using Godot;

namespace StateMachineDemo
{
    public class PlayerInput : Node
    {
        public Vector2 Player1Movement => _player1Movement;

        private Vector2 _player1Movement = new Vector2(0, 0);

        private void GetHorizontalMovement()
        {
            float horizontal = 0;
            float vertical = 0;

            var leftNegative = Input.GetActionStrength("player1_left");
            var rightPositive = Input.GetActionStrength("player1_right");
            var upNegative = Input.GetActionStrength("player1_up");
            var downPositive = Input.GetActionStrength("player1_down");

            if (leftNegative > rightPositive) horizontal = -leftNegative;
            if (rightPositive > leftNegative) horizontal = rightPositive;
            if (upNegative > downPositive) vertical = -upNegative;
            if (downPositive > upNegative) vertical = downPositive;

            _player1Movement.x = horizontal;
            _player1Movement.y = vertical;
        }

        public override void _PhysicsProcess(float delta)
        {
            GetHorizontalMovement();
        }
    }
}