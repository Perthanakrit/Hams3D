using UnityEngine;
using UnityEngine.InputSystem;
public class Character_Warrior : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] private CharacterList character;

    public Call_Warrior Wcall;
    public bool Wisuseskill;

    //[SerializeField] public Skill_archer _skill;

    [Header("Controls")]
    public float playerSpeed = 5.0f;
    public float crouchSpeed = 2.0f;
    public float sprintSpeed = 7.0f;
    public float jumpHeight = 0.8f;
    public float gravityMultiplier = 2;
    public float rotationSpeed = 5f;
    public float crouchColliderHeight = 1.35f;

    [Header("Animation Smoothing")]
    [Range(0, 1)]
    public float speedDampTime = 0.1f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    [Range(0, 1)]
    public float rotationDampTime = 0.2f;
    [Range(0, 1)]
    public float airControl = 0.5f;

    public StateMachine_Warrior movementSM;
    public StandingState_Warrior standing;
    public JumpingState_Warrior jumping;
    public CrouchingState_Warrior crouching;
    public LandingState_Warrior landing;
    public SprintState_Warrior sprinting;
    public SprintJumpState_Warrior sprintjumping;
    public CombatState_Warrior combatting;
    public AttackState_Warrior attacking;
    public passiveSkillAttack passiveAttacking;
    //public SkillState_Warrior usingskill;


    [HideInInspector]
    public float gravityValue = -9.81f;
    [HideInInspector]
    public float normalColliderHeight;
    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public Transform cameraTransform;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Vector3 playerVelocity;
    [HideInInspector]
    public bool usedSkill;


    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        Wcall = GetComponent<Call_Warrior>();
        Wisuseskill = Wcall.Wuseskill;

        movementSM = new StateMachine_Warrior();
        standing = new StandingState_Warrior(this, movementSM);
        jumping = new JumpingState_Warrior(this, movementSM);
        crouching = new CrouchingState_Warrior(this, movementSM);
        landing = new LandingState_Warrior(this, movementSM);
        sprinting = new SprintState_Warrior(this, movementSM);
        sprintjumping = new SprintJumpState_Warrior(this, movementSM);
        combatting = new CombatState_Warrior(this, movementSM);
        attacking =  new AttackState_Warrior(this, movementSM);
        //usingskill = new SkillState_Warrior(this, movementSM);
        //passiveAttacking = new passiveSkillAttack(this, movementSM);

        movementSM.Initialize(standing);

        normalColliderHeight = controller.height;
        gravityValue *= gravityMultiplier;

        //usedSkill = _skill.usingSkill;
    }

    private void Update()
    {
        movementSM.currentState.HandleInput();

        movementSM.currentState.LogicUpdate();

        Wisuseskill = Wcall.Wuseskill;
    }

    private void FixedUpdate()
    {
        movementSM.currentState.PhysicsUpdate();
    }
}