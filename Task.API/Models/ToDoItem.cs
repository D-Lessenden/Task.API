﻿using System;

namespace Task.API.Models
{
	public class ToDoItem
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public bool IsCompleted { get; set; }
	
	}
}
