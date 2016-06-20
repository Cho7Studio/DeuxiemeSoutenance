#pragma strict
function Start()
{
	Time.timeScale = 1f;
}

function NouvellePartie()
{
	Application.LoadLevel("Scene.1");
}

function ChargerNival()
{
	Application.LoadLevel("ChargerNival");
}

function Quitter()
{
	Application.Quit();
}

function Courses()
{
	Application.LoadLevel("MenuCourse");
}

function CTC()
{
	Application.LoadLevel("MenuCTC");
}

function RetourMenu()
{
	Application.LoadLevel("Menu");
}

function Multi()
{
	Application.LoadLevel("MenuMulti");
}

function Combat()
{
	Application.LoadLevel("MenuCombat");
}