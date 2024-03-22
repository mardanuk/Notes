using Notes.BusinessLogic.Abstraction;
using Notes.Domain;

namespace Notes.BusinessLogic
{
    public class AccessesProceed : IAccessesProceed
    {
        private readonly IAccessesProceed _repository;

        public AccessesProceed(IAccessesProceed repository)
        {
            _repository = repository;
        }

        public async Task<User?> AddAccess(string header, int id)
        {
            return string.IsNullOrWhiteSpace(header)
                 ? await _repository.AddAccess(header, id)
                 : null;
        }

        public async Task<ICollection<Note>?> GetNotes(int id)
        {
            return await _repository.GetNotes(id);
        }

        public async Task<ICollection<User>?> GetUsers(string header)
        {
            return string.IsNullOrWhiteSpace(header)
                ? await _repository.GetUsers(header)
                : null;
        }
    }
}
