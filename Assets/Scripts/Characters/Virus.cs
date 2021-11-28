using UnityEngine;

public class Virus : Character, ICanAttack, IDamageable
{
    public int Damage = 1;
    public float Health = 1;
    public bool IsOnBattleField = false;
    void Start()
    {
        GoToWall();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToWall()
    {
        MoveTo(GetVirusDestination(Game.Wall.gameObject.transform.position));
    }

    private Vector3 GetVirusDestination(Vector3 AimPosition)
    {
        float XPos;
        float YPos;
        float ZPos;
        XPos = AimPosition.x;
        YPos = gameObject.transform.position.y;
        ZPos = gameObject.transform.position.z;
        return new Vector3(XPos, YPos, ZPos);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public float GiveDamage()
    {
        return Damage;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0) OnDeath();
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile != null && isCorrectType(projectile))
        {
            TakeDamage(projectile.GiveDamage());
            Destroy(projectile.gameObject);
        }
        if (collision.gameObject.name == "BattleField") IsOnBattleField = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BattleField") IsOnBattleField = false;
    }

    public bool isCorrectType(Projectile projectile)
    {
        // this const is becouse of lenght of name VirusX(Clone) (Clone) == 7 + 1 becose index from 0
        const int compareForType = 8;
        if (this.CharacterGameObject.name.Contains(projectile.name[projectile.name.Length - compareForType] +""))
        {
            return true;
        }
        return false;
    }

    private void OnMouseEnter()
    {
        if(IsOnBattleField) DataHolder.Cannon.CanShoot = true;
    }

    private void OnMouseExit()
    {
        if(IsOnBattleField) DataHolder.Cannon.CanShoot = false;
    }

}
