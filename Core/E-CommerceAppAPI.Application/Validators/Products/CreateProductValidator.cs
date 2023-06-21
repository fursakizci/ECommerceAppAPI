using E_CommerceAppAPI.Application.ViewModels;
using FluentValidation;

namespace E_CommerceAppAPI.Application.Validators.Products;

public class CreateProductValidator:AbstractValidator<VM_Create_Product>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lutfen urun adini giriniz")
            .MaximumLength(150)
            .MinimumLength(5)
            .WithMessage("lutfen urun adini 5 ile 150 karakter arasinda giriniz");

        RuleFor(p => p.Stock)
            .NotEmpty()
            .NotNull()
            .WithMessage("lutfen stok bilgisini giriniz")
            .Must(s => s >= 0)
            .WithMessage("stok bilgisini giriniz");

        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage("lutfen fiyat bilgisini bos gecmeyiniz")
            .Must(s => s >= 0)
            .WithMessage("Fiyat bilgisi negatif olamaz");
    }
}