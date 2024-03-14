using Blogy.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.ArticleValidator
{
    public class CreateArticleValidator : AbstractValidator<Article>
    {
        public CreateArticleValidator()
        {
            RuleFor(x => x.ArticleID).NotEmpty().WithMessage("Makale id' değeri boş geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık değeri boş geçilemez").MinimumLength(5).WithMessage("Makale başlığı 5 karakterden az olamaz.").MaximumLength(20).WithMessage("Makale başlığı en fazla 20 karakter içerecek şekilde yeniden düzenleyiniz. ");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez").MinimumLength(10).WithMessage("Açıklama en az 10 karakter içerecek şekilde yeniden düzenleyiniz");
        }
    }
}
