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
