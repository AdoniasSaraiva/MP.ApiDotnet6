﻿using MP.ApiDotNet6.Domain.Entities.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class PersonImage
    {
        public long Id { get; set; }
        public int PersonId { get; set; }
        public string? ImageUri { get; set; }
        public string? ImageBase { get; set; }
        public Person Person { get; set; }

        public PersonImage(int personId, string? imageUri, string? imageBase)
        {
            Validation(personId);
            ImageUri = imageUri;
            ImageBase = imageBase;
        }

        private void Validation(int personId)
        {
            DomainValidationException.When(personId == 0, "Id Pessoa deve ser informado");
            PersonId = personId;
        }
    }
}
