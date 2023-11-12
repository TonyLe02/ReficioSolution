using ReficioSolution.Models.Serviceform;

namespace ReficioSolution.Repositories;

    public interface IServiceFormRepository
    {
        public IEnumerable<ServiceFormViewModel> GetAll();

        public IEnumerable<ServiceFormViewModel> GetSomeOrderInfo();
        
    }