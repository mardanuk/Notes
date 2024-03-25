using Notes.BusinessLogic.Abstraction;
using Notes.Domain;
using Notes.Repository.Abstracion;

namespace Notes.BusinessLogic.Proceed
{
    public class AccessesProceed : IAccessesProceed
    {
        private readonly IAccessesRepository _repository;

        public AccessesProceed(IAccessesRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAccess(string header, int userid)
        {
            return string.IsNullOrWhiteSpace(header)
                 ? await _repository.AddAccess(header, userid)
                 : false;
        }

        public async Task<ICollection<Note>?> GetNotes(int userid)
        {
            return await _repository.GetNotes(userid);
        }

        public async Task<ICollection<User>?> GetUsers(string header)
        {
            return string.IsNullOrWhiteSpace(header)
                ? await _repository.GetUsers(header)
                : null;
        }
    }
}
