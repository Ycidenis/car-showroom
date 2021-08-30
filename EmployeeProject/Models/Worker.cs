using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Models
{
	public sealed record Worker
	{
		[FromForm, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; init; }
		[FromForm]
		public string LastName { get; init; }
		[FromForm]
		public string Initials { get; init; }
		[FromForm]
		public string Position { get; init; }
		[FromForm]
		public int YearOfWorkBeginning { get; init; }
		[FromForm]
		public decimal Salary { get; init; }
	}
}