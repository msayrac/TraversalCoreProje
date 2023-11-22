using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
	public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
	{
		public AnnouncementUpdateValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez");
			RuleFor(x => x.Content).NotEmpty().WithMessage("Duyuru Alanı Boş Geçilemez");
			RuleFor(x => x.Title).MinimumLength(5).WithMessage("En Az 5 Karakter Veri Girişi Yapınız");
			RuleFor(x => x.Content).MinimumLength(5).WithMessage("En Az 5 Karakter Veri Girişi Yapınız");
			RuleFor(x => x.Title).MaximumLength(50).WithMessage("En Az Fazla 50 Karakter Veri Girişi Yapınız");
			RuleFor(x => x.Content).MaximumLength(500).WithMessage("En Fazla 500 Karakter Veri Girişi Yapınız");



		}
	}
}
