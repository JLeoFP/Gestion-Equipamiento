
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

Equipamiento[]? equipamientos = new Equipamiento[100];

Equipamiento testeEquipe = new Equipamiento();
TelaEquipamento telaEquipamento = new TelaEquipamento();


testeEquipe.id= Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);
testeEquipe.name= "Monitor";
testeEquipe.manufacture= "Acer";
testeEquipe.price=2000;
testeEquipe.manufactureDate = DateTime.Now;

equipamientos[0] = testeEquipe;

while (true)
{
    string? menuOption = telaEquipamento.MainMenu();
    if (menuOption == "S")
    {
        Console.Clear();
        break;
    }

    if (menuOption == "1")
    {
        telaEquipamento.Cadastrar(equipamientos);
    }
    else if (menuOption == "2")
    {
        telaEquipamento.Editar(equipamientos);
    }
    else if (menuOption == "3")
    {
        telaEquipamento.Excluir(equipamientos);
    }

    else if (menuOption == "4")
    {
        telaEquipamento.VisualizarTodos(equipamientos);
    }
}
