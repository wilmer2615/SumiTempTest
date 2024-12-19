using DataTransferObjects;

namespace Logic.PersonLogic
{
    public interface IPersonLogic
    {
        public Task<PersonDto> AddPersonAsync(PersonDto personDto);
    }
}
