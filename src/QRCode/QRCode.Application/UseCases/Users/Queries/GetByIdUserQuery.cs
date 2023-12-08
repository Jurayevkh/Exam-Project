namespace QRCode.Application.UseCases.Users.Queries;

public class GetByIdUserQuery:IRequest<User>
{
    public int Id { get; set; }
}

