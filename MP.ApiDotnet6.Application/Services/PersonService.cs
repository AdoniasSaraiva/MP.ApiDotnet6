using AutoMapper;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotnet6.Application.DTOs.Validations;
using MP.ApiDotnet6.Application.Services.Interface;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotnet6.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

            var result = new PersonDTOValidation().Validate(personDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemas de validade!", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);

            return ResultService.OK<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }

        public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
        {
            var people = await _personRepository.GetPeopleAsync();

            return ResultService.OK<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
        {
            if (id == 0)
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

            var data = await _personRepository.GetByIdAsync(id);

            if (data != null)
                return ResultService.OK<PersonDTO>(_mapper.Map<PersonDTO>(data));

            return ResultService.Fail<PersonDTO>("Pessoa Não Encontrada");
        }

        public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                ResultService.Fail("Objeto deve ser informado");

            var validation = new PersonDTOValidation().Validate(personDTO);
            if (!validation.IsValid)
                ResultService.RequestError("Problema com a validação dos campos", validation);

            var person = await _personRepository.GetByIdAsync(personDTO.Id);

            if (person == null)
                return ResultService.Fail("Pessoa Não Encontrada");

            person = _mapper.Map<PersonDTO, Person>(personDTO, person);

            await _personRepository.EditAsync(person);

            return ResultService.OK("Pessoa Editada");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
                return ResultService.Fail<PersonDTO>("Não existe nenhuma pessoa com esse Id");

            await _personRepository.DeleteAsync(person);

            return ResultService.OK($"Pessoa do Id: {id} foi deletada");
        }
    }
}