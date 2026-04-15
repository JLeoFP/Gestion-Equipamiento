using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestructura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorio = new RepositorioEquipamento();

    public string? MainMenu()
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

        return menuOption;
    }

    public void Cadastrar()
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

        repositorio.Cadastrar(newEquipamiento);

        Console.WriteLine("==================================");
        Console.WriteLine($"O registro do \"{newEquipamiento.name}\" foi cadastrado com sucesso");
        Console.WriteLine("==================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Editar()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("==================================");
        Console.WriteLine("Edição de equipamento");

        Console.WriteLine(
        "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
        "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
        );
        
        Equipamiento?[] equipamientos = repositorio.SelecionarTodos();

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

        Equipamiento newEquipamiento = new Equipamiento();

        do
        {
            Console.WriteLine("Digite o nome do equipamento:");
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
            
        bool consiguioEditar = repositorio.Editar(idSelecionado, newEquipamiento);

        if(!consiguioEditar)
        {
            Console.WriteLine("==================================");
            Console.WriteLine($"Não fio possivle encontrar o equipamento selecionado");
            Console.WriteLine("==================================");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }
        
        Console.WriteLine("==================================");
        Console.WriteLine($"registro do \"{idSelecionado}\" foi editado com sucesso");
        Console.WriteLine("==================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Excluir()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("==================================");
        Console.WriteLine("Edição de equipamento");

        Console.WriteLine(
        "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
        "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
        );

        Equipamiento?[] equipamientos = repositorio.SelecionarTodos();
          
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


        bool consiguiExcluir = repositorio.Excluir(idSelecionado);

        if (consiguiExcluir)
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

    public void VisualizarTodos()
    {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("==================================");
        Console.WriteLine("Visualização de equipamentos");

        Console.WriteLine(
        "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
        "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
        );
        
        Equipamiento?[] equipamientos = repositorio.SelecionarTodos();

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
