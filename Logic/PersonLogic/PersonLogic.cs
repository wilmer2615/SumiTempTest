using AutoMapper;
using DataTransferObjects;
using Entities;
using Repository.Repository.AddressRepository;
using Repository.Repository.EmailRepository;
using Repository.Repository.PersonRepository;
using Repository.Repository.PhoneRepository;

namespace Logic.PersonLogic
{
    public class PersonLogic : IPersonLogic
    {
        private readonly IMapper _mapper;

        private readonly IPersonRepository _personRepository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly IAddressRepository _addressRepository;


        public PersonLogic(IMapper mapper,
            IPersonRepository personRepository,
            IPhoneRepository phoneRepository,
            IEmailRepository emailRepository,
            IAddressRepository addressRepository)
        {
            this._mapper = mapper;
            this._personRepository = personRepository;
            this._addressRepository = addressRepository;
            this._phoneRepository = phoneRepository;
            this._emailRepository = emailRepository;

        }
        public async Task<PersonDto> AddPersonAsync(PersonDto personDto)
        {
            var existingPerson = await _personRepository.FindPersonByDocumentNumberAsync(personDto.DocumentNumber);
            if (existingPerson != null)
            {
                return new PersonDto { ErrorMessage = "Ya existe una persona con el mismo documento de identidad." };
            }

            PersonDto validationResult = this.Validations(personDto);
            if (!string.IsNullOrEmpty(validationResult.ErrorMessage))
            {
                return validationResult;
            }

            var entity = await this._personRepository.AddPersonAsync(_mapper.Map<Person>(personDto));

            await this.AddPhonesAsync(entity.IdPerson, personDto.Phones);
            await this.AddEmailsAsync(entity.IdPerson, personDto.Emails);
            await this.AddAddressesAsync(entity.IdPerson, personDto.Addresses);

            var result = _mapper.Map<PersonDto>(entity);

            return result;
        }
        private async Task AddPhonesAsync(int personId, List<string> phones)
        {
            var phonesToAdd = new List<Phone>();
            
            foreach (var phoneNumber in phones)
            {
                phonesToAdd.Add(new Phone
                {
                    IdPerson = personId,
                    PhoneNumber = phoneNumber
                });
            }

            await this._phoneRepository.AddPhonesAsync(phonesToAdd);
        }

        private async Task AddEmailsAsync(int personId, List<string> emails)
        {
            var emailsToAdd = new List<Email>();

            foreach (var email in emails)
            {
                emailsToAdd.Add(new Email
                {
                    IdPerson = personId,
                    EmailAddres = email
                });
            }

            await this._emailRepository.AddEmailsAsync(emailsToAdd);
        }

        private async Task AddAddressesAsync(int personId, List<string> addresses)
        {
            var addressToAdd = new List<Address>();

            foreach (var address in addresses)
            {
                addressToAdd.Add(new Address
                {
                    IdPerson = personId,
                    Description = address
                });
            }

            await this._addressRepository.AddAddressesAsync(addressToAdd);
        }

        private PersonDto Validations(PersonDto personDto)
        {
            // Validación de información de contacto
            bool hasContactInfo = personDto.Phones.Count > 0 || personDto.Emails.Count > 0 || personDto.Addresses.Count > 0;
            if (!hasContactInfo)
            {
                return new PersonDto { ErrorMessage = "Debe registrar al menos un número telefónico, un correo electrónico o una dirección física." };
            }

            // Validación de máximos
            if (personDto.Phones.Count > 2)
            {
                return new PersonDto { ErrorMessage = "No se pueden registrar más de 2 números telefónicos." };
            }

            if (personDto.Emails.Count > 2)
            {
                return new PersonDto { ErrorMessage = "No se pueden registrar más de 2 correos electrónicos." };
            }

            if (personDto.Addresses.Count > 2)
            {
                return new PersonDto { ErrorMessage = "No se pueden registrar más de 2 direcciones físicas." };
            }

            return personDto;
        }

    }
}
