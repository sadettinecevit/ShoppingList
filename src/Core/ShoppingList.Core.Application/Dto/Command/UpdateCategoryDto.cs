﻿using MediatR;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class UpdateCategoryDto : IRequest<int>
	{
		public string Name { get; set; }
		public DateTime CompeleteTime { get; set; }
		public IQueryable<Group> ShoppingGroup { get; set; }
	}

}