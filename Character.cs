
using Godot;

namespace StateMachineDemo
{
    public class Character : KinematicBody2D
    {
    
        [Export] public float Speed = 100;

        private Sprite _sprite;
    
        private PlayerInput _input;
    
        private StateMachine<CharacterStates.Movement> _movementState;
    
        private Vector2 _motion = Vector2.Zero;
        private Vector2 _linearVelocity = Vector2.Zero;
    
        public override void _Ready()
        {
            _sprite = this.GetNodeInChildren<Sprite>();
            _movementState = new StateMachine<CharacterStates.Movement>(this);
            _input = this.GetNodeInParent<PlayerInput>();
        }

        protected virtual void AddInput()
        {
            _motion = _input.Player1Movement;
            _motion = _motion * Speed;
        }
    
    
        protected virtual void EveryFrame()
        {
        
            GDebug.Print("Movement: " + _movementState.CurrentState);

            ChangeColor();
        
            HandleMovement();
            AddInput();
        }

        private void ChangeColor()
        {
            if (_movementState.CurrentState == CharacterStates.Movement.Idle)
            {
                _sprite.Modulate = Colors.DarkBlue;
            }
        
            if (_movementState.CurrentState == CharacterStates.Movement.Walking)
            {
                _sprite.Modulate = Colors.DarkGreen;
            }
        }
    
        private void MoveController()
        {
            _linearVelocity = MoveAndSlide(_motion);
        }

        protected virtual void HandleMovement()
        {
            if (_linearVelocity.Length() <= 0)
            {
                _movementState.ChangeState(CharacterStates.Movement.Idle);
            }
            else
            {
                _movementState.ChangeState(CharacterStates.Movement.Walking);

            }
        }

        public override void _Process(float delta)
        {
            EveryFrame();
        }

        public override void _PhysicsProcess(float delta)
        {
            MoveController();
        }
    }
}
