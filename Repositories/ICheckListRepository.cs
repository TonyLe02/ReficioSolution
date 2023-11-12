using ReficioSolution.Models.CheckList;

namespace ReficioSolution.Repositories;

    public interface ICheckListRepository
    {
        public IEnumerable<CheckListViewModel> GetAll();
    }