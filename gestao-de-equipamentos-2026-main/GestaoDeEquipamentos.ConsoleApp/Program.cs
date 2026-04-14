
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp;

Equipamiento[]? equipamientos = new Equipamiento[100];

Equipamiento testeEquipe = new Equipamiento();



testeEquipe.id= Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);
testeEquipe.name= "Monitor";
testeEquipe.manufacture= "Acer";
testeEquipe.price=2000;
testeEquipe.manufactureDate = DateTime.Now;

equipamientos[0] = testeEquipe;

while (true)
{
    Console.Clear();
    Console.WriteLine("==================================");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("==================================");
    Console.WriteLine("1 - Cadastrar equipamento");
    Console.WriteLine("2 - Editar equipamento");
    Console.WriteLine("3 - Excluir equipamento");
    Console.WriteLine("4 - Visualizar equipamentos");
    Console.WriteLine("S - Sair");
    Console.WriteLine("==================================");
    Console.Write("> ");
    string? menuOption = Console.ReadLine()?.ToUpper();

    if (menuOption == "S")
    {
        Console.Clear();
        break;
    }

    if (menuOption == "1")
    {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("==================================");
        Console.WriteLine("Cadastro de equipamento");
        Console.WriteLine("==================================");

        Equipamiento newEquipamiento = new Equipamiento();

        do
        {
            Console.WriteLine("Digite o name do equipamento:");
            newEquipamiento.name = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(newEquipamiento.name) && newEquipamiento.name.Length > 3)
            {
                break;
            }

        }while(true);

        do
        {
            Console.WriteLine("Digite fabricante do equipamento: ");
            newEquipamiento.manufacture = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(newEquipamiento.manufacture) && newEquipamiento.manufacture.Length > 2)
            {
                break;
            }
            

        }while(true);

        Console.WriteLine("Digite o preço de aquisição R$");
        newEquipamiento.price =Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite a data de fabricação do equipamento (yyyy/MM/dd) ");
        newEquipamiento.manufactureDate = Convert.ToDateTime(Console.ReadLine());

        newEquipamiento.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        for(int i=0; i < equipamientos.Length; i++)
        {
            Equipamiento? e =  equipamientos[i];

            if(e == null)
            {
                equipamientos[i]= newEquipamiento;
                break;
            }
        }

        Console.WriteLine("==================================");
        Console.WriteLine($"O registro do \"{newEquipamiento.name}\" foi cadastrado com sucesso");
        Console.WriteLine("==================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    else if (menuOption == "2")
    {
        Console.WriteLine("==================================");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("==================================");
        Console.WriteLine("Edição de equipamento");

        Console.WriteLine(
        "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
        "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
        );
        
          
        for(int i = 0; i < equipamientos.Length; i++)
        {
            Equipamiento? e = equipamientos[i];

            if(e == null)
                continue;

            Console.WriteLine(
                "{0,  -7} | {1,  -15} | {2,  -15} | {3,  -22} | {4,  -10}",
                e.id, e.name, e.manufacture, e.price.ToString("C2"), e.manufactureDate.ToShortDateString()
            );    
        }
        
        Console.WriteLine("==================================");


        string? idSelecionado;
        do
        {
            Console.WriteLine("Digite o ID do equipamento que deseja editar: ");
            idSelecionado = Console.ReadLine();
            
            if(!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;

        }while(true);

        //2 buscar/validar o equipamento

        Equipamiento? equipamentoSelecionado = null;

        for(int i = 0; i < equipamientos.Length ;i++)
        {
            Equipamiento? e = equipamientos[i];

            if(e == null)
                continue;
            
            if(e.id == idSelecionado)
            {
                equipamentoSelecionado = e;
                break;
            }   
        }
        
        if(idSelecionado == null)
        {
            Console.WriteLine("==================================");
            Console.WriteLine($"Não fio possivle encontrar o equipamento selecionado");
            Console.WriteLine("==================================");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            continue;
        }

        //3 Subtitui as informacion dos campos do equipamento pelas novas

        Equipamiento newEquipamiento = new Equipamiento();


        do
        {
            Console.WriteLine("Digite o name do equipamento:");
            newEquipamiento.name = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(newEquipamiento.name) && newEquipamiento.name.Length > 3)
            {
                break;
            }

        }while(true);

        do
        {
            Console.WriteLine("Digite fabricante do equipamento: ");
            newEquipamiento.manufacture = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(newEquipamiento.manufacture) && newEquipamiento.manufacture.Length > 2)
            {
                break;
            }
            

        }while(true);

        Console.WriteLine("Digite o preço de aquisição R$");
        newEquipamiento.price =Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite a data de fabricação do equipamento (yyyy/MM/dd) ");
        newEquipamiento.manufactureDate = Convert.ToDateTime(Console.ReadLine());
            
        equipamentoSelecionado.name = newEquipamiento.name;
        equipamentoSelecionado.manufacture = newEquipamiento.manufacture;
        equipamentoSelecionado.price = newEquipamiento.price;
        equipamentoSelecionado.manufactureDate = newEquipamiento.manufactureDate;

        

        Console.WriteLine("==================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    else if (menuOption == "3")
    {
        /*1.4: Como funcionário, Junior quer ter a possibilidade de excluir um equipamento que esteja
        registrado.
        • A lista de equipamentos deve ser atualizada*/


        Console.WriteLine("==================================");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("==================================");
        Console.WriteLine("Edição de equipamento");

        Console.WriteLine(
        "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
        "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
        );
        
          
        for(int i = 0; i < equipamientos.Length; i++)
        {
            Equipamiento? e = equipamientos[i];

            if(e == null)
                continue;

            Console.WriteLine(
                "{0,  -7} | {1,  -15} | {2,  -15} | {3,  -22} | {4,  -10}",
                e.id, e.name, e.manufacture, e.price.ToString("C2"), e.manufactureDate.ToShortDateString()
            );    
        }

        string? idSelecionado;
        do
        {
            Console.WriteLine("Digite o ID do equipamento que deseja excluir: ");
            idSelecionado = Console.ReadLine();
            
            if(!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;

        }while(true);

        //buscar el espacio donde esta almacenado el equipamiento.

        bool equipamentoExcluido = false;

        for(int i = 0; i< equipamientos.Length; i++)
        {
            Equipamiento? e = equipamientos[i];
            
            if( e== null)
                continue;
            if(e.id == idSelecionado)
            {
                equipamientos[i] = null;
                equipamentoExcluido = true;
                break;
            }    
        }

        if (equipamentoExcluido)
        {
            Console.WriteLine("==================================");
            Console.WriteLine($"O registro do \"{idSelecionado}\" foi excluido com sucesso");
            Console.WriteLine("==================================");
        }
        else
        {   
            Console.WriteLine("==================================");
            Console.WriteLine($"O registro selecionado \"{idSelecionado}\" não foi encontrado.");
            Console.WriteLine("==================================");
        }

        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    else if (menuOption == "4")
    {
        
        Console.WriteLine("==================================");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("==================================");
        Console.WriteLine("Visualização de equipamentos");

        Console.WriteLine(
        "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
        "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
        );
        
          
        for(int i = 0; i < equipamientos.Length; i++)
        {
            Equipamiento? e = equipamientos[i];

            if(e == null)
                continue;

            Console.WriteLine(
                "{0,  -7} | {1,  -15} | {2,  -15} | {3,  -22} | {4,  -10}",
                e.id, e.name, e.manufacture, e.price.ToString("C2"), e.manufactureDate.ToShortDateString()
            );    
        }
        
        Console.WriteLine("==================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }
}
