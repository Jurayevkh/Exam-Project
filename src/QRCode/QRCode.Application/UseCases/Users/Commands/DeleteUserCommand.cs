﻿namespace QRCode.Application.UseCases.Users.Commands;

public class DeleteUserCommand:IRequest<bool>
{
    public int Id { get; set; }
}

