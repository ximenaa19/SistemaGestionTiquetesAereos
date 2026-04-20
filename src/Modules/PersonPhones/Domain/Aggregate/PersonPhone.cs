using GestionAerolineas.src.Modules.PersonPhones.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.PersonPhones.Domain.Aggregate;

public class PersonPhone
{
    public PersonPhoneId Id { get; private set; }
    public PersonPhonePersonId PersonId { get; private set; }
    public PersonPhoneCodeId PhoneCodeId { get; private set; }
    public PersonPhoneNumber PhoneNumber { get; private set; }
    public PersonPhoneIsPrimary IsPrimary { get; private set; }

    private PersonPhone(
        PersonPhoneId id,
        PersonPhonePersonId personId,
        PersonPhoneCodeId phoneCodeId,
        PersonPhoneNumber phoneNumber,
        PersonPhoneIsPrimary isPrimary)
    {
        Id = id;
        PersonId = personId;
        PhoneCodeId = phoneCodeId;
        PhoneNumber = phoneNumber;
        IsPrimary = isPrimary;
    }

    public static PersonPhone Create(
        PersonPhoneId id,
        PersonPhonePersonId personId,
        PersonPhoneCodeId phoneCodeId,
        PersonPhoneNumber phoneNumber,
        PersonPhoneIsPrimary isPrimary)
    {
        return new PersonPhone(id, personId, phoneCodeId, phoneNumber, isPrimary);
    }

    public static PersonPhone CreateNew(
        PersonPhonePersonId personId,
        PersonPhoneCodeId phoneCodeId,
        PersonPhoneNumber phoneNumber,
        PersonPhoneIsPrimary? isPrimary = null)
    {
        return new PersonPhone(
            PersonPhoneId.CreateEmpty(),
            personId,
            phoneCodeId,
            phoneNumber,
            isPrimary ?? PersonPhoneIsPrimary.Create(false)
        );
    }
}

