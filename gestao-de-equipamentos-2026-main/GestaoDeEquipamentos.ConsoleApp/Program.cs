
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;

TelaEquipamento telaEquipamento = new TelaEquipamento();

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
        telaEquipamento.Cadastrar();
    }
    else if (menuOption == "2")
    {
        telaEquipamento.Editar();
    }
    else if (menuOption == "3")
    {
        telaEquipamento.Excluir();
    }

    else if (menuOption == "4")
    {
        telaEquipamento.VisualizarTodos();
    }
}
