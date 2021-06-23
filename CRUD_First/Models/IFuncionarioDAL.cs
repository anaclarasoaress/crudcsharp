using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_First.Models
{
    public interface IFuncionarioDAL
    {
        //metodos basicos para realizar um crud e consultar informações de funcionarios 
        IEnumerable<Funcionario> GetAllFuncionario();
        void AddFuncionario(Funcionario funcionario);
        void UpdateFuncionario(Funcionario funcionario);
        Funcionario GetFuncionario(int? id);
        void DeleteFuncionario(int? id);

    }
}
