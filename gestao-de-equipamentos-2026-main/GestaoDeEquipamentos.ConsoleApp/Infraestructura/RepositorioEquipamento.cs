using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestructura;

public class RepositorioEquipamento
{
    public Equipamiento[]? equipamientos = new Equipamiento[100];

    public void Cadastrar(Equipamiento newEquipamiento)
    {
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
    }

    public bool Editar(string idSelecionado, Equipamiento newEquipamiento)
    {
        Equipamiento? equipamentoSelecionado = SelectForId(idSelecionado);

        if(idSelecionado == null)
            return false;

        equipamentoSelecionado.name = newEquipamiento.name;
        equipamentoSelecionado.manufacture = newEquipamiento.manufacture;
        equipamentoSelecionado.price = newEquipamiento.price;
        equipamentoSelecionado.manufactureDate = newEquipamiento.manufactureDate;

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        
        for(int i = 0; i< equipamientos.Length; i++)
        {
            Equipamiento? e = equipamientos[i];
            
            if( e== null)
                continue;
            if(e.id == idSelecionado)
            {
                equipamientos[i] = null;
                return true;
            }  
        }
        return false;
    }

    public Equipamiento? SelectForId(string idSelecionado)
    {
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

        return equipamentoSelecionado;
    }

    public Equipamiento?[] SelecionarTodos()
    {
        return equipamientos;
    }
}
