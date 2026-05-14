//
// Copyright (C) 2015 crosire & kagikn & contributors
// License: https://github.com/scripthookvdotnet/scripthookvdotnet#license
//

using GTA.Math;

namespace GTA.NaturalMotion
{
    public enum ArmDirection
    {
        Backwards = -1,
        Adaptive,
        Forwards
    }

    public enum AnimSource
    {
        CurrentItems,
        PreviousItems,
        AnimItems
    }

    public enum FallType
    {
        RampDownStiffness,
        DontChangeStep,
        ForceBalance,
        Slump
    }

    public enum Synchroisation
    {
        NotSynced,
        AlwaysSynced,
        SyncedAtStart
    }

    public enum TurnType
    {
        DontTurn,
        ToTarget,
        AwayFromTarget
    }

    public enum TorqueMode
    {
        Disabled,
        Proportional,
        Additive
    }

    public enum TorqueSpinMode
    {
        FromImpulse,
        Random,
        Flipping
    }

    public enum TorqueFilterMode
    {
        ApplyEveryBullet,
        ApplyIfLastFinished,
        ApplyIfSpinDifferent
    }

    public enum RbTwistAxis
    {
        WorldUp,
        CharacterComUp
    }

    public enum WeaponMode
    {
        None = -1,
        Pistol,
        Dual,
        Rifle,
        SideArm,
        PistolLeft,
        PistolRight
    }

    public enum Hand
    {
        Left,
        Right
    }

    public enum MirrorMode
    {
        Independant,
        Mirrored,
        Parallel
    }

    public enum AdaptiveMode
    {
        NotAdaptive,
        OnlyDirection,
        DirectionAndSpeed,
        DirectionSpeedAndStrength
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ActivePoseHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ActivePose NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ActivePoseHelper(Ped ped) : base(ped, "activePose")
        {
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see notes for explanation).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }

        /// <summary>
        /// Apply gravity compensation as well?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseGravityCompensation
        {
            get => GetArgument("useGravityCompensation", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useGravityCompensation", argumentValue);
            }
        }

        /// <summary>
        /// AnimSource 0 = CurrentItms, 1 = PreviousItms, 2 = AnimItms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>ART::kITSourceCurrent</c>.</para>
        /// <para>Minimum value: <c>ART::kITSourceCurrent</c>.</para>
        /// <para>Maximum value: <c>ART::KITSourceCount-1</c>.</para>
        /// </remarks>
        public AnimSource AnimSource
        {
            get => (AnimSource)GetArgument("animSource", (int)AnimSource.CurrentItems);
            set
            {
                AnimSource argumentValue = value;
                SetArgument("animSource", (int)argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ApplyImpulseHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ApplyImpulse NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ApplyImpulseHelper(Ped ped) : base(ped, "applyImpulse")
        {
        }

        /// <summary>
        /// 0 means straight impulse, 1 means multiply by the mass (change in velocity).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float EqualizeAmount
        {
            get => GetArgument("equalizeAmount", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("equalizeAmount", argumentValue);
            }
        }

        /// <summary>
        /// Index of part being hit. -1 apply impulse to COM.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// <para>Maximum value: <c>28</c>.</para>
        /// </remarks>
        public int PartIndex
        {
            get => GetArgument("partIndex", 0);
            set
            {
                int argumentValue = System.Math.Min(28, System.Math.Max(-1, value));
                SetArgument("partIndex", argumentValue);
            }
        }

        /// <summary>
        /// Impulse vector (impulse is change in momentum).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-4500.0</c>.</para>
        /// <para>Maximum value: <c>4500.0</c>.</para>
        /// </remarks>
        public Vector3 Impulse
        {
            get => GetArgument("impulse", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-4500.0f, -4500.0f, -4500.0f), new Vector3(4500.0f, 4500.0f, 4500.0f));
                SetArgument("impulse", argumentValue);
            }
        }

        /// <summary>
        /// Optional point on part where hit. If not supplied then the impulse is applied at the part centre.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 HitPoint
        {
            get => GetArgument("hitPoint", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("hitPoint", argumentValue);
            }
        }

        /// <summary>
        /// HitPoint in local coordinates of bodyPart.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool LocalHitPointInfo
        {
            get => GetArgument("localHitPointInfo", false);
            set
            {
                bool argumentValue = value;
                SetArgument("localHitPointInfo", argumentValue);
            }
        }

        /// <summary>
        /// Impulse in local coordinates of bodyPart.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool LocalImpulseInfo
        {
            get => GetArgument("localImpulseInfo", false);
            set
            {
                bool argumentValue = value;
                SetArgument("localImpulseInfo", argumentValue);
            }
        }

        /// <summary>
        /// Impulse should be considered an angular impulse.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AngularImpulse
        {
            get => GetArgument("angularImpulse", false);
            set
            {
                bool argumentValue = value;
                SetArgument("angularImpulse", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ApplyBulletImpulseHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ApplyBulletImpulse NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ApplyBulletImpulseHelper(Ped ped) : base(ped, "applyBulletImpulse")
        {
        }

        /// <summary>
        /// 0 means straight impulse, 1 means multiply by the mass (change in velocity).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float EqualizeAmount
        {
            get => GetArgument("equalizeAmount", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("equalizeAmount", argumentValue);
            }
        }

        /// <summary>
        /// Index of part being hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>28</c>.</para>
        /// </remarks>
        public int PartIndex
        {
            get => GetArgument("partIndex", 0);
            set
            {
                int argumentValue = System.Math.Min(28, System.Math.Max(0, value));
                SetArgument("partIndex", argumentValue);
            }
        }

        /// <summary>
        /// Impulse vector (impulse is change in momentum).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-1000.0</c>.</para>
        /// <para>Maximum value: <c>1000.0</c>.</para>
        /// </remarks>
        public Vector3 Impulse
        {
            get => GetArgument("impulse", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-1000.0f, -1000.0f, -1000.0f), new Vector3(1000.0f, 1000.0f, 1000.0f));
                SetArgument("impulse", argumentValue);
            }
        }

        /// <summary>
        /// Optional point on part where hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 HitPoint
        {
            get => GetArgument("hitPoint", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("hitPoint", argumentValue);
            }
        }

        /// <summary>
        /// True = hitPoint is in local coordinates of bodyPart, false = hitpoint is in world coordinates.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool LocalHitPointInfo
        {
            get => GetArgument("localHitPointInfo", false);
            set
            {
                bool argumentValue = value;
                SetArgument("localHitPointInfo", argumentValue);
            }
        }

        /// <summary>
        /// If not 0.0 then have an extra bullet applied to spine0 (approximates the COM). Uses setup from configureBulletsExtra. 0-1 shared 0.0 = no extra bullet, 0.5 = impulse split equally between extra and bullet, 1.0 only extra bullet. LT 0.0 then bullet + scaled extra bullet. Eg.-0.5 = bullet + 0.5 impulse extra bullet.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-2.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ExtraShare
        {
            get => GetArgument("extraShare", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-2.00f, value));
                SetArgument("extraShare", argumentValue);
            }
        }
    }

    /// <summary>
    /// BodyRelax: Set the amount of relaxation across the whole body; Used to collapse the character into a rag-doll-like state.
    /// </summary>
    public sealed class BodyRelaxHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the BodyRelax NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public BodyRelaxHelper(Ped ped) : base(ped, "bodyRelax")
        {
        }

        /// <summary>
        /// How relaxed the body becomes, in percentage relaxed. 100 being totally rag-dolled, 0 being very stiff and rigid.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>50.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public float Relaxation
        {
            get => GetArgument("relaxation", 50.000f);
            set
            {
                float argumentValue = System.Math.Min(100.0f, System.Math.Max(0.0f, value));
                SetArgument("relaxation", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float Damping
        {
            get => GetArgument("damping", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("damping", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }

        /// <summary>
        /// Automatically hold the current pose as the character relaxes - can be used to avoid relaxing into a t-pose.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool HoldPose
        {
            get => GetArgument("holdPose", false);
            set
            {
                bool argumentValue = value;
                SetArgument("holdPose", argumentValue);
            }
        }

        /// <summary>
        /// Sets the drive state to free - this reduces drifting on the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DisableJointDriving
        {
            get => GetArgument("disableJointDriving", false);
            set
            {
                bool argumentValue = value;
                SetArgument("disableJointDriving", argumentValue);
            }
        }
    }

    /// <summary>
    /// ConfigureBalance: This single message allows you to configure various parameters used on any behavior that uses the dynamic balance.
    /// </summary>
    public sealed class ConfigureBalanceHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureBalance NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureBalanceHelper(Ped ped) : base(ped, "configureBalance")
        {
        }

        /// <summary>
        /// Maximum height that character steps vertically (above 0.2 is high...but ok for say underwater).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.100</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>0.40</c>.</para>
        /// </remarks>
        public float StepHeight
        {
            get => GetArgument("stepHeight", 0.100f);
            set
            {
                float argumentValue = System.Math.Min(0.40f, System.Math.Max(0.0f, value));
                SetArgument("stepHeight", argumentValue);
            }
        }

        /// <summary>
        /// Added to stepHeight if going up steps.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.100</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>0.40</c>.</para>
        /// </remarks>
        public float StepHeightInc4Step
        {
            get => GetArgument("stepHeightInc4Step", 0.100f);
            set
            {
                float argumentValue = System.Math.Min(0.40f, System.Math.Max(0.0f, value));
                SetArgument("stepHeightInc4Step", argumentValue);
            }
        }

        /// <summary>
        /// If the legs end up more than (legsApartRestep + hipwidth) apart even though balanced, take another step.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegsApartRestep
        {
            get => GetArgument("legsApartRestep", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.0f, value));
                SetArgument("legsApartRestep", argumentValue);
            }
        }

        /// <summary>
        /// Mmmm0.1 for drunk if the legs end up less than (hipwidth - legsTogetherRestep) apart even though balanced, take another step. A value of 1 will turn off this feature and the max value is hipWidth = 0.23f by default but is model dependent.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegsTogetherRestep
        {
            get => GetArgument("legsTogetherRestep", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.0f, value));
                SetArgument("legsTogetherRestep", argumentValue);
            }
        }

        /// <summary>
        /// FRICTION WORKAROUND: if the legs end up more than (legsApartMax + hipwidth) apart when balanced, adjust the feet positions to slide back so they are legsApartMax + hipwidth apart. Needs to be less than legsApartRestep to see any effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.000</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float LegsApartMax
        {
            get => GetArgument("legsApartMax", 2.000f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("legsApartMax", argumentValue);
            }
        }

        /// <summary>
        /// Does the knee strength reduce with angle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool TaperKneeStrength
        {
            get => GetArgument("taperKneeStrength", true);
            set
            {
                bool argumentValue = value;
                SetArgument("taperKneeStrength", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of legs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.000</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float LegStiffness
        {
            get => GetArgument("legStiffness", 12.000f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("legStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping of left leg during swing phase (mmmmDrunk used 1.25 to slow legs movement).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.20</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float LeftLegSwingDamping
        {
            get => GetArgument("leftLegSwingDamping", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.20f, value));
                SetArgument("leftLegSwingDamping", argumentValue);
            }
        }

        /// <summary>
        /// Damping of right leg during swing phase (mmmmDrunk used 1.25 to slow legs movement).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.20</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float RightLegSwingDamping
        {
            get => GetArgument("rightLegSwingDamping", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.20f, value));
                SetArgument("rightLegSwingDamping", argumentValue);
            }
        }

        /// <summary>
        /// Gravity opposition applied to hips and knees.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float OpposeGravityLegs
        {
            get => GetArgument("opposeGravityLegs", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.00f, value));
                SetArgument("opposeGravityLegs", argumentValue);
            }
        }

        /// <summary>
        /// Gravity opposition applied to ankles. General balancer likes 1.0. StaggerFall likes 0.1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float OpposeGravityAnkles
        {
            get => GetArgument("opposeGravityAnkles", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.00f, value));
                SetArgument("opposeGravityAnkles", argumentValue);
            }
        }

        /// <summary>
        /// Multiplier on the floorAcceleration added to the lean.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LeanAcc
        {
            get => GetArgument("leanAcc", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("leanAcc", argumentValue);
            }
        }

        /// <summary>
        /// Multiplier on the floorAcceleration added to the leanHips.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float HipLeanAcc
        {
            get => GetArgument("hipLeanAcc", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.00f, value));
                SetArgument("hipLeanAcc", argumentValue);
            }
        }

        /// <summary>
        /// Max floorAcceleration allowed for lean and leanHips.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>5.000</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float LeanAccMax
        {
            get => GetArgument("leanAccMax", 5.000f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.00f, value));
                SetArgument("leanAccMax", argumentValue);
            }
        }

        /// <summary>
        /// Level of cheat force added to character to resist the effect of floorAcceleration (anti-Acceleration) - added to upperbody.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ResistAcc
        {
            get => GetArgument("resistAcc", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.00f, value));
                SetArgument("resistAcc", argumentValue);
            }
        }

        /// <summary>
        /// Max floorAcceleration allowed for anti-Acceleration. If GT 20.0 then it is probably in a crash.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ResistAccMax
        {
            get => GetArgument("resistAccMax", 3.00f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.00f, value));
                SetArgument("resistAccMax", argumentValue);
            }
        }

        /// <summary>
        /// This parameter will be removed when footSlipCompensation preserves the foot angle on a moving floor]. If the character detects a moving floor and footSlipCompOnMovingFloor is false then it will turn off footSlipCompensation - at footSlipCompensation preserves the global heading of the feet. If footSlipCompensation is off then the character usually turns to the side in the end although when turning the vehicle turns it looks promising for a while.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool FootSlipCompOnMovingFloor
        {
            get => GetArgument("footSlipCompOnMovingFloor", true);
            set
            {
                bool argumentValue = value;
                SetArgument("footSlipCompOnMovingFloor", argumentValue);
            }
        }

        /// <summary>
        /// Ankle equilibrium angle used when static balancing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float AnkleEquilibrium
        {
            get => GetArgument("ankleEquilibrium", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.00f, value));
                SetArgument("ankleEquilibrium", argumentValue);
            }
        }

        /// <summary>
        /// Additional feet apart setting.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ExtraFeetApart
        {
            get => GetArgument("extraFeetApart", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.00f, value));
                SetArgument("extraFeetApart", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time at the start of a balance before the character is allowed to start stepping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float DontStepTime
        {
            get => GetArgument("dontStepTime", 0.00f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("dontStepTime", argumentValue);
            }
        }

        /// <summary>
        /// When the character gives up and goes into a fall. Larger values mean that the balancer can lean more before failing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.600</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float BalanceAbortThreshold
        {
            get => GetArgument("balanceAbortThreshold", 0.600f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("balanceAbortThreshold", argumentValue);
            }
        }

        /// <summary>
        /// Height between lowest foot and COM below which balancer will give up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.50</c>.</para>
        /// </remarks>
        public float GiveUpHeight
        {
            get => GetArgument("giveUpHeight", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.50f, System.Math.Max(0.0f, value));
                SetArgument("giveUpHeight", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets stepClampScale.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float StepClampScale
        {
            get => GetArgument("stepClampScale", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("stepClampScale", argumentValue);
            }
        }

        /// <summary>
        /// Variance in clamp scale every step. if negative only takes away from clampScale.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float StepClampScaleVariance
        {
            get => GetArgument("stepClampScaleVariance", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("stepClampScaleVariance", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time (seconds) into the future that the character tries to move hip to (kind of). Will be controlled by balancer in future but can help recover spine quicker from bending forwards to much.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float PredictionTimeHip
        {
            get => GetArgument("predictionTimeHip", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("predictionTimeHip", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time (seconds) into the future that the character tries to step to. bigger values try to recover with fewer, bigger steps. smaller values recover with smaller steps, and generally recover less.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float PredictionTime
        {
            get => GetArgument("predictionTime", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("predictionTime", argumentValue);
            }
        }

        /// <summary>
        /// Variance in predictionTime every step. if negative only takes away from predictionTime.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float PredictionTimeVariance
        {
            get => GetArgument("predictionTimeVariance", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("predictionTimeVariance", argumentValue);
            }
        }

        /// <summary>
        /// Maximum number of steps that the balancer will take.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100</c>.</para>
        /// <para>Minimum value: <c>1</c>.</para>
        /// </remarks>
        public int MaxSteps
        {
            get => GetArgument("maxSteps", 100);
            set
            {
                int argumentValue = System.Math.Max(1, value);
                SetArgument("maxSteps", argumentValue);
            }
        }

        /// <summary>
        /// Maximum time(seconds) that the balancer will balance for.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>50.0</c>.</para>
        /// <para>Minimum value: <c>1.0</c>.</para>
        /// </remarks>
        public float MaxBalanceTime
        {
            get => GetArgument("maxBalanceTime", 50.0f);
            set
            {
                float argumentValue = System.Math.Max(1.0f, value);
                SetArgument("maxBalanceTime", argumentValue);
            }
        }

        /// <summary>
        /// Allow the balancer to take this many more steps before hitting maxSteps. If negative nothing happens(safe default).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int ExtraSteps
        {
            get => GetArgument("extraSteps", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("extraSteps", argumentValue);
            }
        }

        /// <summary>
        /// Allow the balancer to balance for this many more seconds before hitting maxBalanceTime. If negative nothing happens(safe default).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// </remarks>
        public float ExtraTime
        {
            get => GetArgument("extraTime", -1.00f);
            set
            {
                float argumentValue = System.Math.Max(-1.00f, value);
                SetArgument("extraTime", argumentValue);
            }
        }

        /// <summary>
        /// How to fall after maxSteps or maxBalanceTime: 0=rampDown stiffness, 1= 0 and dontChangeStep, 2= 0 and forceBalance, 3=0 and slump (BCR has to be active).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public FallType FallType
        {
            get => (FallType)GetArgument("fallType", (int)(FallType)0);
            set
            {
                FallType argumentValue = value;
                SetArgument("fallType", (int)argumentValue);
            }
        }

        /// <summary>
        /// Multiply the rampDown of stiffness on falling by this amount ( GT 1 fall quicker).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public float FallMult
        {
            get => GetArgument("fallMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(100.0f, System.Math.Max(0.0f, value));
                SetArgument("fallMult", argumentValue);
            }
        }

        /// <summary>
        /// Reduce gravity compensation as the legs weaken on falling.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FallReduceGravityComp
        {
            get => GetArgument("fallReduceGravityComp", false);
            set
            {
                bool argumentValue = value;
                SetArgument("fallReduceGravityComp", argumentValue);
            }
        }

        /// <summary>
        /// Bend over when falling after maxBalanceTime.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool RampHipPitchOnFail
        {
            get => GetArgument("rampHipPitchOnFail", false);
            set
            {
                bool argumentValue = value;
                SetArgument("rampHipPitchOnFail", argumentValue);
            }
        }

        /// <summary>
        /// Linear speed threshold for successful balance.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float StableLinSpeedThresh
        {
            get => GetArgument("stableLinSpeedThresh", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.010f, value));
                SetArgument("stableLinSpeedThresh", argumentValue);
            }
        }

        /// <summary>
        /// Rotational speed threshold for successful balance.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float StableRotSpeedThresh
        {
            get => GetArgument("stableRotSpeedThresh", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.010f, value));
                SetArgument("stableRotSpeedThresh", argumentValue);
            }
        }

        /// <summary>
        /// The upper body of the character must be colliding and other failure conditions met to fail.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FailMustCollide
        {
            get => GetArgument("failMustCollide", false);
            set
            {
                bool argumentValue = value;
                SetArgument("failMustCollide", argumentValue);
            }
        }

        /// <summary>
        /// Ignore maxSteps and maxBalanceTime and try to balance forever.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool IgnoreFailure
        {
            get => GetArgument("ignoreFailure", false);
            set
            {
                bool argumentValue = value;
                SetArgument("ignoreFailure", argumentValue);
            }
        }

        /// <summary>
        /// Time not in contact (airborne) before step is changed. If -ve don't change step.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>5.0</c>.</para>
        /// </remarks>
        public float ChangeStepTime
        {
            get => GetArgument("changeStepTime", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(5.0f, System.Math.Max(-1.0f, value));
                SetArgument("changeStepTime", argumentValue);
            }
        }

        /// <summary>
        /// Ignore maxSteps and maxBalanceTime and try to balance forever.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BalanceIndefinitely
        {
            get => GetArgument("balanceIndefinitely", false);
            set
            {
                bool argumentValue = value;
                SetArgument("balanceIndefinitely", argumentValue);
            }
        }

        /// <summary>
        /// Temporary variable to ignore movingFloor code that generally causes the character to fall over if the feet probe a moving object e.g. treading on a gun.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool MovingFloor
        {
            get => GetArgument("movingFloor", false);
            set
            {
                bool argumentValue = value;
                SetArgument("movingFloor", argumentValue);
            }
        }

        /// <summary>
        /// When airborne try to step. Set to false for e.g. shotGun reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool AirborneStep
        {
            get => GetArgument("airborneStep", true);
            set
            {
                bool argumentValue = value;
                SetArgument("airborneStep", argumentValue);
            }
        }

        /// <summary>
        /// Velocity below which the balancer turns in the direction of the COM forward instead of the ComVel - for use with shot from running with high upright constraint use 1.9.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float UseComDirTurnVelThresh
        {
            get => GetArgument("useComDirTurnVelThresh", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("useComDirTurnVelThresh", argumentValue);
            }
        }

        /// <summary>
        /// Minimum knee angle (-ve value will mean this functionality is not applied). 0.4 seems a good value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.50</c>.</para>
        /// <para>Minimum value: <c>-0.50</c>.</para>
        /// <para>Maximum value: <c>1.50</c>.</para>
        /// </remarks>
        public float MinKneeAngle
        {
            get => GetArgument("minKneeAngle", -0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.50f, System.Math.Max(-0.50f, value));
                SetArgument("minKneeAngle", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets flatterSwingFeet.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FlatterSwingFeet
        {
            get => GetArgument("flatterSwingFeet", false);
            set
            {
                bool argumentValue = value;
                SetArgument("flatterSwingFeet", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets flatterStaticFeet.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FlatterStaticFeet
        {
            get => GetArgument("flatterStaticFeet", false);
            set
            {
                bool argumentValue = value;
                SetArgument("flatterStaticFeet", argumentValue);
            }
        }

        /// <summary>
        /// If true then balancer tries to avoid leg2leg collisions/avoid crossing legs. Avoid tries to not step across a line of the inside of the stance leg's foot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AvoidLeg
        {
            get => GetArgument("avoidLeg", false);
            set
            {
                bool argumentValue = value;
                SetArgument("avoidLeg", argumentValue);
            }
        }

        /// <summary>
        /// NB. Very sensitive. Avoid tries to not step across a line of the inside of the stance leg's foot. avoidFootWidth = how much inwards from the ankle this line is in (m).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float AvoidFootWidth
        {
            get => GetArgument("avoidFootWidth", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.00f, value));
                SetArgument("avoidFootWidth", argumentValue);
            }
        }

        /// <summary>
        /// NB. Very sensitive. Avoid tries to not step across a line of the inside of the stance leg's foot. Avoid doesn't allow the desired stepping foot to cross the line. avoidFeedback = how much of the actual crossing of that line is fedback as an error.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float AvoidFeedback
        {
            get => GetArgument("avoidFeedback", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.00f, value));
                SetArgument("avoidFeedback", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets leanAgainstVelocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAgainstVelocity
        {
            get => GetArgument("leanAgainstVelocity", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.00f, value));
                SetArgument("leanAgainstVelocity", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets stepDecisionThreshold.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float StepDecisionThreshold
        {
            get => GetArgument("stepDecisionThreshold", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.00f, value));
                SetArgument("stepDecisionThreshold", argumentValue);
            }
        }

        /// <summary>
        /// The balancer sometimes decides to step even if balanced.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool StepIfInSupport
        {
            get => GetArgument("stepIfInSupport", true);
            set
            {
                bool argumentValue = value;
                SetArgument("stepIfInSupport", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets alwaysStepWithFarthest.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AlwaysStepWithFarthest
        {
            get => GetArgument("alwaysStepWithFarthest", false);
            set
            {
                bool argumentValue = value;
                SetArgument("alwaysStepWithFarthest", argumentValue);
            }
        }

        /// <summary>
        /// Standup more with increased velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool StandUp
        {
            get => GetArgument("standUp", false);
            set
            {
                bool argumentValue = value;
                SetArgument("standUp", argumentValue);
            }
        }

        /// <summary>
        /// Supposed to increase foot friction: Impact depth of a collision with the foot is changed when the balancer is running - impact.SetDepth(impact.GetDepth() - depthFudge).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.010</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float DepthFudge
        {
            get => GetArgument("depthFudge", 0.010f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.00f, value));
                SetArgument("depthFudge", argumentValue);
            }
        }

        /// <summary>
        /// Supposed to increase foot friction: Impact depth of a collision with the foot is changed when staggerFall is running - impact.SetDepth(impact.GetDepth() - depthFudgeStagger).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.010</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float DepthFudgeStagger
        {
            get => GetArgument("depthFudgeStagger", 0.010f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.00f, value));
                SetArgument("depthFudgeStagger", argumentValue);
            }
        }

        /// <summary>
        /// Foot friction multiplier is multiplied by this amount if balancer is running.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>40.0</c>.</para>
        /// </remarks>
        public float FootFriction
        {
            get => GetArgument("footFriction", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(40.0f, System.Math.Max(0.00f, value));
                SetArgument("footFriction", argumentValue);
            }
        }

        /// <summary>
        /// Foot friction multiplier is multiplied by this amount if staggerFall is running.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>40.0</c>.</para>
        /// </remarks>
        public float FootFrictionStagger
        {
            get => GetArgument("footFrictionStagger", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(40.0f, System.Math.Max(0.00f, value));
                SetArgument("footFrictionStagger", argumentValue);
            }
        }

        /// <summary>
        /// Backwards lean threshold to cut off stay upright forces. 0.0 Vertical - 1.0 horizontal. 0.6 is a sensible value. NB: the balancer does not fail in order to give stagger that extra step as it falls. A backwards lean of GT 0.6 will generally mean the balancer will soon fail without stayUpright forces.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float BackwardsLeanCutoff
        {
            get => GetArgument("backwardsLeanCutoff", 1.10f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("backwardsLeanCutoff", argumentValue);
            }
        }

        /// <summary>
        /// If this value is different from giveUpHeight, actual giveUpHeight will be ramped toward this value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.50</c>.</para>
        /// </remarks>
        public float GiveUpHeightEnd
        {
            get => GetArgument("giveUpHeightEnd", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.50f, System.Math.Max(0.00f, value));
                SetArgument("giveUpHeightEnd", argumentValue);
            }
        }

        /// <summary>
        /// If this value is different from balanceAbortThreshold, actual balanceAbortThreshold will be ramped toward this value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float BalanceAbortThresholdEnd
        {
            get => GetArgument("balanceAbortThresholdEnd", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("balanceAbortThresholdEnd", argumentValue);
            }
        }

        /// <summary>
        /// Duration of ramp from start of behavior for above two parameters. If smaller than 0, no ramp is applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float GiveUpRampDuration
        {
            get => GetArgument("giveUpRampDuration", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(-1.00f, value));
                SetArgument("giveUpRampDuration", argumentValue);
            }
        }

        /// <summary>
        /// Lean at which to send abort message when maxSteps or maxBalanceTime is reached.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LeanToAbort
        {
            get => GetArgument("leanToAbort", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("leanToAbort", argumentValue);
            }
        }
    }

    /// <summary>
    /// ConfigureBalanceReset: reset the values configurable by the Configure Balance message to their defaults.
    /// </summary>
    public sealed class ConfigureBalanceResetHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureBalanceReset NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureBalanceResetHelper(Ped ped) : base(ped, "configureBalanceReset")
        {
        }
    }

    /// <summary>
    /// ConfigureSelfAvoidance: this single message allows to configure self avoidance for the character.BBDD Self avoidance tech.
    /// </summary>
    public sealed class ConfigureSelfAvoidanceHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureSelfAvoidance NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureSelfAvoidanceHelper(Ped ped) : base(ped, "configureSelfAvoidance")
        {
        }

        /// <summary>
        /// Enable or disable self avoidance tech.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseSelfAvoidance
        {
            get => GetArgument("useSelfAvoidance", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useSelfAvoidance", argumentValue);
            }
        }

        /// <summary>
        /// Specify whether self avoidance tech should use original IK input target or the target that has been already modified by getStabilisedPos() tech i.e. function that compensates for rotational and linear velocity of shoulder/thigh.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool OverwriteDragReduction
        {
            get => GetArgument("overwriteDragReduction", false);
            set
            {
                bool argumentValue = value;
                SetArgument("overwriteDragReduction", argumentValue);
            }
        }

        /// <summary>
        /// Place the adjusted target this much along the arc between effector (wrist) and target, value in range [0,1].
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.750</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TorsoSwingFraction
        {
            get => GetArgument("torsoSwingFraction", 0.750f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("torsoSwingFraction", argumentValue);
            }
        }

        /// <summary>
        /// Max value on the effector (wrist) to adjusted target offset.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.7580</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.570</c>.</para>
        /// </remarks>
        public float MaxTorsoSwingAngleRad
        {
            get => GetArgument("maxTorsoSwingAngleRad", 0.7580f);
            set
            {
                float argumentValue = System.Math.Min(1.570f, System.Math.Max(0.00f, value));
                SetArgument("maxTorsoSwingAngleRad", argumentValue);
            }
        }

        /// <summary>
        /// Restrict self avoidance to operate on targets that are within character torso bounds only.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SelfAvoidIfInSpineBoundsOnly
        {
            get => GetArgument("selfAvoidIfInSpineBoundsOnly", false);
            set
            {
                bool argumentValue = value;
                SetArgument("selfAvoidIfInSpineBoundsOnly", argumentValue);
            }
        }

        /// <summary>
        /// Amount of self avoidance offset applied when angle from effector (wrist) to target is greater then right angle i.e. when total offset is a blend between where effector currently is to value that is a product of total arm length and selfAvoidAmount. SelfAvoidAmount is in a range between [0, 1].
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SelfAvoidAmount
        {
            get => GetArgument("selfAvoidAmount", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("selfAvoidAmount", argumentValue);
            }
        }

        /// <summary>
        /// Overwrite desired IK twist with self avoidance procedural twist.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool OverwriteTwist
        {
            get => GetArgument("overwriteTwist", false);
            set
            {
                bool argumentValue = value;
                SetArgument("overwriteTwist", argumentValue);
            }
        }

        /// <summary>
        /// Use the alternative self avoidance algorithm that is based on linear and polar target blending. WARNING: It only requires "radius" in terms of parametrization.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UsePolarPathAlgorithm
        {
            get => GetArgument("usePolarPathAlgorithm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("usePolarPathAlgorithm", argumentValue);
            }
        }

        /// <summary>
        /// Self avoidance radius, measured out from the spine axis along the plane perpendicular to that axis. The closer is the proximity of reaching target to that radius, the more polar (curved) motion is used for offsetting the target. WARNING: Parameter only used by the alternative algorithm that is based on linear and polar target blending.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Radius
        {
            get => GetArgument("radius", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("radius", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ConfigureBulletsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureBullets NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureBulletsHelper(Ped ped) : base(ped, "configureBullets")
        {
        }

        /// <summary>
        /// Spreads impulse across parts. currently only for spine parts, not limbs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ImpulseSpreadOverParts
        {
            get => GetArgument("impulseSpreadOverParts", false);
            set
            {
                bool argumentValue = value;
                SetArgument("impulseSpreadOverParts", argumentValue);
            }
        }

        /// <summary>
        /// For weaker characters subsequent impulses remain strong.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ImpulseLeakageStrengthScaled
        {
            get => GetArgument("impulseLeakageStrengthScaled", false);
            set
            {
                bool argumentValue = value;
                SetArgument("impulseLeakageStrengthScaled", argumentValue);
            }
        }

        /// <summary>
        /// Duration that impulse is spread over (triangular shaped).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulsePeriod
        {
            get => GetArgument("impulsePeriod", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulsePeriod", argumentValue);
            }
        }

        /// <summary>
        /// An impulse applied at a point on a body equivalent to an impulse at the centre of the body and a torque. This parameter scales the torque component. (The torque component seems to be excite the rage looseness bug which sends the character in a sometimes wildly different direction to an applied impulse).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseTorqueScale
        {
            get => GetArgument("impulseTorqueScale", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseTorqueScale", argumentValue);
            }
        }

        /// <summary>
        /// Fix the rage looseness bug by applying only the impulse at the centre of the body unless it is a spine part then apply the twist component only of the torque as well.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool LoosenessFix
        {
            get => GetArgument("loosenessFix", false);
            set
            {
                bool argumentValue = value;
                SetArgument("loosenessFix", argumentValue);
            }
        }

        /// <summary>
        /// Time from hit before impulses are being applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseDelay
        {
            get => GetArgument("impulseDelay", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseDelay", argumentValue);
            }
        }

        /// <summary>
        /// By how much are subsequent impulses reduced (e.g. 0.0: no reduction, 0.1: 10% reduction each new hit).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseReductionPerShot
        {
            get => GetArgument("impulseReductionPerShot", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseReductionPerShot", argumentValue);
            }
        }

        /// <summary>
        /// Recovery rate of impulse strength per second (impulse strength from 0.0:1.0). At 60fps a impulseRecovery=60.0 will recover in 1 frame.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>60.00</c>.</para>
        /// </remarks>
        public float ImpulseRecovery
        {
            get => GetArgument("impulseRecovery", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(60.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseRecovery", argumentValue);
            }
        }

        /// <summary>
        /// The minimum amount of impulse leakage allowed.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseMinLeakage
        {
            get => GetArgument("impulseMinLeakage", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseMinLeakage", argumentValue);
            }
        }

        /// <summary>
        /// 0: Disabled | 1: character strength proportional (can reduce impulse amount) | 2: Additive (no reduction of impulse and not proportional to character strength).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public TorqueMode TorqueMode
        {
            get => (TorqueMode)GetArgument("torqueMode", (int)(TorqueMode)0);
            set
            {
                TorqueMode argumentValue = value;
                SetArgument("torqueMode", (int)argumentValue);
            }
        }

        /// <summary>
        /// 0: spin direction from impulse direction | 1: random direction | 2: direction flipped with each bullet (for burst effect).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public TorqueSpinMode TorqueSpinMode
        {
            get => (TorqueSpinMode)GetArgument("torqueSpinMode", (int)(TorqueSpinMode)0);
            set
            {
                TorqueSpinMode argumentValue = value;
                SetArgument("torqueSpinMode", (int)argumentValue);
            }
        }

        /// <summary>
        /// 0: apply torque for every bullet | 1: only apply new torque if previous has finished | 2: Only apply new torque if its spin direction is different from previous torque.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public TorqueFilterMode TorqueFilterMode
        {
            get => (TorqueFilterMode)GetArgument("torqueFilterMode", (int)(TorqueFilterMode)0);
            set
            {
                TorqueFilterMode argumentValue = value;
                SetArgument("torqueFilterMode", (int)argumentValue);
            }
        }

        /// <summary>
        /// Always apply torques to spine3 instead of actual part hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool TorqueAlwaysSpine3
        {
            get => GetArgument("torqueAlwaysSpine3", true);
            set
            {
                bool argumentValue = value;
                SetArgument("torqueAlwaysSpine3", argumentValue);
            }
        }

        /// <summary>
        /// Time from hit before torques are being applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TorqueDelay
        {
            get => GetArgument("torqueDelay", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("torqueDelay", argumentValue);
            }
        }

        /// <summary>
        /// Duration of torque.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.120</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TorquePeriod
        {
            get => GetArgument("torquePeriod", 0.120f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("torquePeriod", argumentValue);
            }
        }

        /// <summary>
        /// Multiplies impulse magnitude to arrive at torque that is applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float TorqueGain
        {
            get => GetArgument("torqueGain", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("torqueGain", argumentValue);
            }
        }

        /// <summary>
        /// Minimum ratio of impulse that remains after converting to torque (if in strength-proportional mode).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TorqueCutoff
        {
            get => GetArgument("torqueCutoff", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("torqueCutoff", argumentValue);
            }
        }

        /// <summary>
        /// Ratio of torque for next tick (e.g. 1.0: not reducing over time, 0.9: each tick torque is reduced by 10%).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TorqueReductionPerTick
        {
            get => GetArgument("torqueReductionPerTick", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("torqueReductionPerTick", argumentValue);
            }
        }

        /// <summary>
        /// Amount of lift (directly multiplies torque axis to give lift force).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LiftGain
        {
            get => GetArgument("liftGain", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("liftGain", argumentValue);
            }
        }

        /// <summary>
        /// Time after impulse is applied that counter impulse is applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.033330</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CounterImpulseDelay
        {
            get => GetArgument("counterImpulseDelay", 0.033330f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("counterImpulseDelay", argumentValue);
            }
        }

        /// <summary>
        /// Amount of the original impulse that is countered.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CounterImpulseMag
        {
            get => GetArgument("counterImpulseMag", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("counterImpulseMag", argumentValue);
            }
        }

        /// <summary>
        /// Applies the counter impulse counterImpulseDelay(secs) after counterImpulseMag of the Impulse has been applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool CounterAfterMagReached
        {
            get => GetArgument("counterAfterMagReached", false);
            set
            {
                bool argumentValue = value;
                SetArgument("counterAfterMagReached", argumentValue);
            }
        }

        /// <summary>
        /// Add a counter impulse to the pelvis.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DoCounterImpulse
        {
            get => GetArgument("doCounterImpulse", false);
            set
            {
                bool argumentValue = value;
                SetArgument("doCounterImpulse", argumentValue);
            }
        }

        /// <summary>
        /// Amount of the counter impulse applied to hips - the rest is applied to the part originally hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CounterImpulse2Hips
        {
            get => GetArgument("counterImpulse2Hips", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("counterImpulse2Hips", argumentValue);
            }
        }

        /// <summary>
        /// Amount to scale impulse by if the dynamicBalance is not OK. 1.0 means this functionality is not applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseNoBalMult
        {
            get => GetArgument("impulseNoBalMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseNoBalMult", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float ImpulseBalStabStart
        {
            get => GetArgument("impulseBalStabStart", 3.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseBalStabStart", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float ImpulseBalStabEnd
        {
            get => GetArgument("impulseBalStabEnd", 10.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseBalStabEnd", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseBalStabMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseBalStabMult
        {
            get => GetArgument("impulseBalStabMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseBalStabMult", argumentValue);
            }
        }

        /// <summary>
        /// 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End. This the dot of hip2Head with up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseSpineAngStart
        {
            get => GetArgument("impulseSpineAngStart", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("impulseSpineAngStart", argumentValue);
            }
        }

        /// <summary>
        /// 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End. This the dot of hip2Head with up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseSpineAngEnd
        {
            get => GetArgument("impulseSpineAngEnd", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("impulseSpineAngEnd", argumentValue);
            }
        }

        /// <summary>
        /// 100% GE Start to impulseSpineAngMult*100% LT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseSpineAngMult
        {
            get => GetArgument("impulseSpineAngMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseSpineAngMult", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float ImpulseVelStart
        {
            get => GetArgument("impulseVelStart", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseVelStart", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float ImpulseVelEnd
        {
            get => GetArgument("impulseVelEnd", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseVelEnd", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseVelMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseVelMult
        {
            get => GetArgument("impulseVelMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseVelMult", argumentValue);
            }
        }

        /// <summary>
        /// Amount to scale impulse by if the character is airborne and dynamicBalance is OK and impulse is above impulseAirMultStart.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseAirMult
        {
            get => GetArgument("impulseAirMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseAirMult", argumentValue);
            }
        }

        /// <summary>
        /// If impulse is above this value scale it by impulseAirMult.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseAirMultStart
        {
            get => GetArgument("impulseAirMultStart", 100.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseAirMultStart", argumentValue);
            }
        }

        /// <summary>
        /// Amount to clamp impulse to if character is airborne and dynamicBalance is OK.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseAirMax
        {
            get => GetArgument("impulseAirMax", 100.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseAirMax", argumentValue);
            }
        }

        /// <summary>
        /// If impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>399.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseAirApplyAbove
        {
            get => GetArgument("impulseAirApplyAbove", 399.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseAirApplyAbove", argumentValue);
            }
        }

        /// <summary>
        /// Scale and/or clamp impulse if the character is airborne and dynamicBalance is OK.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ImpulseAirOn
        {
            get => GetArgument("impulseAirOn", false);
            set
            {
                bool argumentValue = value;
                SetArgument("impulseAirOn", argumentValue);
            }
        }

        /// <summary>
        /// Amount to scale impulse by if the character is contacting with one foot only and dynamicBalance is OK and impulse is above impulseAirMultStart.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseOneLegMult
        {
            get => GetArgument("impulseOneLegMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseOneLegMult", argumentValue);
            }
        }

        /// <summary>
        /// If impulse is above this value scale it by impulseOneLegMult.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseOneLegMultStart
        {
            get => GetArgument("impulseOneLegMultStart", 100.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseOneLegMultStart", argumentValue);
            }
        }

        /// <summary>
        /// Amount to clamp impulse to if character is contacting with one foot only and dynamicBalance is OK.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseOneLegMax
        {
            get => GetArgument("impulseOneLegMax", 100.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseOneLegMax", argumentValue);
            }
        }

        /// <summary>
        /// If impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>399.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseOneLegApplyAbove
        {
            get => GetArgument("impulseOneLegApplyAbove", 399.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseOneLegApplyAbove", argumentValue);
            }
        }

        /// <summary>
        /// Scale and/or clamp impulse if the character is contacting with one leg only and dynamicBalance is OK.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ImpulseOneLegOn
        {
            get => GetArgument("impulseOneLegOn", false);
            set
            {
                bool argumentValue = value;
                SetArgument("impulseOneLegOn", argumentValue);
            }
        }

        /// <summary>
        /// 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbRatio
        {
            get => GetArgument("rbRatio", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbRatio", argumentValue);
            }
        }

        /// <summary>
        /// Rigid body response is shared between the upper and lower body (rbUpperShare = 1-rbLowerShare). rbLowerShare=0.5 gives upper and lower share scaled by mass. i.e. if 70% ub mass and 30% lower mass then rbLowerShare=0.5 gives actualrbShare of 0.7ub and 0.3lb. rbLowerShare GT 0.5 scales the ub share down from 0.7 and the lb up from 0.3.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbLowerShare
        {
            get => GetArgument("rbLowerShare", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbLowerShare", argumentValue);
            }
        }

        /// <summary>
        /// 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbMoment
        {
            get => GetArgument("rbMoment", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMoment", argumentValue);
            }
        }

        /// <summary>
        /// Maximum twist arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxTwistMomentArm
        {
            get => GetArgument("rbMaxTwistMomentArm", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxTwistMomentArm", argumentValue);
            }
        }

        /// <summary>
        /// Maximum broom((everything but the twist) arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxBroomMomentArm
        {
            get => GetArgument("rbMaxBroomMomentArm", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxBroomMomentArm", argumentValue);
            }
        }

        /// <summary>
        /// If Airborne: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbRatioAirborne
        {
            get => GetArgument("rbRatioAirborne", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbRatioAirborne", argumentValue);
            }
        }

        /// <summary>
        /// If Airborne: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbMomentAirborne
        {
            get => GetArgument("rbMomentAirborne", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMomentAirborne", argumentValue);
            }
        }

        /// <summary>
        /// If Airborne: Maximum twist arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxTwistMomentArmAirborne
        {
            get => GetArgument("rbMaxTwistMomentArmAirborne", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxTwistMomentArmAirborne", argumentValue);
            }
        }

        /// <summary>
        /// If Airborne: Maximum broom((everything but the twist) arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxBroomMomentArmAirborne
        {
            get => GetArgument("rbMaxBroomMomentArmAirborne", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxBroomMomentArmAirborne", argumentValue);
            }
        }

        /// <summary>
        /// If only one leg in contact: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbRatioOneLeg
        {
            get => GetArgument("rbRatioOneLeg", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbRatioOneLeg", argumentValue);
            }
        }

        /// <summary>
        /// If only one leg in contact: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbMomentOneLeg
        {
            get => GetArgument("rbMomentOneLeg", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMomentOneLeg", argumentValue);
            }
        }

        /// <summary>
        /// If only one leg in contact: Maximum twist arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxTwistMomentArmOneLeg
        {
            get => GetArgument("rbMaxTwistMomentArmOneLeg", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxTwistMomentArmOneLeg", argumentValue);
            }
        }

        /// <summary>
        /// If only one leg in contact: Maximum broom((everything but the twist) arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxBroomMomentArmOneLeg
        {
            get => GetArgument("rbMaxBroomMomentArmOneLeg", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxBroomMomentArmOneLeg", argumentValue);
            }
        }

        /// <summary>
        /// Twist axis 0=World Up, 1=CharacterCOM up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>1</c>.</para>
        /// </remarks>
        public RbTwistAxis RbTwistAxis
        {
            get => (RbTwistAxis)GetArgument("rbTwistAxis", (int)(RbTwistAxis)0);
            set
            {
                RbTwistAxis argumentValue = value;
                SetArgument("rbTwistAxis", (int)argumentValue);
            }
        }

        /// <summary>
        /// If false pivot around COM always, if true change pivot depending on foot contact: to feet centre if both feet in contact, or foot position if 1 foot in contact or COM position if no feet in contact.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool RbPivot
        {
            get => GetArgument("rbPivot", false);
            set
            {
                bool argumentValue = value;
                SetArgument("rbPivot", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ConfigureBulletsExtraHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureBulletsExtra NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureBulletsExtraHelper(Ped ped) : base(ped, "configureBulletsExtra")
        {
        }

        /// <summary>
        /// Spreads impulse across parts. currently only for spine parts, not limbs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ImpulseSpreadOverParts
        {
            get => GetArgument("impulseSpreadOverParts", false);
            set
            {
                bool argumentValue = value;
                SetArgument("impulseSpreadOverParts", argumentValue);
            }
        }

        /// <summary>
        /// Duration that impulse is spread over (triangular shaped).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulsePeriod
        {
            get => GetArgument("impulsePeriod", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulsePeriod", argumentValue);
            }
        }

        /// <summary>
        /// An impulse applied at a point on a body equivalent to an impulse at the centre of the body and a torque. This parameter scales the torque component. (The torque component seems to be excite the rage looseness bug which sends the character in a sometimes wildly different direction to an applied impulse).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseTorqueScale
        {
            get => GetArgument("impulseTorqueScale", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseTorqueScale", argumentValue);
            }
        }

        /// <summary>
        /// Fix the rage looseness bug by applying only the impulse at the centre of the body unless it is a spine part then apply the twist component only of the torque as well.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool LoosenessFix
        {
            get => GetArgument("loosenessFix", false);
            set
            {
                bool argumentValue = value;
                SetArgument("loosenessFix", argumentValue);
            }
        }

        /// <summary>
        /// Time from hit before impulses are being applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseDelay
        {
            get => GetArgument("impulseDelay", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseDelay", argumentValue);
            }
        }

        /// <summary>
        /// 0: Disabled | 1: character strength proportional (can reduce impulse amount) | 2: Additive (no reduction of impulse and not proportional to character strength).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public TorqueMode TorqueMode
        {
            get => (TorqueMode)GetArgument("torqueMode", (int)(TorqueMode)0);
            set
            {
                TorqueMode argumentValue = value;
                SetArgument("torqueMode", (int)argumentValue);
            }
        }

        /// <summary>
        /// 0: spin direction from impulse direction | 1: random direction | 2: direction flipped with each bullet (for burst effect).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public TorqueSpinMode TorqueSpinMode
        {
            get => (TorqueSpinMode)GetArgument("torqueSpinMode", (int)(TorqueSpinMode)0);
            set
            {
                TorqueSpinMode argumentValue = value;
                SetArgument("torqueSpinMode", (int)argumentValue);
            }
        }

        /// <summary>
        /// 0: apply torque for every bullet | 1: only apply new torque if previous has finished | 2: Only apply new torque if its spin direction is different from previous torque.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public TorqueFilterMode TorqueFilterMode
        {
            get => (TorqueFilterMode)GetArgument("torqueFilterMode", (int)(TorqueFilterMode)0);
            set
            {
                TorqueFilterMode argumentValue = value;
                SetArgument("torqueFilterMode", (int)argumentValue);
            }
        }

        /// <summary>
        /// Always apply torques to spine3 instead of actual part hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool TorqueAlwaysSpine3
        {
            get => GetArgument("torqueAlwaysSpine3", true);
            set
            {
                bool argumentValue = value;
                SetArgument("torqueAlwaysSpine3", argumentValue);
            }
        }

        /// <summary>
        /// Time from hit before torques are being applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TorqueDelay
        {
            get => GetArgument("torqueDelay", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("torqueDelay", argumentValue);
            }
        }

        /// <summary>
        /// Duration of torque.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.120</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TorquePeriod
        {
            get => GetArgument("torquePeriod", 0.120f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("torquePeriod", argumentValue);
            }
        }

        /// <summary>
        /// Multiplies impulse magnitude to arrive at torque that is applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float TorqueGain
        {
            get => GetArgument("torqueGain", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("torqueGain", argumentValue);
            }
        }

        /// <summary>
        /// Minimum ratio of impulse that remains after converting to torque (if in strength-proportional mode).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TorqueCutoff
        {
            get => GetArgument("torqueCutoff", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("torqueCutoff", argumentValue);
            }
        }

        /// <summary>
        /// Ratio of torque for next tick (e.g. 1.0: not reducing over time, 0.9: each tick torque is reduced by 10%).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TorqueReductionPerTick
        {
            get => GetArgument("torqueReductionPerTick", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("torqueReductionPerTick", argumentValue);
            }
        }

        /// <summary>
        /// Amount of lift (directly multiplies torque axis to give lift force).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LiftGain
        {
            get => GetArgument("liftGain", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("liftGain", argumentValue);
            }
        }

        /// <summary>
        /// Time after impulse is applied that counter impulse is applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.033330</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CounterImpulseDelay
        {
            get => GetArgument("counterImpulseDelay", 0.033330f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("counterImpulseDelay", argumentValue);
            }
        }

        /// <summary>
        /// Amount of the original impulse that is countered.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CounterImpulseMag
        {
            get => GetArgument("counterImpulseMag", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("counterImpulseMag", argumentValue);
            }
        }

        /// <summary>
        /// Applies the counter impulse counterImpulseDelay(secs) after counterImpulseMag of the Impulse has been applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool CounterAfterMagReached
        {
            get => GetArgument("counterAfterMagReached", false);
            set
            {
                bool argumentValue = value;
                SetArgument("counterAfterMagReached", argumentValue);
            }
        }

        /// <summary>
        /// Add a counter impulse to the pelvis.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DoCounterImpulse
        {
            get => GetArgument("doCounterImpulse", false);
            set
            {
                bool argumentValue = value;
                SetArgument("doCounterImpulse", argumentValue);
            }
        }

        /// <summary>
        /// Amount of the counter impulse applied to hips - the rest is applied to the part originally hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CounterImpulse2Hips
        {
            get => GetArgument("counterImpulse2Hips", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("counterImpulse2Hips", argumentValue);
            }
        }

        /// <summary>
        /// Amount to scale impulse by if the dynamicBalance is not OK. 1.0 means this functionality is not applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseNoBalMult
        {
            get => GetArgument("impulseNoBalMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseNoBalMult", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float ImpulseBalStabStart
        {
            get => GetArgument("impulseBalStabStart", 3.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseBalStabStart", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float ImpulseBalStabEnd
        {
            get => GetArgument("impulseBalStabEnd", 10.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseBalStabEnd", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseBalStabMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseBalStabMult
        {
            get => GetArgument("impulseBalStabMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseBalStabMult", argumentValue);
            }
        }

        /// <summary>
        /// 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End. This the dot of hip2Head with up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseSpineAngStart
        {
            get => GetArgument("impulseSpineAngStart", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("impulseSpineAngStart", argumentValue);
            }
        }

        /// <summary>
        /// 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End. This the dot of hip2Head with up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseSpineAngEnd
        {
            get => GetArgument("impulseSpineAngEnd", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("impulseSpineAngEnd", argumentValue);
            }
        }

        /// <summary>
        /// 100% GE Start to impulseSpineAngMult*100% LT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseSpineAngMult
        {
            get => GetArgument("impulseSpineAngMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseSpineAngMult", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float ImpulseVelStart
        {
            get => GetArgument("impulseVelStart", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseVelStart", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float ImpulseVelEnd
        {
            get => GetArgument("impulseVelEnd", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseVelEnd", argumentValue);
            }
        }

        /// <summary>
        /// 100% LE Start to impulseVelMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseVelMult
        {
            get => GetArgument("impulseVelMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseVelMult", argumentValue);
            }
        }

        /// <summary>
        /// Amount to scale impulse by if the character is airborne and dynamicBalance is OK and impulse is above impulseAirMultStart.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseAirMult
        {
            get => GetArgument("impulseAirMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseAirMult", argumentValue);
            }
        }

        /// <summary>
        /// If impulse is above this value scale it by impulseAirMult.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseAirMultStart
        {
            get => GetArgument("impulseAirMultStart", 100.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseAirMultStart", argumentValue);
            }
        }

        /// <summary>
        /// Amount to clamp impulse to if character is airborne and dynamicBalance is OK.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseAirMax
        {
            get => GetArgument("impulseAirMax", 100.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseAirMax", argumentValue);
            }
        }

        /// <summary>
        /// If impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>399.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseAirApplyAbove
        {
            get => GetArgument("impulseAirApplyAbove", 399.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseAirApplyAbove", argumentValue);
            }
        }

        /// <summary>
        /// Scale and/or clamp impulse if the character is airborne and dynamicBalance is OK.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ImpulseAirOn
        {
            get => GetArgument("impulseAirOn", false);
            set
            {
                bool argumentValue = value;
                SetArgument("impulseAirOn", argumentValue);
            }
        }

        /// <summary>
        /// Amount to scale impulse by if the character is contacting with one foot only and dynamicBalance is OK and impulse is above impulseAirMultStart.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpulseOneLegMult
        {
            get => GetArgument("impulseOneLegMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impulseOneLegMult", argumentValue);
            }
        }

        /// <summary>
        /// If impulse is above this value scale it by impulseOneLegMult.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseOneLegMultStart
        {
            get => GetArgument("impulseOneLegMultStart", 100.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseOneLegMultStart", argumentValue);
            }
        }

        /// <summary>
        /// Amount to clamp impulse to if character is contacting with one foot only and dynamicBalance is OK.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseOneLegMax
        {
            get => GetArgument("impulseOneLegMax", 100.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseOneLegMax", argumentValue);
            }
        }

        /// <summary>
        /// If impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>399.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float ImpulseOneLegApplyAbove
        {
            get => GetArgument("impulseOneLegApplyAbove", 399.0f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("impulseOneLegApplyAbove", argumentValue);
            }
        }

        /// <summary>
        /// Scale and/or clamp impulse if the character is contacting with one leg only and dynamicBalance is OK.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ImpulseOneLegOn
        {
            get => GetArgument("impulseOneLegOn", false);
            set
            {
                bool argumentValue = value;
                SetArgument("impulseOneLegOn", argumentValue);
            }
        }

        /// <summary>
        /// 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbRatio
        {
            get => GetArgument("rbRatio", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbRatio", argumentValue);
            }
        }

        /// <summary>
        /// Rigid body response is shared between the upper and lower body (rbUpperShare = 1-rbLowerShare). rbLowerShare=0.5 gives upper and lower share scaled by mass. i.e. if 70% ub mass and 30% lower mass then rbLowerShare=0.5 gives actualrbShare of 0.7ub and 0.3lb. rbLowerShare GT 0.5 scales the ub share down from 0.7 and the lb up from 0.3.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbLowerShare
        {
            get => GetArgument("rbLowerShare", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbLowerShare", argumentValue);
            }
        }

        /// <summary>
        /// 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbMoment
        {
            get => GetArgument("rbMoment", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMoment", argumentValue);
            }
        }

        /// <summary>
        /// Maximum twist arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxTwistMomentArm
        {
            get => GetArgument("rbMaxTwistMomentArm", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxTwistMomentArm", argumentValue);
            }
        }

        /// <summary>
        /// Maximum broom((everything but the twist) arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxBroomMomentArm
        {
            get => GetArgument("rbMaxBroomMomentArm", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxBroomMomentArm", argumentValue);
            }
        }

        /// <summary>
        /// If Airborne: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbRatioAirborne
        {
            get => GetArgument("rbRatioAirborne", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbRatioAirborne", argumentValue);
            }
        }

        /// <summary>
        /// If Airborne: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbMomentAirborne
        {
            get => GetArgument("rbMomentAirborne", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMomentAirborne", argumentValue);
            }
        }

        /// <summary>
        /// If Airborne: Maximum twist arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxTwistMomentArmAirborne
        {
            get => GetArgument("rbMaxTwistMomentArmAirborne", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxTwistMomentArmAirborne", argumentValue);
            }
        }

        /// <summary>
        /// If Airborne: Maximum broom((everything but the twist) arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxBroomMomentArmAirborne
        {
            get => GetArgument("rbMaxBroomMomentArmAirborne", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxBroomMomentArmAirborne", argumentValue);
            }
        }

        /// <summary>
        /// If only one leg in contact: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbRatioOneLeg
        {
            get => GetArgument("rbRatioOneLeg", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbRatioOneLeg", argumentValue);
            }
        }

        /// <summary>
        /// If only one leg in contact: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float RbMomentOneLeg
        {
            get => GetArgument("rbMomentOneLeg", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMomentOneLeg", argumentValue);
            }
        }

        /// <summary>
        /// If only one leg in contact: Maximum twist arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxTwistMomentArmOneLeg
        {
            get => GetArgument("rbMaxTwistMomentArmOneLeg", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxTwistMomentArmOneLeg", argumentValue);
            }
        }

        /// <summary>
        /// If only one leg in contact: Maximum broom((everything but the twist) arm moment of bullet applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RbMaxBroomMomentArmOneLeg
        {
            get => GetArgument("rbMaxBroomMomentArmOneLeg", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rbMaxBroomMomentArmOneLeg", argumentValue);
            }
        }

        /// <summary>
        /// Twist axis 0=World Up, 1=CharacterCOM up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>1</c>.</para>
        /// </remarks>
        public RbTwistAxis RbTwistAxis
        {
            get => (RbTwistAxis)GetArgument("rbTwistAxis", (int)(RbTwistAxis)0);
            set
            {
                RbTwistAxis argumentValue = value;
                SetArgument("rbTwistAxis", (int)argumentValue);
            }
        }

        /// <summary>
        /// If false pivot around COM always, if true change pivot depending on foot contact: to feet centre if both feet in contact, or foot position if 1 foot in contact or COM position if no feet in contact.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool RbPivot
        {
            get => GetArgument("rbPivot", false);
            set
            {
                bool argumentValue = value;
                SetArgument("rbPivot", argumentValue);
            }
        }
    }

    /// <summary>
    /// ConfigureLimits: Enable/disable/edit character limits in real time. This adjusts limits in RAGE-native space and will *not* reorient the joint.
    /// </summary>
    public sealed class ConfigureLimitsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureLimits NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureLimitsHelper(Ped ped) : base(ped, "configureLimits")
        {
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value for joint limits to configure. Ignored if index != -1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }

        /// <summary>
        /// If false, disable (set all to PI, -PI) limits.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Enable
        {
            get => GetArgument("enable", true);
            set
            {
                bool argumentValue = value;
                SetArgument("enable", argumentValue);
            }
        }

        /// <summary>
        /// If true, set limits to accommodate current desired angles.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ToDesired
        {
            get => GetArgument("toDesired", false);
            set
            {
                bool argumentValue = value;
                SetArgument("toDesired", argumentValue);
            }
        }

        /// <summary>
        /// Return to cached defaults?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Restore
        {
            get => GetArgument("restore", false);
            set
            {
                bool argumentValue = value;
                SetArgument("restore", argumentValue);
            }
        }

        /// <summary>
        /// If true, set limits to the current animated limits.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ToCurAnimation
        {
            get => GetArgument("toCurAnimation", false);
            set
            {
                bool argumentValue = value;
                SetArgument("toCurAnimation", argumentValue);
            }
        }

        /// <summary>
        /// Index of effector to configure. Set to -1 to use mask.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int Index
        {
            get => GetArgument("index", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("index", argumentValue);
            }
        }

        /// <summary>
        /// Custom limit values to use if not setting limits to desired. Limits are RAGE-native, not NM-wrapper-native.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.570796</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.141593</c>.</para>
        /// </remarks>
        public float Lean1
        {
            get => GetArgument("lean1", 1.570796f);
            set
            {
                float argumentValue = System.Math.Min(3.141593f, System.Math.Max(0.0f, value));
                SetArgument("lean1", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets lean2.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.570796</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.141593</c>.</para>
        /// </remarks>
        public float Lean2
        {
            get => GetArgument("lean2", 1.570796f);
            set
            {
                float argumentValue = System.Math.Min(3.141593f, System.Math.Max(0.0f, value));
                SetArgument("lean2", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets twist.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.570796</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.141593</c>.</para>
        /// </remarks>
        public float Twist
        {
            get => GetArgument("twist", 1.570796f);
            set
            {
                float argumentValue = System.Math.Min(3.141593f, System.Math.Max(0.0f, value));
                SetArgument("twist", argumentValue);
            }
        }

        /// <summary>
        /// Joint limit margin to add to current animation limits when using those to set runtime limits.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.196350</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.141593</c>.</para>
        /// </remarks>
        public float Margin
        {
            get => GetArgument("margin", 0.196350f);
            set
            {
                float argumentValue = System.Math.Min(3.141593f, System.Math.Max(0.0f, value));
                SetArgument("margin", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ConfigureSoftLimitHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureSoftLimit NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureSoftLimitHelper(Ped ped) : base(ped, "configureSoftLimit")
        {
        }

        /// <summary>
        /// Select limb that the soft limit is going to be applied to.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public int Index
        {
            get => GetArgument("index", 0);
            set
            {
                int argumentValue = System.Math.Min(3, System.Math.Max(0, value));
                SetArgument("index", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of the soft limit. Parameter is used to calculate spring term that contributes to the desired acceleration.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>15.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>30.00</c>.</para>
        /// </remarks>
        public float Stiffness
        {
            get => GetArgument("stiffness", 15.00f);
            set
            {
                float argumentValue = System.Math.Min(30.00f, System.Math.Max(0.00f, value));
                SetArgument("stiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping of the soft limit. Parameter is used to calculate damper term that contributes to the desired acceleration. To have the system critically dampened set it to 1.0.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.90</c>.</para>
        /// <para>Maximum value: <c>1.10</c>.</para>
        /// </remarks>
        public float Damping
        {
            get => GetArgument("damping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.10f, System.Math.Max(0.90f, value));
                SetArgument("damping", argumentValue);
            }
        }

        /// <summary>
        /// Soft limit angle. Positive angle in RAD, measured relatively either from hard limit maxAngle (approach direction = -1) or minAngle (approach direction = 1). This angle will be clamped if outside the joint hard limit range.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>6.283185</c>.</para>
        /// </remarks>
        public float LimitAngle
        {
            get => GetArgument("limitAngle", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(6.283185f, System.Math.Max(0.00f, value));
                SetArgument("limitAngle", argumentValue);
            }
        }

        /// <summary>
        /// Limit angle can be measured relatively to joints hard limit minAngle or maxAngle. Set approachDirection to +1 to measure soft limit angle relatively to hard limit minAngle that corresponds to the maximum stretch of the elbow. Set it to -1 to measure soft limit angle relatively to hard limit maxAngle that corresponds to the maximum stretch of the knee.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// <para>Maximum value: <c>1</c>.</para>
        /// </remarks>
        public int ApproachDirection
        {
            get => GetArgument("approachDirection", 1);
            set
            {
                int argumentValue = System.Math.Min(1, System.Math.Max(-1, value));
                SetArgument("approachDirection", argumentValue);
            }
        }

        /// <summary>
        /// Scale stiffness based on character angular velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool VelocityScaled
        {
            get => GetArgument("velocityScaled", false);
            set
            {
                bool argumentValue = value;
                SetArgument("velocityScaled", argumentValue);
            }
        }
    }

    /// <summary>
    /// ConfigureShotInjuredArm: This single message allows you to configure the injured arm reaction during shot.
    /// </summary>
    public sealed class ConfigureShotInjuredArmHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureShotInjuredArm NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureShotInjuredArmHelper(Ped ped) : base(ped, "configureShotInjuredArm")
        {
        }

        /// <summary>
        /// Length of the reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float InjuredArmTime
        {
            get => GetArgument("injuredArmTime", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("injuredArmTime", argumentValue);
            }
        }

        /// <summary>
        /// Amount of hip twist. (Negative values twist into bullet direction - probably not what is wanted).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.80</c>.</para>
        /// <para>Minimum value: <c>-2.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float HipYaw
        {
            get => GetArgument("hipYaw", 0.80f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(-2.00f, value));
                SetArgument("hipYaw", argumentValue);
            }
        }

        /// <summary>
        /// Amount of hip roll.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-2.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float HipRoll
        {
            get => GetArgument("hipRoll", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(-2.00f, value));
                SetArgument("hipRoll", argumentValue);
            }
        }

        /// <summary>
        /// Additional height added to stepping foot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.070</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>0.70</c>.</para>
        /// </remarks>
        public float ForceStepExtraHeight
        {
            get => GetArgument("forceStepExtraHeight", 0.070f);
            set
            {
                float argumentValue = System.Math.Min(0.70f, System.Math.Max(0.00f, value));
                SetArgument("forceStepExtraHeight", argumentValue);
            }
        }

        /// <summary>
        /// Force a step to be taken whether pushed out of balance or not.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ForceStep
        {
            get => GetArgument("forceStep", true);
            set
            {
                bool argumentValue = value;
                SetArgument("forceStep", argumentValue);
            }
        }

        /// <summary>
        /// Turn the character using the balancer.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool StepTurn
        {
            get => GetArgument("stepTurn", true);
            set
            {
                bool argumentValue = value;
                SetArgument("stepTurn", argumentValue);
            }
        }

        /// <summary>
        /// Start velocity where parameters begin to be ramped down to zero linearly.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float VelMultiplierStart
        {
            get => GetArgument("velMultiplierStart", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("velMultiplierStart", argumentValue);
            }
        }

        /// <summary>
        /// End velocity of ramp where parameters are scaled to zero.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>5.0</c>.</para>
        /// <para>Minimum value: <c>1.00</c>.</para>
        /// <para>Maximum value: <c>40.00</c>.</para>
        /// </remarks>
        public float VelMultiplierEnd
        {
            get => GetArgument("velMultiplierEnd", 5.0f);
            set
            {
                float argumentValue = System.Math.Min(40.00f, System.Math.Max(1.00f, value));
                SetArgument("velMultiplierEnd", argumentValue);
            }
        }

        /// <summary>
        /// Velocity above which a step is not forced.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.80</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float VelForceStep
        {
            get => GetArgument("velForceStep", 0.80f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("velForceStep", argumentValue);
            }
        }

        /// <summary>
        /// Velocity above which a stepTurn is not asked for.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.80</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float VelStepTurn
        {
            get => GetArgument("velStepTurn", 0.80f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("velStepTurn", argumentValue);
            }
        }

        /// <summary>
        /// Use the velocity scaling parameters. Tune for standing still then use velocity scaling to make sure a running character stays balanced (the turning tends to make the character fall over more at speed).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool VelScales
        {
            get => GetArgument("velScales", true);
            set
            {
                bool argumentValue = value;
                SetArgument("velScales", argumentValue);
            }
        }
    }

    /// <summary>
    /// ConfigureShotInjuredLeg: This single message allows you to configure the injured leg reaction during shot.
    /// </summary>
    public sealed class ConfigureShotInjuredLegHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureShotInjuredLeg NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureShotInjuredLegHelper(Ped ped) : base(ped, "configureShotInjuredLeg")
        {
        }

        /// <summary>
        /// Time before a wounded leg is set to be weak and cause the character to collapse.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float TimeBeforeCollapseWoundLeg
        {
            get => GetArgument("timeBeforeCollapseWoundLeg", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("timeBeforeCollapseWoundLeg", argumentValue);
            }
        }

        /// <summary>
        /// Leg inury duration (reaction to being shot in leg).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float LegInjuryTime
        {
            get => GetArgument("legInjuryTime", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("legInjuryTime", argumentValue);
            }
        }

        /// <summary>
        /// Force a step to be taken whether pushed out of balance or not.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool LegForceStep
        {
            get => GetArgument("legForceStep", true);
            set
            {
                bool argumentValue = value;
                SetArgument("legForceStep", argumentValue);
            }
        }

        /// <summary>
        /// Bend the legs via the balancer by this amount if stepping on the injured leg. 0.2 seems a good default.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegLimpBend
        {
            get => GetArgument("legLimpBend", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("legLimpBend", argumentValue);
            }
        }

        /// <summary>
        /// Leg lift duration (reaction to being shot in leg) (lifting happens when not stepping with other leg).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float LegLiftTime
        {
            get => GetArgument("legLiftTime", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("legLiftTime", argumentValue);
            }
        }

        /// <summary>
        /// Leg injury - leg strength is reduced.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegInjury
        {
            get => GetArgument("legInjury", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("legInjury", argumentValue);
            }
        }

        /// <summary>
        /// Leg injury bend forwards amount when not lifting leg.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegInjuryHipPitch
        {
            get => GetArgument("legInjuryHipPitch", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("legInjuryHipPitch", argumentValue);
            }
        }

        /// <summary>
        /// Leg injury bend forwards amount when lifting leg (lifting happens when not stepping with other leg).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegInjuryLiftHipPitch
        {
            get => GetArgument("legInjuryLiftHipPitch", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("legInjuryLiftHipPitch", argumentValue);
            }
        }

        /// <summary>
        /// Leg injury bend forwards amount when not lifting leg.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegInjurySpineBend
        {
            get => GetArgument("legInjurySpineBend", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("legInjurySpineBend", argumentValue);
            }
        }

        /// <summary>
        /// Leg injury bend forwards amount when lifting leg (lifting happens when not stepping with other leg).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegInjuryLiftSpineBend
        {
            get => GetArgument("legInjuryLiftSpineBend", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("legInjuryLiftSpineBend", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class DefineAttachedObjectHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the DefineAttachedObject NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public DefineAttachedObjectHelper(Ped ped) : base(ped, "defineAttachedObject")
        {
        }

        /// <summary>
        /// Index of part to attach to.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int PartIndex
        {
            get => GetArgument("partIndex", -1);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(-1, value));
                SetArgument("partIndex", argumentValue);
            }
        }

        /// <summary>
        /// Mass of the attached object.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public float ObjectMass
        {
            get => GetArgument("objectMass", 0.000f);
            set
            {
                float argumentValue = System.Math.Max(0.0f, value);
                SetArgument("objectMass", argumentValue);
            }
        }

        /// <summary>
        /// World position of attached object's centre of mass. must be updated each frame.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 WorldPos
        {
            get => GetArgument("worldPos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("worldPos", argumentValue);
            }
        }
    }

    /// <summary>
    /// ForceToBodyPart: Apply an impulse to a named body part.
    /// </summary>
    public sealed class ForceToBodyPartHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ForceToBodyPart NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ForceToBodyPartHelper(Ped ped) : base(ped, "forceToBodyPart")
        {
        }

        /// <summary>
        /// Part or link or bound index.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>28</c>.</para>
        /// </remarks>
        public int PartIndex
        {
            get => GetArgument("partIndex", 0);
            set
            {
                int argumentValue = System.Math.Min(28, System.Math.Max(0, value));
                SetArgument("partIndex", argumentValue);
            }
        }

        /// <summary>
        /// Force to apply.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, -50.00, 0.00</c>.</para>
        /// <para>Minimum value: <c>-100000.0</c>.</para>
        /// <para>Maximum value: <c>100000.0</c>.</para>
        /// </remarks>
        public Vector3 Force
        {
            get => GetArgument("force", new Vector3(0.00f, -50.00f, 0.00f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-100000.0f, -100000.0f, -100000.0f), new Vector3(100000.0f, 100000.0f, 100000.0f));
                SetArgument("force", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets forceDefinedInPartSpace.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ForceDefinedInPartSpace
        {
            get => GetArgument("forceDefinedInPartSpace", false);
            set
            {
                bool argumentValue = value;
                SetArgument("forceDefinedInPartSpace", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class LeanInDirectionHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the LeanInDirection NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public LeanInDirectionHelper(Ped ped) : base(ped, "leanInDirection")
        {
        }

        /// <summary>
        /// Amount of lean, 0 to about 0.5. -ve will move away from the target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAmount
        {
            get => GetArgument("leanAmount", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("leanAmount", argumentValue);
            }
        }

        /// <summary>
        /// Direction to lean in.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, 0.00, 1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public Vector3 Dir
        {
            get => GetArgument("dir", new Vector3(0.00f, 0.00f, 1.00f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("dir", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class LeanRandomHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the LeanRandom NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public LeanRandomHelper(Ped ped) : base(ped, "leanRandom")
        {
        }

        /// <summary>
        /// Minimum amount of lean.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAmountMin
        {
            get => GetArgument("leanAmountMin", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanAmountMin", argumentValue);
            }
        }

        /// <summary>
        /// Maximum amount of lean.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAmountMax
        {
            get => GetArgument("leanAmountMax", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanAmountMax", argumentValue);
            }
        }

        /// <summary>
        /// Min time until changing direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ChangeTimeMin
        {
            get => GetArgument("changeTimeMin", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("changeTimeMin", argumentValue);
            }
        }

        /// <summary>
        /// Maximum time until changing direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ChangeTimeMax
        {
            get => GetArgument("changeTimeMax", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("changeTimeMax", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class LeanToPositionHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the LeanToPosition NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public LeanToPositionHelper(Ped ped) : base(ped, "leanToPosition")
        {
        }

        /// <summary>
        /// Amount of lean, 0 to about 0.5. -ve will move away from the target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>-0.50</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float LeanAmount
        {
            get => GetArgument("leanAmount", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(-0.50f, value));
                SetArgument("leanAmount", argumentValue);
            }
        }

        /// <summary>
        /// Position to head towards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos
        {
            get => GetArgument("pos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class LeanTowardsObjectHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the LeanTowardsObject NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public LeanTowardsObjectHelper(Ped ped) : base(ped, "leanTowardsObject")
        {
        }

        /// <summary>
        /// Amount of lean, 0 to about 0.5. -ve will move away from the target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>-0.50</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float LeanAmount
        {
            get => GetArgument("leanAmount", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(-0.50f, value));
                SetArgument("leanAmount", argumentValue);
            }
        }

        /// <summary>
        /// Offset from instance position added when calculating position to lean to.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-100.0</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public Vector3 Offset
        {
            get => GetArgument("offset", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-100.0f, -100.0f, -100.0f), new Vector3(100.0f, 100.0f, 100.0f));
                SetArgument("offset", argumentValue);
            }
        }

        /// <summary>
        /// LevelIndex of object to lean towards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int InstanceIndex
        {
            get => GetArgument("instanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("instanceIndex", argumentValue);
            }
        }

        /// <summary>
        /// BoundIndex of object to lean towards (0 = just use instance coordinates).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int BoundIndex
        {
            get => GetArgument("boundIndex", 0);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("boundIndex", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class HipsLeanInDirectionHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the HipsLeanInDirection NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public HipsLeanInDirectionHelper(Ped ped) : base(ped, "hipsLeanInDirection")
        {
        }

        /// <summary>
        /// Amount of lean, 0 to about 0.5. -ve will move away from the target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAmount
        {
            get => GetArgument("leanAmount", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("leanAmount", argumentValue);
            }
        }

        /// <summary>
        /// Direction to lean in.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, 0.00, 1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public Vector3 Dir
        {
            get => GetArgument("dir", new Vector3(0.00f, 0.00f, 1.00f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("dir", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class HipsLeanRandomHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the HipsLeanRandom NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public HipsLeanRandomHelper(Ped ped) : base(ped, "hipsLeanRandom")
        {
        }

        /// <summary>
        /// Minimum amount of lean.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.300</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAmountMin
        {
            get => GetArgument("leanAmountMin", 0.300f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanAmountMin", argumentValue);
            }
        }

        /// <summary>
        /// Maximum amount of lean.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.400</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAmountMax
        {
            get => GetArgument("leanAmountMax", 0.400f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanAmountMax", argumentValue);
            }
        }

        /// <summary>
        /// Min time until changing direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ChangeTimeMin
        {
            get => GetArgument("changeTimeMin", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("changeTimeMin", argumentValue);
            }
        }

        /// <summary>
        /// Maximum time until changing direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ChangeTimeMax
        {
            get => GetArgument("changeTimeMax", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("changeTimeMax", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class HipsLeanToPositionHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the HipsLeanToPosition NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public HipsLeanToPositionHelper(Ped ped) : base(ped, "hipsLeanToPosition")
        {
        }

        /// <summary>
        /// Amount of lean, 0 to about 0.5. -ve will move away from the target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>-0.50</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float LeanAmount
        {
            get => GetArgument("leanAmount", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(-0.50f, value));
                SetArgument("leanAmount", argumentValue);
            }
        }

        /// <summary>
        /// Position to head towards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos
        {
            get => GetArgument("pos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class HipsLeanTowardsObjectHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the HipsLeanTowardsObject NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public HipsLeanTowardsObjectHelper(Ped ped) : base(ped, "hipsLeanTowardsObject")
        {
        }

        /// <summary>
        /// Amount of lean, 0 to about 0.5. -ve will move away from the target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>-0.50</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float LeanAmount
        {
            get => GetArgument("leanAmount", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(-0.50f, value));
                SetArgument("leanAmount", argumentValue);
            }
        }

        /// <summary>
        /// Offset from instance position added when calculating position to lean to.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-100.0</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public Vector3 Offset
        {
            get => GetArgument("offset", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-100.0f, -100.0f, -100.0f), new Vector3(100.0f, 100.0f, 100.0f));
                SetArgument("offset", argumentValue);
            }
        }

        /// <summary>
        /// LevelIndex of object to lean hips towards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int InstanceIndex
        {
            get => GetArgument("instanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("instanceIndex", argumentValue);
            }
        }

        /// <summary>
        /// BoundIndex of object to lean hips towards (0 = just use instance coordinates).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int BoundIndex
        {
            get => GetArgument("boundIndex", 0);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("boundIndex", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ForceLeanInDirectionHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ForceLeanInDirection NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ForceLeanInDirectionHelper(Ped ped) : base(ped, "forceLeanInDirection")
        {
        }

        /// <summary>
        /// Amount of lean, 0 to about 0.5. -ve will move away from the target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAmount
        {
            get => GetArgument("leanAmount", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("leanAmount", argumentValue);
            }
        }

        /// <summary>
        /// Direction to lean in.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, 0.00, 1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public Vector3 Dir
        {
            get => GetArgument("dir", new Vector3(0.00f, 0.00f, 1.00f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("dir", argumentValue);
            }
        }

        /// <summary>
        /// Body part that the force is applied to.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int BodyPart
        {
            get => GetArgument("bodyPart", 0);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(0, value));
                SetArgument("bodyPart", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ForceLeanRandomHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ForceLeanRandom NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ForceLeanRandomHelper(Ped ped) : base(ped, "forceLeanRandom")
        {
        }

        /// <summary>
        /// Minimum amount of lean.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.300</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAmountMin
        {
            get => GetArgument("leanAmountMin", 0.300f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanAmountMin", argumentValue);
            }
        }

        /// <summary>
        /// Maximum amount of lean.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.400</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanAmountMax
        {
            get => GetArgument("leanAmountMax", 0.400f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanAmountMax", argumentValue);
            }
        }

        /// <summary>
        /// Min time until changing direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ChangeTimeMin
        {
            get => GetArgument("changeTimeMin", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("changeTimeMin", argumentValue);
            }
        }

        /// <summary>
        /// Maximum time until changing direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ChangeTimeMax
        {
            get => GetArgument("changeTimeMax", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("changeTimeMax", argumentValue);
            }
        }

        /// <summary>
        /// Body part that the force is applied to.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int BodyPart
        {
            get => GetArgument("bodyPart", 0);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(0, value));
                SetArgument("bodyPart", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ForceLeanToPositionHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ForceLeanToPosition NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ForceLeanToPositionHelper(Ped ped) : base(ped, "forceLeanToPosition")
        {
        }

        /// <summary>
        /// Amount of lean, 0 to about 0.5. -ve will move away from the target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>-0.50</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float LeanAmount
        {
            get => GetArgument("leanAmount", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(-0.50f, value));
                SetArgument("leanAmount", argumentValue);
            }
        }

        /// <summary>
        /// Position to head towards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos
        {
            get => GetArgument("pos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos", argumentValue);
            }
        }

        /// <summary>
        /// Body part that the force is applied to.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int BodyPart
        {
            get => GetArgument("bodyPart", 0);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(0, value));
                SetArgument("bodyPart", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ForceLeanTowardsObjectHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ForceLeanTowardsObject NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ForceLeanTowardsObjectHelper(Ped ped) : base(ped, "forceLeanTowardsObject")
        {
        }

        /// <summary>
        /// Amount of lean, 0 to about 0.5. -ve will move away from the target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.200</c>.</para>
        /// <para>Minimum value: <c>-0.50</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float LeanAmount
        {
            get => GetArgument("leanAmount", 0.200f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(-0.50f, value));
                SetArgument("leanAmount", argumentValue);
            }
        }

        /// <summary>
        /// Offset from instance position added when calculating position to lean to.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-100.0</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public Vector3 Offset
        {
            get => GetArgument("offset", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-100.0f, -100.0f, -100.0f), new Vector3(100.0f, 100.0f, 100.0f));
                SetArgument("offset", argumentValue);
            }
        }

        /// <summary>
        /// LevelIndex of object to move towards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int InstanceIndex
        {
            get => GetArgument("instanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("instanceIndex", argumentValue);
            }
        }

        /// <summary>
        /// BoundIndex of object to move towards (0 = just use instance coordinates).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int BoundIndex
        {
            get => GetArgument("boundIndex", 0);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("boundIndex", argumentValue);
            }
        }

        /// <summary>
        /// Body part that the force is applied to.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int BodyPart
        {
            get => GetArgument("bodyPart", 0);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(0, value));
                SetArgument("bodyPart", argumentValue);
            }
        }
    }

    /// <summary>
    /// SetStiffness: Use this message to manually set the body stiffness values -before using Active Pose to drive to an animated pose, for example.
    /// </summary>
    public sealed class SetStiffnessHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetStiffness NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetStiffnessHelper(Ped ped) : base(ped, "setStiffness")
        {
        }

        /// <summary>
        /// Stiffness of whole character.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.000</c>.</para>
        /// <para>Minimum value: <c>2.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float BodyStiffness
        {
            get => GetArgument("bodyStiffness", 12.000f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(2.0f, value));
                SetArgument("bodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping amount, less is underdamped.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float Damping
        {
            get => GetArgument("damping", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("damping", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }
    }

    /// <summary>
    /// SetMuscleStiffness: Use this message to manually set the muscle stiffness values -before using Active Pose to drive to an animated pose, for example.
    /// </summary>
    public sealed class SetMuscleStiffnessHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetMuscleStiffness NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetMuscleStiffnessHelper(Ped ped) : base(ped, "setMuscleStiffness")
        {
        }

        /// <summary>
        /// Muscle stiffness of joint/s.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float MuscleStiffness
        {
            get => GetArgument("muscleStiffness", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("muscleStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }
    }

    /// <summary>
    /// SetWeaponMode: Use this message to set the character's weapon mode. This is an alternativeto the setWeaponMode public function.
    /// </summary>
    public sealed class SetWeaponModeHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetWeaponMode NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetWeaponModeHelper(Ped ped) : base(ped, "setWeaponMode")
        {
        }

        /// <summary>
        /// Weapon mode. kNone = -1, kPistol = 0, kDual = 1, kRifle = 2, kSidearm = 3, kPistolLeft = 4, kPistolRight = 5. See WeaponMode enum in NmRsUtils.h and -1 from that.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>5</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// <para>Maximum value: <c>6</c>.</para>
        /// </remarks>
        public WeaponMode WeaponMode
        {
            get => (WeaponMode)GetArgument("weaponMode", (int)(WeaponMode)5);
            set
            {
                WeaponMode argumentValue = value;
                SetArgument("weaponMode", (int)argumentValue);
            }
        }
    }

    /// <summary>
    /// RegisterWeapon: Use this message to register weapon. This is an alternativeto the registerWeapon public function.
    /// </summary>
    public sealed class RegisterWeaponHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the RegisterWeapon NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public RegisterWeaponHelper(Ped ped) : base(ped, "registerWeapon")
        {
        }

        /// <summary>
        /// What hand the weapon is in. LeftHand = 0, RightHand = 1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>1</c>.</para>
        /// </remarks>
        public Hand Hand
        {
            get => (Hand)GetArgument("hand", (int)(Hand)1);
            set
            {
                Hand argumentValue = value;
                SetArgument("hand", (int)argumentValue);
            }
        }

        /// <summary>
        /// Level index of the weapon.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int LevelIndex
        {
            get => GetArgument("levelIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("levelIndex", argumentValue);
            }
        }

        /// <summary>
        /// Pointer to the hand-gun constraint handle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int ConstraintHandle
        {
            get => GetArgument("constraintHandle", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("constraintHandle", argumentValue);
            }
        }

        /// <summary>
        /// A vector of the gunToHand matrix. The gunToHandMatrix is the desired gunToHandMatrix in the aimingPose. (The gunToHandMatrix when pointGun starts can be different so will be blended to this desired one).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00, 0.00, 0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public Vector3 GunToHandA
        {
            get => GetArgument("gunToHandA", new Vector3(1.00f, 0.00f, 0.00f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.00f, 0.00f, 0.00f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("gunToHandA", argumentValue);
            }
        }

        /// <summary>
        /// B vector of the gunToHand matrix.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, 1.00, 0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public Vector3 GunToHandB
        {
            get => GetArgument("gunToHandB", new Vector3(0.00f, 1.00f, 0.00f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.00f, 0.00f, 0.00f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("gunToHandB", argumentValue);
            }
        }

        /// <summary>
        /// C vector of the gunToHand matrix.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, 0.00, 1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public Vector3 GunToHandC
        {
            get => GetArgument("gunToHandC", new Vector3(0.00f, 0.00f, 1.00f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.00f, 0.00f, 0.00f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("gunToHandC", argumentValue);
            }
        }

        /// <summary>
        /// D vector of the gunToHand matrix.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, 0.00, 0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public Vector3 GunToHandD
        {
            get => GetArgument("gunToHandD", new Vector3(0.00f, 0.00f, 0.00f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.00f, 0.00f, 0.00f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("gunToHandD", argumentValue);
            }
        }

        /// <summary>
        /// Gun centre to muzzle expressed in gun co-ordinates. To get the line of sight/barrel of the gun. Assumption: the muzzle direction is always along the same primary axis of the gun.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 GunToMuzzleInGun
        {
            get => GetArgument("gunToMuzzleInGun", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("gunToMuzzleInGun", argumentValue);
            }
        }

        /// <summary>
        /// Gun centre to butt expressed in gun co-ordinates. The gun pivots around this point when aiming.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 GunToButtInGun
        {
            get => GetArgument("gunToButtInGun", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("gunToButtInGun", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ShotRelaxHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ShotRelax NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotRelaxHelper(Ped ped) : base(ped, "shotRelax")
        {
        }

        /// <summary>
        /// Time over which to relax to full relaxation for upper body.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>40.0</c>.</para>
        /// </remarks>
        public float RelaxPeriodUpper
        {
            get => GetArgument("relaxPeriodUpper", 2.000f);
            set
            {
                float argumentValue = System.Math.Min(40.0f, System.Math.Max(0.0f, value));
                SetArgument("relaxPeriodUpper", argumentValue);
            }
        }

        /// <summary>
        /// Time over which to relax to full relaxation for lower body.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.400</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>40.0</c>.</para>
        /// </remarks>
        public float RelaxPeriodLower
        {
            get => GetArgument("relaxPeriodLower", 0.400f);
            set
            {
                float argumentValue = System.Math.Min(40.0f, System.Math.Max(0.0f, value));
                SetArgument("relaxPeriodLower", argumentValue);
            }
        }
    }

    /// <summary>
    /// FireWeapon: One shot message apply a force to the hand as we fire the gun that should be in this hand.
    /// </summary>
    public sealed class FireWeaponHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the FireWeapon NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public FireWeaponHelper(Ped ped) : base(ped, "fireWeapon")
        {
        }

        /// <summary>
        /// The force of the gun.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1000.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10000.0</c>.</para>
        /// </remarks>
        public float FiredWeaponStrength
        {
            get => GetArgument("firedWeaponStrength", 1000.0f);
            set
            {
                float argumentValue = System.Math.Min(10000.0f, System.Math.Max(0.0f, value));
                SetArgument("firedWeaponStrength", argumentValue);
            }
        }

        /// <summary>
        /// Which hand in the gun in, 0 = left, 1 = right.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>1</c>.</para>
        /// </remarks>
        public Hand GunHandEnum
        {
            get => (Hand)GetArgument("gunHandEnum", (int)(Hand)0);
            set
            {
                Hand argumentValue = value;
                SetArgument("gunHandEnum", (int)argumentValue);
            }
        }

        /// <summary>
        /// Should we apply some of the force at the shoulder. Force double handed weapons (Ak47 etc).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ApplyFireGunForceAtClavicle
        {
            get => GetArgument("applyFireGunForceAtClavicle", false);
            set
            {
                bool argumentValue = value;
                SetArgument("applyFireGunForceAtClavicle", argumentValue);
            }
        }

        /// <summary>
        /// Minimum time before next fire impulse.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float InhibitTime
        {
            get => GetArgument("inhibitTime", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("inhibitTime", argumentValue);
            }
        }

        /// <summary>
        /// Direction of impulse in gun frame.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Direction
        {
            get => GetArgument("direction", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("direction", argumentValue);
            }
        }

        /// <summary>
        /// Split force between hand and clavicle when applyFireGunForceAtClavicle is true. 1 = all hand, 0 = all clavicle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float Split
        {
            get => GetArgument("split", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("split", argumentValue);
            }
        }
    }

    /// <summary>
    /// ConfigureConstraints: One shot to give state of constraints on character and response to constraints.
    /// </summary>
    public sealed class ConfigureConstraintsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ConfigureConstraints NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ConfigureConstraintsHelper(Ped ped) : base(ped, "configureConstraints")
        {
        }

        /// <summary>
        /// Gets or sets handCuffs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool HandCuffs
        {
            get => GetArgument("handCuffs", false);
            set
            {
                bool argumentValue = value;
                SetArgument("handCuffs", argumentValue);
            }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool HandCuffsBehindBack
        {
            get => GetArgument("handCuffsBehindBack", false);
            set
            {
                bool argumentValue = value;
                SetArgument("handCuffsBehindBack", argumentValue);
            }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool LegCuffs
        {
            get => GetArgument("legCuffs", false);
            set
            {
                bool argumentValue = value;
                SetArgument("legCuffs", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets rightDominant.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool RightDominant
        {
            get => GetArgument("rightDominant", false);
            set
            {
                bool argumentValue = value;
                SetArgument("rightDominant", argumentValue);
            }
        }

        /// <summary>
        /// 0 setCurrent, 1= IK to dominant, (2=pointGunLikeIK //not implemented).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>5</c>.</para>
        /// </remarks>
        public int PassiveMode
        {
            get => GetArgument("passiveMode", 0);
            set
            {
                int argumentValue = System.Math.Min(5, System.Math.Max(0, value));
                SetArgument("passiveMode", argumentValue);
            }
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BespokeBehavior
        {
            get => GetArgument("bespokeBehaviour", false);
            set
            {
                bool argumentValue = value;
                SetArgument("bespokeBehaviour", argumentValue);
            }
        }

        /// <summary>
        /// Blend Arms to zero pose.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float Blend2ZeroPose
        {
            get => GetArgument("blend2ZeroPose", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("blend2ZeroPose", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class StayUprightHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the StayUpright NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public StayUprightHelper(Ped ped) : base(ped, "stayUpright")
        {
        }

        /// <summary>
        /// Enable force based constraint.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseForces
        {
            get => GetArgument("useForces", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useForces", argumentValue);
            }
        }

        /// <summary>
        /// Enable torque based constraint.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseTorques
        {
            get => GetArgument("useTorques", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useTorques", argumentValue);
            }
        }

        /// <summary>
        /// Uses position/orientation control on the spine and drifts in the direction of bullets. This ignores all other stayUpright settings.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool LastStandMode
        {
            get => GetArgument("lastStandMode", false);
            set
            {
                bool argumentValue = value;
                SetArgument("lastStandMode", argumentValue);
            }
        }

        /// <summary>
        /// The sink rate (higher for a faster drop).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LastStandSinkRate
        {
            get => GetArgument("lastStandSinkRate", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("lastStandSinkRate", argumentValue);
            }
        }

        /// <summary>
        /// Higher values for more damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LastStandHorizDamping
        {
            get => GetArgument("lastStandHorizDamping", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("lastStandHorizDamping", argumentValue);
            }
        }

        /// <summary>
        /// Max time allowed in last stand mode.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>5.0</c>.</para>
        /// </remarks>
        public float LastStandMaxTime
        {
            get => GetArgument("lastStandMaxTime", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(5.0f, System.Math.Max(0.0f, value));
                SetArgument("lastStandMaxTime", argumentValue);
            }
        }

        /// <summary>
        /// Use cheat torques to face the direction of bullets if not facing too far away.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool TurnTowardsBullets
        {
            get => GetArgument("turnTowardsBullets", false);
            set
            {
                bool argumentValue = value;
                SetArgument("turnTowardsBullets", argumentValue);
            }
        }

        /// <summary>
        /// Make strength of constraint function of COM velocity. Uses -1 for forceDamping if the damping is positive.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool VelocityBased
        {
            get => GetArgument("velocityBased", false);
            set
            {
                bool argumentValue = value;
                SetArgument("velocityBased", argumentValue);
            }
        }

        /// <summary>
        /// Only apply torque based constraint when airBorne.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool TorqueOnlyInAir
        {
            get => GetArgument("torqueOnlyInAir", false);
            set
            {
                bool argumentValue = value;
                SetArgument("torqueOnlyInAir", argumentValue);
            }
        }

        /// <summary>
        /// Strength of constraint.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ForceStrength
        {
            get => GetArgument("forceStrength", 3.00f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("forceStrength", argumentValue);
            }
        }

        /// <summary>
        /// Damping in constraint: -1 makes it scale automagically with forceStrength. Other negative values will scale this automagic damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>50.0</c>.</para>
        /// </remarks>
        public float ForceDamping
        {
            get => GetArgument("forceDamping", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(50.0f, System.Math.Max(-1.00f, value));
                SetArgument("forceDamping", argumentValue);
            }
        }

        /// <summary>
        /// Multiplier to the force applied to the feet.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ForceFeetMult
        {
            get => GetArgument("forceFeetMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("forceFeetMult", argumentValue);
            }
        }

        /// <summary>
        /// Share of pelvis force applied to spine3.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ForceSpine3Share
        {
            get => GetArgument("forceSpine3Share", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("forceSpine3Share", argumentValue);
            }
        }

        /// <summary>
        /// How much the character lean is taken into account when reducing the force.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ForceLeanReduction
        {
            get => GetArgument("forceLeanReduction", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("forceLeanReduction", argumentValue);
            }
        }

        /// <summary>
        /// Share of the feet force to the airborne foot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ForceInAirShare
        {
            get => GetArgument("forceInAirShare", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("forceInAirShare", argumentValue);
            }
        }

        /// <summary>
        /// When min and max are greater than 0 the constraint strength is determined from character strength, scaled into the range given by min and max.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ForceMin
        {
            get => GetArgument("forceMin", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(-1.00f, value));
                SetArgument("forceMin", argumentValue);
            }
        }

        /// <summary>
        /// See above.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ForceMax
        {
            get => GetArgument("forceMax", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(-1.00f, value));
                SetArgument("forceMax", argumentValue);
            }
        }

        /// <summary>
        /// When in velocityBased mode, the COM velocity at which constraint reaches maximum strength (forceStrength).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float ForceSaturationVel
        {
            get => GetArgument("forceSaturationVel", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.10f, value));
                SetArgument("forceSaturationVel", argumentValue);
            }
        }

        /// <summary>
        /// When in velocityBased mode, the COM velocity above which constraint starts applying forces.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float ForceThresholdVel
        {
            get => GetArgument("forceThresholdVel", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("forceThresholdVel", argumentValue);
            }
        }

        /// <summary>
        /// Strength of torque based constraint.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float TorqueStrength
        {
            get => GetArgument("torqueStrength", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.00f, value));
                SetArgument("torqueStrength", argumentValue);
            }
        }

        /// <summary>
        /// Damping of torque based constraint.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float TorqueDamping
        {
            get => GetArgument("torqueDamping", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.00f, value));
                SetArgument("torqueDamping", argumentValue);
            }
        }

        /// <summary>
        /// When in velocityBased mode, the COM velocity at which constraint reaches maximum strength (torqueStrength).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float TorqueSaturationVel
        {
            get => GetArgument("torqueSaturationVel", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.10f, value));
                SetArgument("torqueSaturationVel", argumentValue);
            }
        }

        /// <summary>
        /// When in velocityBased mode, the COM velocity above which constraint starts applying torques.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float TorqueThresholdVel
        {
            get => GetArgument("torqueThresholdVel", 2.50f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("torqueThresholdVel", argumentValue);
            }
        }

        /// <summary>
        /// Distance the foot is behind Com projection that is still considered able to generate the support for the upright constraint.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>-2.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float SupportPosition
        {
            get => GetArgument("supportPosition", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(-2.00f, value));
                SetArgument("supportPosition", argumentValue);
            }
        }

        /// <summary>
        /// Still apply this fraction of the upright constaint force if the foot is not in a position (defined by supportPosition) to generate the support for the upright constraint.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float NoSupportForceMult
        {
            get => GetArgument("noSupportForceMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("noSupportForceMult", argumentValue);
            }
        }

        /// <summary>
        /// Strength of cheat force applied upwards to spine3 to help the character up steps/slopes.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float StepUpHelp
        {
            get => GetArgument("stepUpHelp", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.00f, value));
                SetArgument("stepUpHelp", argumentValue);
            }
        }

        /// <summary>
        /// How much the cheat force takes into account the acceleration of moving platforms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float StayUpAcc
        {
            get => GetArgument("stayUpAcc", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("stayUpAcc", argumentValue);
            }
        }

        /// <summary>
        /// The maximum floorAcceleration (of a moving platform) that the cheat force takes into account.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>5.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>15.0</c>.</para>
        /// </remarks>
        public float StayUpAccMax
        {
            get => GetArgument("stayUpAccMax", 5.00f);
            set
            {
                float argumentValue = System.Math.Min(15.0f, System.Math.Max(0.00f, value));
                SetArgument("stayUpAccMax", argumentValue);
            }
        }
    }

    /// <summary>
    /// StopAllBehaviors: Send this message to immediately stop all behaviors from executing.
    /// </summary>
    public sealed class StopAllBehaviorsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the StopAllBehaviors NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public StopAllBehaviorsHelper(Ped ped) : base(ped, "stopAllBehaviours")
        {
        }
    }

    /// <summary>
    /// SetCharacterStrength: Sets character's strength on the dead-granny-to-healthy-terminator scale: [0..1].
    /// </summary>
    public sealed class SetCharacterStrengthHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetCharacterStrength NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetCharacterStrengthHelper(Ped ped) : base(ped, "setCharacterStrength")
        {
        }

        /// <summary>
        /// Strength of character.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CharacterStrength
        {
            get => GetArgument("characterStrength", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("characterStrength", argumentValue);
            }
        }
    }

    /// <summary>
    /// SetCharacterHealth: Sets character's health on the dead-to-alive scale: [0..1].
    /// </summary>
    public sealed class SetCharacterHealthHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetCharacterHealth NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetCharacterHealthHelper(Ped ped) : base(ped, "setCharacterHealth")
        {
        }

        /// <summary>
        /// Health of character.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CharacterHealth
        {
            get => GetArgument("characterHealth", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("characterHealth", argumentValue);
            }
        }
    }

    /// <summary>
    /// SetFallingReaction: Sets the type of reaction if catchFall is called.
    /// </summary>
    public sealed class SetFallingReactionHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetFallingReaction NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetFallingReactionHelper(Ped ped) : base(ped, "setFallingReaction")
        {
        }

        /// <summary>
        /// Set to true to get handsAndKnees catchFall if catchFall called. If true allows the dynBalancer to stay on during the catchfall and modifies the catch fall to give a more alive looking performance (hands and knees for front landing or sitting up for back landing).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool HandsAndKnees
        {
            get => GetArgument("handsAndKnees", false);
            set
            {
                bool argumentValue = value;
                SetArgument("handsAndKnees", argumentValue);
            }
        }

        /// <summary>
        /// If true catchFall will call rollDownstairs if comVel GT comVelRDSThresh - prevents excessive sliding in catchFall. Was previously only true for handsAndKnees.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool CallRDS
        {
            get => GetArgument("callRDS", false);
            set
            {
                bool argumentValue = value;
                SetArgument("callRDS", argumentValue);
            }
        }

        /// <summary>
        /// ComVel above which rollDownstairs will start - prevents excessive sliding in catchFall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float ComVelRDSThresh
        {
            get => GetArgument("comVelRDSThresh", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("comVelRDSThresh", argumentValue);
            }
        }

        /// <summary>
        /// For rds catchFall only: True to resist rolling motion (rolling motion is set off by ub contact and a sliding velocity), false to allow more of a continuous rolling (rolling motion is set off at a sliding velocity).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ResistRolling
        {
            get => GetArgument("resistRolling", false);
            set
            {
                bool argumentValue = value;
                SetArgument("resistRolling", argumentValue);
            }
        }

        /// <summary>
        /// Strength is reduced in the catchFall when the arms contact the ground. 0.2 is good for handsAndKnees. 2.5 is good for normal catchFall, anything lower than 1.0 for normal catchFall may lead to bad catchFall poses.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ArmReduceSpeed
        {
            get => GetArgument("armReduceSpeed", 2.50f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("armReduceSpeed", argumentValue);
            }
        }

        /// <summary>
        /// Reach length multiplier that scales characters arm topological length, value in range from (0, 1 GT where 1.0 means reach length is maximum.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.30</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ReachLengthMultiplier
        {
            get => GetArgument("reachLengthMultiplier", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.30f, value));
                SetArgument("reachLengthMultiplier", argumentValue);
            }
        }

        /// <summary>
        /// Time after hitting ground that the catchFall can call rds.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float InhibitRollingTime
        {
            get => GetArgument("inhibitRollingTime", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("inhibitRollingTime", argumentValue);
            }
        }

        /// <summary>
        /// Time after hitting ground that the catchFall can change the friction of parts to inhibit sliding.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float ChangeFrictionTime
        {
            get => GetArgument("changeFrictionTime", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("changeFrictionTime", argumentValue);
            }
        }

        /// <summary>
        /// 8.0 was used on yanked) Friction multiplier on bodyParts when on ground. Character can look too slidy with groundFriction = 1. Higher values give a more jerky reation but this seems timestep dependent especially for dragged by the feet.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float GroundFriction
        {
            get => GetArgument("groundFriction", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("groundFriction", argumentValue);
            }
        }

        /// <summary>
        /// Min Friction of an impact with a body part (not head, hands or feet) - to increase friction of slippy environment to get character to roll better. Applied in catchFall and rollUp(rollDownStairs).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float FrictionMin
        {
            get => GetArgument("frictionMin", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("frictionMin", argumentValue);
            }
        }

        /// <summary>
        /// Max Friction of an impact with a body part (not head, hands or feet) - to increase friction of slippy environment to get character to roll better. Applied in catchFall and rollUp(rollDownStairs).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>9999.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public float FrictionMax
        {
            get => GetArgument("frictionMax", 9999.00f);
            set
            {
                float argumentValue = System.Math.Max(0.0f, value);
                SetArgument("frictionMax", argumentValue);
            }
        }

        /// <summary>
        /// Apply tactics to help stop on slopes.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool StopOnSlopes
        {
            get => GetArgument("stopOnSlopes", false);
            set
            {
                bool argumentValue = value;
                SetArgument("stopOnSlopes", argumentValue);
            }
        }

        /// <summary>
        /// Override slope value to manually force stopping on flat ground. Encourages character to come to rest face down or face up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float StopManual
        {
            get => GetArgument("stopManual", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("stopManual", argumentValue);
            }
        }

        /// <summary>
        /// Speed at which strength reduces when stopped.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>5.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float StoppedStrengthDecay
        {
            get => GetArgument("stoppedStrengthDecay", 5.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("stoppedStrengthDecay", argumentValue);
            }
        }

        /// <summary>
        /// Bias spine post towards hunched (away from arched).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SpineLean1Offset
        {
            get => GetArgument("spineLean1Offset", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("spineLean1Offset", argumentValue);
            }
        }

        /// <summary>
        /// Hold rifle in a safe position to reduce complications with collision. Only applied if holding a rifle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool RiflePose
        {
            get => GetArgument("riflePose", false);
            set
            {
                bool argumentValue = value;
                SetArgument("riflePose", argumentValue);
            }
        }

        /// <summary>
        /// Enable head ground avoidance when handsAndKnees is true.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool HkHeadAvoid
        {
            get => GetArgument("hkHeadAvoid", true);
            set
            {
                bool argumentValue = value;
                SetArgument("hkHeadAvoid", argumentValue);
            }
        }

        /// <summary>
        /// Discourage the character getting stuck propped up by elbows when falling backwards - by inhibiting backwards moving clavicles (keeps the arms slightly wider).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AntiPropClav
        {
            get => GetArgument("antiPropClav", false);
            set
            {
                bool argumentValue = value;
                SetArgument("antiPropClav", argumentValue);
            }
        }

        /// <summary>
        /// Discourage the character getting stuck propped up by elbows when falling backwards - by weakening the arms as soon they hit the floor. (Also stops the hands lifting up when flat on back).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AntiPropWeak
        {
            get => GetArgument("antiPropWeak", false);
            set
            {
                bool argumentValue = value;
                SetArgument("antiPropWeak", argumentValue);
            }
        }

        /// <summary>
        /// Head weakens as arms weaken. If false and antiPropWeak when falls onto back doesn't loosen neck so early (matches bodyStrength instead).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool HeadAsWeakAsArms
        {
            get => GetArgument("headAsWeakAsArms", true);
            set
            {
                bool argumentValue = value;
                SetArgument("headAsWeakAsArms", argumentValue);
            }
        }

        /// <summary>
        /// When bodyStrength is less than successStrength send a success feedback - DO NOT GO OUTSIDE MIN/MAX PARAMETER VALUES OTHERWISE NO SUCCESS FEEDBACK WILL BE SENT.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.30</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SuccessStrength
        {
            get => GetArgument("successStrength", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.30f, value));
                SetArgument("successStrength", argumentValue);
            }
        }
    }

    /// <summary>
    /// SetCharacterUnderwater: Sets viscosity applied to damping limbs.
    /// </summary>
    public sealed class SetCharacterUnderwaterHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetCharacterUnderwater NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetCharacterUnderwaterHelper(Ped ped) : base(ped, "setCharacterUnderwater")
        {
        }

        /// <summary>
        /// Is character underwater?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Underwater
        {
            get => GetArgument("underwater", false);
            set
            {
                bool argumentValue = value;
                SetArgument("underwater", argumentValue);
            }
        }

        /// <summary>
        /// Viscosity applied to character's parts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float Viscosity
        {
            get => GetArgument("viscosity", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(-1.00f, value));
                SetArgument("viscosity", argumentValue);
            }
        }

        /// <summary>
        /// Gravity factor applied to character.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>-10.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float GravityFactor
        {
            get => GetArgument("gravityFactor", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-10.00f, value));
                SetArgument("gravityFactor", argumentValue);
            }
        }

        /// <summary>
        /// Swimming force applied to character as a function of handVelocity and footVelocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1000.00</c>.</para>
        /// <para>Maximum value: <c>1000.00</c>.</para>
        /// </remarks>
        public float Stroke
        {
            get => GetArgument("stroke", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1000.00f, System.Math.Max(-1000.00f, value));
                SetArgument("stroke", argumentValue);
            }
        }

        /// <summary>
        /// Swimming force (linearStroke=true,False) = (f(v),f(v*v)).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool LinearStroke
        {
            get => GetArgument("linearStroke", false);
            set
            {
                bool argumentValue = value;
                SetArgument("linearStroke", argumentValue);
            }
        }
    }

    /// <summary>
    /// SetCharacterCollisions:.
    /// </summary>
    public sealed class SetCharacterCollisionsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetCharacterCollisions NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetCharacterCollisionsHelper(Ped ped) : base(ped, "setCharacterCollisions")
        {
        }

        /// <summary>
        /// Sliding friction turned into spin 80.0 (used in demo videos) good for rest of default params below. If 0.0 then no collision enhancement.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float Spin
        {
            get => GetArgument("spin", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("spin", argumentValue);
            }
        }

        /// <summary>
        /// Torque = spin*(relative velocity) up to this maximum for relative velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float MaxVelocity
        {
            get => GetArgument("maxVelocity", 8.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("maxVelocity", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets applyToAll.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ApplyToAll
        {
            get => GetArgument("applyToAll", false);
            set
            {
                bool argumentValue = value;
                SetArgument("applyToAll", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets applyToSpine.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ApplyToSpine
        {
            get => GetArgument("applyToSpine", true);
            set
            {
                bool argumentValue = value;
                SetArgument("applyToSpine", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets applyToThighs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ApplyToThighs
        {
            get => GetArgument("applyToThighs", true);
            set
            {
                bool argumentValue = value;
                SetArgument("applyToThighs", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets applyToClavicles.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ApplyToClavicles
        {
            get => GetArgument("applyToClavicles", true);
            set
            {
                bool argumentValue = value;
                SetArgument("applyToClavicles", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets applyToUpperArms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ApplyToUpperArms
        {
            get => GetArgument("applyToUpperArms", true);
            set
            {
                bool argumentValue = value;
                SetArgument("applyToUpperArms", argumentValue);
            }
        }

        /// <summary>
        /// Allow foot slipping if collided.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool FootSlip
        {
            get => GetArgument("footSlip", true);
            set
            {
                bool argumentValue = value;
                SetArgument("footSlip", argumentValue);
            }
        }

        /// <summary>
        /// ClassType of the object against which to enhance the collision. All character vehicle interaction (e.g. braceForImpact glancing spins) relies on this value so EDIT WISELY. If it is used for things other than vehicles then NM should be informed.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>15</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>100</c>.</para>
        /// </remarks>
        public int VehicleClass
        {
            get => GetArgument("vehicleClass", 15);
            set
            {
                int argumentValue = System.Math.Min(100, System.Math.Max(0, value));
                SetArgument("vehicleClass", argumentValue);
            }
        }
    }

    /// <summary>
    /// SetCharacterDamping: Damp out cartwheeling and somersaulting above a certain threshold.
    /// </summary>
    public sealed class SetCharacterDampingHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetCharacterDamping NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetCharacterDampingHelper(Ped ped) : base(ped, "setCharacterDamping")
        {
        }

        /// <summary>
        /// Somersault AngularMomentum measure above which we start damping - try 34.0. Falling over straight backwards gives 54 on hitting ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>34.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>200.00</c>.</para>
        /// </remarks>
        public float SomersaultThresh
        {
            get => GetArgument("somersaultThresh", 34.00f);
            set
            {
                float argumentValue = System.Math.Min(200.00f, System.Math.Max(0.00f, value));
                SetArgument("somersaultThresh", argumentValue);
            }
        }

        /// <summary>
        /// Amount to damp somersaulting by (spinning around left/right axis) - try 0.45.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float SomersaultDamp
        {
            get => GetArgument("somersaultDamp", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("somersaultDamp", argumentValue);
            }
        }

        /// <summary>
        /// Cartwheel AngularMomentum measure above which we start damping - try 27.0.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>27.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>200.00</c>.</para>
        /// </remarks>
        public float CartwheelThresh
        {
            get => GetArgument("cartwheelThresh", 27.00f);
            set
            {
                float argumentValue = System.Math.Min(200.00f, System.Math.Max(0.00f, value));
                SetArgument("cartwheelThresh", argumentValue);
            }
        }

        /// <summary>
        /// Amount to damp somersaulting by (spinning around front/back axis) - try 0.8.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float CartwheelDamp
        {
            get => GetArgument("cartwheelDamp", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("cartwheelDamp", argumentValue);
            }
        }

        /// <summary>
        /// Time after impact with a vehicle to apply characterDamping. -ve values mean always apply whether collided with vehicle or not. =0.0 never apply. =timestep apply for only that frame. A typical roll from being hit by a car lasts about 4secs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1000.00</c>.</para>
        /// </remarks>
        public float VehicleCollisionTime
        {
            get => GetArgument("vehicleCollisionTime", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1000.00f, System.Math.Max(-1.00f, value));
                SetArgument("vehicleCollisionTime", argumentValue);
            }
        }

        /// <summary>
        /// If true damping is proportional to Angular momentum squared. If false proportional to Angular momentum.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool V2
        {
            get => GetArgument("v2", false);
            set
            {
                bool argumentValue = value;
                SetArgument("v2", argumentValue);
            }
        }
    }

    /// <summary>
    /// SetFrictionScale:.
    /// </summary>
    public sealed class SetFrictionScaleHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SetFrictionScale NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SetFrictionScaleHelper(Ped ped) : base(ped, "setFrictionScale")
        {
        }

        /// <summary>
        /// Friction scale to be applied to parts in mask.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float Scale
        {
            get => GetArgument("scale", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("scale", argumentValue);
            }
        }

        /// <summary>
        /// Character-wide minimum impact friction. Affects all parts (not just those in mask).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1000000.00</c>.</para>
        /// </remarks>
        public float GlobalMin
        {
            get => GetArgument("globalMin", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1000000.00f, System.Math.Max(0.00f, value));
                SetArgument("globalMin", argumentValue);
            }
        }

        /// <summary>
        /// Character-wide maximum impact friction. Affects all parts (not just those in mask).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>999999.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1000000.00</c>.</para>
        /// </remarks>
        public float GlobalMax
        {
            get => GetArgument("globalMax", 999999.00f);
            set
            {
                float argumentValue = System.Math.Min(1000000.00f, System.Math.Max(0.00f, value));
                SetArgument("globalMax", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class AnimPoseHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the AnimPose NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public AnimPoseHelper(Ped ped) : base(ped, "animPose")
        {
        }

        /// <summary>
        /// MuscleStiffness of masked joints. -values mean don't apply (just use defaults or ones applied by behaviors - safer if you are going to return to a behavior).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.10</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float MuscleStiffness
        {
            get => GetArgument("muscleStiffness", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-1.10f, value));
                SetArgument("muscleStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of masked joints. -ve values mean don't apply stiffness or damping (just use defaults or ones applied by behaviors). If you are using animpose fullbody on its own then this gives the opprtunity to use setStffness and setMuscleStiffness messages to set up the character's muscles. mmmmtodo get rid of this -ve.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.10</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float Stiffness
        {
            get => GetArgument("stiffness", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(-1.10f, value));
                SetArgument("stiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping of masked joints.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float Damping
        {
            get => GetArgument("damping", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("damping", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see notes for explanation).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>ub</c>.</para>
        /// </remarks>
        public string EffectorMask
        {
            get => GetArgument("effectorMask", "ub");
            set
            {
                string argumentValue = value;
                SetArgument("effectorMask", argumentValue);
            }
        }

        /// <summary>
        /// Override Headlook behavior (if animPose includes the head).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool OverideHeadlook
        {
            get => GetArgument("overideHeadlook", false);
            set
            {
                bool argumentValue = value;
                SetArgument("overideHeadlook", argumentValue);
            }
        }

        /// <summary>
        /// Override PointArm behavior (if animPose includes the arm/arms).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool OveridePointArm
        {
            get => GetArgument("overidePointArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("overidePointArm", argumentValue);
            }
        }

        /// <summary>
        /// Override PointGun behavior (if animPose includes the arm/arms)//mmmmtodo not used at moment.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool OveridePointGun
        {
            get => GetArgument("overidePointGun", false);
            set
            {
                bool argumentValue = value;
                SetArgument("overidePointGun", argumentValue);
            }
        }

        /// <summary>
        /// If true then modify gravity compensation based on stance (can reduce gravity compensation to zero if cofm is outside of balance area).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseZMPGravityCompensation
        {
            get => GetArgument("useZMPGravityCompensation", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useZMPGravityCompensation", argumentValue);
            }
        }

        /// <summary>
        /// Gravity compensation applied to joints in the effectorMask. If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>14.00</c>.</para>
        /// </remarks>
        public float GravityCompensation
        {
            get => GetArgument("gravityCompensation", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(14.00f, System.Math.Max(-1.0f, value));
                SetArgument("gravityCompensation", argumentValue);
            }
        }

        /// <summary>
        /// Muscle stiffness applied to left arm (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float MuscleStiffnessLeftArm
        {
            get => GetArgument("muscleStiffnessLeftArm", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-1.0f, value));
                SetArgument("muscleStiffnessLeftArm", argumentValue);
            }
        }

        /// <summary>
        /// Muscle stiffness applied to right arm (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float MuscleStiffnessRightArm
        {
            get => GetArgument("muscleStiffnessRightArm", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-1.0f, value));
                SetArgument("muscleStiffnessRightArm", argumentValue);
            }
        }

        /// <summary>
        /// Muscle stiffness applied to spine (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float MuscleStiffnessSpine
        {
            get => GetArgument("muscleStiffnessSpine", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-1.0f, value));
                SetArgument("muscleStiffnessSpine", argumentValue);
            }
        }

        /// <summary>
        /// Muscle stiffness applied to left leg (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float MuscleStiffnessLeftLeg
        {
            get => GetArgument("muscleStiffnessLeftLeg", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-1.0f, value));
                SetArgument("muscleStiffnessLeftLeg", argumentValue);
            }
        }

        /// <summary>
        /// Muscle stiffness applied to right leg (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float MuscleStiffnessRightLeg
        {
            get => GetArgument("muscleStiffnessRightLeg", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-1.0f, value));
                SetArgument("muscleStiffnessRightLeg", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness applied to left arm (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float StiffnessLeftArm
        {
            get => GetArgument("stiffnessLeftArm", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(-1.0f, value));
                SetArgument("stiffnessLeftArm", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness applied to right arm (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float StiffnessRightArm
        {
            get => GetArgument("stiffnessRightArm", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(-1.0f, value));
                SetArgument("stiffnessRightArm", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness applied to spine (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float StiffnessSpine
        {
            get => GetArgument("stiffnessSpine", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(-1.0f, value));
                SetArgument("stiffnessSpine", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness applied to left leg (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float StiffnessLeftLeg
        {
            get => GetArgument("stiffnessLeftLeg", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(-1.0f, value));
                SetArgument("stiffnessLeftLeg", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness applied to right leg (applied after stiffness). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float StiffnessRightLeg
        {
            get => GetArgument("stiffnessRightLeg", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(-1.0f, value));
                SetArgument("stiffnessRightLeg", argumentValue);
            }
        }

        /// <summary>
        /// Damping applied to left arm (applied after stiffness). If stiffness -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float DampingLeftArm
        {
            get => GetArgument("dampingLeftArm", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.0f, value));
                SetArgument("dampingLeftArm", argumentValue);
            }
        }

        /// <summary>
        /// Damping applied to right arm (applied after stiffness). If stiffness -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float DampingRightArm
        {
            get => GetArgument("dampingRightArm", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.0f, value));
                SetArgument("dampingRightArm", argumentValue);
            }
        }

        /// <summary>
        /// Damping applied to spine (applied after stiffness). If stiffness-ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float DampingSpine
        {
            get => GetArgument("dampingSpine", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.0f, value));
                SetArgument("dampingSpine", argumentValue);
            }
        }

        /// <summary>
        /// Damping applied to left leg (applied after stiffness). If stiffness-ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float DampingLeftLeg
        {
            get => GetArgument("dampingLeftLeg", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.0f, value));
                SetArgument("dampingLeftLeg", argumentValue);
            }
        }

        /// <summary>
        /// Damping applied to right leg (applied after stiffness). If stiffness -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float DampingRightLeg
        {
            get => GetArgument("dampingRightLeg", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.0f, value));
                SetArgument("dampingRightLeg", argumentValue);
            }
        }

        /// <summary>
        /// Gravity compensation applied to left arm (applied after gravityCompensation). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>14.00</c>.</para>
        /// </remarks>
        public float GravCompLeftArm
        {
            get => GetArgument("gravCompLeftArm", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(14.00f, System.Math.Max(-1.0f, value));
                SetArgument("gravCompLeftArm", argumentValue);
            }
        }

        /// <summary>
        /// Gravity compensation applied to right arm (applied after gravityCompensation). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>14.00</c>.</para>
        /// </remarks>
        public float GravCompRightArm
        {
            get => GetArgument("gravCompRightArm", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(14.00f, System.Math.Max(-1.0f, value));
                SetArgument("gravCompRightArm", argumentValue);
            }
        }

        /// <summary>
        /// Gravity compensation applied to spine (applied after gravityCompensation). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>14.00</c>.</para>
        /// </remarks>
        public float GravCompSpine
        {
            get => GetArgument("gravCompSpine", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(14.00f, System.Math.Max(-1.0f, value));
                SetArgument("gravCompSpine", argumentValue);
            }
        }

        /// <summary>
        /// Gravity compensation applied to left leg (applied after gravityCompensation). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>14.00</c>.</para>
        /// </remarks>
        public float GravCompLeftLeg
        {
            get => GetArgument("gravCompLeftLeg", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(14.00f, System.Math.Max(-1.0f, value));
                SetArgument("gravCompLeftLeg", argumentValue);
            }
        }

        /// <summary>
        /// Gravity compensation applied to right leg (applied after gravityCompensation). If -ve then not applied (use current setting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>14.00</c>.</para>
        /// </remarks>
        public float GravCompRightLeg
        {
            get => GetArgument("gravCompRightLeg", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(14.00f, System.Math.Max(-1.0f, value));
                SetArgument("gravCompRightLeg", argumentValue);
            }
        }

        /// <summary>
        /// Is the left hand constrained to the world/ an object: -1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int ConnectedLeftHand
        {
            get => GetArgument("connectedLeftHand", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(-1, value));
                SetArgument("connectedLeftHand", argumentValue);
            }
        }

        /// <summary>
        /// Is the right hand constrained to the world/ an object: -1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int ConnectedRightHand
        {
            get => GetArgument("connectedRightHand", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(-1, value));
                SetArgument("connectedRightHand", argumentValue);
            }
        }

        /// <summary>
        /// Is the left foot constrained to the world/ an object: -2=do not set in animpose (e.g. let the balancer decide), -1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-2</c>.</para>
        /// <para>Minimum value: <c>-2</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int ConnectedLeftFoot
        {
            get => GetArgument("connectedLeftFoot", -2);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(-2, value));
                SetArgument("connectedLeftFoot", argumentValue);
            }
        }

        /// <summary>
        /// Is the right foot constrained to the world/ an object: -2=do not set in animpose (e.g. let the balancer decide),-1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-2</c>.</para>
        /// <para>Minimum value: <c>-2</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int ConnectedRightFoot
        {
            get => GetArgument("connectedRightFoot", -2);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(-2, value));
                SetArgument("connectedRightFoot", argumentValue);
            }
        }

        /// <summary>
        /// AnimSource 0 = CurrentItms, 1 = PreviousItms, 2 = AnimItms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>ART::kITSourceCurrent</c>.</para>
        /// <para>Minimum value: <c>ART::kITSourceCurrent</c>.</para>
        /// <para>Maximum value: <c>ART::KITSourceCount-1</c>.</para>
        /// </remarks>
        public AnimSource AnimSource
        {
            get => (AnimSource)GetArgument("animSource", (int)AnimSource.CurrentItems);
            set
            {
                AnimSource argumentValue = value;
                SetArgument("animSource", (int)argumentValue);
            }
        }

        /// <summary>
        /// LevelIndex of object to dampen side motion relative to. -1 means not used.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int DampenSideMotionInstanceIndex
        {
            get => GetArgument("dampenSideMotionInstanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("dampenSideMotionInstanceIndex", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ArmsWindmillHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ArmsWindmill NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ArmsWindmillHelper(Ped ped) : base(ped, "armsWindmill")
        {
        }

        /// <summary>
        /// ID of part that the circle uses as local space for positioning.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int LeftPartID
        {
            get => GetArgument("leftPartID", 10);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(0, value));
                SetArgument("leftPartID", argumentValue);
            }
        }

        /// <summary>
        /// Radius for first axis of ellipse.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.750</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LeftRadius1
        {
            get => GetArgument("leftRadius1", 0.750f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("leftRadius1", argumentValue);
            }
        }

        /// <summary>
        /// Radius for second axis of ellipse.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.750</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LeftRadius2
        {
            get => GetArgument("leftRadius2", 0.750f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("leftRadius2", argumentValue);
            }
        }

        /// <summary>
        /// Speed of target around the circle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>-2.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float LeftSpeed
        {
            get => GetArgument("leftSpeed", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(-2.00f, value));
                SetArgument("leftSpeed", argumentValue);
            }
        }

        /// <summary>
        /// Euler Angles orientation of circle in space of part with part ID.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, 0.20, 0.20</c>.</para>
        /// </remarks>
        public Vector3 LeftNormal
        {
            get => GetArgument("leftNormal", new Vector3(0.00f, 0.20f, 0.20f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("leftNormal", argumentValue);
            }
        }

        /// <summary>
        /// Centre of circle in the space of partID.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, 0.50, -0.10</c>.</para>
        /// </remarks>
        public Vector3 LeftCentre
        {
            get => GetArgument("leftCentre", new Vector3(0.00f, 0.50f, -0.10f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("leftCentre", argumentValue);
            }
        }

        /// <summary>
        /// ID of part that the circle uses as local space for positioning.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int RightPartID
        {
            get => GetArgument("rightPartID", 10);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(0, value));
                SetArgument("rightPartID", argumentValue);
            }
        }

        /// <summary>
        /// Radius for first axis of ellipse.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.750</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float RightRadius1
        {
            get => GetArgument("rightRadius1", 0.750f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("rightRadius1", argumentValue);
            }
        }

        /// <summary>
        /// Radius for second axis of ellipse.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.750</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float RightRadius2
        {
            get => GetArgument("rightRadius2", 0.750f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("rightRadius2", argumentValue);
            }
        }

        /// <summary>
        /// Speed of target around the circle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>-2.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float RightSpeed
        {
            get => GetArgument("rightSpeed", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(-2.00f, value));
                SetArgument("rightSpeed", argumentValue);
            }
        }

        /// <summary>
        /// Euler Angles orientation of circle in space of part with part ID.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, -0.20, -0.20</c>.</para>
        /// </remarks>
        public Vector3 RightNormal
        {
            get => GetArgument("rightNormal", new Vector3(0.00f, -0.20f, -0.20f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("rightNormal", argumentValue);
            }
        }

        /// <summary>
        /// Centre of circle in the space of partID.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00, -0.50, -0.10</c>.</para>
        /// </remarks>
        public Vector3 RightCentre
        {
            get => GetArgument("rightCentre", new Vector3(0.00f, -0.50f, -0.10f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("rightCentre", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness applied to the shoulders.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.00</c>.</para>
        /// <para>Minimum value: <c>1.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float ShoulderStiffness
        {
            get => GetArgument("shoulderStiffness", 12.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(1.00f, value));
                SetArgument("shoulderStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping applied to the shoulders.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float ShoulderDamping
        {
            get => GetArgument("shoulderDamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("shoulderDamping", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness applied to the elbows.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.00</c>.</para>
        /// <para>Minimum value: <c>1.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float ElbowStiffness
        {
            get => GetArgument("elbowStiffness", 12.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(1.00f, value));
                SetArgument("elbowStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping applied to the elbows.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float ElbowDamping
        {
            get => GetArgument("elbowDamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("elbowDamping", argumentValue);
            }
        }

        /// <summary>
        /// Minimum left elbow bend.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.70</c>.</para>
        /// </remarks>
        public float LeftElbowMin
        {
            get => GetArgument("leftElbowMin", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.70f, System.Math.Max(0.00f, value));
                SetArgument("leftElbowMin", argumentValue);
            }
        }

        /// <summary>
        /// Minimum right elbow bend.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.70</c>.</para>
        /// </remarks>
        public float RightElbowMin
        {
            get => GetArgument("rightElbowMin", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.70f, System.Math.Max(0.00f, value));
                SetArgument("rightElbowMin", argumentValue);
            }
        }

        /// <summary>
        /// Phase offset(degrees) when phase synchronization is turned on.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-360.00</c>.</para>
        /// <para>Maximum value: <c>360.00</c>.</para>
        /// </remarks>
        public float PhaseOffset
        {
            get => GetArgument("phaseOffset", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(360.00f, System.Math.Max(-360.00f, value));
                SetArgument("phaseOffset", argumentValue);
            }
        }

        /// <summary>
        /// How much to compensate for movement of character/target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float DragReduction
        {
            get => GetArgument("dragReduction", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("dragReduction", argumentValue);
            }
        }

        /// <summary>
        /// Angle of elbow around twist axis ?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-3.141593</c>.</para>
        /// <para>Maximum value: <c>3.141593</c>.</para>
        /// </remarks>
        public float IKtwist
        {
            get => GetArgument("IKtwist", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(3.141593f, System.Math.Max(-3.141593f, value));
                SetArgument("IKtwist", argumentValue);
            }
        }

        /// <summary>
        /// Value of character angular speed above which adaptive arm motion starts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float AngVelThreshold
        {
            get => GetArgument("angVelThreshold", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("angVelThreshold", argumentValue);
            }
        }

        /// <summary>
        /// Multiplies angular speed of character to get speed of arms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float AngVelGain
        {
            get => GetArgument("angVelGain", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("angVelGain", argumentValue);
            }
        }

        /// <summary>
        /// 0: circle orientations are independent, 1: they mirror each other, 2: they're parallel (leftArm parmeters are used).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public MirrorMode MirrorMode
        {
            get => (MirrorMode)GetArgument("mirrorMode", (int)(MirrorMode)1);
            set
            {
                MirrorMode argumentValue = value;
                SetArgument("mirrorMode", (int)argumentValue);
            }
        }

        /// <summary>
        /// 0:not adaptive, 1:only direction, 2: dir and speed, 3: dir, speed and strength.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public AdaptiveMode AdaptiveMode
        {
            get => (AdaptiveMode)GetArgument("adaptiveMode", (int)(AdaptiveMode)0);
            set
            {
                AdaptiveMode argumentValue = value;
                SetArgument("adaptiveMode", (int)argumentValue);
            }
        }

        /// <summary>
        /// Toggles phase synchronization.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ForceSync
        {
            get => GetArgument("forceSync", true);
            set
            {
                bool argumentValue = value;
                SetArgument("forceSync", argumentValue);
            }
        }

        /// <summary>
        /// Use the left arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseLeft
        {
            get => GetArgument("useLeft", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useLeft", argumentValue);
            }
        }

        /// <summary>
        /// Use the right arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseRight
        {
            get => GetArgument("useRight", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useRight", argumentValue);
            }
        }

        /// <summary>
        /// If true, each arm will stop windmilling if it hits the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool DisableOnImpact
        {
            get => GetArgument("disableOnImpact", true);
            set
            {
                bool argumentValue = value;
                SetArgument("disableOnImpact", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ArmsWindmillAdaptiveHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ArmsWindmillAdaptive NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ArmsWindmillAdaptiveHelper(Ped ped) : base(ped, "armsWindmillAdaptive")
        {
        }

        /// <summary>
        /// Controls the speed of the windmilling.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>6.280</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float AngSpeed
        {
            get => GetArgument("angSpeed", 6.280f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.10f, value));
                SetArgument("angSpeed", argumentValue);
            }
        }

        /// <summary>
        /// Controls how stiff the rest of the body is.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11.000</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float BodyStiffness
        {
            get => GetArgument("bodyStiffness", 11.000f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("bodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Controls how large the motion is, higher values means the character waves his arms in a massive arc.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.600</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float Amplitude
        {
            get => GetArgument("amplitude", 0.600f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("amplitude", argumentValue);
            }
        }

        /// <summary>
        /// Set to a non-zero value to desynchronise the left and right arms motion.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>-4.0</c>.</para>
        /// <para>Maximum value: <c>8.0</c>.</para>
        /// </remarks>
        public float Phase
        {
            get => GetArgument("phase", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(8.0f, System.Math.Max(-4.0f, value));
                SetArgument("phase", argumentValue);
            }
        }

        /// <summary>
        /// How stiff the arms are controls how pronounced the windmilling motion appears.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>14.140</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffness
        {
            get => GetArgument("armStiffness", 14.140f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("armStiffness", argumentValue);
            }
        }

        /// <summary>
        /// If not negative then left arm will blend to this angle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>6.0</c>.</para>
        /// </remarks>
        public float LeftElbowAngle
        {
            get => GetArgument("leftElbowAngle", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(6.0f, System.Math.Max(-1.0f, value));
                SetArgument("leftElbowAngle", argumentValue);
            }
        }

        /// <summary>
        /// If not negative then right arm will blend to this angle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>6.0</c>.</para>
        /// </remarks>
        public float RightElbowAngle
        {
            get => GetArgument("rightElbowAngle", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(6.0f, System.Math.Max(-1.0f, value));
                SetArgument("rightElbowAngle", argumentValue);
            }
        }

        /// <summary>
        /// 0 arms go up and down at the side. 1 circles. 0..1 elipse.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float Lean1mult
        {
            get => GetArgument("lean1mult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("lean1mult", argumentValue);
            }
        }

        /// <summary>
        /// 0.f centre of circle at side.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>-6.0</c>.</para>
        /// <para>Maximum value: <c>6.0</c>.</para>
        /// </remarks>
        public float Lean1offset
        {
            get => GetArgument("lean1offset", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(6.0f, System.Math.Max(-6.0f, value));
                SetArgument("lean1offset", argumentValue);
            }
        }

        /// <summary>
        /// Rate at which elbow tries to match *ElbowAngle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>6.0</c>.</para>
        /// </remarks>
        public float ElbowRate
        {
            get => GetArgument("elbowRate", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(6.0f, System.Math.Max(0.0f, value));
                SetArgument("elbowRate", argumentValue);
            }
        }

        /// <summary>
        /// Arm circling direction. -1 = Backwards, 0 = Adaptive, 1 = Forwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// <para>Maximum value: <c>1</c>.</para>
        /// </remarks>
        public ArmDirection ArmDirection
        {
            get => (ArmDirection)GetArgument("armDirection", (int)(ArmDirection)0);
            set
            {
                ArmDirection argumentValue = value;
                SetArgument("armDirection", (int)argumentValue);
            }
        }

        /// <summary>
        /// If true, each arm will stop windmilling if it hits the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool DisableOnImpact
        {
            get => GetArgument("disableOnImpact", true);
            set
            {
                bool argumentValue = value;
                SetArgument("disableOnImpact", argumentValue);
            }
        }

        /// <summary>
        /// If true, back angles will be set to compliment arms windmill.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SetBackAngles
        {
            get => GetArgument("setBackAngles", true);
            set
            {
                bool argumentValue = value;
                SetArgument("setBackAngles", argumentValue);
            }
        }

        /// <summary>
        /// If true, use angular momentum about com to choose arm circling direction. Otherwise use com angular velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseAngMom
        {
            get => GetArgument("useAngMom", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useAngMom", argumentValue);
            }
        }

        /// <summary>
        /// If true, bend the left elbow to give a stuntman type scramble look.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BendLeftElbow
        {
            get => GetArgument("bendLeftElbow", false);
            set
            {
                bool argumentValue = value;
                SetArgument("bendLeftElbow", argumentValue);
            }
        }

        /// <summary>
        /// If true, bend the right elbow to give a stuntman type scramble look.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BendRightElbow
        {
            get => GetArgument("bendRightElbow", false);
            set
            {
                bool argumentValue = value;
                SetArgument("bendRightElbow", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>ub</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "ub");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class BalancerCollisionsReactionHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the BalancerCollisionsReaction NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public BalancerCollisionsReactionHelper(Ped ped) : base(ped, "balancerCollisionsReaction")
        {
        }

        /// <summary>
        /// Begin slump and stop stepping after this many steps.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int NumStepsTillSlump
        {
            get => GetArgument("numStepsTillSlump", 4);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("numStepsTillSlump", argumentValue);
            }
        }

        /// <summary>
        /// Time after becoming stable leaning against a wall that slump starts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public float Stable2SlumpTime
        {
            get => GetArgument("stable2SlumpTime", 0.0f);
            set
            {
                float argumentValue = System.Math.Max(0.0f, value);
                SetArgument("stable2SlumpTime", argumentValue);
            }
        }

        /// <summary>
        /// Steps are ihibited to not go closer to the wall than this (after impact).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.2</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public float ExclusionZone
        {
            get => GetArgument("exclusionZone", 0.2f);
            set
            {
                float argumentValue = System.Math.Max(0.0f, value);
                SetArgument("exclusionZone", argumentValue);
            }
        }

        /// <summary>
        /// Friction multiplier applied to feet when slump starts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float FootFrictionMultStart
        {
            get => GetArgument("footFrictionMultStart", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("footFrictionMultStart", argumentValue);
            }
        }

        /// <summary>
        /// Friction multiplier reduced by this amount every second after slump starts (only if character is not slumping).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>50.0</c>.</para>
        /// </remarks>
        public float FootFrictionMultRate
        {
            get => GetArgument("footFrictionMultRate", 2.0f);
            set
            {
                float argumentValue = System.Math.Min(50.0f, System.Math.Max(0.0f, value));
                SetArgument("footFrictionMultRate", argumentValue);
            }
        }

        /// <summary>
        /// Friction multiplier applied to back when slump starts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float BackFrictionMultStart
        {
            get => GetArgument("backFrictionMultStart", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("backFrictionMultStart", argumentValue);
            }
        }

        /// <summary>
        /// Friction multiplier reduced by this amount every second after slump starts (only if character is not slumping).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>50.0</c>.</para>
        /// </remarks>
        public float BackFrictionMultRate
        {
            get => GetArgument("backFrictionMultRate", 2.0f);
            set
            {
                float argumentValue = System.Math.Min(50.0f, System.Math.Max(0.0f, value));
                SetArgument("backFrictionMultRate", argumentValue);
            }
        }

        /// <summary>
        /// Reduce the stiffness of the legs by this much as soon as an impact is detected.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ImpactLegStiffReduction
        {
            get => GetArgument("impactLegStiffReduction", 3.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("impactLegStiffReduction", argumentValue);
            }
        }

        /// <summary>
        /// Reduce the stiffness of the legs by this much as soon as slump starts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float SlumpLegStiffReduction
        {
            get => GetArgument("slumpLegStiffReduction", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("slumpLegStiffReduction", argumentValue);
            }
        }

        /// <summary>
        /// Rate at which the stiffness of the legs is reduced during slump.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>50.0</c>.</para>
        /// </remarks>
        public float SlumpLegStiffRate
        {
            get => GetArgument("slumpLegStiffRate", 8.0f);
            set
            {
                float argumentValue = System.Math.Min(50.0f, System.Math.Max(0.0f, value));
                SetArgument("slumpLegStiffRate", argumentValue);
            }
        }

        /// <summary>
        /// Time that the character reacts to the impact with ub flinch and writhe.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.3</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ReactTime
        {
            get => GetArgument("reactTime", 0.3f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("reactTime", argumentValue);
            }
        }

        /// <summary>
        /// Time that the character exaggerates impact with spine.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.3</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ImpactExagTime
        {
            get => GetArgument("impactExagTime", 0.3f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("impactExagTime", argumentValue);
            }
        }

        /// <summary>
        /// Duration that the glance torque is applied for.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float GlanceSpinTime
        {
            get => GetArgument("glanceSpinTime", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("glanceSpinTime", argumentValue);
            }
        }

        /// <summary>
        /// Magnitude of the glance torque.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>50.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1000.0</c>.</para>
        /// </remarks>
        public float GlanceSpinMag
        {
            get => GetArgument("glanceSpinMag", 50.0f);
            set
            {
                float argumentValue = System.Math.Min(1000.0f, System.Math.Max(0.0f, value));
                SetArgument("glanceSpinMag", argumentValue);
            }
        }

        /// <summary>
        /// Multiplier used when decaying torque spin over time.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.3</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float GlanceSpinDecayMult
        {
            get => GetArgument("glanceSpinDecayMult", 0.3f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("glanceSpinDecayMult", argumentValue);
            }
        }

        /// <summary>
        /// Used so impact with the character that is pushing you over doesn't set off the behavior.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-2</c>.</para>
        /// <para>Minimum value: <c>-2</c>.</para>
        /// </remarks>
        public int IgnoreColWithIndex
        {
            get => GetArgument("ignoreColWithIndex", -2);
            set
            {
                int argumentValue = System.Math.Max(-2, value);
                SetArgument("ignoreColWithIndex", argumentValue);
            }
        }

        /// <summary>
        /// 0=Normal slump(less movement then slump and movement LT small), 1=fast slump, 2=less movement then slump.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int SlumpMode
        {
            get => GetArgument("slumpMode", 1);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("slumpMode", argumentValue);
            }
        }

        /// <summary>
        /// 0=fall2knees/slump if shot not running, 1=stumble, 2=slump, 3=restart.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public int ReboundMode
        {
            get => GetArgument("reboundMode", 0);
            set
            {
                int argumentValue = System.Math.Min(3, System.Math.Max(0, value));
                SetArgument("reboundMode", argumentValue);
            }
        }

        /// <summary>
        /// Collisions with non-fixed objects with mass below this will not set this behavior off (e.g. ignore guns).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>20.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1000.0</c>.</para>
        /// </remarks>
        public float IgnoreColMassBelow
        {
            get => GetArgument("ignoreColMassBelow", 20.0f);
            set
            {
                float argumentValue = System.Math.Min(1000.0f, System.Math.Max(-1.0f, value));
                SetArgument("ignoreColMassBelow", argumentValue);
            }
        }

        /// <summary>
        /// 0=slump, 1=fallToKnees if shot is running, otherwise slump.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>1</c>.</para>
        /// </remarks>
        public int ForwardMode
        {
            get => GetArgument("forwardMode", 0);
            set
            {
                int argumentValue = System.Math.Min(1, System.Math.Max(0, value));
                SetArgument("forwardMode", argumentValue);
            }
        }

        /// <summary>
        /// Time after a forwards impact before forwardMode is called (leave sometime for a rebound or brace - the min of 0.1 is to ensure fallOverWall can start although it probably needs only 1or2 frames for the probes to return).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float TimeToForward
        {
            get => GetArgument("timeToForward", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.10f, value));
                SetArgument("timeToForward", argumentValue);
            }
        }

        /// <summary>
        /// If forwards impact only: cheat force to try to get the character away from the wall. 3 is a good value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ReboundForce
        {
            get => GetArgument("reboundForce", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("reboundForce", argumentValue);
            }
        }

        /// <summary>
        /// Brace against wall if forwards impact(at the moment only if bodyBalance is running/in charge of arms).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool BraceWall
        {
            get => GetArgument("braceWall", true);
            set
            {
                bool argumentValue = value;
                SetArgument("braceWall", argumentValue);
            }
        }

        /// <summary>
        /// Collisions with non-fixed objects with volume below this will not set this behavior off.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1000.0</c>.</para>
        /// </remarks>
        public float IgnoreColVolumeBelow
        {
            get => GetArgument("ignoreColVolumeBelow", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(1000.0f, System.Math.Max(-1.0f, value));
                SetArgument("ignoreColVolumeBelow", argumentValue);
            }
        }

        /// <summary>
        /// Use fallOverWall as the main drape reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool FallOverWallDrape
        {
            get => GetArgument("fallOverWallDrape", true);
            set
            {
                bool argumentValue = value;
                SetArgument("fallOverWallDrape", argumentValue);
            }
        }

        /// <summary>
        /// Trigger fall over wall if hit up to spine2 else only if hit up to spine1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FallOverHighWalls
        {
            get => GetArgument("fallOverHighWalls", false);
            set
            {
                bool argumentValue = value;
                SetArgument("fallOverHighWalls", argumentValue);
            }
        }

        /// <summary>
        /// Add a Snap to when you hit a wall to emphasize the hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Snap
        {
            get => GetArgument("snap", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snap", argumentValue);
            }
        }

        /// <summary>
        /// The magnitude of the snap reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.60</c>.</para>
        /// <para>Minimum value: <c>-10.00</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float SnapMag
        {
            get => GetArgument("snapMag", -0.60f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(-10.00f, value));
                SetArgument("snapMag", argumentValue);
            }
        }

        /// <summary>
        /// The character snaps in a prescribed way (decided by bullet direction) - Higher the value the more random this direction is.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float SnapDirectionRandomness
        {
            get => GetArgument("snapDirectionRandomness", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.00f, value));
                SetArgument("snapDirectionRandomness", argumentValue);
            }
        }

        /// <summary>
        /// Snap the leftArm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapLeftArm
        {
            get => GetArgument("snapLeftArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapLeftArm", argumentValue);
            }
        }

        /// <summary>
        /// Snap the rightArm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapRightArm
        {
            get => GetArgument("snapRightArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapRightArm", argumentValue);
            }
        }

        /// <summary>
        /// Snap the leftLeg.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapLeftLeg
        {
            get => GetArgument("snapLeftLeg", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapLeftLeg", argumentValue);
            }
        }

        /// <summary>
        /// Snap the rightLeg.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapRightLeg
        {
            get => GetArgument("snapRightLeg", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapRightLeg", argumentValue);
            }
        }

        /// <summary>
        /// Snap the spine.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SnapSpine
        {
            get => GetArgument("snapSpine", true);
            set
            {
                bool argumentValue = value;
                SetArgument("snapSpine", argumentValue);
            }
        }

        /// <summary>
        /// Snap the neck.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SnapNeck
        {
            get => GetArgument("snapNeck", true);
            set
            {
                bool argumentValue = value;
                SetArgument("snapNeck", argumentValue);
            }
        }

        /// <summary>
        /// Legs are either in phase with each other or not.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SnapPhasedLegs
        {
            get => GetArgument("snapPhasedLegs", true);
            set
            {
                bool argumentValue = value;
                SetArgument("snapPhasedLegs", argumentValue);
            }
        }

        /// <summary>
        /// Type of hip reaction 0=none, 1=side2side 2=steplike.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int SnapHipType
        {
            get => GetArgument("snapHipType", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("snapHipType", argumentValue);
            }
        }

        /// <summary>
        /// Interval before applying reverse snap.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.010</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public float UnSnapInterval
        {
            get => GetArgument("unSnapInterval", 0.010f);
            set
            {
                float argumentValue = System.Math.Min(100.0f, System.Math.Max(0.00f, value));
                SetArgument("unSnapInterval", argumentValue);
            }
        }

        /// <summary>
        /// The magnitude of the reverse snap.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public float UnSnapRatio
        {
            get => GetArgument("unSnapRatio", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(100.0f, System.Math.Max(0.00f, value));
                SetArgument("unSnapRatio", argumentValue);
            }
        }

        /// <summary>
        /// Use torques to make the snap otherwise use a change in the parts angular velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SnapUseTorques
        {
            get => GetArgument("snapUseTorques", true);
            set
            {
                bool argumentValue = value;
                SetArgument("snapUseTorques", argumentValue);
            }
        }

        /// <summary>
        /// Duration for which the character's upper body stays at minimum stiffness (not quite zero).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ImpactWeaknessZeroDuration
        {
            get => GetArgument("impactWeaknessZeroDuration", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("impactWeaknessZeroDuration", argumentValue);
            }
        }

        /// <summary>
        /// Duration of the ramp to bring the character's upper body stiffness back to normal levels.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.010</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ImpactWeaknessRampDuration
        {
            get => GetArgument("impactWeaknessRampDuration", 0.010f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.010f, value));
                SetArgument("impactWeaknessRampDuration", argumentValue);
            }
        }

        /// <summary>
        /// How loose the character is on impact. between 0 and 1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ImpactLoosenessAmount
        {
            get => GetArgument("impactLoosenessAmount", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("impactLoosenessAmount", argumentValue);
            }
        }

        /// <summary>
        /// Detected an object behind a shot victim in the direction of a bullet?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ObjectBehindVictim
        {
            get => GetArgument("objectBehindVictim", false);
            set
            {
                bool argumentValue = value;
                SetArgument("objectBehindVictim", argumentValue);
            }
        }

        /// <summary>
        /// The intersection pos of a detected object behind a shot victim in the direction of a bullet.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 ObjectBehindVictimPos
        {
            get => GetArgument("objectBehindVictimPos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("objectBehindVictimPos", argumentValue);
            }
        }

        /// <summary>
        /// The normal of a detected object behind a shot victim in the direction of a bullet.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public Vector3 ObjectBehindVictimNormal
        {
            get => GetArgument("objectBehindVictimNormal", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-1.00f, -1.00f, -1.00f), new Vector3(1.00f, 1.00f, 1.00f));
                SetArgument("objectBehindVictimNormal", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class BodyBalanceHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the BodyBalance NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public BodyBalanceHelper(Ped ped) : base(ped, "bodyBalance")
        {
        }

        /// <summary>
        /// NB. WAS m_bodyStiffness ClaviclesStiffness=9.0f.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>9.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffness
        {
            get => GetArgument("armStiffness", 9.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("armStiffness", argumentValue);
            }
        }

        /// <summary>
        /// How much the elbow swings based on the leg movement.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.9</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float Elbow
        {
            get => GetArgument("elbow", 0.9f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("elbow", argumentValue);
            }
        }

        /// <summary>
        /// How much the shoulder(lean1) swings based on the leg movement.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float Shoulder
        {
            get => GetArgument("shoulder", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("shoulder", argumentValue);
            }
        }

        /// <summary>
        /// NB. WAS m_damping NeckDamping=1 ClaviclesDamping=1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.7</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmDamping
        {
            get => GetArgument("armDamping", 0.7f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armDamping", argumentValue);
            }
        }

        /// <summary>
        /// Enable and provide a look-at target to make the character's head turn to face it while balancing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseHeadLook
        {
            get => GetArgument("useHeadLook", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useHeadLook", argumentValue);
            }
        }

        /// <summary>
        /// Position of thing to look at.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 HeadLookPos
        {
            get => GetArgument("headLookPos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("headLookPos", argumentValue);
            }
        }

        /// <summary>
        /// Level index of thing to look at.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int HeadLookInstanceIndex
        {
            get => GetArgument("headLookInstanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("headLookInstanceIndex", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets spineStiffness.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float SpineStiffness
        {
            get => GetArgument("spineStiffness", 10.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("spineStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Multiplier of the somersault 'angle' (lean forward/back) for arms out (lean2).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float SomersaultAngle
        {
            get => GetArgument("somersaultAngle", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("somersaultAngle", argumentValue);
            }
        }

        /// <summary>
        /// Amount of somersault 'angle' before m_somersaultAngle is used for ArmsOut. Unless drunk - DO NOT EXCEED 0.8.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.25</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float SomersaultAngleThreshold
        {
            get => GetArgument("somersaultAngleThreshold", 0.25f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("somersaultAngleThreshold", argumentValue);
            }
        }

        /// <summary>
        /// Amount of side somersault 'angle' before sideSomersault is used for ArmsOut. Unless drunk - DO NOT EXCEED 0.8.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float SideSomersaultAngle
        {
            get => GetArgument("sideSomersaultAngle", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("sideSomersaultAngle", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets sideSomersaultAngleThreshold.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.25</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float SideSomersaultAngleThreshold
        {
            get => GetArgument("sideSomersaultAngleThreshold", 0.25f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("sideSomersaultAngleThreshold", argumentValue);
            }
        }

        /// <summary>
        /// Automatically turn around if moving backwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BackwardsAutoTurn
        {
            get => GetArgument("backwardsAutoTurn", false);
            set
            {
                bool argumentValue = value;
                SetArgument("backwardsAutoTurn", argumentValue);
            }
        }

        /// <summary>
        /// 0.9 is a sensible value. If pusher within this distance then turn to get out of the way of the pusher.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float TurnWithBumpRadius
        {
            get => GetArgument("turnWithBumpRadius", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-1.00f, value));
                SetArgument("turnWithBumpRadius", argumentValue);
            }
        }

        /// <summary>
        /// Bend elbows, relax shoulders and inhibit spine twist when moving backwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BackwardsArms
        {
            get => GetArgument("backwardsArms", false);
            set
            {
                bool argumentValue = value;
                SetArgument("backwardsArms", argumentValue);
            }
        }

        /// <summary>
        /// Blend upper body to zero pose as the character comes to rest. If false blend to a stored pose.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BlendToZeroPose
        {
            get => GetArgument("blendToZeroPose", false);
            set
            {
                bool argumentValue = value;
                SetArgument("blendToZeroPose", argumentValue);
            }
        }

        /// <summary>
        /// Put arms out based on lean2 of legs, or angular velocity (lean or twist), or lean (front/back or side/side).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ArmsOutOnPush
        {
            get => GetArgument("armsOutOnPush", true);
            set
            {
                bool argumentValue = value;
                SetArgument("armsOutOnPush", argumentValue);
            }
        }

        /// <summary>
        /// Arms out based on lean2 of the legs to simulate being pushed.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmsOutOnPushMultiplier
        {
            get => GetArgument("armsOutOnPushMultiplier", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armsOutOnPushMultiplier", argumentValue);
            }
        }

        /// <summary>
        /// Number of seconds before turning off the armsOutOnPush response only for Arms out based on lean2 of the legs (NOT for the angle or angular velocity).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmsOutOnPushTimeout
        {
            get => GetArgument("armsOutOnPushTimeout", 1.1f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armsOutOnPushTimeout", argumentValue);
            }
        }

        /// <summary>
        /// Range 0:1 0 = don't raise arms if returning to upright position, 0.x = 0.x*raise arms based on angvel and 'angle' settings, 1 = raise arms based on angvel and 'angle' settings.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ReturningToBalanceArmsOut
        {
            get => GetArgument("returningToBalanceArmsOut", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("returningToBalanceArmsOut", argumentValue);
            }
        }

        /// <summary>
        /// Multiplier for straightening the elbows based on the amount of arms out(lean2) 0 = dont straighten elbows. Otherwise straighten elbows proportionately to armsOut.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ArmsOutStraightenElbows
        {
            get => GetArgument("armsOutStraightenElbows", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("armsOutStraightenElbows", argumentValue);
            }
        }

        /// <summary>
        /// Minimum desiredLean2 applied to shoulder (to stop arms going above shoulder height or not).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-9.9</c>.</para>
        /// <para>Minimum value: <c>-10.0</c>.</para>
        /// <para>Maximum value: <c>0.0</c>.</para>
        /// </remarks>
        public float ArmsOutMinLean2
        {
            get => GetArgument("armsOutMinLean2", -9.9f);
            set
            {
                float argumentValue = System.Math.Min(0.0f, System.Math.Max(-10.0f, value));
                SetArgument("armsOutMinLean2", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets spineDamping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float SpineDamping
        {
            get => GetArgument("spineDamping", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("spineDamping", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets useBodyTurn.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseBodyTurn
        {
            get => GetArgument("useBodyTurn", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useBodyTurn", argumentValue);
            }
        }

        /// <summary>
        /// On contact with upperbody the desired elbow angle is set to at least this value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.9</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float ElbowAngleOnContact
        {
            get => GetArgument("elbowAngleOnContact", 1.9f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("elbowAngleOnContact", argumentValue);
            }
        }

        /// <summary>
        /// Time after contact (with Upper body) that the min m_elbowAngleOnContact is applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.3</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float BendElbowsTime
        {
            get => GetArgument("bendElbowsTime", 0.3f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("bendElbowsTime", argumentValue);
            }
        }

        /// <summary>
        /// Minimum desired angle of elbow during non contact arm swing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.7</c>.</para>
        /// <para>Minimum value: <c>-3.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float BendElbowsGait
        {
            get => GetArgument("bendElbowsGait", 0.7f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(-3.0f, value));
                SetArgument("bendElbowsGait", argumentValue);
            }
        }

        /// <summary>
        /// Mmmmdrunk = 0.2 multiplier of hip lean2 (star jump) to give shoulder lean2 (flapping).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.3</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float HipL2ArmL2
        {
            get => GetArgument("hipL2ArmL2", 0.3f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("hipL2ArmL2", argumentValue);
            }
        }

        /// <summary>
        /// Mmmmdrunk = 0.7 shoulder lean2 offset.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>-3.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float ShoulderL2
        {
            get => GetArgument("shoulderL2", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(-3.0f, value));
                SetArgument("shoulderL2", argumentValue);
            }
        }

        /// <summary>
        /// Mmmmdrunk 1.1 shoulder lean1 offset (+ve frankenstein).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ShoulderL1
        {
            get => GetArgument("shoulderL1", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(-1.0f, value));
                SetArgument("shoulderL1", argumentValue);
            }
        }

        /// <summary>
        /// Mmmmdrunk = 0.0 shoulder twist.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.35</c>.</para>
        /// <para>Minimum value: <c>-3.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float ShoulderTwist
        {
            get => GetArgument("shoulderTwist", -0.35f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(-3.0f, value));
                SetArgument("shoulderTwist", argumentValue);
            }
        }

        /// <summary>
        /// Probability [0-1] that headLook will be looking in the direction of velocity when stepping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float HeadLookAtVelProb
        {
            get => GetArgument("headLookAtVelProb", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("headLookAtVelProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability that turn will be off. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TurnOffProb
        {
            get => GetArgument("turnOffProb", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turnOffProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning towards velocity. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.3</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float Turn2VelProb
        {
            get => GetArgument("turn2VelProb", 0.3f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turn2VelProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning away from headLook target. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.15</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TurnAwayProb
        {
            get => GetArgument("turnAwayProb", 0.15f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turnAwayProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning left. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.125</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TurnLeftProb
        {
            get => GetArgument("turnLeftProb", 0.125f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turnLeftProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning right. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.125</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TurnRightProb
        {
            get => GetArgument("turnRightProb", 0.125f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turnRightProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning towards headLook target. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.2</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float Turn2TargetProb
        {
            get => GetArgument("turn2TargetProb", 0.2f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turn2TargetProb", argumentValue);
            }
        }

        /// <summary>
        /// Somersault, twist, sideSomersault) multiplier of the angular velocity for arms out (lean2) (somersault, twist, sideSomersault).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00, 1.00, 4.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public Vector3 AngVelMultiplier
        {
            get => GetArgument("angVelMultiplier", new Vector3(4.00f, 1.00f, 4.00f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(20.0f, 20.0f, 20.0f));
                SetArgument("angVelMultiplier", argumentValue);
            }
        }

        /// <summary>
        /// Somersault, twist, sideSomersault) threshold above which angVel is used for arms out (lean2) Unless drunk - DO NOT EXCEED 7.0 for each component.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.20, 3.00, 1.20</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>40.0</c>.</para>
        /// </remarks>
        public Vector3 AngVelThreshold
        {
            get => GetArgument("angVelThreshold", new Vector3(1.20f, 3.00f, 1.20f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(40.0f, 40.0f, 40.0f));
                SetArgument("angVelThreshold", argumentValue);
            }
        }

        /// <summary>
        /// If -ve then do not brace. distance from object at which to raise hands to brace 0.5 good if newBrace=true - otherwise 0.65.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float BraceDistance
        {
            get => GetArgument("braceDistance", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("braceDistance", argumentValue);
            }
        }

        /// <summary>
        /// Time expected to get arms up from idle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.450</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TargetPredictionTime
        {
            get => GetArgument("targetPredictionTime", 0.450f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("targetPredictionTime", argumentValue);
            }
        }

        /// <summary>
        /// Larger values and he absorbs the impact more.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.150</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ReachAbsorbtionTime
        {
            get => GetArgument("reachAbsorbtionTime", 0.150f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("reachAbsorbtionTime", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of character. catch_fall stiffness scales with this too, with its defaults at this values default.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float BraceStiffness
        {
            get => GetArgument("braceStiffness", 12.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(6.00f, value));
                SetArgument("braceStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Minimum bracing time so the character doesn't look twitchy.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float MinBraceTime
        {
            get => GetArgument("minBraceTime", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("minBraceTime", argumentValue);
            }
        }

        /// <summary>
        /// Time before arm brace kicks in when hit from behind.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float TimeToBackwardsBrace
        {
            get => GetArgument("timeToBackwardsBrace", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("timeToBackwardsBrace", argumentValue);
            }
        }

        /// <summary>
        /// If bracing with 2 hands delay one hand by at least this amount of time to introduce some asymmetry.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float HandsDelayMin
        {
            get => GetArgument("handsDelayMin", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("handsDelayMin", argumentValue);
            }
        }

        /// <summary>
        /// If bracing with 2 hands delay one hand by at most this amount of time to introduce some asymmetry.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float HandsDelayMax
        {
            get => GetArgument("handsDelayMax", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("handsDelayMax", argumentValue);
            }
        }

        /// <summary>
        /// BraceTarget is global headLookPos plus braceOffset m in the up direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-2.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float BraceOffset
        {
            get => GetArgument("braceOffset", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(-2.00f, value));
                SetArgument("braceOffset", argumentValue);
            }
        }

        /// <summary>
        /// If -ve don't move away from pusher unless moveWhenBracing is true and braceDistance GT 0.0f. if the pusher is closer than moveRadius then move away from it.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float MoveRadius
        {
            get => GetArgument("moveRadius", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(-1.00f, value));
                SetArgument("moveRadius", argumentValue);
            }
        }

        /// <summary>
        /// Amount of leanForce applied away from pusher.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float MoveAmount
        {
            get => GetArgument("moveAmount", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("moveAmount", argumentValue);
            }
        }

        /// <summary>
        /// Only move away from pusher when bracing against pusher.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool MoveWhenBracing
        {
            get => GetArgument("moveWhenBracing", false);
            set
            {
                bool argumentValue = value;
                SetArgument("moveWhenBracing", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class BodyFoetalHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the BodyFoetal NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public BodyFoetalHelper(Ped ped) : base(ped, "bodyFoetal")
        {
        }

        /// <summary>
        /// The stiffness of the body determines how fast the character moves into the position, and how well that they hold it.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>9.000</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float Stiffness
        {
            get => GetArgument("stiffness", 9.000f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("stiffness", argumentValue);
            }
        }

        /// <summary>
        /// Sets damping value for the character joints.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.400</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float DampingFactor
        {
            get => GetArgument("dampingFactor", 1.400f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("dampingFactor", argumentValue);
            }
        }

        /// <summary>
        /// A value between 0-1 that controls how asymmetric the results are by varying stiffness across the body.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float Asymmetry
        {
            get => GetArgument("asymmetry", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("asymmetry", argumentValue);
            }
        }

        /// <summary>
        /// Random seed used to generate asymmetry values.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int RandomSeed
        {
            get => GetArgument("randomSeed", 100);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("randomSeed", argumentValue);
            }
        }

        /// <summary>
        /// Amount of random back twist to add.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float BackTwist
        {
            get => GetArgument("backTwist", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("backTwist", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class BodyRollUpHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the BodyRollUp NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public BodyRollUpHelper(Ped ped) : base(ped, "bodyRollUp")
        {
        }

        /// <summary>
        /// Stiffness of whole body.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.000</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float Stiffness
        {
            get => GetArgument("stiffness", 10.000f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("stiffness", argumentValue);
            }
        }

        /// <summary>
        /// The degree to which the character will try to stop a barrel roll with his arms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.300</c>.</para>
        /// <para>Minimum value: <c>-2.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float UseArmToSlowDown
        {
            get => GetArgument("useArmToSlowDown", 1.300f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(-2.0f, value));
                SetArgument("useArmToSlowDown", argumentValue);
            }
        }

        /// <summary>
        /// The likeliness of the character reaching for the ground with its arms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.400</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float ArmReachAmount
        {
            get => GetArgument("armReachAmount", 1.400f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("armReachAmount", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }

        /// <summary>
        /// Used to keep rolling down slope, 1 is full (kicks legs out when pointing upwards).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float LegPush
        {
            get => GetArgument("legPush", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(-1.0f, value));
                SetArgument("legPush", argumentValue);
            }
        }

        /// <summary>
        /// 0 is no leg asymmetry in 'foetal' position. greater than 0 a asymmetricalLegs-rand(30%), added/minus each joint of the legs in radians. Random number changes about once every roll. 0.4 gives a lot of asymmetry.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.000</c>.</para>
        /// <para>Minimum value: <c>-2.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float AsymmetricalLegs
        {
            get => GetArgument("asymmetricalLegs", 0.000f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(-2.0f, value));
                SetArgument("asymmetricalLegs", argumentValue);
            }
        }

        /// <summary>
        /// Time that roll velocity has to be lower than rollVelForSuccess, before success message is sent.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float NoRollTimeBeforeSuccess
        {
            get => GetArgument("noRollTimeBeforeSuccess", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("noRollTimeBeforeSuccess", argumentValue);
            }
        }

        /// <summary>
        /// Lower threshold for roll velocity at which success message can be sent.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float RollVelForSuccess
        {
            get => GetArgument("rollVelForSuccess", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("rollVelForSuccess", argumentValue);
            }
        }

        /// <summary>
        /// Contribution of linear COM velocity to roll Velocity (if 0, roll velocity equal to COM angular velocity).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float RollVelLinearContribution
        {
            get => GetArgument("rollVelLinearContribution", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("rollVelLinearContribution", argumentValue);
            }
        }

        /// <summary>
        /// Scales perceived body velocity. The higher this value gets, the more quickly the velocity measure saturates, resulting in a tighter roll at slower speeds. (NB: Set to 1 to match earlier behavior).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float VelocityScale
        {
            get => GetArgument("velocityScale", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("velocityScale", argumentValue);
            }
        }

        /// <summary>
        /// Offsets perceived body velocity. Increase to create larger "dead zone" around zero velocity where character will be less rolled. (NB: Reset to 0 to match earlier behavior).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float VelocityOffset
        {
            get => GetArgument("velocityOffset", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("velocityOffset", argumentValue);
            }
        }

        /// <summary>
        /// Controls whether or not behavior enforces min/max friction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ApplyMinMaxFriction
        {
            get => GetArgument("applyMinMaxFriction", true);
            set
            {
                bool argumentValue = value;
                SetArgument("applyMinMaxFriction", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class BodyWritheHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the BodyWrithe NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public BodyWritheHelper(Ped ped) : base(ped, "bodyWrithe")
        {
        }

        /// <summary>
        /// Gets or sets armStiffness.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>13.000</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffness
        {
            get => GetArgument("armStiffness", 13.000f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("armStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets backStiffness.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>13.000</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float BackStiffness
        {
            get => GetArgument("backStiffness", 13.000f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("backStiffness", argumentValue);
            }
        }

        /// <summary>
        /// The stiffness of the character will determine how 'determined' a writhe this is - high values will make him thrash about wildly.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>13.000</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float LegStiffness
        {
            get => GetArgument("legStiffness", 13.000f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("legStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping amount, less is underdamped.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.500</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float ArmDamping
        {
            get => GetArgument("armDamping", 0.500f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("armDamping", argumentValue);
            }
        }

        /// <summary>
        /// Damping amount, less is underdamped.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.500</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float BackDamping
        {
            get => GetArgument("backDamping", 0.500f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("backDamping", argumentValue);
            }
        }

        /// <summary>
        /// Damping amount, less is underdamped.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.500</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float LegDamping
        {
            get => GetArgument("legDamping", 0.500f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("legDamping", argumentValue);
            }
        }

        /// <summary>
        /// Controls how fast the writhe is executed, smaller values make faster motions.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float ArmPeriod
        {
            get => GetArgument("armPeriod", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.010f, value));
                SetArgument("armPeriod", argumentValue);
            }
        }

        /// <summary>
        /// Controls how fast the writhe is executed, smaller values make faster motions.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float BackPeriod
        {
            get => GetArgument("backPeriod", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.010f, value));
                SetArgument("backPeriod", argumentValue);
            }
        }

        /// <summary>
        /// Controls how fast the writhe is executed, smaller values make faster motions.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float LegPeriod
        {
            get => GetArgument("legPeriod", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.010f, value));
                SetArgument("legPeriod", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets armAmplitude.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float ArmAmplitude
        {
            get => GetArgument("armAmplitude", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("armAmplitude", argumentValue);
            }
        }

        /// <summary>
        /// Scales the amount of writhe. 0 = no writhe.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float BackAmplitude
        {
            get => GetArgument("backAmplitude", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("backAmplitude", argumentValue);
            }
        }

        /// <summary>
        /// Scales the amount of writhe. 0 = no writhe.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float LegAmplitude
        {
            get => GetArgument("legAmplitude", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("legAmplitude", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets elbowAmplitude.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float ElbowAmplitude
        {
            get => GetArgument("elbowAmplitude", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("elbowAmplitude", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets kneeAmplitude.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float KneeAmplitude
        {
            get => GetArgument("kneeAmplitude", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("kneeAmplitude", argumentValue);
            }
        }

        /// <summary>
        /// Flag to set trying to rollOver.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool RollOverFlag
        {
            get => GetArgument("rollOverFlag", false);
            set
            {
                bool argumentValue = value;
                SetArgument("rollOverFlag", argumentValue);
            }
        }

        /// <summary>
        /// Blend the writhe arms with the current desired arms (0=don't apply any writhe, 1=only writhe).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float BlendArms
        {
            get => GetArgument("blendArms", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("blendArms", argumentValue);
            }
        }

        /// <summary>
        /// Blend the writhe spine and neck with the current desired (0=don't apply any writhe, 1=only writhe).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float BlendBack
        {
            get => GetArgument("blendBack", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("blendBack", argumentValue);
            }
        }

        /// <summary>
        /// Blend the writhe legs with the current desired legs (0=don't apply any writhe, 1=only writhe).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float BlendLegs
        {
            get => GetArgument("blendLegs", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("blendLegs", argumentValue);
            }
        }

        /// <summary>
        /// Use writhe stiffnesses if true. If false don't set any stiffnesses.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ApplyStiffness
        {
            get => GetArgument("applyStiffness", true);
            set
            {
                bool argumentValue = value;
                SetArgument("applyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Extra shoulderBlend. Rolling:one way only, maxRollOverTime, rollOverRadius, doesn't reduce arm stiffness to help rolling. No shoulder twist.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool OnFire
        {
            get => GetArgument("onFire", false);
            set
            {
                bool argumentValue = value;
                SetArgument("onFire", argumentValue);
            }
        }

        /// <summary>
        /// Blend writhe shoulder desired lean1 with this angle in RAD. Note that onFire has to be set to true for this parameter to take any effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>6.283185</c>.</para>
        /// </remarks>
        public float ShoulderLean1
        {
            get => GetArgument("shoulderLean1", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(6.283185f, System.Math.Max(0.00f, value));
                SetArgument("shoulderLean1", argumentValue);
            }
        }

        /// <summary>
        /// Blend writhe shoulder desired lean2 with this angle in RAD. Note that onFire has to be set to true for this parameter to take any effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>6.283185</c>.</para>
        /// </remarks>
        public float ShoulderLean2
        {
            get => GetArgument("shoulderLean2", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(6.283185f, System.Math.Max(0.00f, value));
                SetArgument("shoulderLean2", argumentValue);
            }
        }

        /// <summary>
        /// Shoulder desired lean1 with shoulderLean1 angle blend factor. Set it to 0 to use original shoulder withe desired lean1 angle for shoulders. Note that onFire has to be set to true for this parameter to take any effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Lean1BlendFactor
        {
            get => GetArgument("lean1BlendFactor", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("lean1BlendFactor", argumentValue);
            }
        }

        /// <summary>
        /// Shoulder desired lean2 with shoulderLean2 angle blend factor. Set it to 0 to use original shoulder withe desired lean2 angle for shoulders. Note that onFire has to be set to true for this parameter to take any effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Lean2BlendFactor
        {
            get => GetArgument("lean2BlendFactor", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("lean2BlendFactor", argumentValue);
            }
        }

        /// <summary>
        /// Scale rolling torque that is applied to character spine.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>150.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>300.00</c>.</para>
        /// </remarks>
        public float RollTorqueScale
        {
            get => GetArgument("rollTorqueScale", 150.00f);
            set
            {
                float argumentValue = System.Math.Min(300.00f, System.Math.Max(0.00f, value));
                SetArgument("rollTorqueScale", argumentValue);
            }
        }

        /// <summary>
        /// Rolling torque is ramped down over time. At this time in seconds torque value converges to zero. Use this parameter to restrict time the character is rolling. Note that onFire has to be set to true for this parameter to take any effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>60.00</c>.</para>
        /// </remarks>
        public float MaxRollOverTime
        {
            get => GetArgument("maxRollOverTime", 8.00f);
            set
            {
                float argumentValue = System.Math.Min(60.00f, System.Math.Max(0.00f, value));
                SetArgument("maxRollOverTime", argumentValue);
            }
        }

        /// <summary>
        /// Rolling torque is ramped down with distance measured from position where character hit the ground and started rolling. At this distance in meters torque value converges to zero. Use this parameter to restrict distance the character travels due to rolling. Note that onFire has to be set to true for this parameter to take any effect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float RollOverRadius
        {
            get => GetArgument("rollOverRadius", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("rollOverRadius", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class BraceForImpactHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the BraceForImpact NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public BraceForImpactHelper(Ped ped) : base(ped, "braceForImpact")
        {
        }

        /// <summary>
        /// Distance from object at which to raise hands to brace 0.5 good if newBrace=true - otherwise 0.65.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float BraceDistance
        {
            get => GetArgument("braceDistance", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("braceDistance", argumentValue);
            }
        }

        /// <summary>
        /// Time epected to get arms up from idle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.450</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TargetPredictionTime
        {
            get => GetArgument("targetPredictionTime", 0.450f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("targetPredictionTime", argumentValue);
            }
        }

        /// <summary>
        /// Larger values and he absorbs the impact more.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.150</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ReachAbsorbtionTime
        {
            get => GetArgument("reachAbsorbtionTime", 0.150f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("reachAbsorbtionTime", argumentValue);
            }
        }

        /// <summary>
        /// LevelIndex of object to brace.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int InstanceIndex
        {
            get => GetArgument("instanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("instanceIndex", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of character. catch_fall stiffness scales with this too, with its defaults at this values default.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float BodyStiffness
        {
            get => GetArgument("bodyStiffness", 12.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(6.00f, value));
                SetArgument("bodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Once a constraint is made, keep reaching with whatever hand is allowed.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool GrabDontLetGo
        {
            get => GetArgument("grabDontLetGo", false);
            set
            {
                bool argumentValue = value;
                SetArgument("grabDontLetGo", argumentValue);
            }
        }

        /// <summary>
        /// Strength in hands for grabbing (kg m/s), -1 to ignore/disable.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>40.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1000.00</c>.</para>
        /// </remarks>
        public float GrabStrength
        {
            get => GetArgument("grabStrength", 40.00f);
            set
            {
                float argumentValue = System.Math.Min(1000.00f, System.Math.Max(-1.00f, value));
                SetArgument("grabStrength", argumentValue);
            }
        }

        /// <summary>
        /// Relative distance at which the grab starts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>4.00</c>.</para>
        /// </remarks>
        public float GrabDistance
        {
            get => GetArgument("grabDistance", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(4.00f, System.Math.Max(0.00f, value));
                SetArgument("grabDistance", argumentValue);
            }
        }

        /// <summary>
        /// Angle from front at which the grab activates. If the point is outside this angle from front will not try to grab.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.160</c>.</para>
        /// </remarks>
        public float GrabReachAngle
        {
            get => GetArgument("grabReachAngle", 1.50f);
            set
            {
                float argumentValue = System.Math.Min(3.160f, System.Math.Max(0.00f, value));
                SetArgument("grabReachAngle", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time, in seconds, before grab automatically bails.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float GrabHoldTimer
        {
            get => GetArgument("grabHoldTimer", 2.50f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("grabHoldTimer", argumentValue);
            }
        }

        /// <summary>
        /// Don't try to grab a car moving above this speed mmmmtodo make this the relative velocity of car to character?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>95.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1000.00</c>.</para>
        /// </remarks>
        public float MaxGrabCarVelocity
        {
            get => GetArgument("maxGrabCarVelocity", 95.00f);
            set
            {
                float argumentValue = System.Math.Min(1000.00f, System.Math.Max(0.00f, value));
                SetArgument("maxGrabCarVelocity", argumentValue);
            }
        }

        /// <summary>
        /// Balancer leg stiffness mmmmtodo remove this parameter and use configureBalance?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float LegStiffness
        {
            get => GetArgument("legStiffness", 12.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(6.00f, value));
                SetArgument("legStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Time before arm brace kicks in when hit from behind.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float TimeToBackwardsBrace
        {
            get => GetArgument("timeToBackwardsBrace", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("timeToBackwardsBrace", argumentValue);
            }
        }

        /// <summary>
        /// Position to look at, e.g. the driver.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Look
        {
            get => GetArgument("look", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("look", argumentValue);
            }
        }

        /// <summary>
        /// Location of the front part of the object to brace against. This should be the centre of where his hands should meet the object.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos
        {
            get => GetArgument("pos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos", argumentValue);
            }
        }

        /// <summary>
        /// Minimum bracing time so the character doesn't look twitchy.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float MinBraceTime
        {
            get => GetArgument("minBraceTime", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("minBraceTime", argumentValue);
            }
        }

        /// <summary>
        /// If bracing with 2 hands delay one hand by at least this amount of time to introduce some asymmetry.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float HandsDelayMin
        {
            get => GetArgument("handsDelayMin", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("handsDelayMin", argumentValue);
            }
        }

        /// <summary>
        /// If bracing with 2 hands delay one hand by at most this amount of time to introduce some asymmetry.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float HandsDelayMax
        {
            get => GetArgument("handsDelayMax", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("handsDelayMax", argumentValue);
            }
        }

        /// <summary>
        /// Move away from the car (if in reaching zone).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool MoveAway
        {
            get => GetArgument("moveAway", false);
            set
            {
                bool argumentValue = value;
                SetArgument("moveAway", argumentValue);
            }
        }

        /// <summary>
        /// ForceLean away amount (-ve is lean towards).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float MoveAwayAmount
        {
            get => GetArgument("moveAwayAmount", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("moveAwayAmount", argumentValue);
            }
        }

        /// <summary>
        /// Lean away amount (-ve is lean towards).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.050</c>.</para>
        /// <para>Minimum value: <c>-0.5</c>.</para>
        /// <para>Maximum value: <c>0.5</c>.</para>
        /// </remarks>
        public float MoveAwayLean
        {
            get => GetArgument("moveAwayLean", 0.050f);
            set
            {
                float argumentValue = System.Math.Min(0.5f, System.Math.Max(-0.5f, value));
                SetArgument("moveAwayLean", argumentValue);
            }
        }

        /// <summary>
        /// Amount of sideways movement if at the front or back of the car to add to the move away from car.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float MoveSideways
        {
            get => GetArgument("moveSideways", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("moveSideways", argumentValue);
            }
        }

        /// <summary>
        /// Use bodyBalance arms for the default (non bracing) behavior if bodyBalance is active.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BbArms
        {
            get => GetArgument("bbArms", false);
            set
            {
                bool argumentValue = value;
                SetArgument("bbArms", argumentValue);
            }
        }

        /// <summary>
        /// Use the new brace prediction code.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool NewBrace
        {
            get => GetArgument("newBrace", true);
            set
            {
                bool argumentValue = value;
                SetArgument("newBrace", argumentValue);
            }
        }

        /// <summary>
        /// If true then if a shin or thigh is in contact with the car then brace. NB: newBrace must be true. For those situations where the car has pushed the ped backwards (at the same speed as the car) before the behavior has been started and so doesn't predict an impact.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BraceOnImpact
        {
            get => GetArgument("braceOnImpact", false);
            set
            {
                bool argumentValue = value;
                SetArgument("braceOnImpact", argumentValue);
            }
        }

        /// <summary>
        /// When rollDownStairs is running use roll2Velocity to control the helper torques (this only attempts to roll to the chaarcter's velocity not some default linear velocity mag.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Roll2Velocity
        {
            get => GetArgument("roll2Velocity", false);
            set
            {
                bool argumentValue = value;
                SetArgument("roll2Velocity", argumentValue);
            }
        }

        /// <summary>
        /// 0 = original/roll off/stay on car: Roll with character velocity, 1 = //Gentle: roll off/stay on car = use relative velocity of character to car to roll against, 2 = //roll over car: Roll against character velocity. i.e. roll against any velocity picked up by hitting car, 3 = //Gentle: roll over car: use relative velocity of character to car to roll with.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public int RollType
        {
            get => GetArgument("rollType", 3);
            set
            {
                int argumentValue = System.Math.Min(3, System.Math.Max(0, value));
                SetArgument("rollType", argumentValue);
            }
        }

        /// <summary>
        /// Exaggerate impacts using snap.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapImpacts
        {
            get => GetArgument("snapImpacts", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapImpacts", argumentValue);
            }
        }

        /// <summary>
        /// Exaggeration amount of the initial impact (legs). +ve fold with car impact (as if pushed at hips in the car velocity direction). -ve fold away from car impact.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>7.00</c>.</para>
        /// <para>Minimum value: <c>-20.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float SnapImpact
        {
            get => GetArgument("snapImpact", 7.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(-20.00f, value));
                SetArgument("snapImpact", argumentValue);
            }
        }

        /// <summary>
        /// Exaggeration amount of the secondary (torso) impact with bonnet. +ve fold with car impact (as if pushed at hips by the impact normal). -ve fold away from car impact.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-7.00</c>.</para>
        /// <para>Minimum value: <c>-20.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float SnapBonnet
        {
            get => GetArgument("snapBonnet", -7.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(-20.00f, value));
                SetArgument("snapBonnet", argumentValue);
            }
        }

        /// <summary>
        /// Exaggeration amount of the impact with the floor after falling off of car +ve fold with floor impact (as if pushed at hips in the impact normal direction). -ve fold away from car impact.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>7.00</c>.</para>
        /// <para>Minimum value: <c>-20.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float SnapFloor
        {
            get => GetArgument("snapFloor", 7.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(-20.00f, value));
                SetArgument("snapFloor", argumentValue);
            }
        }

        /// <summary>
        /// Damp out excessive spin and upward velocity when on car.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DampVel
        {
            get => GetArgument("dampVel", false);
            set
            {
                bool argumentValue = value;
                SetArgument("dampVel", argumentValue);
            }
        }

        /// <summary>
        /// Amount to damp spinning by (cartwheeling and somersaulting).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>40.00</c>.</para>
        /// </remarks>
        public float DampSpin
        {
            get => GetArgument("dampSpin", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(40.00f, System.Math.Max(0.00f, value));
                SetArgument("dampSpin", argumentValue);
            }
        }

        /// <summary>
        /// Amount to damp upward velocity by to limit the amount of air above the car the character can get.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>40.00</c>.</para>
        /// </remarks>
        public float DampUpVel
        {
            get => GetArgument("dampUpVel", 10.00f);
            set
            {
                float argumentValue = System.Math.Min(40.00f, System.Math.Max(0.00f, value));
                SetArgument("dampUpVel", argumentValue);
            }
        }

        /// <summary>
        /// Angular velocity above which we start damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float DampSpinThresh
        {
            get => GetArgument("dampSpinThresh", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("dampSpinThresh", argumentValue);
            }
        }

        /// <summary>
        /// Upward velocity above which we start damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float DampUpVelThresh
        {
            get => GetArgument("dampUpVelThresh", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("dampUpVelThresh", argumentValue);
            }
        }

        /// <summary>
        /// Enhance a glancing spin with the side of the car by modulating body friction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool GsHelp
        {
            get => GetArgument("gsHelp", false);
            set
            {
                bool argumentValue = value;
                SetArgument("gsHelp", argumentValue);
            }
        }

        /// <summary>
        /// ID for glancing spin. min depth to be considered from either end (front/rear) of a car (-ve is inside the car area).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.10</c>.</para>
        /// <para>Minimum value: <c>-10.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float GsEndMin
        {
            get => GetArgument("gsEndMin", -0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-10.00f, value));
                SetArgument("gsEndMin", argumentValue);
            }
        }

        /// <summary>
        /// ID for glancing spin. min depth to be considered on the side of a car (-ve is inside the car area).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.20</c>.</para>
        /// <para>Minimum value: <c>-10.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float GsSideMin
        {
            get => GetArgument("gsSideMin", -0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-10.00f, value));
                SetArgument("gsSideMin", argumentValue);
            }
        }

        /// <summary>
        /// ID for glancing spin. max depth to be considered on the side of a car (+ve is outside the car area).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>-10.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float GsSideMax
        {
            get => GetArgument("gsSideMax", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-10.00f, value));
                SetArgument("gsSideMax", argumentValue);
            }
        }

        /// <summary>
        /// ID for glancing spin. Character has to be more upright than this value for it to be considered on the side of a car. Fully upright = 1, upsideDown = -1. Max Angle from upright is acos(gsUpness).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.90</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float GsUpness
        {
            get => GetArgument("gsUpness", 0.90f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("gsUpness", argumentValue);
            }
        }

        /// <summary>
        /// ID for glancing spin. Minimum car velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float GsCarVelMin
        {
            get => GetArgument("gsCarVelMin", 3.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("gsCarVelMin", argumentValue);
            }
        }

        /// <summary>
        /// Apply gsFricScale1 to the foot if colliding with car. (Otherwise foot friction - with the ground - is determined by gsFricScale2 if it is in gsFricMask2).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool GsScale1Foot
        {
            get => GetArgument("gsScale1Foot", true);
            set
            {
                bool argumentValue = value;
                SetArgument("gsScale1Foot", argumentValue);
            }
        }

        /// <summary>
        /// Glancing spin help. Friction scale applied when to the side of the car. e.g. make the character spin more by upping the friction against the car.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float GsFricScale1
        {
            get => GetArgument("gsFricScale1", 8.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("gsFricScale1", argumentValue);
            }
        }

        /// <summary>
        /// Glancing spin help. Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see notes for explanation). Note gsFricMask1 and gsFricMask2 are made independent by the code so you can have fb for gsFricMask1 but gsFricScale1 will not be applied to any bodyParts in gsFricMask2.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string GsFricMask1
        {
            get => GetArgument("gsFricMask1", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("gsFricMask1", argumentValue);
            }
        }

        /// <summary>
        /// Glancing spin help. Friction scale applied when to the side of the car. e.g. make the character spin more by lowering the feet friction. You could also lower the wrist friction here to stop the car pulling along the hands i.e. gsFricMask2 = la|uw.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float GsFricScale2
        {
            get => GetArgument("gsFricScale2", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("gsFricScale2", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see notes for explanation). Note gsFricMask1 and gsFricMask2 are made independent by the code so you can have fb for gsFricMask1 but gsFricScale1 will not be applied to any bodyParts in gsFricMask2.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>la</c>.</para>
        /// </remarks>
        public string GsFricMask2
        {
            get => GetArgument("gsFricMask2", "la");
            set
            {
                string argumentValue = value;
                SetArgument("gsFricMask2", argumentValue);
            }
        }
    }

    /// <summary>
    /// Buoyancy: Simple buoyancy model. No character movement just fluid forces/torques added to parts.
    /// </summary>
    public sealed class BuoyancyHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the Buoyancy NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public BuoyancyHelper(Ped ped) : base(ped, "buoyancy")
        {
        }

        /// <summary>
        /// Arbitrary point on surface of water.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 SurfacePoint
        {
            get => GetArgument("surfacePoint", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("surfacePoint", argumentValue);
            }
        }

        /// <summary>
        /// Normal to surface of water.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public Vector3 SurfaceNormal
        {
            get => GetArgument("surfaceNormal", new Vector3(0.0f, 0.0f, 1.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("surfaceNormal", argumentValue);
            }
        }

        /// <summary>
        /// Buoyancy multiplier.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public float Buoyancy
        {
            get => GetArgument("buoyancy", 1.0f);
            set
            {
                float argumentValue = System.Math.Max(0.0f, value);
                SetArgument("buoyancy", argumentValue);
            }
        }

        /// <summary>
        /// Buoyancy mulplier for spine2/3. Helps character float upright.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public float ChestBuoyancy
        {
            get => GetArgument("chestBuoyancy", 8.0f);
            set
            {
                float argumentValue = System.Math.Max(0.0f, value);
                SetArgument("chestBuoyancy", argumentValue);
            }
        }

        /// <summary>
        /// Damping for submerged parts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>40.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public float Damping
        {
            get => GetArgument("damping", 40.0f);
            set
            {
                float argumentValue = System.Math.Max(0.0f, value);
                SetArgument("damping", argumentValue);
            }
        }

        /// <summary>
        /// Use righting torque to being character face-up in water?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Righting
        {
            get => GetArgument("righting", true);
            set
            {
                bool argumentValue = value;
                SetArgument("righting", argumentValue);
            }
        }

        /// <summary>
        /// Strength of righting torque.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>25.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public float RightingStrength
        {
            get => GetArgument("rightingStrength", 25.0f);
            set
            {
                float argumentValue = System.Math.Max(0.0f, value);
                SetArgument("rightingStrength", argumentValue);
            }
        }

        /// <summary>
        /// How long to wait after chest hits water to begin righting torque.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public float RightingTime
        {
            get => GetArgument("rightingTime", 1.0f);
            set
            {
                float argumentValue = System.Math.Max(0.0f, value);
                SetArgument("rightingTime", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class CatchFallHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the CatchFall NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public CatchFallHelper(Ped ped) : base(ped, "catchFall")
        {
        }

        /// <summary>
        /// Stiffness of torso.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>9.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float TorsoStiffness
        {
            get => GetArgument("torsoStiffness", 9.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("torsoStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of legs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>6.0</c>.</para>
        /// <para>Minimum value: <c>4.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float LegsStiffness
        {
            get => GetArgument("legsStiffness", 6.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(4.0f, value));
                SetArgument("legsStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of arms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>15.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmsStiffness
        {
            get => GetArgument("armsStiffness", 15.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("armsStiffness", argumentValue);
            }
        }

        /// <summary>
        /// 0 will prop arms up near his shoulders. -0.3 will place hands nearer his behind.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.25</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>0.0</c>.</para>
        /// </remarks>
        public float BackwardsMinArmOffset
        {
            get => GetArgument("backwardsMinArmOffset", -0.25f);
            set
            {
                float argumentValue = System.Math.Min(0.0f, System.Math.Max(-1.0f, value));
                SetArgument("backwardsMinArmOffset", argumentValue);
            }
        }

        /// <summary>
        /// 0 will point arms down with angled body, 0.45 will point arms forward a bit to catch nearer the head.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.35</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ForwardMaxArmOffset
        {
            get => GetArgument("forwardMaxArmOffset", 0.35f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("forwardMaxArmOffset", argumentValue);
            }
        }

        /// <summary>
        /// Tries to reduce the spin around the Z axis. Scale 0 - 1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ZAxisSpinReduction
        {
            get => GetArgument("zAxisSpinReduction", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("zAxisSpinReduction", argumentValue);
            }
        }

        /// <summary>
        /// Scale extra-sit value 0..1. Setting to 0 helps with arched-back issues. Set to 1 for a more alive-looking finish.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ExtraSit
        {
            get => GetArgument("extraSit", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("extraSit", argumentValue);
            }
        }

        /// <summary>
        /// Toggle to use the head look in this behavior.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseHeadLook
        {
            get => GetArgument("useHeadLook", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useHeadLook", argumentValue);
            }
        }

        /// <summary>
        /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value (see Active Pose notes for possible values).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string Mask
        {
            get => GetArgument("mask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("mask", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ElectrocuteHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the Electrocute NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ElectrocuteHelper(Ped ped) : base(ped, "electrocute")
        {
        }

        /// <summary>
        /// The magnitude of the reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float StunMag
        {
            get => GetArgument("stunMag", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("stunMag", argumentValue);
            }
        }

        /// <summary>
        /// InitialMult*stunMag = The magnitude of the 1st snap reaction (other mults are applied after this).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float InitialMult
        {
            get => GetArgument("initialMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("initialMult", argumentValue);
            }
        }

        /// <summary>
        /// LargeMult*stunMag = The magnitude of a random large snap reaction (other mults are applied after this).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float LargeMult
        {
            get => GetArgument("largeMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.00f, value));
                SetArgument("largeMult", argumentValue);
            }
        }

        /// <summary>
        /// Min time to next large random snap (about 14 snaps with stunInterval = 0.07s).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>200.00</c>.</para>
        /// </remarks>
        public float LargeMinTime
        {
            get => GetArgument("largeMinTime", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(200.00f, System.Math.Max(0.00f, value));
                SetArgument("largeMinTime", argumentValue);
            }
        }

        /// <summary>
        /// Max time to next large random snap (about 28 snaps with stunInterval = 0.07s).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>200.00</c>.</para>
        /// </remarks>
        public float LargeMaxTime
        {
            get => GetArgument("largeMaxTime", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(200.00f, System.Math.Max(0.00f, value));
                SetArgument("largeMaxTime", argumentValue);
            }
        }

        /// <summary>
        /// MovingMult*stunMag = The magnitude of the reaction if moving(comVelMag) faster than movingThresh.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float MovingMult
        {
            get => GetArgument("movingMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("movingMult", argumentValue);
            }
        }

        /// <summary>
        /// BalancingMult*stunMag = The magnitude of the reaction if balancing = (not lying on the floor/ not upper body not collided) and not airborne.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float BalancingMult
        {
            get => GetArgument("balancingMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("balancingMult", argumentValue);
            }
        }

        /// <summary>
        /// AirborneMult*stunMag = The magnitude of the reaction if airborne.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float AirborneMult
        {
            get => GetArgument("airborneMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("airborneMult", argumentValue);
            }
        }

        /// <summary>
        /// If moving(comVelMag) faster than movingThresh then mvingMult applied to stunMag.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.00</c>.</para>
        /// </remarks>
        public float MovingThresh
        {
            get => GetArgument("movingThresh", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(20.00f, System.Math.Max(0.00f, value));
                SetArgument("movingThresh", argumentValue);
            }
        }

        /// <summary>
        /// Direction flips every stunInterval.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.070</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float StunInterval
        {
            get => GetArgument("stunInterval", 0.070f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("stunInterval", argumentValue);
            }
        }

        /// <summary>
        /// The character vibrates in a prescribed way - Higher the value the more random this direction is.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float DirectionRandomness
        {
            get => GetArgument("directionRandomness", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("directionRandomness", argumentValue);
            }
        }

        /// <summary>
        /// Vibrate the leftArm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool LeftArm
        {
            get => GetArgument("leftArm", true);
            set
            {
                bool argumentValue = value;
                SetArgument("leftArm", argumentValue);
            }
        }

        /// <summary>
        /// Vibrate the rightArm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool RightArm
        {
            get => GetArgument("rightArm", true);
            set
            {
                bool argumentValue = value;
                SetArgument("rightArm", argumentValue);
            }
        }

        /// <summary>
        /// Vibrate the leftLeg.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool LeftLeg
        {
            get => GetArgument("leftLeg", true);
            set
            {
                bool argumentValue = value;
                SetArgument("leftLeg", argumentValue);
            }
        }

        /// <summary>
        /// Vibrate the rightLeg.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool RightLeg
        {
            get => GetArgument("rightLeg", true);
            set
            {
                bool argumentValue = value;
                SetArgument("rightLeg", argumentValue);
            }
        }

        /// <summary>
        /// Vibrate the spine.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Spine
        {
            get => GetArgument("spine", true);
            set
            {
                bool argumentValue = value;
                SetArgument("spine", argumentValue);
            }
        }

        /// <summary>
        /// Vibrate the neck.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Neck
        {
            get => GetArgument("neck", true);
            set
            {
                bool argumentValue = value;
                SetArgument("neck", argumentValue);
            }
        }

        /// <summary>
        /// Legs are either in phase with each other or not.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool PhasedLegs
        {
            get => GetArgument("phasedLegs", true);
            set
            {
                bool argumentValue = value;
                SetArgument("phasedLegs", argumentValue);
            }
        }

        /// <summary>
        /// Let electrocute apply a (higher generally) stiffness to the character whilst being vibrated.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ApplyStiffness
        {
            get => GetArgument("applyStiffness", true);
            set
            {
                bool argumentValue = value;
                SetArgument("applyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Use torques to make vibration otherwise use a change in the parts angular velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseTorques
        {
            get => GetArgument("useTorques", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useTorques", argumentValue);
            }
        }

        /// <summary>
        /// Type of hip reaction 0=none, 1=side2side 2=steplike.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int HipType
        {
            get => GetArgument("hipType", 2);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("hipType", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class FallOverWallHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the FallOverWall NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public FallOverWallHelper(Ped ped) : base(ped, "fallOverWall")
        {
        }

        /// <summary>
        /// Stiffness of the body, roll up stiffness scales with this and defaults at this default value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>9.000</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float BodyStiffness
        {
            get => GetArgument("bodyStiffness", 9.000f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(6.00f, value));
                SetArgument("bodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping in the effectors.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.500</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float Damping
        {
            get => GetArgument("damping", 0.500f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("damping", argumentValue);
            }
        }

        /// <summary>
        /// Magnitude of the falloverWall helper force.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float MagOfForce
        {
            get => GetArgument("magOfForce", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("magOfForce", argumentValue);
            }
        }

        /// <summary>
        /// The maximum distance away from the pelvis that hit points will be registered.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float MaxDistanceFromPelToHitPoint
        {
            get => GetArgument("maxDistanceFromPelToHitPoint", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.010f, value));
                SetArgument("maxDistanceFromPelToHitPoint", argumentValue);
            }
        }

        /// <summary>
        /// Maximum distance between hitPoint and body part at which forces are applied to part.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.80</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float MaxForceDist
        {
            get => GetArgument("maxForceDist", 0.80f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.010f, value));
                SetArgument("maxForceDist", argumentValue);
            }
        }

        /// <summary>
        /// Specifies extent of area in front of the wall in which balancer won't try to take another step.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float StepExclusionZone
        {
            get => GetArgument("stepExclusionZone", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.010f, value));
                SetArgument("stepExclusionZone", argumentValue);
            }
        }

        /// <summary>
        /// Minimum height of pelvis above feet at which fallOverWall is attempted.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float MinLegHeight
        {
            get => GetArgument("minLegHeight", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.10f, value));
                SetArgument("minLegHeight", argumentValue);
            }
        }

        /// <summary>
        /// Amount of twist to apply to the spine as the character tries to fling himself over the wall, provides more of a believable roll but increases the amount of lateral space the character needs to successfully flip.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.540</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float BodyTwist
        {
            get => GetArgument("bodyTwist", 0.540f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("bodyTwist", argumentValue);
            }
        }

        /// <summary>
        /// Max angle the character can twist before twsit helper torques are turned off.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.141593</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float MaxTwist
        {
            get => GetArgument("maxTwist", 3.141593f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("maxTwist", argumentValue);
            }
        }

        /// <summary>
        /// One end of the wall to try to fall over.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 FallOverWallEndA
        {
            get => GetArgument("fallOverWallEndA", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("fallOverWallEndA", argumentValue);
            }
        }

        /// <summary>
        /// One end of the wall over which we are trying to fall over.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 FallOverWallEndB
        {
            get => GetArgument("fallOverWallEndB", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("fallOverWallEndB", argumentValue);
            }
        }

        /// <summary>
        /// The angle abort threshold.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.20</c>.</para>
        /// </remarks>
        public float ForceAngleAbort
        {
            get => GetArgument("forceAngleAbort", -0.20f);
            set
            {
                float argumentValue = value;
                SetArgument("forceAngleAbort", argumentValue);
            }
        }

        /// <summary>
        /// The force time out.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// </remarks>
        public float ForceTimeOut
        {
            get => GetArgument("forceTimeOut", 2.00f);
            set
            {
                float argumentValue = value;
                SetArgument("forceTimeOut", argumentValue);
            }
        }

        /// <summary>
        /// Lift the arms up if true. Do nothing with the arms if false (eg when using catchfall arms or brace etc).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool MoveArms
        {
            get => GetArgument("moveArms", true);
            set
            {
                bool argumentValue = value;
                SetArgument("moveArms", argumentValue);
            }
        }

        /// <summary>
        /// Move the legs if true. Do nothing with the legs if false (eg when using dynamicBalancer etc).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool MoveLegs
        {
            get => GetArgument("moveLegs", true);
            set
            {
                bool argumentValue = value;
                SetArgument("moveLegs", argumentValue);
            }
        }

        /// <summary>
        /// Bend spine to help falloverwall if true. Do nothing with the spine if false.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool BendSpine
        {
            get => GetArgument("bendSpine", true);
            set
            {
                bool argumentValue = value;
                SetArgument("bendSpine", argumentValue);
            }
        }

        /// <summary>
        /// Maximum angle in degrees (between the direction of the velocity of the COM and the wall normal) to start to apply forces and torques to fall over the wall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>180.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>180.00</c>.</para>
        /// </remarks>
        public float AngleDirWithWallNormal
        {
            get => GetArgument("angleDirWithWallNormal", 180.00f);
            set
            {
                float argumentValue = System.Math.Min(180.00f, System.Math.Max(0.00f, value));
                SetArgument("angleDirWithWallNormal", argumentValue);
            }
        }

        /// <summary>
        /// Maximum angle in degrees (between the vertical vector and a vector from pelvis to lower neck) to start to apply forces and torques to fall over the wall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>180.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>180.00</c>.</para>
        /// </remarks>
        public float LeaningAngleThreshold
        {
            get => GetArgument("leaningAngleThreshold", 180.00f);
            set
            {
                float argumentValue = System.Math.Min(180.00f, System.Math.Max(0.00f, value));
                SetArgument("leaningAngleThreshold", argumentValue);
            }
        }

        /// <summary>
        /// If the angular velocity is higher than maxAngVel, the torques and forces are not applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>30.00</c>.</para>
        /// </remarks>
        public float MaxAngVel
        {
            get => GetArgument("maxAngVel", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(30.00f, System.Math.Max(-1.00f, value));
                SetArgument("maxAngVel", argumentValue);
            }
        }

        /// <summary>
        /// Will reduce the magnitude of the forces applied to the character to help him to fall over wall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AdaptForcesToLowWall
        {
            get => GetArgument("adaptForcesToLowWall", false);
            set
            {
                bool argumentValue = value;
                SetArgument("adaptForcesToLowWall", argumentValue);
            }
        }

        /// <summary>
        /// Maximum height (from the lowest foot) to start to apply forces and torques to fall over the wall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float MaxWallHeight
        {
            get => GetArgument("maxWallHeight", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(-1.00f, value));
                SetArgument("maxWallHeight", argumentValue);
            }
        }

        /// <summary>
        /// Minimum distance between the pelvis and the wall to send the success message. If negative doesn't take this parameter into account when sending feedback.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float DistanceToSendSuccessMessage
        {
            get => GetArgument("distanceToSendSuccessMessage", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(-1.00f, value));
                SetArgument("distanceToSendSuccessMessage", argumentValue);
            }
        }

        /// <summary>
        /// Value of the angular velocity about the wallEgde above which the character is considered as rolling backwards i.e. goes in to fow_RollingBack state.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float RollingBackThr
        {
            get => GetArgument("rollingBackThr", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("rollingBackThr", argumentValue);
            }
        }

        /// <summary>
        /// On impact with the wall if the rollingPotential(calculated from the characters linear velocity w.r.t the wall) is greater than this value the character will try to go over the wall otherwise it won't try (fow_Aborted).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float RollingPotential
        {
            get => GetArgument("rollingPotential", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-1.00f, value));
                SetArgument("rollingPotential", argumentValue);
            }
        }

        /// <summary>
        /// Try to reach the wallEdge. To configure the IK : use limitAngleBack, limitAngleFront and limitAngleTotallyBack.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseArmIK
        {
            get => GetArgument("useArmIK", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useArmIK", argumentValue);
            }
        }

        /// <summary>
        /// Distance from predicted hitpoint where each hands will try to reach the wall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ReachDistanceFromHitPoint
        {
            get => GetArgument("reachDistanceFromHitPoint", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("reachDistanceFromHitPoint", argumentValue);
            }
        }

        /// <summary>
        /// Minimal distance from predicted hitpoint where each hands will try to reach the wall. Used if the hand target is outside the wall Edge.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float MinReachDistanceFromHitPoint
        {
            get => GetArgument("minReachDistanceFromHitPoint", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("minReachDistanceFromHitPoint", argumentValue);
            }
        }

        /// <summary>
        /// Max angle in degrees (between 1.the vector between two hips and 2. wallEdge) to try to reach the wall just behind his pelvis with his arms when the character is back to the wall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>15.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>180.00</c>.</para>
        /// </remarks>
        public float AngleTotallyBack
        {
            get => GetArgument("angleTotallyBack", 15.00f);
            set
            {
                float argumentValue = System.Math.Min(180.00f, System.Math.Max(0.00f, value));
                SetArgument("angleTotallyBack", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class GrabHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the Grab NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public GrabHelper(Ped ped) : base(ped, "grab")
        {
        }

        /// <summary>
        /// Flag to toggle use of left hand.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseLeft
        {
            get => GetArgument("useLeft", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useLeft", argumentValue);
            }
        }

        /// <summary>
        /// Flag to toggle the use of the Right hand.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseRight
        {
            get => GetArgument("useRight", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useRight", argumentValue);
            }
        }

        /// <summary>
        /// If hasn't grabbed when weapon carrying hand is close to target, grab anyway.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DropWeaponIfNecessary
        {
            get => GetArgument("dropWeaponIfNecessary", false);
            set
            {
                bool argumentValue = value;
                SetArgument("dropWeaponIfNecessary", argumentValue);
            }
        }

        /// <summary>
        /// Distance below which a weapon carrying hand will request weapon to be dropped.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float DropWeaponDistance
        {
            get => GetArgument("dropWeaponDistance", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("dropWeaponDistance", argumentValue);
            }
        }

        /// <summary>
        /// Strength in hands for grabbing (kg m/s), -1 to ignore/disable.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>10000.0</c>.</para>
        /// </remarks>
        public float GrabStrength
        {
            get => GetArgument("grabStrength", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(10000.0f, System.Math.Max(-1.0f, value));
                SetArgument("grabStrength", argumentValue);
            }
        }

        /// <summary>
        /// Strength of cheat force on hands to pull towards target and stick to target ("cleverHandIK" strength).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float StickyHands
        {
            get => GetArgument("stickyHands", 4.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("stickyHands", argumentValue);
            }
        }

        /// <summary>
        /// 0=don't turn, 1=turnToTarget, 2=turnAwayFromTarget.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public TurnType TurnToTarget
        {
            get => (TurnType)GetArgument("turnToTarget", (int)(TurnType)1);
            set
            {
                TurnType argumentValue = value;
                SetArgument("turnToTarget", (int)argumentValue);
            }
        }

        /// <summary>
        /// Amount of time, in seconds, before grab automatically bails.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1000.0</c>.</para>
        /// </remarks>
        public float GrabHoldMaxTimer
        {
            get => GetArgument("grabHoldMaxTimer", 100.0f);
            set
            {
                float argumentValue = System.Math.Min(1000.0f, System.Math.Max(0.0f, value));
                SetArgument("grabHoldMaxTimer", argumentValue);
            }
        }

        /// <summary>
        /// Time to reach the full pullup strength.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float PullUpTime
        {
            get => GetArgument("pullUpTime", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("pullUpTime", argumentValue);
            }
        }

        /// <summary>
        /// Strength to pull up with the right arm. 0 = no pull up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float PullUpStrengthRight
        {
            get => GetArgument("pullUpStrengthRight", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("pullUpStrengthRight", argumentValue);
            }
        }

        /// <summary>
        /// Strength to pull up with the left arm. 0 = no pull up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float PullUpStrengthLeft
        {
            get => GetArgument("pullUpStrengthLeft", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("pullUpStrengthLeft", argumentValue);
            }
        }

        /// <summary>
        /// Grab pos1, right hand if not using line or surface grab.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos1
        {
            get => GetArgument("pos1", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos1", argumentValue);
            }
        }

        /// <summary>
        /// Grab pos2, left hand if not using line or surface grab.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos2
        {
            get => GetArgument("pos2", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos2", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets pos3.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos3
        {
            get => GetArgument("pos3", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos3", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets pos4.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos4
        {
            get => GetArgument("pos4", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos4", argumentValue);
            }
        }

        /// <summary>
        /// Normal for the right grab point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public Vector3 NormalR
        {
            get => GetArgument("normalR", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-1.0f, -1.0f, -1.0f), new Vector3(1.0f, 1.0f, 1.0f));
                SetArgument("normalR", argumentValue);
            }
        }

        /// <summary>
        /// Normal for the left grab point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public Vector3 NormalL
        {
            get => GetArgument("normalL", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-1.0f, -1.0f, -1.0f), new Vector3(1.0f, 1.0f, 1.0f));
                SetArgument("normalL", argumentValue);
            }
        }

        /// <summary>
        /// Normal for the 2nd right grab point (if pointsX4grab=true).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public Vector3 NormalR2
        {
            get => GetArgument("normalR2", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-1.0f, -1.0f, -1.0f), new Vector3(1.0f, 1.0f, 1.0f));
                SetArgument("normalR2", argumentValue);
            }
        }

        /// <summary>
        /// Normal for the 3rd left grab point (if pointsX4grab=true).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public Vector3 NormalL2
        {
            get => GetArgument("normalL2", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-1.0f, -1.0f, -1.0f), new Vector3(1.0f, 1.0f, 1.0f));
                SetArgument("normalL2", argumentValue);
            }
        }

        /// <summary>
        /// Hand collisions on when grabbing (false turns off hand collisions making grab more stable esp. to grab points slightly inside geometry).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool HandsCollide
        {
            get => GetArgument("handsCollide", false);
            set
            {
                bool argumentValue = value;
                SetArgument("handsCollide", argumentValue);
            }
        }

        /// <summary>
        /// Flag to toggle between grabbing and bracing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool JustBrace
        {
            get => GetArgument("justBrace", false);
            set
            {
                bool argumentValue = value;
                SetArgument("justBrace", argumentValue);
            }
        }

        /// <summary>
        /// Use the line grab, Grab along the line (x-x2).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseLineGrab
        {
            get => GetArgument("useLineGrab", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useLineGrab", argumentValue);
            }
        }

        /// <summary>
        /// Use 2 point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool PointsX4grab
        {
            get => GetArgument("pointsX4grab", false);
            set
            {
                bool argumentValue = value;
                SetArgument("pointsX4grab", argumentValue);
            }
        }

        /// <summary>
        /// Use 2 point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FromEA
        {
            get => GetArgument("fromEA", false);
            set
            {
                bool argumentValue = value;
                SetArgument("fromEA", argumentValue);
            }
        }

        /// <summary>
        /// Toggle surface grab on. Requires pos1,pos2,pos3 and pos4 to be specified.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SurfaceGrab
        {
            get => GetArgument("surfaceGrab", false);
            set
            {
                bool argumentValue = value;
                SetArgument("surfaceGrab", argumentValue);
            }
        }

        /// <summary>
        /// LevelIndex of instance to grab (-1 = world coordinates).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int InstanceIndex
        {
            get => GetArgument("instanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("instanceIndex", argumentValue);
            }
        }

        /// <summary>
        /// BoundIndex of part on instance to grab (0 = just use instance coordinates).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int InstancePartIndex
        {
            get => GetArgument("instancePartIndex", 0);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("instancePartIndex", argumentValue);
            }
        }

        /// <summary>
        /// Once a constraint is made, keep reaching with whatever hand is allowed - no matter what the angle/distance and whether or not the constraint has broken due to constraintForce GT grabStrength. mmmtodo this is a badly named parameter.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DontLetGo
        {
            get => GetArgument("dontLetGo", false);
            set
            {
                bool argumentValue = value;
                SetArgument("dontLetGo", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of upper body. Scales the arm grab such that the armStiffness is default when this is at default value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float BodyStiffness
        {
            get => GetArgument("bodyStiffness", 11.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("bodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Angle from front at which the grab activates. If the point is outside this angle from front will not try to grab.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.80</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float ReachAngle
        {
            get => GetArgument("reachAngle", 2.80f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("reachAngle", argumentValue);
            }
        }

        /// <summary>
        /// Angle at which we will only reach with one hand.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.4</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float OneSideReachAngle
        {
            get => GetArgument("oneSideReachAngle", 1.4f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("oneSideReachAngle", argumentValue);
            }
        }

        /// <summary>
        /// Relative distance at which the grab starts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float GrabDistance
        {
            get => GetArgument("grabDistance", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("grabDistance", argumentValue);
            }
        }

        /// <summary>
        /// Relative distance (additional to grabDistance - doesn't try to move inside grabDistance)at which the grab tries to use the balancer to move to the grab point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>14.0</c>.</para>
        /// </remarks>
        public float Move2Radius
        {
            get => GetArgument("move2Radius", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(14.0f, System.Math.Max(0.0f, value));
                SetArgument("move2Radius", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of the arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>14.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffness
        {
            get => GetArgument("armStiffness", 14.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("armStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Distance to reach out towards the grab point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.7</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float MaxReachDistance
        {
            get => GetArgument("maxReachDistance", 0.7f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("maxReachDistance", argumentValue);
            }
        }

        /// <summary>
        /// Scale torque used to rotate hands to face normals.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float OrientationConstraintScale
        {
            get => GetArgument("orientationConstraintScale", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("orientationConstraintScale", argumentValue);
            }
        }

        /// <summary>
        /// When we are grabbing the max angle the wrist ccan be at before we break the grab.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.141593</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.151593</c>.</para>
        /// </remarks>
        public float MaxWristAngle
        {
            get => GetArgument("maxWristAngle", 3.141593f);
            set
            {
                float argumentValue = System.Math.Min(3.151593f, System.Math.Max(0.0f, value));
                SetArgument("maxWristAngle", argumentValue);
            }
        }

        /// <summary>
        /// If true, the character will look at targetForHeadLook after a hand grabs until the end of the behavior. (Before grabbing it looks at the grab target).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseHeadLookToTarget
        {
            get => GetArgument("useHeadLookToTarget", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useHeadLookToTarget", argumentValue);
            }
        }

        /// <summary>
        /// If true, the character will look at the grab.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool LookAtGrab
        {
            get => GetArgument("lookAtGrab", true);
            set
            {
                bool argumentValue = value;
                SetArgument("lookAtGrab", argumentValue);
            }
        }

        /// <summary>
        /// Only used if useHeadLookToTarget is true, the target in world space to look at.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 TargetForHeadLook
        {
            get => GetArgument("targetForHeadLook", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("targetForHeadLook", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class HeadLookHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the HeadLook NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public HeadLookHelper(Ped ped) : base(ped, "headLook")
        {
        }

        /// <summary>
        /// Damping of the muscles.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.000</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float Damping
        {
            get => GetArgument("damping", 1.000f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("damping", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of the muscles.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.000</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float Stiffness
        {
            get => GetArgument("stiffness", 10.000f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("stiffness", argumentValue);
            }
        }

        /// <summary>
        /// LevelIndex of object to be looked at. vel parameters are ignored if this is non -1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int InstanceIndex
        {
            get => GetArgument("instanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("instanceIndex", argumentValue);
            }
        }

        /// <summary>
        /// The velocity of the point being looked at.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-100.0</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public Vector3 Vel
        {
            get => GetArgument("vel", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-100.0f, -100.0f, -100.0f), new Vector3(100.0f, 100.0f, 100.0f));
                SetArgument("vel", argumentValue);
            }
        }

        /// <summary>
        /// The point being looked at.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos
        {
            get => GetArgument("pos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos", argumentValue);
            }
        }

        /// <summary>
        /// Flag to force always to look.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AlwaysLook
        {
            get => GetArgument("alwaysLook", false);
            set
            {
                bool argumentValue = value;
                SetArgument("alwaysLook", argumentValue);
            }
        }

        /// <summary>
        /// Keep the eyes horizontal. Use true for impact with cars. Use false if you want better look at target accuracy when the character is on the floor or leaned over alot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool EyesHorizontal
        {
            get => GetArgument("eyesHorizontal", true);
            set
            {
                bool argumentValue = value;
                SetArgument("eyesHorizontal", argumentValue);
            }
        }

        /// <summary>
        /// Keep the eyes horizontal. Use true for impact with cars. Use false if you want better look at target accuracy when the character is on the floor or leaned over (when not leaned over the eyes are still kept horizontal if eyesHorizontal=true ) alot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool AlwaysEyesHorizontal
        {
            get => GetArgument("alwaysEyesHorizontal", true);
            set
            {
                bool argumentValue = value;
                SetArgument("alwaysEyesHorizontal", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets keepHeadAwayFromGround.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool KeepHeadAwayFromGround
        {
            get => GetArgument("keepHeadAwayFromGround", false);
            set
            {
                bool argumentValue = value;
                SetArgument("keepHeadAwayFromGround", argumentValue);
            }
        }

        /// <summary>
        /// Allow headlook to twist spine.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool TwistSpine
        {
            get => GetArgument("twistSpine", true);
            set
            {
                bool argumentValue = value;
                SetArgument("twistSpine", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class HighFallHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the HighFall NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public HighFallHelper(Ped ped) : base(ped, "highFall")
        {
        }

        /// <summary>
        /// Stiffness of body. Value feeds through to bodyBalance (synched with defaults), to armsWindmill (14 for this value at default ), legs pedal, head look and roll down stairs directly.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float BodyStiffness
        {
            get => GetArgument("bodyStiffness", 11.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(6.00f, value));
                SetArgument("bodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// The damping of the joints.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float Bodydamping
        {
            get => GetArgument("bodydamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("bodydamping", argumentValue);
            }
        }

        /// <summary>
        /// The length of time before the impact that the character transitions to the landing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.300</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Catchfalltime
        {
            get => GetArgument("catchfalltime", 0.300f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("catchfalltime", argumentValue);
            }
        }

        /// <summary>
        /// 0.52angle is 0.868 dot//A threshold for deciding how far away from upright the character needs to be before bailing out (going into a foetal) instead of trying to land (keeping stretched out). NB: never does bailout if ignorWorldCollisions true.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.8680</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CrashOrLandCutOff
        {
            get => GetArgument("crashOrLandCutOff", 0.8680f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("crashOrLandCutOff", argumentValue);
            }
        }

        /// <summary>
        /// Strength of the controller to keep the character at angle aimAngleBase from vertical.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float PdStrength
        {
            get => GetArgument("pdStrength", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("pdStrength", argumentValue);
            }
        }

        /// <summary>
        /// Damping multiplier of the controller to keep the character at angle aimAngleBase from vertical. The actual damping is pdDamping*pdStrength*constant*angVel.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float PdDamping
        {
            get => GetArgument("pdDamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("pdDamping", argumentValue);
            }
        }

        /// <summary>
        /// Arm circling speed in armWindMillAdaptive.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>7.850</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ArmAngSpeed
        {
            get => GetArgument("armAngSpeed", 7.850f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.00f, value));
                SetArgument("armAngSpeed", argumentValue);
            }
        }

        /// <summary>
        /// In armWindMillAdaptive.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ArmAmplitude
        {
            get => GetArgument("armAmplitude", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("armAmplitude", argumentValue);
            }
        }

        /// <summary>
        /// In armWindMillAdaptive 3.1 opposite for stuntman. 1.0 old default. 0.0 in phase.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>6.283185</c>.</para>
        /// </remarks>
        public float ArmPhase
        {
            get => GetArgument("armPhase", 3.10f);
            set
            {
                float argumentValue = System.Math.Min(6.283185f, System.Math.Max(0.00f, value));
                SetArgument("armPhase", argumentValue);
            }
        }

        /// <summary>
        /// In armWindMillAdaptive bend the elbows as a function of armAngle. For stuntman true otherwise false.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ArmBendElbows
        {
            get => GetArgument("armBendElbows", true);
            set
            {
                bool argumentValue = value;
                SetArgument("armBendElbows", argumentValue);
            }
        }

        /// <summary>
        /// Radius of legs on pedal.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float LegRadius
        {
            get => GetArgument("legRadius", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(0.010f, value));
                SetArgument("legRadius", argumentValue);
            }
        }

        /// <summary>
        /// In pedal.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>7.850</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>15.0</c>.</para>
        /// </remarks>
        public float LegAngSpeed
        {
            get => GetArgument("legAngSpeed", 7.850f);
            set
            {
                float argumentValue = System.Math.Min(15.0f, System.Math.Max(0.00f, value));
                SetArgument("legAngSpeed", argumentValue);
            }
        }

        /// <summary>
        /// 0.0 for stuntman. Random offset applied per leg to the angular speed to desynchronise the pedaling - set to 0 to disable, otherwise should be set to less than the angularSpeed value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>-10.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float LegAsymmetry
        {
            get => GetArgument("legAsymmetry", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-10.00f, value));
                SetArgument("legAsymmetry", argumentValue);
            }
        }

        /// <summary>
        /// Phase angle between the arms and legs circling angle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>6.50</c>.</para>
        /// </remarks>
        public float Arms2LegsPhase
        {
            get => GetArgument("arms2LegsPhase", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(6.50f, System.Math.Max(0.00f, value));
                SetArgument("arms2LegsPhase", argumentValue);
            }
        }

        /// <summary>
        /// 0=not synched, 1=always synched, 2= synch at start only. Synchs the arms angle to what the leg angle is. All speed/direction parameters of armswindmill are overwritten if = 1. If 2 and you want synced arms/legs then armAngSpeed=legAngSpeed, legAsymmetry = 0.0 (to stop randomizations of the leg cicle speed).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public Synchroisation Arms2LegsSync
        {
            get => (Synchroisation)GetArgument("arms2LegsSync", (int)(Synchroisation)1);
            set
            {
                Synchroisation argumentValue = value;
                SetArgument("arms2LegsSync", (int)argumentValue);
            }
        }

        /// <summary>
        /// Where to put the arms when preparing to land. Approx 1 = above head, 0 = head height, -1 = down. LT -2.0 use catchFall arms, LT -3.0 use prepare for landing pose if Agent is due to land vertically, feet first.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-3.10</c>.</para>
        /// <para>Minimum value: <c>-4.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float ArmsUp
        {
            get => GetArgument("armsUp", -3.10f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(-4.00f, value));
                SetArgument("armsUp", argumentValue);
            }
        }

        /// <summary>
        /// Toggle to orientate to fall direction. i.e. orientate so that the character faces the horizontal velocity direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool OrientateBodyToFallDirection
        {
            get => GetArgument("orientateBodyToFallDirection", false);
            set
            {
                bool argumentValue = value;
                SetArgument("orientateBodyToFallDirection", argumentValue);
            }
        }

        /// <summary>
        /// If false don't worry about the twist angle of the character when orientating the character. If false this allows the twist axis of the character to be free (You can get a nice twisting highFall like the one in dieHard 4 when the car goes into the helicopter).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool OrientateTwist
        {
            get => GetArgument("orientateTwist", true);
            set
            {
                bool argumentValue = value;
                SetArgument("orientateTwist", argumentValue);
            }
        }

        /// <summary>
        /// DEVEL parameter - suggest you don't edit it. Maximum torque the orientation controller can apply. If 0 then no helper torques will be used. 300 will orientate the character soflty for all but extreme angles away from aimAngleBase. If abs (current -aimAngleBase) is getting near 3.0 then this can be reduced to give a softer feel.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>300.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2000.00</c>.</para>
        /// </remarks>
        public float OrientateMax
        {
            get => GetArgument("orientateMax", 300.00f);
            set
            {
                float argumentValue = System.Math.Min(2000.00f, System.Math.Max(0.00f, value));
                SetArgument("orientateMax", argumentValue);
            }
        }

        /// <summary>
        /// If true then orientate the character to face the point from where it started falling. HighFall like the one in dieHard with Alan Rickman.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AlanRickman
        {
            get => GetArgument("alanRickman", false);
            set
            {
                bool argumentValue = value;
                SetArgument("alanRickman", argumentValue);
            }
        }

        /// <summary>
        /// Try to execute a forward Roll on landing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FowardRoll
        {
            get => GetArgument("fowardRoll", false);
            set
            {
                bool argumentValue = value;
                SetArgument("fowardRoll", argumentValue);
            }
        }

        /// <summary>
        /// Blend to a zero pose when forward roll is attempted.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseZeroPose_withFowardRoll
        {
            get => GetArgument("useZeroPose_withFowardRoll", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useZeroPose_withFowardRoll", argumentValue);
            }
        }

        /// <summary>
        /// Angle from vertical the pdController is driving to ( positive = forwards).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.180</c>.</para>
        /// <para>Minimum value: <c>-3.141593</c>.</para>
        /// <para>Maximum value: <c>3.141593</c>.</para>
        /// </remarks>
        public float AimAngleBase
        {
            get => GetArgument("aimAngleBase", 0.180f);
            set
            {
                float argumentValue = System.Math.Min(3.141593f, System.Math.Max(-3.141593f, value));
                SetArgument("aimAngleBase", argumentValue);
            }
        }

        /// <summary>
        /// Scale to add/subtract from aimAngle based on forward speed (Internal).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.020</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FowardVelRotation
        {
            get => GetArgument("fowardVelRotation", -0.020f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("fowardVelRotation", argumentValue);
            }
        }

        /// <summary>
        /// Scale to change to amount of vel that is added to the foot ik from the velocity (Internal).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.050</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FootVelCompScale
        {
            get => GetArgument("footVelCompScale", 0.050f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("footVelCompScale", argumentValue);
            }
        }

        /// <summary>
        /// Sideoffset for the feet during prepareForLanding. +ve = right.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SideD
        {
            get => GetArgument("sideD", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("sideD", argumentValue);
            }
        }

        /// <summary>
        /// Forward offset for the feet during prepareForLanding.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FowardOffsetOfLegIK
        {
            get => GetArgument("fowardOffsetOfLegIK", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("fowardOffsetOfLegIK", argumentValue);
            }
        }

        /// <summary>
        /// Leg Length for ik (Internal)//unused.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float LegL
        {
            get => GetArgument("legL", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.0f, value));
                SetArgument("legL", argumentValue);
            }
        }

        /// <summary>
        /// 0.5angle is 0.878 dot. Cutoff to go to the catchFall ( internal) //mmmtodo do like crashOrLandCutOff.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.8780</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CatchFallCutOff
        {
            get => GetArgument("catchFallCutOff", 0.8780f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("catchFallCutOff", argumentValue);
            }
        }

        /// <summary>
        /// Strength of the legs at landing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float LegStrength
        {
            get => GetArgument("legStrength", 12.00f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.00f, value));
                SetArgument("legStrength", argumentValue);
            }
        }

        /// <summary>
        /// If true have enough strength to balance. If false not enough strength in legs to balance (even though bodyBlance called).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Balance
        {
            get => GetArgument("balance", true);
            set
            {
                bool argumentValue = value;
                SetArgument("balance", argumentValue);
            }
        }

        /// <summary>
        /// Never go into bailout (foetal).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool IgnorWorldCollisions
        {
            get => GetArgument("ignorWorldCollisions", false);
            set
            {
                bool argumentValue = value;
                SetArgument("ignorWorldCollisions", argumentValue);
            }
        }

        /// <summary>
        /// Stuntman type fall. Arm and legs circling direction controlled by angmom and orientation.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool AdaptiveCircling
        {
            get => GetArgument("adaptiveCircling", true);
            set
            {
                bool argumentValue = value;
                SetArgument("adaptiveCircling", argumentValue);
            }
        }

        /// <summary>
        /// With stuntman type fall. Hula reaction if can't see floor and not rotating fast.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Hula
        {
            get => GetArgument("hula", true);
            set
            {
                bool argumentValue = value;
                SetArgument("hula", argumentValue);
            }
        }

        /// <summary>
        /// Character needs to be moving less than this speed to consider fall as a recoverable one.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>15.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float MaxSpeedForRecoverableFall
        {
            get => GetArgument("maxSpeedForRecoverableFall", 15.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("maxSpeedForRecoverableFall", argumentValue);
            }
        }

        /// <summary>
        /// Character needs to be moving at least this fast horizontally to start bracing for impact if there is an object along its trajectory.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float MinSpeedForBrace
        {
            get => GetArgument("minSpeedForBrace", 10.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("minSpeedForBrace", argumentValue);
            }
        }

        /// <summary>
        /// Ray-cast normal doted with up direction has to be greater than this number to consider object flat enough to land on it.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LandingNormal
        {
            get => GetArgument("landingNormal", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("landingNormal", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class IncomingTransformsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the IncomingTransforms NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public IncomingTransformsHelper(Ped ped) : base(ped, "incomingTransforms")
        {
        }
    }

    /// <summary>
    /// InjuredOnGround.
    /// </summary>
    public sealed class InjuredOnGroundHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the InjuredOnGround NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public InjuredOnGroundHelper(Ped ped) : base(ped, "injuredOnGround")
        {
        }

        /// <summary>
        /// Gets or sets numInjuries.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int NumInjuries
        {
            get => GetArgument("numInjuries", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("numInjuries", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets injury1Component.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int Injury1Component
        {
            get => GetArgument("injury1Component", 0);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("injury1Component", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets injury2Component.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int Injury2Component
        {
            get => GetArgument("injury2Component", 0);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("injury2Component", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets injury1LocalPosition.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Injury1LocalPosition
        {
            get => GetArgument("injury1LocalPosition", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("injury1LocalPosition", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets injury2LocalPosition.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Injury2LocalPosition
        {
            get => GetArgument("injury2LocalPosition", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("injury2LocalPosition", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets injury1LocalNormal.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1, 0, 0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public Vector3 Injury1LocalNormal
        {
            get => GetArgument("injury1LocalNormal", new Vector3(1.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f));
                SetArgument("injury1LocalNormal", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets injury2LocalNormal.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1, 0, 0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public Vector3 Injury2LocalNormal
        {
            get => GetArgument("injury2LocalNormal", new Vector3(1.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f));
                SetArgument("injury2LocalNormal", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets attackerPos.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1, 0, 0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public Vector3 AttackerPos
        {
            get => GetArgument("attackerPos", new Vector3(1.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("attackerPos", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets dontReachWithLeft.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DontReachWithLeft
        {
            get => GetArgument("dontReachWithLeft", false);
            set
            {
                bool argumentValue = value;
                SetArgument("dontReachWithLeft", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets dontReachWithRight.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DontReachWithRight
        {
            get => GetArgument("dontReachWithRight", false);
            set
            {
                bool argumentValue = value;
                SetArgument("dontReachWithRight", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets strongRollForce.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool StrongRollForce
        {
            get => GetArgument("strongRollForce", false);
            set
            {
                bool argumentValue = value;
                SetArgument("strongRollForce", argumentValue);
            }
        }
    }

    /// <summary>
    /// Carried.
    /// </summary>
    public sealed class CarriedHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the Carried NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public CarriedHelper(Ped ped) : base(ped, "carried")
        {
        }
    }

    /// <summary>
    /// Dangle.
    /// </summary>
    public sealed class DangleHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the Dangle NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public DangleHelper(Ped ped) : base(ped, "dangle")
        {
        }

        /// <summary>
        /// Gets or sets doGrab.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool DoGrab
        {
            get => GetArgument("doGrab", true);
            set
            {
                bool argumentValue = value;
                SetArgument("doGrab", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets grabFrequency.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float GrabFrequency
        {
            get => GetArgument("grabFrequency", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("grabFrequency", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class OnFireHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the OnFire NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public OnFireHelper(Ped ped) : base(ped, "onFire")
        {
        }

        /// <summary>
        /// Max time for stumbling around before falling to ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>30.00</c>.</para>
        /// </remarks>
        public float StaggerTime
        {
            get => GetArgument("staggerTime", 2.50f);
            set
            {
                float argumentValue = System.Math.Min(30.00f, System.Math.Max(0.00f, value));
                SetArgument("staggerTime", argumentValue);
            }
        }

        /// <summary>
        /// How quickly the character leans hips when staggering.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.90</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float StaggerLeanRate
        {
            get => GetArgument("staggerLeanRate", 0.90f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("staggerLeanRate", argumentValue);
            }
        }

        /// <summary>
        /// Max the character leans hips back when staggering.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.50</c>.</para>
        /// </remarks>
        public float StumbleMaxLeanBack
        {
            get => GetArgument("stumbleMaxLeanBack", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(1.50f, System.Math.Max(0.00f, value));
                SetArgument("stumbleMaxLeanBack", argumentValue);
            }
        }

        /// <summary>
        /// Max the character leans hips forwards when staggering.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.50</c>.</para>
        /// </remarks>
        public float StumbleMaxLeanForward
        {
            get => GetArgument("stumbleMaxLeanForward", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.50f, System.Math.Max(0.00f, value));
                SetArgument("stumbleMaxLeanForward", argumentValue);
            }
        }

        /// <summary>
        /// Blend armsWindmill with the bodyWrithe arms when character is upright.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ArmsWindmillWritheBlend
        {
            get => GetArgument("armsWindmillWritheBlend", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("armsWindmillWritheBlend", argumentValue);
            }
        }

        /// <summary>
        /// Blend spine stumble with the bodyWrithe spine when character is upright.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SpineStumbleWritheBlend
        {
            get => GetArgument("spineStumbleWritheBlend", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("spineStumbleWritheBlend", argumentValue);
            }
        }

        /// <summary>
        /// Blend legs stumble with the bodyWrithe legs when character is upright.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegsStumbleWritheBlend
        {
            get => GetArgument("legsStumbleWritheBlend", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("legsStumbleWritheBlend", argumentValue);
            }
        }

        /// <summary>
        /// Blend the bodyWrithe arms with the current desired pose from on fire behavior when character is on the floor.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ArmsPoseWritheBlend
        {
            get => GetArgument("armsPoseWritheBlend", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("armsPoseWritheBlend", argumentValue);
            }
        }

        /// <summary>
        /// Blend the bodyWrithe back with the current desired pose from on fire behavior when character is on the floor.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.550</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SpinePoseWritheBlend
        {
            get => GetArgument("spinePoseWritheBlend", 0.550f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("spinePoseWritheBlend", argumentValue);
            }
        }

        /// <summary>
        /// Blend the bodyWrithe legs with the current desired pose from on fire behavior when character is on the floor.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegsPoseWritheBlend
        {
            get => GetArgument("legsPoseWritheBlend", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("legsPoseWritheBlend", argumentValue);
            }
        }

        /// <summary>
        /// Flag to set bodyWrithe trying to rollOver.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool RollOverFlag
        {
            get => GetArgument("rollOverFlag", true);
            set
            {
                bool argumentValue = value;
                SetArgument("rollOverFlag", argumentValue);
            }
        }

        /// <summary>
        /// Scale rolling torque that is applied to character spine by bodyWrithe. Torque magnitude is calculated with the following formula: m_rollOverDirection*rollOverPhase*rollTorqueScale.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>25.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>300.00</c>.</para>
        /// </remarks>
        public float RollTorqueScale
        {
            get => GetArgument("rollTorqueScale", 25.00f);
            set
            {
                float argumentValue = System.Math.Min(300.00f, System.Math.Max(0.00f, value));
                SetArgument("rollTorqueScale", argumentValue);
            }
        }

        /// <summary>
        /// Character pose depends on character facing direction that is evaluated from its COMTM orientation. Set this value to 0 to use no orientation prediction i.e. current character COMTM orientation will be used to determine character facing direction and finally the pose bodyWrithe is blending to. Set this value to GT 0 to predict character COMTM orientation this amout of time in seconds to the future.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float PredictTime
        {
            get => GetArgument("predictTime", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("predictTime", argumentValue);
            }
        }

        /// <summary>
        /// Rolling torque is ramped down over time. At this time in seconds torque value converges to zero. Use this parameter to restrict time the character is rolling.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>60.00</c>.</para>
        /// </remarks>
        public float MaxRollOverTime
        {
            get => GetArgument("maxRollOverTime", 8.00f);
            set
            {
                float argumentValue = System.Math.Min(60.00f, System.Math.Max(0.00f, value));
                SetArgument("maxRollOverTime", argumentValue);
            }
        }

        /// <summary>
        /// Rolling torque is ramped down with distance measured from position where character hit the ground and started rolling. At this distance in meters torque value converges to zero. Use this parameter to restrict distance the character travels due to rolling.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float RollOverRadius
        {
            get => GetArgument("rollOverRadius", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("rollOverRadius", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class PedalLegsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the PedalLegs NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public PedalLegsHelper(Ped ped) : base(ped, "pedalLegs")
        {
        }

        /// <summary>
        /// Pedal with this leg or not.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool PedalLeftLeg
        {
            get => GetArgument("pedalLeftLeg", true);
            set
            {
                bool argumentValue = value;
                SetArgument("pedalLeftLeg", argumentValue);
            }
        }

        /// <summary>
        /// Pedal with this leg or not.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool PedalRightLeg
        {
            get => GetArgument("pedalRightLeg", true);
            set
            {
                bool argumentValue = value;
                SetArgument("pedalRightLeg", argumentValue);
            }
        }

        /// <summary>
        /// Pedal forwards or backwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BackPedal
        {
            get => GetArgument("backPedal", false);
            set
            {
                bool argumentValue = value;
                SetArgument("backPedal", argumentValue);
            }
        }

        /// <summary>
        /// Base radius of pedal action.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float Radius
        {
            get => GetArgument("radius", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.010f, value));
                SetArgument("radius", argumentValue);
            }
        }

        /// <summary>
        /// Rate of pedaling. If adaptivePedal4Dragging is true then the legsAngularSpeed calculated to match the linear speed of the character can have a maximum value of angularSpeed (this max used to be hard coded to 13.0).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float AngularSpeed
        {
            get => GetArgument("angularSpeed", 10.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("angularSpeed", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of legs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float LegStiffness
        {
            get => GetArgument("legStiffness", 10.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(6.00f, value));
                SetArgument("legStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Move the centre of the pedal for the left leg up by this amount, the right leg down by this amount.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float PedalOffset
        {
            get => GetArgument("pedalOffset", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("pedalOffset", argumentValue);
            }
        }

        /// <summary>
        /// Random seed used to generate speed changes.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int RandomSeed
        {
            get => GetArgument("randomSeed", 100);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("randomSeed", argumentValue);
            }
        }

        /// <summary>
        /// Random offset applied per leg to the angular speed to desynchronise the pedaling - set to 0 to disable, otherwise should be set to less than the angularSpeed value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.00</c>.</para>
        /// <para>Minimum value: <c>-10.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SpeedAsymmetry
        {
            get => GetArgument("speedAsymmetry", 8.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-10.00f, value));
                SetArgument("speedAsymmetry", argumentValue);
            }
        }

        /// <summary>
        /// Will pedal in the direction of travel (if backPedal = false, against travel if backPedal = true) and with an angular velocity relative to speed upto a maximum of 13(rads/sec). Use when being dragged by a car. Overrides angularSpeed.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AdaptivePedal4Dragging
        {
            get => GetArgument("adaptivePedal4Dragging", false);
            set
            {
                bool argumentValue = value;
                SetArgument("adaptivePedal4Dragging", argumentValue);
            }
        }

        /// <summary>
        /// NewAngularSpeed = Clamp(angSpeedMultiplier4Dragging * linear_speed/pedalRadius, 0.0, angularSpeed).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float AngSpeedMultiplier4Dragging
        {
            get => GetArgument("angSpeedMultiplier4Dragging", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("angSpeedMultiplier4Dragging", argumentValue);
            }
        }

        /// <summary>
        /// 0-1 value used to add variance to the radius value while pedalling, to desynchonize the legs' movement and provide some variety.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float RadiusVariance
        {
            get => GetArgument("radiusVariance", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("radiusVariance", argumentValue);
            }
        }

        /// <summary>
        /// 0-1 value used to vary the angle of the legs from the hips during the pedal.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LegAngleVariance
        {
            get => GetArgument("legAngleVariance", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("legAngleVariance", argumentValue);
            }
        }

        /// <summary>
        /// Move the centre of the pedal for both legs sideways (+ve = right). NB: not applied to hula.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CentreSideways
        {
            get => GetArgument("centreSideways", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("centreSideways", argumentValue);
            }
        }

        /// <summary>
        /// Move the centre of the pedal for both legs forward (or backward -ve).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CentreForwards
        {
            get => GetArgument("centreForwards", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("centreForwards", argumentValue);
            }
        }

        /// <summary>
        /// Move the centre of the pedal for both legs up (or down -ve).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CentreUp
        {
            get => GetArgument("centreUp", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("centreUp", argumentValue);
            }
        }

        /// <summary>
        /// Turn the circle into an ellipse. Ellipse has horizontal radius a and vertical radius b. If ellipse is +ve then a=radius*ellipse and b=radius. If ellipse is -ve then a=radius and b = radius*ellipse. 0.0 = vertical line of length 2*radius, 0.0:1.0 circle squashed horizontally (vertical radius = radius), 1.0=circle. -0.001 = horizontal line of length 2*radius, -0.0:-1.0 circle squashed vertically (horizontal radius = radius), -1.0 = circle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Ellipse
        {
            get => GetArgument("ellipse", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("ellipse", argumentValue);
            }
        }

        /// <summary>
        /// How much to account for the target moving through space rather than being static.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float DragReduction
        {
            get => GetArgument("dragReduction", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("dragReduction", argumentValue);
            }
        }

        /// <summary>
        /// Spread legs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Spread
        {
            get => GetArgument("spread", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("spread", argumentValue);
            }
        }

        /// <summary>
        /// If true circle the legs in a hula motion.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Hula
        {
            get => GetArgument("hula", false);
            set
            {
                bool argumentValue = value;
                SetArgument("hula", argumentValue);
            }
        }
    }

    /// <summary>
    /// PointArm:BEHAVIOURS REFERENCED: AnimPose - allows animPose to overridebodyParts: Arms (useLeftArm, useRightArm).
    /// </summary>
    public sealed class PointArmHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the PointArm NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public PointArmHelper(Ped ped) : base(ped, "pointArm")
        {
        }

        /// <summary>
        /// Point to point to (in world space).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 TargetLeft
        {
            get => GetArgument("targetLeft", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("targetLeft", argumentValue);
            }
        }

        /// <summary>
        /// Twist of the arm around point direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.3</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TwistLeft
        {
            get => GetArgument("twistLeft", 0.3f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("twistLeft", argumentValue);
            }
        }

        /// <summary>
        /// Values less than 1 can give the arm a more bent look.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.8</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmStraightnessLeft
        {
            get => GetArgument("armStraightnessLeft", 0.8f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armStraightnessLeft", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets useLeftArm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseLeftArm
        {
            get => GetArgument("useLeftArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useLeftArm", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>15.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffnessLeft
        {
            get => GetArgument("armStiffnessLeft", 15.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("armStiffnessLeft", argumentValue);
            }
        }

        /// <summary>
        /// Damping value for arm used to point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmDampingLeft
        {
            get => GetArgument("armDampingLeft", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armDampingLeft", argumentValue);
            }
        }

        /// <summary>
        /// Level index of thing to point at, or -1 for none. if -1, target is specified in world space, otherwise it is an offset from the object specified by this index.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int InstanceIndexLeft
        {
            get => GetArgument("instanceIndexLeft", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("instanceIndexLeft", argumentValue);
            }
        }

        /// <summary>
        /// Swing limit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float PointSwingLimitLeft
        {
            get => GetArgument("pointSwingLimitLeft", 1.5f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("pointSwingLimitLeft", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets useZeroPoseWhenNotPointingLeft.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseZeroPoseWhenNotPointingLeft
        {
            get => GetArgument("useZeroPoseWhenNotPointingLeft", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useZeroPoseWhenNotPointingLeft", argumentValue);
            }
        }

        /// <summary>
        /// Point to point to (in world space).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 TargetRight
        {
            get => GetArgument("targetRight", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("targetRight", argumentValue);
            }
        }

        /// <summary>
        /// Twist of the arm around point direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.3</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TwistRight
        {
            get => GetArgument("twistRight", 0.3f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("twistRight", argumentValue);
            }
        }

        /// <summary>
        /// Values less than 1 can give the arm a more bent look.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.8</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmStraightnessRight
        {
            get => GetArgument("armStraightnessRight", 0.8f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armStraightnessRight", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets useRightArm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseRightArm
        {
            get => GetArgument("useRightArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useRightArm", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>15.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffnessRight
        {
            get => GetArgument("armStiffnessRight", 15.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("armStiffnessRight", argumentValue);
            }
        }

        /// <summary>
        /// Damping value for arm used to point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmDampingRight
        {
            get => GetArgument("armDampingRight", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armDampingRight", argumentValue);
            }
        }

        /// <summary>
        /// Level index of thing to point at, or -1 for none. if -1, target is specified in world space, otherwise it is an offset from the object specified by this index.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int InstanceIndexRight
        {
            get => GetArgument("instanceIndexRight", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("instanceIndexRight", argumentValue);
            }
        }

        /// <summary>
        /// Swing limit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float PointSwingLimitRight
        {
            get => GetArgument("pointSwingLimitRight", 1.5f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("pointSwingLimitRight", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets useZeroPoseWhenNotPointingRight.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseZeroPoseWhenNotPointingRight
        {
            get => GetArgument("useZeroPoseWhenNotPointingRight", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useZeroPoseWhenNotPointingRight", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class PointGunHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the PointGun NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public PointGunHelper(Ped ped) : base(ped, "pointGun")
        {
        }

        /// <summary>
        /// Allow right hand to point/support?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool EnableRight
        {
            get => GetArgument("enableRight", true);
            set
            {
                bool argumentValue = value;
                SetArgument("enableRight", argumentValue);
            }
        }

        /// <summary>
        /// Allow right hand to point/support?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool EnableLeft
        {
            get => GetArgument("enableLeft", true);
            set
            {
                bool argumentValue = value;
                SetArgument("enableLeft", argumentValue);
            }
        }

        /// <summary>
        /// Target for the left Hand.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 LeftHandTarget
        {
            get => GetArgument("leftHandTarget", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("leftHandTarget", argumentValue);
            }
        }

        /// <summary>
        /// Index of the object that the left hand target is specified in, -1 is world space.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// </remarks>
        public int LeftHandTargetIndex
        {
            get => GetArgument("leftHandTargetIndex", -1);
            set
            {
                int argumentValue = value;
                SetArgument("leftHandTargetIndex", argumentValue);
            }
        }

        /// <summary>
        /// Target for the right Hand.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 RightHandTarget
        {
            get => GetArgument("rightHandTarget", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("rightHandTarget", argumentValue);
            }
        }

        /// <summary>
        /// Index of the object that the right hand target is specified in, -1 is world space.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// </remarks>
        public int RightHandTargetIndex
        {
            get => GetArgument("rightHandTargetIndex", -1);
            set
            {
                int argumentValue = value;
                SetArgument("rightHandTargetIndex", argumentValue);
            }
        }

        /// <summary>
        /// NB: Only Applied to single handed weapons (some more work is required to have this tech on two handed weapons). Amount to lead target based on target velocity relative to the chest.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float LeadTarget
        {
            get => GetArgument("leadTarget", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("leadTarget", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of the arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>14.00</c>.</para>
        /// <para>Minimum value: <c>2.00</c>.</para>
        /// <para>Maximum value: <c>15.00</c>.</para>
        /// </remarks>
        public float ArmStiffness
        {
            get => GetArgument("armStiffness", 14.00f);
            set
            {
                float argumentValue = System.Math.Min(15.00f, System.Math.Max(2.00f, value));
                SetArgument("armStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of the arm on pointing arm when a support arm is detached from a two-handed weapon.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.00</c>.</para>
        /// <para>Minimum value: <c>2.00</c>.</para>
        /// <para>Maximum value: <c>15.00</c>.</para>
        /// </remarks>
        public float ArmStiffnessDetSupport
        {
            get => GetArgument("armStiffnessDetSupport", 8.00f);
            set
            {
                float argumentValue = System.Math.Min(15.00f, System.Math.Max(2.00f, value));
                SetArgument("armStiffnessDetSupport", argumentValue);
            }
        }

        /// <summary>
        /// Damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float ArmDamping
        {
            get => GetArgument("armDamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.10f, value));
                SetArgument("armDamping", argumentValue);
            }
        }

        /// <summary>
        /// Amount of gravity opposition on pointing arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float GravityOpposition
        {
            get => GetArgument("gravityOpposition", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("gravityOpposition", argumentValue);
            }
        }

        /// <summary>
        /// Amount of gravity opposition on pointing arm when a support arm is detached from a two-handed weapon.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float GravOppDetachedSupport
        {
            get => GetArgument("gravOppDetachedSupport", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("gravOppDetachedSupport", argumentValue);
            }
        }

        /// <summary>
        /// Amount of mass of weapon taken into account by gravity opposition on pointing arm when a support arm is detached from a two-handed weapon. The lower the value the more the character doesn't know about the weapon mass and therefore is more affected by it.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float MassMultDetachedSupport
        {
            get => GetArgument("massMultDetachedSupport", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("massMultDetachedSupport", argumentValue);
            }
        }

        /// <summary>
        /// Allow shot to set a lower arm muscleStiffness than pointGun normally would.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AllowShotLooseness
        {
            get => GetArgument("allowShotLooseness", false);
            set
            {
                bool argumentValue = value;
                SetArgument("allowShotLooseness", argumentValue);
            }
        }

        /// <summary>
        /// How much of blend should come from incoming transforms 0(all IK) .. 1(all ITMs) For pointing arms only. (Support arm uses the IK solution as is for clavicles).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ClavicleBlend
        {
            get => GetArgument("clavicleBlend", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("clavicleBlend", argumentValue);
            }
        }

        /// <summary>
        /// Controls arm twist. (except in pistolIK).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ElbowAttitude
        {
            get => GetArgument("elbowAttitude", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("elbowAttitude", argumentValue);
            }
        }

        /// <summary>
        /// Type of constraint between the support hand and gun. 0=no constraint, 1=hard distance constraint, 2=Force based constraint, 3=hard spherical constraint.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public int SupportConstraint
        {
            get => GetArgument("supportConstraint", 1);
            set
            {
                int argumentValue = System.Math.Min(3, System.Math.Max(0, value));
                SetArgument("supportConstraint", argumentValue);
            }
        }

        /// <summary>
        /// For supportConstraint = 1: Support hand constraint distance will be slowly reduced until it hits this value. This is for stability and also allows the pointing arm to lead a little. Don't set lower than NM_MIN_STABLE_DISTANCECONSTRAINT_DISTANCE 0.001f.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0150</c>.</para>
        /// <para>Minimum value: <c>0.0010</c>.</para>
        /// <para>Maximum value: <c>0.10</c>.</para>
        /// </remarks>
        public float ConstraintMinDistance
        {
            get => GetArgument("constraintMinDistance", 0.0150f);
            set
            {
                float argumentValue = System.Math.Min(0.10f, System.Math.Max(0.0010f, value));
                SetArgument("constraintMinDistance", argumentValue);
            }
        }

        /// <summary>
        /// For supportConstraint = 1: Minimum distance within which support hand constraint will be made.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float MakeConstraintDistance
        {
            get => GetArgument("makeConstraintDistance", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("makeConstraintDistance", argumentValue);
            }
        }

        /// <summary>
        /// For supportConstraint = 1: Velocity at which to reduce the support hand constraint length.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.50</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ReduceConstraintLengthVel
        {
            get => GetArgument("reduceConstraintLengthVel", 1.50f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.10f, value));
                SetArgument("reduceConstraintLengthVel", argumentValue);
            }
        }

        /// <summary>
        /// For supportConstraint = 1: strength of the supporting hands constraint (kg m/s), -1 to ignore/disable.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1000.00</c>.</para>
        /// </remarks>
        public float BreakingStrength
        {
            get => GetArgument("breakingStrength", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(1000.00f, System.Math.Max(-1.00f, value));
                SetArgument("breakingStrength", argumentValue);
            }
        }

        /// <summary>
        /// Once constraint is broken then do not try to reconnect/support for this amount of time.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float BrokenSupportTime
        {
            get => GetArgument("brokenSupportTime", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("brokenSupportTime", argumentValue);
            }
        }

        /// <summary>
        /// Probability that the when a constraint is broken that during brokenSupportTime a side pose will be selected.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float BrokenToSideProb
        {
            get => GetArgument("brokenToSideProb", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("brokenToSideProb", argumentValue);
            }
        }

        /// <summary>
        /// If gunArm has been controlled by other behaviors for this time when it could have been pointing but couldn't due to pointing only allowed if connected, change gunArm pose to something that could connect for connectFor seconds.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float ConnectAfter
        {
            get => GetArgument("connectAfter", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("connectAfter", argumentValue);
            }
        }

        /// <summary>
        /// Time to try to reconnect for.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.550</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float ConnectFor
        {
            get => GetArgument("connectFor", 0.550f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("connectFor", argumentValue);
            }
        }

        /// <summary>
        /// 0 = don't allow, 1= allow for kPistol(two handed pistol) only, 2 = allow for kRifle only, 3 = allow for kPistol and kRifle. Allow one handed pointing - no constraint if cant be supported . If not allowed then gunHand does not try to point at target if it cannot be supported - the constraint will be controlled by always support.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public int OneHandedPointing
        {
            get => GetArgument("oneHandedPointing", 1);
            set
            {
                int argumentValue = System.Math.Min(3, System.Math.Max(0, value));
                SetArgument("oneHandedPointing", argumentValue);
            }
        }

        /// <summary>
        /// Support a non pointing gunHand i.e. if in zero pose (constrain as well if constraint possible).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AlwaysSupport
        {
            get => GetArgument("alwaysSupport", false);
            set
            {
                bool argumentValue = value;
                SetArgument("alwaysSupport", argumentValue);
            }
        }

        /// <summary>
        /// Apply neutral pose when a gun arm isn't in use. NB: at the moment Rifle hand is always controlled by pointGun.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool PoseUnusedGunArm
        {
            get => GetArgument("poseUnusedGunArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("poseUnusedGunArm", argumentValue);
            }
        }

        /// <summary>
        /// Apply neutral pose when a support arm isn't in use.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool PoseUnusedSupportArm
        {
            get => GetArgument("poseUnusedSupportArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("poseUnusedSupportArm", argumentValue);
            }
        }

        /// <summary>
        /// Apply neutral pose to the non-gun arm (otherwise it is always under the control of other behaviors or not set). If the non-gun hand is a supporting hand it is not controlled by this parameter but by poseUnusedSupportArm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool PoseUnusedOtherArm
        {
            get => GetArgument("poseUnusedOtherArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("poseUnusedOtherArm", argumentValue);
            }
        }

        /// <summary>
        /// Max aiming angle(deg) sideways across body midline measured from chest forward that the character will try to point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>90.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>180.00</c>.</para>
        /// </remarks>
        public float MaxAngleAcross
        {
            get => GetArgument("maxAngleAcross", 90.00f);
            set
            {
                float argumentValue = System.Math.Min(180.00f, System.Math.Max(0.00f, value));
                SetArgument("maxAngleAcross", argumentValue);
            }
        }

        /// <summary>
        /// Max aiming angle(deg) sideways away from body midline measured from chest forward that the character will try to point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>90.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>180.00</c>.</para>
        /// </remarks>
        public float MaxAngleAway
        {
            get => GetArgument("maxAngleAway", 90.00f);
            set
            {
                float argumentValue = System.Math.Min(180.00f, System.Math.Max(0.00f, value));
                SetArgument("maxAngleAway", argumentValue);
            }
        }

        /// <summary>
        /// 0= don't apply limits. 1=apply the limits below only when the character is falling. 2 = always apply these limits (instead of applying maxAngleAcross and maxAngleAway which only limits the horizontal angle but implicity limits the updown (the limit shape is a vertical hinge).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int FallingLimits
        {
            get => GetArgument("fallingLimits", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("fallingLimits", argumentValue);
            }
        }

        /// <summary>
        /// Max aiming angle(deg) sideways across body midline measured from chest forward that the character will try to point. i.e. for rightHanded gun this is the angle left of the midline.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>90.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>180.00</c>.</para>
        /// </remarks>
        public float AcrossLimit
        {
            get => GetArgument("acrossLimit", 90.00f);
            set
            {
                float argumentValue = System.Math.Min(180.00f, System.Math.Max(0.00f, value));
                SetArgument("acrossLimit", argumentValue);
            }
        }

        /// <summary>
        /// Max aiming angle(deg) sideways away from body midline measured from chest forward that the character will try to point. i.e. for rightHanded gun this is the angle right of the midline.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>90.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>180.00</c>.</para>
        /// </remarks>
        public float AwayLimit
        {
            get => GetArgument("awayLimit", 90.00f);
            set
            {
                float argumentValue = System.Math.Min(180.00f, System.Math.Max(0.00f, value));
                SetArgument("awayLimit", argumentValue);
            }
        }

        /// <summary>
        /// Max aiming angle(deg) upwards from body midline measured from chest forward that the character will try to point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>90.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>180.00</c>.</para>
        /// </remarks>
        public float UpLimit
        {
            get => GetArgument("upLimit", 90.00f);
            set
            {
                float argumentValue = System.Math.Min(180.00f, System.Math.Max(0.00f, value));
                SetArgument("upLimit", argumentValue);
            }
        }

        /// <summary>
        /// Max aiming angle(deg) downwards from body midline measured from chest forward that the character will try to point.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>45.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>180.00</c>.</para>
        /// </remarks>
        public float DownLimit
        {
            get => GetArgument("downLimit", 45.00f);
            set
            {
                float argumentValue = System.Math.Min(180.00f, System.Math.Max(0.00f, value));
                SetArgument("downLimit", argumentValue);
            }
        }

        /// <summary>
        /// Pose the rifle hand to reduce complications with collisions. 0 = false, 1 = always when falling, 2 = when falling except if falling backwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int RifleFall
        {
            get => GetArgument("rifleFall", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("rifleFall", argumentValue);
            }
        }

        /// <summary>
        /// Allow supporting of a rifle(or two handed pistol) when falling. 0 = false, 1 = support if allowed, 2 = support until constraint not active (don't allow support to restart), 3 = support until constraint not effective (support hand to support distance must be less than 0.15 - don't allow support to restart).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public int FallingSupport
        {
            get => GetArgument("fallingSupport", 1);
            set
            {
                int argumentValue = System.Math.Min(3, System.Math.Max(0, value));
                SetArgument("fallingSupport", argumentValue);
            }
        }

        /// <summary>
        /// What is considered a fall by fallingSupport). Apply fallingSupport 0=never(will support if allowed), 1 = falling, 2 = falling except if falling backwards, 3 = falling and collided, 4 = falling and collided except if falling backwards, 5 = falling except if falling backwards until collided.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>5</c>.</para>
        /// </remarks>
        public int FallingTypeSupport
        {
            get => GetArgument("fallingTypeSupport", 0);
            set
            {
                int argumentValue = System.Math.Min(5, System.Math.Max(0, value));
                SetArgument("fallingTypeSupport", argumentValue);
            }
        }

        /// <summary>
        /// 0 = byFace, 1=acrossFront, 2=bySide. NB: bySide is not connectible so be careful if combined with kPistol and oneHandedPointing = 0 or 2.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int PistolNeutralType
        {
            get => GetArgument("pistolNeutralType", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("pistolNeutralType", argumentValue);
            }
        }

        /// <summary>
        /// NOT IMPLEMENTED YET KEEP=false - use pointing for neutral targets in pistol modes.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool NeutralPoint4Pistols
        {
            get => GetArgument("neutralPoint4Pistols", false);
            set
            {
                bool argumentValue = value;
                SetArgument("neutralPoint4Pistols", argumentValue);
            }
        }

        /// <summary>
        /// Use pointing for neutral targets in rifle mode.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool NeutralPoint4Rifle
        {
            get => GetArgument("neutralPoint4Rifle", true);
            set
            {
                bool argumentValue = value;
                SetArgument("neutralPoint4Rifle", argumentValue);
            }
        }

        /// <summary>
        /// Check the neutral pointing is pointable, if it isn't then choose a neutral pose instead.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool CheckNeutralPoint
        {
            get => GetArgument("checkNeutralPoint", false);
            set
            {
                bool argumentValue = value;
                SetArgument("checkNeutralPoint", argumentValue);
            }
        }

        /// <summary>
        /// Side, up, back) side is left for left arm, right for right arm mmmmtodo.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>5.00, -5.00, -2.00</c>.</para>
        /// </remarks>
        public Vector3 Point2Side
        {
            get => GetArgument("point2Side", new Vector3(5.00f, -5.00f, -2.00f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("point2Side", argumentValue);
            }
        }

        /// <summary>
        /// Add to weaponDistance for point2Side neutral pointing (to straighten the arm).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1000.00</c>.</para>
        /// </remarks>
        public float Add2WeaponDistSide
        {
            get => GetArgument("add2WeaponDistSide", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1000.00f, System.Math.Max(-1.00f, value));
                SetArgument("add2WeaponDistSide", argumentValue);
            }
        }

        /// <summary>
        /// Side, up, back) side is left for left arm, right for rght arm mmmmtodo.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00, -0.90, -0.20</c>.</para>
        /// </remarks>
        public Vector3 Point2Connect
        {
            get => GetArgument("point2Connect", new Vector3(-1.00f, -0.90f, -0.20f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("point2Connect", argumentValue);
            }
        }

        /// <summary>
        /// Add to weaponDistance for point2Connect neutral pointing (to straighten the arm).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1000.00</c>.</para>
        /// </remarks>
        public float Add2WeaponDistConnect
        {
            get => GetArgument("add2WeaponDistConnect", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1000.00f, System.Math.Max(-1.00f, value));
                SetArgument("add2WeaponDistConnect", argumentValue);
            }
        }

        /// <summary>
        /// Enable new ik for pistol pointing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UsePistolIK
        {
            get => GetArgument("usePistolIK", true);
            set
            {
                bool argumentValue = value;
                SetArgument("usePistolIK", argumentValue);
            }
        }

        /// <summary>
        /// Use spine twist to orient chest?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseSpineTwist
        {
            get => GetArgument("useSpineTwist", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useSpineTwist", argumentValue);
            }
        }

        /// <summary>
        /// Turn balancer to help gun point at target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseTurnToTarget
        {
            get => GetArgument("useTurnToTarget", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useTurnToTarget", argumentValue);
            }
        }

        /// <summary>
        /// Use head look to drive head?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseHeadLook
        {
            get => GetArgument("useHeadLook", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useHeadLook", argumentValue);
            }
        }

        /// <summary>
        /// Angular difference between pointing direction and target direction above which feedback will be generated.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.39260</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.141590</c>.</para>
        /// </remarks>
        public float ErrorThreshold
        {
            get => GetArgument("errorThreshold", 0.39260f);
            set
            {
                float argumentValue = System.Math.Min(3.141590f, System.Math.Max(0.00f, value));
                SetArgument("errorThreshold", argumentValue);
            }
        }

        /// <summary>
        /// Duration of arms relax following firing weapon. NB:This is clamped (0,5) in pointGun.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float FireWeaponRelaxTime
        {
            get => GetArgument("fireWeaponRelaxTime", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("fireWeaponRelaxTime", argumentValue);
            }
        }

        /// <summary>
        /// Relax multiplier following firing weapon. Recovers over relaxTime.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FireWeaponRelaxAmount
        {
            get => GetArgument("fireWeaponRelaxAmount", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.10f, value));
                SetArgument("fireWeaponRelaxAmount", argumentValue);
            }
        }

        /// <summary>
        /// Range of motion for ik-based recoil.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.050</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>0.250</c>.</para>
        /// </remarks>
        public float FireWeaponRelaxDistance
        {
            get => GetArgument("fireWeaponRelaxDistance", 0.050f);
            set
            {
                float argumentValue = System.Math.Min(0.250f, System.Math.Max(0.00f, value));
                SetArgument("fireWeaponRelaxDistance", argumentValue);
            }
        }

        /// <summary>
        /// Use the incoming transforms to inform the pointGun of the primaryWeaponDistance, poleVector for the arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseIncomingTransforms
        {
            get => GetArgument("useIncomingTransforms", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useIncomingTransforms", argumentValue);
            }
        }

        /// <summary>
        /// If useIncomingTransforms = true and measureParentOffset=true then measure the Pointing-from offset from parent effector, using itms - this should point the barrel of the gun to the target. This is added to the rightHandParentOffset. NB NOT used if rightHandParentEffector LT 0.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool MeasureParentOffset
        {
            get => GetArgument("measureParentOffset", true);
            set
            {
                bool argumentValue = value;
                SetArgument("measureParentOffset", argumentValue);
            }
        }

        /// <summary>
        /// Pointing-from offset from parent effector, expressed in spine3's frame, x = back/forward, y = right/left, z = up/down.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 LeftHandParentOffset
        {
            get => GetArgument("leftHandParentOffset", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("leftHandParentOffset", argumentValue);
            }
        }

        /// <summary>
        /// 1 = Use leftShoulder. Effector from which the left hand pointing originates. ie, point from this part to the target. -1 causes default offset for active weapon mode to be applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int LeftHandParentEffector
        {
            get => GetArgument("leftHandParentEffector", -1);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(-1, value));
                SetArgument("leftHandParentEffector", argumentValue);
            }
        }

        /// <summary>
        /// Pointing-from offset from parent effector, expressed in spine3's frame, x = back/forward, y = right/left, z = up/down. This is added to the measured one if useIncomingTransforms=true and measureParentOffset=true. NB NOT used if rightHandParentEffector LT 0. Pistol(0,0,0) Rifle(0.0032, 0.0, -0.0).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 RightHandParentOffset
        {
            get => GetArgument("rightHandParentOffset", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("rightHandParentOffset", argumentValue);
            }
        }

        /// <summary>
        /// 1 = Use rightShoulder.. Effector from which the right hand pointing originates. ie, point from this part to the target. -1 causes default offset for active weapon mode to be applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int RightHandParentEffector
        {
            get => GetArgument("rightHandParentEffector", -1);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(-1, value));
                SetArgument("rightHandParentEffector", argumentValue);
            }
        }

        /// <summary>
        /// Distance from the shoulder to hold the weapon. If -1 and useIncomingTransforms then weaponDistance is read from ITMs. weaponDistance=primaryHandWeaponDistance clamped [0.2f:m_maxArmReach=0.65] if useIncomingTransforms = false. pistol 0.60383, rifle 0.336.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float PrimaryHandWeaponDistance
        {
            get => GetArgument("primaryHandWeaponDistance", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("primaryHandWeaponDistance", argumentValue);
            }
        }

        /// <summary>
        /// Use hard constraint to keep rifle stock against shoulder?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ConstrainRifle
        {
            get => GetArgument("constrainRifle", true);
            set
            {
                bool argumentValue = value;
                SetArgument("constrainRifle", argumentValue);
            }
        }

        /// <summary>
        /// Rifle constraint distance. Deliberately kept large to create a flat constraint surface where rifle meets the shoulder.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// </remarks>
        public float RifleConstraintMinDistance
        {
            get => GetArgument("rifleConstraintMinDistance", 0.20f);
            set
            {
                float argumentValue = System.Math.Max(0.00f, value);
                SetArgument("rifleConstraintMinDistance", argumentValue);
            }
        }

        /// <summary>
        /// Disable collisions between right hand/forearm and the torso/legs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DisableArmCollisions
        {
            get => GetArgument("disableArmCollisions", false);
            set
            {
                bool argumentValue = value;
                SetArgument("disableArmCollisions", argumentValue);
            }
        }

        /// <summary>
        /// Disable collisions between right hand/forearm and spine3/spine2 if in rifle mode.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DisableRifleCollisions
        {
            get => GetArgument("disableRifleCollisions", false);
            set
            {
                bool argumentValue = value;
                SetArgument("disableRifleCollisions", argumentValue);
            }
        }
    }

    /// <summary>
    /// PointGunExtra: Seldom set parameters for pointGun - just to keep number of parameters in any message less than or equal to 64.
    /// </summary>
    public sealed class PointGunExtraHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the PointGunExtra NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public PointGunExtraHelper(Ped ped) : base(ped, "pointGunExtra")
        {
        }

        /// <summary>
        /// For supportConstraint = 2: force constraint strength of the supporting hands - it gets shaky at about 4.0.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float ConstraintStrength
        {
            get => GetArgument("constraintStrength", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("constraintStrength", argumentValue);
            }
        }

        /// <summary>
        /// For supportConstraint = 2: Like makeConstraintDistance. Force starts acting when the hands are LT 3.0*thresh apart but is maximum strength LT thresh. For comparison: 0.1 is used for reachForWound in shot, 0.25 is used in grab.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float ConstraintThresh
        {
            get => GetArgument("constraintThresh", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("constraintThresh", argumentValue);
            }
        }

        /// <summary>
        /// Currently unused - no intoWorldTest. RAGE bit mask to exclude weapons from ray probe - currently defaults to MP3 weapon flag.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1024</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// </remarks>
        public int WeaponMask
        {
            get => GetArgument("weaponMask", 1024);
            set
            {
                int argumentValue = System.Math.Max(0, value);
                SetArgument("weaponMask", argumentValue);
            }
        }

        /// <summary>
        /// Is timeWarpActive enabled?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool TimeWarpActive
        {
            get => GetArgument("timeWarpActive", false);
            set
            {
                bool argumentValue = value;
                SetArgument("timeWarpActive", argumentValue);
            }
        }

        /// <summary>
        /// Scale for arm and helper strength when timewarp is enabled. 1 = normal compensation.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float TimeWarpStrengthScale
        {
            get => GetArgument("timeWarpStrengthScale", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.10f, value));
                SetArgument("timeWarpStrengthScale", argumentValue);
            }
        }

        /// <summary>
        /// Hand stabilization controller stiffness.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float OriStiff
        {
            get => GetArgument("oriStiff", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("oriStiff", argumentValue);
            }
        }

        /// <summary>
        /// Hand stabilization controller damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float OriDamp
        {
            get => GetArgument("oriDamp", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("oriDamp", argumentValue);
            }
        }

        /// <summary>
        /// Hand stabilization controller stiffness.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float PosStiff
        {
            get => GetArgument("posStiff", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("posStiff", argumentValue);
            }
        }

        /// <summary>
        /// Hand stabilization controller damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float PosDamp
        {
            get => GetArgument("posDamp", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("posDamp", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class RollDownStairsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the RollDownStairs NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public RollDownStairsHelper(Ped ped) : base(ped, "rollDownStairs")
        {
        }

        /// <summary>
        /// Effector Stiffness. value feeds through to rollUp directly.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float Stiffness
        {
            get => GetArgument("stiffness", 11.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("stiffness", argumentValue);
            }
        }

        /// <summary>
        /// Effector Damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.4</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float Damping
        {
            get => GetArgument("damping", 1.4f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("damping", argumentValue);
            }
        }

        /// <summary>
        /// Helper force strength. Do not go above 1 for a rollDownStairs/roll along ground reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.55</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float Forcemag
        {
            get => GetArgument("forcemag", 0.55f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("forcemag", argumentValue);
            }
        }

        /// <summary>
        /// The degree to which the character will try to stop a barrel roll with his arms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.9</c>.</para>
        /// <para>Minimum value: <c>-3.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float M_useArmToSlowDown
        {
            get => GetArgument("m_useArmToSlowDown", -1.9f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(-3.0f, value));
                SetArgument("m_useArmToSlowDown", argumentValue);
            }
        }

        /// <summary>
        /// Blends between a zeroPose and the Rollup, Faster the character is rotating the less the zeroPose.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseZeroPose
        {
            get => GetArgument("useZeroPose", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useZeroPose", argumentValue);
            }
        }

        /// <summary>
        /// Applied cheat forces to spin the character when in the air, the forces are 40% of the forces applied when touching the ground. Be careful little bunny rabbits, the character could spin unnaturally in the air.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SpinWhenInAir
        {
            get => GetArgument("spinWhenInAir", false);
            set
            {
                bool argumentValue = value;
                SetArgument("spinWhenInAir", argumentValue);
            }
        }

        /// <summary>
        /// How much the character reaches with his arms to brace against the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.4</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>3.0</c>.</para>
        /// </remarks>
        public float M_armReachAmount
        {
            get => GetArgument("m_armReachAmount", 1.4f);
            set
            {
                float argumentValue = System.Math.Min(3.0f, System.Math.Max(0.0f, value));
                SetArgument("m_armReachAmount", argumentValue);
            }
        }

        /// <summary>
        /// Amount that the legs push outwards when tumbling.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float M_legPush
        {
            get => GetArgument("m_legPush", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("m_legPush", argumentValue);
            }
        }

        /// <summary>
        /// Blends between a zeroPose and the Rollup, Faster the character is rotating the less the zeroPose.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool TryToAvoidHeadButtingGround
        {
            get => GetArgument("tryToAvoidHeadButtingGround", false);
            set
            {
                bool argumentValue = value;
                SetArgument("tryToAvoidHeadButtingGround", argumentValue);
            }
        }

        /// <summary>
        /// The length that the arm reaches and so how much it straightens.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.4</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ArmReachLength
        {
            get => GetArgument("armReachLength", 0.4f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("armReachLength", argumentValue);
            }
        }

        /// <summary>
        /// Pass in a custom direction in to have the character try and roll in that direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 1</c>.</para>
        /// <para>Minimum value: <c>1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public Vector3 CustomRollDir
        {
            get => GetArgument("customRollDir", new Vector3(0.0f, 0.0f, 1.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f));
                SetArgument("customRollDir", argumentValue);
            }
        }

        /// <summary>
        /// Pass in true to use the customRollDir parameter.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseCustomRollDir
        {
            get => GetArgument("useCustomRollDir", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useCustomRollDir", argumentValue);
            }
        }

        /// <summary>
        /// The target linear velocity used to start the rolling.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>9.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float StiffnessDecayTarget
        {
            get => GetArgument("stiffnessDecayTarget", 9.0f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("stiffnessDecayTarget", argumentValue);
            }
        }

        /// <summary>
        /// Time, in seconds, to decay stiffness down to the stiffnessDecayTarget value (or -1 to disable).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float StiffnessDecayTime
        {
            get => GetArgument("stiffnessDecayTime", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(-1.0f, value));
                SetArgument("stiffnessDecayTime", argumentValue);
            }
        }

        /// <summary>
        /// 0 is no leg asymmetry in 'foetal' position. greater than 0 a asymmetricalLegs-rand(30%), added/minus each joint of the legs in radians. Random number changes about once every roll. 0.4 gives a lot of asymmetry.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float AsymmetricalLegs
        {
            get => GetArgument("asymmetricalLegs", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("asymmetricalLegs", argumentValue);
            }
        }

        /// <summary>
        /// Tries to reduce the spin around the z axis. Scale 0 - 1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ZAxisSpinReduction
        {
            get => GetArgument("zAxisSpinReduction", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("zAxisSpinReduction", argumentValue);
            }
        }

        /// <summary>
        /// Time for the targetlinearVelocity to decay to zero.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float TargetLinearVelocityDecayTime
        {
            get => GetArgument("targetLinearVelocityDecayTime", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("targetLinearVelocityDecayTime", argumentValue);
            }
        }

        /// <summary>
        /// Helper torques are applied to match the spin of the character to the max of targetLinearVelocity and COMVelMag.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float TargetLinearVelocity
        {
            get => GetArgument("targetLinearVelocity", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("targetLinearVelocity", argumentValue);
            }
        }

        /// <summary>
        /// Don't use rollup if true.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool OnlyApplyHelperForces
        {
            get => GetArgument("onlyApplyHelperForces", false);
            set
            {
                bool argumentValue = value;
                SetArgument("onlyApplyHelperForces", argumentValue);
            }
        }

        /// <summary>
        /// Scale applied cheat forces/torques to (zero) if object underneath character has velocity greater than 1.f.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseVelocityOfObjectBelow
        {
            get => GetArgument("useVelocityOfObjectBelow", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useVelocityOfObjectBelow", argumentValue);
            }
        }

        /// <summary>
        /// UseVelocityOfObjectBelow uses a relative velocity of the character to the object underneath.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseRelativeVelocity
        {
            get => GetArgument("useRelativeVelocity", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useRelativeVelocity", argumentValue);
            }
        }

        /// <summary>
        /// If true, use rollup for upper body and a kind of foetal behavior for legs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ApplyFoetalToLegs
        {
            get => GetArgument("applyFoetalToLegs", false);
            set
            {
                bool argumentValue = value;
                SetArgument("applyFoetalToLegs", argumentValue);
            }
        }

        /// <summary>
        /// Only used if applyFoetalToLegs = true : define the variation of angles for the joints of the legs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float MovementLegsInFoetalPosition
        {
            get => GetArgument("movementLegsInFoetalPosition", 1.30f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("movementLegsInFoetalPosition", argumentValue);
            }
        }

        /// <summary>
        /// Only used if applyNewRollingCheatingTorques or applyHelPerTorqueToAlign defined to true : maximal angular velocity around frontward axis of the pelvis to apply cheating torques.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float MaxAngVelAroundFrontwardAxis
        {
            get => GetArgument("maxAngVelAroundFrontwardAxis", 2.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(-1.0f, value));
                SetArgument("maxAngVelAroundFrontwardAxis", argumentValue);
            }
        }

        /// <summary>
        /// Only used if applyNewRollingCheatingTorques or applyHelPerTorqueToAlign defined to true : minimal angular velocity of the roll to apply cheating torques.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float MinAngVel
        {
            get => GetArgument("minAngVel", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("minAngVel", argumentValue);
            }
        }

        /// <summary>
        /// If true will use the new way to apply cheating torques (like in fallOverWall), otherwise will use the old way.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ApplyNewRollingCheatingTorques
        {
            get => GetArgument("applyNewRollingCheatingTorques", false);
            set
            {
                bool argumentValue = value;
                SetArgument("applyNewRollingCheatingTorques", argumentValue);
            }
        }

        /// <summary>
        /// Only used if applyNewRollingCheatingTorques defined to true : maximal angular velocity of the roll to apply cheating torque.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>5.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float MaxAngVel
        {
            get => GetArgument("maxAngVel", 5.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("maxAngVel", argumentValue);
            }
        }

        /// <summary>
        /// Only used if applyNewRollingCheatingTorques defined to true : magnitude of the torque to roll down the stairs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>50.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>500.0</c>.</para>
        /// </remarks>
        public float MagOfTorqueToRoll
        {
            get => GetArgument("magOfTorqueToRoll", 50.0f);
            set
            {
                float argumentValue = System.Math.Min(500.0f, System.Math.Max(0.0f, value));
                SetArgument("magOfTorqueToRoll", argumentValue);
            }
        }

        /// <summary>
        /// Apply torque to align the body orthogonally to the direction of the roll.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ApplyHelPerTorqueToAlign
        {
            get => GetArgument("applyHelPerTorqueToAlign", false);
            set
            {
                bool argumentValue = value;
                SetArgument("applyHelPerTorqueToAlign", argumentValue);
            }
        }

        /// <summary>
        /// Only used if applyHelPerTorqueToAlign defined to true : delay to start to apply torques.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.2</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float DelayToAlignBody
        {
            get => GetArgument("delayToAlignBody", 0.2f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("delayToAlignBody", argumentValue);
            }
        }

        /// <summary>
        /// Only used if applyHelPerTorqueToAlign defined to true : magnitude of the torque to align orthogonally the body.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>50.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>500.0</c>.</para>
        /// </remarks>
        public float MagOfTorqueToAlign
        {
            get => GetArgument("magOfTorqueToAlign", 50.0f);
            set
            {
                float argumentValue = System.Math.Min(500.0f, System.Math.Max(0.0f, value));
                SetArgument("magOfTorqueToAlign", argumentValue);
            }
        }

        /// <summary>
        /// Ordinarily keep at 0.85. Make this lower if you want spinning in the air.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.85</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float AirborneReduction
        {
            get => GetArgument("airborneReduction", 0.85f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("airborneReduction", argumentValue);
            }
        }

        /// <summary>
        /// Pass-through to Roll Up. Controls whether or not behavior enforces min/max friction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ApplyMinMaxFriction
        {
            get => GetArgument("applyMinMaxFriction", true);
            set
            {
                bool argumentValue = value;
                SetArgument("applyMinMaxFriction", argumentValue);
            }
        }

        /// <summary>
        /// Scale zAxisSpinReduction back when rotating end-over-end (somersault) to give the body a chance to align with the axis of rotation.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool LimitSpinReduction
        {
            get => GetArgument("limitSpinReduction", false);
            set
            {
                bool argumentValue = value;
                SetArgument("limitSpinReduction", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ShotHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the Shot NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotHelper(Ped ped) : base(ped, "shot")
        {
        }

        /// <summary>
        /// Stiffness of body. Feeds through to roll_up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float BodyStiffness
        {
            get => GetArgument("bodyStiffness", 11.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(6.00f, value));
                SetArgument("bodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of body. Feeds through to roll_up.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float SpineDamping
        {
            get => GetArgument("spineDamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.10f, value));
                SetArgument("spineDamping", argumentValue);
            }
        }

        /// <summary>
        /// Arm stiffness.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float ArmStiffness
        {
            get => GetArgument("armStiffness", 10.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(6.00f, value));
                SetArgument("armStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Initial stiffness of neck after being shot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>14.00</c>.</para>
        /// <para>Minimum value: <c>3.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float InitialNeckStiffness
        {
            get => GetArgument("initialNeckStiffness", 14.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(3.00f, value));
                SetArgument("initialNeckStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Intial damping of neck after being shot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float InitialNeckDamping
        {
            get => GetArgument("initialNeckDamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.10f, value));
                SetArgument("initialNeckDamping", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of neck.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>14.00</c>.</para>
        /// <para>Minimum value: <c>3.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float NeckStiffness
        {
            get => GetArgument("neckStiffness", 14.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(3.00f, value));
                SetArgument("neckStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping of neck.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float NeckDamping
        {
            get => GetArgument("neckDamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.10f, value));
                SetArgument("neckDamping", argumentValue);
            }
        }

        /// <summary>
        /// How much to add to upperbody stiffness dependent on looseness.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float KMultOnLoose
        {
            get => GetArgument("kMultOnLoose", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("kMultOnLoose", argumentValue);
            }
        }

        /// <summary>
        /// How much to add to leg stiffnesses dependent on looseness.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float KMult4Legs
        {
            get => GetArgument("kMult4Legs", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("kMult4Legs", argumentValue);
            }
        }

        /// <summary>
        /// How loose the character is made by a newBullet. between 0 and 1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LoosenessAmount
        {
            get => GetArgument("loosenessAmount", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("loosenessAmount", argumentValue);
            }
        }

        /// <summary>
        /// How loose the character is made by a newBullet if falling.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Looseness4Fall
        {
            get => GetArgument("looseness4Fall", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("looseness4Fall", argumentValue);
            }
        }

        /// <summary>
        /// How loose the upperBody of the character is made by a newBullet if staggerFall is running (and not falling). Note atm the neck ramp values are ignored in staggerFall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Looseness4Stagger
        {
            get => GetArgument("looseness4Stagger", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("looseness4Stagger", argumentValue);
            }
        }

        /// <summary>
        /// Minimum looseness to apply to the arms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float MinArmsLooseness
        {
            get => GetArgument("minArmsLooseness", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("minArmsLooseness", argumentValue);
            }
        }

        /// <summary>
        /// Minimum looseness to apply to the Legs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float MinLegsLooseness
        {
            get => GetArgument("minLegsLooseness", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("minLegsLooseness", argumentValue);
            }
        }

        /// <summary>
        /// How long to hold for before returning to relaxed arm position.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float GrabHoldTime
        {
            get => GetArgument("grabHoldTime", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("grabHoldTime", argumentValue);
            }
        }

        /// <summary>
        /// True: spine is blended with zero pose, false: spine is blended with zero pose if not setting exag or cpain.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SpineBlendExagCPain
        {
            get => GetArgument("spineBlendExagCPain", false);
            set
            {
                bool argumentValue = value;
                SetArgument("spineBlendExagCPain", argumentValue);
            }
        }

        /// <summary>
        /// Spine is always blended with zero pose this much and up to 1 as the character become stationary. If negative no blend is ever applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>-0.10</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float SpineBlendZero
        {
            get => GetArgument("spineBlendZero", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-0.10f, value));
                SetArgument("spineBlendZero", argumentValue);
            }
        }

        /// <summary>
        /// Looseness applied to spine is different if bulletProofVest is true.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool BulletProofVest
        {
            get => GetArgument("bulletProofVest", false);
            set
            {
                bool argumentValue = value;
                SetArgument("bulletProofVest", argumentValue);
            }
        }

        /// <summary>
        /// Looseness always reset on shotNewBullet even if previous looseness ramp still running. Except for the neck which has it's own ramp.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool AlwaysResetLooseness
        {
            get => GetArgument("alwaysResetLooseness", true);
            set
            {
                bool argumentValue = value;
                SetArgument("alwaysResetLooseness", argumentValue);
            }
        }

        /// <summary>
        /// Neck looseness always reset on shotNewBullet even if previous looseness ramp still running.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool AlwaysResetNeckLooseness
        {
            get => GetArgument("alwaysResetNeckLooseness", true);
            set
            {
                bool argumentValue = value;
                SetArgument("alwaysResetNeckLooseness", argumentValue);
            }
        }

        /// <summary>
        /// How much to scale the angular velocity coming in from animation of a part if it is in angVelScaleMask (otherwise scale by 1.0).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float AngVelScale
        {
            get => GetArgument("angVelScale", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("angVelScale", argumentValue);
            }
        }

        /// <summary>
        /// Parts to scale the initial angular velocity by angVelScale (otherwize scale by 1.0).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>fb</c>.</para>
        /// </remarks>
        public string AngVelScaleMask
        {
            get => GetArgument("angVelScaleMask", "fb");
            set
            {
                string argumentValue = value;
                SetArgument("angVelScaleMask", argumentValue);
            }
        }

        /// <summary>
        /// Width of the fling behavior.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FlingWidth
        {
            get => GetArgument("flingWidth", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("flingWidth", argumentValue);
            }
        }

        /// <summary>
        /// Duration of the fling behavior.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FlingTime
        {
            get => GetArgument("flingTime", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("flingTime", argumentValue);
            }
        }

        /// <summary>
        /// Time, in seconds, before the character begins to grab for the wound on the first hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float TimeBeforeReachForWound
        {
            get => GetArgument("timeBeforeReachForWound", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("timeBeforeReachForWound", argumentValue);
            }
        }

        /// <summary>
        /// Exaggerate bullet duration (at exagMag/exagTwistMag).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ExagDuration
        {
            get => GetArgument("exagDuration", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("exagDuration", argumentValue);
            }
        }

        /// <summary>
        /// Exaggerate bullet spine Lean magnitude.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ExagMag
        {
            get => GetArgument("exagMag", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("exagMag", argumentValue);
            }
        }

        /// <summary>
        /// Exaggerate bullet spine Twist magnitude.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ExagTwistMag
        {
            get => GetArgument("exagTwistMag", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("exagTwistMag", argumentValue);
            }
        }

        /// <summary>
        /// Exaggerate bullet duration ramping to zero after exagDuration.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ExagSmooth2Zero
        {
            get => GetArgument("exagSmooth2Zero", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("exagSmooth2Zero", argumentValue);
            }
        }

        /// <summary>
        /// Exaggerate bullet time spent at 0 spine lean/twist after exagDuration + exagSmooth2Zero.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ExagZeroTime
        {
            get => GetArgument("exagZeroTime", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("exagZeroTime", argumentValue);
            }
        }

        /// <summary>
        /// Conscious pain duration ramping from zero to cpainMag/cpainTwistMag.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float CpainSmooth2Time
        {
            get => GetArgument("cpainSmooth2Time", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("cpainSmooth2Time", argumentValue);
            }
        }

        /// <summary>
        /// Conscious pain duration at cpainMag/cpainTwistMag after cpainSmooth2Time.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float CpainDuration
        {
            get => GetArgument("cpainDuration", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("cpainDuration", argumentValue);
            }
        }

        /// <summary>
        /// Conscious pain spine Lean(back/Forward) magnitude (Replaces spinePainMultiplier).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float CpainMag
        {
            get => GetArgument("cpainMag", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.0f, value));
                SetArgument("cpainMag", argumentValue);
            }
        }

        /// <summary>
        /// Conscious pain spine Twist/Lean2Side magnitude Replaces spinePainTwistMultiplier).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float CpainTwistMag
        {
            get => GetArgument("cpainTwistMag", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("cpainTwistMag", argumentValue);
            }
        }

        /// <summary>
        /// Conscious pain ramping to zero after cpainSmooth2Time + cpainDuration (Replaces spinePainTime).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float CpainSmooth2Zero
        {
            get => GetArgument("cpainSmooth2Zero", 1.50f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("cpainSmooth2Zero", argumentValue);
            }
        }

        /// <summary>
        /// Is the guy crouching or not.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Crouching
        {
            get => GetArgument("crouching", false);
            set
            {
                bool argumentValue = value;
                SetArgument("crouching", argumentValue);
            }
        }

        /// <summary>
        /// Type of reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ChickenArms
        {
            get => GetArgument("chickenArms", false);
            set
            {
                bool argumentValue = value;
                SetArgument("chickenArms", argumentValue);
            }
        }

        /// <summary>
        /// Type of reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ReachForWound
        {
            get => GetArgument("reachForWound", true);
            set
            {
                bool argumentValue = value;
                SetArgument("reachForWound", argumentValue);
            }
        }

        /// <summary>
        /// Type of reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Fling
        {
            get => GetArgument("fling", false);
            set
            {
                bool argumentValue = value;
                SetArgument("fling", argumentValue);
            }
        }

        /// <summary>
        /// Injured arm code runs if arm hit (turns and steps and bends injured arm).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AllowInjuredArm
        {
            get => GetArgument("allowInjuredArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("allowInjuredArm", argumentValue);
            }
        }

        /// <summary>
        /// When false injured leg is not bent and character does not bend to reach it.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool AllowInjuredLeg
        {
            get => GetArgument("allowInjuredLeg", true);
            set
            {
                bool argumentValue = value;
                SetArgument("allowInjuredLeg", argumentValue);
            }
        }

        /// <summary>
        /// When false don't try to reach for injured Lower Legs (shins/feet).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AllowInjuredLowerLegReach
        {
            get => GetArgument("allowInjuredLowerLegReach", false);
            set
            {
                bool argumentValue = value;
                SetArgument("allowInjuredLowerLegReach", argumentValue);
            }
        }

        /// <summary>
        /// When false don't try to reach for injured Thighs.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool AllowInjuredThighReach
        {
            get => GetArgument("allowInjuredThighReach", true);
            set
            {
                bool argumentValue = value;
                SetArgument("allowInjuredThighReach", argumentValue);
            }
        }

        /// <summary>
        /// Additional stability for hands and neck (less loose).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool StableHandsAndNeck
        {
            get => GetArgument("stableHandsAndNeck", false);
            set
            {
                bool argumentValue = value;
                SetArgument("stableHandsAndNeck", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets melee.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Melee
        {
            get => GetArgument("melee", false);
            set
            {
                bool argumentValue = value;
                SetArgument("melee", argumentValue);
            }
        }

        /// <summary>
        /// 0=Rollup, 1=Catchfall, 2=rollDownStairs, 3=smartFall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public int FallingReaction
        {
            get => GetArgument("fallingReaction", 0);
            set
            {
                int argumentValue = System.Math.Min(3, System.Math.Max(0, value));
                SetArgument("fallingReaction", argumentValue);
            }
        }

        /// <summary>
        /// Keep the character active instead of relaxing at the end of the catch fall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseExtendedCatchFall
        {
            get => GetArgument("useExtendedCatchFall", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useExtendedCatchFall", argumentValue);
            }
        }

        /// <summary>
        /// Duration for which the character's upper body stays at minimum stiffness (not quite zero).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float InitialWeaknessZeroDuration
        {
            get => GetArgument("initialWeaknessZeroDuration", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("initialWeaknessZeroDuration", argumentValue);
            }
        }

        /// <summary>
        /// Duration of the ramp to bring the character's upper body stiffness back to normal levels.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float InitialWeaknessRampDuration
        {
            get => GetArgument("initialWeaknessRampDuration", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("initialWeaknessRampDuration", argumentValue);
            }
        }

        /// <summary>
        /// Duration for which the neck stays at intial stiffness/damping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float InitialNeckDuration
        {
            get => GetArgument("initialNeckDuration", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("initialNeckDuration", argumentValue);
            }
        }

        /// <summary>
        /// Duration of the ramp to bring the neck stiffness/damping back to normal levels.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float InitialNeckRampDuration
        {
            get => GetArgument("initialNeckRampDuration", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("initialNeckRampDuration", argumentValue);
            }
        }

        /// <summary>
        /// If enabled upper and lower body strength scales with character strength, using the range given by parameters below.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseCStrModulation
        {
            get => GetArgument("useCStrModulation", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useCStrModulation", argumentValue);
            }
        }

        /// <summary>
        /// Proportions to what the strength would be normally.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CStrUpperMin
        {
            get => GetArgument("cStrUpperMin", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.10f, value));
                SetArgument("cStrUpperMin", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets cStrUpperMax.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CStrUpperMax
        {
            get => GetArgument("cStrUpperMax", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.10f, value));
                SetArgument("cStrUpperMax", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets cStrLowerMin.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CStrLowerMin
        {
            get => GetArgument("cStrLowerMin", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.10f, value));
                SetArgument("cStrLowerMin", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets cStrLowerMax.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.10</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CStrLowerMax
        {
            get => GetArgument("cStrLowerMax", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.10f, value));
                SetArgument("cStrLowerMax", argumentValue);
            }
        }

        /// <summary>
        /// Time to death (HACK for underwater). If -ve don't ever die.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1000.0</c>.</para>
        /// </remarks>
        public float DeathTime
        {
            get => GetArgument("deathTime", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(1000.0f, System.Math.Max(-1.0f, value));
                SetArgument("deathTime", argumentValue);
            }
        }
    }

    /// <summary>
    /// ShotNewBullet: Send new wound information to the shot. Can cause shot to restart it's performance in part or in whole.
    /// </summary>
    public sealed class ShotNewBulletHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ShotNewBullet NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotNewBulletHelper(Ped ped) : base(ped, "shotNewBullet")
        {
        }

        /// <summary>
        /// Part ID on the body where the bullet hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>21</c>.</para>
        /// </remarks>
        public int BodyPart
        {
            get => GetArgument("bodyPart", 0);
            set
            {
                int argumentValue = System.Math.Min(21, System.Math.Max(0, value));
                SetArgument("bodyPart", argumentValue);
            }
        }

        /// <summary>
        /// If true then normal and hitPoint should be supplied in local coordinates of bodyPart. If false then normal and hitPoint should be supplied in World coordinates.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool LocalHitPointInfo
        {
            get => GetArgument("localHitPointInfo", true);
            set
            {
                bool argumentValue = value;
                SetArgument("localHitPointInfo", argumentValue);
            }
        }

        /// <summary>
        /// Normal coming out of impact point on character. Can be local or global depending on localHitPointInfo.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, -1</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public Vector3 Normal
        {
            get => GetArgument("normal", new Vector3(0.0f, 0.0f, -1.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-1.0f, -1.0f, -1.0f), new Vector3(1.0f, 1.0f, 1.0f));
                SetArgument("normal", argumentValue);
            }
        }

        /// <summary>
        /// Position of impact on character. Can be local or global depending on localHitPointInfo.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 HitPoint
        {
            get => GetArgument("hitPoint", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("hitPoint", argumentValue);
            }
        }

        /// <summary>
        /// Bullet velocity in world coordinates.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// <para>Minimum value: <c>-2000.0</c>.</para>
        /// <para>Maximum value: <c>2000.0</c>.</para>
        /// </remarks>
        public Vector3 BulletVel
        {
            get => GetArgument("bulletVel", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(-2000.0f, -2000.0f, -2000.0f), new Vector3(2000.0f, 2000.0f, 2000.0f));
                SetArgument("bulletVel", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ShotSnapHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ShotSnap NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotSnapHelper(Ped ped) : base(ped, "shotSnap")
        {
        }

        /// <summary>
        /// Add a Snap to shot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Snap
        {
            get => GetArgument("snap", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snap", argumentValue);
            }
        }

        /// <summary>
        /// The magnitude of the reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>-10.00</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float SnapMag
        {
            get => GetArgument("snapMag", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(-10.00f, value));
                SetArgument("snapMag", argumentValue);
            }
        }

        /// <summary>
        /// MovingMult*snapMag = The magnitude of the reaction if moving(comVelMag) faster than movingThresh.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float SnapMovingMult
        {
            get => GetArgument("snapMovingMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("snapMovingMult", argumentValue);
            }
        }

        /// <summary>
        /// BalancingMult*snapMag = The magnitude of the reaction if balancing = (not lying on the floor/ not upper body not collided) and not airborne.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float SnapBalancingMult
        {
            get => GetArgument("snapBalancingMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("snapBalancingMult", argumentValue);
            }
        }

        /// <summary>
        /// AirborneMult*snapMag = The magnitude of the reaction if airborne.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float SnapAirborneMult
        {
            get => GetArgument("snapAirborneMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("snapAirborneMult", argumentValue);
            }
        }

        /// <summary>
        /// If moving(comVelMag) faster than movingThresh then mvingMult applied to stunMag.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float SnapMovingThresh
        {
            get => GetArgument("snapMovingThresh", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("snapMovingThresh", argumentValue);
            }
        }

        /// <summary>
        /// The character snaps in a prescribed way (decided by bullet direction) - Higher the value the more random this direction is.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float SnapDirectionRandomness
        {
            get => GetArgument("snapDirectionRandomness", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.00f, value));
                SetArgument("snapDirectionRandomness", argumentValue);
            }
        }

        /// <summary>
        /// Snap the leftArm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapLeftArm
        {
            get => GetArgument("snapLeftArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapLeftArm", argumentValue);
            }
        }

        /// <summary>
        /// Snap the rightArm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapRightArm
        {
            get => GetArgument("snapRightArm", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapRightArm", argumentValue);
            }
        }

        /// <summary>
        /// Snap the leftLeg.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapLeftLeg
        {
            get => GetArgument("snapLeftLeg", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapLeftLeg", argumentValue);
            }
        }

        /// <summary>
        /// Snap the rightLeg.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapRightLeg
        {
            get => GetArgument("snapRightLeg", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapRightLeg", argumentValue);
            }
        }

        /// <summary>
        /// Snap the spine.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SnapSpine
        {
            get => GetArgument("snapSpine", true);
            set
            {
                bool argumentValue = value;
                SetArgument("snapSpine", argumentValue);
            }
        }

        /// <summary>
        /// Snap the neck.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SnapNeck
        {
            get => GetArgument("snapNeck", true);
            set
            {
                bool argumentValue = value;
                SetArgument("snapNeck", argumentValue);
            }
        }

        /// <summary>
        /// Legs are either in phase with each other or not.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SnapPhasedLegs
        {
            get => GetArgument("snapPhasedLegs", true);
            set
            {
                bool argumentValue = value;
                SetArgument("snapPhasedLegs", argumentValue);
            }
        }

        /// <summary>
        /// Type of hip reaction 0=none, 1=side2side 2=steplike.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int SnapHipType
        {
            get => GetArgument("snapHipType", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("snapHipType", argumentValue);
            }
        }

        /// <summary>
        /// Legs are either in phase with each other or not.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SnapUseBulletDir
        {
            get => GetArgument("snapUseBulletDir", true);
            set
            {
                bool argumentValue = value;
                SetArgument("snapUseBulletDir", argumentValue);
            }
        }

        /// <summary>
        /// Snap only around the wounded part//mmmmtodo check whether bodyPart doesn't have to be remembered for unSnap.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool SnapHitPart
        {
            get => GetArgument("snapHitPart", false);
            set
            {
                bool argumentValue = value;
                SetArgument("snapHitPart", argumentValue);
            }
        }

        /// <summary>
        /// Interval before applying reverse snap.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.010</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public float UnSnapInterval
        {
            get => GetArgument("unSnapInterval", 0.010f);
            set
            {
                float argumentValue = System.Math.Min(100.0f, System.Math.Max(0.00f, value));
                SetArgument("unSnapInterval", argumentValue);
            }
        }

        /// <summary>
        /// The magnitude of the reverse snap.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public float UnSnapRatio
        {
            get => GetArgument("unSnapRatio", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(100.0f, System.Math.Max(0.00f, value));
                SetArgument("unSnapRatio", argumentValue);
            }
        }

        /// <summary>
        /// Use torques to make the snap otherwise use a change in the parts angular velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool SnapUseTorques
        {
            get => GetArgument("snapUseTorques", true);
            set
            {
                bool argumentValue = value;
                SetArgument("snapUseTorques", argumentValue);
            }
        }
    }

    /// <summary>
    /// ShotShockSpin: configure the shockSpin effect in shot. Spin/Lift the character using cheat torques/forces.
    /// </summary>
    public sealed class ShotShockSpinHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ShotShockSpin NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotShockSpinHelper(Ped ped) : base(ped, "shotShockSpin")
        {
        }

        /// <summary>
        /// If enabled, add a short 'shock' of torque to the character's spine to exaggerate bullet impact.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AddShockSpin
        {
            get => GetArgument("addShockSpin", false);
            set
            {
                bool argumentValue = value;
                SetArgument("addShockSpin", argumentValue);
            }
        }

        /// <summary>
        /// For use with close-range shotgun blasts, or similar.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool RandomizeShockSpinDirection
        {
            get => GetArgument("randomizeShockSpinDirection", false);
            set
            {
                bool argumentValue = value;
                SetArgument("randomizeShockSpinDirection", argumentValue);
            }
        }

        /// <summary>
        /// If true, apply the shock spin no matter which body component was hit. otherwise only apply if the spine or clavicles get hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AlwaysAddShockSpin
        {
            get => GetArgument("alwaysAddShockSpin", false);
            set
            {
                bool argumentValue = value;
                SetArgument("alwaysAddShockSpin", argumentValue);
            }
        }

        /// <summary>
        /// Minimum amount of torque to add if using shock-spin feature.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>50.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1000.0</c>.</para>
        /// </remarks>
        public float ShockSpinMin
        {
            get => GetArgument("shockSpinMin", 50.0f);
            set
            {
                float argumentValue = System.Math.Min(1000.0f, System.Math.Max(0.0f, value));
                SetArgument("shockSpinMin", argumentValue);
            }
        }

        /// <summary>
        /// Maxiumum amount of torque to add if using shock-spin feature.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>90.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1000.0</c>.</para>
        /// </remarks>
        public float ShockSpinMax
        {
            get => GetArgument("shockSpinMax", 90.0f);
            set
            {
                float argumentValue = System.Math.Min(1000.0f, System.Math.Max(0.0f, value));
                SetArgument("shockSpinMax", argumentValue);
            }
        }

        /// <summary>
        /// If greater than 0, apply a force to lift the character up while the torque is applied, trying to produce a dramatic spun/twist shotgun-to-the-chest effect. this is a scale of the torque applied, so 8.0 or so would give a reasonable amount of lift.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ShockSpinLiftForceMult
        {
            get => GetArgument("shockSpinLiftForceMult", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("shockSpinLiftForceMult", argumentValue);
            }
        }

        /// <summary>
        /// Multiplier used when decaying torque spin over time.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float ShockSpinDecayMult
        {
            get => GetArgument("shockSpinDecayMult", 4.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("shockSpinDecayMult", argumentValue);
            }
        }

        /// <summary>
        /// Torque applied is scaled by this amount across the spine components - spine2 recieving the full amount, then 3 and 1 and finally 0. each time, this value is used to scale it down. 0.5 means half the torque each time.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ShockSpinScalePerComponent
        {
            get => GetArgument("shockSpinScalePerComponent", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("shockSpinScalePerComponent", argumentValue);
            }
        }

        /// <summary>
        /// Shock spin ends when twist velocity is greater than this value (try 6.0). If set to -1 does not stop.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>200.0</c>.</para>
        /// </remarks>
        public float ShockSpinMaxTwistVel
        {
            get => GetArgument("shockSpinMaxTwistVel", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(200.0f, System.Math.Max(-1.0f, value));
                SetArgument("shockSpinMaxTwistVel", argumentValue);
            }
        }

        /// <summary>
        /// Shock spin scales by lever arm of bullet i.e. bullet impact point to centre line.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ShockSpinScaleByLeverArm
        {
            get => GetArgument("shockSpinScaleByLeverArm", true);
            set
            {
                bool argumentValue = value;
                SetArgument("shockSpinScaleByLeverArm", argumentValue);
            }
        }

        /// <summary>
        /// ShockSpin's torque is multipied by this value when both the character's feet are not in contact.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ShockSpinAirMult
        {
            get => GetArgument("shockSpinAirMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("shockSpinAirMult", argumentValue);
            }
        }

        /// <summary>
        /// ShockSpin's torque is multipied by this value when the one of the character's feet are not in contact.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ShockSpin1FootMult
        {
            get => GetArgument("shockSpin1FootMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("shockSpin1FootMult", argumentValue);
            }
        }

        /// <summary>
        /// ShockSpin scales the torques applied to the feet by footSlipCompensation.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float ShockSpinFootGripMult
        {
            get => GetArgument("shockSpinFootGripMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("shockSpinFootGripMult", argumentValue);
            }
        }

        /// <summary>
        /// If shot on a side with a forward foot and both feet are on the ground and balanced, increase the shockspin to compensate for the balancer naturally resisting spin to that side.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>1.0</c>.</para>
        /// <para>Maximum value: <c>5.0</c>.</para>
        /// </remarks>
        public float BracedSideSpinMult
        {
            get => GetArgument("bracedSideSpinMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(5.0f, System.Math.Max(1.0f, value));
                SetArgument("bracedSideSpinMult", argumentValue);
            }
        }
    }

    /// <summary>
    /// ShotFallToKnees: configure the fall to knees shot.
    /// </summary>
    public sealed class ShotFallToKneesHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ShotFallToKnees NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotFallToKneesHelper(Ped ped) : base(ped, "shotFallToKnees")
        {
        }

        /// <summary>
        /// Type of reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FallToKnees
        {
            get => GetArgument("fallToKnees", false);
            set
            {
                bool argumentValue = value;
                SetArgument("fallToKnees", argumentValue);
            }
        }

        /// <summary>
        /// Always change fall behavior. If false only change when falling forward.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FtkAlwaysChangeFall
        {
            get => GetArgument("ftkAlwaysChangeFall", false);
            set
            {
                bool argumentValue = value;
                SetArgument("ftkAlwaysChangeFall", argumentValue);
            }
        }

        /// <summary>
        /// How long the balancer runs for before fallToKnees starts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float FtkBalanceTime
        {
            get => GetArgument("ftkBalanceTime", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("ftkBalanceTime", argumentValue);
            }
        }

        /// <summary>
        /// Hip helper force magnitude - to help character lean over balance point of line between toes.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>200.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2000.00</c>.</para>
        /// </remarks>
        public float FtkHelperForce
        {
            get => GetArgument("ftkHelperForce", 200.0f);
            set
            {
                float argumentValue = System.Math.Min(2000.00f, System.Math.Max(0.00f, value));
                SetArgument("ftkHelperForce", argumentValue);
            }
        }

        /// <summary>
        /// Helper force applied to spine3 aswell.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool FtkHelperForceOnSpine
        {
            get => GetArgument("ftkHelperForceOnSpine", true);
            set
            {
                bool argumentValue = value;
                SetArgument("ftkHelperForceOnSpine", argumentValue);
            }
        }

        /// <summary>
        /// Help balancer lean amount - to help character lean over balance point of line between toes. Half of this is also applied as hipLean.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.050</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>0.30</c>.</para>
        /// </remarks>
        public float FtkLeanHelp
        {
            get => GetArgument("ftkLeanHelp", 0.050f);
            set
            {
                float argumentValue = System.Math.Min(0.30f, System.Math.Max(0.00f, value));
                SetArgument("ftkLeanHelp", argumentValue);
            }
        }

        /// <summary>
        /// Bend applied to spine when falling from knees. (+ve forward - try -0.1) (only if rds called).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.00</c>.</para>
        /// <para>Minimum value: <c>-0.20</c>.</para>
        /// <para>Maximum value: <c>0.30</c>.</para>
        /// </remarks>
        public float FtkSpineBend
        {
            get => GetArgument("ftkSpineBend", -0.00f);
            set
            {
                float argumentValue = System.Math.Min(0.30f, System.Math.Max(-0.20f, value));
                SetArgument("ftkSpineBend", argumentValue);
            }
        }

        /// <summary>
        /// Stiffen spine when falling from knees (only if rds called).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FtkStiffSpine
        {
            get => GetArgument("ftkStiffSpine", false);
            set
            {
                bool argumentValue = value;
                SetArgument("ftkStiffSpine", argumentValue);
            }
        }

        /// <summary>
        /// Looseness (muscleStiffness = 1.01f - m_parameters.ftkImpactLooseness) applied to upperBody on knee impacts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float FtkImpactLooseness
        {
            get => GetArgument("ftkImpactLooseness", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.00f, value));
                SetArgument("ftkImpactLooseness", argumentValue);
            }
        }

        /// <summary>
        /// Time that looseness is applied after knee impacts.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>-0.10</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FtkImpactLoosenessTime
        {
            get => GetArgument("ftkImpactLoosenessTime", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-0.10f, value));
                SetArgument("ftkImpactLoosenessTime", argumentValue);
            }
        }

        /// <summary>
        /// Rate at which the legs are bent to go from standing to on knees.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>4.00</c>.</para>
        /// </remarks>
        public float FtkBendRate
        {
            get => GetArgument("ftkBendRate", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(4.00f, System.Math.Max(0.00f, value));
                SetArgument("ftkBendRate", argumentValue);
            }
        }

        /// <summary>
        /// Blend from current hip to balancing on knees hip angle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FtkHipBlend
        {
            get => GetArgument("ftkHipBlend", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("ftkHipBlend", argumentValue);
            }
        }

        /// <summary>
        /// Probability that a lunge reaction will be allowed.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FtkLungeProb
        {
            get => GetArgument("ftkLungeProb", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("ftkLungeProb", argumentValue);
            }
        }

        /// <summary>
        /// When on knees allow some spinning of the character. If false then the balancers' footSlipCompensation remains on and tends to keep the character facing the same way as when it was balancing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FtkKneeSpin
        {
            get => GetArgument("ftkKneeSpin", false);
            set
            {
                bool argumentValue = value;
                SetArgument("ftkKneeSpin", argumentValue);
            }
        }

        /// <summary>
        /// Multiplier on the reduction of friction for the feet based on angle away from horizontal - helps the character fall to knees quicker.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float FtkFricMult
        {
            get => GetArgument("ftkFricMult", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("ftkFricMult", argumentValue);
            }
        }

        /// <summary>
        /// Apply this hip angle when the character starts to fall backwards when on knees.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FtkHipAngleFall
        {
            get => GetArgument("ftkHipAngleFall", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("ftkHipAngleFall", argumentValue);
            }
        }

        /// <summary>
        /// Hip pitch applied (+ve forward, -ve backwards) if character is falling forwards on way down to it's knees.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>-0.50</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float FtkPitchForwards
        {
            get => GetArgument("ftkPitchForwards", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(-0.50f, value));
                SetArgument("ftkPitchForwards", argumentValue);
            }
        }

        /// <summary>
        /// Hip pitch applied (+ve forward, -ve backwards) if character is falling backwards on way down to it's knees.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>-0.50</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float FtkPitchBackwards
        {
            get => GetArgument("ftkPitchBackwards", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(-0.50f, value));
                SetArgument("ftkPitchBackwards", argumentValue);
            }
        }

        /// <summary>
        /// Balancer instability below which the character starts to bend legs even if it isn't going to fall on to it's knees (i.e. if going backwards). 0.3 almost ensures a fall to knees but means the character will keep stepping backward until it slows down enough.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>15.00</c>.</para>
        /// </remarks>
        public float FtkFallBelowStab
        {
            get => GetArgument("ftkFallBelowStab", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(15.00f, System.Math.Max(0.00f, value));
                SetArgument("ftkFallBelowStab", argumentValue);
            }
        }

        /// <summary>
        /// When the character gives up and goes into a fall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>4.00</c>.</para>
        /// </remarks>
        public float FtkBalanceAbortThreshold
        {
            get => GetArgument("ftkBalanceAbortThreshold", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(4.00f, System.Math.Max(0.00f, value));
                SetArgument("ftkBalanceAbortThreshold", argumentValue);
            }
        }

        /// <summary>
        /// Type of arm response when on knees falling forward 0=useFallArms (from RollDownstairs or catchFall), 1= armsIn, 2=armsOut.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int FtkOnKneesArmType
        {
            get => GetArgument("ftkOnKneesArmType", 2);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("ftkOnKneesArmType", argumentValue);
            }
        }

        /// <summary>
        /// Release the reachForWound this amount of time after the knees have hit. If LT 0.0 then keep reaching for wound regardless of fall/onground state.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float FtkReleaseReachForWound
        {
            get => GetArgument("ftkReleaseReachForWound", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(-1.00f, value));
                SetArgument("ftkReleaseReachForWound", argumentValue);
            }
        }

        /// <summary>
        /// True = Keep reaching for wound regardless of fall/onground state. false = respect the shotConfigureArms params: reachFalling, reachFallingWithOneHand, reachOnFloor.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool FtkReachForWound
        {
            get => GetArgument("ftkReachForWound", true);
            set
            {
                bool argumentValue = value;
                SetArgument("ftkReachForWound", argumentValue);
            }
        }

        /// <summary>
        /// Override the pointGun when knees hit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FtkReleasePointGun
        {
            get => GetArgument("ftkReleasePointGun", false);
            set
            {
                bool argumentValue = value;
                SetArgument("ftkReleasePointGun", argumentValue);
            }
        }

        /// <summary>
        /// The upper body of the character must be colliding and other failure conditions met to fail.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool FtkFailMustCollide
        {
            get => GetArgument("ftkFailMustCollide", true);
            set
            {
                bool argumentValue = value;
                SetArgument("ftkFailMustCollide", argumentValue);
            }
        }
    }

    /// <summary>
    /// ShotFromBehind: configure the shot from behind reaction.
    /// </summary>
    public sealed class ShotFromBehindHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ShotFromBehind NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotFromBehindHelper(Ped ped) : base(ped, "shotFromBehind")
        {
        }

        /// <summary>
        /// Type of reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ShotFromBehind
        {
            get => GetArgument("shotFromBehind", false);
            set
            {
                bool argumentValue = value;
                SetArgument("shotFromBehind", argumentValue);
            }
        }

        /// <summary>
        /// SpineBend.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SfbSpineAmount
        {
            get => GetArgument("sfbSpineAmount", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sfbSpineAmount", argumentValue);
            }
        }

        /// <summary>
        /// Neck Bend.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SfbNeckAmount
        {
            get => GetArgument("sfbNeckAmount", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sfbNeckAmount", argumentValue);
            }
        }

        /// <summary>
        /// Hip Pitch.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SfbHipAmount
        {
            get => GetArgument("sfbHipAmount", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sfbHipAmount", argumentValue);
            }
        }

        /// <summary>
        /// Knee bend.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.050</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SfbKneeAmount
        {
            get => GetArgument("sfbKneeAmount", 0.050f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("sfbKneeAmount", argumentValue);
            }
        }

        /// <summary>
        /// ShotFromBehind reaction period after being shot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SfbPeriod
        {
            get => GetArgument("sfbPeriod", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.010f, value));
                SetArgument("sfbPeriod", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time not taking a step.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SfbForceBalancePeriod
        {
            get => GetArgument("sfbForceBalancePeriod", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sfbForceBalancePeriod", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time before applying spread out arms pose.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SfbArmsOnset
        {
            get => GetArgument("sfbArmsOnset", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sfbArmsOnset", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time before bending knees a bit.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SfbKneesOnset
        {
            get => GetArgument("sfbKneesOnset", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sfbKneesOnset", argumentValue);
            }
        }

        /// <summary>
        /// Controls additional independent randomized bending of left/right elbows.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float SfbNoiseGain
        {
            get => GetArgument("sfbNoiseGain", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("sfbNoiseGain", argumentValue);
            }
        }

        /// <summary>
        /// 0=balancer fails as normal, 1= ignore backArchedBack and leanedTooFarBack balancer failures, 2= ignore backArchedBack balancer failure only, 3= ignore leanedTooFarBack balancer failure only.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public int SfbIgnoreFail
        {
            get => GetArgument("sfbIgnoreFail", 0);
            set
            {
                int argumentValue = System.Math.Min(3, System.Math.Max(0, value));
                SetArgument("sfbIgnoreFail", argumentValue);
            }
        }
    }

    /// <summary>
    /// ShotInGuts: configure the shot in guts reaction.
    /// </summary>
    public sealed class ShotInGutsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ShotInGuts NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotInGutsHelper(Ped ped) : base(ped, "shotInGuts")
        {
        }

        /// <summary>
        /// Type of reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ShotInGuts
        {
            get => GetArgument("shotInGuts", false);
            set
            {
                bool argumentValue = value;
                SetArgument("shotInGuts", argumentValue);
            }
        }

        /// <summary>
        /// SpineBend.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SigSpineAmount
        {
            get => GetArgument("sigSpineAmount", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sigSpineAmount", argumentValue);
            }
        }

        /// <summary>
        /// Neck Bend.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SigNeckAmount
        {
            get => GetArgument("sigNeckAmount", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sigNeckAmount", argumentValue);
            }
        }

        /// <summary>
        /// Hip Pitch.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SigHipAmount
        {
            get => GetArgument("sigHipAmount", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sigHipAmount", argumentValue);
            }
        }

        /// <summary>
        /// Knee bend.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.050</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SigKneeAmount
        {
            get => GetArgument("sigKneeAmount", 0.050f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("sigKneeAmount", argumentValue);
            }
        }

        /// <summary>
        /// Active time after being shot.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SigPeriod
        {
            get => GetArgument("sigPeriod", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.010f, value));
                SetArgument("sigPeriod", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time not taking a step.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SigForceBalancePeriod
        {
            get => GetArgument("sigForceBalancePeriod", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sigForceBalancePeriod", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time not taking a step.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float SigKneesOnset
        {
            get => GetArgument("sigKneesOnset", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("sigKneesOnset", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class ShotHeadLookHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ShotHeadLook NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotHeadLookHelper(Ped ped) : base(ped, "shotHeadLook")
        {
        }

        /// <summary>
        /// Use headLook. Default: looks at provided target or if this is zero - looks forward or in velocity direction. If reachForWound is enabled, switches between looking at the wound and at the default target.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseHeadLook
        {
            get => GetArgument("useHeadLook", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useHeadLook", argumentValue);
            }
        }

        /// <summary>
        /// Position to look at with headlook flag.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 HeadLook
        {
            get => GetArgument("headLook", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("headLook", argumentValue);
            }
        }

        /// <summary>
        /// Min time to look at wound.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float HeadLookAtWoundMinTimer
        {
            get => GetArgument("headLookAtWoundMinTimer", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("headLookAtWoundMinTimer", argumentValue);
            }
        }

        /// <summary>
        /// Max time to look at wound.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.80</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float HeadLookAtWoundMaxTimer
        {
            get => GetArgument("headLookAtWoundMaxTimer", 0.80f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("headLookAtWoundMaxTimer", argumentValue);
            }
        }

        /// <summary>
        /// Min time to look headLook or if zero - forward or in velocity direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float HeadLookAtHeadPosMaxTimer
        {
            get => GetArgument("headLookAtHeadPosMaxTimer", 1.70f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("headLookAtHeadPosMaxTimer", argumentValue);
            }
        }

        /// <summary>
        /// Max time to look headLook or if zero - forward or in velocity direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float HeadLookAtHeadPosMinTimer
        {
            get => GetArgument("headLookAtHeadPosMinTimer", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("headLookAtHeadPosMinTimer", argumentValue);
            }
        }
    }

    /// <summary>
    /// ShotConfigureArms: configure the arm reactions in shot.
    /// </summary>
    public sealed class ShotConfigureArmsHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the ShotConfigureArms NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public ShotConfigureArmsHelper(Ped ped) : base(ped, "shotConfigureArms")
        {
        }

        /// <summary>
        /// Blind brace with arms if appropriate.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Brace
        {
            get => GetArgument("brace", true);
            set
            {
                bool argumentValue = value;
                SetArgument("brace", argumentValue);
            }
        }

        /// <summary>
        /// Point gun if appropriate.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool PointGun
        {
            get => GetArgument("pointGun", false);
            set
            {
                bool argumentValue = value;
                SetArgument("pointGun", argumentValue);
            }
        }

        /// <summary>
        /// ArmsWindmill if going backwards fast enough.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseArmsWindmill
        {
            get => GetArgument("useArmsWindmill", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useArmsWindmill", argumentValue);
            }
        }

        /// <summary>
        /// Release wound if going sideways/forward fast enough. 0 = don't. 1 = only if bracing. 2 = any default arm reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int ReleaseWound
        {
            get => GetArgument("releaseWound", 1);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("releaseWound", argumentValue);
            }
        }

        /// <summary>
        /// ReachForWound when falling 0 = false, 1 = true, 2 = once per shot performance.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int ReachFalling
        {
            get => GetArgument("reachFalling", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("reachFalling", argumentValue);
            }
        }

        /// <summary>
        /// Force character to reach for wound with only one hand when falling or fallen. 0= allow 2 handed reach, 1= left only if 2 handed possible, 2= right only if 2 handed possible, 3 = one handed but automatic (allows switching of hands).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>3</c>.</para>
        /// </remarks>
        public int ReachFallingWithOneHand
        {
            get => GetArgument("reachFallingWithOneHand", 3);
            set
            {
                int argumentValue = System.Math.Min(3, System.Math.Max(0, value));
                SetArgument("reachFallingWithOneHand", argumentValue);
            }
        }

        /// <summary>
        /// ReachForWound when on floor - 0 = false, 1 = true, 2 = once per shot performance.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int ReachOnFloor
        {
            get => GetArgument("reachOnFloor", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("reachOnFloor", argumentValue);
            }
        }

        /// <summary>
        /// Inhibit arms brace for this amount of time after reachForWound has begun.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float AlwaysReachTime
        {
            get => GetArgument("alwaysReachTime", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("alwaysReachTime", argumentValue);
            }
        }

        /// <summary>
        /// For armsWindmill, multiplier on character speed - increase of speed of circling is proportional to character speed (max speed of circliing increase = 1.5). eg. lowering the value increases the range of velocity that the 0-1.5 is applied over.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float AWSpeedMult
        {
            get => GetArgument("AWSpeedMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("AWSpeedMult", argumentValue);
            }
        }

        /// <summary>
        /// For armsWindmill, multiplier on character speed - increase of radii is proportional to character speed (max radius increase = 0.45). eg. lowering the value increases the range of velocity that the 0-0.45 is applied over.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float AWRadiusMult
        {
            get => GetArgument("AWRadiusMult", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("AWRadiusMult", argumentValue);
            }
        }

        /// <summary>
        /// For armsWindmill, added arm stiffness ranges from 0 to AWStiffnessAdd.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float AWStiffnessAdd
        {
            get => GetArgument("AWStiffnessAdd", 4.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("AWStiffnessAdd", argumentValue);
            }
        }

        /// <summary>
        /// Force character to reach for wound with only one hand. 0= allow 2 handed reach, 1= left only if 2 handed possible, 2= right only if 2 handed possible.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int ReachWithOneHand
        {
            get => GetArgument("reachWithOneHand", 0);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(0, value));
                SetArgument("reachWithOneHand", argumentValue);
            }
        }

        /// <summary>
        /// Allow character to reach for wound with left hand if holding a pistol. It never will for a rifle. If pointGun is running this will only happen if the hand cannot point and pointGun:poseUnusedGunArm = false.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool AllowLeftPistolRFW
        {
            get => GetArgument("allowLeftPistolRFW", true);
            set
            {
                bool argumentValue = value;
                SetArgument("allowLeftPistolRFW", argumentValue);
            }
        }

        /// <summary>
        /// Allow character to reach for wound with right hand if holding a pistol. It never will for a rifle. If pointGun is running this will only happen if the hand cannot point and pointGun:poseUnusedGunArm = false.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AllowRightPistolRFW
        {
            get => GetArgument("allowRightPistolRFW", false);
            set
            {
                bool argumentValue = value;
                SetArgument("allowRightPistolRFW", argumentValue);
            }
        }

        /// <summary>
        /// Override pointGun and reachForWound if desired if holding a pistol. It never will for a rifle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool RfwWithPistol
        {
            get => GetArgument("rfwWithPistol", false);
            set
            {
                bool argumentValue = value;
                SetArgument("rfwWithPistol", argumentValue);
            }
        }

        /// <summary>
        /// Type of reaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Fling2
        {
            get => GetArgument("fling2", false);
            set
            {
                bool argumentValue = value;
                SetArgument("fling2", argumentValue);
            }
        }

        /// <summary>
        /// Fling the left arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Fling2Left
        {
            get => GetArgument("fling2Left", true);
            set
            {
                bool argumentValue = value;
                SetArgument("fling2Left", argumentValue);
            }
        }

        /// <summary>
        /// Fling the right arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Fling2Right
        {
            get => GetArgument("fling2Right", true);
            set
            {
                bool argumentValue = value;
                SetArgument("fling2Right", argumentValue);
            }
        }

        /// <summary>
        /// Override stagger arms even if staggerFall:m_upperBodyReaction = true.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Fling2OverrideStagger
        {
            get => GetArgument("fling2OverrideStagger", false);
            set
            {
                bool argumentValue = value;
                SetArgument("fling2OverrideStagger", argumentValue);
            }
        }

        /// <summary>
        /// Time after hit that the fling will start (allows for a bit of loose arm movement from bullet impact.snap etc).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Fling2TimeBefore
        {
            get => GetArgument("fling2TimeBefore", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("fling2TimeBefore", argumentValue);
            }
        }

        /// <summary>
        /// Duration of the fling behavior.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Fling2Time
        {
            get => GetArgument("fling2Time", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("fling2Time", argumentValue);
            }
        }

        /// <summary>
        /// MuscleStiffness of the left arm. If negative then uses the shots underlying muscle stiffness from controlStiffness (i.e. respects looseness).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.950</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.50</c>.</para>
        /// </remarks>
        public float Fling2MStiffL
        {
            get => GetArgument("fling2MStiffL", 0.950f);
            set
            {
                float argumentValue = System.Math.Min(1.50f, System.Math.Max(-1.00f, value));
                SetArgument("fling2MStiffL", argumentValue);
            }
        }

        /// <summary>
        /// MuscleStiffness of the right arm. If negative then uses the shots underlying muscle stiffness from controlStiffness (i.e. respects looseness).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.50</c>.</para>
        /// </remarks>
        public float Fling2MStiffR
        {
            get => GetArgument("fling2MStiffR", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.50f, System.Math.Max(-1.00f, value));
                SetArgument("fling2MStiffR", argumentValue);
            }
        }

        /// <summary>
        /// Maximum time before the left arm relaxes in the fling. It will relax automatically when the arm has completed it's bent arm fling. This is what causes the arm to straighten.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Fling2RelaxTimeL
        {
            get => GetArgument("fling2RelaxTimeL", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("fling2RelaxTimeL", argumentValue);
            }
        }

        /// <summary>
        /// Maximum time before the right arm relaxes in the fling. It will relax automatically when the arm has completed it's bent arm fling. This is what causes the arm to straighten.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Fling2RelaxTimeR
        {
            get => GetArgument("fling2RelaxTimeR", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("fling2RelaxTimeR", argumentValue);
            }
        }

        /// <summary>
        /// Min fling angle for left arm. Fling angle is random in the range fling2AngleMin:fling2AngleMax. Angle of fling in radians measured from the body horizontal sideways from shoulder. positive is up, 0 shoulder level, negative down.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.50</c>.</para>
        /// <para>Minimum value: <c>-1.50</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Fling2AngleMinL
        {
            get => GetArgument("fling2AngleMinL", -1.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.50f, value));
                SetArgument("fling2AngleMinL", argumentValue);
            }
        }

        /// <summary>
        /// Max fling angle for left arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>-1.50</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Fling2AngleMaxL
        {
            get => GetArgument("fling2AngleMaxL", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.50f, value));
                SetArgument("fling2AngleMaxL", argumentValue);
            }
        }

        /// <summary>
        /// Min fling angle for right arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.50</c>.</para>
        /// <para>Minimum value: <c>-1.50</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Fling2AngleMinR
        {
            get => GetArgument("fling2AngleMinR", -1.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.50f, value));
                SetArgument("fling2AngleMinR", argumentValue);
            }
        }

        /// <summary>
        /// Max fling angle for right arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>-1.50</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Fling2AngleMaxR
        {
            get => GetArgument("fling2AngleMaxR", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.50f, value));
                SetArgument("fling2AngleMaxR", argumentValue);
            }
        }

        /// <summary>
        /// Min left arm length. Armlength is random in the range fling2LengthMin:fling2LengthMax. Armlength maps one to one with elbow angle. (These values are scaled internally for the female character).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.250</c>.</para>
        /// <para>Maximum value: <c>0.60</c>.</para>
        /// </remarks>
        public float Fling2LengthMinL
        {
            get => GetArgument("fling2LengthMinL", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(0.60f, System.Math.Max(0.250f, value));
                SetArgument("fling2LengthMinL", argumentValue);
            }
        }

        /// <summary>
        /// Max left arm length.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>0.250</c>.</para>
        /// <para>Maximum value: <c>0.60</c>.</para>
        /// </remarks>
        public float Fling2LengthMaxL
        {
            get => GetArgument("fling2LengthMaxL", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(0.60f, System.Math.Max(0.250f, value));
                SetArgument("fling2LengthMaxL", argumentValue);
            }
        }

        /// <summary>
        /// Min right arm length.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.250</c>.</para>
        /// <para>Minimum value: <c>0.250</c>.</para>
        /// <para>Maximum value: <c>0.60</c>.</para>
        /// </remarks>
        public float Fling2LengthMinR
        {
            get => GetArgument("fling2LengthMinR", 0.250f);
            set
            {
                float argumentValue = System.Math.Min(0.60f, System.Math.Max(0.250f, value));
                SetArgument("fling2LengthMinR", argumentValue);
            }
        }

        /// <summary>
        /// Max right arm length.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>0.250</c>.</para>
        /// <para>Maximum value: <c>0.60</c>.</para>
        /// </remarks>
        public float Fling2LengthMaxR
        {
            get => GetArgument("fling2LengthMaxR", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(0.60f, System.Math.Max(0.250f, value));
                SetArgument("fling2LengthMaxR", argumentValue);
            }
        }

        /// <summary>
        /// Has the character got a bust. If so then cupBust (move bust reach targets below bust) or bustElbowLift and cupSize (stop upperArm penetrating bust and move bust targets to surface of bust) are implemented.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Bust
        {
            get => GetArgument("bust", false);
            set
            {
                bool argumentValue = value;
                SetArgument("bust", argumentValue);
            }
        }

        /// <summary>
        /// Lift the elbows up this much extra to avoid upper arm penetrating the bust (when target hits spine2 or spine3).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float BustElbowLift
        {
            get => GetArgument("bustElbowLift", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("bustElbowLift", argumentValue);
            }
        }

        /// <summary>
        /// Amount reach target to bust (spine2) will be offset forward by.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CupSize
        {
            get => GetArgument("cupSize", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("cupSize", argumentValue);
            }
        }

        /// <summary>
        /// All reach targets above or on the bust will cause a reach below the bust. (specifically moves spine3 and spine2 targets to spine1). bustElbowLift and cupSize are ignored.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool CupBust
        {
            get => GetArgument("cupBust", false);
            set
            {
                bool argumentValue = value;
                SetArgument("cupBust", argumentValue);
            }
        }
    }

    /// <summary>
    /// SmartFall: Clone of High Fall with a wider range of operating conditions.
    /// </summary>
    public sealed class SmartFallHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the SmartFall NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public SmartFallHelper(Ped ped) : base(ped, "smartFall")
        {
        }

        /// <summary>
        /// Stiffness of body. Value feeds through to bodyBalance (synched with defaults), to armsWindmill (14 for this value at default ), legs pedal, head look and roll down stairs directly.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.00</c>.</para>
        /// </remarks>
        public float BodyStiffness
        {
            get => GetArgument("bodyStiffness", 11.00f);
            set
            {
                float argumentValue = System.Math.Min(16.00f, System.Math.Max(6.00f, value));
                SetArgument("bodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// The damping of the joints.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>3.00</c>.</para>
        /// </remarks>
        public float Bodydamping
        {
            get => GetArgument("bodydamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(3.00f, System.Math.Max(0.00f, value));
                SetArgument("bodydamping", argumentValue);
            }
        }

        /// <summary>
        /// The length of time before the impact that the character transitions to the landing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.300</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float Catchfalltime
        {
            get => GetArgument("catchfalltime", 0.300f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("catchfalltime", argumentValue);
            }
        }

        /// <summary>
        /// 0.52angle is 0.868 dot//A threshold for deciding how far away from upright the character needs to be before bailing out (going into a foetal) instead of trying to land (keeping stretched out). NB: never does bailout if ignorWorldCollisions true.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.8680</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CrashOrLandCutOff
        {
            get => GetArgument("crashOrLandCutOff", 0.8680f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("crashOrLandCutOff", argumentValue);
            }
        }

        /// <summary>
        /// Strength of the controller to keep the character at angle aimAngleBase from vertical.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float PdStrength
        {
            get => GetArgument("pdStrength", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("pdStrength", argumentValue);
            }
        }

        /// <summary>
        /// Damping multiplier of the controller to keep the character at angle aimAngleBase from vertical. The actual damping is pdDamping*pdStrength*constant*angVel.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float PdDamping
        {
            get => GetArgument("pdDamping", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(0.00f, value));
                SetArgument("pdDamping", argumentValue);
            }
        }

        /// <summary>
        /// Arm circling speed in armWindMillAdaptive.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>7.850</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ArmAngSpeed
        {
            get => GetArgument("armAngSpeed", 7.850f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.00f, value));
                SetArgument("armAngSpeed", argumentValue);
            }
        }

        /// <summary>
        /// In armWindMillAdaptive.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float ArmAmplitude
        {
            get => GetArgument("armAmplitude", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("armAmplitude", argumentValue);
            }
        }

        /// <summary>
        /// In armWindMillAdaptive 3.1 opposite for stuntman. 1.0 old default. 0.0 in phase.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.10</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>6.283185</c>.</para>
        /// </remarks>
        public float ArmPhase
        {
            get => GetArgument("armPhase", 3.10f);
            set
            {
                float argumentValue = System.Math.Min(6.283185f, System.Math.Max(0.00f, value));
                SetArgument("armPhase", argumentValue);
            }
        }

        /// <summary>
        /// In armWindMillAdaptive bend the elbows as a function of armAngle. For stuntman true otherwise false.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ArmBendElbows
        {
            get => GetArgument("armBendElbows", true);
            set
            {
                bool argumentValue = value;
                SetArgument("armBendElbows", argumentValue);
            }
        }

        /// <summary>
        /// Radius of legs on pedal.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>0.010</c>.</para>
        /// <para>Maximum value: <c>0.50</c>.</para>
        /// </remarks>
        public float LegRadius
        {
            get => GetArgument("legRadius", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(0.50f, System.Math.Max(0.010f, value));
                SetArgument("legRadius", argumentValue);
            }
        }

        /// <summary>
        /// In pedal.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>7.850</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>15.0</c>.</para>
        /// </remarks>
        public float LegAngSpeed
        {
            get => GetArgument("legAngSpeed", 7.850f);
            set
            {
                float argumentValue = System.Math.Min(15.0f, System.Math.Max(0.00f, value));
                SetArgument("legAngSpeed", argumentValue);
            }
        }

        /// <summary>
        /// 0.0 for stuntman. Random offset applied per leg to the angular speed to desynchronise the pedaling - set to 0 to disable, otherwise should be set to less than the angularSpeed value.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>4.00</c>.</para>
        /// <para>Minimum value: <c>-10.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float LegAsymmetry
        {
            get => GetArgument("legAsymmetry", 4.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(-10.00f, value));
                SetArgument("legAsymmetry", argumentValue);
            }
        }

        /// <summary>
        /// Phase angle between the arms and legs circling angle.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>6.50</c>.</para>
        /// </remarks>
        public float Arms2LegsPhase
        {
            get => GetArgument("arms2LegsPhase", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(6.50f, System.Math.Max(0.00f, value));
                SetArgument("arms2LegsPhase", argumentValue);
            }
        }

        /// <summary>
        /// 0=not synched, 1=always synched, 2= synch at start only. Synchs the arms angle to what the leg angle is. All speed/direction parameters of armswindmill are overwritten if = 1. If 2 and you want synced arms/legs then armAngSpeed=legAngSpeed, legAsymmetry = 0.0 (to stop randomizations of the leg cicle speed).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public Synchroisation Arms2LegsSync
        {
            get => (Synchroisation)GetArgument("arms2LegsSync", (int)(Synchroisation)1);
            set
            {
                Synchroisation argumentValue = value;
                SetArgument("arms2LegsSync", (int)argumentValue);
            }
        }

        /// <summary>
        /// Where to put the arms when preparing to land. Approx 1 = above head, 0 = head height, -1 = down. LT -2.0 use catchFall arms, LT -3.0 use prepare for landing pose if Agent is due to land vertically, feet first.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-3.10</c>.</para>
        /// <para>Minimum value: <c>-4.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float ArmsUp
        {
            get => GetArgument("armsUp", -3.10f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(-4.00f, value));
                SetArgument("armsUp", argumentValue);
            }
        }

        /// <summary>
        /// Toggle to orientate to fall direction. i.e. orientate so that the character faces the horizontal velocity direction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool OrientateBodyToFallDirection
        {
            get => GetArgument("orientateBodyToFallDirection", false);
            set
            {
                bool argumentValue = value;
                SetArgument("orientateBodyToFallDirection", argumentValue);
            }
        }

        /// <summary>
        /// If false don't worry about the twist angle of the character when orientating the character. If false this allows the twist axis of the character to be free (You can get a nice twisting highFall like the one in dieHard 4 when the car goes into the helicopter).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool OrientateTwist
        {
            get => GetArgument("orientateTwist", true);
            set
            {
                bool argumentValue = value;
                SetArgument("orientateTwist", argumentValue);
            }
        }

        /// <summary>
        /// DEVEL parameter - suggest you don't edit it. Maximum torque the orientation controller can apply. If 0 then no helper torques will be used. 300 will orientate the character soflty for all but extreme angles away from aimAngleBase. If abs (current -aimAngleBase) is getting near 3.0 then this can be reduced to give a softer feel.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>300.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2000.00</c>.</para>
        /// </remarks>
        public float OrientateMax
        {
            get => GetArgument("orientateMax", 300.00f);
            set
            {
                float argumentValue = System.Math.Min(2000.00f, System.Math.Max(0.00f, value));
                SetArgument("orientateMax", argumentValue);
            }
        }

        /// <summary>
        /// If true then orientate the character to face the point from where it started falling. HighFall like the one in dieHard with Alan Rickman.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AlanRickman
        {
            get => GetArgument("alanRickman", false);
            set
            {
                bool argumentValue = value;
                SetArgument("alanRickman", argumentValue);
            }
        }

        /// <summary>
        /// Try to execute a forward Roll on landing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool FowardRoll
        {
            get => GetArgument("fowardRoll", false);
            set
            {
                bool argumentValue = value;
                SetArgument("fowardRoll", argumentValue);
            }
        }

        /// <summary>
        /// Blend to a zero pose when forward roll is attempted.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseZeroPose_withFowardRoll
        {
            get => GetArgument("useZeroPose_withFowardRoll", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useZeroPose_withFowardRoll", argumentValue);
            }
        }

        /// <summary>
        /// Angle from vertical the pdController is driving to ( positive = forwards).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.180</c>.</para>
        /// <para>Minimum value: <c>-3.141593</c>.</para>
        /// <para>Maximum value: <c>3.141593</c>.</para>
        /// </remarks>
        public float AimAngleBase
        {
            get => GetArgument("aimAngleBase", 0.180f);
            set
            {
                float argumentValue = System.Math.Min(3.141593f, System.Math.Max(-3.141593f, value));
                SetArgument("aimAngleBase", argumentValue);
            }
        }

        /// <summary>
        /// Scale to add/subtract from aimAngle based on forward speed (Internal).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.020</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FowardVelRotation
        {
            get => GetArgument("fowardVelRotation", -0.020f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("fowardVelRotation", argumentValue);
            }
        }

        /// <summary>
        /// Scale to change to amount of vel that is added to the foot ik from the velocity (Internal).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.050</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FootVelCompScale
        {
            get => GetArgument("footVelCompScale", 0.050f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("footVelCompScale", argumentValue);
            }
        }

        /// <summary>
        /// Sideoffset for the feet during prepareForLanding. +ve = right.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SideD
        {
            get => GetArgument("sideD", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("sideD", argumentValue);
            }
        }

        /// <summary>
        /// Forward offset for the feet during prepareForLanding.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float FowardOffsetOfLegIK
        {
            get => GetArgument("fowardOffsetOfLegIK", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("fowardOffsetOfLegIK", argumentValue);
            }
        }

        /// <summary>
        /// Leg Length for ik (Internal)//unused.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float LegL
        {
            get => GetArgument("legL", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.0f, value));
                SetArgument("legL", argumentValue);
            }
        }

        /// <summary>
        /// 0.5angle is 0.878 dot. Cutoff to go to the catchFall ( internal) //mmmtodo do like crashOrLandCutOff.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.8780</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CatchFallCutOff
        {
            get => GetArgument("catchFallCutOff", 0.8780f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("catchFallCutOff", argumentValue);
            }
        }

        /// <summary>
        /// Strength of the legs at landing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.00</c>.</para>
        /// <para>Minimum value: <c>6.00</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float LegStrength
        {
            get => GetArgument("legStrength", 12.00f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.00f, value));
                SetArgument("legStrength", argumentValue);
            }
        }

        /// <summary>
        /// If true have enough strength to balance. If false not enough strength in legs to balance (even though bodyBlance called).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Balance
        {
            get => GetArgument("balance", true);
            set
            {
                bool argumentValue = value;
                SetArgument("balance", argumentValue);
            }
        }

        /// <summary>
        /// Never go into bailout (foetal).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool IgnorWorldCollisions
        {
            get => GetArgument("ignorWorldCollisions", false);
            set
            {
                bool argumentValue = value;
                SetArgument("ignorWorldCollisions", argumentValue);
            }
        }

        /// <summary>
        /// Stuntman type fall. Arm and legs circling direction controlled by angmom and orientation.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool AdaptiveCircling
        {
            get => GetArgument("adaptiveCircling", true);
            set
            {
                bool argumentValue = value;
                SetArgument("adaptiveCircling", argumentValue);
            }
        }

        /// <summary>
        /// With stuntman type fall. Hula reaction if can't see floor and not rotating fast.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool Hula
        {
            get => GetArgument("hula", true);
            set
            {
                bool argumentValue = value;
                SetArgument("hula", argumentValue);
            }
        }

        /// <summary>
        /// Character needs to be moving less than this speed to consider fall as a recoverable one.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>15.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float MaxSpeedForRecoverableFall
        {
            get => GetArgument("maxSpeedForRecoverableFall", 15.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("maxSpeedForRecoverableFall", argumentValue);
            }
        }

        /// <summary>
        /// Character needs to be moving at least this fast horizontally to start bracing for impact if there is an object along its trajectory.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float MinSpeedForBrace
        {
            get => GetArgument("minSpeedForBrace", 10.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("minSpeedForBrace", argumentValue);
            }
        }

        /// <summary>
        /// Ray-cast normal doted with up direction has to be greater than this number to consider object flat enough to land on it.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LandingNormal
        {
            get => GetArgument("landingNormal", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("landingNormal", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets rdsForceMag.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.80</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float RdsForceMag
        {
            get => GetArgument("rdsForceMag", 0.80f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("rdsForceMag", argumentValue);
            }
        }

        /// <summary>
        /// RDS: Time for the targetlinearVelocity to decay to zero.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float RdsTargetLinVeDecayTime
        {
            get => GetArgument("rdsTargetLinVeDecayTime", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("rdsTargetLinVeDecayTime", argumentValue);
            }
        }

        /// <summary>
        /// RDS: Helper torques are applied to match the spin of the character to the max of targetLinearVelocity and COMVelMag. -1 to use initial character velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>30.0</c>.</para>
        /// </remarks>
        public float RdsTargetLinearVelocity
        {
            get => GetArgument("rdsTargetLinearVelocity", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(30.0f, System.Math.Max(0.0f, value));
                SetArgument("rdsTargetLinearVelocity", argumentValue);
            }
        }

        /// <summary>
        /// Start Catch Fall/RDS state with specified friction. Catch fall will overwrite based on setFallingReaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool RdsUseStartingFriction
        {
            get => GetArgument("rdsUseStartingFriction", false);
            set
            {
                bool argumentValue = value;
                SetArgument("rdsUseStartingFriction", argumentValue);
            }
        }

        /// <summary>
        /// Catch Fall/RDS starting friction. Catch fall will overwrite based on setFallingReaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float RdsStartingFriction
        {
            get => GetArgument("rdsStartingFriction", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.00f, value));
                SetArgument("rdsStartingFriction", argumentValue);
            }
        }

        /// <summary>
        /// Catch Fall/RDS starting friction minimum. Catch fall will overwrite based on setFallingReaction.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float RdsStartingFrictionMin
        {
            get => GetArgument("rdsStartingFrictionMin", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("rdsStartingFrictionMin", argumentValue);
            }
        }

        /// <summary>
        /// Velocity threshold under which RDS force mag will be applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.0</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public float RdsForceVelThreshold
        {
            get => GetArgument("rdsForceVelThreshold", 10.0f);
            set
            {
                float argumentValue = System.Math.Min(100.0f, System.Math.Max(0.00f, value));
                SetArgument("rdsForceVelThreshold", argumentValue);
            }
        }

        /// <summary>
        /// Force initial state (used in vehicle bail out to start SF_CatchFall (6) earlier.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>7</c>.</para>
        /// </remarks>
        public int InitialState
        {
            get => GetArgument("initialState", 0);
            set
            {
                int argumentValue = System.Math.Min(7, System.Math.Max(0, value));
                SetArgument("initialState", argumentValue);
            }
        }

        /// <summary>
        /// Allow friction changes to be applied to the hands and feet.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ChangeExtremityFriction
        {
            get => GetArgument("changeExtremityFriction", false);
            set
            {
                bool argumentValue = value;
                SetArgument("changeExtremityFriction", argumentValue);
            }
        }

        /// <summary>
        /// Set up an immediate teeter in the direction of trave if initial state is SF_Balance.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool Teeter
        {
            get => GetArgument("teeter", false);
            set
            {
                bool argumentValue = value;
                SetArgument("teeter", argumentValue);
            }
        }

        /// <summary>
        /// Offset the default Teeter edge in the direction of travel. Will need to be tweaked depending on how close to the real edge AI tends to trigger the behavior.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TeeterOffset
        {
            get => GetArgument("teeterOffset", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("teeterOffset", argumentValue);
            }
        }

        /// <summary>
        /// Time in seconds before ped should start actively trying to stop rolling.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float StopRollingTime
        {
            get => GetArgument("stopRollingTime", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("stopRollingTime", argumentValue);
            }
        }

        /// <summary>
        /// Scale for rebound assistance. 0=off, 1=very bouncy, 2=jbone crazy Try 0.5?
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>2.00</c>.</para>
        /// </remarks>
        public float ReboundScale
        {
            get => GetArgument("reboundScale", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(2.00f, System.Math.Max(0.00f, value));
                SetArgument("reboundScale", argumentValue);
            }
        }

        /// <summary>
        /// Part mask to apply rebound assistance.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>uk</c>.</para>
        /// </remarks>
        public string ReboundMask
        {
            get => GetArgument("reboundMask", "uk");
            set
            {
                string argumentValue = value;
                SetArgument("reboundMask", argumentValue);
            }
        }

        /// <summary>
        /// Force head avoid to be active during Catch Fall even when character is not on the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ForceHeadAvoid
        {
            get => GetArgument("forceHeadAvoid", false);
            set
            {
                bool argumentValue = value;
                SetArgument("forceHeadAvoid", argumentValue);
            }
        }

        /// <summary>
        /// Pass-through parameter for Catch Fall spin reduction. Increase to stop more spin. 0..1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float CfZAxisSpinReduction
        {
            get => GetArgument("cfZAxisSpinReduction", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("cfZAxisSpinReduction", argumentValue);
            }
        }

        /// <summary>
        /// Transition to splat state when com vel is below value, regardless of character health or fall velocity. Set to zero to disable.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float SplatWhenStopped
        {
            get => GetArgument("splatWhenStopped", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("splatWhenStopped", argumentValue);
            }
        }

        /// <summary>
        /// Blend head to neutral pose com vel approaches zero. Linear between zero and value. Set to zero to disable.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>100.00</c>.</para>
        /// </remarks>
        public float BlendHeadWhenStopped
        {
            get => GetArgument("blendHeadWhenStopped", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(100.00f, System.Math.Max(0.00f, value));
                SetArgument("blendHeadWhenStopped", argumentValue);
            }
        }

        /// <summary>
        /// Spread legs amount for Pedal during fall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>-1.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float SpreadLegs
        {
            get => GetArgument("spreadLegs", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-1.00f, value));
                SetArgument("spreadLegs", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class StaggerFallHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the StaggerFall NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public StaggerFallHelper(Ped ped) : base(ped, "staggerFall")
        {
        }

        /// <summary>
        /// Stiffness of arms. catch_fall's stiffness scales with this value, but has default values when this is default.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffness
        {
            get => GetArgument("armStiffness", 12.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("armStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Sets damping value for the arms.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmDamping
        {
            get => GetArgument("armDamping", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armDamping", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets spineDamping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float SpineDamping
        {
            get => GetArgument("spineDamping", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("spineDamping", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets spineStiffness.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float SpineStiffness
        {
            get => GetArgument("spineStiffness", 10.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("spineStiffness", argumentValue);
            }
        }

        /// <summary>
        /// ArmStiffness during the yanked timescale ie timeAtStartValues.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffnessStart
        {
            get => GetArgument("armStiffnessStart", 3.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("armStiffnessStart", argumentValue);
            }
        }

        /// <summary>
        /// ArmDamping during the yanked timescale ie timeAtStartValues.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmDampingStart
        {
            get => GetArgument("armDampingStart", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armDampingStart", argumentValue);
            }
        }

        /// <summary>
        /// SpineDamping during the yanked timescale ie timeAtStartValues.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float SpineDampingStart
        {
            get => GetArgument("spineDampingStart", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("spineDampingStart", argumentValue);
            }
        }

        /// <summary>
        /// SpineStiffness during the yanked timescale ie timeAtStartValues.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float SpineStiffnessStart
        {
            get => GetArgument("spineStiffnessStart", 3.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("spineStiffnessStart", argumentValue);
            }
        }

        /// <summary>
        /// Time spent with Start values for arms and spine stiffness and damping ie for whiplash efffect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float TimeAtStartValues
        {
            get => GetArgument("timeAtStartValues", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("timeAtStartValues", argumentValue);
            }
        }

        /// <summary>
        /// Time spent ramping from Start to end values for arms and spine stiffness and damping ie for whiplash efffect (occurs after timeAtStartValues).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RampTimeFromStartValues
        {
            get => GetArgument("rampTimeFromStartValues", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rampTimeFromStartValues", argumentValue);
            }
        }

        /// <summary>
        /// Probability per step of time spent in a stagger step.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float StaggerStepProb
        {
            get => GetArgument("staggerStepProb", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("staggerStepProb", argumentValue);
            }
        }

        /// <summary>
        /// Steps taken before lowerBodyStiffness starts ramping down by perStepReduction1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>100</c>.</para>
        /// </remarks>
        public int StepsTillStartEnd
        {
            get => GetArgument("stepsTillStartEnd", 2);
            set
            {
                int argumentValue = System.Math.Min(100, System.Math.Max(0, value));
                SetArgument("stepsTillStartEnd", argumentValue);
            }
        }

        /// <summary>
        /// Time from start of behavior before lowerBodyStiffness starts ramping down for rampTimeToEndValues to endValues.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public float TimeStartEnd
        {
            get => GetArgument("timeStartEnd", 100.0f);
            set
            {
                float argumentValue = System.Math.Min(100.0f, System.Math.Max(0.0f, value));
                SetArgument("timeStartEnd", argumentValue);
            }
        }

        /// <summary>
        /// Time spent ramping from lowerBodyStiffness to lowerBodyStiffnessEnd.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float RampTimeToEndValues
        {
            get => GetArgument("rampTimeToEndValues", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("rampTimeToEndValues", argumentValue);
            }
        }

        /// <summary>
        /// LowerBodyStiffness should be 12.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>13.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float LowerBodyStiffness
        {
            get => GetArgument("lowerBodyStiffness", 13.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("lowerBodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// LowerBodyStiffness at end.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float LowerBodyStiffnessEnd
        {
            get => GetArgument("lowerBodyStiffnessEnd", 8.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("lowerBodyStiffnessEnd", argumentValue);
            }
        }

        /// <summary>
        /// Amount of time (seconds) into the future that the character tries to step to. bigger values try to recover with fewer, bigger steps. smaller values recover with smaller steps, and generally recover less.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float PredictionTime
        {
            get => GetArgument("predictionTime", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("predictionTime", argumentValue);
            }
        }

        /// <summary>
        /// LowerBody stiffness will be reduced every step to make the character fallover.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float PerStepReduction1
        {
            get => GetArgument("perStepReduction1", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("perStepReduction1", argumentValue);
            }
        }

        /// <summary>
        /// LeanInDirection will be increased from 0 to leanInDirMax linearly at this rate.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float LeanInDirRate
        {
            get => GetArgument("leanInDirRate", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("leanInDirRate", argumentValue);
            }
        }

        /// <summary>
        /// Max of leanInDirection magnitude when going forwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.10</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanInDirMaxF
        {
            get => GetArgument("leanInDirMaxF", 0.10f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanInDirMaxF", argumentValue);
            }
        }

        /// <summary>
        /// Max of leanInDirection magnitude when going backwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.30</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanInDirMaxB
        {
            get => GetArgument("leanInDirMaxB", 0.30f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanInDirMaxB", argumentValue);
            }
        }

        /// <summary>
        /// Max of leanInDirectionHips magnitude when going forwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanHipsMaxF
        {
            get => GetArgument("leanHipsMaxF", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanHipsMaxF", argumentValue);
            }
        }

        /// <summary>
        /// Max of leanInDirectionHips magnitude when going backwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float LeanHipsMaxB
        {
            get => GetArgument("leanHipsMaxB", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("leanHipsMaxB", argumentValue);
            }
        }

        /// <summary>
        /// Lean of spine to side in side velocity direction when going forwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.00</c>.</para>
        /// <para>Minimum value: <c>-5.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float Lean2multF
        {
            get => GetArgument("lean2multF", -1.00f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(-5.00f, value));
                SetArgument("lean2multF", argumentValue);
            }
        }

        /// <summary>
        /// Lean of spine to side in side velocity direction when going backwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-2.00</c>.</para>
        /// <para>Minimum value: <c>-5.00</c>.</para>
        /// <para>Maximum value: <c>5.00</c>.</para>
        /// </remarks>
        public float Lean2multB
        {
            get => GetArgument("lean2multB", -2.00f);
            set
            {
                float argumentValue = System.Math.Min(5.00f, System.Math.Max(-5.00f, value));
                SetArgument("lean2multB", argumentValue);
            }
        }

        /// <summary>
        /// Amount stance foot is behind com in the direction of velocity before the leg tries to pushOff to increase momentum. Increase to lower the probability of the pushOff making the character bouncy.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.20</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float PushOffDist
        {
            get => GetArgument("pushOffDist", 0.20f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("pushOffDist", argumentValue);
            }
        }

        /// <summary>
        /// Stance leg will only pushOff to increase momentum if the vertical hip velocity is less than this value. 0.4 seems like a good value. The higher it is the the less this functionality is applied. If it is very low or negative this can stop the pushOff altogether.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>20.00</c>.</para>
        /// <para>Minimum value: <c>-20.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float MaxPushoffVel
        {
            get => GetArgument("maxPushoffVel", 20.00f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(-20.0f, value));
                SetArgument("maxPushoffVel", argumentValue);
            }
        }

        /// <summary>
        /// HipBend scaled with velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.00</c>.</para>
        /// <para>Minimum value: <c>-10.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float HipBendMult
        {
            get => GetArgument("hipBendMult", 0.00f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(-10.0f, value));
                SetArgument("hipBendMult", argumentValue);
            }
        }

        /// <summary>
        /// Bend forwards at the hip (hipBendMult) whether moving backwards or forwards.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool AlwaysBendForwards
        {
            get => GetArgument("alwaysBendForwards", false);
            set
            {
                bool argumentValue = value;
                SetArgument("alwaysBendForwards", argumentValue);
            }
        }

        /// <summary>
        /// Spine bend scaled with velocity.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.40</c>.</para>
        /// <para>Minimum value: <c>-10.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float SpineBendMult
        {
            get => GetArgument("spineBendMult", 0.40f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(-10.0f, value));
                SetArgument("spineBendMult", argumentValue);
            }
        }

        /// <summary>
        /// Enable and provide a look-at target to make the character's head turn to face it while balancing, balancer default is 0.2.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseHeadLook
        {
            get => GetArgument("useHeadLook", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useHeadLook", argumentValue);
            }
        }

        /// <summary>
        /// Position of thing to look at.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 HeadLookPos
        {
            get => GetArgument("headLookPos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("headLookPos", argumentValue);
            }
        }

        /// <summary>
        /// Level index of thing to look at.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int HeadLookInstanceIndex
        {
            get => GetArgument("headLookInstanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("headLookInstanceIndex", argumentValue);
            }
        }

        /// <summary>
        /// Probability [0-1] that headLook will be looking in the direction of velocity when stepping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float HeadLookAtVelProb
        {
            get => GetArgument("headLookAtVelProb", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("headLookAtVelProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability that turn will be off. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TurnOffProb
        {
            get => GetArgument("turnOffProb", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turnOffProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning towards headLook target. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float Turn2TargetProb
        {
            get => GetArgument("turn2TargetProb", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turn2TargetProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning towards velocity. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float Turn2VelProb
        {
            get => GetArgument("turn2VelProb", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turn2VelProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning away from headLook target. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TurnAwayProb
        {
            get => GetArgument("turnAwayProb", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turnAwayProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning left. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TurnLeftProb
        {
            get => GetArgument("turnLeftProb", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turnLeftProb", argumentValue);
            }
        }

        /// <summary>
        /// Weighted Probability of turning right. This is one of six turn type weights.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float TurnRightProb
        {
            get => GetArgument("turnRightProb", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("turnRightProb", argumentValue);
            }
        }

        /// <summary>
        /// Enable and provide a positive bodyTurnTimeout and provide a look-at target to make the character turn to face it while balancing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseBodyTurn
        {
            get => GetArgument("useBodyTurn", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useBodyTurn", argumentValue);
            }
        }

        /// <summary>
        /// Enable upper body reaction ie blindBrace and armswindmill.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UpperBodyReaction
        {
            get => GetArgument("upperBodyReaction", true);
            set
            {
                bool argumentValue = value;
                SetArgument("upperBodyReaction", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class TeeterHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the Teeter NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public TeeterHelper(Ped ped) : base(ped, "teeter")
        {
        }

        /// <summary>
        /// Defines the left edge point (left of character facing edge).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>39.470, 38.890, 21.120</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public Vector3 EdgeLeft
        {
            get => GetArgument("edgeLeft", new Vector3(39.470f, 38.890f, 21.120f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("edgeLeft", argumentValue);
            }
        }

        /// <summary>
        /// Defines the right edge point (right of character facing edge).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>39.470, 39.890, 21.120</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// </remarks>
        public Vector3 EdgeRight
        {
            get => GetArgument("edgeRight", new Vector3(39.470f, 39.890f, 21.120f));
            set
            {
                Vector3 argumentValue = Vector3.Clamp(value, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                SetArgument("edgeRight", argumentValue);
            }
        }

        /// <summary>
        /// Stop stepping across the line defined by edgeLeft and edgeRight.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseExclusionZone
        {
            get => GetArgument("useExclusionZone", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useExclusionZone", argumentValue);
            }
        }

        /// <summary>
        /// Gets or sets useHeadLook.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseHeadLook
        {
            get => GetArgument("useHeadLook", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useHeadLook", argumentValue);
            }
        }

        /// <summary>
        /// Call highFall if fallen over the edge. If false just call blended writhe (to go over the top of the fall behavior of the underlying behavior e.g. bodyBalance).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool CallHighFall
        {
            get => GetArgument("callHighFall", true);
            set
            {
                bool argumentValue = value;
                SetArgument("callHighFall", argumentValue);
            }
        }

        /// <summary>
        /// Lean away from the edge based on velocity towards the edge (if closer than 2m from edge).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool LeanAway
        {
            get => GetArgument("leanAway", true);
            set
            {
                bool argumentValue = value;
                SetArgument("leanAway", argumentValue);
            }
        }

        /// <summary>
        /// Time-to-edge threshold to start pre-teeter (windmilling, etc).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float PreTeeterTime
        {
            get => GetArgument("preTeeterTime", 2.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("preTeeterTime", argumentValue);
            }
        }

        /// <summary>
        /// Time-to-edge threshold to start leaning away from a potential fall.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float LeanAwayTime
        {
            get => GetArgument("leanAwayTime", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("leanAwayTime", argumentValue);
            }
        }

        /// <summary>
        /// Scales stay upright lean and hip pitch.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.50</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float LeanAwayScale
        {
            get => GetArgument("leanAwayScale", 0.50f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(0.00f, value));
                SetArgument("leanAwayScale", argumentValue);
            }
        }

        /// <summary>
        /// Time-to-edge threshold to start full-on teeter (more aggressive lean, drop-and-twist, etc).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.00</c>.</para>
        /// <para>Minimum value: <c>0.00</c>.</para>
        /// <para>Maximum value: <c>10.00</c>.</para>
        /// </remarks>
        public float TeeterTime
        {
            get => GetArgument("teeterTime", 1.00f);
            set
            {
                float argumentValue = System.Math.Min(10.00f, System.Math.Max(0.00f, value));
                SetArgument("teeterTime", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class UpperBodyFlinchHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the UpperBodyFlinch NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public UpperBodyFlinchHelper(Ped ped) : base(ped, "upperBodyFlinch")
        {
        }

        /// <summary>
        /// Left-Right distance between the hands.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float HandDistanceLeftRight
        {
            get => GetArgument("handDistanceLeftRight", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("handDistanceLeftRight", argumentValue);
            }
        }

        /// <summary>
        /// Front-Back distance between the hands.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.06</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float HandDistanceFrontBack
        {
            get => GetArgument("handDistanceFrontBack", 0.06f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("handDistanceFrontBack", argumentValue);
            }
        }

        /// <summary>
        /// Vertical distance between the hands.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float HandDistanceVertical
        {
            get => GetArgument("handDistanceVertical", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("handDistanceVertical", argumentValue);
            }
        }

        /// <summary>
        /// Stiffness of body. Value carries over to head look, spine twist.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float BodyStiffness
        {
            get => GetArgument("bodyStiffness", 11.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("bodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Damping value used for upper body.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float BodyDamping
        {
            get => GetArgument("bodyDamping", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("bodyDamping", argumentValue);
            }
        }

        /// <summary>
        /// Amount to bend the back during the flinch.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-0.55</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float BackBendAmount
        {
            get => GetArgument("backBendAmount", -0.55f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("backBendAmount", argumentValue);
            }
        }

        /// <summary>
        /// Toggle to use the right arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseRightArm
        {
            get => GetArgument("useRightArm", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useRightArm", argumentValue);
            }
        }

        /// <summary>
        /// Toggle to Use the Left arm.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseLeftArm
        {
            get => GetArgument("useLeftArm", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useLeftArm", argumentValue);
            }
        }

        /// <summary>
        /// Amplitude of the perlin noise applied to the arms positions in the flicnh to the front part of the behavior.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float NoiseScale
        {
            get => GetArgument("noiseScale", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("noiseScale", argumentValue);
            }
        }

        /// <summary>
        /// Relaxes the character for 1 frame if set.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool NewHit
        {
            get => GetArgument("newHit", true);
            set
            {
                bool argumentValue = value;
                SetArgument("newHit", argumentValue);
            }
        }

        /// <summary>
        /// Always protect head. Note if false then character flinches if target is in front, protects head if target is behind.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool ProtectHeadToggle
        {
            get => GetArgument("protectHeadToggle", false);
            set
            {
                bool argumentValue = value;
                SetArgument("protectHeadToggle", argumentValue);
            }
        }

        /// <summary>
        /// Don't protect head only brace from front. Turned on by bcr.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool DontBraceHead
        {
            get => GetArgument("dontBraceHead", false);
            set
            {
                bool argumentValue = value;
                SetArgument("dontBraceHead", argumentValue);
            }
        }

        /// <summary>
        /// Turned of by bcr.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool ApplyStiffness
        {
            get => GetArgument("applyStiffness", true);
            set
            {
                bool argumentValue = value;
                SetArgument("applyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Look away from target (unless protecting head then look between feet).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool HeadLookAwayFromTarget
        {
            get => GetArgument("headLookAwayFromTarget", false);
            set
            {
                bool argumentValue = value;
                SetArgument("headLookAwayFromTarget", argumentValue);
            }
        }

        /// <summary>
        /// Use headlook.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>true</c>.</para>
        /// </remarks>
        public bool UseHeadLook
        {
            get => GetArgument("useHeadLook", true);
            set
            {
                bool argumentValue = value;
                SetArgument("useHeadLook", argumentValue);
            }
        }

        /// <summary>
        /// Ve balancer turn Towards, negative balancer turn Away, 0 balancer won't turn. NB.There is a 50% chance that the character will not turn even if this parameter is set to turn.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1</c>.</para>
        /// <para>Minimum value: <c>-2</c>.</para>
        /// <para>Maximum value: <c>2</c>.</para>
        /// </remarks>
        public int TurnTowards
        {
            get => GetArgument("turnTowards", 1);
            set
            {
                int argumentValue = System.Math.Min(2, System.Math.Max(-2, value));
                SetArgument("turnTowards", argumentValue);
            }
        }

        /// <summary>
        /// Position in world-space of object to flinch from.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 Pos
        {
            get => GetArgument("pos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("pos", argumentValue);
            }
        }
    }

    /// <summary>
    /// Configures the NaturalMotion behavior.
    /// </summary>
    public sealed class YankedHelper : CustomHelper
    {
        /// <summary>
        /// Creates a helper for sending the Yanked NaturalMotion message to a <see cref="Ped"/>.
        /// </summary>
        public YankedHelper(Ped ped) : base(ped, "yanked")
        {
        }

        /// <summary>
        /// Stiffness of arms when upright.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffness
        {
            get => GetArgument("armStiffness", 11.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("armStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Sets damping value for the arms when upright.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmDamping
        {
            get => GetArgument("armDamping", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armDamping", argumentValue);
            }
        }

        /// <summary>
        /// Spine Damping when upright.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float SpineDamping
        {
            get => GetArgument("spineDamping", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("spineDamping", argumentValue);
            }
        }

        /// <summary>
        /// Spine Stiffness when upright..
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>10.0</c>.</para>
        /// <para>Minimum value: <c>6.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float SpineStiffness
        {
            get => GetArgument("spineStiffness", 10.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(6.0f, value));
                SetArgument("spineStiffness", argumentValue);
            }
        }

        /// <summary>
        /// ArmStiffness during the yanked timescale ie timeAtStartValues.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float ArmStiffnessStart
        {
            get => GetArgument("armStiffnessStart", 3.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("armStiffnessStart", argumentValue);
            }
        }

        /// <summary>
        /// ArmDamping during the yanked timescale ie timeAtStartValues.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float ArmDampingStart
        {
            get => GetArgument("armDampingStart", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("armDampingStart", argumentValue);
            }
        }

        /// <summary>
        /// SpineDamping during the yanked timescale ie timeAtStartValues.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float SpineDampingStart
        {
            get => GetArgument("spineDampingStart", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("spineDampingStart", argumentValue);
            }
        }

        /// <summary>
        /// SpineStiffness during the yanked timescale ie timeAtStartValues.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>3.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float SpineStiffnessStart
        {
            get => GetArgument("spineStiffnessStart", 3.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("spineStiffnessStart", argumentValue);
            }
        }

        /// <summary>
        /// Time spent with Start values for arms and spine stiffness and damping ie for whiplash efffect.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.4</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float TimeAtStartValues
        {
            get => GetArgument("timeAtStartValues", 0.4f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("timeAtStartValues", argumentValue);
            }
        }

        /// <summary>
        /// Time spent ramping from Start to end values for arms and spine stiffness and damping ie for whiplash efffect (occurs after timeAtStartValues).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.1</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RampTimeFromStartValues
        {
            get => GetArgument("rampTimeFromStartValues", 0.1f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rampTimeFromStartValues", argumentValue);
            }
        }

        /// <summary>
        /// Steps taken before lowerBodyStiffness starts ramping down.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2</c>.</para>
        /// <para>Minimum value: <c>0</c>.</para>
        /// <para>Maximum value: <c>100</c>.</para>
        /// </remarks>
        public int StepsTillStartEnd
        {
            get => GetArgument("stepsTillStartEnd", 2);
            set
            {
                int argumentValue = System.Math.Min(100, System.Math.Max(0, value));
                SetArgument("stepsTillStartEnd", argumentValue);
            }
        }

        /// <summary>
        /// Time from start of behavior before lowerBodyStiffness starts ramping down by perStepReduction1.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>100.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>100.0</c>.</para>
        /// </remarks>
        public float TimeStartEnd
        {
            get => GetArgument("timeStartEnd", 100.0f);
            set
            {
                float argumentValue = System.Math.Min(100.0f, System.Math.Max(0.0f, value));
                SetArgument("timeStartEnd", argumentValue);
            }
        }

        /// <summary>
        /// Time spent ramping from lowerBodyStiffness to lowerBodyStiffnessEnd.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float RampTimeToEndValues
        {
            get => GetArgument("rampTimeToEndValues", 0.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("rampTimeToEndValues", argumentValue);
            }
        }

        /// <summary>
        /// LowerBodyStiffness should be 12.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>12.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float LowerBodyStiffness
        {
            get => GetArgument("lowerBodyStiffness", 12.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("lowerBodyStiffness", argumentValue);
            }
        }

        /// <summary>
        /// LowerBodyStiffness at end.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float LowerBodyStiffnessEnd
        {
            get => GetArgument("lowerBodyStiffnessEnd", 8.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("lowerBodyStiffnessEnd", argumentValue);
            }
        }

        /// <summary>
        /// LowerBody stiffness will be reduced every step to make the character fallover.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.50</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float PerStepReduction
        {
            get => GetArgument("perStepReduction", 1.50f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("perStepReduction", argumentValue);
            }
        }

        /// <summary>
        /// Amount to bend forward at the hips (+ve forward, -ve backwards). Behavior switches between hipPitchForward and hipPitchBack.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>-1.30</c>.</para>
        /// <para>Maximum value: <c>1.30</c>.</para>
        /// </remarks>
        public float HipPitchForward
        {
            get => GetArgument("hipPitchForward", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(1.30f, System.Math.Max(-1.30f, value));
                SetArgument("hipPitchForward", argumentValue);
            }
        }

        /// <summary>
        /// Amount to bend backwards at the hips (+ve backwards, -ve forwards). Behavior switches between hipPitchForward and hipPitchBack.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>-1.30</c>.</para>
        /// <para>Maximum value: <c>1.30</c>.</para>
        /// </remarks>
        public float HipPitchBack
        {
            get => GetArgument("hipPitchBack", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.30f, System.Math.Max(-1.30f, value));
                SetArgument("hipPitchBack", argumentValue);
            }
        }

        /// <summary>
        /// Bend/Twist the spine amount.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.70</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float SpineBend
        {
            get => GetArgument("spineBend", 0.70f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(0.0f, value));
                SetArgument("spineBend", argumentValue);
            }
        }

        /// <summary>
        /// Foot friction when standing/stepping. 0.5 gives a good slide sometimes.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float FootFriction
        {
            get => GetArgument("footFriction", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("footFriction", argumentValue);
            }
        }

        /// <summary>
        /// Min angle at which the turn with toggle to the other direction (actual toggle angle is chosen randomly in range min to max). If it is 1 then it will never toggle. If negative then no turn is applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>-0.10</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TurnThresholdMin
        {
            get => GetArgument("turnThresholdMin", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-0.10f, value));
                SetArgument("turnThresholdMin", argumentValue);
            }
        }

        /// <summary>
        /// Max angle at which the turn with toggle to the other direction (actual toggle angle is chosen randomly in range min to max). If it is 1 then it will never toggle. If negative then no turn is applied.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.60</c>.</para>
        /// <para>Minimum value: <c>-0.10</c>.</para>
        /// <para>Maximum value: <c>1.00</c>.</para>
        /// </remarks>
        public float TurnThresholdMax
        {
            get => GetArgument("turnThresholdMax", 0.60f);
            set
            {
                float argumentValue = System.Math.Min(1.00f, System.Math.Max(-0.10f, value));
                SetArgument("turnThresholdMax", argumentValue);
            }
        }

        /// <summary>
        /// Enable and provide a look-at target to make the character's head turn to face it while balancing.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>false</c>.</para>
        /// </remarks>
        public bool UseHeadLook
        {
            get => GetArgument("useHeadLook", false);
            set
            {
                bool argumentValue = value;
                SetArgument("useHeadLook", argumentValue);
            }
        }

        /// <summary>
        /// Position of thing to look at.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0, 0, 0</c>.</para>
        /// </remarks>
        public Vector3 HeadLookPos
        {
            get => GetArgument("headLookPos", new Vector3(0.0f, 0.0f, 0.0f));
            set
            {
                Vector3 argumentValue = value;
                SetArgument("headLookPos", argumentValue);
            }
        }

        /// <summary>
        /// Level index of thing to look at.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1</c>.</para>
        /// <para>Minimum value: <c>-1</c>.</para>
        /// </remarks>
        public int HeadLookInstanceIndex
        {
            get => GetArgument("headLookInstanceIndex", -1);
            set
            {
                int argumentValue = System.Math.Max(-1, value);
                SetArgument("headLookInstanceIndex", argumentValue);
            }
        }

        /// <summary>
        /// Probability [0-1] that headLook will be looking in the direction of velocity when stepping.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>-1.0</c>.</para>
        /// <para>Minimum value: <c>-1.0</c>.</para>
        /// <para>Maximum value: <c>1.0</c>.</para>
        /// </remarks>
        public float HeadLookAtVelProb
        {
            get => GetArgument("headLookAtVelProb", -1.0f);
            set
            {
                float argumentValue = System.Math.Min(1.0f, System.Math.Max(-1.0f, value));
                SetArgument("headLookAtVelProb", argumentValue);
            }
        }

        /// <summary>
        /// For handsAndKnees catchfall ONLY: comVel above which rollDownstairs will start.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>2.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>20.0</c>.</para>
        /// </remarks>
        public float ComVelRDSThresh
        {
            get => GetArgument("comVelRDSThresh", 2.0f);
            set
            {
                float argumentValue = System.Math.Min(20.0f, System.Math.Max(0.0f, value));
                SetArgument("comVelRDSThresh", argumentValue);
            }
        }

        /// <summary>
        /// 0.25 A complete wiggle will take 4*hulaPeriod.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.25</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float HulaPeriod
        {
            get => GetArgument("hulaPeriod", 0.25f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("hulaPeriod", argumentValue);
            }
        }

        /// <summary>
        /// Amount of hip movement.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float HipAmplitude
        {
            get => GetArgument("hipAmplitude", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("hipAmplitude", argumentValue);
            }
        }

        /// <summary>
        /// Amount of spine movement.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>4.0</c>.</para>
        /// </remarks>
        public float SpineAmplitude
        {
            get => GetArgument("spineAmplitude", 1.0f);
            set
            {
                float argumentValue = System.Math.Min(4.0f, System.Math.Max(0.0f, value));
                SetArgument("spineAmplitude", argumentValue);
            }
        }

        /// <summary>
        /// Wriggle relaxes for a minimum of minRelaxPeriod (if it is negative it is a multiplier on the time previously spent wriggling).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.3</c>.</para>
        /// <para>Minimum value: <c>-5.0</c>.</para>
        /// <para>Maximum value: <c>5.0</c>.</para>
        /// </remarks>
        public float MinRelaxPeriod
        {
            get => GetArgument("minRelaxPeriod", 0.3f);
            set
            {
                float argumentValue = System.Math.Min(5.0f, System.Math.Max(-5.0f, value));
                SetArgument("minRelaxPeriod", argumentValue);
            }
        }

        /// <summary>
        /// Wriggle relaxes for a maximum of maxRelaxPeriod (if it is negative it is a multiplier on the time previously spent wriggling).
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>1.5</c>.</para>
        /// <para>Minimum value: <c>-5.0</c>.</para>
        /// <para>Maximum value: <c>5.0</c>.</para>
        /// </remarks>
        public float MaxRelaxPeriod
        {
            get => GetArgument("maxRelaxPeriod", 1.5f);
            set
            {
                float argumentValue = System.Math.Min(5.0f, System.Math.Max(-5.0f, value));
                SetArgument("maxRelaxPeriod", argumentValue);
            }
        }

        /// <summary>
        /// Amount of cheat torque applied to turn the character over.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float RollHelp
        {
            get => GetArgument("rollHelp", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("rollHelp", argumentValue);
            }
        }

        /// <summary>
        /// Leg Stiffness when on the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float GroundLegStiffness
        {
            get => GetArgument("groundLegStiffness", 11.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("groundLegStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Arm Stiffness when on the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>11</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float GroundArmStiffness
        {
            get => GetArgument("groundArmStiffness", 11.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("groundArmStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Spine Stiffness when on the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>14</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>16.0</c>.</para>
        /// </remarks>
        public float GroundSpineStiffness
        {
            get => GetArgument("groundSpineStiffness", 14.0f);
            set
            {
                float argumentValue = System.Math.Min(16.0f, System.Math.Max(0.0f, value));
                SetArgument("groundSpineStiffness", argumentValue);
            }
        }

        /// <summary>
        /// Leg Damping when on the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float GroundLegDamping
        {
            get => GetArgument("groundLegDamping", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("groundLegDamping", argumentValue);
            }
        }

        /// <summary>
        /// Arm Damping when on the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float GroundArmDamping
        {
            get => GetArgument("groundArmDamping", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("groundArmDamping", argumentValue);
            }
        }

        /// <summary>
        /// Spine Damping when on the ground.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>0.5</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>2.0</c>.</para>
        /// </remarks>
        public float GroundSpineDamping
        {
            get => GetArgument("groundSpineDamping", 0.5f);
            set
            {
                float argumentValue = System.Math.Min(2.0f, System.Math.Max(0.0f, value));
                SetArgument("groundSpineDamping", argumentValue);
            }
        }

        /// <summary>
        /// Friction multiplier on bodyParts when on ground. Character can look too slidy with groundFriction = 1. Higher values give a more jerky reation but this seems timestep dependent especially for dragged by the feet.
        /// </summary>
        /// <remarks>
        /// <para>Default value: <c>8.0</c>.</para>
        /// <para>Minimum value: <c>0.0</c>.</para>
        /// <para>Maximum value: <c>10.0</c>.</para>
        /// </remarks>
        public float GroundFriction
        {
            get => GetArgument("groundFriction", 8.0f);
            set
            {
                float argumentValue = System.Math.Min(10.0f, System.Math.Max(0.0f, value));
                SetArgument("groundFriction", argumentValue);
            }
        }
    }
}
