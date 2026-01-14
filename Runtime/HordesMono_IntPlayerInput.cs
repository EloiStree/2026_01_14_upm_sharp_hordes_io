using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class HordesMono_IntPlayerInput : MonoBehaviour
{
    /*
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
    public UnityEvent<int,int> m_onActionIntegerRequestedWithDelayInMilliseconds;

    public int m_moveForward = 1038;
    public int m_moveBackward = 1040;
    public int m_moveLeft= 1081;
    public int m_moveRight = 1069;
    public int m_rotateLeft = 1037;
    public int m_rotateRight = 1039;
    public int m_jump = 1032;
    public int m_firePower1 = 1049;
    public int m_selectEnemy = 1009;
    public int m_toggleMap = 1077;

    public float m_rotateAnglePerSecond = 170;
    public float m_moveForwardSpeedPerSecond = 5.2f;
    public float m_moveLeftRightSpeedPerSecond = 5.2f;
    public float m_moveBackwardSpeedPerSecond = 1.5f;


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

    // Move Forward
    public void SetKeyDownMoveForward(bool isPressingDown) => SetKeyDown(m_moveForward, isPressingDown);
    public void StartMovingForward() => PressKey(m_moveForward);
    public void StopMovingForward() => ReleaseKey(m_moveForward);

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

    // Fire Power 1
    public void SetKeyDownFirePower1(bool isPressingDown) => SetKeyDown(m_firePower1, isPressingDown);
    public void StartFirePower1() => PressKey(m_firePower1);
    public void StopFirePower1() => ReleaseKey(m_firePower1);


    // Fire Power 1
    public void SetKeyDownSelectEnemy(bool isPressingDown) => SetKeyDown(m_selectEnemy, isPressingDown);
    public void StartSelectEnemy() => PressKey(m_selectEnemy);
    public void StopSelectEnemey() => ReleaseKey(m_selectEnemy);


    // Fire Power 1
    public void SetKeyDownToggleMap(bool isPressingDown) => SetKeyDown(m_toggleMap, isPressingDown);
    public void StartToggleMap() => PressKey(m_toggleMap);
    public void StopToggleMap() => ReleaseKey(m_toggleMap);

    public void StrokeToggleMap() { 
    
        PressKey(m_toggleMap);
        ReleaseKeyWithDelay(m_toggleMap, 100);
    }

    public void PressKeyWithDelay(int key, int delayInMilliseconds)
    {

        m_onActionIntegerRequestedWithDelayInMilliseconds.Invoke(key, delayInMilliseconds);

    }

    public void ReleaseKeyWithDelay(int key, int delayInMilliseconds)
    {

        m_onActionIntegerRequestedWithDelayInMilliseconds.Invoke(key + 1000, delayInMilliseconds);

    }



    public void PressAndReleaseWithDelayInSeconds(int key, float seconds) {


        PressKey(key);
        ReleaseKeyWithDelay(key, (int)(seconds * 1000f));
    }

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
    public void RotateRightForSeconds(float secondsToMove)
    {
        PressAndReleaseWithDelayInSeconds(m_rotateRight, secondsToMove);

    }
    public void RotateLeftForSeconds(float secondsToMove)
    {
        PressAndReleaseWithDelayInSeconds(m_rotateLeft, secondsToMove);
    }


    public void MoveForwardForDistance(float distance)
    {

        float secondToMove = (float)(distance / m_moveForwardSpeedPerSecond);
        MoveForwardForSeconds(secondToMove);
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





    public void StrokeToggleMapCoroutineVersion()
    {

        StartCoroutine(Coroutine_StrokeToggleMap());
    }
    // With Coroutine
    public IEnumerator Coroutine_StrokeToggleMap()
    {

        StartToggleMap();
        yield return new WaitForSeconds(0.1f);
        StopToggleMap();
    }
}
