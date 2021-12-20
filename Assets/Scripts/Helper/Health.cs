using System;


namespace DinoHitMaster.Helper
{
    public class Health
    {
        public event Action OnDeath;

        public float CurrentHp { get; private set; }

        public Health(float currentHp)
        {
            CurrentHp = currentHp;
        }

        public void Damage(float damage)
        {
            CurrentHp -= damage;
            if (CurrentHp <= 0)
                OnDeath?.Invoke();
        }
    }
}
