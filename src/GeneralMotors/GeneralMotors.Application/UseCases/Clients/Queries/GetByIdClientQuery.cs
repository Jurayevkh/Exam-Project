using GeneralMotors.Domain.Entities.Clients;

namespace GeneralMotors.Application.UseCases.Clients.Queries;

public class GetByIdClientQuery:IRequest<Client>
{
    public int Id { get; set; }
}

