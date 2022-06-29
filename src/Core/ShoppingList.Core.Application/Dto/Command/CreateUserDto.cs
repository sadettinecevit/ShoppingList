﻿using MediatR;

namespace ShoppingList.Application.Dto.Command
{
    public class CreateUserDto : IRequest<int>
	{
		public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
