using System;


namespace DinoHitMaster.Helper
{
    public class Health
    {
        public event Action OnDeath;

        public float Max { get; }
        public float CurrentHp { get; private set; }

        public Health(float currentHp)
        {
            CurrentHp = currentHp;
            Max = currentHp;
        }

        public void SetHp(float? hp = null)
        {
            CurrentHp = hp ?? Max;
        }

        public void Damage(float damage)
        {
            CurrentHp -= damage;
            if (CurrentHp <= 0)
            {
                OnDeath?.Invoke();
            }
                
        }
    }
}
