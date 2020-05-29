using FluentValidation;
using MoviesLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLab2.ModelValidators
{
	public class MovieValidator : AbstractValidator<Movie>
	{
		public MovieValidator()
		{
			RuleFor(x => x.Id)
				.NotNull();
			RuleFor(x => x.Rating > 4);
			RuleFor(x => x.Title)
				.Length(0, 15);
			RuleFor(x => x.DateAdded)
				.LessThan(DateTime.Now);
		}
	}
}