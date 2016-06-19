#pragma strict

var Health = 100;
var cadalDammage : int;
var EnemyName : String;

function Awake()
{
	EnemyName = gameObject.transform.name;
}

function OnCollisionEnter(col : Collision)
{
	if(col.gameObject.tag == "cadal")
	{
		ApplyDammage(cadalDammage);
	}
}

function ApplyDammage (TheDammage : int)
{
	Health -= TheDammage;
	
	if(Health <= 0)
	{
	    GameObject.Find(EnemyName).GetComponent(AdvancedAI).enabled = false;
	    GetComponent.<Animation>().Play("death");
	    GetComponent.<Animation>()["death"].speed = 1;
	    yield WaitForSeconds (10);
		Dead();
	}
}

function Dead()
{
	Destroy (gameObject);
}