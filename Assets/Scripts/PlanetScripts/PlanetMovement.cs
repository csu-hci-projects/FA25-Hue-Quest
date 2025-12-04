using UnityEngine;


	public class TempMovement : MonoBehaviour {

		private Animator anim;
		public float speed = 6f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		private bool onPlanet;


		void Start () {

			anim = gameObject.GetComponentInChildren<Animator>();
			onPlanet = true;
		}

		void Update()
		{
			if (Input.GetKey("w"))
			{
				anim.SetInteger("AnimationPar", 1);
			}
			else
			{
				anim.SetInteger("AnimationPar", 0);
			}

			if (onPlanet)
			{
				moveDirection.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			moveDirection.y -= gravity * Time.deltaTime;
			transform.Translate(0, 0, moveDirection.z);
		}
		
	}

