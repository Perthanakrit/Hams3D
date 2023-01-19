using UnityEngine;
using UnityEngine.InputSystem;
public class Character_archer : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] private CharacterList character;

    //public Call_archer _skill;

    [Header("Controls")]
    public float playerSpeed = 5.0f;
    public float crouchSpeed = 2.0f;
    public float sprintSpeed = 7.0f;
    public float jumpHeight = 0.8f;
    public float gravityMultiplier = 2;
    public float rotationSpeed = 5f;
    public float crouchColliderHeight = 1.35f;
    public bool useSkill;

    [Header("Animation Smoothing")]
    [Range(0, 1)]
    public float speedDampTime = 0.1f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    [Range(0, 1)]
    public float rotationDampTime = 0.2f;
    [Range(0, 1)]
    public float airControl = 0.5f;

    public StateMachine_archer movementSM;
    public StandingState_archer standing;
    public JumpingState_archer jumping;
    public CrouchingState_archer crouching;
    public LandingState_archer landing;
    public SprintState_archer sprinting;
    public SprintJumpState_archer sprintjumping;
    public CombatState_archer combatting;
    public AttackState_archer attacking;
    public passiveSkillAttack passiveAttacking;
    public SkillState_archer usingskill;


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
    public bool meleeAttack;
    [HideInInspector] public Aim_archer aim;
    [HideInInspector] public bool isAimming;
    [HideInInspector] public bool isSprinting;
    [HideInInspector] public bool isSpelling;

    public InventoryScriptable Inventory;

    [SerializeField] public Call_archer _call; 
    [SerializeField] private erika_Combat arcCombat;
    [SerializeField] private SkillState_archer abilitly;
  
    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;

        useSkill = _call.usingSkill;
        meleeAttack = arcCombat.melee;
        isSpelling = false;
        aim = GetComponent<Aim_archer>();
       
        movementSM = new StateMachine_archer();
        standing = new StandingState_archer(this, movementSM);
        jumping = new JumpingState_archer(this, movementSM);
        crouching = new CrouchingState_archer(this, movementSM);
        landing = new LandingState_archer(this, movementSM);
        sprinting = new SprintState_archer(this, movementSM);
        sprintjumping = new SprintJumpState_archer(this, movementSM);
        combatting = new CombatState_archer(this, movementSM);
        attacking =  new AttackState_archer(this, movementSM);
        usingskill = new SkillState_archer(this, movementSM);
        passiveAttacking = new passiveSkillAttack(this, movementSM);

        movementSM.Initialize(standing);

        normalColliderHeight = controller.height;
        gravityValue *= gravityMultiplier;

        //usedSkill = _skill.usingSkill;
    }

    private void Update()
    {
        useSkill = _call.usingSkill;
        meleeAttack = arcCombat.melee;
        //isAimming = aim.istracking;

        movementSM.currentState.HandleInput();

        movementSM.currentState.LogicUpdate();

    }

    private void FixedUpdate()
    {
        movementSM.currentState.PhysicsUpdate();
    }
}