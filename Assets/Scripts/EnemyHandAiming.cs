using UnityEngine;

public class EnemyHandAiming : MonoBehaviour
{
    [Header("References")]
    public Transform rightHand;
    public Transform leftHand;
    public Transform enemy;
    public Transform player;

    void Update()
    {
        if (player == null) return;

        Vector2 dir = player.position - enemy.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // تشخیص جهت دشمن (چپ یا راست)
        float enemyDir = enemy.localScale.x;

        if (enemyDir > 0)
        {
            // رو به راست
            rightHand.rotation = Quaternion.Euler(0, 0, angle);
            leftHand.rotation = Quaternion.Euler(0, 0, angle * 2f);
        }
        else
        {
            // رو به چپ
            rightHand.rotation = Quaternion.Euler(0, 0, angle + 180f);
            leftHand.rotation = Quaternion.Euler(0, 0, (angle + 180f) * 2f);
        }
    }
}
