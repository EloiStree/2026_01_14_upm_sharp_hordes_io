using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.HordesIO
{

    public class HordesMono_IntPlayerInput : MonoBehaviour
    {
        /* BASIC IF USING ARROW ONLY
        Left    37  0x25  1037 2037
        Up      38  0x26  1038 2038
        Right   39  0x27  1039 2039
        Down    40  0x28  1040 2040
        Tab     9   0x09  1009 2009
        Space   32  0x20  1032 2032
        1       49  0x31  1049 2049
        */

        public UnityEvent<int> m_onActionIntegerRequested;

        [Tooltip("Send Integer as action and in seconds parameter the delay in milliseconds")]
        public UnityEvent<int, int> m_onActionIntegerRequestedWithDelayInMilliseconds;

        [Header("Estimation Value")]
        public float m_rotateAnglePerSecond = 170;
        public float m_moveForwardSpeedPerSecond = 5.2f;
        public float m_moveLeftRightSpeedPerSecond = 5.2f;
        public float m_moveBackwardSpeedPerSecond = 1.5f;

        [Header("Move")]

        public int m_moveForward = 1087;//w
        public int m_moveBackward = 1083;//s
        public int m_moveLeft = 1065;//a
        public int m_moveRight = 1068;//d
        public int m_rotateLeft = 1037;//Arrow Left
        public int m_rotateRight = 1039;//Arrow Right

        public int m_jump = 1032;//Space

        [Header("Power")]

        public int m_firePower1 = 1049;//1
        public int m_firePower2 = 1050;//2
        public int m_firePower3 = 1051;//3
        public int m_firePower4 = 1052;//4
        public int m_firePower5 = 1053;//5
        public int m_firePower6 = 1054;//6
        public int m_firePower7 = 1055;//7
        public int m_firePower8 = 1056;//8
        public int m_firePower9 = 1057;//9
        public int m_firePower0 = 1048;//0
        [Header("Select")]

        public int m_targetNextEnemy = 1009;//Tab
        public int m_targetNextAlly= 1088;//x
        [Header("Menu")]
        public int m_toggleMap = 1077;//m
        public int m_toggleMenuSkills= 1075;//k
        public int m_toggleMenuCharacter= 1067;//c
        public int m_toggleMenuInventory= 1066;//b
        public int m_toggleMenuClan = 1071;//g
        public int m_toggleMenuPVP = 1086;//v
        public int m_toggleMenuParty = 1080;//p
        public int m_toggleMenuSocial = 1073;//i
        public int m_toggleUntarget = 1027;//escape

        [Header("Mouse")]
        public int m_mouseClickLeft=1260;
        public int m_mouseClickMiddle=1261;
        public int m_mouseClickRight=1263;
        public int m_mouseScrollUp = 1268;
        public int m_mouseScrollDown=1269;
        public int m_mouseScrollLeft=1270;
        public int m_mouseScrollRight=1271;


        #region GENERIC METHODS
        public void PressKey(int key)
        {
            m_onActionIntegerRequested.Invoke(key);
        }
        public void ReleaseKey(int key)
        {
            m_onActionIntegerRequested.Invoke(key + 1000);
        }
        public void SetKeyDown(int key, bool isPressingDown)
        {
            if (isPressingDown)
                PressKey(key);
            else
                ReleaseKey(key);
        }
        public void PressKeyWithDelay(int key, int delayInMilliseconds)
        =>m_onActionIntegerRequestedWithDelayInMilliseconds.Invoke(key, delayInMilliseconds);
        

        public void ReleaseKeyWithDelay(int key, int delayInMilliseconds)
        => m_onActionIntegerRequestedWithDelayInMilliseconds.Invoke(key + 1000, delayInMilliseconds);
        public void PressAndReleaseWithDelayInSeconds(int key, float seconds)
        {
            PressKey(key);
            ReleaseKeyWithDelay(key, (int)(seconds * 1000f));
        }
        public void PressAndReleaseWithDelayInMilliseconds(int key, int milliseconds)
        {
            PressKey(key);
            ReleaseKeyWithDelay(key, milliseconds);
        }

        #endregion


        public void SetKeyDownMoveForward(bool isPressingDown)
            => SetKeyDown(m_moveForward, isPressingDown);
        public void StartMovingForward()
            => PressKey(m_moveForward);
        public void StopMovingForward()
            => ReleaseKey(m_moveForward);
        public void StrokeMovingForwardSeconds(float seconds)
            => PressAndReleaseWithDelayInSeconds(m_moveForward, seconds);
        public void StrokeMovingForwardMilliseconds(int milliseconds)
            => PressAndReleaseWithDelayInMilliseconds(m_moveForward, milliseconds);



        // Move Backward
        public void SetKeyDownMoveBackward(bool isPressingDown) => SetKeyDown(m_moveBackward, isPressingDown);
        public void StartMovingBackward() => PressKey(m_moveBackward);
        public void StopMovingBackward() => ReleaseKey(m_moveBackward);

        // Rotate Left
        public void SetKeyDownRotateLeft(bool isPressingDown) => SetKeyDown(m_rotateLeft, isPressingDown);
        public void StartRotatingLeft() => PressKey(m_rotateLeft);
        public void StopRotatingLeft() => ReleaseKey(m_rotateLeft);

        // Rotate Right
        public void SetKeyDownRotateRight(bool isPressingDown) => SetKeyDown(m_rotateRight, isPressingDown);
        public void StartRotatingRight() => PressKey(m_rotateRight);
        public void StopRotatingRight() => ReleaseKey(m_rotateRight);

        // Jump
        public void SetKeyDownJump(bool isPressingDown) => SetKeyDown(m_jump, isPressingDown);
        public void StartJump() => PressKey(m_jump);
        public void StopJump() => ReleaseKey(m_jump);


        




        #region MOVEMENT METHODS
            public void MoveForwardForSeconds(float secondsToMove)
            {
                PressAndReleaseWithDelayInSeconds(m_moveForward, secondsToMove);
            }
            public void MoveBackwardForSeconds(float secondsToMove)
            {
                PressAndReleaseWithDelayInSeconds(m_moveBackward, secondsToMove);
            }
            public void MoveLeftForSeconds(float secondsToMove)
            {
                PressAndReleaseWithDelayInSeconds(m_moveLeft, secondsToMove);
            }
            public void MoveRightForSeconds(float secondsToMove)
            {
                PressAndReleaseWithDelayInSeconds(m_moveRight, secondsToMove);
            }

            public void MoveForwardForDistance(float distance)
            {
                float secondToMove = (float)(distance / m_moveForwardSpeedPerSecond);
                MoveForwardForSeconds(secondToMove);
            }
            public void MoveBackwardForDistance(float distance)
            {
                float secondToMove = (float)(distance / m_moveBackwardSpeedPerSecond);
                MoveBackwardForSeconds(secondToMove);
            }
            public void MoveLeftForDistance(float distance)
            {
                float secondToMove = (float)(distance / m_moveLeftRightSpeedPerSecond);
                MoveLeftForSeconds(secondToMove);
            }
            public void MoveRightForDistance(float distance)
            {
                float secondToMove = (float)(distance / m_moveLeftRightSpeedPerSecond);
                MoveRightForSeconds(secondToMove);
            }
        #endregion

#region  EXTRA ROTATION METHODS
        public void RotateRightForSeconds(float secondsToMove)
        {
            PressAndReleaseWithDelayInSeconds(m_rotateRight, secondsToMove);

        }
        public void RotateLeftForSeconds(float secondsToMove)
        {
            PressAndReleaseWithDelayInSeconds(m_rotateLeft, secondsToMove);
        }

        public void RotateRightForAngle(float angleInDegree)
        {

            float secondToMove = (float)(angleInDegree / m_rotateAnglePerSecond);
            RotateRightForSeconds(secondToMove);
        }
        public void RotateLeftForAngle(float angleInDegree)
        {

            float secondToMove = (float)(angleInDegree / m_rotateAnglePerSecond);
            RotateLeftForSeconds(secondToMove);
        }

#endregion 



// public int m_firePower1 = 1049;//1
#region  WRAPPER KEY FIREPOWER1
public void SetKeyDownFirePower1(bool isPressingDown)
    => SetKeyDown(m_firePower1, isPressingDown);
public void StartFirePower1()
    => PressKey(m_firePower1);
public void StopFirePower1()
    => ReleaseKey(m_firePower1);
public void StrokeFirePower1Seconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_firePower1, seconds);
public void StrokeFirePower1Milliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_firePower1, milliseconds);
#endregion






        // public int m_firePower2 = 1050;//2

        #region  WRAPPER KEY FIREPOWER2

        public void SetKeyDownFirePower2(bool isPressingDown)
            => SetKeyDown(m_firePower2, isPressingDown);
        public void StartFirePower2()
            => PressKey(m_firePower2);
        public void StopFirePower2()
            => ReleaseKey(m_firePower2);    
        public void StrokeFirePower2Seconds(float seconds)
            => PressAndReleaseWithDelayInSeconds(m_firePower2, seconds);
        public void StrokeFirePower2Milliseconds(int milliseconds)
            => PressAndReleaseWithDelayInMilliseconds(m_firePower2, milliseconds);
        #endregion

        // public int m_firePower3 = 1051;//3
        #region  WRAPPER KEY FIREPOWER3
        public void SetKeyDownFirePower3(bool isPressingDown)
            => SetKeyDown(m_firePower3, isPressingDown);
        public void StartFirePower3()
            => PressKey(m_firePower3);
        public void StopFirePower3()
            => ReleaseKey(m_firePower3);
        public void StrokeFirePower3Seconds(float seconds)
            => PressAndReleaseWithDelayInSeconds(m_firePower3, seconds);
        public void StrokeFirePower3Milliseconds(int milliseconds)
            => PressAndReleaseWithDelayInMilliseconds(m_firePower3, milliseconds);
        #endregion


// public int m_firePower4 = 1052;//4
#region  WRAPPER KEY FIREPOWER4
public void SetKeyDownFirePower4(bool isPressingDown)
    => SetKeyDown(m_firePower4, isPressingDown);
public void StartFirePower4()
    => PressKey(m_firePower4);
public void StopFirePower4()
    => ReleaseKey(m_firePower4);
public void StrokeFirePower4Seconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_firePower4, seconds);
public void StrokeFirePower4Milliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_firePower4, milliseconds);
#endregion

// public int m_firePower5 = 1053;//5
#region  WRAPPER KEY FIREPOWER5
public void SetKeyDownFirePower5(bool isPressingDown)
    => SetKeyDown(m_firePower5, isPressingDown);
public void StartFirePower5()
    => PressKey(m_firePower5);
public void StopFirePower5()
    => ReleaseKey(m_firePower5);
public void StrokeFirePower5Seconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_firePower5, seconds);
public void StrokeFirePower5Milliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_firePower5, milliseconds);
#endregion

// public int m_firePower6 = 1054;//6
#region  WRAPPER KEY FIREPOWER6
public void SetKeyDownFirePower6(bool isPressingDown)
    => SetKeyDown(m_firePower6, isPressingDown);
public void StartFirePower6()
    => PressKey(m_firePower6);
public void StopFirePower6()
    => ReleaseKey(m_firePower6);
public void StrokeFirePower6Seconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_firePower6, seconds);
public void StrokeFirePower6Milliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_firePower6, milliseconds);
#endregion

// public int m_firePower7 = 1055;//7
#region  WRAPPER KEY FIREPOWER7
public void SetKeyDownFirePower7(bool isPressingDown)
    => SetKeyDown(m_firePower7, isPressingDown);
public void StartFirePower7()
    => PressKey(m_firePower7);
public void StopFirePower7()
    => ReleaseKey(m_firePower7);
public void StrokeFirePower7Seconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_firePower7, seconds);
public void StrokeFirePower7Milliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_firePower7, milliseconds);
#endregion

// public int m_firePower8 = 1056;//8
#region  WRAPPER KEY FIREPOWER8
public void SetKeyDownFirePower8(bool isPressingDown)
    => SetKeyDown(m_firePower8, isPressingDown);
public void StartFirePower8()
    => PressKey(m_firePower8);
public void StopFirePower8()
    => ReleaseKey(m_firePower8);
public void StrokeFirePower8Seconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_firePower8, seconds);
public void StrokeFirePower8Milliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_firePower8, milliseconds);
#endregion

// public int m_firePower9 = 1057;//9
#region  WRAPPER KEY FIREPOWER9
public void SetKeyDownFirePower9(bool isPressingDown)
    => SetKeyDown(m_firePower9, isPressingDown);
public void StartFirePower9()
    => PressKey(m_firePower9);
public void StopFirePower9()
    => ReleaseKey(m_firePower9);
public void StrokeFirePower9Seconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_firePower9, seconds);
public void StrokeFirePower9Milliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_firePower9, milliseconds);
#endregion

// public int m_firePower0 = 1048;//0
#region  WRAPPER KEY FIREPOWER0
public void SetKeyDownFirePower0(bool isPressingDown)
    => SetKeyDown(m_firePower0, isPressingDown);
public void StartFirePower0()
    => PressKey(m_firePower0);
public void StopFirePower0()
    => ReleaseKey(m_firePower0);
public void StrokeFirePower0Seconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_firePower0, seconds);
public void StrokeFirePower0Milliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_firePower0, milliseconds);
#endregion

// public int m_targetNextEnemy = 1009;//Tab
#region  WRAPPER KEY TARGET NEXT ENEMY
public void SetKeyDownTargetNextEnemy(bool isPressingDown)
    => SetKeyDown(m_targetNextEnemy, isPressingDown);
public void StartTargetNextEnemy()
    => PressKey(m_targetNextEnemy);
public void StopTargetNextEnemy()
    => ReleaseKey(m_targetNextEnemy);
public void StrokeTargetNextEnemySeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_targetNextEnemy, seconds);
public void StrokeTargetNextEnemyMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_targetNextEnemy, milliseconds);
#endregion

// public int m_targetNextAlly = 1088;//x
#region  WRAPPER KEY TARGET NEXT ALLY
public void SetKeyDownTargetNextAlly(bool isPressingDown)
    => SetKeyDown(m_targetNextAlly, isPressingDown);
public void StartTargetNextAlly()
    => PressKey(m_targetNextAlly);
public void StopTargetNextAlly()
    => ReleaseKey(m_targetNextAlly);
public void StrokeTargetNextAllySeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_targetNextAlly, seconds);
public void StrokeTargetNextAllyMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_targetNextAlly, milliseconds);
#endregion

// public int m_toggleMap = 1077;//m
#region  WRAPPER KEY TOGGLE MAP
public void SetKeyDownToggleMap(bool isPressingDown)
    => SetKeyDown(m_toggleMap, isPressingDown);
public void StartToggleMap()
    => PressKey(m_toggleMap);
public void StopToggleMap()
    => ReleaseKey(m_toggleMap);
public void StrokeToggleMapSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_toggleMap, seconds);
public void StrokeToggleMapMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_toggleMap, milliseconds);
#endregion

// public int m_toggleMenuSkills = 1075;//k
#region  WRAPPER KEY TOGGLE MENU SKILLS
public void SetKeyDownToggleMenuSkills(bool isPressingDown)
    => SetKeyDown(m_toggleMenuSkills, isPressingDown);
public void StartToggleMenuSkills()
    => PressKey(m_toggleMenuSkills);
public void StopToggleMenuSkills()
    => ReleaseKey(m_toggleMenuSkills);
public void StrokeToggleMenuSkillsSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_toggleMenuSkills, seconds);
public void StrokeToggleMenuSkillsMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_toggleMenuSkills, milliseconds);
#endregion

// public int m_toggleMenuCharacter = 1067;//c
#region  WRAPPER KEY TOGGLE MENU CHARACTER
public void SetKeyDownToggleMenuCharacter(bool isPressingDown)
    => SetKeyDown(m_toggleMenuCharacter, isPressingDown);
public void StartToggleMenuCharacter()
    => PressKey(m_toggleMenuCharacter);
public void StopToggleMenuCharacter()
    => ReleaseKey(m_toggleMenuCharacter);
public void StrokeToggleMenuCharacterSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_toggleMenuCharacter, seconds);
public void StrokeToggleMenuCharacterMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_toggleMenuCharacter, milliseconds);
#endregion

// public int m_toggleMenuInventory = 1066;//b
#region  WRAPPER KEY TOGGLE MENU INVENTORY
public void SetKeyDownToggleMenuInventory(bool isPressingDown)
    => SetKeyDown(m_toggleMenuInventory, isPressingDown);
public void StartToggleMenuInventory()
    => PressKey(m_toggleMenuInventory);
public void StopToggleMenuInventory()
    => ReleaseKey(m_toggleMenuInventory);
public void StrokeToggleMenuInventorySeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_toggleMenuInventory, seconds);
public void StrokeToggleMenuInventoryMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_toggleMenuInventory, milliseconds);
#endregion

// public int m_toggleMenuClan = 1071;//g
#region  WRAPPER KEY TOGGLE MENU CLAN
public void SetKeyDownToggleMenuClan(bool isPressingDown)
    => SetKeyDown(m_toggleMenuClan, isPressingDown);
public void StartToggleMenuClan()
    => PressKey(m_toggleMenuClan);
public void StopToggleMenuClan()
    => ReleaseKey(m_toggleMenuClan);
public void StrokeToggleMenuClanSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_toggleMenuClan, seconds);
public void StrokeToggleMenuClanMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_toggleMenuClan, milliseconds);
#endregion

// public int m_toggleMenuPVP = 1086;//v
#region  WRAPPER KEY TOGGLE MENU PVP
public void SetKeyDownToggleMenuPVP(bool isPressingDown)
    => SetKeyDown(m_toggleMenuPVP, isPressingDown);
public void StartToggleMenuPVP()
    => PressKey(m_toggleMenuPVP);
public void StopToggleMenuPVP()
    => ReleaseKey(m_toggleMenuPVP);
public void StrokeToggleMenuPVPSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_toggleMenuPVP, seconds);
public void StrokeToggleMenuPVPMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_toggleMenuPVP, milliseconds);
#endregion

// public int m_toggleMenuParty = 1080;//p
#region  WRAPPER KEY TOGGLE MENU PARTY
public void SetKeyDownToggleMenuParty(bool isPressingDown)
    => SetKeyDown(m_toggleMenuParty, isPressingDown);
public void StartToggleMenuParty()
    => PressKey(m_toggleMenuParty);
public void StopToggleMenuParty()
    => ReleaseKey(m_toggleMenuParty);
public void StrokeToggleMenuPartySeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_toggleMenuParty, seconds);
public void StrokeToggleMenuPartyMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_toggleMenuParty, milliseconds);
#endregion

// public int m_toggleMenuSocial = 1073;//i
#region  WRAPPER KEY TOGGLE MENU SOCIAL
public void SetKeyDownToggleMenuSocial(bool isPressingDown)
    => SetKeyDown(m_toggleMenuSocial, isPressingDown);
public void StartToggleMenuSocial()
    => PressKey(m_toggleMenuSocial);
public void StopToggleMenuSocial()
    => ReleaseKey(m_toggleMenuSocial);
public void StrokeToggleMenuSocialSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_toggleMenuSocial, seconds);
public void StrokeToggleMenuSocialMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_toggleMenuSocial, milliseconds);
#endregion

// public int m_toggleUntarget = 1027;//escape
#region  WRAPPER KEY TOGGLE UNTARGET
public void SetKeyDownToggleUntarget(bool isPressingDown)
    => SetKeyDown(m_toggleUntarget, isPressingDown);
public void StartToggleUntarget()
    => PressKey(m_toggleUntarget);
public void StopToggleUntarget()
    => ReleaseKey(m_toggleUntarget);
public void StrokeToggleUntargetSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_toggleUntarget, seconds);
public void StrokeToggleUntargetMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_toggleUntarget, milliseconds);
#endregion

// public int m_mouseClickLeft = 1260;
#region  WRAPPER MOUSE CLICK LEFT
public void SetMouseClickLeft(bool isPressingDown)
    => SetKeyDown(m_mouseClickLeft, isPressingDown);
public void StartMouseClickLeft()
    => PressKey(m_mouseClickLeft);
public void StopMouseClickLeft()
    => ReleaseKey(m_mouseClickLeft);
public void StrokeMouseClickLeftSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_mouseClickLeft, seconds);
public void StrokeMouseClickLeftMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_mouseClickLeft, milliseconds);
#endregion

// public int m_mouseClickMiddle = 1261;
#region  WRAPPER MOUSE CLICK MIDDLE
public void SetMouseClickMiddle(bool isPressingDown)
    => SetKeyDown(m_mouseClickMiddle, isPressingDown);
public void StartMouseClickMiddle()
    => PressKey(m_mouseClickMiddle);
public void StopMouseClickMiddle()
    => ReleaseKey(m_mouseClickMiddle);
public void StrokeMouseClickMiddleSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_mouseClickMiddle, seconds);
public void StrokeMouseClickMiddleMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_mouseClickMiddle, milliseconds);
#endregion

// public int m_mouseClickRight = 1263;
#region  WRAPPER MOUSE CLICK RIGHT
public void SetMouseClickRight(bool isPressingDown)
    => SetKeyDown(m_mouseClickRight, isPressingDown);
public void StartMouseClickRight()
    => PressKey(m_mouseClickRight);
public void StopMouseClickRight()
    => ReleaseKey(m_mouseClickRight);
public void StrokeMouseClickRightSeconds(float seconds)
    => PressAndReleaseWithDelayInSeconds(m_mouseClickRight, seconds);
public void StrokeMouseClickRightMilliseconds(int milliseconds)
    => PressAndReleaseWithDelayInMilliseconds(m_mouseClickRight, milliseconds);
#endregion


    }
}