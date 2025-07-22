using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;	// 보간 적용된 이동값
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool shoot;

		[Header("Movement Settings")]
		public bool analogMovement;
		public Vector2 targetMove;	// 플레이어가 입력하고 있는 이동값
		Vector2 currentVelocity;	// 이동값 보간에 사용

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

        void Update()
        {
			//입력이 아날로그 값일 때는 그대로 적용 (게임패드 등...)
			if (analogMovement)
			{
				move = targetMove;
			}
			else	//입력이 디지털 값일 때는 보간 적용 (키보드)
			{
				move = Vector2.SmoothDamp(move, targetMove, ref currentVelocity, Time.deltaTime);
			}
        }

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnShoot(InputValue value)
		{
			ShootInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			targetMove = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}