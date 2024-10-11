using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;      // Tốc độ di chuyển của đạn
    [SerializeField] private float resetTime;  // Thời gian tối đa trước khi đạn tự động biến mất
    private float lifetime;                    // Thời gian tồn tại của đạn

    // Kích hoạt đạn và thiết lập lại thời gian sống
    public void ActivateProjectile()
    {
        lifetime = 0;               // Đặt lại thời gian sống của đạn
        gameObject.SetActive(true);  // Kích hoạt đạn (hiển thị lại nếu nó đã bị tắt)
    }

    // Cập nhật vị trí và kiểm tra thời gian sống của đạn
    private void Update()
    {
        // Tính toán tốc độ di chuyển theo thời gian
        float movementSpeed = speed * Time.deltaTime;

        // Di chuyển đạn theo trục x
        transform.Translate(movementSpeed, 0, 0);

        // Cập nhật thời gian sống của đạn
        lifetime += Time.deltaTime;

        // Kiểm tra nếu đạn tồn tại quá thời gian đặt trước thì tắt đạn
        if (lifetime > resetTime)
        {
            gameObject.SetActive(false); // Tắt đạn (ẩn khỏi màn hình)
        }
    }

}
